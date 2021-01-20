//-------------------------------------------------------------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------BEGIN CUT AND PASTE BLOCK-----------------------------------------------------------------------------------
/********************************************************************
 FileName:		Form1.cs
 Dependencies:	When compiled, needs .NET framework 2.0 redistributable to run.
 Hardware:		Need a free USB port to connect USB peripheral device
				programmed with appropriate Generic HID firmware.  VID and
				PID in firmware must match the VID and PID in this
				program.
 Compiler:  	Microsoft Visual C# 2005 Express Edition (or better)
 Company:		Microchip Technology, Inc.

 Software License Agreement:

 The software supplied herewith by Microchip Technology Incorporated
 (the 鼎ompany・ for its PICｮ Microcontroller is intended and
 supplied to you, the Company痴 customer, for use solely and
 exclusively with Microchip PIC Microcontroller products. The
 software is owned by the Company and/or its supplier, and is
 protected under applicable copyright laws. All rights are reserved.
 Any use in violation of the foregoing restrictions may subject the
 user to criminal sanctions under applicable laws, as well as to
 civil liability for the breach of the terms and conditions of this
 license.

 THIS SOFTWARE IS PROVIDED IN AN 鄭S IS・CONDITION. NO WARRANTIES,
 WHETHER EXPRESS, IMPLIED OR STATUTORY, INCLUDING, BUT NOT LIMITED
 TO, IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A
 PARTICULAR PURPOSE APPLY TO THIS SOFTWARE. THE COMPANY SHALL NOT,
 IN ANY CIRCUMSTANCES, BE LIABLE FOR SPECIAL, INCIDENTAL OR
 CONSEQUENTIAL DAMAGES, FOR ANY REASON WHATSOEVER.

********************************************************************
 File Description:

 Change History:
  Rev   Date         Description
  2.5a	07/17/2009	 Initial Release.  Ported from HID PnP Demo
                     application source, which was originally 
                     written in MSVC++ 2005 Express Edition.
********************************************************************
NOTE:	All user made code contained in this project is in the Form1.cs file.
		All other code and files were generated automatically by either the
		new project wizard, or by the development environment (ex: code is
		automatically generated if you create a new button on the form, and
		then double click on it, which creates a click event handler
		function).  User developed code (code not developed by the IDE) has
        been marked in "cut and paste blocks" to make it easier to identify.
********************************************************************/

//NOTE: In order for this program to "find" a USB device with a given VID and PID, 
//both the VID and PID in the USB device descriptor (in the USB firmware on the 
//microcontroller), as well as in this PC application source code, must match.
//To change the VID/PID in this PC application source code, scroll down to the 
//CheckIfPresentAndGetUSBDevicePath() function, and change the line that currently
//reads:

//   String DeviceIDToFind = "Vid_04d8&Pid_003f";


//NOTE 2: This C# program makes use of several functions in setupapi.dll and
//other Win32 DLLs.  However, one cannot call the functions directly in a 
//32-bit DLL if the project is built in "Any CPU" mode, when run on a 64-bit OS.
//When configured to build an "Any CPU" executable, the executable will "become"
//a 64-bit executable when run on a 64-bit OS.  On a 32-bit OS, it will run as 
//a 32-bit executable, and the pointer sizes and other aspects of this 
//application will be compatible with calling 32-bit DLLs.

//Therefore, on a 64-bit OS, this application will not work unless it is built in
//"x86" mode.  When built in this mode, the exectuable always runs in 32-bit mode
//even on a 64-bit OS.  This allows this application to make 32-bit DLL function 
//calls, when run on either a 32-bit or 64-bit OS.

//By default, on a new project, C# normally wants to build in "Any CPU" mode.  
//To switch to "x86" mode, open the "Configuration Manager" window.  In the 
//"Active solution platform:" drop down box, select "x86".  If this option does
//not appear, select: "<New...>" and then select the x86 option in the 
//"Type or select the new platform:" drop down box.  

//-------------------------------------------------------END CUT AND PASTE BLOCK-------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------------------------------------------------------------



using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;
using System.Threading;


namespace ReviveUSBAdvance
{
    public partial class Form1 : Form
    {
#if DEBUG
        internal const bool __DEBUG_FLAG__ = true;    // デバッグ時
#else
        internal const bool __DEBUG_FLAG__ = false;     // リリース時
#endif

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------BEGIN CUT AND PASTE BLOCK-----------------------------------------------------------------------------------

        //Constant definitions from setupapi.h, which we aren't allowed to include directly since this is C#
        internal const uint DIGCF_PRESENT = 0x02;
        internal const uint DIGCF_DEVICEINTERFACE = 0x10;
        //Constants for CreateFile() and other file I/O functions
        internal const short FILE_ATTRIBUTE_NORMAL = 0x80;
        internal const short INVALID_HANDLE_VALUE = -1;
        internal const uint GENERIC_READ = 0x80000000;
        internal const uint GENERIC_WRITE = 0x40000000;
        internal const uint CREATE_NEW = 1;
        internal const uint CREATE_ALWAYS = 2;
        internal const uint OPEN_EXISTING = 3;
        internal const uint FILE_SHARE_READ = 0x00000001;
        internal const uint FILE_SHARE_WRITE = 0x00000002;
        //Constant definitions for certain WM_DEVICECHANGE messages
        internal const uint WM_DEVICECHANGE = 0x0219;
        internal const uint DBT_DEVICEARRIVAL = 0x8000;
        internal const uint DBT_DEVICEREMOVEPENDING = 0x8003;
        internal const uint DBT_DEVICEREMOVECOMPLETE = 0x8004;
        internal const uint DBT_CONFIGCHANGED = 0x0018;
        //Other constant definitions
        internal const uint DBT_DEVTYP_DEVICEINTERFACE = 0x05;
        internal const uint DEVICE_NOTIFY_WINDOW_HANDLE = 0x00;
        internal const uint ERROR_SUCCESS = 0x00;
        internal const uint ERROR_NO_MORE_ITEMS = 0x00000103;
        internal const uint SPDRP_HARDWAREID = 0x00000001;

        //Various structure definitions for structures that this code will be using
        internal struct SP_DEVICE_INTERFACE_DATA
        {
            internal uint cbSize;               //DWORD
            internal Guid InterfaceClassGuid;   //GUID
            internal uint Flags;                //DWORD
            internal uint Reserved;             //ULONG_PTR MSDN says ULONG_PTR is "typedef unsigned __int3264 ULONG_PTR;"  
        }

        internal struct SP_DEVICE_INTERFACE_DETAIL_DATA
        {
            internal uint cbSize;               //DWORD
            internal char[] DevicePath;         //TCHAR array of any size
        }
        
        internal struct SP_DEVINFO_DATA
        {
            internal uint cbSize;       //DWORD
            internal Guid ClassGuid;    //GUID
            internal uint DevInst;      //DWORD
            internal uint Reserved;     //ULONG_PTR  MSDN says ULONG_PTR is "typedef unsigned __int3264 ULONG_PTR;"  
        }

