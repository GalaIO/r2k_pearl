using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Resources;

using System.Net;
using System.Net.Sockets;

using System.IO;
using Microsoft.Win32;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO.Ports;

namespace R2kDemo
{
    public partial class MainWindow : Form
    {
       [DllImport("ws2_32.dll")]
       public static extern Int32 WSAStartup(UInt16 wVersionRequested,   ref  WSADATA wsaData);
       [DllImport("ws2_32.dll")]
       public static extern Int32 WSACleanup();

       static List<EPC_data> Tag_data = new List<EPC_data>();
       static bool bNewTag = false;
       static int nItemNo = 0; // 记录需要更新的EPC数据索引
       int RWBank = 0;// 记录选择的读写区域及开始、结束地址，便于更新控件
       int addStart = 0;
        int addEnd = 0;
        bool bConnected = false; // 连接标志，由委托的异步线程改写
        public R2k.HANDLE_FUN f = new R2k.HANDLE_FUN(HandleData);
        // 加载字符串资源
        static ResourceManager[] rmArray = new ResourceManager[2]{  
                                                    new ResourceManager("R2kDemo.SimpChinese", typeof(MainWindow).Assembly),
                                                    new ResourceManager("R2kDemo.English", typeof(MainWindow).Assembly)};
        static ResourceManager rm = rmArray[0];


        // 负责连接设备的委托
       public delegate void DeleConnectDev(byte[] ip, int CommPort, uint PortOrBaudRate);
        // 数据产生时，触发此事件，更新ListView控件
       public delegate void UpdateControlEventHandler();
       public static event UpdateControlEventHandler UpdateControl;
       

        public MainWindow()
        {
            InitializeComponent();

            UpdateControl = new UpdateControlEventHandler(UpdateListView);  //订阅UpdateControl事件
            // 允许跨线程更新窗口控件
            Control.CheckForIllegalCrossThreadCalls = false;

            textBoxPort.Text = "20058";
            for (int i = 100; i <= 5000; i += 100)
            {
                comboBoxWT1.Items.Add(i.ToString());
                comboBoxWT2.Items.Add(i.ToString());
                comboBoxWT3.Items.Add(i.ToString());
                comboBoxWT4.Items.Add(i.ToString());
            }
            for (int i = 200; i <= 300; i += 10)
            {
                comboBoxPower1.Items.Add(i.ToString());
                comboBoxPower2.Items.Add(i.ToString());
                comboBoxPower3.Items.Add(i.ToString());
                comboBoxPower4.Items.Add(i.ToString());
            }
            // 主数据表
            listView.Columns.Add("No", 40, HorizontalAlignment.Center);
            listView.Columns.Add("EPC", 260, HorizontalAlignment.Center);
            listView.Columns.Add("Count", 60, HorizontalAlignment.Center);
            listView.Columns.Add("AntNo", 60, HorizontalAlignment.Center);
            listView.Columns.Add("DevNo", 60, HorizontalAlignment.Center);


            // 初始化各个页面控件
            InitCommParamControl();
            cbbLangSwitch.SelectedIndex = 0; // 默认中文

            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
            btnGetAnts.Enabled = false;
            btnSetAnts.Enabled = false;
            btnStartReadData.Enabled = false;            
            btnReadOnce.Enabled = false;
            btnStopReadData.Enabled = false;
            btnUpdate_Click(null, null);
        }

