using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace R2kDemo
{
    public struct PANT_CFG
    {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] antEnable;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public UInt32[] dwell_time;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public UInt32[] power;
    }
    public  class R2k
    {
        // 回调函数类型
        public delegate void HANDLE_FUN( byte cmdID, IntPtr pData, int length);
        // 导入所有的动态库函数
        [DllImport("R2k.dll", EntryPoint="deviceInit") ]
       unsafe  public static extern int   deviceInit(byte[] ip, int CommMode, uint PortOrBaudRate);

        [DllImport("R2k.dll")]
        public static extern int deviceConnect();

        [DllImport("R2k.dll")]
        public static extern void deviceDisconnect();

        [DllImport("R2k.dll")]
        public static extern void deviceUnInit();

        [DllImport("R2k.dll")]
        unsafe public static extern int GetDevVersion(byte[] pVer);

        [DllImport("R2k.dll")]
        public static extern int GetAnt(out PANT_CFG AntCfg);

        [DllImport("R2k.dll")]
        public static extern int SetAnt( ref PANT_CFG AntCfg);

        [DllImport("R2k.dll")]
         public static extern  int  WriteTagData(byte bank, byte begin,  byte size,	 byte[] Data,  byte[] Password);

         [DllImport("R2k.dll")]
         public static extern int   ReadTagData(byte bank, byte begin,  byte size, byte[] OutData,	byte[] Password);	

        [DllImport("R2k.dll")]
        public static extern  int  BeginMultiInv(HANDLE_FUN f);

        [DllImport("R2k.dll")]
        public static extern int   StopInv();

        [DllImport("R2k.dll")]
        public static extern int BeginOnceInv(HANDLE_FUN f) ;

         [DllImport("R2k.dll")]
        public static extern  int SetAlive(byte intervalSecond);

        [DllImport("R2k.dll")]
         public static extern int   KillTag(byte[] Kill_pwd,byte[] Access_pwd);

         [DllImport("R2k.dll")]
         public static extern int     LockTag(byte opcode,  byte block, byte[]Password);

         [DllImport("R2k.dll")]
        public static extern int     SetDeviceNo(byte deviceNo);

         [DllImport("R2k.dll")]
        public static extern int     SetNeighJudgeTime(byte time);

        [DllImport("R2k.dll")]
        public static extern int   SetDO(  byte port,  byte state);

        [DllImport("R2k.dll")]
         public static extern int   GetDI(byte[] pDIState);

        [DllImport("R2k.dll")]
        public static extern void ForceStop();











    }
}
//typedef void (CALLBACK* HANDLE_FUN)(unsigned char cmdID, void* pData, int length);

// int GetLastErrorMessage();	
// int  deviceInit(char* pHost,int CommMode = 0, unsigned PortOrBaudRate = 20058);
// int   deviceConnect();
// void     deviceDisconnect();
// void    deviceUnInit();
// int GetDevVersion(unsigned char* pVer);
// int     GetAnt(PANT_CFG pAntCfg);
// int      SetAnt(const PANT_CFG pAntCfg);
// int   WriteTagData(unsigned char bank, unsigned char begin,
//                  unsigned char size,	const unsigned char* pData,
//                  char* pPassword = "\0\0\0\0");
// int    ReadTagData(unsigned char bank, unsigned char begin,				
//                   unsigned char size, unsigned char* pOutData,	        
//                   char* pPassword = "\0\0\0\0");	 
// int     BeginMultiInv(HANDLE_FUN f);
// int   StopInv();

// int     BeginOnceInv(HANDLE_FUN f) ;