        internal struct DEV_BROADCAST_DEVICEINTERFACE
        {
            internal uint dbcc_size;            //DWORD
            internal uint dbcc_devicetype;      //DWORD
            internal uint dbcc_reserved;        //DWORD
            internal Guid dbcc_classguid;       //GUID
            internal char[] dbcc_name;          //TCHAR array
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// SW設定
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        internal struct STR_SW_INFO
        {
            internal byte[] sw_data;       // SW機能データ
            internal void init_data(int p_data_len)
            {
                sw_data = new byte[p_data_len];
                for (int fi = 0; fi < p_data_len; fi++)
                {
                    sw_data[fi] = 0;
                }
            }
            internal void clear()
            {
                for (int fi = 0; fi <= sw_data.GetUpperBound(0); fi++)
                {
                    sw_data[fi] = 0;
                }
            }
        }
        public struct STR_SW_DATAS
        {
            internal STR_SW_INFO[] sw_datas;
            internal void init_data(byte p_sw_num, byte p_data_len)
            {
                sw_datas = new STR_SW_INFO[p_sw_num];
                for (int fi = 0; fi < sw_datas.Length; fi++)
                {
                    sw_datas[fi].init_data(p_data_len);
                }
            }
            internal void clear(int p_sw_idx)
            {
                if (0 <= p_sw_idx && p_sw_idx < sw_datas.Length)
                {
                    sw_datas[p_sw_idx].clear();
                }
            }
            internal void all_clear()
            {
                for (int fi = 0; fi < sw_datas.Length; fi++)
                {
                    clear(fi);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// AN設定
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        internal struct STR_AN_INFO
        {
            internal byte[] an_data;                  // AN機能制御データ
            internal void init_data(int p_an_data_len)
            {
                an_data = new byte[p_an_data_len];
                for (int fi = 0; fi < an_data.Length; fi++)
                {
                    an_data[fi] = 0;
                }
            }
            internal void clear()
            {
                for (int fi = 0; fi <= an_data.GetUpperBound(0); fi++)
                {
                    an_data[fi] = 0;
                }
            }
        }
        public struct STR_AN_DATAS
        {
            internal STR_AN_INFO[] an_datas;
            internal void init_data(byte p_an_num, byte p_data_len)
            {
                an_datas = new STR_AN_INFO[p_an_num];
                for (int fi = 0; fi < an_datas.Length; fi++)
                {
                    an_datas[fi].init_data(p_data_len);
                }
            }
            internal void clear(int p_an_idx)
            {
                if (0 <= p_an_idx && p_an_idx < an_datas.Length)
                {
                    an_datas[p_an_idx].clear();
                }
            }
            internal void all_clear()
            {
                for (int fi = 0; fi < an_datas.Length; fi++)
                {
                    clear(fi);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// EEPROM
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        internal struct STR_EEPROM_READ_WRITE_BUFFER
        {
            internal byte[] read_buff;
            internal byte[] write_buff;
            internal bool[] write_flag;
            internal bool write_req;

            internal void init_data(uint p_eeprom_size)
            {
                read_buff = new byte[p_eeprom_size];
                write_buff = new byte[p_eeprom_size];
                write_flag = new bool[p_eeprom_size];
                for (int fi = 0; fi < p_eeprom_size; fi++)
                {
                    read_buff[fi] = 0xFF;
                    write_buff[fi] = 0xFF;
                    write_flag[fi] = false;
                }
                write_req = false;
            }
            internal void clear()
            {
                for (int fi = 0; fi < read_buff.Length; fi++)
                {
                    read_buff[fi] = 0xFF;
                    write_buff[fi] = 0xFF;
                    write_flag[fi] = false;
                }
                write_req = false;
            }
            internal void write_data_clear()
            {
                for (int fi = 0; fi < write_buff.Length; fi++)
                {
                    write_buff[fi] = 0xFF;
                    write_flag[fi] = false;
                }
                write_req = false;
            }
            internal void set_write_req()
            {
                write_req = true;
            }
            internal void set_write_data(int p_address, byte p_data)
            {
                if (0 <= p_address && p_address < write_buff.Length)
                {
                    write_buff[p_address] = p_data;
                    write_flag[p_address] = true;
                }
            }
            internal void set_write_data(int p_address, byte[] p_data, int p_write_size)
            {
                if (0 <= p_address && (p_address + p_write_size) <= write_buff.Length
                    && 0 < p_write_size && p_data.Length == p_write_size)
                {
                    for (int fi = 0; fi < p_write_size; fi++)
                    {
                        write_buff[p_address + fi] = p_data[fi];
                        write_flag[p_address + fi] = true;
                    }
                }
            }
        }

        //DLL Imports.  Need these to access various C style unmanaged functions contained in their respective DLL files.
        //--------------------------------------------------------------------------------------------------------------
        //Returns a HDEVINFO type for a device information set.  We will need the 
        //HDEVINFO as in input parameter for calling many of the other SetupDixxx() functions.
        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern IntPtr SetupDiGetClassDevs(
            ref Guid ClassGuid,     //LPGUID    Input: Need to supply the class GUID. 
            IntPtr Enumerator,      //PCTSTR    Input: Use NULL here, not important for our purposes
            IntPtr hwndParent,      //HWND      Input: Use NULL here, not important for our purposes
            uint Flags);            //DWORD     Input: Flags describing what kind of filtering to use.

	    //Gives us "PSP_DEVICE_INTERFACE_DATA" which contains the Interface specific GUID (different
	    //from class GUID).  We need the interface GUID to get the device path.
        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern bool SetupDiEnumDeviceInterfaces(
            IntPtr DeviceInfoSet,           //Input: Give it the HDEVINFO we got from SetupDiGetClassDevs()
            IntPtr DeviceInfoData,          //Input (optional)
            ref Guid InterfaceClassGuid,    //Input 
            uint MemberIndex,               //Input: "Index" of the device you are interested in getting the path for.
            ref SP_DEVICE_INTERFACE_DATA DeviceInterfaceData);    //Output: This function fills in an "SP_DEVICE_INTERFACE_DATA" structure.

        //SetupDiDestroyDeviceInfoList() frees up memory by destroying a DeviceInfoList
        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern bool SetupDiDestroyDeviceInfoList(
            IntPtr DeviceInfoSet);          //Input: Give it a handle to a device info list to deallocate from RAM.

        //SetupDiEnumDeviceInfo() fills in an "SP_DEVINFO_DATA" structure, which we need for SetupDiGetDeviceRegistryProperty()
        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern bool SetupDiEnumDeviceInfo(
            IntPtr DeviceInfoSet,
            uint MemberIndex,
            ref SP_DEVINFO_DATA DeviceInterfaceData);

        //SetupDiGetDeviceRegistryProperty() gives us the hardware ID, which we use to check to see if it has matching VID/PID
        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern bool SetupDiGetDeviceRegistryProperty(
            IntPtr DeviceInfoSet,
            ref SP_DEVINFO_DATA DeviceInfoData,
            uint Property,
            ref uint PropertyRegDataType,
            IntPtr PropertyBuffer,
            uint PropertyBufferSize,
            ref uint RequiredSize);

        //SetupDiGetDeviceInterfaceDetail() gives us a device path, which is needed before CreateFile() can be used.
        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern bool SetupDiGetDeviceInterfaceDetail(
            IntPtr DeviceInfoSet,                   //Input: Wants HDEVINFO which can be obtained from SetupDiGetClassDevs()
            ref SP_DEVICE_INTERFACE_DATA DeviceInterfaceData,                    //Input: Pointer to an structure which defines the device interface.  
            IntPtr  DeviceInterfaceDetailData,      //Output: Pointer to a SP_DEVICE_INTERFACE_DETAIL_DATA structure, which will receive the device path.
            uint DeviceInterfaceDetailDataSize,     //Input: Number of bytes to retrieve.
            ref uint RequiredSize,                  //Output (optional): The number of bytes needed to hold the entire struct 
            IntPtr DeviceInfoData);                 //Output (optional): Pointer to a SP_DEVINFO_DATA structure

        //Overload for SetupDiGetDeviceInterfaceDetail().  Need this one since we can't pass NULL pointers directly in C#.
        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern bool SetupDiGetDeviceInterfaceDetail(
            IntPtr DeviceInfoSet,                   //Input: Wants HDEVINFO which can be obtained from SetupDiGetClassDevs()
            ref SP_DEVICE_INTERFACE_DATA DeviceInterfaceData,               //Input: Pointer to an structure which defines the device interface.  
            IntPtr DeviceInterfaceDetailData,       //Output: Pointer to a SP_DEVICE_INTERFACE_DETAIL_DATA structure, which will contain the device path.
            uint DeviceInterfaceDetailDataSize,     //Input: Number of bytes to retrieve.
            IntPtr RequiredSize,                    //Output (optional): Pointer to a DWORD to tell you the number of bytes needed to hold the entire struct 
            IntPtr DeviceInfoData);                 //Output (optional): Pointer to a SP_DEVINFO_DATA structure

        //Need this function for receiving all of the WM_DEVICECHANGE messages.  See MSDN documentation for
        //description of what this function does/how to use it. Note: name is remapped "RegisterDeviceNotificationUM" to
        //avoid possible build error conflicts.
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern IntPtr RegisterDeviceNotification(
            IntPtr hRecipient,
            IntPtr NotificationFilter,
            uint Flags);

        //Takes in a device path and opens a handle to the device.
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        static extern SafeFileHandle CreateFile(
            string lpFileName,
            uint dwDesiredAccess,
            uint dwShareMode, 
            IntPtr lpSecurityAttributes, 
            uint dwCreationDisposition,
            uint dwFlagsAndAttributes, 
            IntPtr hTemplateFile);

        //Uses a handle (created with CreateFile()), and lets us write USB data to the device.
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        static extern bool WriteFile(
            SafeFileHandle hFile,
            byte[] lpBuffer,
            uint nNumberOfBytesToWrite,
            ref uint lpNumberOfBytesWritten,
            IntPtr lpOverlapped);

        //Uses a handle (created with CreateFile()), and lets us read USB data from the device.
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        static extern bool ReadFile(
            SafeFileHandle hFile,
            IntPtr lpBuffer,
            uint nNumberOfBytesToRead,
            ref uint lpNumberOfBytesRead,
            IntPtr lpOverlapped);



	    //--------------- Global Varibles Section ------------------
	    //USB related variables that need to have wide scope.
	    bool AttachedState = false;						//Need to keep track of the USB device attachment status for proper plug and play operation.
	    bool AttachedButBroken = false;
        SafeFileHandle WriteHandleToUSBDevice = null;
        SafeFileHandle ReadHandleToUSBDevice = null;
        String DevicePath = null;   //Need the find the proper device path before you can open file handles.

        bool ConnectFirstTime = true;
        bool UnConnectFirstTime = true;
        bool VersionReadReq = true;
        bool VersionReadComp = false;
        byte[] version_buff = new byte[64];

        STR_SW_DATAS my_sw_datas;
        STR_AN_DATAS my_an_datas;
        STR_EEPROM_READ_WRITE_BUFFER my_eeprom_read_write_buffer;
        EepromControl fData = new EepromControl();
        bool EepromReadFirstTime = true;
        byte[] sw_disp_data = new byte[Constants.SW_DEVICE_DATA_LEN];
        byte[] an_disp_data = new byte[Constants.AN_DEVICE_DATA_LEN];

        byte[] sw_status = new byte[Constants.DIGITAL_INPUT_NUM];
        uint[] an_status = new uint[Constants.ANALOG_INPUT_NUM];

        bool set_sw_info_flag = false;
        byte set_sw_info_sw_no = 0;
        bool set_an_info_flag = false;
        byte set_an_info_an_no = 0;
        bool set_an_calibration_flag = false;
        bool set_an_calibration_req = false;
        byte set_an_calibration_an_no = 0;

	    //Variables used by the application/form updates.
        byte[] eeprom_data = new byte[64]{0,0,0,0,0,0,0,0,0,0,
                                          0,0,0,0,0,0,0,0,0,0,
                                          0,0,0,0,0,0,0,0,0,0,
                                          0,0,0,0,0,0,0,0,0,0,
                                          0,0,0,0,0,0,0,0,0,0,
                                          0,0,0,0,0,0,0,0,0,0,
                                          0,0,0,0};
        bool[] ChangeAssign = new bool[Constants.DIGITAL_INPUT_NUM] { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true };
        //bool Changevalue_btn_pressed = false;

        byte SW_DeviceType_selected = 0;
        byte MouseValue_selected = 0;
        byte KeyboardValue_selected = 0;
        byte KeyboardModifier_selected = 0;
        byte LeverValue_selected = 0;
        byte HatSWValue_selected = 0;
        byte[] ButtonValue_selected = new byte[2];
        //uint PushButonState = 0;
        int sw_selected = 0;
        byte MouseMoveValue_selected = 80;
        byte Now_Background_image = 0;  //どっちの背景が表示されているか。0:未接続 1:接続済み
        //int StatusBoxChange = 99;
        //bool ReadFromDevice = true;

        int an_selected = 0;
        int an_set_type_select = 0;

        // SWデジタル機能設定デバイスタイプ
        string[] sw_device_type_list = new string[] { "未設定", "マウス", "キーボード", "ジョイスティック" };
        byte[] sw_device_type_no_list = new byte[] { Constants.SW_SET_DEVICE_TYPE_NONE, Constants.SW_SET_DEVICE_TYPE_MOUSE, Constants.SW_SET_DEVICE_TYPE_KEYBOARD, Constants.SW_SET_DEVICE_TYPE_JOYSTICK };
        string[] sw_mouse_set_type_list = new string[] { "左クリック", "右クリック", "ホイールクリック", "ボタン4", "ボタン5", "上移動", "下移動", "左移動", "右移動", "ホイール上", "ホイール下", "移動速度変更" };
        //string[] sw_mouse_set_type_list = new string[] { "左クリック", "右クリック", "ホイールクリック", "ボタン4", "ボタン5", "上移動", "下移動", "左移動", "右移動", "ホイール上", "ホイール下" };
        //string[] sw_mouse_set_type_list = new string[] { "左クリック", "右クリック", "ホイールクリック", "ボタン4", "ボタン5", "ダブルクリック", "上移動", "下移動", "左移動", "右移動", "ホイール上", "ホイール下" };
        //string[] sw_mouse_set_type_list = new string[] { "左クリック", "右クリック", "ホイールクリック", "ボタン4", "ボタン5", "ダブルクリック", "上移動", "下移動", "左移動", "右移動", "ホイール上", "ホイール下", "移動速度変更" };
        string[] sw_joystick_set_type_lever_list = new string[] { "レバー X+", "レバー X-", "レバー Y+", "レバー Y-", "レバー Z+", "レバー Z-", "レバー RX+", "レバー RX-", "レバー RY+", "レバー RY-", "レバー RZ+", "レバー RZ-", "スライダー +", "スライダー -" };
        string[] sw_joystick_set_type_hatsw_list = new string[] { "HAT SW 上", "HAT SW 右", "HAT SW 下", "HAT SW 左" };
        string[] sw_joystick_set_type_button_list = new string[] { "ボタン1", "ボタン2", "ボタン3", "ボタン4", "ボタン5", "ボタン6", "ボタン7", "ボタン8", "ボタン9", "ボタン10", "ボタン11", "ボタン12", "ボタン13", "ボタン14", "ボタン15" };

        public string[] keyboard_modifier_name = new string[] { "Ctrl L", "Shift L", "Alt L", "Win L", "Ctrl R", "Shift R", "Alt R", "Win R" };
        public byte[] keyboard_modifier_bit = new byte[] { 0x01, 0x02, 0x04, 0x08, 0x10, 0x20, 0x40, 0x80 };
        public string[] keyboard_modifier_name_4type = new string[] { "Ctrl", "Shift", "Alt", "Win" };
        public byte[] keyboard_modifier_bit_4type = new byte[] { 0x01, 0x02, 0x04, 0x08, 0x10, 0x20, 0x40, 0x80 };
        public byte[] joystick_lever_set_bit = new byte[] { Constants.LEVER_SWITCH_BIT_X_P, Constants.LEVER_SWITCH_BIT_X_M, Constants.LEVER_SWITCH_BIT_Y_P, Constants.LEVER_SWITCH_BIT_Y_M, Constants.LEVER_SWITCH_BIT_Z_P, Constants.LEVER_SWITCH_BIT_Z_M, 
                                                        Constants.LEVER_SWITCH_BIT_RX_P, Constants.LEVER_SWITCH_BIT_RX_M, Constants.LEVER_SWITCH_BIT_RY_P, Constants.LEVER_SWITCH_BIT_RY_M, Constants.LEVER_SWITCH_BIT_RZ_P, Constants.LEVER_SWITCH_BIT_RZ_M,
                                                        Constants.LEVER_SWITCH_BIT_SL_P, Constants.LEVER_SWITCH_BIT_SL_M};
        public byte[] joystick_lever_set_byte = new byte[] { Constants.LEVER_SWITCH_BYTE_POS_X_P, Constants.LEVER_SWITCH_BYTE_POS_X_M, Constants.LEVER_SWITCH_BYTE_POS_Y_P, Constants.LEVER_SWITCH_BYTE_POS_Y_M, Constants.LEVER_SWITCH_BYTE_POS_Z_P, Constants.LEVER_SWITCH_BYTE_POS_Z_M, 
                                                        Constants.LEVER_SWITCH_BYTE_POS_RX_P, Constants.LEVER_SWITCH_BYTE_POS_RX_M, Constants.LEVER_SWITCH_BYTE_POS_RY_P, Constants.LEVER_SWITCH_BYTE_POS_RY_M, Constants.LEVER_SWITCH_BYTE_POS_RZ_P, Constants.LEVER_SWITCH_BYTE_POS_RZ_M,
                                                        Constants.LEVER_SWITCH_BYTE_POS_SL_P, Constants.LEVER_SWITCH_BYTE_POS_SL_M};
        public byte[] joystick_hatsw_set_bit = new byte[] { Constants.HAT_SWITCH_BIT_NORTH, Constants.HAT_SWITCH_BIT_EAST, Constants.HAT_SWITCH_BIT_SOUTH, Constants.HAT_SWITCH_BIT_WEST };
        public byte[] joystick_button_set_bit = new byte[] { 0x01, 0x02, 0x04, 0x08, 0x10, 0x20, 0x40, 0x80, 0x01, 0x02, 0x04, 0x08, 0x10, 0x20, 0x40 };
        public byte[] joystick_button_set_byte = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01 };

        // An 
        static public byte[] analog_lever_setting_default_value = new byte[] { 0x00, 0xFF, 
                                                                        0x00, 0x05, 0x00, 
                                                                        0x00, 0xA5, 0x80, 
                                                                        0x01, 0x45, 0xFF};
        static public byte[] analog_mouse_setting_default_value = new byte[] { 0x00, 0x00, 
                                                                        0x00, 0x00, 0x00, 
                                                                        0x00, 0x00, 0x00, 
                                                                        0x00, 0x00, 0x00};
        string[] analog_set_type_list = new string[] { "未設定", "アナログ X", "アナログ Y", "アナログ Z", "アナログ RX", "アナログ RY", "アナログ RZ", "アナログ SLIDER", "マウス X", "マウス Y" };
        byte[] analog_set_type_no_list = new byte[] { Constants.AN_SET_DEVICE_TYPE_NONE, Constants.AN_SET_DEVICE_TYPE_X, Constants.AN_SET_DEVICE_TYPE_Y, Constants.AN_SET_DEVICE_TYPE_Z, Constants.AN_SET_DEVICE_TYPE_RX, Constants.AN_SET_DEVICE_TYPE_RY, Constants.AN_SET_DEVICE_TYPE_RZ, Constants.AN_SET_DEVICE_TYPE_SL, Constants.AN_SET_DEVICE_TYPE_MOUSE_X, Constants.AN_SET_DEVICE_TYPE_MOUSE_Y };


        // Soft Reset
        bool b_soft_reset_req = false;
        // Default set
        bool b_default_set_req = false;

        CheckBox[] my_chkbx_keyboard_modifier;
        CheckBox[] my_chkbx_joystick_lever;
        CheckBox[] my_chkbx_joystick_hatsw;
        CheckBox[] my_chkbx_joystick_button;

        Label[] my_lbl_sw_assign;
        Label[] my_lbl_sw_device_type;
        PictureBox[] my_pic_sw_status;
        PictureBox[] my_pin_no_pic_a;
        PictureBox[] my_pin_no_pic_b;
        Label[] my_lbl_an_status;
        Label[] my_lbl_an_assign;
        PictureBox[] my_an_pin_no_pic_a;
        PictureBox[] my_an_pin_no_pic_b;

        static KeyCode const_Key_Code = new KeyCode();

        // DEBUG
        int[] Debug_Array1 = new int[16];    //DEBUG
        int[] Debug_Array2 = new int[16];
        int[] Debug_Array3 = new int[16];    //DEBUG
        bool debug_eeprom_read_req = false;
        bool debug_eeprom_read_comp = false;
        uint debug_eeprom_read_start_addr = 0;
        uint debug_eeprom_read_size = 0;
        bool debug_eeprom_write_req = false;
        uint debug_eeprom_write_start_addr = 0;
        uint debug_eeprom_write_size = 0;
        byte[] debug_eeprom_read_buff = new byte[EepromControl.E2P_TOTAL_SIZE];
        byte[] debug_eeprom_write_buff = new byte[EepromControl.E2P_USB_WRITE_DATA_SIZE];

#if false
        //バーチャルキーコードとUSBキーコードの変換用配列
        byte[] VKtoUSBkey = new byte[256]{
            0x00,   //0
            0x00,   //1
            0x00,   //2
            0x00,   //3
            0x00,   //4
            0x00,   //5
            0x00,   //6
            0x00,   //7
            0x2A,   //8
            0x2B,   //9
            0x00,   //10
            0x00,   //11
            0x00,   //12
            0x28,   //13
            0x00,   //14
            0x00,   //15
            0xE1,   //16
            0xE0,   //17
            0xE2,   //18
            0x48,   //19
            0x39,   //20
            0x88,   //21
            0x00,   //22
            0x00,   //23
            0x00,   //24
            0x35,   //25
            0x00,   //26
            0x29,   //27
            0x8A,   //28
            0x8B,   //29
            0x00,   //30
            0x00,   //31
            0x2C,   //32
            0x4B,   //33
            0x4E,   //34
            0x4D,   //35
            0x4A,   //36
            0x50,   //37
            0x52,   //38
            0x4F,   //39
            0x51,   //40
            0x00,   //41
            0x00,   //42
            0x00,   //43
            0x46,   //44
            0x49,   //45
            0x4C,   //46
            0x00,   //47
            0x27,   //48
            0x1E,   //49
            0x1F,   //50
            0x20,   //51
            0x21,   //52
            0x22,   //53
            0x23,   //54
            0x24,   //55
            0x25,   //56
            0x26,   //57
            0x00,   //58
            0x00,   //59
            0x00,   //60
            0x00,   //61
            0x00,   //62
            0x00,   //63
            0x00,   //64
            0x04,   //65
            0x05,   //66
            0x06,   //67
            0x07,   //68
            0x08,   //69
            0x09,   //70
            0x0A,   //71
            0x0B,   //72
            0x0C,   //73
            0x0D,   //74
            0x0E,   //75
            0x0F,   //76
            0x10,   //77
            0x11,   //78
            0x12,   //79
            0x13,   //80
            0x14,   //81
            0x15,   //82
            0x16,   //83
            0x17,   //84
            0x18,   //85
            0x19,   //86
            0x1A,   //87
            0x1B,   //88
            0x1C,   //89
            0x1D,   //90
            0xE3,   //91
            0xE7,   //92
            0x65,   //93
            0x00,   //94
            0x00,   //95
            0x62,   //96
            0x59,   //97
            0x5A,   //98
            0x5B,   //99
            0x5C,   //100
            0x5D,   //101
            0x5E,   //102
            0x5F,   //103
            0x60,   //104
            0x61,   //105
            0x55,   //106
            0x57,   //107
            0x85,   //108
            0x56,   //109
            0x63,   //110
            0x54,   //111
            0x3A,   //112
            0x3B,   //113
            0x3C,   //114
            0x3D,   //115
            0x3E,   //116
            0x3F,   //117
            0x40,   //118
            0x41,   //119
            0x42,   //120
            0x43,   //121
            0x44,   //122
            0x45,   //123
            0x68,   //124
            0x69,   //125
            0x6A,   //126
            0x6B,   //127
            0x6C,   //128
            0x6D,   //129
            0x6E,   //130
            0x6F,   //131
            0x70,   //132
            0x71,   //133
            0x72,   //134
            0x73,   //135
            0x00,   //136
            0x00,   //137
            0x00,   //138
            0x00,   //139
            0x00,   //140
            0x00,   //141
            0x00,   //142
            0x00,   //143
            0x53,   //144
            0x47,   //145
            0x67,   //146
            0x00,   //147
            0x00,   //148
            0x00,   //149
            0x00,   //150
            0x00,   //151
            0x00,   //152
            0x00,   //153
            0x00,   //154
            0x00,   //155
            0x00,   //156
            0x00,   //157
            0x00,   //158
            0x00,   //159
            0xE1,   //160
            0xE5,   //161
            0xE0,   //162
            0xE4,   //163
            0xE2,   //164
            0xE6,   //165
            0x00,   //166
            0x00,   //167
            0x00,   //168
            0x00,   //169
            0x00,   //170
            0x00,   //171
            0x00,   //172
            0x00,   //173
            0x00,   //174
            0x00,   //175
            0x00,   //176
            0x00,   //177
            0x00,   //178
            0x00,   //179
            0x00,   //180
            0x00,   //181
            0x00,   //182
            0x00,   //183
            0x00,   //184
            0x00,   //185
            0x34,   //186
            0x33,   //187
            0x36,   //188
            0x2D,   //189
            0x37,   //190
            0x38,   //191
            0x2F,   //192
            0x00,   //193
            0x00,   //194
            0x00,   //195
            0x00,   //196
            0x00,   //197
            0x00,   //198
            0x00,   //199
            0x00,   //200
            0x00,   //201
            0x00,   //202
            0x00,   //203
            0x00,   //204
            0x00,   //205
            0x00,   //206
            0x00,   //207
            0x00,   //208
            0x00,   //209
            0x00,   //210
            0x00,   //211
            0x00,   //212
            0x00,   //213
            0x00,   //214
            0x00,   //215
            0x00,   //216
            0x00,   //217
            0x00,   //218
            0x30,   //219
            0x89,   //220
            0x32,   //221
            0x2E,   //222
            0x00,   //223
            0x00,   //224
            0x00,   //225
            0x87,   //226
            0x00,   //227
            0x00,   //228
            0x35,   //229
            0x00,   //230
            0x00,   //231
            0x00,   //232
            0x00,   //233
            0x00,   //234
            0x00,   //235
            0x00,   //236
            0x00,   //237
            0x00,   //238
            0x00,   //239
            0x39,   //240
            0x00,   //241
            0x39,   //242
            0x35,   //243
            0x35,   //244
            0x00,   //245
            0x00,   //246
            0x00,   //247
            0x00,   //248
            0x00,   //249
            0x00,   //250
            0x00,   //251
            0x00,   //252
            0x00,   //253
            0x00,   //254
            0x00,   //255
       };
#if true
        //USBキーコードの名称配列
        public string[] USB_KeyCode_Name = new string[256]{
            "",   //0
            "",   //1
            "",   //2
            "",   //3
            "A",   //4
            "B",   //5
            "C",   //6
            "D",   //7
            "E",   //8
            "F",   //9
            "G",   //10
            "H",   //11
            "I",   //12
            "J",   //13
            "K",   //14
            "L",   //15
            "M",   //16
            "N",   //17
            "O",   //18
            "P",   //19
            "Q",   //20
            "R",   //21
            "S",   //22
            "T",   //23
            "U",   //24
            "V",   //25
            "W",   //26
            "X",   //27
            "Y",   //28
            "Z",   //29
            "1",   //30
            "2",   //31
            "3",   //32
            "4",   //33
            "5",   //34
            "6",   //35
            "7",   //36
            "8",   //37
            "9",   //38
            "0",   //39
            "Enter",   //40
            "ESC",   //41
            "BS",   //42
            "Tab",   //43
            "Space",   //44
            "-",   //45
            "^",   //46
            "@",   //47
            "[",   //48
            "",   //49
            "]",   //50
            ";",   //51
            ":",   //52
            "ZenHan",   //53
            ",",   //54
            ".",   //55
            "/",   //56
            "CapsLK",   //57
            "F1",   //58
            "F2",   //59
            "F3",   //60
            "F4",   //61
            "F5",   //62
            "F6",   //63
            "F7",   //64
            "F8",   //65
            "F9",   //66
            "F10",   //67
            "F11",   //68
            "F12",   //69
            "PrtSC",   //70
            "ScLK",   //71
            "Pause",   //72
            "Insert",   //73
            "Home",   //74
            "pgUp",   //75
            "Delete",   //76
            "End",   //77
            "pgDown",   //78
            "→",   //79
            "←",   //80
            "↓",   //81
            "↑",   //82
            "NumLK",   //83
            "Num/",   //84
            "Num*",   //85
            "Num-",   //86
            "Num+",   //87
            "NumENT",   //88
            "Num1",   //89
            "Num2",   //90
            "Num3",   //91
            "Num4",   //92
            "Num5",   //93
            "Num6",   //94
            "Num7",   //95
            "Num8",   //96
            "Num9",   //97
            "Num0",   //98
            "Num.",   //99
            "",   //100
            "Menu",   //101
            "",   //102
            "",   //103
            "",   //104
            "",   //105
            "",   //106
            "",   //107
            "",   //108
            "",   //109
            "",   //110
            "",   //111
            "",   //112
            "",   //113
            "",   //114
            "",   //115
            "",   //116
            "",   //117
            "",   //118
            "",   //119
            "",   //120
            "",   //121
            "",   //122
            "",   //123
            "",   //124
            "",   //125
            "",   //126
            "",   //127
            "",   //128
            "",   //129
            "",   //130
            "",   //131
            "",   //132
            "",   //133
            "",   //134
            "BackSL",   //135
            "k/Hira",   //136
            "￥",   //137
            "変換",   //138
            "無変換",   //139
            "",   //140
            "",   //141
            "",   //142
            "",   //143
            "",   //144
            "",   //145
            "",   //146
            "",   //147
            "",   //148
            "",   //149
            "",   //150
            "",   //151
            "",   //152
            "",   //153
            "",   //154
            "",   //155
            "",   //156
            "",   //157
            "",   //158
            "",   //159
            "",   //160
            "",   //161
            "",   //162
            "",   //163
            "",   //164
            "",   //165
            "",   //166
            "",   //167
            "",   //168
            "",   //169
            "",   //170
            "",   //171
            "",   //172
            "",   //173
            "",   //174
            "",   //175
            "",   //176
            "",   //177
            "",   //178
            "",   //179
            "",   //180
            "",   //181
            "",   //182
            "",   //183
            "",   //184
            "",   //185
            "",   //186
            "",   //187
            "",   //188
            "",   //189
            "",   //190
            "",   //191
            "",   //192
            "",   //193
            "",   //194
            "",   //195
            "",   //196
            "",   //197
            "",   //198
            "",   //199
            "",   //200
            "",   //201
            "",   //202
            "",   //203
            "",   //204
            "",   //205
            "",   //206
            "",   //207
            "",   //208
            "",   //209
            "",   //210
            "",   //211
            "",   //212
            "",   //213
            "",   //214
            "",   //215
            "",   //216
            "",   //217
            "",   //218
            "",   //219
            "",   //220
            "",   //221
            "",   //222
            "",   //223
            "Ctrl L",   //224
            "Shift L",   //225
            "Alt L",   //226
            "Win L",   //227
            "Ctrl R",   //228
            "Shift R",   //229
            "Alt R",   //230
            "Win R",   //231
            "",   //232
            "",   //233
            "",   //234
            "",   //235
            "",   //236
            "",   //237
            "",   //238
            "",   //239
            "",   //240
            "",   //241
            "",   //242
            "",   //243
            "",   //244
            "",   //245
            "",   //246
            "",   //247
            "",   //248
            "",   //249
            "",   //250
            "",   //251
            "",   //252
            "",   //253
            "",   //254
            "",   //255
       };
#endif
#endif


        //Globally Unique Identifier (GUID) for HID class devices.  Windows uses GUIDs to identify things.
        Guid InterfaceClassGuid = new Guid(0x4d1e55b2, 0xf16f, 0x11cf, 0x88, 0xcb, 0x00, 0x11, 0x11, 0x00, 0x00, 0x30); 
	    //--------------- End of Global Varibles ------------------

        //-------------------------------------------------------END CUT AND PASTE BLOCK-------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------


        //Need to check "Allow unsafe code" checkbox in build properties to use unsafe keyword.  Unsafe is needed to
        //properly interact with the unmanged C++ style APIs used to find and connect with the USB device.
        public unsafe Form1()
        {
            InitializeComponent();

            try
            {
                if (__DEBUG_FLAG__ == false)
                {   // Release
                    this.Size = new System.Drawing.Size(1010, 630);
                }
                else
                {   // DEBUG
                }

                //自分自身のバージョン情報を取得する
                System.Diagnostics.FileVersionInfo fver = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location);
                this.Text += fver.FileVersion;

                pnl_digital_setting.Location = pnl_analog_setting.Location;

                my_sw_datas.init_data(Constants.DIGITAL_INPUT_NUM, EepromControl.E2P_SW_INFO_SW_DATA_SIZE);
                my_an_datas.init_data(Constants.ANALOG_INPUT_NUM, EepromControl.E2P_AN_INFO_AN_DATA_SIZE);
                my_eeprom_read_write_buffer.init_data(EepromControl.E2P_TOTAL_SIZE);

                my_lbl_sw_assign = new Label[] { DeviceAssign_lbl1, DeviceAssign_lbl2, DeviceAssign_lbl3, DeviceAssign_lbl4, DeviceAssign_lbl5, DeviceAssign_lbl6, DeviceAssign_lbl7, DeviceAssign_lbl8, DeviceAssign_lbl9, DeviceAssign_lbl10, DeviceAssign_lbl11, DeviceAssign_lbl12, DeviceAssign_lbl13, DeviceAssign_lbl14, DeviceAssign_lbl15 };
                my_lbl_sw_device_type = new Label[] { devicetype_lbl1, devicetype_lbl2, devicetype_lbl3, devicetype_lbl4, devicetype_lbl5, devicetype_lbl6, devicetype_lbl7, devicetype_lbl8, devicetype_lbl9, devicetype_lbl10, devicetype_lbl11, devicetype_lbl12, devicetype_lbl13, devicetype_lbl14, devicetype_lbl15 };
                my_pic_sw_status = new PictureBox[] { ButtonPressIcon1, ButtonPressIcon2, ButtonPressIcon3, ButtonPressIcon4, ButtonPressIcon5, ButtonPressIcon6, ButtonPressIcon7, ButtonPressIcon8, ButtonPressIcon9, ButtonPressIcon10, ButtonPressIcon11, ButtonPressIcon12, ButtonPressIcon13, ButtonPressIcon14, ButtonPressIcon15 };
                my_pin_no_pic_a = new PictureBox[] { Pin01A_pb, Pin02A_pb, Pin03A_pb, Pin04A_pb, Pin05A_pb, Pin06A_pb, Pin07A_pb, Pin08A_pb, Pin09A_pb, Pin10A_pb, Pin11A_pb, Pin12A_pb, Pin13A_pb, Pin14A_pb, Pin15A_pb };
                my_pin_no_pic_b = new PictureBox[] { Pin01B_pb, Pin02B_pb, Pin03B_pb, Pin04B_pb, Pin05B_pb, Pin06B_pb, Pin07B_pb, Pin08B_pb, Pin09B_pb, Pin10B_pb, Pin11B_pb, Pin12B_pb, Pin13B_pb, Pin14B_pb, Pin15B_pb };

                my_lbl_an_status = new Label[] { lbl_analog1_status, lbl_analog2_status, lbl_analog3_status, lbl_analog4_status, lbl_analog5_status, lbl_analog6_status, lbl_analog7_status, lbl_analog8_status };
                my_lbl_an_assign = new Label[] { lbl_analog1_assign, lbl_analog2_assign, lbl_analog3_assign, lbl_analog4_assign, lbl_analog5_assign, lbl_analog6_assign, lbl_analog7_assign, lbl_analog8_assign };
                my_an_pin_no_pic_a = new PictureBox[] { PinAN01A_pb, PinAN02A_pb, PinAN03A_pb, PinAN04A_pb, PinAN05A_pb, PinAN06A_pb, PinAN07A_pb, PinAN08A_pb };
                my_an_pin_no_pic_b = new PictureBox[] { PinAN01B_pb, PinAN02B_pb, PinAN03B_pb, PinAN04B_pb, PinAN05B_pb, PinAN06B_pb, PinAN07B_pb, PinAN08B_pb };

                my_chkbx_keyboard_modifier = new CheckBox[] { Ctrl_cbox, Shift_cbox, Alt_cbox, Win_cbox };
                my_chkbx_joystick_lever = new CheckBox[] { LeverXP_cbox, LeverXM_cbox, LeverYP_cbox, LeverYM_cbox, LeverZP_cbox, LeverZM_cbox, LeverRXP_cbox, LeverRXM_cbox, LeverRYP_cbox, LeverRYM_cbox, LeverRZP_cbox, LeverRZM_cbox, LeverSliderP_cbox, LeverSliderM_cbox };
                my_chkbx_joystick_hatsw = new CheckBox[] { hatsw_up_cbox, hatsw_right_cbox, hatsw_down_cbox, hatsw_left_cbox };
                my_chkbx_joystick_button = new CheckBox[] { Button1_cbox, Button2_cbox, Button3_cbox, Button4_cbox, Button5_cbox, Button6_cbox, Button7_cbox, Button8_cbox, Button9_cbox, Button10_cbox, Button11_cbox, Button12_cbox, Button13_cbox, Button14_cbox, Button15_cbox };

                // 初期値設定

                // チャート設定
                // 1.Seriesの追加
                chart1.Series.Clear();
                chart1.Series.Add("CH A Level");
                //chart1.Series[0].Color = Color.Orange;
                //chart1.Series[0].Color = Color.Blue;
                chart1.Series[0].Color = Color.Red;
                chart1.Series[0].BorderWidth = 3;
                chart1.Series[0].IsVisibleInLegend = false;
                chart1.Series[0].IsValueShownAsLabel = false;
                // 2.グラフのタイプの設定
                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                //軸ラベルの設定
                chart1.ChartAreas[0].AxisX.Title = "入力電圧[V]";
                chart1.ChartAreas[0].AxisY.Title = "出力値";

                //X軸最小値、最大値、目盛間隔の設定
                chart1.ChartAreas[0].AxisX.Minimum = Constants.CHART_X_MIN;
                chart1.ChartAreas[0].AxisX.Maximum = Constants.CHART_X_MAX;
                chart1.ChartAreas[0].AxisX.Interval = Constants.CHART_X_INTERVAL;
                //Y軸最小値、最大値、目盛間隔の設定
                chart1.ChartAreas[0].AxisY.Minimum = Constants.CHART_Y_MIN;
                chart1.ChartAreas[0].AxisY.Maximum = Constants.CHART_Y_MAX;
                chart1.ChartAreas[0].AxisY.Interval = Constants.CHART_Y_INTERVAL;
                // ダミーデータ
                //chart1.Series[0].Points.AddXY(0, 0);
                //chart1.Series[0].Points.AddXY(0.5, 0);
                //chart1.Series[0].Points.AddXY(1.55, 128);
                //chart1.Series[0].Points.AddXY(1.65, 128);
                //chart1.Series[0].Points.AddXY(1.75, 128);
                //chart1.Series[0].Points.AddXY(2.8, 255);
                //chart1.Series[0].Points.AddXY(3.3, 255);


                MouseMove_UD.Minimum = Constants.SENSITIVITY_MIN;
                MouseMove_UD.Maximum = Constants.SENSITIVITY_MAX;
                lbl_sw_mouse_title1.Text = Constants.SW_MOUSE_LABEL1;
                lbl_sw_mouse_title2.Text = Constants.SW_MOUSE_LABEL2;

                // 初期値設定
                for (int fi = 0; fi < Constants.DIGITAL_INPUT_NUM; fi++ )
                {
                    cmbbx_digital_pin.Items.Add(string.Format("D{0} PIN", fi+1));
                }
                for (int fi = 0; fi < Constants.SW_SET_DEVICE_TYPE_NUM; fi++)
                {
                    cmbbx_digital_device_type.Items.Add(sw_device_type_list[fi]);
                }
                for (int fi = 0; fi < sw_mouse_set_type_list.Length; fi++)
                {
                    cmbbx_digital_assign.Items.Add(sw_mouse_set_type_list[fi]);
                }
                cmbbx_digital_pin.SelectedIndex = 0;

                for (int fi = 0; fi < my_chkbx_keyboard_modifier.Length; fi++ )
                {
                    my_chkbx_keyboard_modifier[fi].Text = keyboard_modifier_name_4type[fi];
                }
                for (int fi = 0; fi < my_chkbx_joystick_lever.Length; fi++)
                {
                    my_chkbx_joystick_lever[fi].Text = sw_joystick_set_type_lever_list[fi];
                }
                for (int fi = 0; fi < my_chkbx_joystick_hatsw.Length; fi++)
                {
                    my_chkbx_joystick_hatsw[fi].Text = sw_joystick_set_type_hatsw_list[fi];
                }
                for (int fi = 0; fi < my_chkbx_joystick_button.Length; fi++)
                {
                    my_chkbx_joystick_button[fi].Text = sw_joystick_set_type_button_list[fi];
                }


                for (int fi = 0; fi < Constants.ANALOG_INPUT_NUM; fi++)
                {
                    cmbbx_analog_pin.Items.Add(string.Format("A{0} PIN", fi + 1));
                }
                for (int fi = 0; fi < analog_set_type_list.Length; fi++)
                {
                    cmbbx_analog_set_type.Items.Add(analog_set_type_list[fi]);
                }
                cmbbx_analog_pin.SelectedIndex = 0;

                // 設定 リスト表示
                string[] item1 = { "ID", "ID", "", "" };
                for (int fi = 0; fi < Constants.AN_SETTING_NUM; fi++)
                {
                    item1[0] = string.Format("A{0}", fi + 1);
                    item1[1] = string.Format("A{0}", fi + 1);
                    listView1.Items.Add(new ListViewItem(item1));
                }
                for (int fi = 0; fi < Constants.SW_SETTING_NUM; fi++)
                {
                    item1[0] = string.Format("D{0}", fi + 1);
                    item1[1] = string.Format("D{0}", fi + 1);
                    listView1.Items.Add(new ListViewItem(item1));
                }



                //-------------------------------------------------------------------------------------------------------------------------------------------------------------------
                //-------------------------------------------------------BEGIN CUT AND PASTE BLOCK-----------------------------------------------------------------------------------
                //Additional constructor code

                //Initialize tool tips, to provide pop up help when the mouse cursor is moved over objects on the form.
                //ToggleLEDToolTip.SetToolTip(this.Changevalue_btn, "Sends a packet of data to the USB device.");

                //Register for WM_DEVICECHANGE notifications.  This code uses these messages to detect plug and play connection/disconnection events for USB devices
                DEV_BROADCAST_DEVICEINTERFACE DeviceBroadcastHeader = new DEV_BROADCAST_DEVICEINTERFACE();
                DeviceBroadcastHeader.dbcc_devicetype = DBT_DEVTYP_DEVICEINTERFACE;
                DeviceBroadcastHeader.dbcc_size = (uint)Marshal.SizeOf(DeviceBroadcastHeader);
                DeviceBroadcastHeader.dbcc_reserved = 0;	//Reserved says not to use...
                DeviceBroadcastHeader.dbcc_classguid = InterfaceClassGuid;

                //Need to get the address of the DeviceBroadcastHeader to call RegisterDeviceNotification(), but
                //can't use "&DeviceBroadcastHeader".  Instead, using a roundabout means to get the address by 
                //making a duplicate copy using Marshal.StructureToPtr().
                IntPtr pDeviceBroadcastHeader = IntPtr.Zero;  //Make a pointer.
                pDeviceBroadcastHeader = Marshal.AllocHGlobal(Marshal.SizeOf(DeviceBroadcastHeader)); //allocate memory for a new DEV_BROADCAST_DEVICEINTERFACE structure, and return the address 
                Marshal.StructureToPtr(DeviceBroadcastHeader, pDeviceBroadcastHeader, false);  //Copies the DeviceBroadcastHeader structure into the memory already allocated at DeviceBroadcastHeaderWithPointer
                RegisterDeviceNotification(this.Handle, pDeviceBroadcastHeader, DEVICE_NOTIFY_WINDOW_HANDLE);


                //Now make an initial attempt to find the USB device, if it was already connected to the PC and enumerated prior to launching the application.
                //If it is connected and present, we should open read and write handles to the device so we can communicate with it later.
                //If it was not connected, we will have to wait until the user plugs the device in, and the WM_DEVICECHANGE callback function can process
                //the message and again search for the device.
                if (CheckIfPresentAndGetUSBDevicePath())	//Check and make sure at least one device with matching VID/PID is attached
                {
                    uint ErrorStatusWrite;
                    uint ErrorStatusRead;


                    //We now have the proper device path, and we can finally open read and write handles to the device.
                    WriteHandleToUSBDevice = CreateFile(DevicePath, GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);
                    ErrorStatusWrite = (uint)Marshal.GetLastWin32Error();
                    ReadHandleToUSBDevice = CreateFile(DevicePath, GENERIC_READ, FILE_SHARE_READ | FILE_SHARE_WRITE, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);
                    ErrorStatusRead = (uint)Marshal.GetLastWin32Error();

                    if ((ErrorStatusWrite == ERROR_SUCCESS) && (ErrorStatusRead == ERROR_SUCCESS))
                    {
                        AttachedState = true;		//Let the rest of the PC application know the USB device is connected, and it is safe to read/write to it
                        AttachedButBroken = false;
                        StatusBox_lbl.Text = "デバイス検出済";
                    }
                    else //for some reason the device was physically plugged in, but one or both of the read/write handles didn't open successfully...
                    {
                        AttachedState = false;		//Let the rest of this application known not to read/write to the device.
                        AttachedButBroken = true;	//Flag so that next time a WM_DEVICECHANGE message occurs, can retry to re-open read/write pipes
                        if (ErrorStatusWrite == ERROR_SUCCESS)
                            WriteHandleToUSBDevice.Close();
                        if (ErrorStatusRead == ERROR_SUCCESS)
                            ReadHandleToUSBDevice.Close();
                    }
                }
                else	//Device must not be connected (or not programmed with correct firmware)
                {
                    AttachedState = false;
                    AttachedButBroken = false;
                }

                if (AttachedState == true)
                {
                    StatusBox_lbl.Text = "デバイス検出済";
                }
                else
                {
                    StatusBox_lbl.Text = "デバイス未検出";
                }

                ReadWriteThread.RunWorkerAsync();	//Recommend performing USB read/write operations in a separate thread.  Otherwise,
                //the Read/Write operations are effectively blocking functions and can lock up the
                //user interface if the I/O operations take a long time to complete.

            }
            catch
            {
            }
            //-------------------------------------------------------END CUT AND PASTE BLOCK-------------------------------------------------------------------------------------
            //-------------------------------------------------------------------------------------------------------------------------------------------------------------------
        }


        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------BEGIN CUT AND PASTE BLOCK-----------------------------------------------------------------------------------

        //FUNCTION:	CheckIfPresentAndGetUSBDevicePath()
        //PURPOSE:	Check if a USB device is currently plugged in with a matching VID and PID
        //INPUT:	Uses globally declared String DevicePath, globally declared GUID, and the MY_DEVICE_ID constant.
        //OUTPUT:	Returns BOOL.  TRUE when device with matching VID/PID found.  FALSE if device with VID/PID could not be found.
        //			When returns TRUE, the globally accessable "DetailedInterfaceDataStructure" will contain the device path
        //			to the USB device with the matching VID/PID.

        bool CheckIfPresentAndGetUSBDevicePath()
        {
		    /* 
		    Before we can "connect" our application to our USB embedded device, we must first find the device.
		    A USB bus can have many devices simultaneously connected, so somehow we have to find our device only.
		    This is done with the Vendor ID (VID) and Product ID (PID).  Each USB product line should have
		    a unique combination of VID and PID.  

		    Microsoft has created a number of functions which are useful for finding plug and play devices.  Documentation
		    for each function used can be found in the MSDN library.  We will be using the following functions (unmanaged C functions):

		    SetupDiGetClassDevs()					//provided by setupapi.dll, which comes with Windows
		    SetupDiEnumDeviceInterfaces()			//provided by setupapi.dll, which comes with Windows
		    GetLastError()							//provided by kernel32.dll, which comes with Windows
		    SetupDiDestroyDeviceInfoList()			//provided by setupapi.dll, which comes with Windows
		    SetupDiGetDeviceInterfaceDetail()		//provided by setupapi.dll, which comes with Windows
		    SetupDiGetDeviceRegistryProperty()		//provided by setupapi.dll, which comes with Windows
		    CreateFile()							//provided by kernel32.dll, which comes with Windows

            In order to call these unmanaged functions, the Marshal class is very useful.
             
		    We will also be using the following unusual data types and structures.  Documentation can also be found in
		    the MSDN library:

		    PSP_DEVICE_INTERFACE_DATA
		    PSP_DEVICE_INTERFACE_DETAIL_DATA
		    SP_DEVINFO_DATA
		    HDEVINFO
		    HANDLE
		    GUID

		    The ultimate objective of the following code is to get the device path, which will be used elsewhere for getting
		    read and write handles to the USB device.  Once the read/write handles are opened, only then can this
		    PC application begin reading/writing to the USB device using the WriteFile() and ReadFile() functions.

		    Getting the device path is a multi-step round about process, which requires calling several of the
		    SetupDixxx() functions provided by setupapi.dll.
		    */

            try
            {
		        IntPtr DeviceInfoTable = IntPtr.Zero;
		        SP_DEVICE_INTERFACE_DATA InterfaceDataStructure = new SP_DEVICE_INTERFACE_DATA();
                SP_DEVICE_INTERFACE_DETAIL_DATA DetailedInterfaceDataStructure = new SP_DEVICE_INTERFACE_DETAIL_DATA();
                SP_DEVINFO_DATA DevInfoData = new SP_DEVINFO_DATA();

		        uint InterfaceIndex = 0;
		        uint dwRegType = 0;
		        uint dwRegSize = 0;
                uint dwRegSize2 = 0;
		        uint StructureSize = 0;
		        IntPtr PropertyValueBuffer = IntPtr.Zero;
		        bool MatchFound = false;
                bool MatchFound2 = false;
                uint ErrorStatus;
		        uint LoopCounter = 0;

                //Use the formatting: "Vid_xxxx&Pid_xxxx" where xxxx is a 16-bit hexadecimal number.
                //Make sure the value appearing in the parathesis matches the USB device descriptor
                //of the device that this aplication is intending to find.
                String DeviceIDToFind = "Vid_22ea&Pid_0060";
                String DeviceIDToFind2 = "Mi_03";


		        //First populate a list of plugged in devices (by specifying "DIGCF_PRESENT"), which are of the specified class GUID. 
		        DeviceInfoTable = SetupDiGetClassDevs(ref InterfaceClassGuid, IntPtr.Zero, IntPtr.Zero, DIGCF_PRESENT | DIGCF_DEVICEINTERFACE);

                if(DeviceInfoTable != IntPtr.Zero)
                {
		            //Now look through the list we just populated.  We are trying to see if any of them match our device. 
		            while(true)
		            {
                        InterfaceDataStructure.cbSize = (uint)Marshal.SizeOf(InterfaceDataStructure);
			            if(SetupDiEnumDeviceInterfaces(DeviceInfoTable, IntPtr.Zero, ref InterfaceClassGuid, InterfaceIndex, ref InterfaceDataStructure))
			            {
                            ErrorStatus = (uint)Marshal.GetLastWin32Error();
                            if (ErrorStatus == ERROR_NO_MORE_ITEMS)	//Did we reach the end of the list of matching devices in the DeviceInfoTable?
				            {	//Cound not find the device.  Must not have been attached.
					            SetupDiDestroyDeviceInfoList(DeviceInfoTable);	//Clean up the old structure we no longer need.
					            return false;		
				            }
			            }
			            else	//Else some other kind of unknown error ocurred...
			            {
                            ErrorStatus = (uint)Marshal.GetLastWin32Error();
				            SetupDiDestroyDeviceInfoList(DeviceInfoTable);	//Clean up the old structure we no longer need.
				            return false;	
			            }

			            //Now retrieve the hardware ID from the registry.  The hardware ID contains the VID and PID, which we will then 
			            //check to see if it is the correct device or not.

			            //Initialize an appropriate SP_DEVINFO_DATA structure.  We need this structure for SetupDiGetDeviceRegistryProperty().
                        DevInfoData.cbSize = (uint)Marshal.SizeOf(DevInfoData);
			            SetupDiEnumDeviceInfo(DeviceInfoTable, InterfaceIndex, ref DevInfoData);

			            //First query for the size of the hardware ID, so we can know how big a buffer to allocate for the data.
			            SetupDiGetDeviceRegistryProperty(DeviceInfoTable, ref DevInfoData, SPDRP_HARDWAREID, ref dwRegType, IntPtr.Zero, 0, ref dwRegSize);

			            //Allocate a buffer for the hardware ID.
                        //Should normally work, but could throw exception "OutOfMemoryException" if not enough resources available.
                        PropertyValueBuffer = Marshal.AllocHGlobal((int)dwRegSize);

			            //Retrieve the hardware IDs for the current device we are looking at.  PropertyValueBuffer gets filled with a 
			            //REG_MULTI_SZ (array of null terminated strings).  To find a device, we only care about the very first string in the
			            //buffer, which will be the "device ID".  The device ID is a string which contains the VID and PID, in the example 
			            //format "Vid_04d8&Pid_003f".
                        SetupDiGetDeviceRegistryProperty(DeviceInfoTable, ref DevInfoData, SPDRP_HARDWAREID, ref dwRegType, PropertyValueBuffer, dwRegSize, ref dwRegSize2);

			            //Now check if the first string in the hardware ID matches the device ID of the USB device we are trying to find.
			            String DeviceIDFromRegistry = Marshal.PtrToStringUni(PropertyValueBuffer); //Make a new string, fill it with the contents from the PropertyValueBuffer

			            Marshal.FreeHGlobal(PropertyValueBuffer);		//No longer need the PropertyValueBuffer, free the memory to prevent potential memory leaks

			            //Convert both strings to lower case.  This makes the code more robust/portable accross OS Versions
			            DeviceIDFromRegistry = DeviceIDFromRegistry.ToLowerInvariant();	
			            DeviceIDToFind = DeviceIDToFind.ToLowerInvariant();
                        DeviceIDToFind2 = DeviceIDToFind2.ToLowerInvariant();
                        //Now check if the hardware ID we are looking at contains the correct VID/PID
			            MatchFound = DeviceIDFromRegistry.Contains(DeviceIDToFind);
                        MatchFound2 = DeviceIDFromRegistry.Contains(DeviceIDToFind2);
                        if (MatchFound == true && MatchFound2 == true)
			            {
                            //Device must have been found.  In order to open I/O file handle(s), we will need the actual device path first.
				            //We can get the path by calling SetupDiGetDeviceInterfaceDetail(), however, we have to call this function twice:  The first
				            //time to get the size of the required structure/buffer to hold the detailed interface data, then a second time to actually 
				            //get the structure (after we have allocated enough memory for the structure.)
                            DetailedInterfaceDataStructure.cbSize = (uint)Marshal.SizeOf(DetailedInterfaceDataStructure);
				            //First call populates "StructureSize" with the correct value
				            SetupDiGetDeviceInterfaceDetail(DeviceInfoTable, ref InterfaceDataStructure, IntPtr.Zero, 0, ref StructureSize, IntPtr.Zero);
                            //Need to call SetupDiGetDeviceInterfaceDetail() again, this time specifying a pointer to a SP_DEVICE_INTERFACE_DETAIL_DATA buffer with the correct size of RAM allocated.
                            //First need to allocate the unmanaged buffer and get a pointer to it.
                            IntPtr pUnmanagedDetailedInterfaceDataStructure = IntPtr.Zero;  //Declare a pointer.
                            pUnmanagedDetailedInterfaceDataStructure = Marshal.AllocHGlobal((int)StructureSize);    //Reserve some unmanaged memory for the structure.
                            DetailedInterfaceDataStructure.cbSize = 6; //Initialize the cbSize parameter (4 bytes for DWORD + 2 bytes for unicode null terminator)
                            Marshal.StructureToPtr(DetailedInterfaceDataStructure, pUnmanagedDetailedInterfaceDataStructure, false); //Copy managed structure contents into the unmanaged memory buffer.

                            //Now call SetupDiGetDeviceInterfaceDetail() a second time to receive the device path in the structure at pUnmanagedDetailedInterfaceDataStructure.
                            if (SetupDiGetDeviceInterfaceDetail(DeviceInfoTable, ref InterfaceDataStructure, pUnmanagedDetailedInterfaceDataStructure, StructureSize, IntPtr.Zero, IntPtr.Zero))
                            {
                                //Need to extract the path information from the unmanaged "structure".  The path starts at (pUnmanagedDetailedInterfaceDataStructure + sizeof(DWORD)).
                                IntPtr pToDevicePath = new IntPtr((uint)pUnmanagedDetailedInterfaceDataStructure.ToInt32() + 4);  //Add 4 to the pointer (to get the pointer to point to the path, instead of the DWORD cbSize parameter)
                                DevicePath = Marshal.PtrToStringUni(pToDevicePath); //Now copy the path information into the globally defined DevicePath String.
                                
                                //We now have the proper device path, and we can finally use the path to open I/O handle(s) to the device.
                                SetupDiDestroyDeviceInfoList(DeviceInfoTable);	//Clean up the old structure we no longer need.
                                Marshal.FreeHGlobal(pUnmanagedDetailedInterfaceDataStructure);  //No longer need this unmanaged SP_DEVICE_INTERFACE_DETAIL_DATA buffer.  We already extracted the path information.
                                return true;    //Returning the device path in the global DevicePath String
                            }
                            else //Some unknown failure occurred
                            {
                                uint ErrorCode = (uint)Marshal.GetLastWin32Error();
                                SetupDiDestroyDeviceInfoList(DeviceInfoTable);	//Clean up the old structure.
                                Marshal.FreeHGlobal(pUnmanagedDetailedInterfaceDataStructure);  //No longer need this unmanaged SP_DEVICE_INTERFACE_DETAIL_DATA buffer.  We already extracted the path information.
                                return false;    
                            }
                        }

			            InterfaceIndex++;	
			            //Keep looping until we either find a device with matching VID and PID, or until we run out of devices to check.
			            //However, just in case some unexpected error occurs, keep track of the number of loops executed.
			            //If the number of loops exceeds a very large number, exit anyway, to prevent inadvertent infinite looping.
			            LoopCounter++;
			            if(LoopCounter == 10000000)	//Surely there aren't more than 10 million devices attached to any forseeable PC...
			            {
				            return false;
			            }
		            }//end of while(true)
                }
                return false;
            }//end of try
            catch
            {
                //Something went wrong if PC gets here.  Maybe a Marshal.AllocHGlobal() failed due to insufficient resources or something.
			    return false;	
            }
        }
        //-------------------------------------------------------END CUT AND PASTE BLOCK-------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------


        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------BEGIN CUT AND PASTE BLOCK-----------------------------------------------------------------------------------
        //This is a callback function that gets called when a Windows message is received by the form.
        //We will receive various different types of messages, but the ones we really want to use are the WM_DEVICECHANGE messages.
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_DEVICECHANGE)
            {
                if (((int)m.WParam == DBT_DEVICEARRIVAL) || ((int)m.WParam == DBT_DEVICEREMOVEPENDING) || ((int)m.WParam == DBT_DEVICEREMOVECOMPLETE) || ((int)m.WParam == DBT_CONFIGCHANGED))
                {
                    //WM_DEVICECHANGE messages by themselves are quite generic, and can be caused by a number of different
                    //sources, not just your USB hardware device.  Therefore, must check to find out if any changes relavant
                    //to your device (with known VID/PID) took place before doing any kind of opening or closing of handles/endpoints.
                    //(the message could have been totally unrelated to your application/USB device)

                    if (CheckIfPresentAndGetUSBDevicePath())	//Check and make sure at least one device with matching VID/PID is attached
                    {
                        //If executes to here, this means the device is currently attached and was found.
                        //This code needs to decide however what to do, based on whether or not the device was previously known to be
                        //attached or not.
                        if ((AttachedState == false) || (AttachedButBroken == true))	//Check the previous attachment state
                        {
                            uint ErrorStatusWrite;
                            uint ErrorStatusRead;

                            //We obtained the proper device path (from CheckIfPresentAndGetUSBDevicePath() function call), and it
                            //is now possible to open read and write handles to the device.
                            WriteHandleToUSBDevice = CreateFile(DevicePath, GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);
                            ErrorStatusWrite = (uint)Marshal.GetLastWin32Error();
                            ReadHandleToUSBDevice = CreateFile(DevicePath, GENERIC_READ, FILE_SHARE_READ | FILE_SHARE_WRITE, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);
                            ErrorStatusRead = (uint)Marshal.GetLastWin32Error();

                            if ((ErrorStatusWrite == ERROR_SUCCESS) && (ErrorStatusRead == ERROR_SUCCESS))
                            {
                                AttachedState = true;		//Let the rest of the PC application know the USB device is connected, and it is safe to read/write to it
                                AttachedButBroken = false;
                                StatusBox_lbl.Text = "デバイス検出済";
                            }
                            else //for some reason the device was physically plugged in, but one or both of the read/write handles didn't open successfully...
                            {
                                AttachedState = false;		//Let the rest of this application known not to read/write to the device.
                                AttachedButBroken = true;	//Flag so that next time a WM_DEVICECHANGE message occurs, can retry to re-open read/write pipes
                                if (ErrorStatusWrite == ERROR_SUCCESS)
                                    WriteHandleToUSBDevice.Close();
                                if (ErrorStatusRead == ERROR_SUCCESS)
                                    ReadHandleToUSBDevice.Close();
                            }
                        }
                        //else we did find the device, but AttachedState was already true.  In this case, don't do anything to the read/write handles,
                        //since the WM_DEVICECHANGE message presumably wasn't caused by our USB device.  
                    }
                    else	//Device must not be connected (or not programmed with correct firmware)
                    {
                        if (AttachedState == true)		//If it is currently set to true, that means the device was just now disconnected
                        {
                            AttachedState = false;
                            WriteHandleToUSBDevice.Close();
                            ReadHandleToUSBDevice.Close();
                        }
                        AttachedState = false;
                        AttachedButBroken = false;
                    }
                }
            } //end of: if(m.Msg == WM_DEVICECHANGE)

            base.WndProc(ref m);
        } //end of: WndProc() function
        //-------------------------------------------------------END CUT AND PASTE BLOCK-------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private void btn_digital_set_Click(object sender, EventArgs e)
        {
            try
            {
                // 設定値チェック
                bool b_ret = my_digital_setting_check();
                if(b_ret == false)
                {
                    if (MessageBox.Show(Constants.SETUP_WRITE_CONFIRM_MSG, Constants.APPLICATION_NAME, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {

                        // 設定変更有無チェック
                        byte[] digital_data_now = new byte[Constants.SW_DEVICE_DATA_LEN];
                        my_digital_setting_get_by_disp(digital_data_now);
                        bool b_ret1 = my_digital_data_change_check(my_sw_datas.sw_datas[0].sw_data, digital_data_now);
                        if (b_ret1 == true)
                        {
                            int write_address = EepromControl.E2P_ADR_SW_INFO + (EepromControl.E2P_SW_INFO_SW_DATA_SIZE * sw_selected);
                            for (int fi = 0; fi < Constants.SW_DEVICE_DATA_LEN; fi++)
                            {
                                my_sw_datas.sw_datas[sw_selected].sw_data[fi] = digital_data_now[fi];
                                my_eeprom_read_write_buffer.set_write_data(write_address + fi, digital_data_now[fi]);
                            }

                            set_sw_info_sw_no = (byte)(sw_selected & 0xFF);
                            set_sw_info_flag = true;
                            // 書き換え要求セット
                            my_eeprom_read_write_buffer.set_write_req();

                            // 画面更新
                            my_Set_Display();
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void btn_analog_set_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(Constants.SETUP_WRITE_CONFIRM_MSG, Constants.APPLICATION_NAME, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {

                    // 設定変更有無チェック
                    byte[] analog_data_now = new byte[Constants.AN_DEVICE_DATA_LEN];
                    my_analog_setting_get_by_disp(my_an_datas.an_datas[0].an_data, analog_data_now);
                    bool b_ret1 = my_analog_data_change_check(my_an_datas.an_datas[0].an_data, analog_data_now);
                    if (b_ret1 == true)
                    {
                        int write_address = EepromControl.E2P_ADR_AN_INFO + (EepromControl.E2P_AN_INFO_AN_DATA_SIZE * an_selected);
                        for (int fi = 0; fi < Constants.AN_DEVICE_DATA_LEN; fi++)
                        {
                            my_an_datas.an_datas[an_selected].an_data[fi] = analog_data_now[fi];
                            my_eeprom_read_write_buffer.set_write_data(write_address + fi, analog_data_now[fi]);
                        }

                        set_an_info_an_no = (byte)(an_selected & 0xFF);
                        set_an_info_flag = true;
                        // 書き換え要求セット
                        my_eeprom_read_write_buffer.set_write_req();

                        // 画面更新
                        my_Set_Display();
                    }
                }
            }
            catch
            {
            }
        }

        private void ReadWriteThread_DoWork(object sender, DoWorkEventArgs e)
        {
            //-------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //-------------------------------------------------------BEGIN CUT AND PASTE BLOCK-----------------------------------------------------------------------------------

            /*This thread does the actual USB read/write operations (but only when AttachedState == true) to the USB device.
            It is generally preferrable to write applications so that read and write operations are handled in a separate
            thread from the main form.  This makes it so that the main form can remain responsive, even if the I/O operations
            take a very long time to complete.

            Since this is a separate thread, this code below executes independently from the rest of the
            code in this application.  All this thread does is read and write to the USB device.  It does not update
            the form directly with the new information it obtains (such as the ANxx/POT Voltage or pushbutton state).
            The information that this thread obtains is stored in atomic global variables.
            Form updates are handled by the FormUpdateTimer Tick event handler function.

            This application sends packets to the endpoint buffer on the USB device by using the "WriteFile()" function.
            This application receives packets from the endpoint buffer on the USB device by using the "ReadFile()" function.
            Both of these functions are documented in the MSDN library.  Calling ReadFile() is a not perfectly straight
            foward in C# environment, since one of the input parameters is a pointer to a buffer that gets filled by ReadFile().
            The ReadFile() function is therefore called through a wrapper function ReadFileManagedBuffer().

            All ReadFile() and WriteFile() operations in this example project are synchronous.  They are blocking function
            calls and only return when they are complete, or if they fail because of some event, such as the user unplugging
            the device.  It is possible to call these functions with "overlapped" structures, and use them as non-blocking
            asynchronous I/O function calls.  

            Note:  This code may perform differently on some machines when the USB device is plugged into the host through a
            USB 2.0 hub, as opposed to a direct connection to a root port on the PC.  In some cases the data rate may be slower
            when the device is connected through a USB 2.0 hub.  This performance difference is believed to be caused by
            the issue described in Microsoft knowledge base article 940021:
            http://support.microsoft.com/kb/940021/en-us 

            Higher effective bandwidth (up to the maximum offered by interrupt endpoints), both when connected
            directly and through a USB 2.0 hub, can generally be achieved by queuing up multiple pending read and/or
            write requests simultaneously.  This can be done when using	asynchronous I/O operations (calling ReadFile() and
            WriteFile()	with overlapped structures).  The Microchip	HID USB Bootloader application uses asynchronous I/O
            for some USB operations and the source code can be used	as an example.*/


            Byte[] OUTBuffer = new byte[65];	//Allocate a memory buffer equal to the OUT endpoint size + 1
		    Byte[] INBuffer = new byte[65];		//Allocate a memory buffer equal to the IN endpoint size + 1
		    uint BytesWritten = 0;
            uint BytesRead = 0;
            byte byte_temp;
            ArrayList al_temp1 = new ArrayList();
            uint l_address;
            uint l_size;
            uint l_comp_size;
            byte b_size;
            bool b_Error_Flag;
            bool b_usb_write_ret = false;

		    while(true)
		    {
                try
                {
                    if (AttachedState == true)	//Do not try to use the read/write handles unless the USB device is attached and ready
                    {
                        //Get ANxx/POT Voltage value from the microcontroller firmware.  Note: some demo boards may not have a pot
                        //on them.  In this case, the firmware may be configured to read an ANxx I/O pin voltage with the ADC
                        //instead.  If this is the case, apply a proper voltage to the pin.  See the firmware for exact implementation.

                        //VersionReadReq = false;
                        if (VersionReadReq == true)
                        {
                            VersionReadReq = false;

                            //Get the pushbutton state from the microcontroller firmware.
                            OUTBuffer[0] = 0;			//The first byte is the "Report ID" and does not get sent over the USB bus.  Always set = 0.
                            OUTBuffer[1] = 0x56;		//0x81 is the "Get Pushbutton State" command in the firmware

                            for (uint i = 2; i < 65; i++)	//This loop is not strictly necessary.  Simply initializes unused bytes to
                                OUTBuffer[i] = 0xFF;				//0xFF for lower EMI and power consumption when driving the USB cable.

                            //To get the pushbutton state, first, we send a packet with our "Get Pushbutton State" command in it.
                            if (WriteFile(WriteHandleToUSBDevice, OUTBuffer, 65, ref BytesWritten, IntPtr.Zero))	//Blocking function, unless an "overlapped" structure is used
                            {
                                //Now get the response packet from the firmware.
                                INBuffer[0] = 0;
                                {
                                    if (ReadFileManagedBuffer(ReadHandleToUSBDevice, INBuffer, 65, ref BytesRead, IntPtr.Zero))	//Blocking function, unless an "overlapped" structure is used
                                    {
                                        //INBuffer[0] is the report ID, which we don't care about.
                                        //INBuffer[1] is an echo back of the command (see microcontroller firmware).
                                        //INBuffer[2] contains the I/O port pin value for the pushbutton (see microcontroller firmware).  
                                        if (INBuffer[1] == 0x56)
                                        {
                                            for (uint i = 2; i < 65; i++)
                                            {
                                                version_buff[i - 2] = INBuffer[i];
                                            }
                                            VersionReadComp = true;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                AttachedState = false;
                            }
                        }

                        // SW 状態取得
                        OUTBuffer[0] = 0;			//The first byte is the "Report ID" and does not get sent over the USB bus.  Always set = 0.
                        OUTBuffer[1] = 0x21;		//0x22 is the "Get Pushbutton State" command in the firmware
                        
                        //To get the pushbutton state, first, we send a packet with our "Get Pushbutton State" command in it.
                        if (WriteFile(WriteHandleToUSBDevice, OUTBuffer, 65, ref BytesWritten, IntPtr.Zero))	//Blocking function, unless an "overlapped" structure is used
                        {
                            //Now get the response packet from the firmware.
                            INBuffer[0] = 0;
                            {
                                if (ReadFileManagedBuffer(ReadHandleToUSBDevice, INBuffer, 65, ref BytesRead, IntPtr.Zero))	//Blocking function, unless an "overlapped" structure is used
                                {
                                    //INBuffer[0] is the report ID, which we don't care about.
                                    //INBuffer[1] is an echo back of the command (see microcontroller firmware).
                                    //INBuffer[2] contains the I/O port pin value for the pushbutton (see microcontroller firmware).  
                                    if (INBuffer[1] == 0x21)
                                    {
                                        for (int fi = 0; fi < Constants.DIGITAL_INPUT_NUM; fi++)
                                        {
                                            sw_status[fi] = INBuffer[2 + fi];
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            AttachedState = false;
                        }

                        // AN 状態取得
                        OUTBuffer[0] = 0;			//The first byte is the "Report ID" and does not get sent over the USB bus.  Always set = 0.
                        OUTBuffer[1] = 0x22;		//0x22 is the "Get Pushbutton State" command in the firmware

                        //To get the pushbutton state, first, we send a packet with our "Get Pushbutton State" command in it.
                        if (WriteFile(WriteHandleToUSBDevice, OUTBuffer, 65, ref BytesWritten, IntPtr.Zero))	//Blocking function, unless an "overlapped" structure is used
                        {
                            //Now get the response packet from the firmware.
                            INBuffer[0] = 0;
                            {
                                if (ReadFileManagedBuffer(ReadHandleToUSBDevice, INBuffer, 65, ref BytesRead, IntPtr.Zero))	//Blocking function, unless an "overlapped" structure is used
                                {
                                    //INBuffer[0] is the report ID, which we don't care about.
                                    //INBuffer[1] is an echo back of the command (see microcontroller firmware).
                                    //INBuffer[2] contains the I/O port pin value for the pushbutton (see microcontroller firmware).  
                                    if (INBuffer[1] == 0x22)
                                    {
                                        for (int fi = 0; fi < Constants.ANALOG_INPUT_NUM; fi++)
                                        {
                                            an_status[fi] = INBuffer[2 + (fi * 2)];
                                            an_status[fi] = (an_status[fi] << 8) + INBuffer[2 + (fi * 2) + 1];
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            AttachedState = false;
                        }


                        // SW設定変更要求
                        if (set_sw_info_flag == true)
                        {
                            set_sw_info_flag = false;

                            OUTBuffer[0] = 0;			//The first byte is the "Report ID" and does not get sent over the USB bus.  Always set = 0.
                            OUTBuffer[1] = 0x32;		//0x22 is the "Get Pushbutton State" command in the firmware
                            OUTBuffer[2] = set_sw_info_sw_no;		//
                            for (int fi = 0; fi < EepromControl.E2P_SW_INFO_SW_DATA_SIZE; fi++)
                            {
                                OUTBuffer[3 + fi] = my_sw_datas.sw_datas[set_sw_info_sw_no].sw_data[fi];
                            }

                            //To get the pushbutton state, first, we send a packet with our "Get Pushbutton State" command in it.
                            if (WriteFile(WriteHandleToUSBDevice, OUTBuffer, 65, ref BytesWritten, IntPtr.Zero))	//Blocking function, unless an "overlapped" structure is used
                            {
                                //Now get the response packet from the firmware.
                                INBuffer[0] = 0;
                                {
                                    if (ReadFileManagedBuffer(ReadHandleToUSBDevice, INBuffer, 65, ref BytesRead, IntPtr.Zero))	//Blocking function, unless an "overlapped" structure is used
                                    {
                                        //INBuffer[0] is the report ID, which we don't care about.
                                        //INBuffer[1] is an echo back of the command (see microcontroller firmware).
                                        //INBuffer[2] contains the I/O port pin value for the pushbutton (see microcontroller firmware).  
                                        if (INBuffer[1] == 0x32)
                                        {
                                            //ANS
                                            if (INBuffer[2] != 0x00)
                                            {
                                                b_Error_Flag = true;
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                AttachedState = false;
                            }
                        }
                        // AN設定変更要求
                        if (set_an_info_flag == true)
                        {
                            set_an_info_flag = false;

                            OUTBuffer[0] = 0;			//The first byte is the "Report ID" and does not get sent over the USB bus.  Always set = 0.
                            OUTBuffer[1] = 0x34;		//0x22 is the "Get Pushbutton State" command in the firmware
                            OUTBuffer[2] = set_an_info_an_no;		//
                            for (int fi = 0; fi < EepromControl.E2P_AN_INFO_AN_DATA_SIZE; fi++)
                            {
                                OUTBuffer[3 + fi] = my_an_datas.an_datas[set_an_info_an_no].an_data[fi];
                            }

                            //To get the pushbutton state, first, we send a packet with our "Get Pushbutton State" command in it.
                            if (WriteFile(WriteHandleToUSBDevice, OUTBuffer, 65, ref BytesWritten, IntPtr.Zero))	//Blocking function, unless an "overlapped" structure is used
                            {
                                //Now get the response packet from the firmware.
                                INBuffer[0] = 0;
                                {
                                    if (ReadFileManagedBuffer(ReadHandleToUSBDevice, INBuffer, 65, ref BytesRead, IntPtr.Zero))	//Blocking function, unless an "overlapped" structure is used
                                    {
                                        //INBuffer[0] is the report ID, which we don't care about.
                                        //INBuffer[1] is an echo back of the command (see microcontroller firmware).
                                        //INBuffer[2] contains the I/O port pin value for the pushbutton (see microcontroller firmware).  
                                        if (INBuffer[1] == 0x34)
                                        {
                                            //ANS
                                            if (INBuffer[2] != 0x00)
                                            {
                                                b_Error_Flag = true;
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                AttachedState = false;
                            }

                            if (set_an_calibration_flag == true)
                            {
                                set_an_calibration_flag = false;
                                set_an_calibration_req = true;
                            }
                        }


                        // EEPROM 書き換え要求あり？
                        if (my_eeprom_read_write_buffer.write_req == true)
                        {
                            l_address = 0;
                            b_Error_Flag = false;

                            while (l_address < EepromControl.E2P_TOTAL_SIZE && b_Error_Flag == false)
                            {
                                l_size = 0;
                                if (my_eeprom_read_write_buffer.write_flag[l_address] == true)
                                {   // 書き換え要求ありデータ

                                    // 連続で書き込みデータあり？
                                    for (uint fi = l_address; fi < EepromControl.E2P_TOTAL_SIZE; fi++)
                                    {
                                        if (my_eeprom_read_write_buffer.write_flag[fi] == true)
                                        {
                                            l_size++;

                                            // 一定サイズごとに書き込む
                                            if (l_size >= EepromControl.E2P_USB_WRITE_DATA_SIZE)
                                            {
                                                break;
                                            }
                                        }
                                        else
                                        {   // 書き込み要求なしデータ
                                            break;
                                        }
                                    }

                                    // 書き込みデータあり
                                    if (l_size > 0)
                                    {
                                        OUTBuffer[0] = 0;			//The first byte is the "Report ID" and does not get sent over the USB bus.  Always set = 0.
                                        OUTBuffer[1] = 0x12;		//0x22 is the "Get Pushbutton State" command in the firmware
                                        OUTBuffer[2] = (byte)((l_address >> 8) & 0xFF);		//Address
                                        OUTBuffer[3] = (byte)(l_address & 0xFF);		    //

                                        //送信バイトデータを出力バッファにコピー
                                        for (uint fi = 0; fi < l_size; fi++)
                                        {
                                            OUTBuffer[5 + fi] = my_eeprom_read_write_buffer.write_buff[l_address + fi];
                                        }
                                        OUTBuffer[4] = (byte)(l_size & 0xFF);		        //Size

                                        //To get the pushbutton state, first, we send a packet with our "Get Pushbutton State" command in it.
                                        if (WriteFile(WriteHandleToUSBDevice, OUTBuffer, 65, ref BytesWritten, IntPtr.Zero))	//Blocking function, unless an "overlapped" structure is used
                                        {
                                            //Now get the response packet from the firmware.
                                            INBuffer[0] = 0;
                                            {
                                                if (ReadFileManagedBuffer(ReadHandleToUSBDevice, INBuffer, 65, ref BytesRead, IntPtr.Zero))	//Blocking function, unless an "overlapped" structure is used
                                                {
                                                    //INBuffer[0] is the report ID, which we don't care about.
                                                    //INBuffer[1] is an echo back of the command (see microcontroller firmware).
                                                    //INBuffer[2] contains the I/O port pin value for the pushbutton (see microcontroller firmware).  
                                                    if (INBuffer[1] == 0x12)
                                                    {
                                                        //ANS
                                                        if (INBuffer[2] != 0x00)
                                                        {
                                                            b_Error_Flag = true;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            AttachedState = false;
                                        }

                                        // 書き込みアドレスを進める
                                        l_address += l_size;
                                    }
                                    else
                                    {
                                        l_address++;
                                    }
                                }
                                else
                                {
                                    l_address++;
                                }
                            }

                            my_eeprom_read_write_buffer.write_data_clear();



                            // 再読込要求セット
                            byte_temp = fData.Get_Eeprom_Write_Status(EepromControl.E2P_WRITE_TYPE_SW_SETTING);
                            if (byte_temp == EepromControl.E2P_WRITE_STATUS_RQ)
                            {
                                fData.Set_Eeprom_Read_Status(EepromControl.E2P_WRITE_TYPE_SW_SETTING, EepromControl.E2P_WRITE_STATUS_NA);

                                fData.Set_Eeprom_Read_Status(EepromControl.E2P_READ_TYPE_SW_SETTING, EepromControl.E2P_READ_STATUS_RQ);
                                EepromReadFirstTime = true;
                            }
                            byte_temp = fData.Get_Eeprom_Write_Status(EepromControl.E2P_WRITE_TYPE_AN_SETTING);
                            if (byte_temp == EepromControl.E2P_WRITE_STATUS_RQ)
                            {
                                fData.Set_Eeprom_Read_Status(EepromControl.E2P_WRITE_TYPE_AN_SETTING, EepromControl.E2P_WRITE_STATUS_NA);

                                fData.Set_Eeprom_Read_Status(EepromControl.E2P_READ_TYPE_AN_SETTING, EepromControl.E2P_READ_STATUS_RQ);
                                EepromReadFirstTime = true;
                            }

                        }

                        // SW設定情報読み込み要求あり？
                        byte_temp = fData.Get_Eeprom_Read_Status(EepromControl.E2P_READ_TYPE_SW_SETTING);
                        if (byte_temp == EepromControl.E2P_READ_STATUS_RQ)
                        {
                            fData.Set_Eeprom_Read_Status(EepromControl.E2P_READ_TYPE_SW_SETTING, EepromControl.E2P_READ_STATUS_READING);

                            al_temp1.Clear();
                            l_address = EepromControl.E2P_ADR_SW_INFO;
                            l_comp_size = 0;
                            b_Error_Flag = false;

                            while (l_comp_size < EepromControl.E2P_SW_INFO_AREA_ALL_SIZE && b_Error_Flag == false)
                            {
                                l_size = EepromControl.E2P_SW_INFO_AREA_ALL_SIZE - l_comp_size;
                                if (l_size > EepromControl.E2P_USB_READ_DATA_SIZE)
                                {
                                    l_size = EepromControl.E2P_USB_READ_DATA_SIZE;
                                }
                                l_comp_size += l_size;

                                //Get the pushbutton state from the microcontroller firmware.
                                OUTBuffer[0] = 0;			//The first byte is the "Report ID" and does not get sent over the USB bus.  Always set = 0.
                                OUTBuffer[1] = 0x11;		//0x21 is the "Get Pushbutton State" command in the firmware
                                OUTBuffer[2] = (byte)((l_address >> 8) & 0xFF);    //Address
                                OUTBuffer[3] = (byte)(l_address & 0xFF);            //
                                b_size = (byte)(l_size & 0xFF);
                                OUTBuffer[4] = b_size;               //Size
                                for (uint i = 5; i < 65; i++)	//This loop is not strictly necessary.  Simply initializes unused bytes to
                                    OUTBuffer[i] = 0xFF;				//0xFF for lower EMI and power consumption when driving the USB cable.

                                //To get the pushbutton state, first, we send a packet with our "Get Pushbutton State" command in it.
                                if (WriteFile(WriteHandleToUSBDevice, OUTBuffer, 65, ref BytesWritten, IntPtr.Zero))	//Blocking function, unless an "overlapped" structure is used
                                {
                                    //Now get the response packet from the firmware.
                                    INBuffer[0] = 0;
                                    {
                                        if (ReadFileManagedBuffer(ReadHandleToUSBDevice, INBuffer, 65, ref BytesRead, IntPtr.Zero))	//Blocking function, unless an "overlapped" structure is used
                                        {
                                            //INBuffer[0] is the report ID, which we don't care about.
                                            //INBuffer[1] is an echo back of the command (see microcontroller firmware).
                                            //INBuffer[2] contains the I/O port pin value for the pushbutton (see microcontroller firmware).  
                                            if (INBuffer[1] == 0x11)
                                            {
                                                if (INBuffer[2] == b_size)
                                                {
                                                    // OK
                                                    for (int fi = 0; fi < INBuffer[2]; fi++)
                                                    {
                                                        al_temp1.Add(INBuffer[3 + fi]);
                                                    }
                                                }
                                                else
                                                {
                                                    // NG
                                                    b_Error_Flag = true;
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    AttachedState = false;
                                }

                                l_address += l_size;
                            }

                            // 読み込みOK
                            if (b_Error_Flag == false)
                            {
                                //読み込み情報セット
                                fData.Set_Eeprom_Read_SW_Info(ref my_sw_datas, al_temp1);

                                fData.Set_Eeprom_Read_Status(EepromControl.E2P_READ_TYPE_SW_SETTING, EepromControl.E2P_READ_STATUS_COMP);
                            }
                            else
                            {   // 読み込みNG
                                fData.Set_Eeprom_Read_Status(EepromControl.E2P_READ_TYPE_SW_SETTING, EepromControl.E2P_READ_STATUS_NA);
                            }

                            // バッファクリア
                            al_temp1.Clear();
                        }

                        // AN設定情報読み込み要求あり？
                        byte_temp = fData.Get_Eeprom_Read_Status(EepromControl.E2P_READ_TYPE_AN_SETTING);
                        if (byte_temp == EepromControl.E2P_READ_STATUS_RQ)
                        {
                            fData.Set_Eeprom_Read_Status(EepromControl.E2P_READ_TYPE_AN_SETTING, EepromControl.E2P_READ_STATUS_READING);

                            al_temp1.Clear();
                            l_address = EepromControl.E2P_ADR_AN_INFO;
                            l_comp_size = 0;
                            b_Error_Flag = false;

                            while (l_comp_size < EepromControl.E2P_AN_INFO_AREA_ALL_SIZE && b_Error_Flag == false)
                            {
                                l_size = EepromControl.E2P_AN_INFO_AREA_ALL_SIZE - l_comp_size;
                                if (l_size > EepromControl.E2P_USB_READ_DATA_SIZE)
                                {
                                    l_size = EepromControl.E2P_USB_READ_DATA_SIZE;
                                }
                                l_comp_size += l_size;

                                //Get the pushbutton state from the microcontroller firmware.
                                OUTBuffer[0] = 0;			//The first byte is the "Report ID" and does not get sent over the USB bus.  Always set = 0.
                                OUTBuffer[1] = 0x11;		//0x21 is the "Get Pushbutton State" command in the firmware
                                OUTBuffer[2] = (byte)((l_address >> 8) & 0xFF);    //Address
                                OUTBuffer[3] = (byte)(l_address & 0xFF);            //
                                b_size = (byte)(l_size & 0xFF);
                                OUTBuffer[4] = b_size;               //Size
                                for (uint i = 5; i < 65; i++)	//This loop is not strictly necessary.  Simply initializes unused bytes to
                                    OUTBuffer[i] = 0xFF;				//0xFF for lower EMI and power consumption when driving the USB cable.

                                //To get the pushbutton state, first, we send a packet with our "Get Pushbutton State" command in it.
                                if (WriteFile(WriteHandleToUSBDevice, OUTBuffer, 65, ref BytesWritten, IntPtr.Zero))	//Blocking function, unless an "overlapped" structure is used
                                {
                                    //Now get the response packet from the firmware.
                                    INBuffer[0] = 0;
                                    {
                                        if (ReadFileManagedBuffer(ReadHandleToUSBDevice, INBuffer, 65, ref BytesRead, IntPtr.Zero))	//Blocking function, unless an "overlapped" structure is used
                                        {
                                            //INBuffer[0] is the report ID, which we don't care about.
                                            //INBuffer[1] is an echo back of the command (see microcontroller firmware).
                                            //INBuffer[2] contains the I/O port pin value for the pushbutton (see microcontroller firmware).  
                                            if (INBuffer[1] == 0x11)
                                            {
                                                if (INBuffer[2] == b_size)
                                                {
                                                    // OK
                                                    for (int fi = 0; fi < INBuffer[2]; fi++)
                                                    {
                                                        al_temp1.Add(INBuffer[3 + fi]);
                                                    }
                                                }
                                                else
                                                {
                                                    // NG
                                                    b_Error_Flag = true;
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    AttachedState = false;
                                }

                                l_address += l_size;
                            }

                            // 読み込みOK
                            if (b_Error_Flag == false)
                            {
                                //読み込み情報セット
                                fData.Set_Eeprom_Read_An_Info(ref my_an_datas, al_temp1);

                                fData.Set_Eeprom_Read_Status(EepromControl.E2P_READ_TYPE_AN_SETTING, EepromControl.E2P_READ_STATUS_COMP);
                            }
                            else
                            {   // 読み込みNG
                                fData.Set_Eeprom_Read_Status(EepromControl.E2P_READ_TYPE_AN_SETTING, EepromControl.E2P_READ_STATUS_NA);
                            }

                            // バッファクリア
                            al_temp1.Clear();
                        }

                        if (set_an_calibration_req == true)
                        {
                            set_an_calibration_req = false;

                            //Get the pushbutton state from the microcontroller firmware.
                            OUTBuffer[0] = 0;			//The first byte is the "Report ID" and does not get sent over the USB bus.  Always set = 0.
                            OUTBuffer[1] = 0x35;		//0x81 is the "Get Pushbutton State" command in the firmware
                            OUTBuffer[2] = set_an_calibration_an_no;
                            for (uint i = 3; i < 65; i++)	//This loop is not strictly necessary.  Simply initializes unused bytes to
                                OUTBuffer[i] = 0xFF;				//0xFF for lower EMI and power consumption when driving the USB cable.

                            //To get the pushbutton state, first, we send a packet with our "Get Pushbutton State" command in it.
                            if (WriteFile(WriteHandleToUSBDevice, OUTBuffer, 65, ref BytesWritten, IntPtr.Zero))	//Blocking function, unless an "overlapped" structure is used
                            {
                                if (ReadFileManagedBuffer(ReadHandleToUSBDevice, INBuffer, 65, ref BytesRead, IntPtr.Zero))	//Blocking function, unless an "overlapped" structure is used
                                {
                                    //INBuffer[0] is the report ID, which we don't care about.
                                    //INBuffer[1] is an echo back of the command (see microcontroller firmware).
                                    //INBuffer[2] contains the I/O port pin value for the pushbutton (see microcontroller firmware).  
                                    if (INBuffer[1] == 0x35)
                                    {
                                        if (INBuffer[2] == 0x00)
                                        {
                                        }
                                        else
                                        {
                                            // NG
                                            //b_Error_Flag = true;
                                        }
                                    }
                                }
                            }
                        }

                        if (b_soft_reset_req == true)
                        {
                            b_soft_reset_req = false;

                            //Get the pushbutton state from the microcontroller firmware.
                            OUTBuffer[0] = 0;			//The first byte is the "Report ID" and does not get sent over the USB bus.  Always set = 0.
                            OUTBuffer[1] = 0x61;		//0x81 is the "Get Pushbutton State" command in the firmware
                            for (uint i = 2; i < 65; i++)	//This loop is not strictly necessary.  Simply initializes unused bytes to
                                OUTBuffer[i] = 0xFF;				//0xFF for lower EMI and power consumption when driving the USB cable.

                            //To get the pushbutton state, first, we send a packet with our "Get Pushbutton State" command in it.
                            if (WriteFile(WriteHandleToUSBDevice, OUTBuffer, 65, ref BytesWritten, IntPtr.Zero))	//Blocking function, unless an "overlapped" structure is used
                            {
                            }
                        }

                        if (b_default_set_req == true)
                        {
                            b_default_set_req = false;

                            //Get the pushbutton state from the microcontroller firmware.
                            OUTBuffer[0] = 0;			//The first byte is the "Report ID" and does not get sent over the USB bus.  Always set = 0.
                            OUTBuffer[1] = 0x62;		//0x81 is the "Get Pushbutton State" command in the firmware
                            for (uint i = 2; i < 65; i++)	//This loop is not strictly necessary.  Simply initializes unused bytes to
                                OUTBuffer[i] = 0xFF;				//0xFF for lower EMI and power consumption when driving the USB cable.

                            //To get the pushbutton state, first, we send a packet with our "Get Pushbutton State" command in it.
                            if (WriteFile(WriteHandleToUSBDevice, OUTBuffer, 65, ref BytesWritten, IntPtr.Zero))	//Blocking function, unless an "overlapped" structure is used
                            {
                                if (ReadFileManagedBuffer(ReadHandleToUSBDevice, INBuffer, 65, ref BytesRead, IntPtr.Zero))	//Blocking function, unless an "overlapped" structure is used
                                {
                                    //INBuffer[0] is the report ID, which we don't care about.
                                    //INBuffer[1] is an echo back of the command (see microcontroller firmware).
                                    //INBuffer[2] contains the I/O port pin value for the pushbutton (see microcontroller firmware).  
                                    if (INBuffer[1] == 0x62)
                                    {
                                        if (INBuffer[2] == 0x00)
                                        {
                                        }
                                        else
                                        {
                                            // NG
                                            //b_Error_Flag = true;
                                        }
                                    }
                                }
                            }
                        }

#pragma warning disable 0162
                        //DEBUG DEBUG DEBUG *****************************************************************************************************
                        if (__DEBUG_FLAG__ == true)
                        {

                            //Get the pushbutton state from the microcontroller firmware.
                            OUTBuffer[0] = 0;			//The first byte is the "Report ID" and does not get sent over the USB bus.  Always set = 0.
                            OUTBuffer[1] = 0x40;		//0x81 is the "Get Pushbutton State" command in the firmware
                            for (uint i = 2; i < 65; i++)	//This loop is not strictly necessary.  Simply initializes unused bytes to
                                OUTBuffer[i] = 0xFF;				//0xFF for lower EMI and power consumption when driving the USB cable.

                            //To get the pushbutton state, first, we send a packet with our "Get Pushbutton State" command in it.
                            if (WriteFile(WriteHandleToUSBDevice, OUTBuffer, 65, ref BytesWritten, IntPtr.Zero))	//Blocking function, unless an "overlapped" structure is used
                            {
                                //Now get the response packet from the firmware.
                                INBuffer[0] = 0;
                                {
                                    if (ReadFileManagedBuffer(ReadHandleToUSBDevice, INBuffer, 65, ref BytesRead, IntPtr.Zero))	//Blocking function, unless an "overlapped" structure is used
                                    {
                                        //INBuffer[0] is the report ID, which we don't care about.
                                        //INBuffer[1] is an echo back of the command (see microcontroller firmware).
                                        //INBuffer[2] contains the I/O port pin value for the pushbutton (see microcontroller firmware).  
                                        if (INBuffer[1] == 0x40)
                                        {
                                            for (int fi = 0; fi < Debug_Array1.Length; fi++)
                                            {
                                                Debug_Array1[fi] = (int)(INBuffer[2 + fi]);
                                            }
                                        }
                                    }
                                }
                            }
                            //Get the pushbutton state from the microcontroller firmware.
                            OUTBuffer[0] = 0;			//The first byte is the "Report ID" and does not get sent over the USB bus.  Always set = 0.
                            OUTBuffer[1] = 0x41;		//0x81 is the "Get Pushbutton State" command in the firmware
                            for (uint i = 2; i < 65; i++)	//This loop is not strictly necessary.  Simply initializes unused bytes to
                                OUTBuffer[i] = 0xFF;				//0xFF for lower EMI and power consumption when driving the USB cable.

                            //To get the pushbutton state, first, we send a packet with our "Get Pushbutton State" command in it.
                            if (WriteFile(WriteHandleToUSBDevice, OUTBuffer, 65, ref BytesWritten, IntPtr.Zero))	//Blocking function, unless an "overlapped" structure is used
                            {
                                //Now get the response packet from the firmware.
                                INBuffer[0] = 0;
                                {
                                    if (ReadFileManagedBuffer(ReadHandleToUSBDevice, INBuffer, 65, ref BytesRead, IntPtr.Zero))	//Blocking function, unless an "overlapped" structure is used
                                    {
                                        //INBuffer[0] is the report ID, which we don't care about.
                                        //INBuffer[1] is an echo back of the command (see microcontroller firmware).
                                        //INBuffer[2] contains the I/O port pin value for the pushbutton (see microcontroller firmware).  
                                        if (INBuffer[1] == 0x41)
                                        {
                                            for (int fi = 0; fi < Debug_Array2.Length; fi++)
                                            {
                                                Debug_Array2[fi] = (int)(INBuffer[2 + fi]);
                                            }
                                        }
                                    }
                                }
                            }
                            //Get the pushbutton state from the microcontroller firmware.
                            OUTBuffer[0] = 0;			//The first byte is the "Report ID" and does not get sent over the USB bus.  Always set = 0.
                            OUTBuffer[1] = 0x42;		//0x81 is the "Get Pushbutton State" command in the firmware
                            for (uint i = 2; i < 65; i++)	//This loop is not strictly necessary.  Simply initializes unused bytes to
                                OUTBuffer[i] = 0xFF;				//0xFF for lower EMI and power consumption when driving the USB cable.

                            //To get the pushbutton state, first, we send a packet with our "Get Pushbutton State" command in it.
                            if (WriteFile(WriteHandleToUSBDevice, OUTBuffer, 65, ref BytesWritten, IntPtr.Zero))	//Blocking function, unless an "overlapped" structure is used
                            {
                                //Now get the response packet from the firmware.
                                INBuffer[0] = 0;
                                {
                                    if (ReadFileManagedBuffer(ReadHandleToUSBDevice, INBuffer, 65, ref BytesRead, IntPtr.Zero))	//Blocking function, unless an "overlapped" structure is used
                                    {
                                        //INBuffer[0] is the report ID, which we don't care about.
                                        //INBuffer[1] is an echo back of the command (see microcontroller firmware).
                                        //INBuffer[2] contains the I/O port pin value for the pushbutton (see microcontroller firmware).  
                                        if (INBuffer[1] == 0x42)
                                        {
                                            for (int fi = 0; fi < Debug_Array3.Length; fi++)
                                            {
                                                Debug_Array3[fi] = (int)(INBuffer[2 + fi]);
                                            }
                                        }
                                    }
                                }
                            }
                            // EEPROM Read
                            if (debug_eeprom_read_req == true)
                            {
                                debug_eeprom_read_req = false;

                                for (uint i = 0; i < 65; i++)	//This loop is not strictly necessary.  Simply initializes unused bytes to
                                {
                                    OUTBuffer[i] = 0xFF;				//0xFF for lower EMI and power consumption when driving the USB cable.
                                }

                                uint tmp_eeprom_read_address = debug_eeprom_read_start_addr;
                                uint tmp_eeprom_read_size = 0;
                                uint tmp_buff_set_pos = 0;
                                while (true)
                                {
                                    OUTBuffer[0] = 0;
                                    OUTBuffer[1] = 0x11;
                                    OUTBuffer[2] = (byte)((tmp_eeprom_read_address >> 8) & 0xFF);		//Address
                                    OUTBuffer[3] = (byte)(tmp_eeprom_read_address & 0xFF);		        //

                                    tmp_eeprom_read_size = (debug_eeprom_read_start_addr + debug_eeprom_read_size) - tmp_eeprom_read_address;
                                    if (tmp_eeprom_read_size > EepromControl.E2P_USB_READ_DATA_SIZE)
                                    {
                                        tmp_eeprom_read_size = EepromControl.E2P_USB_READ_DATA_SIZE;
                                    }
                                    else if (tmp_eeprom_read_size == 0)
                                    {   // すべて読み込み完了
                                        debug_eeprom_read_comp = true;
                                        break;
                                    }
                                    OUTBuffer[4] = (byte)(tmp_eeprom_read_size & 0xFF);		            //Size
                                    tmp_eeprom_read_address += tmp_eeprom_read_size;

                                    //To get the pushbutton state, first, we send a packet with our "Get Pushbutton State" command in it.
                                    b_usb_write_ret = WriteFile(WriteHandleToUSBDevice, OUTBuffer, 65, ref BytesWritten, IntPtr.Zero);
                                    if (b_usb_write_ret == true)	//Blocking function, unless an "overlapped" structure is used
                                    {
                                        //Now get the response packet from the firmware.
                                        INBuffer[0] = 0;
                                        {
                                            if (ReadFileManagedBuffer(ReadHandleToUSBDevice, INBuffer, 65, ref BytesRead, IntPtr.Zero))	//Blocking function, unless an "overlapped" structure is used
                                            {
                                                //INBuffer[0] is the report ID, which we don't care about.
                                                //INBuffer[1] is an echo back of the command (see microcontroller firmware).
                                                //INBuffer[2] contains the I/O port pin value for the pushbutton (see microcontroller firmware).  
                                                if (INBuffer[1] == 0x11)
                                                {
                                                    if (INBuffer[2] == tmp_eeprom_read_size)
                                                    {
                                                        // OK
                                                        for (int fi = 0; fi < INBuffer[2]; fi++)
                                                        {
                                                            debug_eeprom_read_buff[tmp_buff_set_pos++] = INBuffer[3 + fi];
                                                        }
                                                    }
                                                    else
                                                    {
                                                        // NG
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                            // EEPROM Write
                            if (debug_eeprom_write_req == true)
                            {
                                debug_eeprom_write_req = false;

                                for (uint i = 0; i < 65; i++)	//This loop is not strictly necessary.  Simply initializes unused bytes to
                                {
                                    OUTBuffer[i] = 0xFF;				//0xFF for lower EMI and power consumption when driving the USB cable.
                                }

                                //Get the pushbutton state from the microcontroller firmware.
                                OUTBuffer[0] = 0;			//The first byte is the "Report ID" and does not get sent over the USB bus.  Always set = 0.
                                OUTBuffer[1] = 0x12;		//0x22 is the "Get Pushbutton State" command in the firmware
                                OUTBuffer[2] = (byte)((debug_eeprom_write_start_addr >> 8) & 0xFF);		//Address
                                OUTBuffer[3] = (byte)(debug_eeprom_write_start_addr & 0xFF);		        //
                                OUTBuffer[4] = (byte)(debug_eeprom_write_size & 0xFF);  //Size
                                for (uint i = 0; i < debug_eeprom_write_size; i++)
                                {
                                    OUTBuffer[5 + i] = debug_eeprom_write_buff[i];
                                }
                                for (uint i = (5 + (uint)debug_eeprom_write_size); i < 65; i++)	//This loop is not strictly necessary.  Simply initializes unused bytes to
                                    OUTBuffer[i] = 0xFF;				//0xFF for lower EMI and power consumption when driving the USB cable.

                                //To get the pushbutton state, first, we send a packet with our "Get Pushbutton State" command in it.
                                b_usb_write_ret = WriteFile(WriteHandleToUSBDevice, OUTBuffer, 65, ref BytesWritten, IntPtr.Zero);
                                if (b_usb_write_ret == true)	//Blocking function, unless an "overlapped" structure is used
                                {
                                    //Now get the response packet from the firmware.
                                    INBuffer[0] = 0;
                                    {
                                        if (ReadFileManagedBuffer(ReadHandleToUSBDevice, INBuffer, 65, ref BytesRead, IntPtr.Zero))	//Blocking function, unless an "overlapped" structure is used
                                        {
                                            //INBuffer[0] is the report ID, which we don't care about.
                                            //INBuffer[1] is an echo back of the command (see microcontroller firmware).
                                            //INBuffer[2] contains the I/O port pin value for the pushbutton (see microcontroller firmware).  
                                            if (INBuffer[1] == 0x12)
                                            {
                                                //ANS
                                                //byte_FlashWrite_Ans = INBuffer[2];
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    AttachedState = false;
                                }
                            }
                        }
                        //DEBUG DEBUG DEBUG *****************************************************************************************************
#pragma warning restore 0162

                    } //end of: if(AttachedState == true)
                    else
                    {
                        Thread.Sleep(5);	//Add a small delay.  Otherwise, this while(true) loop can execute very fast and cause 
                                            //high CPU utilization, with no particular benefit to the application.
                    }
                }
                catch
                {
                    //Exceptions can occur during the read or write operations.  For example,
                    //exceptions may occur if for instance the USB device is physically unplugged
                    //from the host while the above read/write functions are executing.

                    //Don't need to do anything special in this case.  The application will automatically
                    //re-establish communications based on the global AttachedState boolean variable used
                    //in conjunction with the WM_DEVICECHANGE messages to dyanmically respond to Plug and Play
                    //USB connection events.
                }

		    } //end of while(true) loop
            //-------------------------------------------------------END CUT AND PASTE BLOCK-------------------------------------------------------------------------------------
            //-------------------------------------------------------------------------------------------------------------------------------------------------------------------
        }



        private void FormUpdateTimer_Tick(object sender, EventArgs e)
        {
            //-------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //-------------------------------------------------------BEGIN CUT AND PASTE BLOCK-----------------------------------------------------------------------------------
            //This timer tick event handler function is used to update the user interface on the form, based on data
            //obtained asynchronously by the ReadWriteThread and the WM_DEVICECHANGE event handler functions.

            //Check if user interface on the form should be enabled or not, based on the attachment state of the USB device.
            if (AttachedState == true)
            {
                //Device is connected and ready to communicate, enable user interface on the form 
                StatusBox_lbl.Text = "デバイス検出済";

                if (Now_Background_image == 0)
                {
                    Revive_Advance_Device_pb.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_MAIN_ON;
                    Now_Background_image = 1;
                }


                if (ConnectFirstTime == true)
                {
                    //                    devicetype_combox.Text = st_device_type[eeprom_data[0]].text;
                    
                    Status_C_pb.Visible = true;
                    Status_NC_pb.Visible = false;

                    VersionReadReq = true;
                    VersionReadComp = false;
#if false
                    SetPin_combox.SelectedIndex = SetPin_selected;
                    devicetype_combox.SelectedIndex = (int)eeprom_data[SetPin_selected * 3];

                    for (uint fi = 0; fi < Constants.DIGITAL_INPUT_NUM; fi++)
                    {
                        if (ChangeAssign[fi] == true)
                        {
                            ChangeAssign[fi] = false;
                            switch (eeprom_data[fi * 3])
                            {
                                case Constants.SW_SET_DEVICE_TYPE_MOUSE:
                                    templbls2[fi].Text = "マウス";

                                    switch (eeprom_data[fi * 3 + 1])
                                    {
                                        case 0:
                                            templbls[fi].Text = "左クリック";
                                            break;
                                        case 1:
                                            templbls[fi].Text = "右クリック";
                                            break;
                                        case 2:
                                            templbls[fi].Text = "ホイールクリック";
                                            break;
                                        case 3:
                                            templbls[fi].Text = eeprom_data[fi * 3 + 2].ToString();
                                            templbls[fi].Text = templbls[fi].Text.Insert(0, "上移動 ");
                                            break;
                                        case 4:
                                            templbls[fi].Text = eeprom_data[fi * 3 + 2].ToString();
                                            templbls[fi].Text = templbls[fi].Text.Insert(0, "下移動 ");
                                            break;
                                        case 5:
                                            templbls[fi].Text = eeprom_data[fi * 3 + 2].ToString();
                                            templbls[fi].Text = templbls[fi].Text.Insert(0, "左移動 ");
                                            break;
                                        case 6:
                                            templbls[fi].Text = eeprom_data[fi * 3 + 2].ToString();
                                            templbls[fi].Text = templbls[fi].Text.Insert(0, "右移動 ");
                                            break;
                                        case 7:
                                            templbls[fi].Text = eeprom_data[fi * 3 + 2].ToString();
                                            templbls[fi].Text = templbls[fi].Text.Insert(0, "ホイール上 ");
                                            break;
                                        case 8:
                                            templbls[fi].Text = eeprom_data[fi * 3 + 2].ToString();
                                            templbls[fi].Text = templbls[fi].Text.Insert(0, "ホイール下 ");
                                            break;
                                        case 9:
                                            templbls[fi].Text = eeprom_data[fi * 3 + 2].ToString();
                                            templbls[fi].Text = templbls[fi].Text.Insert(0, "移動速度変更 ");
                                            break;
                                    }
                                    break;
                                case Constants.SW_SET_DEVICE_TYPE_KEYBOARD:
                                    templbls2[fi].Text = "キーボード";

                                    for (uint i = 0; i < 256; i++)
                                    {
                                        if (eeprom_data[fi * 3 + 1] == VKtoUSBkey[i])
                                        {
                                            templbls[fi].Text = USB_KeyCode_Name[VKtoUSBkey[i]];
                                        }
                                    }

                                    if ((eeprom_data[fi * 3 + 2] & 0x01) != 0)
                                        templbls[fi].Text = templbls[fi].Text.Insert(0, "Ctrl + ");

                                    if ((eeprom_data[fi * 3 + 2] & 0x02) != 0)
                                        templbls[fi].Text = templbls[fi].Text.Insert(0, "Shift + ");

                                    if ((eeprom_data[fi * 3 + 2] & 0x04) != 0)
                                        templbls[fi].Text = templbls[fi].Text.Insert(0, "Alt + ");

                                    if ((eeprom_data[fi * 3 + 2] & 0x08) != 0)
                                        templbls[fi].Text = templbls[fi].Text.Insert(0, "Win + ");

                                    break;
                                case Constants.SW_SET_DEVICE_TYPE_JOYSTICK:
                                    templbls2[fi].Text = "ジョイパッド";
                                    templbls[fi].Text = "";
                                    if ((eeprom_data[fi * 3 + 1] & 0x01) != 0)
                                        templbls[fi].Text = templbls[fi].Text.Insert(0, " 上");

                                    if ((eeprom_data[fi * 3 + 1] & 0x02) != 0)
                                        templbls[fi].Text = templbls[fi].Text.Insert(0, " 下");

                                    if ((eeprom_data[fi * 3 + 1] & 0x04) != 0)
                                        templbls[fi].Text = templbls[fi].Text.Insert(0, " 左");

                                    if ((eeprom_data[fi * 3 + 1] & 0x08) != 0)
                                        templbls[fi].Text = templbls[fi].Text.Insert(0, " 右");

                                    if ((eeprom_data[fi * 3 + 1] & 0x80) != 0)
                                        templbls[fi].Text = templbls[fi].Text.Insert(0, " B12");

                                    if ((eeprom_data[fi * 3 + 1] & 0x40) != 0)
                                        templbls[fi].Text = templbls[fi].Text.Insert(0, " B11");

                                    if ((eeprom_data[fi * 3 + 1] & 0x20) != 0)
                                        templbls[fi].Text = templbls[fi].Text.Insert(0, " B10");

                                    if ((eeprom_data[fi * 3 + 1] & 0x10) != 0)
                                        templbls[fi].Text = templbls[fi].Text.Insert(0, " B9");

                                    if ((eeprom_data[fi * 3 + 2] & 0x80) != 0)
                                        templbls[fi].Text = templbls[fi].Text.Insert(0, " B8");

                                    if ((eeprom_data[fi * 3 + 2] & 0x40) != 0)
                                        templbls[fi].Text = templbls[fi].Text.Insert(0, " B7");

                                    if ((eeprom_data[fi * 3 + 2] & 0x20) != 0)
                                        templbls[fi].Text = templbls[fi].Text.Insert(0, " B6");

                                    if ((eeprom_data[fi * 3 + 2] & 0x10) != 0)
                                        templbls[fi].Text = templbls[fi].Text.Insert(0, " B5");

                                    if ((eeprom_data[fi * 3 + 2] & 0x08) != 0)
                                        templbls[fi].Text = templbls[fi].Text.Insert(0, " B4");

                                    if ((eeprom_data[fi * 3 + 2] & 0x04) != 0)
                                        templbls[fi].Text = templbls[fi].Text.Insert(0, " B3");

                                    if ((eeprom_data[fi * 3 + 2] & 0x02) != 0)
                                        templbls[fi].Text = templbls[fi].Text.Insert(0, " B2");

                                    if ((eeprom_data[fi * 3 + 2] & 0x01) != 0)
                                        templbls[fi].Text = templbls[fi].Text.Insert(0, " B1");

                                    break;
                            }
                        }
                    }
#endif
                    ConnectFirstTime = false;
                }
                //if (StatusBoxChange != 99)
                //{
                //    StatusBox_lbl2.Text = " ]に設定しました";
                //    StatusBox_lbl2.Text = StatusBox_lbl2.Text.Insert(0, my_lbl_sw_assign[StatusBoxChange].Text);
                //    StatusBox_lbl2.Text = StatusBox_lbl2.Text.Insert(0, " / ");
                //    StatusBox_lbl2.Text = StatusBox_lbl2.Text.Insert(0, my_lbl_sw_device_type[StatusBoxChange].Text);
                //    StatusBox_lbl2.Text = StatusBox_lbl2.Text.Insert(0, "を[ ");
                //    StatusBox_lbl2.Text = StatusBox_lbl2.Text.Insert(0, cmbbx_digital_pin.Text );
                //    StatusBoxChange = 99;
                //}


                if (VersionReadReq == false && VersionReadComp == true)
                {
                    VersionReadComp = false;
                    // Version
                    System.Diagnostics.FileVersionInfo ver = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location);
                    lbl_FW_Version.Text = Constants.FIRMWARE_VERSION_STR + " " + Encoding.Default.GetString(version_buff);

                    // SW設定情報読み込み要求
                    fData.Set_Eeprom_Read_Status(EepromControl.E2P_READ_TYPE_SW_SETTING, EepromControl.E2P_READ_STATUS_RQ);
                    // AN設定情報読み込み要求
                    fData.Set_Eeprom_Read_Status(EepromControl.E2P_READ_TYPE_AN_SETTING, EepromControl.E2P_READ_STATUS_RQ);
                }

                byte read_status = fData.Get_Eeprom_Read_Status(EepromControl.E2P_READ_TYPE_SW_SETTING);
                read_status &= fData.Get_Eeprom_Read_Status(EepromControl.E2P_READ_TYPE_AN_SETTING);
                if ((read_status & EepromControl.E2P_READ_STATUS_COMP) == EepromControl.E2P_READ_STATUS_COMP)
                {
                    // SW設定情報　＆　AN設定情報 読み込み完了

                    if (EepromReadFirstTime == true)
                    {
                        EepromReadFirstTime = false;

                        // コントロール有効
                        my_Display_Enabled(true);
                        
                        //表示更新
                        my_Set_Display();
                        my_sw_setting_pin_disp(0, true);
                        my_an_setting_pin_disp(0, true);
                    }
                }
                else
                {
                    // コントロール無効
                    my_Display_Enabled(false);
                }

                UnConnectFirstTime = true;

            }
            if ((AttachedState == false) || (AttachedButBroken == true))
            {
                //Device not available to communicate. Disable user interface on the form.
                StatusBox_lbl.Text = "デバイス未検出";
                if (UnConnectFirstTime == true)
                {
                    Revive_Advance_Device_pb.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_MAIN_OFF;
                    Now_Background_image = 0;
                    Status_NC_pb.Visible = true;
                    Status_C_pb.Visible = false;

                    // コントロール無効
                    my_Display_Enabled(false);

                    for (int fi = 0; fi < Constants.DIGITAL_INPUT_NUM; fi++)
                    {
                        ChangeAssign[fi] = true;
                    }

                    // Flash読み込み状態クリア
                    fData.Set_Eeprom_Read_Status_Clear(0xFFFF);
                    EepromReadFirstTime = true;

                    my_sw_datas.all_clear();
                    my_an_datas.all_clear();

                    UnConnectFirstTime = false;
                }
                
                ConnectFirstTime = true;
            }

            //Update the various status indicators on the form with the latest info obtained from the ReadWriteThread()
            if (AttachedState == true)
            {
                // SW ON/OFF表示
                for (int fi = 0; fi < Constants.DIGITAL_INPUT_NUM; fi++)
                {
                    if (sw_status[fi] == 1)
                    {
                        my_pic_sw_status[fi].Visible = true;
                        //SetPin_combox.SelectedIndex = fi;
                        //listView1.Items[Constants.ANALOG_INPUT_NUM + fi].SubItems[Constants.SETTING_LIST_INDEX_VALUE].Text = "ON";
                    }
                    else
                    {
                        my_pic_sw_status[fi].Visible = false;
                        //listView1.Items[Constants.ANALOG_INPUT_NUM + fi].SubItems[Constants.SETTING_LIST_INDEX_VALUE].Text = "OFF";
                    }
                }
                // AN アナログ値表示
                for (int fi = 0; fi < Constants.ANALOG_INPUT_NUM; fi++)
                {
                    double dbl_temp = an_status[fi];
                    dbl_temp = dbl_temp * 3.3 / 0x3FF;
                    string str_val = string.Format("{0:0.00}", dbl_temp);
                    //string str_val = string.Format("AN {0}Pin {1:0.00}", fi + 1, dbl_temp);
                    my_lbl_an_status[fi].Text = str_val;
                    //my_lbl_an_status[fi].Text = string.Format("AN {0}Pin ", fi + 1);
                    //my_lbl_an_status[fi].Text += string.Format("{0:0.00}", dbl_temp);
                    //listView1.Items[fi].SubItems[Constants.SETTING_LIST_INDEX_VALUE].Text = str_val;
                }



                //DEBUG
                string debug_str = "";
                for (int fi = 0; fi < 16; fi++)
                {
                    debug_str += string.Format("{0:000} : ", fi);
                }
                colum_lbl.Text = debug_str;
                debug_str = "";
                for (int fi = 0; fi < Debug_Array1.Length; fi++)
                {
                    debug_str += string.Format("{0:000} : ", Debug_Array1[fi]);
                }
                Debug_label1.Text = debug_str;
                debug_str = "";
                for (int fi = 0; fi < Debug_Array1.Length; fi++)
                {
                    debug_str += string.Format(" {0:X2} : ", Debug_Array1[fi]);
                }
                Debug_label2.Text = debug_str;
                debug_str = "";
                for (int fi = 0; fi < Debug_Array2.Length; fi++)
                {
                    debug_str += string.Format(" {0:X2} : ", Debug_Array2[fi]);
                }
                Debug_label3.Text = debug_str;
                debug_str = "";
                for (int fi = 0; fi < Debug_Array3.Length; fi++)
                {
                    debug_str += string.Format(" {0:X2} : ", Debug_Array3[fi]);
                }
                Debug_label4.Text = debug_str;

                //DEBUG
                if (debug_eeprom_read_comp == true)
                {
                    debug_eeprom_read_comp = false;

                    string out_str = "0xXXXXXX:";
                    rtxtbx_debug_flash_read.Text = "";

                    // Header
                    for (int fi = 0; fi < 16; fi++)
                    {
                        out_str += string.Format(" {0:X2}", fi);
                    }

                    uint tmp_addr = debug_eeprom_read_start_addr & 0x1FFFF0;
                    uint tmp_buff_read_pos = 0;
                    // data
                    while (true)
                    {
                        if ((tmp_addr & 0xF) == 0)
                        {
                            out_str += string.Format("\n0x{0:X6}:", tmp_addr);
                        }
                        if (tmp_addr < debug_eeprom_read_start_addr)
                        {
                            out_str += string.Format("   ");
                        }
                        else if (tmp_addr < (debug_eeprom_read_start_addr + debug_eeprom_read_size))
                        {
                            if (tmp_buff_read_pos < debug_eeprom_read_buff.Length)
                            {
                                out_str += string.Format(" {0:X2}", debug_eeprom_read_buff[tmp_buff_read_pos++]);
                            }
                        }
                        else
                        {
                            break;
                        }
                        tmp_addr++;
                    }

                    rtxtbx_debug_flash_read.Text = out_str;
                }
                // DEBUG
            }
 
            //-------------------------------------------------------END CUT AND PASTE BLOCK-------------------------------------------------------------------------------------
            //-------------------------------------------------------------------------------------------------------------------------------------------------------------------
        }


        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------BEGIN CUT AND PASTE BLOCK-----------------------------------------------------------------------------------

        //--------------------------------------------------------------------------------------------------------------------------
        //FUNCTION:	ReadFileManagedBuffer()
        //PURPOSE:	Wrapper function to call ReadFile()
        //
        //INPUT:	Uses managed versions of the same input parameters as ReadFile() uses.
        //
        //OUTPUT:	Returns boolean indicating if the function call was successful or not.
        //          Also returns data in the byte[] INBuffer, and the number of bytes read. 
        //
        //Notes:    Wrapper function used to call the ReadFile() function.  ReadFile() takes a pointer to an unmanaged buffer and deposits
        //          the bytes read into the buffer.  However, can't pass a pointer to a managed buffer directly to ReadFile().
        //          This ReadFileManagedBuffer() is a wrapper function to make it so application code can call ReadFile() easier
        //          by specifying a managed buffer.
        //--------------------------------------------------------------------------------------------------------------------------
        public unsafe bool ReadFileManagedBuffer(SafeFileHandle hFile, byte[] INBuffer, uint nNumberOfBytesToRead, ref uint lpNumberOfBytesRead, IntPtr lpOverlapped)
        {
            IntPtr pINBuffer = IntPtr.Zero;

            try
            {
                pINBuffer = Marshal.AllocHGlobal((int)nNumberOfBytesToRead);    //Allocate some unmanged RAM for the receive data buffer.

                if (ReadFile(hFile, pINBuffer, nNumberOfBytesToRead, ref lpNumberOfBytesRead, lpOverlapped))
                {
                    Marshal.Copy(pINBuffer, INBuffer, 0, (int)lpNumberOfBytesRead);    //Copy over the data from unmanged memory into the managed byte[] INBuffer
                    Marshal.FreeHGlobal(pINBuffer);
                    return true;
                }
                else
                {
                    Marshal.FreeHGlobal(pINBuffer);
                    return false;
                }

            }
            catch
            {
                if (pINBuffer != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(pINBuffer);
                }
                return false;
            }
        }

        private void cmbbx_digital_device_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SW_DeviceType_selected = (byte)cmbbx_digital_device_type.SelectedIndex;

            my_sw_setting_device_type_disp(sw_selected, cmbbx_digital_device_type.SelectedIndex);

            //switch (SW_DeviceType_selected)
            //{
            //    case Constants.SW_SET_DEVICE_TYPE_MOUSE:
            //        cmbbx_digital_assign.Visible = true;
            //        KeyboardValue_txtbx.Visible = false;
            //        Alt_cbox.Visible = false;
            //        Ctrl_cbox.Visible = false;
            //        Shift_cbox.Visible = false;
            //        Win_cbox.Visible = false;
            //        LeverXM_cbox.Visible = false;
            //        LeverYP_cbox.Visible = false;
            //        LeverYM_cbox.Visible = false;
            //        LeverXP_cbox.Visible = false;
            //        Button1_cbox.Visible = false;
            //        Button2_cbox.Visible = false;
            //        Button3_cbox.Visible = false;
            //        Button4_cbox.Visible = false;
            //        Button5_cbox.Visible = false;
            //        Button6_cbox.Visible = false;
            //        Button7_cbox.Visible = false;
            //        Button8_cbox.Visible = false;
            //        Button9_cbox.Visible = false;
            //        Button10_cbox.Visible = false;
            //        Button11_cbox.Visible = false;
            //        Button12_cbox.Visible = false;
            //        Arrow_Keyboard_pb.Visible = false;

            //        Arrow_Com_pb.Visible = false;

            //        if (eeprom_data[sw_selected * 3 + 1] > 9)
            //            eeprom_data[sw_selected * 3 + 1] = 0;

            //        cmbbx_digital_assign.Items.Add("ダミー");
            //        cmbbx_digital_assign.SelectedIndex = cmbbx_digital_assign.Items.Count - 1;
            //        cmbbx_digital_assign.SelectedIndex = eeprom_data[sw_selected * 3 + 1];
            //        cmbbx_digital_assign.Items.Remove("ダミー");

            //        break;
            //    case Constants.SW_SET_DEVICE_TYPE_KEYBOARD:
            //        cmbbx_digital_assign.Visible = false;
            //        KeyboardValue_txtbx.Visible = true;
            //        Alt_cbox.Visible = true;
            //        Ctrl_cbox.Visible = true;
            //        Shift_cbox.Visible = true;
            //        Win_cbox.Visible = true;
            //        LeverXM_cbox.Visible = false;
            //        LeverYP_cbox.Visible = false;
            //        LeverYM_cbox.Visible = false;
            //        LeverXP_cbox.Visible = false;
            //        Button1_cbox.Visible = false;
            //        Button2_cbox.Visible = false;
            //        Button3_cbox.Visible = false;
            //        Button4_cbox.Visible = false;
            //        Button5_cbox.Visible = false;
            //        Button6_cbox.Visible = false;
            //        Button7_cbox.Visible = false;
            //        Button8_cbox.Visible = false;
            //        Button9_cbox.Visible = false;
            //        Button10_cbox.Visible = false;
            //        Button11_cbox.Visible = false;
            //        Button12_cbox.Visible = false;
            //        Arrow_Keyboard_pb.Visible = true;

            //        Arrow_Mouse1_pb.Visible = false;
            //        Arrow_Mouse2_pb.Visible = false;
            //        Arrow_Mouse3_pb.Visible = false;
            //        Speed_Mouse4_pb.Visible = false;
            //        Speed_Mouse5_pb.Visible = false;
            //        Arrow_Com_pb.Visible = true;

            //        for (uint i = 0; i < 256; i++)
            //        {
            //            if (eeprom_data[sw_selected * 3 + 1] == VKtoUSBkey[i])
            //            {
            //                KeyboardValue_txtbx.Text = USB_KeyCode_Name[VKtoUSBkey[i]];
            //            }
            //        }
            //        if (eeprom_data[sw_selected * 3 + 1] == 0)
            //            KeyboardValue_txtbx.Text = "ここに入力";

            //        if ((eeprom_data[sw_selected * 3 + 2] & 0x01) != 0)
            //            Ctrl_cbox.Checked = true;
            //        else
            //            Ctrl_cbox.Checked = false;

            //        if ((eeprom_data[sw_selected * 3 +  2] & 0x02) != 0)
            //            Shift_cbox.Checked = true;
            //        else
            //            Shift_cbox.Checked = false;

            //        if ((eeprom_data[sw_selected * 3 + 2] & 0x04) != 0)
            //            Alt_cbox.Checked = true;
            //        else
            //            Alt_cbox.Checked = false;

            //        if ((eeprom_data[sw_selected * 3 + 2] & 0x08) != 0)
            //            Win_cbox.Checked = true;
            //        else
            //            Win_cbox.Checked = false;

            //        MouseMove_UD.Visible = false;

            //        break;
            //    case Constants.SW_SET_DEVICE_TYPE_JOYSTICK:
            //        cmbbx_digital_assign.Visible = false;
            //        KeyboardValue_txtbx.Visible = false;
            //        Alt_cbox.Visible = false;
            //        Ctrl_cbox.Visible = false;
            //        Shift_cbox.Visible = false;
            //        Win_cbox.Visible = false;
            //        LeverXM_cbox.Visible = true;
            //        LeverYP_cbox.Visible = true;
            //        LeverYM_cbox.Visible = true;
            //        LeverXP_cbox.Visible = true;
            //        Button1_cbox.Visible = true;
            //        Button2_cbox.Visible = true;
            //        Button3_cbox.Visible = true;
            //        Button4_cbox.Visible = true;
            //        Button5_cbox.Visible = true;
            //        Button6_cbox.Visible = true;
            //        Button7_cbox.Visible = true;
            //        Button8_cbox.Visible = true;
            //        Button9_cbox.Visible = true;
            //        Button10_cbox.Visible = true;
            //        Button11_cbox.Visible = true;
            //        Button12_cbox.Visible = true;

            //        Arrow_Mouse1_pb.Visible = false;
            //        Arrow_Mouse2_pb.Visible = false;
            //        Arrow_Mouse3_pb.Visible = false;
            //        Speed_Mouse4_pb.Visible = false;
            //        Speed_Mouse5_pb.Visible = false;
            //        Arrow_Com_pb.Visible = true;

            //        LeverValue_selected = 0;
            //        HatSWValue_selected = 0;
            //        for(int fi = 0; fi < ButtonValue_selected.Length; fi++)
            //        {
            //            ButtonValue_selected[fi] = 0;
            //        }
            //        LeverXP_cbox.Checked = false;
            //        LeverXM_cbox.Checked = false;
            //        LeverYP_cbox.Checked = false;
            //        LeverYM_cbox.Checked = false;
            //        Button12_cbox.Checked = false;
            //        Button11_cbox.Checked = false;
            //        Button10_cbox.Checked = false;
            //        Button9_cbox.Checked = false;
            //        Button8_cbox.Checked = false;
            //        Button7_cbox.Checked = false;
            //        Button6_cbox.Checked = false;
            //        Button5_cbox.Checked = false;
            //        Button4_cbox.Checked = false;
            //        Button3_cbox.Checked = false;
            //        Button2_cbox.Checked = false;
            //        Button1_cbox.Checked = false;

            //        Arrow_Keyboard_pb.Visible = false;

            //        if ((eeprom_data[sw_selected * 3 + 1] & 0x01) != 0)
            //            LeverXP_cbox.Checked = true;

            //        if ((eeprom_data[sw_selected * 3 + 1] & 0x02) != 0)
            //            LeverXM_cbox.Checked = true;

            //        if ((eeprom_data[sw_selected * 3 + 1] & 0x04) != 0)
            //            LeverYP_cbox.Checked = true;

            //        if ((eeprom_data[sw_selected * 3 + 1] & 0x08) != 0)
            //            LeverYM_cbox.Checked = true;

            //        if ((eeprom_data[sw_selected * 3 + 1] & 0x80) != 0)
            //            Button12_cbox.Checked = true;

            //        if ((eeprom_data[sw_selected * 3 + 1] & 0x40) != 0)
            //            Button11_cbox.Checked = true;

            //        if ((eeprom_data[sw_selected * 3 + 1] & 0x20) != 0)
            //            Button10_cbox.Checked = true;
                    
            //        if ((eeprom_data[sw_selected * 3 + 1] & 0x10) != 0)
            //            Button9_cbox.Checked = true;
                    
            //        if ((eeprom_data[sw_selected * 3 + 2] & 0x80) != 0)
            //            Button8_cbox.Checked = true;

            //        if ((eeprom_data[sw_selected * 3 + 2] & 0x40) != 0)
            //            Button7_cbox.Checked = true;

            //        if ((eeprom_data[sw_selected * 3 + 2] & 0x20) != 0)
            //            Button6_cbox.Checked = true;

            //        if ((eeprom_data[sw_selected * 3 + 2] & 0x10) != 0)
            //            Button5_cbox.Checked = true;

            //        if ((eeprom_data[sw_selected * 3 + 2] & 0x08) != 0)
            //            Button4_cbox.Checked = true;

            //        if ((eeprom_data[sw_selected * 3 + 2] & 0x04) != 0)
            //            Button3_cbox.Checked = true;

            //        if ((eeprom_data[sw_selected * 3 + 2] & 0x02) != 0)
            //            Button2_cbox.Checked = true;

            //        if ((eeprom_data[sw_selected * 3 + 2] & 0x01) != 0)
            //            Button1_cbox.Checked = true;

            //        MouseMove_UD.Visible = false;

            //        break;
            //    default:
            //        cmbbx_digital_assign.Visible = false;
            //        KeyboardValue_txtbx.Visible = false;
            //        Alt_cbox.Visible = false;
            //        Ctrl_cbox.Visible = false;
            //        Shift_cbox.Visible = false;
            //        Win_cbox.Visible = false;
            //        LeverXM_cbox.Visible = false;
            //        LeverYP_cbox.Visible = false;
            //        LeverYM_cbox.Visible = false;
            //        LeverXP_cbox.Visible = false;
            //        Button1_cbox.Visible = false;
            //        Button2_cbox.Visible = false;
            //        Button3_cbox.Visible = false;
            //        Button4_cbox.Visible = false;
            //        Button5_cbox.Visible = false;
            //        Button6_cbox.Visible = false;
            //        Button7_cbox.Visible = false;
            //        Button8_cbox.Visible = false;
            //        Button9_cbox.Visible = false;
            //        Button10_cbox.Visible = false;
            //        Button11_cbox.Visible = false;
            //        Button12_cbox.Visible = false;
            //        Arrow_Keyboard_pb.Visible = false;

            //        Arrow_Com_pb.Visible = false;

            //        if (eeprom_data[sw_selected * 3 + 1] > 9)
            //        {
            //            eeprom_data[sw_selected * 3 + 1] = 0;
            //        }

            //        cmbbx_digital_assign.Items.Add("ダミー");
            //        cmbbx_digital_assign.SelectedIndex = cmbbx_digital_assign.Items.Count - 1;
            //        cmbbx_digital_assign.SelectedIndex = eeprom_data[sw_selected * 3 + 1];
            //        cmbbx_digital_assign.Items.Remove("ダミー");
            //        break;
            //}
        }

        private void cmbbx_digital_assign_SelectedIndexChanged(object sender, EventArgs e)
        {
            MouseValue_selected = (byte)cmbbx_digital_assign.SelectedIndex;

            my_sw_setting_set_type_disp(sw_selected, SW_DeviceType_selected, MouseValue_selected, sw_disp_data);

            //if (MouseValue_selected > 2)
            //{
            //    MouseMove_UD.Visible = true;
            //    Arrow_Mouse1_pb.Visible = true;
            //    Arrow_Mouse2_pb.Visible = false;
            //    Arrow_Mouse3_pb.Visible = true;
            //    Speed_Mouse4_pb.Visible = true;
            //    Speed_Mouse5_pb.Visible = true;
            //    if (eeprom_data[sw_selected * 3 + 2] == 0)
            //        eeprom_data[sw_selected * 3 + 2] = 50;
            //    MouseMove_UD.Value = eeprom_data[sw_selected * 3 + 2];
            //}
            //else
            //{
            //    Arrow_Mouse1_pb.Visible = false;
            //    Arrow_Mouse2_pb.Visible = true;
            //    Arrow_Mouse3_pb.Visible = false;
            //    Speed_Mouse4_pb.Visible = false;
            //    Speed_Mouse5_pb.Visible = false;
            //    MouseMove_UD.Visible = false;
            //}
        }

        private void KeyboardValue_txtbx_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Tab)
                {
                    KeyboardValue_txtbx.Text = const_Key_Code.Get_KeyCode_Name(const_Key_Code.Get_VKtoUSBkey(e.KeyValue.GetHashCode(), Constants.KEYBOARD_TYPE_JA, true), Constants.KEYBOARD_TYPE_JA);
                    KeyboardValue_selected = const_Key_Code.Get_VKtoUSBkey(e.KeyValue.GetHashCode(), Constants.KEYBOARD_TYPE_JA, true);
                    e.IsInputKey = true;
                }
            }
            catch
            {
            }
        }

        private void KeyboardValue_txtbx_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //if (e.KeyCode == Keys.ControlKey || e.KeyCode == Keys.ShiftKey || e.KeyCode == Keys.Alt)
                //{
                //    e.Handled = true;
                //}
                //else
                //{
                //    KeyboardValue_txtbx.Text = USB_KeyCode_Name[VKtoUSBkey[e.KeyValue.GetHashCode()]];
                //    KeyboardValue_selected = VKtoUSBkey[e.KeyValue.GetHashCode()];
                //    e.SuppressKeyPress = true;
                //}
                KeyboardValue_txtbx.Text = const_Key_Code.Get_KeyCode_Name(const_Key_Code.Get_VKtoUSBkey(e.KeyValue.GetHashCode(), Constants.KEYBOARD_TYPE_JA, true), Constants.KEYBOARD_TYPE_JA);
                KeyboardValue_selected = const_Key_Code.Get_VKtoUSBkey(e.KeyValue.GetHashCode(), Constants.KEYBOARD_TYPE_JA, true);
                e.SuppressKeyPress = true;
            }
            catch
            {
            }
        }

        private void KeyboardValue_txtbx_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.PrintScreen)
                {
                    KeyboardValue_txtbx.Text = const_Key_Code.Get_KeyCode_Name(const_Key_Code.Get_VKtoUSBkey(e.KeyValue.GetHashCode(), Constants.KEYBOARD_TYPE_JA, true), Constants.KEYBOARD_TYPE_JA);
                    KeyboardValue_selected = const_Key_Code.Get_VKtoUSBkey(e.KeyValue.GetHashCode(), Constants.KEYBOARD_TYPE_JA, true);
                    e.SuppressKeyPress = true;
                }
            }
            catch
            {
            }
        }

        private void keyboard_modifier_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                int idx = int.Parse(((CheckBox)sender).Tag.ToString());
                if (0 <= idx && idx < my_chkbx_keyboard_modifier.Length)
                {
                    if (my_chkbx_keyboard_modifier[idx].Checked == true)
                    {
                        KeyboardModifier_selected |= keyboard_modifier_bit_4type[idx];
                    }
                    else
                    {
                        KeyboardModifier_selected = (byte)((KeyboardModifier_selected & ~keyboard_modifier_bit_4type[idx]) & 0xFF);
                    }
                }
            }
            catch
            {
            }
        }

        private void Joystick_Lever_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                int idx = int.Parse(((CheckBox)sender).Tag.ToString());
                if (0 <= idx && idx < joystick_lever_set_bit.Length)
                {
                    if (my_chkbx_joystick_lever[idx].Checked == true)
                    {
                        LeverValue_selected |= joystick_lever_set_bit[idx];
                    }
                    else
                    {
                        LeverValue_selected = (byte)((LeverValue_selected & ~joystick_lever_set_bit[idx]) & 0xFF);
                    }
                }
            }
            catch
            {
            }
        }

        private void Joystick_HatSW_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                int idx = int.Parse(((CheckBox)sender).Tag.ToString());
                if (0 <= idx && idx < joystick_hatsw_set_bit.Length)
                {
                    if (my_chkbx_joystick_hatsw[idx].Checked == true)
                    {
                        HatSWValue_selected |= joystick_hatsw_set_bit[idx];
                    }
                    else
                    {
                        HatSWValue_selected = (byte)((HatSWValue_selected & ~joystick_hatsw_set_bit[idx]) & 0xFF);
                    }
                }
            }
            catch
            {
            }
        }

        private void Joystick_Button_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                int idx = int.Parse(((CheckBox)sender).Tag.ToString());
                if (0 <= idx && idx < joystick_button_set_bit.Length)
                {
                    if (my_chkbx_joystick_button[idx].Checked == true)
                    {
                        ButtonValue_selected[joystick_button_set_byte[idx]] |= joystick_button_set_bit[idx];
                    }
                    else
                    {
                        ButtonValue_selected[joystick_button_set_byte[idx]] = (byte)((ButtonValue_selected[joystick_button_set_byte[idx]] & ~joystick_button_set_bit[idx]) & 0xFF);
                    }
                }
            }
            catch
            {
            }
        }
        
        private void cmbbx_digital_pin_SelectedIndexChanged(object sender, EventArgs e)
        {
            //PictureBox[] tmp_picA = new PictureBox[] { Pin01A_pb, Pin02A_pb, Pin03A_pb, Pin04A_pb, Pin05A_pb, Pin06A_pb, Pin07A_pb, Pin08A_pb, Pin09A_pb, Pin10A_pb, Pin11A_pb, Pin12A_pb, Pin13A_pb, Pin14A_pb, Pin15A_pb };
            //tmp_picA[sw_selected].Visible = false;

            ////sw_selected = cmbbx_digital_pin.SelectedIndex;

            //tmp_picA[cmbbx_digital_pin.SelectedIndex].Visible = true;

            my_sw_setting_pin_disp(cmbbx_digital_pin.SelectedIndex, false);

            //cmbbx_digital_device_type.Items.Add("ダミー");
            //cmbbx_digital_device_type.SelectedIndex = cmbbx_digital_device_type.Items.Count - 1;
            //cmbbx_digital_device_type.SelectedIndex = eeprom_data[sw_selected * 3];
            //cmbbx_digital_device_type.Items.Remove("ダミー");
        }

        private void DigitalPIN_Click(object sender, EventArgs e)
        {
            try
            {
                int idx = int.Parse(((PictureBox)sender).Tag.ToString());
                if (0 <= idx && idx < Constants.DIGITAL_INPUT_NUM)
                {
                    my_sw_setting_pin_disp(idx, false);
                }
            }
            catch
            {
            }
        }

        private void AnalogPIN_Click(object sender, EventArgs e)
        {
            try
            {
                int idx = int.Parse(((PictureBox)sender).Tag.ToString());
                if (0 <= idx && idx < Constants.ANALOG_INPUT_NUM)
                {
                    my_an_setting_pin_disp(idx, false);
                }
            }
            catch
            {
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                MouseMoveValue_selected = (byte)MouseMove_UD.Value;
            }
            catch
            {
            }
        }

        /// <summary>
        /// 表示コントロールの有効/無効設定
        /// </summary>
        /// <param name="flag"></param>
        private void my_Display_Enabled(bool flag)
        {
            try
            {
                // DIGITAL 設定
                pnl_digital_setting.Enabled = flag;
                btn_digital_set.Enabled = flag;
                cmbbx_digital_pin.Enabled = flag;
                cmbbx_digital_device_type.Enabled = flag;
                for (int fi = 0; fi < my_pin_no_pic_a.Length; fi++)
                {
                    my_pin_no_pic_a[fi].Enabled = flag;
                    my_pin_no_pic_b[fi].Enabled = flag;
                }

                // ANALOG 設定
                pnl_analog_setting.Enabled = flag;
                cmbbx_analog_pin.Enabled = flag;
                cmbbx_analog_set_type.Enabled = flag;
                btn_analog_set.Enabled = flag;
                for (int fi = 0; fi < my_an_pin_no_pic_a.Length; fi++)
                {
                    my_an_pin_no_pic_a[fi].Enabled = flag;
                    my_an_pin_no_pic_b[fi].Enabled = flag;
                }

                gbx_setting_list.Enabled = flag;
                ana_tabB_pb.Enabled = flag;
                dig_tabB_pb.Enabled = flag;

                // soft reset
                btn_soft_reset.Enabled = flag;
                btn_default_reset.Enabled = flag;

                if (flag == true)
                {
                }
                else
                {
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 表示の更新をする
        /// </summary>
        /// <param name="display_type">更新対象画面</param>
        /// <param name="p_mouse_mode"></param>
        /// <param name="p_mouse_setting_data"></param>
        /// <param name="p_p_script_info"></param>
        /// <param name="p_script_info_datas"></param>
        private void my_Set_Display()
        {
            try
            {
                my_sw_setting_disp(true);
                my_an_setting_disp(true);
            }
            catch
            {
            }
        }

        private void my_sw_setting_disp(bool p_visibled)
        {
            try
            {
                for (int sw_no = 0; sw_no < Constants.DIGITAL_INPUT_NUM; sw_no++ )
                {
                    my_lbl_sw_device_type[sw_no].Text = "";
                    my_lbl_sw_assign[sw_no].Text = "";
                    string str_device_type = "";
                    string str_assign = "";

                    switch (my_sw_datas.sw_datas[sw_no].sw_data[Constants.SW_DEVICE_DATA_SET_DEVICE_TYPE_IDX])
                    {
                        case Constants.SW_SET_DEVICE_TYPE_NONE:
                            my_lbl_sw_device_type[sw_no].Text = sw_device_type_list[Constants.SW_SET_DEVICE_TYPE_NONE];
                            str_device_type = sw_device_type_list[Constants.SW_SET_DEVICE_TYPE_NONE];
                            break;
                        case Constants.SW_SET_DEVICE_TYPE_MOUSE:
                            my_lbl_sw_device_type[sw_no].Text = sw_device_type_list[Constants.SW_SET_DEVICE_TYPE_MOUSE];
                            str_device_type = sw_device_type_list[Constants.SW_SET_DEVICE_TYPE_MOUSE];

                            my_lbl_sw_assign[sw_no].Text = sw_mouse_set_type_list[my_sw_datas.sw_datas[sw_no].sw_data[Constants.SW_DEVICE_DATA_SET_TYPE_IDX]];
                            str_assign = sw_mouse_set_type_list[my_sw_datas.sw_datas[sw_no].sw_data[Constants.SW_DEVICE_DATA_SET_TYPE_IDX]];
                            switch (my_sw_datas.sw_datas[sw_no].sw_data[Constants.SW_DEVICE_DATA_SET_TYPE_IDX])
                            {
                                case Constants.SW_SET_TYPE_MOUSE_LCLICK:
                                case Constants.SW_SET_TYPE_MOUSE_RCLICK:
                                case Constants.SW_SET_TYPE_MOUSE_WHCLICK:
                                case Constants.SW_SET_TYPE_MOUSE_B4CLICK:
                                case Constants.SW_SET_TYPE_MOUSE_B5CLICK:
                                    break;
                                case Constants.SW_SET_TYPE_MOUSE_MOVE_UP:
                                case Constants.SW_SET_TYPE_MOUSE_MOVE_DOWN:
                                case Constants.SW_SET_TYPE_MOUSE_MOVE_LEFT:
                                case Constants.SW_SET_TYPE_MOUSE_MOVE_RIGHT:
                                    my_lbl_sw_assign[sw_no].Text += " " + my_sw_datas.sw_datas[sw_no].sw_data[Constants.SW_DEVICE_DATA_SENSE_IDX].ToString();
                                    str_assign += " " + my_sw_datas.sw_datas[sw_no].sw_data[Constants.SW_DEVICE_DATA_SENSE_IDX].ToString();
                                    break;
                                case Constants.SW_SET_TYPE_MOUSE_WHSCROLL_UP:
                                case Constants.SW_SET_TYPE_MOUSE_WHSCROLL_DOWN:
                                    my_lbl_sw_assign[sw_no].Text += " " + my_sw_datas.sw_datas[sw_no].sw_data[Constants.SW_DEVICE_DATA_SENSE_IDX].ToString();
                                    str_assign += " " + my_sw_datas.sw_datas[sw_no].sw_data[Constants.SW_DEVICE_DATA_SENSE_IDX].ToString();
                                    break;
                                case Constants.SW_SET_TYPE_MOUSE_SPEED:
                                    my_lbl_sw_assign[sw_no].Text += " " + my_sw_datas.sw_datas[sw_no].sw_data[Constants.SW_DEVICE_DATA_SENSE_IDX].ToString();
                                    str_assign += " " + my_sw_datas.sw_datas[sw_no].sw_data[Constants.SW_DEVICE_DATA_SENSE_IDX].ToString();
                                    break;
                            }
                            break;
                        case Constants.SW_SET_DEVICE_TYPE_KEYBOARD:
                            my_lbl_sw_device_type[sw_no].Text = sw_device_type_list[Constants.SW_SET_DEVICE_TYPE_KEYBOARD];
                            str_device_type = sw_device_type_list[Constants.SW_SET_DEVICE_TYPE_KEYBOARD];

                            my_lbl_sw_assign[sw_no].Text = const_Key_Code.Get_KeyCode_Name(my_sw_datas.sw_datas[sw_no].sw_data[Constants.SW_DEVICE_DATA_KEY1_IDX], Constants.KEYBOARD_TYPE_JA);
                            str_assign = const_Key_Code.Get_KeyCode_Name(my_sw_datas.sw_datas[sw_no].sw_data[Constants.SW_DEVICE_DATA_KEY1_IDX], Constants.KEYBOARD_TYPE_JA);

                            for (int fi = (my_chkbx_keyboard_modifier.Length - 1); fi >= 0; fi--)
                            {
                                if ((my_sw_datas.sw_datas[sw_no].sw_data[Constants.SW_DEVICE_DATA_MODIFIER_IDX] & keyboard_modifier_bit_4type[fi]) != 0)
                                {
                                    my_lbl_sw_assign[sw_no].Text = keyboard_modifier_name_4type[fi] + " + " + my_lbl_sw_assign[sw_no].Text;
                                    str_assign = keyboard_modifier_name_4type[fi] + " + " + str_assign;
                                }
                            }
                            break;
                        case Constants.SW_SET_DEVICE_TYPE_JOYSTICK:
                            my_lbl_sw_device_type[sw_no].Text = sw_device_type_list[Constants.SW_SET_DEVICE_TYPE_JOYSTICK];
                            str_device_type = sw_device_type_list[Constants.SW_SET_DEVICE_TYPE_JOYSTICK];

                            my_lbl_sw_assign[sw_no].Text = "";
                            str_assign = "";
                            int disp_count = 0;
                            for (int fi = 0; fi < sw_joystick_set_type_button_list.Length; fi++)
                            {
                                string combine_char = " + ";
                                if (disp_count == 0)
                                {
                                    combine_char = "";
                                }
                                if ((my_sw_datas.sw_datas[sw_no].sw_data[Constants.SW_DEVICE_DATA_BUTTON1_IDX + joystick_button_set_byte[fi]] & joystick_button_set_bit[fi]) != 0)
                                {
                                    my_lbl_sw_assign[sw_no].Text = my_lbl_sw_assign[sw_no].Text + combine_char + sw_joystick_set_type_button_list[fi];
                                    str_assign = str_assign + combine_char + sw_joystick_set_type_button_list[fi];
                                    disp_count++;
                                }
                            }
                            for (int fi = 0; fi < sw_joystick_set_type_hatsw_list.Length; fi++)
                            {
                                string combine_char = " + ";
                                if (disp_count == 0)
                                {
                                    combine_char = "";
                                }
                                if ((my_sw_datas.sw_datas[sw_no].sw_data[Constants.SW_DEVICE_DATA_HATSW_IDX] & joystick_hatsw_set_bit[fi]) != 0)
                                {
                                    my_lbl_sw_assign[sw_no].Text = my_lbl_sw_assign[sw_no].Text + combine_char + sw_joystick_set_type_hatsw_list[fi];
                                    str_assign = str_assign + combine_char + sw_joystick_set_type_hatsw_list[fi];
                                    disp_count++;
                                }
                            }
                            for (int fi = 0; fi < sw_joystick_set_type_lever_list.Length; fi++)
                            {
                                string combine_char = " + ";
                                if (disp_count == 0)
                                {
                                    combine_char = "";
                                }
                                if ((my_sw_datas.sw_datas[sw_no].sw_data[Constants.SW_DEVICE_DATA_LEVER1_IDX + joystick_lever_set_byte[fi]] & joystick_lever_set_bit[fi]) != 0)
                                {
                                    my_lbl_sw_assign[sw_no].Text = my_lbl_sw_assign[sw_no].Text + combine_char + sw_joystick_set_type_lever_list[fi];
                                    str_assign = str_assign + combine_char + sw_joystick_set_type_lever_list[fi];
                                    disp_count++;
                                }
                            }
                            break;
                    }

                    listView1.Items[Constants.AN_SETTING_NUM + sw_no].SubItems[Constants.SETTING_LIST_INDEX_DEVICE_TYPE].Text = str_device_type;
                    listView1.Items[Constants.AN_SETTING_NUM + sw_no].SubItems[Constants.SETTING_LIST_INDEX_ASSIGN].Text = str_assign;
                }
            }
            catch
            {
            }
        }

        private void my_sw_setting_pin_disp(int p_sw_no, bool p_first_disp_flag)
        {
            try
            {
                if (0 <= p_sw_no && p_sw_no < Constants.DIGITAL_INPUT_NUM && p_sw_no < cmbbx_digital_pin.Items.Count)
                {
                    this.cmbbx_digital_pin.SelectedIndexChanged -= new System.EventHandler(this.cmbbx_digital_pin_SelectedIndexChanged);

                    pnl_digital_setting.Visible = true;
                    pnl_analog_setting.Visible = false;
                    ana_tabA_pb.Visible = false;
                    dig_tabA_pb.Visible = true;

                    my_pin_no_pic_a[sw_selected].Visible = false;
                    my_pin_no_pic_a[p_sw_no].Visible = true;
                    for (int fi = 0; fi < my_an_pin_no_pic_a.Length; fi++)
                    {
                        my_an_pin_no_pic_a[fi].Visible = false;
                    }

                    cmbbx_digital_pin.SelectedIndex = p_sw_no;


                    if (sw_selected != p_sw_no || p_first_disp_flag == true)
                    {
                        for (int fi = 0; fi < Constants.SW_DEVICE_DATA_LEN; fi++)
                        {
                            sw_disp_data[fi] = my_sw_datas.sw_datas[p_sw_no].sw_data[fi];
                        }
                    }
                    sw_selected = p_sw_no;

                    byte device_no = my_sw_datas.sw_datas[p_sw_no].sw_data[Constants.SW_DEVICE_DATA_SET_DEVICE_TYPE_IDX];
                    my_sw_setting_device_type_disp(p_sw_no, device_no);

                    this.cmbbx_digital_pin.SelectedIndexChanged += new System.EventHandler(this.cmbbx_digital_pin_SelectedIndexChanged);
                }
            }
            catch
            {
            }
        }

        private void my_sw_setting_device_type_disp(int p_sw_no, int p_device_type)
        {
            try
            {
                if (0 <= p_sw_no && p_sw_no < Constants.DIGITAL_INPUT_NUM)
                {
                    if (0 <= p_device_type && p_device_type < Constants.SW_SET_DEVICE_TYPE_NUM && p_device_type < cmbbx_digital_device_type.Items.Count)
                    {
                        this.cmbbx_digital_device_type.SelectedIndexChanged -= new System.EventHandler(this.cmbbx_digital_device_type_SelectedIndexChanged);

                        cmbbx_digital_device_type.SelectedIndex = p_device_type;

                        // デバイスタイプが設定値と異なる場合は、設定データを初期化
                        if (p_device_type != my_sw_datas.sw_datas[p_sw_no].sw_data[Constants.SW_DEVICE_DATA_SET_DEVICE_TYPE_IDX])
                        {
                            for (int fi = Constants.SW_DEVICE_DATA_SET_TYPE_IDX; fi < Constants.SW_DEVICE_DATA_LEN; fi++)
                            {
                                sw_disp_data[fi] = 0;
                            }
                        }
                        SW_DeviceType_selected = (byte)(p_device_type & 0xFF);

                        byte set_type = my_sw_datas.sw_datas[p_sw_no].sw_data[Constants.SW_DEVICE_DATA_SET_TYPE_IDX];
                        my_sw_setting_set_type_disp(p_sw_no, p_device_type, set_type, sw_disp_data);

                        this.cmbbx_digital_device_type.SelectedIndexChanged += new System.EventHandler(this.cmbbx_digital_device_type_SelectedIndexChanged);
                    }
                }
            }
            catch
            {
            }
        }

        private void my_sw_setting_set_type_disp(int p_sw_no, int p_device_type, int p_set_type, byte[] p_sw_data)
        {
            try
            {
                if (0 <= p_sw_no && p_sw_no < Constants.DIGITAL_INPUT_NUM)
                {
                    if (0 <= p_device_type && p_device_type < Constants.SW_SET_DEVICE_TYPE_NUM)
                    {
                        if (p_sw_data.Length == Constants.SW_DEVICE_DATA_LEN)
                        {
                            this.cmbbx_digital_assign.SelectedIndexChanged -= new System.EventHandler(this.cmbbx_digital_assign_SelectedIndexChanged);

                            switch (p_device_type)
                            {
                                case Constants.SW_SET_DEVICE_TYPE_NONE:
                                    cmbbx_digital_assign.Visible = false;
                                    lbl_sw_mouse_title1.Visible = false;
                                    MouseMove_UD.Visible = false;
                                    lbl_sw_mouse_title2.Visible = false;
                                    for (int fi = 0; fi < my_chkbx_keyboard_modifier.Length; fi++ )
                                    {
                                        my_chkbx_keyboard_modifier[fi].Visible = false;
                                    }
                                    KeyboardValue_txtbx.Visible = false;
                                    for (int fi = 0; fi < my_chkbx_joystick_lever.Length; fi++)
                                    {
                                        my_chkbx_joystick_lever[fi].Visible = false;
                                    }
                                    for (int fi = 0; fi < my_chkbx_joystick_hatsw.Length; fi++)
                                    {
                                        my_chkbx_joystick_hatsw[fi].Visible = false;
                                    }
                                    for (int fi = 0; fi < my_chkbx_joystick_button.Length; fi++)
                                    {
                                        my_chkbx_joystick_button[fi].Visible = false;
                                    }
                                    break;
                                case Constants.SW_SET_DEVICE_TYPE_MOUSE:
                                    //マウスデータセット
                                    cmbbx_digital_assign.SelectedIndex = p_set_type;
                                    cmbbx_digital_assign.Visible = true;
                                    switch (p_set_type)
                                    {
                                        case Constants.SW_SET_TYPE_MOUSE_LCLICK:
                                        case Constants.SW_SET_TYPE_MOUSE_RCLICK:
                                        case Constants.SW_SET_TYPE_MOUSE_WHCLICK:
                                        case Constants.SW_SET_TYPE_MOUSE_B4CLICK:
                                        case Constants.SW_SET_TYPE_MOUSE_B5CLICK:
                                            lbl_sw_mouse_title1.Visible = false;
                                            MouseMove_UD.Visible = false;
                                            lbl_sw_mouse_title2.Visible = false;
                                            break;
                                        case Constants.SW_SET_TYPE_MOUSE_MOVE_UP:
                                        case Constants.SW_SET_TYPE_MOUSE_MOVE_DOWN:
                                        case Constants.SW_SET_TYPE_MOUSE_MOVE_LEFT:
                                        case Constants.SW_SET_TYPE_MOUSE_MOVE_RIGHT:
                                        case Constants.SW_SET_TYPE_MOUSE_WHSCROLL_UP:
                                        case Constants.SW_SET_TYPE_MOUSE_WHSCROLL_DOWN:
                                        case Constants.SW_SET_TYPE_MOUSE_SPEED:
                                            if (MouseMove_UD.Minimum <= p_sw_data[Constants.SW_DEVICE_DATA_SENSE_IDX] && p_sw_data[Constants.SW_DEVICE_DATA_SENSE_IDX] <= MouseMove_UD.Maximum)
                                            {
                                                MouseMove_UD.Value = p_sw_data[Constants.SW_DEVICE_DATA_SENSE_IDX];
                                            }
                                            else
                                            {
                                                MouseMove_UD.Value = Constants.SENSITIVITY_DEFAULT;
                                            }
                                            lbl_sw_mouse_title1.Visible = true;
                                            MouseMove_UD.Visible = true;
                                            lbl_sw_mouse_title2.Visible = true;
                                            break;
                                    }
                                    //
                                    for (int fi = 0; fi < my_chkbx_keyboard_modifier.Length; fi++)
                                    {
                                        my_chkbx_keyboard_modifier[fi].Visible = false;
                                    }
                                    KeyboardValue_txtbx.Visible = false;
                                    for (int fi = 0; fi < my_chkbx_joystick_lever.Length; fi++)
                                    {
                                        my_chkbx_joystick_lever[fi].Visible = false;
                                    }
                                    for (int fi = 0; fi < my_chkbx_joystick_hatsw.Length; fi++)
                                    {
                                        my_chkbx_joystick_hatsw[fi].Visible = false;
                                    }
                                    for (int fi = 0; fi < my_chkbx_joystick_button.Length; fi++)
                                    {
                                        my_chkbx_joystick_button[fi].Visible = false;
                                    }
                                    break;
                                case Constants.SW_SET_DEVICE_TYPE_KEYBOARD:
                                    cmbbx_digital_assign.Visible = false;
                                    lbl_sw_mouse_title1.Visible = false;
                                    MouseMove_UD.Visible = false;
                                    lbl_sw_mouse_title2.Visible = false;
                                    // キーボード設定値セット
                                    for (int fi = 0; fi < my_chkbx_keyboard_modifier.Length; fi++)
                                    {
                                        if ((p_sw_data[Constants.SW_DEVICE_DATA_MODIFIER_IDX] & keyboard_modifier_bit[fi]) != 0)
                                        {
                                            my_chkbx_keyboard_modifier[fi].Checked = true;
                                        }
                                        else
                                        {
                                            my_chkbx_keyboard_modifier[fi].Checked = false;
                                        }
                                        my_chkbx_keyboard_modifier[fi].Visible = true;
                                    }
                                    // キー表示
                                    if (p_sw_data[Constants.SW_DEVICE_DATA_KEY1_IDX] == 0)
                                    {
                                        KeyboardValue_txtbx.Text = Constants.KEYBOARD_SET_KEY_EMPTY;
                                        KeyboardValue_selected = 0;
                                    }
                                    else
                                    {
                                        KeyboardValue_txtbx.Text = const_Key_Code.Get_KeyCode_Name(p_sw_data[Constants.SW_DEVICE_DATA_KEY1_IDX], Constants.KEYBOARD_TYPE_JA);
                                        KeyboardValue_selected = p_sw_data[Constants.SW_DEVICE_DATA_KEY1_IDX];
                                    }
                                    KeyboardValue_txtbx.Visible = true;
                                    //
                                    for (int fi = 0; fi < my_chkbx_joystick_lever.Length; fi++)
                                    {
                                        my_chkbx_joystick_lever[fi].Visible = false;
                                    }
                                    for (int fi = 0; fi < my_chkbx_joystick_hatsw.Length; fi++)
                                    {
                                        my_chkbx_joystick_hatsw[fi].Visible = false;
                                    }
                                    for (int fi = 0; fi < my_chkbx_joystick_button.Length; fi++)
                                    {
                                        my_chkbx_joystick_button[fi].Visible = false;
                                    }
                                    break;
                                case Constants.SW_SET_DEVICE_TYPE_JOYSTICK:
                                    cmbbx_digital_assign.Visible = false;
                                    lbl_sw_mouse_title1.Visible = false;
                                    MouseMove_UD.Visible = false;
                                    lbl_sw_mouse_title2.Visible = false;
                                    for (int fi = 0; fi < my_chkbx_keyboard_modifier.Length; fi++)
                                    {
                                        my_chkbx_keyboard_modifier[fi].Visible = false;
                                    }
                                    KeyboardValue_txtbx.Visible = false;
                                    // ジョイスティック設定値セット
                                    for (int fi = 0; fi < my_chkbx_joystick_lever.Length; fi++)
                                    {
                                        if ((p_sw_data[Constants.SW_DEVICE_DATA_LEVER1_IDX + joystick_lever_set_byte[fi]] & joystick_lever_set_bit[fi]) != 0)
                                        {
                                            my_chkbx_joystick_lever[fi].Checked = true;
                                        }
                                        else
                                        {
                                            my_chkbx_joystick_lever[fi].Checked = false;
                                        }
                                        my_chkbx_joystick_lever[fi].Visible = true;
                                    }
                                    for (int fi = 0; fi < my_chkbx_joystick_hatsw.Length; fi++)
                                    {
                                        if ((p_sw_data[Constants.SW_DEVICE_DATA_HATSW_IDX] & joystick_hatsw_set_bit[fi]) != 0)
                                        {
                                            my_chkbx_joystick_hatsw[fi].Checked = true;
                                        }
                                        else
                                        {
                                            my_chkbx_joystick_hatsw[fi].Checked = false;
                                        }
                                        my_chkbx_joystick_hatsw[fi].Visible = true;
                                    }
                                    for (int fi = 0; fi < my_chkbx_joystick_button.Length; fi++)
                                    {
                                        if ((p_sw_data[Constants.SW_DEVICE_DATA_BUTTON1_IDX + joystick_button_set_byte[fi]] & joystick_button_set_bit[fi]) != 0)
                                        {
                                            my_chkbx_joystick_button[fi].Checked = true;
                                        }
                                        else
                                        {
                                            my_chkbx_joystick_button[fi].Checked = false;
                                        }
                                        my_chkbx_joystick_button[fi].Visible = true;
                                    }
                                    //
                                    break;
                            }


                            this.cmbbx_digital_assign.SelectedIndexChanged += new System.EventHandler(this.cmbbx_digital_assign_SelectedIndexChanged);
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void my_an_setting_disp(bool p_visibled)
        {
            try
            {
                for (int an_no = 0; an_no < Constants.ANALOG_INPUT_NUM; an_no++)
                {

                    //my_lbl_an_status[an_no].Text = "";
                    my_lbl_an_assign[an_no].Text = "";
                    string str_device_type = "";
                    string str_assign = "";

                    switch (my_an_datas.an_datas[an_no].an_data[Constants.AN_DEVICE_DATA_SET_DEVICE_TYPE_IDX])
                    {
                        case Constants.AN_SET_DEVICE_TYPE_NONE:
                            str_device_type = analog_set_type_list[my_an_datas.an_datas[an_no].an_data[Constants.AN_DEVICE_DATA_SET_DEVICE_TYPE_IDX]];
                            my_lbl_an_assign[an_no].Text = analog_set_type_list[Constants.AN_SET_DEVICE_TYPE_NONE];
                            str_assign = analog_set_type_list[Constants.AN_SET_DEVICE_TYPE_NONE];
                            break;
                        case Constants.AN_SET_DEVICE_TYPE_X:
                        case Constants.AN_SET_DEVICE_TYPE_Y:
                        case Constants.AN_SET_DEVICE_TYPE_Z:
                        case Constants.AN_SET_DEVICE_TYPE_RX:
                        case Constants.AN_SET_DEVICE_TYPE_RY:
                        case Constants.AN_SET_DEVICE_TYPE_RZ:
                        case Constants.AN_SET_DEVICE_TYPE_SL:
                            str_device_type = analog_set_type_list[my_an_datas.an_datas[an_no].an_data[Constants.AN_DEVICE_DATA_SET_DEVICE_TYPE_IDX]];
                            my_lbl_an_assign[an_no].Text = analog_set_type_list[my_an_datas.an_datas[an_no].an_data[Constants.AN_DEVICE_DATA_SET_DEVICE_TYPE_IDX]];
                            
                            int temp_int1 = my_an_datas.an_datas[an_no].an_data[Constants.AN_DEVICE_DATA_VOL1HI_IDX];
                            temp_int1 = (temp_int1 << 8) + my_an_datas.an_datas[an_no].an_data[Constants.AN_DEVICE_DATA_VOL1LO_IDX];
                            double temp_dbl1 = temp_int1;
                            temp_dbl1 = temp_dbl1 / 100;
                            int temp_int2 = my_an_datas.an_datas[an_no].an_data[Constants.AN_DEVICE_DATA_VOL2HI_IDX];
                            temp_int2 = (temp_int2 << 8) + my_an_datas.an_datas[an_no].an_data[Constants.AN_DEVICE_DATA_VOL2LO_IDX];
                            double temp_dbl2 = temp_int2;
                            temp_dbl2 = temp_dbl2 / 100;
                            int temp_int3 = my_an_datas.an_datas[an_no].an_data[Constants.AN_DEVICE_DATA_VOL3HI_IDX];
                            temp_int3 = (temp_int3 << 8) + my_an_datas.an_datas[an_no].an_data[Constants.AN_DEVICE_DATA_VOL3LO_IDX];
                            double temp_dbl3 = temp_int3;
                            temp_dbl3 = temp_dbl3 / 100;
                            str_assign = string.Format(Constants.AN_LEVER_SETTING_FORMAT, Constants.ANALOG_LEVER_VOLTAGE_MIN, my_an_datas.an_datas[an_no].an_data[Constants.AN_DEVICE_DATA_0V_VAL_IDX]) + ", ";
                            str_assign += string.Format(Constants.AN_LEVER_SETTING_FORMAT, temp_dbl1, my_an_datas.an_datas[an_no].an_data[Constants.AN_DEVICE_DATA_VAL1_IDX]) + ", ";
                            str_assign += string.Format(Constants.AN_LEVER_SETTING_FORMAT, temp_dbl2, my_an_datas.an_datas[an_no].an_data[Constants.AN_DEVICE_DATA_VAL2_IDX]) + ", ";
                            str_assign += string.Format(Constants.AN_LEVER_SETTING_FORMAT, temp_dbl3, my_an_datas.an_datas[an_no].an_data[Constants.AN_DEVICE_DATA_VAL3_IDX]) + ", ";
                            str_assign += string.Format(Constants.AN_LEVER_SETTING_FORMAT, Constants.ANALOG_LEVER_VOLTAGE_MAX, my_an_datas.an_datas[an_no].an_data[Constants.AN_DEVICE_DATA_3V_VAL_IDX]);
                            break;
                        case Constants.AN_SET_DEVICE_TYPE_MOUSE_X:
                        case Constants.AN_SET_DEVICE_TYPE_MOUSE_Y:
                            str_device_type = analog_set_type_list[my_an_datas.an_datas[an_no].an_data[Constants.AN_DEVICE_DATA_SET_DEVICE_TYPE_IDX]];
                            str_assign = analog_set_type_list[my_an_datas.an_datas[an_no].an_data[Constants.AN_DEVICE_DATA_SET_DEVICE_TYPE_IDX]] + " " + string.Format(Constants.AN_MOUSE_SENSITIVITY, my_an_datas.an_datas[an_no].an_data[Constants.AN_DEVICE_DATA_SENSE_IDX]) + " " + string.Format(Constants.AN_MOUSE_DEAD_ZONE, (double)my_an_datas.an_datas[an_no].an_data[Constants.AN_DEVICE_DATA_DEADZONE_IDX]/100);
                            my_lbl_an_assign[an_no].Text = str_assign;
                            str_assign = string.Format(Constants.AN_MOUSE_SENSITIVITY, my_an_datas.an_datas[an_no].an_data[Constants.AN_DEVICE_DATA_SENSE_IDX]) + " " + string.Format(Constants.AN_MOUSE_DEAD_ZONE, (double)my_an_datas.an_datas[an_no].an_data[Constants.AN_DEVICE_DATA_DEADZONE_IDX]/100);
                            break;
                    }

                    listView1.Items[an_no].SubItems[Constants.SETTING_LIST_INDEX_DEVICE_TYPE].Text = str_device_type;
                    listView1.Items[an_no].SubItems[Constants.SETTING_LIST_INDEX_ASSIGN].Text = str_assign;
                }
            }
            catch
            {
            }
        }

        private void my_an_setting_pin_disp(int p_an_no, bool p_first_disp_flag)
        {
            try
            {
                if (0 <= p_an_no && p_an_no < Constants.ANALOG_INPUT_NUM && p_an_no < cmbbx_analog_pin.Items.Count)
                {
                    this.cmbbx_analog_pin.SelectedIndexChanged -= new System.EventHandler(this.cmbbx_analog_pin_SelectedIndexChanged);

                    pnl_analog_setting.Visible = true;
                    pnl_digital_setting.Visible = false;
                    ana_tabA_pb.Visible = true;
                    dig_tabA_pb.Visible = false;

                    my_an_pin_no_pic_a[an_selected].Visible = false;
                    my_an_pin_no_pic_a[p_an_no].Visible = true;
                    for (int fi = 0; fi < my_pin_no_pic_a.Length; fi++)
                    {
                        my_pin_no_pic_a[fi].Visible = false;
                    }

                    cmbbx_analog_pin.SelectedIndex = p_an_no;

                    if (an_selected != p_an_no || p_first_disp_flag == true)
                    {
                        for (int fi = 0; fi < Constants.AN_DEVICE_DATA_LEN; fi++)
                        {
                            an_disp_data[fi] = my_an_datas.an_datas[p_an_no].an_data[fi];
                        }
                    }
                    an_selected = p_an_no;


                    byte set_type = my_an_datas.an_datas[p_an_no].an_data[Constants.AN_DEVICE_DATA_SET_DEVICE_TYPE_IDX];
                    my_an_setting_set_type_disp(p_an_no, set_type, an_disp_data);

                    this.cmbbx_analog_pin.SelectedIndexChanged += new System.EventHandler(this.cmbbx_analog_pin_SelectedIndexChanged);
                }
            }
            catch
            {
            }
        }

        private void my_an_setting_set_type_disp(int p_an_no, int p_set_type, byte[] p_an_data)
        {
            try
            {
                if (0 <= p_an_no && p_an_no < Constants.ANALOG_INPUT_NUM)
                {
                    if (0 <= p_set_type && p_set_type < Constants.AN_SET_DEVICE_TYPE_NUM)
                    {
                        if (p_an_data.Length == Constants.AN_DEVICE_DATA_LEN)
                        {
                            this.cmbbx_analog_set_type.SelectedIndexChanged -= new System.EventHandler(this.cmbbx_analog_set_type_SelectedIndexChanged);

                            cmbbx_analog_set_type.SelectedIndex = p_set_type;

                            // デバイスタイプが設定値と異なる場合は、設定データを初期化
                            if (p_set_type != p_an_data[Constants.AN_DEVICE_DATA_SET_DEVICE_TYPE_IDX])
                            {
                                an_disp_data[Constants.AN_DEVICE_DATA_SET_DEVICE_TYPE_IDX] = (byte)(p_set_type & 0xFF);
                                switch (p_set_type)
                                {
                                    case Constants.AN_SET_DEVICE_TYPE_X:
                                    case Constants.AN_SET_DEVICE_TYPE_Y:
                                    case Constants.AN_SET_DEVICE_TYPE_Z:
                                    case Constants.AN_SET_DEVICE_TYPE_RX:
                                    case Constants.AN_SET_DEVICE_TYPE_RY:
                                    case Constants.AN_SET_DEVICE_TYPE_RZ:
                                    case Constants.AN_SET_DEVICE_TYPE_SL:
                                        for (int fi = Constants.AN_DEVICE_DATA_0V_VAL_IDX, set_idx = 0; fi < Constants.AN_DEVICE_DATA_LEN && set_idx < analog_lever_setting_default_value.Length; fi++, set_idx++)
                                        {
                                            an_disp_data[fi] = analog_lever_setting_default_value[set_idx];
                                        }
                                        break;
                                    case Constants.AN_SET_DEVICE_TYPE_MOUSE_X:
                                    case Constants.AN_SET_DEVICE_TYPE_MOUSE_Y:
                                        for (int fi = Constants.AN_DEVICE_DATA_0V_VAL_IDX, set_idx = 0; fi < Constants.AN_DEVICE_DATA_LEN && set_idx < analog_mouse_setting_default_value.Length; fi++, set_idx++)
                                        {
                                            an_disp_data[fi] = analog_mouse_setting_default_value[set_idx];
                                        }
                                        break;
                                    default:
                                        for (int fi = Constants.AN_DEVICE_DATA_0V_VAL_IDX; fi < Constants.AN_DEVICE_DATA_LEN; fi++)
                                        {
                                            an_disp_data[fi] = 0;
                                        }
                                        break;
                                }
                            }
                            an_set_type_select = (byte)(p_set_type & 0xFF);

                            switch (p_set_type)
                            {
                                case Constants.AN_SET_DEVICE_TYPE_NONE:
                                    lbl_analog_sensitivity.Visible = false;
                                    num_analog_sensitivity.Visible = false;
                                    lbl_input_voltage.Visible = false;
                                    lbl_output_val.Visible = false;
                                    lbl_input_vol1.Visible = false;
                                    lbl_input_vol5.Visible = false;
                                    num_input_vol2.Visible = false;
                                    num_input_vol3.Visible = false;
                                    num_input_vol4.Visible = false;
                                    num_output_val1.Visible = false;
                                    num_output_val2.Visible = false;
                                    num_output_val3.Visible = false;
                                    num_output_val4.Visible = false;
                                    num_output_val5.Visible = false;
                                    pic_analog_arrow1.Visible = false;
                                    pic_analog_arrow2.Visible = false;
                                    pic_analog_arrow3.Visible = false;
                                    pic_analog_arrow4.Visible = false;
                                    pic_analog_arrow5.Visible = false;
                                    chart1.Visible = false;
                                    chkbx_analog_calibration.Visible = false;
                                    gbx_analog_calibration.Visible = false;
                                    break;
                                case Constants.AN_SET_DEVICE_TYPE_X:
                                case Constants.AN_SET_DEVICE_TYPE_Y:
                                case Constants.AN_SET_DEVICE_TYPE_Z:
                                case Constants.AN_SET_DEVICE_TYPE_RX:
                                case Constants.AN_SET_DEVICE_TYPE_RY:
                                case Constants.AN_SET_DEVICE_TYPE_RZ:
                                case Constants.AN_SET_DEVICE_TYPE_SL:
                                    lbl_analog_sensitivity.Visible = false;
                                    num_analog_sensitivity.Visible = false;
                                    my_analog_lever_voltage_range_max_set();
                                    my_analog_lever_value_range_max_set();
                                    decimal dec_temp = 0;
                                    int int_temp = 0;
                                    int_temp = p_an_data[Constants.AN_DEVICE_DATA_VOL1HI_IDX];
                                    int_temp = (int_temp << 8) + p_an_data[Constants.AN_DEVICE_DATA_VOL1LO_IDX];
                                    dec_temp = int_temp;
                                    dec_temp = dec_temp / 100;
                                    num_input_vol2.Value = dec_temp;
                                    int_temp = p_an_data[Constants.AN_DEVICE_DATA_VOL2HI_IDX];
                                    int_temp = (int_temp << 8) + p_an_data[Constants.AN_DEVICE_DATA_VOL2LO_IDX];
                                    dec_temp = int_temp;
                                    dec_temp = dec_temp / 100;
                                    num_input_vol3.Value = dec_temp;
                                    int_temp = p_an_data[Constants.AN_DEVICE_DATA_VOL3HI_IDX];
                                    int_temp = (int_temp << 8) + p_an_data[Constants.AN_DEVICE_DATA_VOL3LO_IDX];
                                    dec_temp = int_temp;
                                    dec_temp = dec_temp / 100;
                                    num_input_vol4.Value = dec_temp;
                                    num_output_val1.Value = p_an_data[Constants.AN_DEVICE_DATA_0V_VAL_IDX];
                                    num_output_val2.Value = p_an_data[Constants.AN_DEVICE_DATA_VAL1_IDX];
                                    num_output_val3.Value = p_an_data[Constants.AN_DEVICE_DATA_VAL2_IDX];
                                    num_output_val4.Value = p_an_data[Constants.AN_DEVICE_DATA_VAL3_IDX];
                                    num_output_val5.Value = p_an_data[Constants.AN_DEVICE_DATA_3V_VAL_IDX];
                                    lbl_input_voltage.Visible = true;
                                    lbl_output_val.Visible = true;
                                    lbl_input_vol1.Visible = true;
                                    lbl_input_vol5.Visible = true;
                                    num_input_vol2.Visible = true;
                                    num_input_vol3.Visible = true;
                                    num_input_vol4.Visible = true;
                                    num_output_val1.Visible = true;
                                    num_output_val2.Visible = true;
                                    num_output_val3.Visible = true;
                                    num_output_val4.Visible = true;
                                    num_output_val5.Visible = true;
                                    pic_analog_arrow1.Visible = true;
                                    pic_analog_arrow2.Visible = true;
                                    pic_analog_arrow3.Visible = true;
                                    pic_analog_arrow4.Visible = true;
                                    pic_analog_arrow5.Visible = true;
                                    chart1.Visible = true;
                                    my_analog_lever_voltage_range_set();
                                    my_analog_lever_value_range_set();
                                    my_analog_lever_graph_update(num_output_val1.Value, num_output_val5.Value, num_input_vol2.Value, num_output_val2.Value, num_input_vol3.Value, num_output_val3.Value, num_input_vol4.Value, num_output_val4.Value);
                                    chkbx_analog_calibration.Visible = false;
                                    gbx_analog_calibration.Visible = false;
                                    break;
                                case Constants.AN_SET_DEVICE_TYPE_MOUSE_X:
                                case Constants.AN_SET_DEVICE_TYPE_MOUSE_Y:
                                    num_analog_sensitivity.Minimum = Constants.SENSITIVITY_MIN;
                                    num_analog_sensitivity.Maximum = Constants.SENSITIVITY_MAX;
                                    if (Constants.SENSITIVITY_MIN <= p_an_data[Constants.AN_DEVICE_DATA_SENSE_IDX] && p_an_data[Constants.AN_DEVICE_DATA_SENSE_IDX] <= Constants.SENSITIVITY_MAX)
                                    {
                                        num_analog_sensitivity.Value = p_an_data[Constants.AN_DEVICE_DATA_SENSE_IDX];
                                    }
                                    else
                                    {
                                        num_analog_sensitivity.Value = Constants.SENSITIVITY_DEFAULT;
                                    }
                                    lbl_analog_sensitivity.Visible = true;
                                    num_analog_sensitivity.Visible = true;
                                    lbl_input_voltage.Visible = false;
                                    lbl_output_val.Visible = false;
                                    lbl_input_vol1.Visible = false;
                                    lbl_input_vol5.Visible = false;
                                    num_input_vol2.Visible = false;
                                    num_input_vol3.Visible = false;
                                    num_input_vol4.Visible = false;
                                    num_output_val1.Visible = false;
                                    num_output_val2.Visible = false;
                                    num_output_val3.Visible = false;
                                    num_output_val4.Visible = false;
                                    num_output_val5.Visible = false;
                                    pic_analog_arrow1.Visible = false;
                                    pic_analog_arrow2.Visible = false;
                                    pic_analog_arrow3.Visible = false;
                                    pic_analog_arrow4.Visible = false;
                                    pic_analog_arrow5.Visible = false;
                                    chart1.Visible = false;
                                    chkbx_center_calibration.Checked = true;
                                    dec_temp = (decimal)Constants.DEAD_ZONE_MIN / 100;
                                    num_analog_dead_zone.Minimum = dec_temp;
                                    dec_temp = (decimal)Constants.DEAD_ZONE_MAX / 100;
                                    num_analog_dead_zone.Maximum = dec_temp;
                                    int_temp = p_an_data[Constants.AN_DEVICE_DATA_DEADZONE_IDX];
                                    dec_temp = int_temp;
                                    dec_temp = dec_temp / 100;
                                    if (num_analog_dead_zone.Minimum <= dec_temp && dec_temp <= num_analog_dead_zone.Maximum)
                                    {
                                        num_analog_dead_zone.Value = dec_temp;
                                    }
                                    else
                                    {
                                        dec_temp = (decimal)Constants.DEAD_ZONE_DEFAULT / 100;
                                        num_analog_dead_zone.Value = dec_temp;
                                    }
                                    gbx_analog_calibration.Enabled = false;
                                    gbx_analog_calibration.Visible = true;
                                    chkbx_analog_calibration.BringToFront();
                                    chkbx_analog_calibration.Checked = false;
                                    chkbx_analog_calibration.Visible = true;
                                    break;
                            }

                            this.cmbbx_analog_set_type.SelectedIndexChanged += new System.EventHandler(this.cmbbx_analog_set_type_SelectedIndexChanged);
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void cmbbx_analog_pin_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                my_an_setting_pin_disp(cmbbx_analog_pin.SelectedIndex, false);
            }
            catch
            {
            }
        }

        private void cmbbx_analog_set_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                an_set_type_select = cmbbx_analog_set_type.SelectedIndex;
                my_an_setting_set_type_disp(an_selected, an_set_type_select, an_disp_data);
            }
            catch
            {
            }
        }

        private void btn_soft_reset_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("ファームウェア書き換えを行いますか？この処理はマニュアルを読みながら行って下さい。", "ファームウェア書き換え", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if(dr == DialogResult.OK)
                {
                    b_soft_reset_req = true;
                }
            }
            catch
            {
            }
        }

        private void btn_default_reset_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("初期化を行います。実行しますか？", "初期化", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.Yes)
                {
                    b_default_set_req = true;
                    MessageBox.Show("実行後、USBケーブルを一旦抜き差しして下さい。", "初期化", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
            }
        }

        private void lbl_sw_assign_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                toolTip1.SetToolTip(((System.Windows.Forms.Label)sender), ((System.Windows.Forms.Label)sender).Text);
            }
            catch
            {
            }
        }

        private bool my_digital_setting_check()
        {
            bool ret_val = false;
            string error_msg = "";
            try
            {
                if (cmbbx_digital_device_type.SelectedIndex == SW_DeviceType_selected)
                {
                    switch (SW_DeviceType_selected)
                    {
                        case Constants.SW_SET_DEVICE_TYPE_NONE:
                            break;
                        case Constants.SW_SET_DEVICE_TYPE_MOUSE:
                            break;
                        case Constants.SW_SET_DEVICE_TYPE_KEYBOARD:
                            break;
                        case Constants.SW_SET_DEVICE_TYPE_JOYSTICK:
                            if ((my_chkbx_joystick_lever[Constants.LEVER_SWITCH_INDEX_X_P].Checked == true && my_chkbx_joystick_lever[Constants.LEVER_SWITCH_INDEX_X_M].Checked == true)
                                || (my_chkbx_joystick_lever[Constants.LEVER_SWITCH_INDEX_Y_P].Checked == true && my_chkbx_joystick_lever[Constants.LEVER_SWITCH_INDEX_Y_M].Checked == true)
                                || (my_chkbx_joystick_lever[Constants.LEVER_SWITCH_INDEX_Z_P].Checked == true && my_chkbx_joystick_lever[Constants.LEVER_SWITCH_INDEX_Z_M].Checked == true)
                                || (my_chkbx_joystick_lever[Constants.LEVER_SWITCH_INDEX_RX_P].Checked == true && my_chkbx_joystick_lever[Constants.LEVER_SWITCH_INDEX_RX_M].Checked == true)
                                || (my_chkbx_joystick_lever[Constants.LEVER_SWITCH_INDEX_RY_P].Checked == true && my_chkbx_joystick_lever[Constants.LEVER_SWITCH_INDEX_RY_M].Checked == true)
                                || (my_chkbx_joystick_lever[Constants.LEVER_SWITCH_INDEX_RZ_P].Checked == true && my_chkbx_joystick_lever[Constants.LEVER_SWITCH_INDEX_RZ_M].Checked == true))
                            {
                                ret_val = true;
                                error_msg += Constants.DIGITAL_SETUP_CHECK_ERROR_MSG_LEVER;
                            }
                            if ((my_chkbx_joystick_hatsw[Constants.HAT_SWITCH_INDEX_UP].Checked == true && my_chkbx_joystick_hatsw[Constants.HAT_SWITCH_INDEX_DOWN].Checked == true)
                                || (my_chkbx_joystick_hatsw[Constants.HAT_SWITCH_INDEX_RIGHT].Checked == true && my_chkbx_joystick_hatsw[Constants.HAT_SWITCH_INDEX_LEFT].Checked == true))
                            {
                                ret_val = true;
                                error_msg += Constants.DIGITAL_SETUP_CHECK_ERROR_MSG_HATSW;
                            }
                            break;
                    }

                    if (ret_val == true)
                    {
                        error_msg = Constants.DIGITAL_SETUP_CHECK_ERROR_MSG + error_msg;
                        MessageBox.Show(error_msg, Constants.APPLICATION_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch
            {
            }
            return ret_val;
        }

        // 画面表示内容を取得して設定データバッファに格納する
        private void my_digital_setting_get_by_disp(byte[] o_data_now)
        {
            try
            {
                if (cmbbx_digital_pin.SelectedIndex == sw_selected && cmbbx_digital_device_type.SelectedIndex == SW_DeviceType_selected)
                {
                    if (o_data_now.Length != Constants.SW_DEVICE_DATA_LEN)
                    {
                        o_data_now = new byte[Constants.SW_DEVICE_DATA_LEN];
                    }
                    o_data_now.Initialize();

                    switch (SW_DeviceType_selected)
                    {
                        case Constants.SW_SET_DEVICE_TYPE_NONE:
                            o_data_now[Constants.SW_DEVICE_DATA_SET_DEVICE_TYPE_IDX] = Constants.SW_SET_DEVICE_TYPE_NONE;
                            o_data_now[Constants.SW_DEVICE_DATA_SENSE_IDX] = Constants.SENSITIVITY_DEFAULT;
                            o_data_now[Constants.SW_DEVICE_DATA_SET_TYPE_IDX] = 0;
                            break;
                        case Constants.SW_SET_DEVICE_TYPE_MOUSE:
                            o_data_now[Constants.SW_DEVICE_DATA_SET_DEVICE_TYPE_IDX] = Constants.SW_SET_DEVICE_TYPE_MOUSE;
                            o_data_now[Constants.SW_DEVICE_DATA_SENSE_IDX] = (byte)((int)(MouseMove_UD.Value) & 0xFF);
                            o_data_now[Constants.SW_DEVICE_DATA_SET_TYPE_IDX] = (byte)(cmbbx_digital_assign.SelectedIndex & 0xFF);
                            break;
                        case Constants.SW_SET_DEVICE_TYPE_KEYBOARD:
                            o_data_now[Constants.SW_DEVICE_DATA_SET_DEVICE_TYPE_IDX] = Constants.SW_SET_DEVICE_TYPE_KEYBOARD;
                            o_data_now[Constants.SW_DEVICE_DATA_SENSE_IDX] = Constants.SENSITIVITY_DEFAULT;
                            o_data_now[Constants.SW_DEVICE_DATA_SET_TYPE_IDX] = 0;

                            o_data_now[Constants.SW_DEVICE_DATA_MODIFIER_IDX] = 0;
                            // モディファイがセットされているかチェックして、ビットセット
                            for (int fj = 0; fj < my_chkbx_keyboard_modifier.Length; fj++)
                            {
                                if (my_chkbx_keyboard_modifier[fj].Checked == true)
                                {
                                    o_data_now[Constants.SW_DEVICE_DATA_MODIFIER_IDX] |= keyboard_modifier_bit_4type[fj];
                                }
                            }
                            o_data_now[Constants.SW_DEVICE_DATA_KEY1_IDX] = KeyboardValue_selected;

                            break;
                        case Constants.SW_SET_DEVICE_TYPE_JOYSTICK:
                            o_data_now[Constants.SW_DEVICE_DATA_SET_DEVICE_TYPE_IDX] = Constants.SW_SET_DEVICE_TYPE_JOYSTICK;
                            o_data_now[Constants.SW_DEVICE_DATA_SENSE_IDX] = Constants.SENSITIVITY_DEFAULT;
                            o_data_now[Constants.SW_DEVICE_DATA_SET_TYPE_IDX] = 0;

                            o_data_now[Constants.SW_DEVICE_DATA_BUTTON1_IDX] = 0;
                            for (int fi = 0; fi < my_chkbx_joystick_button.Length; fi++)
                            {
                                if (my_chkbx_joystick_button[fi].Checked == true)
                                {
                                    o_data_now[Constants.SW_DEVICE_DATA_BUTTON1_IDX + joystick_button_set_byte[fi]] |= joystick_button_set_bit[fi];
                                }
                            }
                            o_data_now[Constants.SW_DEVICE_DATA_HATSW_IDX] = 0;
                            for (int fi = 0; fi < my_chkbx_joystick_hatsw.Length; fi++)
                            {
                                if (my_chkbx_joystick_hatsw[fi].Checked == true)
                                {
                                    o_data_now[Constants.SW_DEVICE_DATA_HATSW_IDX] |= joystick_hatsw_set_bit[fi];
                                }
                            }
                            o_data_now[Constants.SW_DEVICE_DATA_LEVER1_IDX] = 0;
                            for (int fi = 0; fi < my_chkbx_joystick_lever.Length; fi++ )
                            {
                                if (my_chkbx_joystick_lever[fi].Checked == true)
                                {
                                    o_data_now[Constants.SW_DEVICE_DATA_LEVER1_IDX + joystick_lever_set_byte[fi]] |= joystick_lever_set_bit[fi];
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            catch
            {
            }
        }

        private bool my_digital_data_change_check(byte[] p_data_org, byte[] p_data_now)
        {
            bool b_ret = false;
            try
            {
                if (p_data_org.Length == p_data_now.Length)
                {
                    for (int fi = 0; fi < p_data_org.Length; fi++)
                    {
                        if (p_data_org[fi] != p_data_now[fi])
                        {   // データ相違
                            b_ret = true;
                            break;
                        }
                    }
                }
            }
            catch
            {
            }
            return b_ret;
        }

        // 画面表示内容を取得して設定データバッファに格納する
        private void my_analog_setting_get_by_disp(byte[] o_data_now, byte[] o_data_new)
        {
            try
            {
                if (cmbbx_analog_pin.SelectedIndex == an_selected && cmbbx_analog_set_type.SelectedIndex == an_set_type_select && o_data_now.Length == Constants.AN_DEVICE_DATA_LEN)
                {
                    if (o_data_new.Length != Constants.AN_DEVICE_DATA_LEN)
                    {
                        o_data_new = new byte[Constants.AN_DEVICE_DATA_LEN];
                    }
                    o_data_new.Initialize();
                    // 現在値をコピー
                    for (int fi = 0; fi < Constants.AN_DEVICE_DATA_LEN; fi++ )
                    {
                        o_data_new[fi] = o_data_now[fi];
                    }

                    switch (an_set_type_select)
                    {
                        case Constants.AN_SET_DEVICE_TYPE_NONE:
                            o_data_new[Constants.AN_DEVICE_DATA_SET_DEVICE_TYPE_IDX] = (byte)(an_set_type_select & 0xFF);
                            o_data_new[Constants.AN_DEVICE_DATA_SENSE_IDX] = 0;
                            o_data_new[Constants.AN_DEVICE_DATA_SET_TYPE_IDX] = 0;
                            break;
                        case Constants.AN_SET_DEVICE_TYPE_X:
                        case Constants.AN_SET_DEVICE_TYPE_Y:
                        case Constants.AN_SET_DEVICE_TYPE_Z:
                        case Constants.AN_SET_DEVICE_TYPE_RX:
                        case Constants.AN_SET_DEVICE_TYPE_RY:
                        case Constants.AN_SET_DEVICE_TYPE_RZ:
                        case Constants.AN_SET_DEVICE_TYPE_SL:
                            o_data_new[Constants.AN_DEVICE_DATA_SET_DEVICE_TYPE_IDX] = (byte)(an_set_type_select & 0xFF);
                            o_data_new[Constants.AN_DEVICE_DATA_SENSE_IDX] = 0;
                            o_data_new[Constants.AN_DEVICE_DATA_SET_TYPE_IDX] = 0;

                            decimal dec_temp = 0;
                            int int_temp = 0;
                            dec_temp = num_input_vol2.Value;
                            dec_temp = dec_temp * 100;
                            int_temp = (int)dec_temp;
                            o_data_new[Constants.AN_DEVICE_DATA_VOL1HI_IDX] = (byte)((int_temp >> 8) & 0xFF);
                            o_data_new[Constants.AN_DEVICE_DATA_VOL1LO_IDX] = (byte)(int_temp & 0xFF);
                            dec_temp = num_input_vol3.Value;
                            dec_temp = dec_temp * 100;
                            int_temp = (int)dec_temp;
                            o_data_new[Constants.AN_DEVICE_DATA_VOL2HI_IDX] = (byte)((int_temp >> 8) & 0xFF);
                            o_data_new[Constants.AN_DEVICE_DATA_VOL2LO_IDX] = (byte)(int_temp & 0xFF);
                            dec_temp = num_input_vol4.Value;
                            dec_temp = dec_temp * 100;
                            int_temp = (int)dec_temp;
                            o_data_new[Constants.AN_DEVICE_DATA_VOL3HI_IDX] = (byte)((int_temp >> 8) & 0xFF);
                            o_data_new[Constants.AN_DEVICE_DATA_VOL3LO_IDX] = (byte)(int_temp & 0xFF);

                            dec_temp = num_output_val1.Value;
                            int_temp = (int)dec_temp;
                            o_data_new[Constants.AN_DEVICE_DATA_0V_VAL_IDX] = (byte)(int_temp & 0xFF);
                            dec_temp = num_output_val5.Value;
                            int_temp = (int)dec_temp;
                            o_data_new[Constants.AN_DEVICE_DATA_3V_VAL_IDX] = (byte)(int_temp & 0xFF);
                            dec_temp = num_output_val2.Value;
                            int_temp = (int)dec_temp;
                            o_data_new[Constants.AN_DEVICE_DATA_VAL1_IDX] = (byte)(int_temp & 0xFF);
                            dec_temp = num_output_val3.Value;
                            int_temp = (int)dec_temp;
                            o_data_new[Constants.AN_DEVICE_DATA_VAL2_IDX] = (byte)(int_temp & 0xFF);
                            dec_temp = num_output_val4.Value;
                            int_temp = (int)dec_temp;
                            o_data_new[Constants.AN_DEVICE_DATA_VAL3_IDX] = (byte)(int_temp & 0xFF);
                            break;
                        case Constants.AN_SET_DEVICE_TYPE_MOUSE_X:
                        case Constants.AN_SET_DEVICE_TYPE_MOUSE_Y:
                            o_data_new[Constants.AN_DEVICE_DATA_SET_DEVICE_TYPE_IDX] = (byte)(an_set_type_select & 0xFF);
                            o_data_new[Constants.AN_DEVICE_DATA_SENSE_IDX] = (byte)((int)(num_analog_sensitivity.Value) & 0xFF);
                            o_data_new[Constants.AN_DEVICE_DATA_SET_TYPE_IDX] = 0;
                            if (chkbx_analog_calibration.Checked == true)
                            {
                                dec_temp = num_analog_dead_zone.Value;
                                dec_temp = dec_temp * 100;
                                int_temp = (int)dec_temp;
                                o_data_new[Constants.AN_DEVICE_DATA_DEADZONE_IDX] = (byte)(int_temp & 0xFF);

                                if (chkbx_center_calibration.Checked == true)
                                {
                                    set_an_calibration_an_no = (byte)(an_selected & 0xFF);
                                    set_an_calibration_flag = true;
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            catch
            {
            }
        }

        private bool my_analog_data_change_check(byte[] p_data_org, byte[] p_data_now)
        {
            bool b_ret = false;
            try
            {
                if (p_data_org.Length == p_data_now.Length)
                {
                    for (int fi = 0; fi < p_data_org.Length; fi++)
                    {
                        if (p_data_org[fi] != p_data_now[fi])
                        {   // データ相違
                            b_ret = true;
                            break;
                        }
                    }

                    // キャリブレーションチェック
                    if (set_an_calibration_flag == true)
                    {
                        b_ret = true;
                    }
                }
            }
            catch
            {
            }
            return b_ret;
        }

        private void my_analog_lever_voltage_range_set()
        {
            try
            {
                this.num_input_vol2.ValueChanged -= new System.EventHandler(this.num_input_vol_ValueChanged);
                this.num_input_vol3.ValueChanged -= new System.EventHandler(this.num_input_vol_ValueChanged);
                this.num_input_vol4.ValueChanged -= new System.EventHandler(this.num_input_vol_ValueChanged);

                if (num_input_vol2.Value < (decimal)(Constants.ANALOG_LEVER_VOLTAGE_MIN + Constants.ANALOG_LEVER_VOLTAGE_INC))
                {
                    num_input_vol2.Value = (decimal)(Constants.ANALOG_LEVER_VOLTAGE_MIN + Constants.ANALOG_LEVER_VOLTAGE_INC);
                }
                num_input_vol2.Minimum = (decimal)(Constants.ANALOG_LEVER_VOLTAGE_MIN + Constants.ANALOG_LEVER_VOLTAGE_INC);
                if (num_input_vol2.Value > (num_input_vol3.Value - (decimal)Constants.ANALOG_LEVER_VOLTAGE_INC))
                {
                    num_input_vol2.Value = (num_input_vol3.Value - (decimal)Constants.ANALOG_LEVER_VOLTAGE_INC);
                }
                num_input_vol2.Maximum = (num_input_vol3.Value - (decimal)Constants.ANALOG_LEVER_VOLTAGE_INC);

                if (num_input_vol3.Value < (num_input_vol2.Value + (decimal)Constants.ANALOG_LEVER_VOLTAGE_INC))
                {
                    num_input_vol3.Value = (num_input_vol2.Value + (decimal)Constants.ANALOG_LEVER_VOLTAGE_INC);
                }
                num_input_vol3.Minimum = (num_input_vol2.Value + (decimal)Constants.ANALOG_LEVER_VOLTAGE_INC);
                if (num_input_vol3.Value > (num_input_vol4.Value - (decimal)Constants.ANALOG_LEVER_VOLTAGE_INC))
                {
                    num_input_vol3.Value = (num_input_vol4.Value - (decimal)Constants.ANALOG_LEVER_VOLTAGE_INC);
                }
                num_input_vol3.Maximum = (num_input_vol4.Value - (decimal)Constants.ANALOG_LEVER_VOLTAGE_INC);

                if (num_input_vol4.Value < (num_input_vol3.Value + (decimal)Constants.ANALOG_LEVER_VOLTAGE_INC))
                {
                    num_input_vol4.Value = (num_input_vol3.Value + (decimal)Constants.ANALOG_LEVER_VOLTAGE_INC);
                }
                num_input_vol4.Minimum = (num_input_vol3.Value + (decimal)Constants.ANALOG_LEVER_VOLTAGE_INC);
                if (num_input_vol4.Value > (decimal)(Constants.ANALOG_LEVER_VOLTAGE_MAX - Constants.ANALOG_LEVER_VOLTAGE_INC))
                {
                    num_input_vol4.Value = (decimal)(Constants.ANALOG_LEVER_VOLTAGE_MAX - Constants.ANALOG_LEVER_VOLTAGE_INC);
                }
                num_input_vol4.Maximum = (decimal)(Constants.ANALOG_LEVER_VOLTAGE_MAX - Constants.ANALOG_LEVER_VOLTAGE_INC);

                this.num_input_vol2.ValueChanged += new System.EventHandler(this.num_input_vol_ValueChanged);
                this.num_input_vol3.ValueChanged += new System.EventHandler(this.num_input_vol_ValueChanged);
                this.num_input_vol4.ValueChanged += new System.EventHandler(this.num_input_vol_ValueChanged);
            }
            catch
            {
            }
        }

        private void my_analog_lever_voltage_range_max_set()
        {
            try
            {
                this.num_input_vol2.ValueChanged -= new System.EventHandler(this.num_input_vol_ValueChanged);
                this.num_input_vol3.ValueChanged -= new System.EventHandler(this.num_input_vol_ValueChanged);
                this.num_input_vol4.ValueChanged -= new System.EventHandler(this.num_input_vol_ValueChanged);

                num_input_vol2.Minimum = (decimal)Constants.ANALOG_LEVER_VOLTAGE_MIN;
                num_input_vol2.Maximum = (decimal)Constants.ANALOG_LEVER_VOLTAGE_MAX;
                num_input_vol3.Minimum = (decimal)Constants.ANALOG_LEVER_VOLTAGE_MIN;
                num_input_vol3.Maximum = (decimal)Constants.ANALOG_LEVER_VOLTAGE_MAX;
                num_input_vol4.Minimum = (decimal)Constants.ANALOG_LEVER_VOLTAGE_MIN;
                num_input_vol4.Maximum = (decimal)Constants.ANALOG_LEVER_VOLTAGE_MAX;

                //this.num_input_vol2.ValueChanged += new System.EventHandler(this.num_input_vol_ValueChanged);
                //this.num_input_vol3.ValueChanged += new System.EventHandler(this.num_input_vol_ValueChanged);
                //this.num_input_vol4.ValueChanged += new System.EventHandler(this.num_input_vol_ValueChanged);
            }
            catch
            {
            }
        }

        private void my_analog_lever_value_range_set()
        {
            try
            {
#if false
                this.num_output_val1.ValueChanged -= new System.EventHandler(this.num_output_val_ValueChanged);
                this.num_output_val2.ValueChanged -= new System.EventHandler(this.num_output_val_ValueChanged);
                this.num_output_val3.ValueChanged -= new System.EventHandler(this.num_output_val_ValueChanged);
                this.num_output_val4.ValueChanged -= new System.EventHandler(this.num_output_val_ValueChanged);
                this.num_output_val5.ValueChanged -= new System.EventHandler(this.num_output_val_ValueChanged);

                num_output_val1.Minimum = Constants.ANALOG_LEVER_VALUE_MIN;
                if (num_output_val1.Value > num_output_val2.Value)
                {
                    num_output_val1.Value = num_output_val2.Value;
                }
                num_output_val1.Maximum = num_output_val2.Value;

                if (num_output_val2.Value < num_output_val1.Value)
                {
                    num_output_val2.Value = num_output_val1.Value;
                }
                num_output_val2.Minimum = num_output_val1.Value;
                if (num_output_val2.Value > num_output_val3.Value)
                {
                    num_output_val2.Value = num_output_val3.Value;
                }
                num_output_val2.Maximum = num_output_val3.Value;

                if (num_output_val3.Value < num_output_val2.Value)
                {
                    num_output_val3.Value = num_output_val2.Value;
                }
                num_output_val3.Minimum = num_output_val2.Value;
                if (num_output_val3.Value > num_output_val4.Value)
                {
                    num_output_val3.Value = num_output_val4.Value;
                }
                num_output_val3.Maximum = num_output_val4.Value;

                if (num_output_val4.Value < num_output_val3.Value)
                {
                    num_output_val4.Value = num_output_val3.Value;
                }
                num_output_val4.Minimum = num_output_val3.Value;
                if (num_output_val4.Value > num_output_val5.Value)
                {
                    num_output_val4.Value = num_output_val5.Value;
                }
                num_output_val4.Maximum = num_output_val5.Value;

                if (num_output_val5.Value < num_output_val4.Value)
                {
                    num_output_val5.Value = num_output_val4.Value;
                }
                num_output_val5.Minimum = num_output_val4.Value;
                num_output_val5.Maximum = Constants.ANALOG_LEVER_VALUE_MAX;

                this.num_output_val1.ValueChanged += new System.EventHandler(this.num_output_val_ValueChanged);
                this.num_output_val2.ValueChanged += new System.EventHandler(this.num_output_val_ValueChanged);
                this.num_output_val3.ValueChanged += new System.EventHandler(this.num_output_val_ValueChanged);
                this.num_output_val4.ValueChanged += new System.EventHandler(this.num_output_val_ValueChanged);
                this.num_output_val5.ValueChanged += new System.EventHandler(this.num_output_val_ValueChanged);
#endif
            }
            catch
            {
            }
        }

        private void my_analog_lever_value_range_max_set()
        {
            try
            {
                this.num_output_val1.ValueChanged -= new System.EventHandler(this.num_output_val_ValueChanged);
                this.num_output_val2.ValueChanged -= new System.EventHandler(this.num_output_val_ValueChanged);
                this.num_output_val3.ValueChanged -= new System.EventHandler(this.num_output_val_ValueChanged);
                this.num_output_val4.ValueChanged -= new System.EventHandler(this.num_output_val_ValueChanged);
                this.num_output_val5.ValueChanged -= new System.EventHandler(this.num_output_val_ValueChanged);

                num_output_val1.Minimum = Constants.ANALOG_LEVER_VALUE_MIN;
                num_output_val1.Maximum = Constants.ANALOG_LEVER_VALUE_MAX;
                num_output_val2.Minimum = Constants.ANALOG_LEVER_VALUE_MIN;
                num_output_val2.Maximum = Constants.ANALOG_LEVER_VALUE_MAX;
                num_output_val3.Minimum = Constants.ANALOG_LEVER_VALUE_MIN;
                num_output_val3.Maximum = Constants.ANALOG_LEVER_VALUE_MAX;
                num_output_val4.Minimum = Constants.ANALOG_LEVER_VALUE_MIN;
                num_output_val4.Maximum = Constants.ANALOG_LEVER_VALUE_MAX;
                num_output_val5.Minimum = Constants.ANALOG_LEVER_VALUE_MIN;
                num_output_val5.Maximum = Constants.ANALOG_LEVER_VALUE_MAX;

                this.num_output_val1.ValueChanged += new System.EventHandler(this.num_output_val_ValueChanged);
                this.num_output_val2.ValueChanged += new System.EventHandler(this.num_output_val_ValueChanged);
                this.num_output_val3.ValueChanged += new System.EventHandler(this.num_output_val_ValueChanged);
                this.num_output_val4.ValueChanged += new System.EventHandler(this.num_output_val_ValueChanged);
                this.num_output_val5.ValueChanged += new System.EventHandler(this.num_output_val_ValueChanged);
            }
            catch
            {
            }
        }

        private void my_analog_lever_graph_update(decimal p_0V_val, decimal p_3V3_val, decimal p_vol1, decimal p_val1, decimal p_vol2, decimal p_val2, decimal p_vol3, decimal p_val3)
        {
            try
            {
                chart1.Series[0].Points.Clear();
                chart1.Series[0].Points.AddXY(Constants.ANALOG_LEVER_VOLTAGE_MIN, p_0V_val);
                chart1.Series[0].Points.AddXY(p_vol1, p_val1);
                chart1.Series[0].Points.AddXY(p_vol2, p_val2);
                chart1.Series[0].Points.AddXY(p_vol3, p_val3);
                chart1.Series[0].Points.AddXY(Constants.ANALOG_LEVER_VOLTAGE_MAX, p_3V3_val);
            }
            catch
            {
            }
        }

        private void btn_debug_flash_read_Click(object sender, EventArgs e)
        {
            try
            {
                debug_eeprom_read_start_addr = Convert.ToUInt32(txtbx_debug_flash_read_addr.Text, 16);
                debug_eeprom_read_size = Convert.ToUInt32(txtbx_debug_flash_read_size.Text, 16);
                if (debug_eeprom_read_size < debug_eeprom_read_buff.Length
                    && (debug_eeprom_read_start_addr + debug_eeprom_read_size) <= EepromControl.E2P_TOTAL_SIZE)
                {
                    debug_eeprom_read_comp = false;
                    debug_eeprom_read_req = true;
                }
            }
            catch
            {
            }
        }

        private void num_input_vol_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                int idx = int.Parse(((NumericUpDown)sender).Tag.ToString());
                my_analog_lever_voltage_range_set();

                my_analog_lever_graph_update(num_output_val1.Value, num_output_val5.Value, num_input_vol2.Value, num_output_val2.Value, num_input_vol3.Value, num_output_val3.Value, num_input_vol4.Value, num_output_val4.Value);
            }
            catch
            {
            }
        }

        private void num_output_val_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                int idx = int.Parse(((NumericUpDown)sender).Tag.ToString());
                my_analog_lever_value_range_set();

                my_analog_lever_graph_update(num_output_val1.Value, num_output_val5.Value, num_input_vol2.Value, num_output_val2.Value, num_input_vol3.Value, num_output_val3.Value, num_input_vol4.Value, num_output_val4.Value);
            }
            catch
            {
            }
        }

        private void chkbx_analog_calibration_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkbx_analog_calibration.Checked == true)
                {
                    gbx_analog_calibration.Enabled = true;
                }
                else
                {
                    gbx_analog_calibration.Enabled = false;
                }
            }
            catch
            {
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count != 0)
                {
                    int idx = 0;
                    if (0 <= listView1.SelectedItems[0].Index && listView1.SelectedItems[0].Index < Constants.AN_SETTING_NUM)
                    {   // アナログセレクト
                        pnl_analog_setting.Visible = true;
                        pnl_digital_setting.Visible = false;
                        ana_tabA_pb.Visible = true;
                        dig_tabA_pb.Visible = false;
                        idx = listView1.SelectedItems[0].Index;
                        my_an_setting_pin_disp(idx, false);
                    }
                    else if (Constants.AN_SETTING_NUM <= listView1.SelectedItems[0].Index && listView1.SelectedItems[0].Index < (Constants.AN_SETTING_NUM + Constants.SW_SETTING_NUM))
                    {   // デジタルセレクト
                        pnl_digital_setting.Visible = true;
                        pnl_analog_setting.Visible = false;
                        ana_tabA_pb.Visible = false;
                        dig_tabA_pb.Visible = true;
                        idx = listView1.SelectedItems[0].Index - Constants.AN_SETTING_NUM;
                        my_sw_setting_pin_disp(idx, false);
                    }
                }
            }
            catch
            {
            }
        }

        private void ana_tabB_pb_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                pnl_analog_setting.Visible = true;
                pnl_digital_setting.Visible = false;
                ana_tabA_pb.Visible = true;
                dig_tabA_pb.Visible = false;

                my_an_setting_pin_disp(an_selected, false);
            }
            catch
            {
            }
        }

        private void dig_tabB_pb_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                pnl_digital_setting.Visible = true;
                pnl_analog_setting.Visible = false;
                ana_tabA_pb.Visible = false;
                dig_tabA_pb.Visible = true;

                my_sw_setting_pin_disp(sw_selected, false);
            }
            catch
            {
            }
        }





        //-------------------------------------------------------END CUT AND PASTE BLOCK-------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------
    } //public partial class Form1 : Form

    static class Constants
    {
        public const string APPLICATION_NAME = "Revive USB Advance Configuration Tool";

        public const int DIGITAL_INPUT_NUM = 15;
        public const int ANALOG_INPUT_NUM = 8;

        public const string FIRMWARE_VERSION_STR = "FW Version : ";    /* ファームウェアバージョン文字 */

        public const string KEYBOARD_SET_KEY_EMPTY = "キー入力";
        public const string SW_MOUSE_LABEL1 = "移動速度";
        public const string SW_MOUSE_LABEL2 = "遅 001 <-----> 100 速\n(Default = 50)";

        public const string SETUP_WRITE_CONFIRM_MSG = "設定を書き込みます。よろしいですか？";
        public const string DIGITAL_SETUP_CHECK_ERROR_MSG = "設定異常　設定を確認してください\n";
        public const string DIGITAL_SETUP_CHECK_ERROR_MSG_LEVER = "レバー設定異常\n";
        public const string DIGITAL_SETUP_CHECK_ERROR_MSG_HATSW = "HAT SW設定異常\n";

        public const string AN_LEVER_SETTING_FORMAT = "{0:0.00}={1}";
        public const string AN_MOUSE_SENSITIVITY = "感度={0}";
        public const string AN_MOUSE_DEAD_ZONE = "不感帯={0:0.00}";

        // グラフ
        public const double CHART_X_MIN = 0.0;
        public const double CHART_X_MAX = 3.3;
        public const double CHART_X_INTERVAL = 3.3;
        public const double CHART_Y_MIN = 0.0;
        public const double CHART_Y_MAX = 255;
        public const double CHART_Y_INTERVAL = 255;

        public const byte SENSITIVITY_MIN = 1;             /* 感度設定最小値 1 */
        public const byte SENSITIVITY_MAX = 100;           /* 感度設定最大値 100 */
        public const byte SENSITIVITY_DEFAULT = 50;        /* 感度デフォルト値 50 */
        public const byte DEAD_ZONE_MIN = 1;                /* 不感帯設定最小値 0.01V */
        public const byte DEAD_ZONE_MAX = 50;               /* 不感帯設定最大値 0.50V */
        public const byte DEAD_ZONE_DEFAULT = 5;            /* 不感帯デフォルト値 0.05V */

        public const double ANALOG_LEVER_VOLTAGE_MIN = 0.00;
        public const double ANALOG_LEVER_VOLTAGE_MAX = 3.30;
        public const double ANALOG_LEVER_VOLTAGE_INC = 0.01;
        public const byte ANALOG_LEVER_VALUE_MIN = 0x00;
        public const byte ANALOG_LEVER_VALUE_MAX = 0xFF;
        public const byte ANALOG_LEVER_VALUE_INC = 1;
        public const uint ANALOG_INPUT_MAX_VALUE = 0x3FF;
        public const uint ANALOG_INPUT_CENTER_DEFAULT_VALUE = 0x200;

        // SW 設定
        public const int SW_SETTING_NUM                         = 15;  // 設定数 15
        public const int SW_DEVICE_DATA_LEN                     = 16;   // SWデバイス設定データ長

        public const int SW_DEVICE_DATA_SET_DEVICE_TYPE_IDX     = 0;    // デバイス設定データ  デバイスタイプ格納位置
        public const int SW_DEVICE_DATA_SENSE_IDX               = 1;    // デバイス設定データ　感度調整格納位置
        public const int SW_DEVICE_DATA_SET_TYPE_IDX            = 2;    // デバイス設定データ  設定タイプ格納位置
        public const int SW_DEVICE_DATA_CLICK_IDX               = 3;    // デバイス設定データ　マウスデータ　クリックデータ格納位置
        public const int SW_DEVICE_DATA_X_MOVE_IDX              = 4;    // デバイス設定データ　マウスデータ　X移動量格納位置
        public const int SW_DEVICE_DATA_Y_MOVE_IDX              = 5;    // デバイス設定データ　マウスデータ　Y移動量格納位置
        public const int SW_DEVICE_DATA_WHEEL_IDX               = 6;    // デバイス設定データ　マウスデータ　ホイールスクロール量格納位置
        public const int SW_DEVICE_DATA_TILT_IDX                = 7;    // デバイス設定データ　マウスデータ　チルト移動量格納位置
        public const int SW_DEVICE_DATA_MODIFIER_IDX            = 3;    // デバイス設定データ　キーボードデータ　モディファイデータ格納位置
        public const int SW_DEVICE_DATA_KEY1_IDX                = 4;    // デバイス設定データ　キーボードデータ　キーデータ1格納位置
        public const int SW_DEVICE_DATA_KEY2_IDX                = 5;    // デバイス設定データ　キーボードデータ　キーデータ2格納位置
        public const int SW_DEVICE_DATA_KEY3_IDX                = 6;    // デバイス設定データ　キーボードデータ　キーデータ3格納位置
        public const int SW_DEVICE_DATA_KEY_DELAY_IDX           = 7;    // デバイス設定データ　キーボードデータ　キー入力遅延格納位置
        public const int SW_DEVICE_DATA_BUTTON1_IDX             = 3;    // デバイス設定データ　ジョイスティック　ボタンデータ1格納位置
        public const int SW_DEVICE_DATA_BUTTON2_IDX             = 4;    // デバイス設定データ　ジョイスティック　ボタンデータ2格納位置
        public const int SW_DEVICE_DATA_HATSW_IDX               = 5;    // デバイス設定データ　ジョイスティック　HATSWデータ格納位置
        public const int SW_DEVICE_DATA_LEVER1_IDX              = 6;    // デバイス設定データ　ジョイスティック　レバーデータ1格納位置
        public const int SW_DEVICE_DATA_LEVER2_IDX              = 7;    // デバイス設定データ　ジョイスティック　レバーデータ2格納位置

        public const int SW_SET_DEVICE_TYPE_NUM             = 4;    // 設定デバイスタイプ数
        public const int SW_SET_DEVICE_TYPE_NONE            = 0;    // 設定デバイスタイプ　なし
        public const int SW_SET_DEVICE_TYPE_MOUSE           = 1;    // 設定デバイスタイプ　マウス
        public const int SW_SET_DEVICE_TYPE_KEYBOARD        = 2;    // 設定デバイスタイプ　キーボード
        public const int SW_SET_DEVICE_TYPE_JOYSTICK        = 3;    // 設定デバイスタイプ　ジョイスティック

        public const int SW_SET_TYPE_MOUSE_NUM              = 12;   // 設定タイプ　マウス　設定数
        public const int SW_SET_TYPE_MOUSE_LCLICK           = 0;    // 設定タイプ　マウス　左クリック
        public const int SW_SET_TYPE_MOUSE_RCLICK           = 1;    // 設定タイプ　マウス　右クリック
        public const int SW_SET_TYPE_MOUSE_WHCLICK          = 2;    // 設定タイプ　マウス　ホイールクリック
        public const int SW_SET_TYPE_MOUSE_B4CLICK          = 3;    // 設定タイプ　マウス　ボタン4
        public const int SW_SET_TYPE_MOUSE_B5CLICK          = 4;    // 設定タイプ　マウス　ボタン5
        //public const int SW_SET_TYPE_MOUSE_DCLICK           = 5;    // 設定タイプ　マウス　ダブルクリック
        public const int SW_SET_TYPE_MOUSE_MOVE_UP          = 5;    // 設定タイプ　マウス　上移動
        public const int SW_SET_TYPE_MOUSE_MOVE_DOWN        = 6;    // 設定タイプ　マウス　下移動
        public const int SW_SET_TYPE_MOUSE_MOVE_LEFT        = 7;    // 設定タイプ　マウス　左移動
        public const int SW_SET_TYPE_MOUSE_MOVE_RIGHT       = 8;    // 設定タイプ　マウス　右移動
        public const int SW_SET_TYPE_MOUSE_WHSCROLL_UP      = 9;    // 設定タイプ　マウス　ホイールスクロール上
        public const int SW_SET_TYPE_MOUSE_WHSCROLL_DOWN    = 10;   // 設定タイプ　マウス　ホイールスクロール下
        public const int SW_SET_TYPE_MOUSE_SPEED            = 11;    // 設定タイプ　マウス　カーソル速度変更
        //public const int SW_SET_TYPE_MOUSE_TILT           = 13;    // 設定タイプ　マウス　チルト左
        //public const int SW_SET_TYPE_MOUSE_TILT_L         = 13;    // 設定タイプ　マウス　チルト左
        //public const int SW_SET_TYPE_MOUSE_TILT_R         = 14;    // 設定タイプ　マウス　チルト右
        public const int SW_SET_TYPE_KEYBOARD_NUM           = 1;    // 設定タイプ　キーボード　設定数
        public const int SW_SET_TYPE_KEYBOARD_KEY           = 0;    // 設定タイプ　キーボード　キー
        public const int SW_SET_TYPE_JOYSTICK_NUM           = 0;    // 設定タイプ　ジョイスティック　設定数
      
        public const byte HAT_SWITCH_BIT_NULL               = 0x00;
        public const byte HAT_SWITCH_BIT_NORTH              = 0x01;
        public const byte HAT_SWITCH_BIT_NORTH_EAST         = 0x02;
        public const byte HAT_SWITCH_BIT_EAST               = 0x04;
        public const byte HAT_SWITCH_BIT_SOUTH_EAST         = 0x08;
        public const byte HAT_SWITCH_BIT_SOUTH              = 0x10;
        public const byte HAT_SWITCH_BIT_SOUTH_WEST         = 0x20;
        public const byte HAT_SWITCH_BIT_WEST               = 0x40;
        public const byte HAT_SWITCH_BIT_NORTH_WEST         = 0x80;
  
        public const byte LEVER_SWITCH_BIT_X_P              = 0x01;
        public const byte LEVER_SWITCH_BIT_X_M              = 0x02;
        public const byte LEVER_SWITCH_BIT_Y_P              = 0x04;
        public const byte LEVER_SWITCH_BIT_Y_M              = 0x08;
        public const byte LEVER_SWITCH_BIT_Z_P              = 0x10;
        public const byte LEVER_SWITCH_BIT_Z_M              = 0x20;
        public const byte LEVER_SWITCH_BIT_RX_P             = 0x40;
        public const byte LEVER_SWITCH_BIT_RX_M             = 0x80;
        public const byte LEVER_SWITCH_BIT_RY_P             = 0x01;
        public const byte LEVER_SWITCH_BIT_RY_M             = 0x02;
        public const byte LEVER_SWITCH_BIT_RZ_P             = 0x04;
        public const byte LEVER_SWITCH_BIT_RZ_M             = 0x08;
        public const byte LEVER_SWITCH_BIT_SL_P             = 0x10;
        public const byte LEVER_SWITCH_BIT_SL_M             = 0x20;
        public const byte LEVER_SWITCH_BYTE_POS_X_P         = 0x00;
        public const byte LEVER_SWITCH_BYTE_POS_X_M         = 0x00;
        public const byte LEVER_SWITCH_BYTE_POS_Y_P         = 0x00;
        public const byte LEVER_SWITCH_BYTE_POS_Y_M         = 0x00;
        public const byte LEVER_SWITCH_BYTE_POS_Z_P         = 0x00;
        public const byte LEVER_SWITCH_BYTE_POS_Z_M         = 0x00;
        public const byte LEVER_SWITCH_BYTE_POS_RX_P        = 0x00;
        public const byte LEVER_SWITCH_BYTE_POS_RX_M        = 0x00;
        public const byte LEVER_SWITCH_BYTE_POS_RY_P        = 0x01;
        public const byte LEVER_SWITCH_BYTE_POS_RY_M        = 0x01;
        public const byte LEVER_SWITCH_BYTE_POS_RZ_P        = 0x01;
        public const byte LEVER_SWITCH_BYTE_POS_RZ_M        = 0x01;
        public const byte LEVER_SWITCH_BYTE_POS_SL_P        = 0x01;
        public const byte LEVER_SWITCH_BYTE_POS_SL_M        = 0x01;

        public const int LEVER_SWITCH_INDEX_X_P             = 0;
        public const int LEVER_SWITCH_INDEX_X_M             = 1;
        public const int LEVER_SWITCH_INDEX_Y_P             = 2;
        public const int LEVER_SWITCH_INDEX_Y_M             = 3;
        public const int LEVER_SWITCH_INDEX_Z_P             = 4;
        public const int LEVER_SWITCH_INDEX_Z_M             = 5;
        public const int LEVER_SWITCH_INDEX_RX_P            = 6;
        public const int LEVER_SWITCH_INDEX_RX_M            = 7;
        public const int LEVER_SWITCH_INDEX_RY_P            = 8;
        public const int LEVER_SWITCH_INDEX_RY_M            = 9;
        public const int LEVER_SWITCH_INDEX_RZ_P            = 10;
        public const int LEVER_SWITCH_INDEX_RZ_M            = 11;
        public const int HAT_SWITCH_INDEX_UP                = 0;
        public const int HAT_SWITCH_INDEX_RIGHT             = 1;
        public const int HAT_SWITCH_INDEX_DOWN              = 2;
        public const int HAT_SWITCH_INDEX_LEFT              = 3;

        // AN 設定
        public const int AN_SETTING_NUM                         = 8;  // 設定数 8
        public const int AN_DEVICE_DATA_LEN                     = 32;   // ANデバイス設定データ長

        public const int AN_DEVICE_DATA_SET_DEVICE_TYPE_IDX     = 0;    // デバイス設定データ  デバイスタイプ格納位置
        public const int AN_DEVICE_DATA_SENSE_IDX               = 1;    // デバイス設定データ　感度調整格納位置
        public const int AN_DEVICE_DATA_SET_TYPE_IDX            = 2;    // デバイス設定データ  設定タイプ格納位置
        public const int AN_DEVICE_DATA_CENTER_VAL_HI_IDX       = 3;    // デバイス設定データ  中立位置HI格納位置
        public const int AN_DEVICE_DATA_CENTER_VAL_LO_IDX       = 4;    // デバイス設定データ  中立位置LO格納位置
        public const int AN_DEVICE_DATA_0V_VAL_IDX              = 5;    // デバイス設定データ　0V時の出力データ格納位置
        public const int AN_DEVICE_DATA_3V_VAL_IDX              = 6;    // デバイス設定データ　3V時の出力データ格納位置
        public const int AN_DEVICE_DATA_VOL1HI_IDX              = 7;    // デバイス設定データ　変換電圧1HI格納位置
        public const int AN_DEVICE_DATA_VOL1LO_IDX              = 8;    // デバイス設定データ　変換電圧1LO格納位置
        public const int AN_DEVICE_DATA_VAL1_IDX                = 9;    // デバイス設定データ　出力値1格納位置
        public const int AN_DEVICE_DATA_VOL2HI_IDX              = 10;    // デバイス設定データ　変換電圧2HI格納位置
        public const int AN_DEVICE_DATA_VOL2LO_IDX              = 11;    // デバイス設定データ　変換電圧2LO格納位置
        public const int AN_DEVICE_DATA_VAL2_IDX                = 12;    // デバイス設定データ　出力値2格納位置
        public const int AN_DEVICE_DATA_VOL3HI_IDX              = 13;    // デバイス設定データ　変換電圧3HI格納位置
        public const int AN_DEVICE_DATA_VOL3LO_IDX              = 14;    // デバイス設定データ　変換電圧3LO格納位置
        public const int AN_DEVICE_DATA_VAL3_IDX                = 15;    // デバイス設定データ　出力値3格納位置
        public const int AN_DEVICE_DATA_DEADZONE_IDX            = 16;    // デバイス設定データ　不感帯格納位置

        public const int AN_SET_DEVICE_TYPE_NUM                 = 10;    // 設定デバイスタイプ数
        public const int AN_SET_DEVICE_TYPE_NONE                = 0;    // 設定デバイスタイプ　なし
        public const int AN_SET_DEVICE_TYPE_X                   = 1;    // 設定デバイスタイプ　ジョイスティックX
        public const int AN_SET_DEVICE_TYPE_Y                   = 2;    // 設定デバイスタイプ　ジョイスティックY
        public const int AN_SET_DEVICE_TYPE_Z                   = 3;    // 設定デバイスタイプ　ジョイスティックZ
        public const int AN_SET_DEVICE_TYPE_RX                  = 4;    // 設定デバイスタイプ　ジョイスティックRX
        public const int AN_SET_DEVICE_TYPE_RY                  = 5;    // 設定デバイスタイプ　ジョイスティックRY
        public const int AN_SET_DEVICE_TYPE_RZ                  = 6;    // 設定デバイスタイプ　ジョイスティックRZ
        public const int AN_SET_DEVICE_TYPE_SL                  = 7;    // 設定デバイスタイプ　ジョイスティックSL
        public const int AN_SET_DEVICE_TYPE_MOUSE_X             = 8;    // 設定デバイスタイプ　マウスX
        public const int AN_SET_DEVICE_TYPE_MOUSE_Y             = 9;    // 設定デバイスタイプ　マウスY

        // 設定リスト
        public const int SETTING_LIST_INDEX_ID                  = 0; // 設定リスト IDインデックス
        public const int SETTING_LIST_INDEX_PIN_NO              = 1; // 設定リスト PIN NOインデックス
        //public const int SETTING_LIST_INDEX_VALUE               = 2; // 設定リスト 値インデックス
        public const int SETTING_LIST_INDEX_DEVICE_TYPE         = 2; // 設定リスト デバイスタイプインデックス
        public const int SETTING_LIST_INDEX_ASSIGN              = 3; // 設定リスト アサインインデックス


        public const byte USB_KEY_CODE_CTRL_L = 0xE0;      // USBキーコード ctrl left
        public const byte USB_KEY_CODE_CTRL_R = 0xE4;      // USBキーコード ctrl right
        public const byte USB_KEY_CODE_SHIFT_L = 0xE1;      // USBキーコード shift left
        public const byte USB_KEY_CODE_SHIFT_R = 0xE5;      // USBキーコード shift right
        public const byte USB_KEY_CODE_ALT_L = 0xE2;      // USBキーコード alt left
        public const byte USB_KEY_CODE_ALT_R = 0xE6;      // USBキーコード alt right
        public const byte USB_KEY_CODE_WIN_L = 0xE3;      // USBキーコード win left
        public const byte USB_KEY_CODE_WIN_R = 0xE7;      // USBキーコード win right

        public const byte KEYBOARD_TYPE_NUM = 2;
        public const byte KEYBOARD_TYPE_US = 0;
        public const byte KEYBOARD_TYPE_JA = 1;
    }


    class KeyCode
    {
        // DLLをインポートする必要がある
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern short GetKeyState(int nVirtKey);

        public byte Get_VKtoUSBkey(int p_VK_Code, byte p_keyboard_type, bool p_LR_flag)
        {
            byte ret_val = 0;
            try
            {
                if (0 <= p_VK_Code && p_VK_Code < VKtoUSBkey.Length)
                {
                    if (p_keyboard_type == Constants.KEYBOARD_TYPE_JA)
                    {
                        ret_val = VKtoUSBkey[p_VK_Code];
                    }
                    else
                    {
                        ret_val = VKtoUSBkey_US[p_VK_Code];
                    }
                }

#if true
                if (p_LR_flag == true)
                {   // 左右キーを判別

                    // 左右キーの判定
                    if (ret_val == Constants.USB_KEY_CODE_CTRL_L)
                    {   // Ctrl key
                        int tmp_int = GetKeyState((int)Keys.RControlKey);
                        if (tmp_int < 0)
                        {   // 右shift?
                            ret_val = Constants.USB_KEY_CODE_CTRL_R;
                        }
                    }
                    else if (ret_val == Constants.USB_KEY_CODE_SHIFT_L)
                    {   // Shift key
                        int tmp_int = GetKeyState((int)Keys.RShiftKey);
                        if (tmp_int < 0)
                        {   // 右shift?
                            ret_val = Constants.USB_KEY_CODE_SHIFT_R;
                        }
                    }
                    else if (ret_val == Constants.USB_KEY_CODE_ALT_L)
                    {   // Alt key
                        int tmp_int = GetKeyState((int)Keys.RMenu);
                        if (tmp_int < 0)
                        {   // 右shift?
                            ret_val = Constants.USB_KEY_CODE_ALT_R;
                        }
                    }
                    else if (ret_val == Constants.USB_KEY_CODE_WIN_L)
                    {   // Win key
                        int tmp_int = GetKeyState((int)Keys.RWin);
                        if (tmp_int < 0)
                        {   // 右shift?
                            ret_val = Constants.USB_KEY_CODE_WIN_R;
                        }
                    }
                }

#endif
            }
            catch
            {
            }
            return ret_val;
        }
        public string Get_KeyCode_Name(byte p_usb_key_code, byte p_keyboard_type)
        {
            string ret_key_name = "";
            try
            {
                if (p_keyboard_type == Constants.KEYBOARD_TYPE_JA)
                {
                    ret_key_name = USB_KeyCode_Name[p_usb_key_code];
                }
                else
                {
                    ret_key_name = USB_KeyCode_Name_US[p_usb_key_code];
                }
            }
            catch
            {
            }
            return ret_key_name;
        }

        //バーチャルキーコードとUSBキーコードの変換用配列
        byte[] VKtoUSBkey = new byte[256]{
            0x00,   //0
            0x00,   //1
            0x00,   //2
            0x00,   //3
            0x00,   //4
            0x00,   //5
            0x00,   //6
            0x00,   //7
            0x2A,   //8
            0x2B,   //9
            0x00,   //10
            0x00,   //11
            0x00,   //12
            0x28,   //13
            0x00,   //14
            0x00,   //15
            0xE1,   //16
            0xE0,   //17
            0xE2,   //18
            0x48,   //19
            0x39,   //20
            0x88,   //21
            0x00,   //22
            0x00,   //23
            0x00,   //24
            0x35,   //25
            0x00,   //26
            0x29,   //27
            0x8A,   //28
            0x8B,   //29
            0x00,   //30
            0x00,   //31
            0x2C,   //32
            0x4B,   //33
            0x4E,   //34
            0x4D,   //35
            0x4A,   //36
            0x50,   //37
            0x52,   //38
            0x4F,   //39
            0x51,   //40
            0x00,   //41
            0x00,   //42
            0x00,   //43
            0x46,   //44
            0x49,   //45
            0x4C,   //46
            0x00,   //47
            0x27,   //48
            0x1E,   //49
            0x1F,   //50
            0x20,   //51
            0x21,   //52
            0x22,   //53
            0x23,   //54
            0x24,   //55
            0x25,   //56
            0x26,   //57
            0x00,   //58
            0x00,   //59
            0x00,   //60
            0x00,   //61
            0x00,   //62
            0x00,   //63
            0x00,   //64
            0x04,   //65
            0x05,   //66
            0x06,   //67
            0x07,   //68
            0x08,   //69
            0x09,   //70
            0x0A,   //71
            0x0B,   //72
            0x0C,   //73
            0x0D,   //74
            0x0E,   //75
            0x0F,   //76
            0x10,   //77
            0x11,   //78
            0x12,   //79
            0x13,   //80
            0x14,   //81
            0x15,   //82
            0x16,   //83
            0x17,   //84
            0x18,   //85
            0x19,   //86
            0x1A,   //87
            0x1B,   //88
            0x1C,   //89
            0x1D,   //90
            0xE3,   //91
            0xE7,   //92
            0x65,   //93
            0x00,   //94
            0x00,   //95
            0x62,   //96
            0x59,   //97
            0x5A,   //98
            0x5B,   //99
            0x5C,   //100
            0x5D,   //101
            0x5E,   //102
            0x5F,   //103
            0x60,   //104
            0x61,   //105
            0x55,   //106
            0x57,   //107
            0x85,   //108
            0x56,   //109
            0x63,   //110
            0x54,   //111
            0x3A,   //112
            0x3B,   //113
            0x3C,   //114
            0x3D,   //115
            0x3E,   //116
            0x3F,   //117
            0x40,   //118
            0x41,   //119
            0x42,   //120
            0x43,   //121
            0x44,   //122
            0x45,   //123
            0x68,   //124
            0x69,   //125
            0x6A,   //126
            0x6B,   //127
            0x6C,   //128
            0x6D,   //129
            0x6E,   //130
            0x6F,   //131
            0x70,   //132
            0x71,   //133
            0x72,   //134
            0x73,   //135
            0x00,   //136
            0x00,   //137
            0x00,   //138
            0x00,   //139
            0x00,   //140
            0x00,   //141
            0x00,   //142
            0x00,   //143
            0x53,   //144
            0x47,   //145
            0x67,   //146
            0x00,   //147
            0x00,   //148
            0x00,   //149
            0x00,   //150
            0x00,   //151
            0x00,   //152
            0x00,   //153
            0x00,   //154
            0x00,   //155
            0x00,   //156
            0x00,   //157
            0x00,   //158
            0x00,   //159
            0xE1,   //160
            0xE5,   //161
            0xE0,   //162
            0xE4,   //163
            0xE2,   //164
            0xE6,   //165
            0x00,   //166
            0x00,   //167
            0x00,   //168
            0x00,   //169
            0x00,   //170
            0x00,   //171
            0x00,   //172
            0x00,   //173
            0x00,   //174
            0x00,   //175
            0x00,   //176
            0x00,   //177
            0x00,   //178
            0x00,   //179
            0x00,   //180
            0x00,   //181
            0x00,   //182
            0x00,   //183
            0x00,   //184
            0x00,   //185
            0x34,   //186
            0x33,   //187
            0x36,   //188
            0x2D,   //189
            0x37,   //190
            0x38,   //191
            0x2F,   //192
            0x00,   //193
            0x00,   //194
            0x00,   //195
            0x00,   //196
            0x00,   //197
            0x00,   //198
            0x00,   //199
            0x00,   //200
            0x00,   //201
            0x00,   //202
            0x00,   //203
            0x00,   //204
            0x00,   //205
            0x00,   //206
            0x00,   //207
            0x00,   //208
            0x00,   //209
            0x00,   //210
            0x00,   //211
            0x00,   //212
            0x00,   //213
            0x00,   //214
            0x00,   //215
            0x00,   //216
            0x00,   //217
            0x00,   //218
            0x30,   //219
            0x89,   //220
            0x32,   //221
            0x2E,   //222
            0x00,   //223
            0x00,   //224
            0x00,   //225
            0x87,   //226
            0x00,   //227
            0x00,   //228
            0x00,   //229
            0x00,   //230
            0x00,   //231
            0x00,   //232
            0x00,   //233
            0x00,   //234
            0x00,   //235
            0x00,   //236
            0x00,   //237
            0x00,   //238
            0x00,   //239
            0x39,   //240
            0x00,   //241
            0x39,   //242
            0x35,   //243
            0x35,   //244
            0x00,   //245
            0x00,   //246
            0x00,   //247
            0x00,   //248
            0x00,   //249
            0x00,   //250
            0x00,   //251
            0x00,   //252
            0x00,   //253
            0x00,   //254
            0x00,   //255
       };
        // USキーボード
        private byte[] VKtoUSBkey_US = new byte[256]{
            0x00,   //0
            0x00,   //1
            0x00,   //2
            0x00,   //3
            0x00,   //4
            0x00,   //5
            0x00,   //6
            0x00,   //7
            0x2A,   //8
            0x2B,   //9
            0x00,   //10
            0x00,   //11
            0x00,   //12
            0x28,   //13
            0x00,   //14
            0x00,   //15
            0xE1,   //16
            0xE0,   //17
            0xE2,   //18
            0x48,   //19
            0x39,   //20
            0x88,   //21
            0x00,   //22
            0x00,   //23
            0x00,   //24
            0x35,   //25
            0x00,   //26
            0x29,   //27
            0x8A,   //28
            0x8B,   //29
            0x00,   //30
            0x00,   //31
            0x2C,   //32
            0x4B,   //33
            0x4E,   //34
            0x4D,   //35
            0x4A,   //36
            0x50,   //37
            0x52,   //38
            0x4F,   //39
            0x51,   //40
            0x00,   //41
            0x00,   //42
            0x00,   //43
            0x46,   //44
            0x49,   //45
            0x4C,   //46
            0x00,   //47
            0x27,   //48
            0x1E,   //49
            0x1F,   //50
            0x20,   //51
            0x21,   //52
            0x22,   //53
            0x23,   //54
            0x24,   //55
            0x25,   //56
            0x26,   //57
            0x00,   //58
            0x00,   //59
            0x00,   //60
            0x00,   //61
            0x00,   //62
            0x00,   //63
            0x00,   //64
            0x04,   //65
            0x05,   //66
            0x06,   //67
            0x07,   //68
            0x08,   //69
            0x09,   //70
            0x0A,   //71
            0x0B,   //72
            0x0C,   //73
            0x0D,   //74
            0x0E,   //75
            0x0F,   //76
            0x10,   //77
            0x11,   //78
            0x12,   //79
            0x13,   //80
            0x14,   //81
            0x15,   //82
            0x16,   //83
            0x17,   //84
            0x18,   //85
            0x19,   //86
            0x1A,   //87
            0x1B,   //88
            0x1C,   //89
            0x1D,   //90
            0xE3,   //91
            0xE7,   //92
            0x65,   //93
            0x00,   //94
            0x00,   //95
            0x62,   //96
            0x59,   //97
            0x5A,   //98
            0x5B,   //99
            0x5C,   //100
            0x5D,   //101
            0x5E,   //102
            0x5F,   //103
            0x60,   //104
            0x61,   //105
            0x55,   //106
            0x57,   //107
            0x85,   //108
            0x56,   //109
            0x63,   //110
            0x54,   //111
            0x3A,   //112
            0x3B,   //113
            0x3C,   //114
            0x3D,   //115
            0x3E,   //116
            0x3F,   //117
            0x40,   //118
            0x41,   //119
            0x42,   //120
            0x43,   //121
            0x44,   //122
            0x45,   //123
            0x68,   //124
            0x69,   //125
            0x6A,   //126
            0x6B,   //127
            0x6C,   //128
            0x6D,   //129
            0x6E,   //130
            0x6F,   //131
            0x70,   //132
            0x71,   //133
            0x72,   //134
            0x73,   //135
            0x00,   //136
            0x00,   //137
            0x00,   //138
            0x00,   //139
            0x00,   //140
            0x00,   //141
            0x00,   //142
            0x00,   //143
            0x53,   //144
            0x47,   //145
            0x67,   //146
            0x00,   //147
            0x00,   //148
            0x00,   //149
            0x00,   //150
            0x00,   //151
            0x00,   //152
            0x00,   //153
            0x00,   //154
            0x00,   //155
            0x00,   //156
            0x00,   //157
            0x00,   //158
            0x00,   //159
            0xE1,   //160
            0xE5,   //161
            0xE0,   //162
            0xE4,   //163
            0xE2,   //164
            0xE6,   //165
            0x00,   //166
            0x00,   //167
            0x00,   //168
            0x00,   //169
            0x00,   //170
            0x00,   //171
            0x00,   //172
            0x00,   //173
            0x00,   //174
            0x00,   //175
            0x00,   //176
            0x00,   //177
            0x00,   //178
            0x00,   //179
            0x00,   //180
            0x00,   //181
            0x00,   //182
            0x00,   //183
            0x00,   //184
            0x00,   //185
            0x33,   //186
            0x2E,   //187
            0x36,   //188
            0x2D,   //189
            0x37,   //190
            0x38,   //191
            0x35,   //192
            0x00,   //193
            0x00,   //194
            0x00,   //195
            0x00,   //196
            0x00,   //197
            0x00,   //198
            0x00,   //199
            0x00,   //200
            0x00,   //201
            0x00,   //202
            0x00,   //203
            0x00,   //204
            0x00,   //205
            0x00,   //206
            0x00,   //207
            0x00,   //208
            0x00,   //209
            0x00,   //210
            0x00,   //211
            0x00,   //212
            0x00,   //213
            0x00,   //214
            0x00,   //215
            0x00,   //216
            0x00,   //217
            0x00,   //218
            0x2F,   //219
            0x31,   //220
            0x30,   //221
            0x34,   //222
            0x00,   //223
            0x00,   //224
            0x00,   //225
            0x87,   //226
            0x00,   //227
            0x00,   //228
            0x35,   //229
            0x00,   //230
            0x00,   //231
            0x00,   //232
            0x00,   //233
            0x00,   //234
            0x00,   //235
            0x00,   //236
            0x00,   //237
            0x00,   //238
            0x00,   //239
            0x39,   //240
            0x00,   //241
            0x39,   //242
            0x35,   //243
            0x35,   //244
            0x00,   //245
            0x00,   //246
            0x00,   //247
            0x00,   //248
            0x00,   //249
            0x00,   //250
            0x00,   //251
            0x00,   //252
            0x00,   //253
            0x00,   //254
            0x00,   //255
       };
#if true
        //USBキーコードの名称配列
        public string[] USB_KeyCode_Name = new string[256]{
            "",   //0
            "",   //1
            "",   //2
            "",   //3
            "A",   //4
            "B",   //5
            "C",   //6
            "D",   //7
            "E",   //8
            "F",   //9
            "G",   //10
            "H",   //11
            "I",   //12
            "J",   //13
            "K",   //14
            "L",   //15
            "M",   //16
            "N",   //17
            "O",   //18
            "P",   //19
            "Q",   //20
            "R",   //21
            "S",   //22
            "T",   //23
            "U",   //24
            "V",   //25
            "W",   //26
            "X",   //27
            "Y",   //28
            "Z",   //29
            "1",   //30
            "2",   //31
            "3",   //32
            "4",   //33
            "5",   //34
            "6",   //35
            "7",   //36
            "8",   //37
            "9",   //38
            "0",   //39
            "Enter",   //40
            "ESC",   //41
            "BS",   //42
            "Tab",   //43
            "Space",   //44
            "-",   //45
            "^",   //46
            "@",   //47
            "[",   //48
            "",   //49
            "]",   //50
            ";",   //51
            ":",   //52
            "ZenHan",   //53
            ",",   //54
            ".",   //55
            "/",   //56
            "CapsLK",   //57
            "F1",   //58
            "F2",   //59
            "F3",   //60
            "F4",   //61
            "F5",   //62
            "F6",   //63
            "F7",   //64
            "F8",   //65
            "F9",   //66
            "F10",   //67
            "F11",   //68
            "F12",   //69
            "PrtSC",   //70
            "ScLK",   //71
            "Pause",   //72
            "Insert",   //73
            "Home",   //74
            "pgUp",   //75
            "Delete",   //76
            "End",   //77
            "pgDown",   //78
            "→",   //79
            "←",   //80
            "↓",   //81
            "↑",   //82
            "NumLK",   //83
            "Num/",   //84
            "Num*",   //85
            "Num-",   //86
            "Num+",   //87
            "NumENT",   //88
            "Num1",   //89
            "Num2",   //90
            "Num3",   //91
            "Num4",   //92
            "Num5",   //93
            "Num6",   //94
            "Num7",   //95
            "Num8",   //96
            "Num9",   //97
            "Num0",   //98
            "Num.",   //99
            "",   //100
            "Menu",   //101
            "",   //102
            "",   //103
            "",   //104
            "",   //105
            "",   //106
            "",   //107
            "",   //108
            "",   //109
            "",   //110
            "",   //111
            "",   //112
            "",   //113
            "",   //114
            "",   //115
            "",   //116
            "",   //117
            "",   //118
            "",   //119
            "",   //120
            "",   //121
            "",   //122
            "",   //123
            "",   //124
            "",   //125
            "",   //126
            "",   //127
            "",   //128
            "",   //129
            "",   //130
            "",   //131
            "",   //132
            "",   //133
            "",   //134
            "BackSL",   //135
            "k/Hira",   //136
            "￥",   //137
            "変換",   //138
            "無変換",   //139
            "",   //140
            "",   //141
            "",   //142
            "",   //143
            "",   //144
            "",   //145
            "",   //146
            "",   //147
            "",   //148
            "",   //149
            "",   //150
            "",   //151
            "",   //152
            "",   //153
            "",   //154
            "",   //155
            "",   //156
            "",   //157
            "",   //158
            "",   //159
            "",   //160
            "",   //161
            "",   //162
            "",   //163
            "",   //164
            "",   //165
            "",   //166
            "",   //167
            "",   //168
            "",   //169
            "",   //170
            "",   //171
            "",   //172
            "",   //173
            "",   //174
            "",   //175
            "",   //176
            "",   //177
            "",   //178
            "",   //179
            "",   //180
            "",   //181
            "",   //182
            "",   //183
            "",   //184
            "",   //185
            "",   //186
            "",   //187
            "",   //188
            "",   //189
            "",   //190
            "",   //191
            "",   //192
            "",   //193
            "",   //194
            "",   //195
            "",   //196
            "",   //197
            "",   //198
            "",   //199
            "",   //200
            "",   //201
            "",   //202
            "",   //203
            "",   //204
            "",   //205
            "",   //206
            "",   //207
            "",   //208
            "",   //209
            "",   //210
            "",   //211
            "",   //212
            "",   //213
            "",   //214
            "",   //215
            "",   //216
            "",   //217
            "",   //218
            "",   //219
            "",   //220
            "",   //221
            "",   //222
            "",   //223
            "Ctrl L",   //224
            "Shift L",   //225
            "Alt L",   //226
            "Win L",   //227
            "Ctrl R",   //228
            "Shift R",   //229
            "Alt R",   //230
            "Win R",   //231
            "",   //232
            "",   //233
            "",   //234
            "",   //235
            "",   //236
            "",   //237
            "",   //238
            "",   //239
            "",   //240
            "",   //241
            "",   //242
            "",   //243
            "",   //244
            "",   //245
            "",   //246
            "",   //247
            "",   //248
            "",   //249
            "",   //250
            "",   //251
            "",   //252
            "",   //253
            "",   //254
            "",   //255
       };
        // USキーボード
        private string[] USB_KeyCode_Name_US = new string[256]{
            "",   //x0
            "",   //x1
            "",   //x2
            "",   //x3
            "A",   //4
            "B",   //5
            "C",   //6
            "D",   //7
            "E",   //8
            "F",   //9
            "G",   //10
            "H",   //11
            "I",   //12
            "J",   //13
            "K",   //14
            "L",   //15
            "M",   //16
            "N",   //17
            "O",   //18
            "P",   //19
            "Q",   //20
            "R",   //21
            "S",   //22
            "T",   //23
            "U",   //24
            "V",   //25
            "W",   //26
            "X",   //27
            "Y",   //28
            "Z",   //29
            "1",   //30
            "2",   //31
            "3",   //32
            "4",   //33
            "5",   //34
            "6",   //35
            "7",   //36
            "8",   //37
            "9",   //38
            "0",   //39
            "Enter",   //40
            "ESC",   //41
            "BS",   //42
            "Tab",   //43
            "Space",   //44
            "-",   //45
            "=",   //46
            "[",   //47
            "]",   //48
            "BackSL",   //49
            "",   //50
            ";",   //51
            "'",   //52
            "`",   //53
            ",",   //54
            ".",   //55
            "/",   //56
            "CapsLock",   //57
            "F1",   //58
            "F2",   //59
            "F3",   //60
            "F4",   //61
            "F5",   //62
            "F6",   //63
            "F7",   //64
            "F8",   //65
            "F9",   //66
            "F10",   //67
            "F11",   //68
            "F12",   //69
            "PrintScreen",   //70
            "ScrollLock",   //71
            "Pause",   //72
            "Insert",   //73
            "Home",   //74
            "PageUp",   //75
            "Delete",   //76
            "End",   //77
            "PageDown",   //78
            "→",   //79
            "←",   //80
            "↓",   //81
            "↑",   //82
            "NumLock",   //83
            "Num/",   //84
            "Num*",   //85
            "Num-",   //86
            "Num+",   //87
            "NumEnter",   //88
            "Num1",   //89
            "Num2",   //90
            "Num3",   //91
            "Num4",   //92
            "Num5",   //93
            "Num6",   //94
            "Num7",   //95
            "Num8",   //96
            "Num9",   //97
            "Num0",   //98
            "Num.",   //99
            "",   //x100
            "Menu",   //101
            "",   //x102
            "",   //x103
            "F13",   //104
            "F14",   //105
            "F15",   //106
            "F16",   //107
            "F17",   //108
            "F18",   //109
            "F19",   //110
            "F20",   //111
            "F21",   //112
            "F22",   //113
            "F23",   //114
            "F24",   //115
            "",   //x116
            "",   //x117
            "",   //x118
            "",   //x119
            "",   //x120
            "",   //x121
            "",   //x122
            "",   //x123
            "",   //x124
            "",   //x125
            "",   //x126
            "",   //x127
            "",   //x128
            "",   //x129
            "",   //x130
            "",   //x131
            "",   //x132
            "",   //x133
            "",   //x134
            "",   //x135
            "",   //x136
            "",   //x137
            "",   //X138
            "",   //X139
            "",   //x140
            "",   //x141
            "",   //x142
            "",   //x143
            "",   //x144
            "",   //x145
            "",   //x146
            "",   //x147
            "",   //x148
            "",   //x149
            "",   //x150
            "",   //x151
            "",   //x152
            "",   //x153
            "",   //x154
            "",   //x155
            "",   //x156
            "",   //x157
            "",   //x158
            "",   //x159
            "",   //x160
            "",   //x161
            "",   //x162
            "",   //x163
            "",   //x164
            "",   //x165
            "",   //x166
            "",   //x167
            "",   //x168
            "",   //x169
            "",   //x170
            "",   //x171
            "",   //x172
            "",   //x173
            "",   //x174
            "",   //x175
            "",   //x176
            "",   //x177
            "",   //x178
            "",   //x179
            "",   //x180
            "",   //x181
            "",   //x182
            "",   //x183
            "",   //x184
            "",   //x185
            "",   //x186
            "",   //x187
            "",   //x188
            "",   //x189
            "",   //x190
            "",   //x191
            "",   //x192
            "",   //x193
            "",   //x194
            "",   //x195
            "",   //x196
            "",   //x197
            "",   //x198
            "",   //x199
            "",   //x200
            "",   //x201
            "",   //x202
            "",   //x203
            "",   //x204
            "",   //x205
            "",   //x206
            "",   //x207
            "",   //x208
            "",   //x209
            "",   //x210
            "",   //x211
            "",   //x212
            "",   //x213
            "",   //x214
            "",   //x215
            "",   //x216
            "",   //x217
            "",   //x218
            "",   //x219
            "",   //x220
            "",   //x221
            "",   //x222
            "",   //x223
            "Ctrl L",   //224
            "Shift L",   //225
            "Alt L",   //226
            "Win L",   //227
            "Ctrl R",   //228
            "Shift R",   //229
            "Alt R",   //230
            "Win R",   //231
            "",   //x232
            "",   //x233
            "",   //x234
            "",   //x235
            "",   //x236
            "",   //x237
            "",   //x238
            "",   //x239
            "",   //x240
            "",   //x241
            "",   //x242
            "",   //x243
            "",   //x244
            "",   //x245
            "",   //x246
            "",   //x247
            "",   //x248
            "",   //x249
            "",   //x250
            "",   //x251
            "",   //x252
            "",   //x253
            "",   //x254
            "",   //x255
       };
#endif
    }
} //namespace HID_PnP_Demo