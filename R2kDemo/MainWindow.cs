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
            // 主数据表
            listView.Columns.Add("No", 40, HorizontalAlignment.Center);
            listView.Columns.Add("EPC", 260, HorizontalAlignment.Center);
            listView.Columns.Add("Count", 60, HorizontalAlignment.Center);
            listView.Columns.Add("AntNo", 60, HorizontalAlignment.Center);
            listView.Columns.Add("DevNo", 60, HorizontalAlignment.Center);


            // 初始化各个页面控件
            cbbLangSwitch.SelectedIndex = 0; // 默认中文

            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
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
            byte[] version = new byte[32];
            R2k.GetDevVersion(version);
            labelVersion.Text = "Version:" + Encoding.Default.GetString(version);
            btnConnect.Enabled = false;
            btnDisconnect.Enabled = true;
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
        // 大小端转换
        public static UInt16 ReverseByte(UInt16 value)
        {
            return (UInt16)((value & 0xFFU) << 8 | (value & 0xFF00U) >> 8);
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
