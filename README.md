# r2k_pearl


## Dev Env

1. windows only. no support for Mac/Linux
2. visual studio 2010


## Notes

1. compile and debug with Release mode.


## Reader Protocol Spec

#### data structure

```c
//---------------- 网络命令包结构------------------------
typedef struct _PACKAGE
{
    unsigned char STARTCODE[2];  // 2 个字节的起始码
    unsigned char cmd;           // 命令码
    unsigned char seq;           // 顺序号
    unsigned char len[2];        // 长度, 为low, 1 为 high
    unsigned char data[520];     // 数据
    unsigned char bcc;           // 校验位
}PACKAGE, *PPACKAGE;
```

#### API

```c
APP_DLL int WINAPI BeginMultiInv(HANDLE_FUN f);
/*---------------------------------
 * return:
 *      R_OK
 *      R_FAIL
 **********************************/
typedef void (CALLBACK* HANDLE_FUN)(unsigned char cmdID, void* pData, int length);
APP_DLL int WINAPI StopInv();
```

###### cmdID:

```c
#define UHF_INV_MULTIPLY_BEGIN (Ox2A)
#define UHF_INV_MULTIPLY_END (0x2B)
```

###### pData & length

- length: 取值 1 与 16
- data: 12 位 EPC，2 位校验值，1 位天线，1 位设备号

length 为 1

1. 天线工作周期结束，data 值是 f0
2. 如果立刻收到，是命令响应。data 值是 0x00. 代码成功接收操作命令。

length 为 16，收到正常的标签数据。12 位的 data 值。