        // 更新串口列表
        public void GetSerialPortList(ref ComboBox comboBoxSP)
        {
            comboBoxSP.Items.Clear();
            comboBoxSP.Items.AddRange(SerialPort.GetPortNames());
            if (comboBoxSP.Items.Count > 0)
            {
                comboBoxSP.SelectedIndex = 0;
            }
        }
        unsafe private void btnUpdate_Click(object sender, EventArgs e)
        {
            WSADATA wsaData = new WSADATA();
            WSAStartup(0x0202,  ref wsaData); 
            // 搜索设备，获得IP列表
            ZLDM.m_DevCnt = ZLDM.StartSearchDev();
            comboBoxIP.Items.Clear();
            for (byte i = 0; i < ZLDM.m_DevCnt; ++i)
            {
                comboBoxIP.Items.Add(Marshal.PtrToStringAnsi(ZLDM.GetIP(i)));
            }
            if (ZLDM.m_DevCnt > 0)
            {
                comboBoxIP.SelectedIndex = 0;
            }
            //WSACleanup();
        }

        // 委托执行的连接函数，成功后修改标志并停止定时器
        private void ConnectDevice(byte[] ip, int CommPort, uint PortOrBaudRate)
        {
            if (0 != R2k.deviceInit(ip, CommPort, PortOrBaudRate))
            {
                labelVersion.Text =  rm.GetString("strMsgInitFailure");
                return;
            }
            if (0 != R2k.deviceConnect())
            {
                return;
            }
            btnGetAnts_Click(null, null);
            byte[] version = new byte[32];
            R2k.GetDevVersion(version);
            labelVersion.Text = "Version:" + Encoding.Default.GetString(version);
            btnConnect.Enabled = false;
            btnDisconnect.Enabled = true;
            btnGetAnts.Enabled = true;
            btnSetAnts.Enabled = true;
            btnStartReadData.Enabled = true;
            btnReadOnce.Enabled = true;
            bConnected = true;
            timerConnect.Stop();// 连接成功，结束定时器
        }
        // 定时器函数，在指定时间内没有完成连接，则执行此函数
        private void timerConnect_Tick(object sender, EventArgs e)
        {
            if (!bConnected)
            {
                labelVersion.Text = rm.GetString("strMsgConnectFailure");
                timerConnect.Stop();
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            byte[] ip = new byte[32];
            int CommPort = 0;
            uint PortOrBaudRate = 0;
         
                if ((!Regex.IsMatch(comboBoxIP.Text, "^[0-9.]+$")) || comboBoxIP.Text.Length < 7 || comboBoxIP.Text.Length > 15)
                {
                    MessageBox.Show(rm.GetString("strMsgInvalidIPAdd")); 
                    return;
                }
                ip = Encoding.ASCII.GetBytes(comboBoxIP.Text); // 由string获得byte数组
                if (!Regex.IsMatch(textBoxPort.Text, "^[0-9]+$")  || textBoxPort.Text.Length > 5)
                {
                    MessageBox.Show(rm.GetString("strMsgInvalidPort"));
                    return;
                }
                PortOrBaudRate = UInt32.Parse(textBoxPort.Text);
            // 使用委托异步线程执行连接，同时启动定时器，等待
            DeleConnectDev dcd = new DeleConnectDev(ConnectDevice);
           dcd.BeginInvoke(ip, CommPort, PortOrBaudRate, null, null);
            bConnected = false;
            timerConnect.Interval = 3000; // 等待3秒时间
            timerConnect.Start();
        }

        private void btnGetAnts_Click(object sender, EventArgs e)
        {
            labelVersion.Text = "";
            PANT_CFG AntCfg = new PANT_CFG();
            AntCfg.antEnable = new byte[4];
            AntCfg.dwell_time = new UInt32[4];
            AntCfg.power = new UInt32[4];
            if (0 == R2k.GetAnt(out AntCfg))
            {
                cbAnt1.Checked = (AntCfg.antEnable[0] == 1);
                cbAnt2.Checked = (AntCfg.antEnable[1] == 1);
                cbAnt3.Checked = (AntCfg.antEnable[2] == 1);
                cbAnt4.Checked = (AntCfg.antEnable[3] == 1);
                comboBoxWT1.Text = AntCfg.dwell_time[0].ToString();
                comboBoxWT2.Text = AntCfg.dwell_time[1].ToString();
                comboBoxWT3.Text = AntCfg.dwell_time[2].ToString();
                comboBoxWT4.Text = AntCfg.dwell_time[3].ToString();
                comboBoxPower1.Text = AntCfg.power[0].ToString();
                comboBoxPower2.Text = AntCfg.power[1].ToString();
                comboBoxPower3.Text = AntCfg.power[2].ToString();
                comboBoxPower4.Text = AntCfg.power[3].ToString();
                labelVersion.Text =  rm.GetString("strMsgSucceedGetAnt");
            }
            else
            {
                labelVersion.Text = rm.GetString("strMsgFailedGetAnt");
            }
        }

        private void btnSetAnts_Click(object sender, EventArgs e)
        {
            labelVersion.Text = "";
            PANT_CFG AntCfg = new PANT_CFG();
            AntCfg.antEnable = new byte[4];
            AntCfg.dwell_time = new UInt32[4];
            AntCfg.power = new UInt32[4];
            AntCfg.antEnable[0] = (byte)(cbAnt1.Checked ? 1 : 0);
            AntCfg.antEnable[1] = (byte)(cbAnt2.Checked ? 1 : 0);
            AntCfg.antEnable[2] = (byte)(cbAnt3.Checked ? 1 : 0);
            AntCfg.antEnable[3] = (byte)(cbAnt4.Checked ? 1 : 0);
            UInt32[] dt = new UInt32[4];
            UInt32[] pwr = new UInt32[4];
            dt[0] = UInt32.Parse(comboBoxWT1.Text);
            if (dt[0] < 100 || dt[0] > 10000)
            {
                MessageBox.Show(rm.GetString("strMsgValidWT"));// rm.GetString("strMsgValidWT")
                return;
            }
            dt[1] = UInt32.Parse(comboBoxWT2.Text);
            if (dt[1] < 100 || dt[1] > 10000)
            {
                MessageBox.Show(rm.GetString("strMsgValidWT"));
                return;
            }
            dt[2] = UInt32.Parse(comboBoxWT3.Text);
            if (dt[2] < 100 || dt[2] > 10000)
            {
                MessageBox.Show(rm.GetString("strMsgValidWT"));
                return;
            }
            dt[3] = UInt32.Parse(comboBoxWT4.Text);
            if (dt[3] < 100 || dt[3] > 10000)
            {
                MessageBox.Show(rm.GetString("strMsgValidWT"));
                return;
            }
            pwr[0] = UInt32.Parse(comboBoxPower1.Text);
            if (pwr[0] < 200 || pwr[0] > 300)
            {
                MessageBox.Show(rm.GetString("strMsgPowerValid"));// rm.GetString("strMsgPowerValid")
                return;
            }
            pwr[1] = UInt32.Parse(comboBoxPower2.Text);
            if (pwr[1] < 200 || pwr[1] > 300)
            {
                MessageBox.Show(rm.GetString("strMsgPowerValid"));
                return;
            }
            pwr[2] = UInt32.Parse(comboBoxPower3.Text);
            if (pwr[2] < 200 || pwr[2] > 300)
            {
                MessageBox.Show(rm.GetString("strMsgPowerValid"));
                return;
            }
            pwr[3] = UInt32.Parse(comboBoxPower4.Text);
            if (pwr[3] < 200 || pwr[3] > 300)
            {
                MessageBox.Show(rm.GetString("strMsgPowerValid"));
                return;
            }
            for (int i = 0; i < 4; ++i)
            {
                AntCfg.dwell_time[i] = dt[i];
                AntCfg.power[i] = pwr[i];
            }
            if (0 == R2k.SetAnt(ref AntCfg))
            {
                labelVersion.Text =  rm.GetString("strMsgSucceedSetAnt");
            }
            else
            {
                labelVersion.Text = rm.GetString("strMsgFailedSetAnt");
            }
        }
         private void btnInvokeOnce_Click(object sender, EventArgs e)
        {
            R2k.BeginOnceInv(f);
        }

         static string epc;
         public static void HandleData( byte cmdID, IntPtr pData, int length)
        {
           epc = "";
           byte[] data = new byte[32];
           Marshal.Copy(pData, data, 0, length);
           for (int i = 0; i < length - 4; ++i)
           {
               epc += string.Format("{0:X2} ",data[i]);
           }
           bNewTag = true;
           for (int i = 0; i < Tag_data.Count; ++i)
           {
               if (epc == Tag_data[i].epc)
               {
                   Tag_data[i].count++;
                   Tag_data[i].antNo = data[length - 1];
                   Tag_data[i].devNo = data[length - 2];
                   bNewTag = false;     // 不是新标签
                   nItemNo = i;             //记录数据索引值，用于更新listView表
                   break;
               }
           }
           if (bNewTag)
           {
               EPC_data epcdata = new EPC_data();
               epcdata.epc = epc;
               epcdata.antNo = data[length - 1];
               epcdata.devNo = data[length - 2];
               epcdata.count = 1;
               Tag_data.Add(epcdata);
           }
           UpdateControl(); // 有新数据产生，更新listView
        }
        // 保存数据
         public static void WriteFile(string strTxt, string path)
         {
             using (StreamWriter wlog = File.AppendText(path))
             {
                 wlog.Write("{0}", strTxt);
                 wlog.Write(wlog.NewLine);
             }
         }
        private void UpdateListView()
        {
            if (cbSaveFile.Checked)
            {
                WriteFile(epc, "tag.txt");
            }
            if (!bNewTag) // 非新标签，更新对应项的读取次数及天线号、设备号等
            {
                labelCount.Text = (int.Parse(labelCount.Text) + 1).ToString();
               listView.Items[nItemNo].SubItems[2].Text = Tag_data[nItemNo].count.ToString();
               listView.Items[nItemNo].SubItems[3].Text = Tag_data[nItemNo].antNo.ToString();
               listView.Items[nItemNo].SubItems[4].Text = Tag_data[nItemNo].devNo.ToString();
            }
            else // 新标签
            {
                labelCount.Text = (int.Parse(labelCount.Text) + 1).ToString(); // 更新读取次数
                labelTagCount.Text = (int.Parse(labelTagCount.Text) + 1).ToString();// 更新标签计数
                ListViewItem lvi = new ListViewItem();
                int no = Tag_data.Count;
                lvi.Text = no.ToString();
                lvi.SubItems.Add(Tag_data[no - 1].epc);
                lvi.SubItems.Add(Tag_data[no - 1].count.ToString());
                lvi.SubItems.Add(Tag_data[no - 1].antNo.ToString());
                lvi.SubItems.Add(Tag_data[no - 1].devNo.ToString());
                listView.Items.Add(lvi);
            }        
        }

       private void UpdateLV() 
       {
           listView.BeginUpdate();
           listView.Items.Clear();
           for (int i = 1; i <= Tag_data.Count; ++i)
           {
               ListViewItem lvi = new ListViewItem();
               lvi.Text = i.ToString();
               lvi.SubItems.Add(Tag_data[i - 1].epc);
               lvi.SubItems.Add(Tag_data[i - 1].count.ToString());
               lvi.SubItems.Add(Tag_data[i - 1].antNo.ToString());
               lvi.SubItems.Add(Tag_data[i - 1].devNo.ToString());
               listView.Items.Add(lvi);
           }
           listView.EndUpdate();
       }

        private void btnStart_Click(object sender, EventArgs e)
        {
            R2k.BeginMultiInv(f);
            btnStopReadData.Enabled = true;
            btnStartReadData.Enabled = false;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            R2k.StopInv();
            btnStartReadData.Enabled = true;
            btnStopReadData.Enabled = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            listView.Items.Clear();
            Tag_data.Clear();
            labelTagCount.Text = "0";
            labelCount.Text = "0";
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            R2k.deviceDisconnect();
            R2k.deviceUnInit();
            labelVersion.Text = "";
            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
            btnGetAnts.Enabled = false;
            btnSetAnts.Enabled = false;
            btnStartReadData.Enabled = false;
            btnReadOnce.Enabled = false;
            btnStopReadData.Enabled = false;
            bConnected = false;
        }

        private void radioButtonＡsc_CheckedChanged(object sender, EventArgs e)
        {
            Tag_data.Sort();
            UpdateLV();
        }

        private void radioButtonDesc_CheckedChanged(object sender, EventArgs e)
        {
            Tag_data.Sort();
            Tag_data.Reverse();
            UpdateLV();
        }

        private void SetCommParam_Enter(object sender, EventArgs e)
        {
        }
        
        private void InitCommParamControl()
        {
            comboBoxNetMode.Items.Add("TCP Server");
            comboBoxNetMode.Items.Add("TCP Client");
            comboBoxNetMode.Items.Add("UDP");
            comboBoxNetMode.Items.Add("UDP Group");

            comboBoxIPMode.Items.Add("Static");
            comboBoxIPMode.Items.Add("Dynamic");            

            comboBoxBaudRate.Items.Add("1200");
            comboBoxBaudRate.Items.Add("2400");
            comboBoxBaudRate.Items.Add("4800");
            comboBoxBaudRate.Items.Add("7200");
            comboBoxBaudRate.Items.Add("9600");
            comboBoxBaudRate.Items.Add("14400");
            comboBoxBaudRate.Items.Add("19200");
            comboBoxBaudRate.Items.Add("28800");
            comboBoxBaudRate.Items.Add("38400");
            comboBoxBaudRate.Items.Add("57600");
            comboBoxBaudRate.Items.Add("76800");
            comboBoxBaudRate.Items.Add("115200");
            comboBoxBaudRate.Items.Add("230400");

            comboBoxDataBits.Items.Add("8");
            comboBoxDataBits.Items.Add("7");
            comboBoxDataBits.Items.Add("6");
            comboBoxDataBits.Items.Add("5");

            comboBoxCheckBits.Items.Add("None");
            comboBoxCheckBits.Items.Add("Odd");
            comboBoxCheckBits.Items.Add("Even");
            comboBoxCheckBits.Items.Add("Marked");
            comboBoxCheckBits.Items.Add("Space");
        }
        private void btnSearchDev_Click(object sender, EventArgs e)
        {
            //WSADATA wsaData = new WSADATA();
            //WSAStartup(0x0202, ref wsaData);
            lvZl.Items.Clear();
           ZLDM.m_DevCnt = ZLDM.StartSearchDev();
            for (byte i = 0; i < ZLDM.m_DevCnt; ++i)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = (i+1).ToString();
                lvi.SubItems.Add(Marshal.PtrToStringAnsi(ZLDM.GetIP(i)));
                lvi.SubItems.Add(ReverseByte(ZLDM.GetPort(i)).ToString());
                lvi.SubItems.Add(Marshal.PtrToStringAnsi(ZLDM.GetDevID(i)));
                lvZl.Items.Add(lvi);
            }
            if (ZLDM.m_DevCnt > 0)
            {
                UpdateCommParamControl(); // 更新页面控件
                lvZl.FocusedItem = lvZl.Items[0];// 设置第一项为焦点项
            }
          // WSACleanup();
        }
        // 大小端转换
        public static UInt16 ReverseByte(UInt16 value)
        {
            return (UInt16)((value & 0xFFU) << 8 | (value & 0xFF00U) >> 8);
        }
        private void btnModifyDev_Click(object sender, EventArgs e)
        {
            //listViewDev_ItemActivate(sender, e);
            if(lvZl.SelectedItems != null)
                listViewDev_ItemActivate(sender, e);
        }
        // 设置默认参数
        private void btnDefaultParams_Click(object sender, EventArgs e)
        {
            comboBoxNetMode.SelectedIndex = 0;
            comboBoxIPMode.SelectedIndex = 0;
            textBoxIPAdd.Text = "192.168.1.200";
            textBoxNetMask.Text = "255.255.255.0";
            textBoxPortNo.Text = "20058";
            textBoxGateway.Text = "192.168.1.1";
            textBoxDestIP.Text = "192.168.1.100";
            textBoxDestPort.Text = "20058";
            comboBoxBaudRate.SelectedIndex = 12;
            comboBoxDataBits.SelectedIndex = 0;
            comboBoxCheckBits.SelectedIndex = 0;        
        }
        // 设置通信参数
        private void btnSetParams_Click(object sender, EventArgs e)
        {
            if (-1 == comboBoxNetMode.SelectedIndex)
            {
                MessageBox.Show(rm.GetString("strMsgSelectNetMode"));// rm.GetString("strMsgSelectNetMode")
                return;
            }
            if (-1 == comboBoxIPMode.SelectedIndex)
            {
                MessageBox.Show(rm.GetString("strMsgSelectIPMode"));// rm.GetString("strMsgSelectIPMode")
                return;
            }
            if (-1 == comboBoxBaudRate.SelectedIndex)
            {
                MessageBox.Show(rm.GetString("strMsgSelectBaudRate"));// rm.GetString("strMsgSelectBaudRate")
                return;
            }
            if (-1 == comboBoxDataBits.SelectedIndex)
            {
                MessageBox.Show(rm.GetString("strMsgSelectDataBits"));// rm.GetString("strMsgSelectDataBits")
                return;
            }
            if (-1 == comboBoxDataBits.SelectedIndex)
            {
                MessageBox.Show(rm.GetString("strMsgSelectParity"));// rm.GetString("strMsgSelectParity")
                return;
            }

            ushort port = ReverseByte(ushort.Parse(textBoxPortNo.Text));
            ushort destport = ReverseByte(ushort.Parse(textBoxDestPort.Text));

            byte[] ip = new byte[32];
            byte[] netmask = new byte[32];
            byte[] gateway = new byte[32];
            byte[] destip = new byte[32];
            ip = Encoding.ASCII.GetBytes(textBoxIPAdd.Text);
            netmask = Encoding.ASCII.GetBytes(textBoxNetMask.Text);
            gateway = Encoding.ASCII.GetBytes(textBoxGateway.Text);
            destip = Encoding.ASCII.GetBytes(textBoxDestIP.Text);

            ZLDM.SetWorkMode(ZLDM.m_SelectedDevNo, (byte)comboBoxNetMode.SelectedIndex);
            ZLDM.SetIPMode(ZLDM.m_SelectedDevNo, (byte)comboBoxIPMode.SelectedIndex);

            
            ZLDM.SetIP(ZLDM.m_SelectedDevNo,  ip);
            ZLDM.SetNetMask(ZLDM.m_SelectedDevNo, netmask);
            ZLDM.SetPort(ZLDM.m_SelectedDevNo, port);
            ZLDM.SetGateWay(ZLDM.m_SelectedDevNo, gateway);

            ZLDM.SetDestName(ZLDM.m_SelectedDevNo, destip);
            ZLDM.SetDestPort(ZLDM.m_SelectedDevNo, destport);

            ZLDM.SetBaudrateIndex(ZLDM.m_SelectedDevNo, (byte)comboBoxBaudRate.SelectedIndex);
            ZLDM.SetDataBits(ZLDM.m_SelectedDevNo, (byte)comboBoxDataBits.SelectedIndex);
            ZLDM.SetParity(ZLDM.m_SelectedDevNo, (byte)comboBoxCheckBits.SelectedIndex);

           bool res =  ZLDM.SetParam(ZLDM.m_SelectedDevNo);
           if (res)
               MessageBox.Show(rm.GetString("strMsgSucceedSetCommParam")); // 
           else
               MessageBox.Show(rm.GetString("strMsgFailedSetCommParam"));// rm.GetString("strMsgFailedSetCommParam")
        }

