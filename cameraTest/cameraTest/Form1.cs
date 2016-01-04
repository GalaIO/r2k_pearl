using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO.Ports;

using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Imaging;
using AForge.Imaging.Filters;

using System.Drawing.Imaging;


namespace cameraTest
{
    public partial class Form1 : Form
    {
        //摄像头设备 枚举
        private FilterInfoCollection videoDevices;

        public Form1()
        {
            InitializeComponent(); 
            // 允许跨线程更新窗口控件
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //串口初始化
            serialPortInnitial();
            //摄像头初始化
            cameraDevInnitial();
        }

        //串口初始化
        private bool serialPortInnitial()
        {
            //搜索当前所有的com口，并列出来
            string[] portName = SerialPort.GetPortNames();
            if (portName.Length == 0)
            {
                this.list_com.Items.Add("unavaliable");
            }
            else
            {
                for (int i = 0; i < portName.Length; i++)
                {
                    this.list_com.Items.Add(portName[i]);
                }
            }
            //显示默认项
            this.list_com.SelectedIndex = 0;

            //实例化串口对象
            serialPort = new SerialPort();
            //添加串口数据读取
            serialPort.DataReceived += new SerialDataReceivedEventHandler(comDataReceived);

            return true;
        }
        //摄像头初始化
        private bool cameraDevInnitial()
        {
            //搜索当前所有的视频设备，并列出来
            try
            {
                // 枚举所有视频输入设备
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                if (videoDevices.Count == 0)
                    throw new ApplicationException();

                foreach (FilterInfo device in videoDevices)
                {
                    this.list_cam.Items.Add(device.Name);
                }

                this.list_cam.SelectedIndex = 0;
            }
            catch (ApplicationException)
            {
                this.list_cam.Items.Add("unavaliable");
                this.list_cam.SelectedIndex = 0;
            }

            return true;
        }
        private void CameraConn()
        {
            VideoCaptureDevice videoSource = new VideoCaptureDevice(videoDevices[list_cam.SelectedIndex].MonikerString);
            videoSource.DesiredFrameSize = new Size(this.videoPlayer.Width, this.videoPlayer.Height);
            videoSource.DesiredFrameRate = 1;

            videoPlayer.VideoSource = videoSource;
            videoPlayer.Start();
        }

        private void button_cam_open_Click(object sender, EventArgs e)
        {
            CameraConn();
        }

        private void button_cam_close_Click(object sender, EventArgs e)
        {
            videoPlayer.SignalToStop();
            videoPlayer.WaitForStop();
        }
        //拍照
        private void photoShot(string pName, int width, int height)
        {
            try
            {
                if (videoPlayer.IsRunning)
                {
                    //获取当前视频帧
                    Bitmap bitMap = new Bitmap(videoPlayer.GetCurrentVideoFrame(), width, height);
                    bitMap.Save("./save/"+pName+".jpg",ImageFormat.Jpeg);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("摄像头异常：" + ex.Message);
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            button_cam_close_Click(null, null);
            button_com_close_Click(null, null);
        }

        private void button_com_open_Click(object sender, EventArgs e)
        {
            Console.WriteLine(list_com.Items[list_com.SelectedIndex].ToString());
            comOpen(list_com.Items[list_com.SelectedIndex].ToString(), 9600, Parity.None, 8, StopBits.One);

        }

        private void button_com_close_Click(object sender, EventArgs e)
        {
            serialPort.Close();
        }

        private void comOpen(string comName, int baudRate, Parity parity, int DataBits, StopBits stopBits)
        {
            serialPort.PortName = comName;
            serialPort.BaudRate = baudRate;
            serialPort.DataBits = DataBits;
            serialPort.Parity = parity;
            serialPort.StopBits = stopBits;
            serialPort.ReadTimeout = 500;

            serialPort.Open();
        }
        //接收数据
        private void comDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // 判断用户用的是字节模式还是字符模式
            /*if (CurrentDataMode == DataMode.Text)
            {
                // 读取缓冲区的数据
                string data = serialPort.ReadExisting();
            }

            else
            {*/
                // 获取字节长度
                int bytes = serialPort.BytesToRead;

                // 创建字节数组
                byte[] buffer = new byte[bytes];

                // 读取缓冲区的数据到数组
                serialPort.Read(buffer, 0, bytes);

                text_info.AppendText(Encoding.Default.GetString(buffer));
                //photoShot("tmp",300,300);
            //}

        }
    }
}
