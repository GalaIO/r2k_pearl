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

            rbNet.Checked = true;
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
            InitAccessTagControl();
            DisableAccessTagButton(false);
            cbbLangSwitch.SelectedIndex = 0; // 默认中文
            cbbLangSwitch_SelectedIndexChanged(null, null);

            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
            btnGetAnts.Enabled = false;
            btnSetAnts.Enabled = false;
            btnStartReadData.Enabled = false;            
            btnReadOnce.Enabled = false;
            btnStopReadData.Enabled = false;
            comboBoxSerialCommPort.Visible = false;
            btnUpdate_Click(null, null);
        }
        private void InitAccessTagControl()
        {
            // 读写区域
            cbbRWBank.Items.Add("Reserve");
            cbbRWBank.Items.Add("EPC");
            cbbRWBank.Items.Add("TID");
            cbbRWBank.Items.Add("User");

            // 锁卡区域
            cbbLockBank.Items.Add("Kill");
            cbbLockBank.Items.Add("Access");
            cbbLockBank.Items.Add("EPC");
            cbbLockBank.Items.Add("TID");
            cbbLockBank.Items.Add("User");

            tbRWAccessPwd.Text = "00 00 00 00";
           
        }
        private void DisableAccessTagButton(bool bEnabled)
        {
            btnReadData.Enabled = bEnabled;
            btnWriteData.Enabled = bEnabled;
            btnLockTag.Enabled = bEnabled;
            btnKillTag.Enabled = bEnabled;
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
            // 获得串口列表
            GetSerialPortList(ref comboBoxSerialCommPort);
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
            DisableAccessTagButton(true);
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
            if (rbNet.Checked) // TCP/IP
            {
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
            }
            else // SerialCommPort
            {
                if (comboBoxSerialCommPort.SelectedIndex >= 0)
                {
                    CommPort = int.Parse(comboBoxSerialCommPort.Text.Trim("COM".ToCharArray()));
                    PortOrBaudRate = 115200;
                }
                else
                {
                    MessageBox.Show(rm.GetString("strMsgSelectPort"));// rm.GetString("strMsgSelectPort")
                    return;
                }
            }
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

        private void radioButtonSP_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxSerialCommPort.Visible = true;
            comboBoxIP.Visible = false;
            textBoxPort.Visible = false;
            labCommPort.Visible = false;
        }

        private void radioButtonNet_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxSerialCommPort.Visible = false;
            comboBoxIP.Visible = true;
            textBoxPort.Visible = true;
            labCommPort.Visible = true;
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

        private void cbbRWBank_SelectedIndexChanged(object sender, EventArgs e)
        {   // 根据操作区域，确定有效的起始地址
            if (cbbRWBank.SelectedIndex == 0) // 保留区
            {
                RWBank = 0;
                addStart = 0;
                addEnd = 3;
            }
            else if (cbbRWBank.SelectedIndex == 1) // EPC区
            {
                RWBank = 1;
                addStart = 2;
                addEnd = 7;
            }
            else  if (cbbRWBank.SelectedIndex == 2) // TID
            {
                RWBank = 2;
                addStart = 0;
                addEnd = 5;
            }
            else if (cbbRWBank.SelectedIndex == 3) // User
            {
                RWBank = 3;
                addStart = 0;
                addEnd = 31;
            }
            cbbStartAdd.Items.Clear();
            for (int i = addStart; i <= addEnd; ++i)
            {
                cbbStartAdd.Items.Add(i.ToString());
            }
        }

        private void cbbStartAdd_SelectedIndexChanged(object sender, EventArgs e)
        { // 根据起始地址，确定长度选项
            int nItem = cbbStartAdd.SelectedIndex; // 取出起始地址索引值
            int maxLength = addEnd - addStart - nItem +1;
            cbbLength.Items.Clear();
            for (int i = 1; i <= maxLength; ++i)
            {
                cbbLength.Items.Add(i.ToString());
            }
        }

        private void btnClearData_Click(object sender, EventArgs e)
        {
            tbRWData.Text = "";
        }

        private void btnReadData_Click(object sender, EventArgs e)
        {
            int RWBank = -1;
            int StartAdd = -1;
            int Length = -1;
            labResult.Text = "";
            if ((RWBank = cbbRWBank.SelectedIndex) == -1)
            {
                MessageBox.Show(rm.GetString("strMsgSelectRWBank"));// rm.GetString("strMsgSelectRWBank")
                return;
            }
            if ((StartAdd = cbbStartAdd.SelectedIndex) == -1)
            {
                MessageBox.Show(rm.GetString("strMsgSelectStartAdd"));// rm.GetString("strMsgSelectStartAdd")
                return;
            }
            StartAdd = int.Parse(cbbStartAdd.Text);
            if ((Length = cbbLength.SelectedIndex) == -1)
            {
                MessageBox.Show(rm.GetString("strMsgSelectLength")); // rm.GetString("strMsgSelectLength")
                return;
            }
            Length = int.Parse(cbbLength.Text);

            string strpwd = tbRWAccessPwd.Text.Replace(" ", "");
            if (strpwd.Length != 8)
            {
                MessageBox.Show(rm.GetString("strMsgPwdMustEight")); // rm.GetString("strMsgPwdMustEight")
                return;
            }
            if (!IsHexCharacter(strpwd))
            {
                MessageBox.Show(rm.GetString("strMsgPwdInvalidChar"));// rm.GetString("strMsgPwdInvalidChar")
                return;
            }

            // 转密码框的字符转为byte数组
            byte[] pwd = new byte[4];
            for (int i = 0; i < 4; ++i)
            {
                pwd[i] = Convert.ToByte(strpwd.Substring(i * 2, 2), 16); // 把字符串的子串转为16进制的8位无符号整数
            }
            byte[] byteArray = new byte[64];
            tbRWData.Text = "";
            if (0 == R2k.ReadTagData((byte)RWBank, (byte)StartAdd, (byte)Length, byteArray, pwd))
            {
                for (int i = 0; i < 2 * Length; i++)
                {
                    tbRWData.Text += string.Format("{0:X2} ",byteArray[i]);
                }
            }
            else
            {
                labResult.Text = rm.GetString("strMsgFailedReadData");
            }
        }

        private void btnWriteData_Click(object sender, EventArgs e)
        {
            int RWBank = -1;
            int StartAdd = -1;
            int Length = -1;
            labResult.Text = "";
            if ((RWBank = cbbRWBank.SelectedIndex) == -1)
            {
                MessageBox.Show(rm.GetString("strMsgSelectRWBank"));//rm.GetString("strMsgSelectRWBank")
                return;
            }
            if ((StartAdd = cbbStartAdd.SelectedIndex) == -1)
            {
                MessageBox.Show(rm.GetString("strMsgSelectStartAdd"));//rm.GetString("strMsgSelectStartAdd")
                return;
            }
            StartAdd = int.Parse(cbbStartAdd.Text);
            if ((Length = cbbLength.SelectedIndex) == -1)
            {
                MessageBox.Show(rm.GetString("strMsgSelectLength"));//rm.GetString("strMsgSelectLength")
                return;
            }
            Length = int.Parse(cbbLength.Text);

            string strpwd = tbRWAccessPwd.Text.Replace(" ", "");
            if (strpwd.Length != 8)
            {
                MessageBox.Show(rm.GetString("strMsgPwdMustEight"));// rm.GetString("strMsgPwdMustEight")
                return;
            }
            if (!IsHexCharacter(strpwd))
            {
                MessageBox.Show(rm.GetString("strMsgPwdInvalidChar"));// rm.GetString("strMsgPwdInvalidChar")

                return;
            }

            byte[] pwd = new byte[4];
            for (int i = 0; i < 4; ++i)
            {
                pwd[i] = Convert.ToByte(strpwd.Substring(i * 2, 2), 16); // 把字符串的子串转为16进制的8位无符号整数
            }

            string strData = tbRWData.Text.Replace(" ", "");// 去空格
            if (strData.Length % 4 != 0 || strData.Length / 4 != Length)
            {
                MessageBox.Show(rm.GetString("strMsgLengthDiff"));// rm.GetString("strMsgLengthDiff")
                return;
            }
            if (!IsHexCharacter(strData))
            {
                MessageBox.Show(rm.GetString("strMsgPwdInvalidChar"));// rm.GetString("strMsgPwdInvalidChar")

                return;
            }
            byte[] byteArray = new byte[64];
            for (int i = 0; i < 2 * Length; ++i)
            {
                byteArray[i] = Convert.ToByte(strData.Substring(2 * i, 2), 16);
            }
            if (0 == R2k.WriteTagData((byte)RWBank, (byte)StartAdd, (byte)Length, byteArray, pwd))
            {
                labResult.Text = rm.GetString("strMsgSucceedWrite");
            }
            else
            {
                labResult.Text = rm.GetString("strMsgFailedWrite");
            }


        }
        private bool IsHexCharacter(string str)
        {
            return Regex.IsMatch(str, "^[0-9A-Fa-f]+$");
        }

        private void btnLockTag_Click(object sender, EventArgs e)
        {
            int lockBank = -1;
            int locktType = -1;
            labResult.Text = "";
            if ((lockBank = cbbLockBank.SelectedIndex) == -1)
            {
                MessageBox.Show(rm.GetString("strMsgSelecOprBank"));// rm.GetString("strMsgSelecOprBank")
                return;
            }
            if ((locktType = cbbLockType.SelectedIndex) == -1)
            {
                MessageBox.Show(rm.GetString("strMsgSelectOprType"));// rm.GetString("strMsgSelectOprType")
                return;
            }
            string strpwd = tbLockAccessPwd.Text.Replace(" ", "");
            if (strpwd.Length != 8)
            {
                MessageBox.Show(rm.GetString("strMsgPwdMustEight"));// rm.GetString("strMsgPwdMustEight")
                return;
            }
            if (!IsHexCharacter(strpwd))
            {
                MessageBox.Show(rm.GetString("strMsgPwdInvalidChar"));//rm.GetString("strMsgPwdInvalidChar")
                return;
            }

            byte[] pwd = new byte[4];
            for (int i = 0; i < 4; ++i)
            {
                pwd[i] = Convert.ToByte(strpwd.Substring(i * 2, 2), 16); // 把字符串的子串转为16进制的8位无符号整数
            }
            if (0 == R2k.LockTag((byte)locktType, (byte)lockBank, pwd))
            {
                labResult.Text = rm.GetString("strMsgSucceedOpr");
            }
            else
            {
                labResult.Text =  rm.GetString("strMsgFailedOpr");
            }
            return;
        }

        private void btnKillTag_Click(object sender, EventArgs e)
        {
            string strAccessPwd = tbKillAccessPwd.Text.Replace(" ", "");
            string strKillPwd = tbKillKillPwd.Text.Replace(" ", "");
            if (!IsHexCharacter(strAccessPwd) || !IsHexCharacter(strKillPwd))
            {
                MessageBox.Show(rm.GetString("strMsgPwdInvalidChar")); // rm.GetString("strMsgPwdInvalidChar")
                return;
            }
            if (strAccessPwd.Length != 8 || strKillPwd.Length != 8)
            {
                MessageBox.Show(rm.GetString("strMsgPwdMustEight")); //  rm.GetString("strMsgPwdMustEight")
                return;
            }
            byte[] byteAccessPwd = new byte[4];
            byte[] byteKillPwd = new byte[4];
            for (int i = 0; i < 4; ++i)
            {
                byteAccessPwd[i] = Convert.ToByte(strAccessPwd.Substring( i * 2, 2), 16);
                byteKillPwd[i] = Convert.ToByte(strKillPwd.Substring(i * 2, 2), 16);
            }
           if(0 == R2k.KillTag(byteAccessPwd, byteKillPwd))
            {
                labResult.Text = rm.GetString("strMsgSucceedDes");
            }
            else
            {
                labResult.Text = rm.GetString("strMsgFailedDes");
            }
        }
        bool IsDecNumber(string str)
        {
            return Regex.IsMatch(str, "^[0-9]+$");
        }

        private void btnSetDevNo_Click(object sender, EventArgs e)
        {
            labSetParam.Text = "";
            if (tbDevNo.Text == "")
            {
                MessageBox.Show(rm.GetString("strMsgDevNoNotEmpty"));// rm.GetString("strMsgDevNoNotEmpty")
                return;
           }
            if (!IsDecNumber(tbDevNo.Text))
            {
                MessageBox.Show(rm.GetString("strMsgNotDigit")); // rm.GetString("strMsgNotDigit")
                    return;
            }

            int devno = int.Parse(tbDevNo.Text);
            if (devno > 255)
            {
                MessageBox.Show(rm.GetString("strMsgDevNoValid")); // rm.GetString("strMsgDevNoValid")
                return;
            }
            if (0 == R2k.SetDeviceNo((byte)devno))
            {
                labSetParam.Text = rm.GetString("strMsgSucceedSetDevNo");
            }
            else
            {
                labSetParam.Text =  rm.GetString("strMsgFailedSetDevNo");
            }
        }

        private void btnSetNeighJudge_Click(object sender, EventArgs e)
        {
            labSetParam.Text = "";
            if (tbNeighJudge.Text == "")
            {
                MessageBox.Show(rm.GetString("strMsgNJNotEmpty")); // rm.GetString("strMsgNJNotEmpty")
                return;
            }
            if (!IsDecNumber(tbNeighJudge.Text))
            {
                MessageBox.Show(rm.GetString("strMsgNotDigit")); // rm.GetString("strMsgNotDigit")
                return;
            }

            int neighJudge = int.Parse(tbNeighJudge.Text);
            if (neighJudge > 255)
            {
                MessageBox.Show(rm.GetString("stMsgNJValid"));// rm.GetString("stMsgNJValid")
                return;
            }
            if (0 == R2k.SetNeighJudgeTime((byte)neighJudge))
            {
                labSetParam.Text = rm.GetString("strMsgSucceedSetNJ");
            }
            else
            {
                labSetParam.Text = rm.GetString("strMsgFailedSetNJ");
            }
        }

        private void btnSetHeartTime_Click(object sender, EventArgs e)
        {
            labSetParam.Text = "";
            if (tbHeartTime.Text == "")
            {
                MessageBox.Show(rm.GetString("strMsgAliveNotEmpty")); // rm.GetString("strMsgAliveNotEmpty")
                return;
            }
            if (!IsDecNumber(tbHeartTime.Text))
            {
                MessageBox.Show(rm.GetString("strMsgNotDigit")); // rm.GetString("strMsgNotDigit")
                return;
            }

            int heartTime = int.Parse(tbHeartTime.Text);
            if (heartTime > 255)
            {
                MessageBox.Show(rm.GetString("strMsgAliveValid")); // rm.GetString("strMsgAliveValid")
                return;
            }
            if (0 == R2k.SetNeighJudgeTime((byte)heartTime))
            {
                labSetParam.Text = rm.GetString("strMsgSucceedSetAlive");
            }
            else
            {
                labSetParam.Text =  rm.GetString("strMsgFailedSetAlive");
            }
        }

        private void btnGetInPort_Click(object sender, EventArgs e)
        {
            byte[] portState = new byte[2];
            if (0 == R2k.GetDI(portState))
            {
                if (1 == portState[0])
                {
                    cbIn1.Checked = true;
                }
                else
                {
                    cbIn1.Checked = false;
                }
                if (1 == portState[1])
                {
                    cbIn2.Checked = true;
                }
                else
                {
                    cbIn2.Checked = false;
                }
            }
            else
            {
                labSetParam.Text = rm.GetString("strMsgFailedGetIn");
            }
        }

        private void btnSetOutPort_Click(object sender, EventArgs e)
        {
            byte outPort1 = 0;
            byte outPort2 = 0;
            if (cbOut1.Checked)
            {
                outPort1 = 1;
            }
            if (cbOut2.Checked)
            {
                outPort2 = 1;
            }
            if (0 == R2k.SetDO(1, outPort1) && 0 == R2k.SetDO(2, outPort2))
            {
                labSetParam.Text = rm.GetString("strMsgSucceedSetOut");

            }
            else
            {
                labSetParam.Text =  rm.GetString("strMsgFailedSetOut");
            }
        }

        private void cbbLangSwitch_SelectedIndexChanged(object sender, EventArgs e)
        {
            //// 锁卡操作类型
            cbbLockType.Items.Clear();
            if (cbbLangSwitch.SelectedIndex == 0)
            {
                cbbLockType.Items.Add("解锁");
                cbbLockType.Items.Add("永久可写");
                cbbLockType.Items.Add("安全锁定");
                cbbLockType.Items.Add("永久不可写");
            }
            else
            {
                cbbLockType.Items.Add("Unlock");
                cbbLockType.Items.Add("Permanence writable");
                cbbLockType.Items.Add("Security lock");
                cbbLockType.Items.Add("Permanence unwritable");
            }
            // 引用所选择的语言字符串
           // ResourceManager rm = rmArray[cbbLangSwitch.SelectedIndex];
            rm = rmArray[cbbLangSwitch.SelectedIndex];
            // Tab标签页标题
            General.Text = rm.GetString("strTpGeneral");
            TagAccess.Text = rm.GetString("strTpTagAccess");
            SetCommParam.Text = rm.GetString("strTpSetCommParam");
            SetReaderParam.Text = rm.GetString("strTpSetReaderParam");

            // 表头更新
            listView.Columns[0].Text = rm.GetString("strLvHeadNo");
            listView.Columns[1].Text = rm.GetString("strLvHeadEPC");
            listView.Columns[2].Text = rm.GetString("strLvHeadCount");
            listView.Columns[3].Text = rm.GetString("strLvHeadAntNo");
            listView.Columns[4].Text = rm.GetString("strLvHeadDevNo");
            lvZl.Columns[0].Text = rm.GetString("strZlHeadNo");
            lvZl.Columns[1].Text = rm.GetString("strZlHeadIP");
            lvZl.Columns[2].Text = rm.GetString("strZlHeadPort");
            lvZl.Columns[3].Text = rm.GetString("strZlHeadMAC");

            // 按钮文字
            btnConnect.Text = rm.GetString("strBtnConnect");
            btnDisconnect.Text = rm.GetString("strBtnDisconnect");
            btnUpdate.Text = rm.GetString("strBtnUpdate");
            btnStartReadData.Text = rm.GetString("strBtnStartReadData");
            btnStopReadData.Text = rm.GetString("strBtnStopReadData");
            btnClearListView.Text = rm.GetString("strBtnClearListView");
            btnReadOnce.Text = rm.GetString("strBtnReadOnce");
            btnDefaultParams .Text = rm.GetString("strBtnDefaultParams");
            btnGetAnts.Text = rm.GetString("strBtnGetAnts");
            btnGetDI.Text = rm.GetString("strBtnGetDI");
            btnKillTag .Text = rm.GetString("strBtnKillTag");
             btnModifyDev .Text = rm.GetString("strBtnModifyDev");
             btnLockTag.Text = rm.GetString("strBtnPerform");
             btnReadData.Text = rm.GetString("strBtnReadTagData");
             btnSearchDev .Text = rm.GetString("strBtnSearchDev");
             btnSetHeartTime .Text = rm.GetString("strBtnSetAlive");
             btnSetAnts .Text = rm.GetString("strBtnSetAnts");
             btnSetDevNo .Text = rm.GetString("strBtnSetDevNo");
             btnSetOutPort .Text = rm.GetString("strBtnSetDO");
             btnSetNeighJudge .Text = rm.GetString("strBtnSetNeighJudge");
             btnSetParams .Text = rm.GetString("strBtnSetParams");
             btnWriteData.Text = rm.GetString("strBtnWriteTagData");
             btnClearData.Text = rm.GetString("strBtnClearEditData");

             // RadioButton标示
             rbAsc.Text = rm.GetString("strRbAsc");
             rbDesc.Text = rm.GetString("strRbDesc");
             rbNet.Text = rm.GetString("strRbNet");
             rbSerialPort.Text = rm.GetString("strRbSerialPort");

             // CheckBox标示
             cbAnt1.Text = rm.GetString("strCbAnt1");
             cbAnt2.Text = rm.GetString("strCbAnt2");
             cbAnt3.Text = rm.GetString("strCbAnt3");
             cbAnt4.Text = rm.GetString("strCbAnt4");
             cbIn1.Text = rm.GetString("strCbIn1");
             cbIn2.Text = rm.GetString("strCbIn2");
             cbOut1.Text = rm.GetString("strCbOut1");
             cbOut2.Text = rm.GetString("strCbOut2");
             cbSaveFile.Text = rm.GetString("strCbSaveFile");
             // GroupBox说明文字
             gbAntParams.Text = rm.GetString("strGbAntParams");
             gbCommMode.Text = rm.GetString("strGbCommMode");
             gbDestroyTag.Text = rm.GetString("strGbDestroyTag");
             gbDevParams.Text = rm.GetString("strGbDevParams");
             gbIOOpr.Text = rm.GetString("strGbIOOpr");
             gbLockTag.Text = rm.GetString("strGbLockTag");
             gbNetParams.Text = rm.GetString("strGbNetParams");
             gbRWData.Text = rm.GetString("strGbRWData");
             gbSPParams.Text = rm.GetString("strGbSPParams");
             // Label标签
             labAlive.Text = rm.GetString("strLabAlive");
             labAntUnit.Text = rm.GetString("strLabAntUnit");
             labBaudRate.Text = rm.GetString("strLabBaudRate");
             labCheckBits.Text = rm.GetString("strLabCheckBits");
             labCommPort.Text = rm.GetString("strLabCommPort");
             labDataBits.Text = rm.GetString("strLabDataBits");
             labDestIP.Text = rm.GetString("strLabDestIP");
             labDestPort.Text = rm.GetString("strLabDestPort");
             labDestroyPwd.Text = rm.GetString("strLabDestrlyPwd");
             labDesAccessPwd.Text = rm.GetString("strLabDestroyAccessPwd");
             labDevNo.Text = rm.GetString("strLabDevNo");
             labGateway.Text = rm.GetString("strLabGateway");
             labIPAdd.Text = rm.GetString("strLabIPAdd");
             labIPMode.Text = rm.GetString("strLabIPMode");
             labLength.Text = rm.GetString("strLabLength");
             labLockAccessPwd.Text = rm.GetString("strLabLockAccessPwd");
             labLockBank.Text = rm.GetString("strLabLockBank");
             labLockType.Text = rm.GetString("strLabLockType");
             labMask.Text = rm.GetString("strLabMask");
             labNeightJudge.Text = rm.GetString("strLabNeighJudge");
             labNetMode.Text = rm.GetString("strLabNetMode");
             labPort.Text = rm.GetString("strLabPort");
             labPromotion.Text = rm.GetString("strLabPromotion");
             labRWAccessPwd.Text = rm.GetString("strLabRWAccessPwd");
             labOprBank.Text = rm.GetString("strLabRWBank");
             labData.Text = rm.GetString("strLabRWData");
             labStartAdd.Text = rm.GetString("strLabStartAdd");
             labReadCount.Text = rm.GetString("strLabCount");
             labTagCount.Text = rm.GetString("strLabTagCount");
            // 语言切换后，清空左下角结果提示串
             labResult.Text = "";
             labelVersion.Text = "";
             labSetParam.Text = "";
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