        private void listViewDev_ItemActivate(object sender, EventArgs e)
        {
            if (lvZl.Items.Count > 0)
            {
                ZLDM.m_SelectedDevNo = (byte)(lvZl.Items.IndexOf(lvZl.FocusedItem));
                UpdateCommParamControl();
            }
        }

        private void UpdateCommParamControl()
        {
            if (ZLDM.m_DevCnt > 0)
            {
                comboBoxNetMode.SelectedIndex = ZLDM.GetWordMode(ZLDM.m_SelectedDevNo);
                comboBoxIPMode.SelectedIndex = ZLDM.GetIPMode(ZLDM.m_SelectedDevNo);
                textBoxIPAdd.Text = Marshal.PtrToStringAnsi(ZLDM.GetIP(ZLDM.m_SelectedDevNo));
                textBoxNetMask.Text = Marshal.PtrToStringAnsi(ZLDM.GetNetMask(ZLDM.m_SelectedDevNo));
                textBoxPortNo.Text = (ReverseByte(ZLDM.GetPort(ZLDM.m_SelectedDevNo))).ToString();
                textBoxGateway.Text = Marshal.PtrToStringAnsi(ZLDM.GetGateWay(ZLDM.m_SelectedDevNo));
                textBoxDestIP.Text = Marshal.PtrToStringAnsi(ZLDM.GetDestName(ZLDM.m_SelectedDevNo));
                textBoxDestPort.Text = (ReverseByte(ZLDM.GetDestPort(ZLDM.m_SelectedDevNo))).ToString();
                comboBoxBaudRate.SelectedIndex = ZLDM.GetBaudrateIndex(ZLDM.m_SelectedDevNo);
                comboBoxDataBits.SelectedIndex = ZLDM.GetDataBits(ZLDM.m_SelectedDevNo);
                comboBoxCheckBits.SelectedIndex = ZLDM.GetParity(ZLDM.m_SelectedDevNo);
             }
        }

        private bool IsHexCharacter(string str)
        {
            return Regex.IsMatch(str, "^[0-9A-Fa-f]+$");
        }
        bool IsDecNumber(string str)
        {
            return Regex.IsMatch(str, "^[0-9]+$");
        }
    }
    public struct WSADATA 
    { 
         public short wVersion; 
         public short wHighVersion; 
         [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 6)] 
         public string szDescription; 
         [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 6)] 
         public string szSystemStatus; 
         [Obsolete] // Ignored for v2.0 and above 
         public int wMaxSockets; 
         [Obsolete] // Ignored for v2.0 and above 
         public int wMAXUDPDG; 
         public IntPtr dwVendorInfo; 
     }

    public sealed class EPC_data : IComparable
    {
        public string epc;
        public int count;
        public int devNo;
        public byte antNo;
        int IComparable.CompareTo(object obj)
        {
            EPC_data temp = (EPC_data)obj ;
            {
                return string.Compare(this.epc, temp.epc);
            }
        }
    }
    // 解决插入数据表格闪烁的问题
    class ListViewNF : System.Windows.Forms.ListView
    {
        public ListViewNF()
        {
            // 开启双缓冲
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

            // Enable the OnNotifyMessage event so we get a chance to filter out 
            // Windows messages before they get to the form's WndProc
            this.SetStyle(ControlStyles.EnableNotifyMessage, true);
        }

        protected override void OnNotifyMessage(Message m)
        {
            //Filter out the WM_ERASEBKGND message
            if (m.Msg != 0x14)
            {
                base.OnNotifyMessage(m);
            }
        }
    }
}
