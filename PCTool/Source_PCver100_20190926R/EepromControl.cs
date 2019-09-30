using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace ReviveUSBAdvance
{
    class EepromControl
    {
        private System.Timers.Timer myFlashTimer;
        
        public byte read_comp_flag;
        public byte all_read_flag;
        public byte read_flag_sw_setting;
        public byte read_flag_an_setting;

        public byte write_comp_flag;
        public byte all_write_flag;
        public byte write_flag_sw_setting;
        public byte write_flag_an_setting;


        // EEPROM AT25080B 8Kb(1024byte)
        public const uint E2P_TOTAL_SIZE                = 0x0400;		// EEPROM MEMORY 総サイズ(byte)
        public const uint E2P_SECTOR_NUM                = 0x20;   		// EEPROM MEMORY セクター数
        public const uint E2P_SECTOR_SIZE               = 0x20;         // EEPROM MEMORY セクターサイズ
        public const uint E2P_USB_READ_DATA_SIZE        = 32;           // USBリードサイズ（1回の通信での）
        public const uint E2P_USB_WRITE_DATA_SIZE       = 32;           // USBライトサイズ（1回の通信での）
        // EEPROM AT25640B 64Kb(8192byte)
        //public const uint E2P_TOTAL_SIZE                = 0x2000;		// EEPROM MEMORY 総サイズ(byte)
        //public const uint E2P_SECTOR_NUM                = 0x100;   		// EEPROM MEMORY セクター数
        //public const uint E2P_SECTOR_SIZE               = 0x20;         // EEPROM MEMORY セクターサイズ
        //public const uint E2P_USB_READ_DATA_SIZE        = 32;           // USBリードサイズ（1回の通信での）
        //public const uint E2P_USB_WRITE_DATA_SIZE       = 32;           // USBライトサイズ（1回の通信での）

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// SW設定情報
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public const int E2P_SW_INFO_AREA_ALL_SIZE          = 0x0000F0;   // SW設定情報 全サイズ
        public const int E2P_ADR_SW_INFO                    = 0x000010;   // SW設定情報 保存先頭アドレス
        public const int E2P_SW_INFO_AREA_SIZE              = 0x0000F0;   // SW設定情報 保存エリアサイズ
        public const int E2P_SW_INFO_SW_DATA_SIZE           = 0x000010;   // SW設定情報 SW DATAサイズ

        // SW設定情報格納位置オフセット
        public const int E2P_OFSET_SW_INFO_SW_DATA_TOP = 0x000000; // SW設定情報 SW DATA先頭
        public const int E2P_OFSET_SW_INFO_SW1_DATA_TOP = 0x000000; // SW設定情報 SW1 DATA先頭
        public const int E2P_OFSET_SW_INFO_SW2_DATA_TOP = 0x000010; // SW設定情報 SW2 DATA先頭
        public const int E2P_OFSET_SW_INFO_SW3_DATA_TOP = 0x000020; // SW設定情報 SW3 DATA先頭
        public const int E2P_OFSET_SW_INFO_SW4_DATA_TOP = 0x000030; // SW設定情報 SW4 DATA先頭
        public const int E2P_OFSET_SW_INFO_SW5_DATA_TOP = 0x000040; // SW設定情報 SW5 DATA先頭
        public const int E2P_OFSET_SW_INFO_SW6_DATA_TOP = 0x000050; // SW設定情報 SW6 DATA先頭
        public const int E2P_OFSET_SW_INFO_SW7_DATA_TOP = 0x000060; // SW設定情報 SW7 DATA先頭
        public const int E2P_OFSET_SW_INFO_SW8_DATA_TOP = 0x000070; // SW設定情報 SW8 DATA先頭
        public const int E2P_OFSET_SW_INFO_SW9_DATA_TOP = 0x000080; // SW設定情報 SW9 DATA先頭
        public const int E2P_OFSET_SW_INFO_SW10_DATA_TOP = 0x000090; // SW設定情報 SW10 DATA先頭
        public const int E2P_OFSET_SW_INFO_SW11_DATA_TOP = 0x0000A0; // SW設定情報 SW11 DATA先頭
        public const int E2P_OFSET_SW_INFO_SW12_DATA_TOP = 0x0000B0; // SW設定情報 SW12 DATA先頭
        public const int E2P_OFSET_SW_INFO_SW13_DATA_TOP = 0x0000C0; // SW設定情報 SW13 DATA先頭
        public const int E2P_OFSET_SW_INFO_SW14_DATA_TOP = 0x0000D0; // SW設定情報 SW14 DATA先頭
        public const int E2P_OFSET_SW_INFO_SW15_DATA_TOP = 0x0000E0; // SW設定情報 SW15 DATA先頭
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// AN設定情報
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public const int E2P_AN_INFO_AREA_ALL_SIZE              = 0x000100;   // AN設定情報 全サイズ
        public const int E2P_ADR_AN_INFO                        = 0x000100;   // AN設定情報 保存先頭アドレス
        public const int E2P_AN_INFO_AREA_SIZE                  = 0x000100;   // AN設定情報 保存エリアサイズ
        public const int E2P_AN_INFO_AN_DATA_SIZE               = 0x000020;   // AN設定情報 AN DATAサイズ
        // AN設定情報格納位置オフセット
        public const int E2P_OFSET_AN_INFO_AN_DATA_TOP = 0x000000; // AN設定情報 AN DATA先頭
        public const int E2P_OFSET_AN_INFO_AN1_DATA_TOP = 0x000000; // AN設定情報 AN1 DATA先頭
        public const int E2P_OFSET_AN_INFO_AN2_DATA_TOP = 0x000020; // AN設定情報 AN2 DATA先頭
        public const int E2P_OFSET_AN_INFO_AN3_DATA_TOP = 0x000040; // AN設定情報 AN3 DATA先頭
        public const int E2P_OFSET_AN_INFO_AN4_DATA_TOP = 0x000060; // AN設定情報 AN4 DATA先頭
        public const int E2P_OFSET_AN_INFO_AN5_DATA_TOP = 0x000080; // AN設定情報 AN5 DATA先頭
        public const int E2P_OFSET_AN_INFO_AN6_DATA_TOP = 0x0000A0; // AN設定情報 AN6 DATA先頭
        public const int E2P_OFSET_AN_INFO_AN7_DATA_TOP = 0x0000C0; // AN設定情報 AN7 DATA先頭
        public const int E2P_OFSET_AN_INFO_AN8_DATA_TOP = 0x0000E0; // AN設定情報 AN8 DATA先頭


        public const uint E2P_READ_TYPE_SW_SETTING          = 0x0001;     // 
        public const uint E2P_READ_TYPE_AN_SETTING          = 0x0002;     // 
        public const uint E2P_WRITE_TYPE_SW_SETTING         = 0x0001;     // 
        public const uint E2P_WRITE_TYPE_AN_SETTING         = 0x0002;     // 

        public const byte E2P_READ_STATUS_NA                = 0x00;     // リード状態　N/A
        public const byte E2P_READ_STATUS_RQ                = 0x01;     // リード状態　読み込みリクエスト
        public const byte E2P_READ_STATUS_READING           = 0x02;     // リード状態　読み込み中
        public const byte E2P_READ_STATUS_COMP              = 0x04;     // リード状態　読み込み完了
        public const byte E2P_WRITE_STATUS_NA               = 0x00;     // ライト状態　N/A
        public const byte E2P_WRITE_STATUS_RQ               = 0x01;     // ライト状態　書き込みリクエスト
        public const byte E2P_WRITE_STATUS_WRITTING         = 0x02;     // ライト状態　書き込み中
        public const byte E2P_WRITE_STATUS_COMP             = 0x04;     // ライト状態　書き込み完了




        public EepromControl()
        {
            read_comp_flag = E2P_READ_STATUS_NA;
            all_read_flag = E2P_READ_STATUS_NA;
            read_flag_sw_setting = E2P_READ_STATUS_NA;
            read_flag_an_setting = E2P_READ_STATUS_NA;

            write_comp_flag = E2P_WRITE_STATUS_NA;
            all_write_flag = E2P_WRITE_STATUS_NA;
            write_flag_sw_setting = E2P_WRITE_STATUS_NA;
            write_flag_an_setting = E2P_WRITE_STATUS_NA;


            myFlashTimer = new System.Timers.Timer();
            myFlashTimer.Enabled = true;
            myFlashTimer.AutoReset = true;
            myFlashTimer.Interval = 1000;
            myFlashTimer.Elapsed += new ElapsedEventHandler(FlashTimer_Tick);

            StartTimer();
        }
        ~EepromControl()
        {
            StopTimer();
        }

        private void FlashTimer_Tick(object source, ElapsedEventArgs e)
        {
            // TODO:
            Console.WriteLine(DateTime.Now);
        }

        public void StartTimer()
        {
            myFlashTimer.Start();
        }
        public void StopTimer()
        {
            myFlashTimer.Stop();
        }

        public void Set_Eeprom_Read_Status(uint read_type, byte set_status)
        {
            try
            {
                switch (read_type)
                {
                    case E2P_READ_TYPE_SW_SETTING:
                        if (set_status == E2P_READ_STATUS_RQ
                            && (read_flag_sw_setting == E2P_READ_STATUS_NA || read_flag_sw_setting == E2P_READ_STATUS_COMP))
                        {
                            read_flag_sw_setting = E2P_READ_STATUS_RQ;
                        }
                        if (set_status == E2P_READ_STATUS_READING
                            && (read_flag_sw_setting == E2P_READ_STATUS_RQ))
                        {
                            read_flag_sw_setting = E2P_READ_STATUS_READING;
                        }
                        if (set_status == E2P_READ_STATUS_COMP
                            && (read_flag_sw_setting == E2P_READ_STATUS_READING))
                        {
                            read_flag_sw_setting = E2P_READ_STATUS_COMP;
                        }
                        if (set_status == E2P_READ_STATUS_NA)
                        {
                            read_flag_sw_setting = E2P_READ_STATUS_NA;
                        }
                        break;
                    case E2P_READ_TYPE_AN_SETTING:
                        if (set_status == E2P_READ_STATUS_RQ
                            && (read_flag_an_setting == E2P_READ_STATUS_NA || read_flag_an_setting == E2P_READ_STATUS_COMP))
                        {
                            read_flag_an_setting = E2P_READ_STATUS_RQ;
                        }
                        if (set_status == E2P_READ_STATUS_READING
                            && (read_flag_an_setting == E2P_READ_STATUS_RQ))
                        {
                            read_flag_an_setting = E2P_READ_STATUS_READING;
                        }
                        if (set_status == E2P_READ_STATUS_COMP
                            && (read_flag_an_setting == E2P_READ_STATUS_READING))
                        {
                            read_flag_an_setting = E2P_READ_STATUS_COMP;
                        }
                        if (set_status == E2P_READ_STATUS_NA)
                        {
                            read_flag_an_setting = E2P_READ_STATUS_NA;
                        }
                        break;
                }
            }
            catch
            {
            }
            return;
        }
        public byte Get_Eeprom_Read_Status(uint read_type)
        {
            byte b_ret = E2P_READ_STATUS_NA;
            try
            {
                switch (read_type)
                {
                    case E2P_READ_TYPE_SW_SETTING:
                        b_ret = read_flag_sw_setting;
                        break;
                    case E2P_READ_TYPE_AN_SETTING:
                        b_ret = read_flag_an_setting;
                        break;
                }
            }
            catch
            {
            }
            return b_ret;
        }
        public void Set_Eeprom_Read_Status_Clear(uint read_type)
        {
            try
            {
                if ((read_type & E2P_READ_TYPE_SW_SETTING) != 0)
                {
                    read_flag_sw_setting = E2P_READ_STATUS_NA;
                }
                if ((read_type & E2P_READ_TYPE_AN_SETTING) != 0)
                {
                    read_flag_an_setting = E2P_READ_STATUS_NA;
                }
            }
            catch
            {
            }
        }

        public bool Set_Eeprom_Read_SW_Info(ref Form1.STR_SW_DATAS p_sw_datas, ArrayList p_al)
        {
            bool b_ret = false;
            try
            {
                if (p_al.Count == E2P_SW_INFO_AREA_ALL_SIZE)
                {
                    // SW設定データをセット
                    for (int sw_idx = 0; sw_idx < Constants.DIGITAL_INPUT_NUM; sw_idx++)
                    {
                        for (int data_idx = 0; data_idx < E2P_SW_INFO_SW_DATA_SIZE; data_idx++)
                        {
                            p_sw_datas.sw_datas[sw_idx].sw_data[data_idx] = (byte)p_al[(E2P_SW_INFO_SW_DATA_SIZE * sw_idx) + data_idx];
                        }

                        // デバイスタイプの範囲チェック
                        if (p_sw_datas.sw_datas[sw_idx].sw_data[Constants.SW_DEVICE_DATA_SET_DEVICE_TYPE_IDX] >= Constants.SW_SET_DEVICE_TYPE_NUM)
                        {
                            p_sw_datas.sw_datas[sw_idx].sw_data[Constants.SW_DEVICE_DATA_SET_DEVICE_TYPE_IDX] = Constants.SW_SET_DEVICE_TYPE_NONE;
                            for (int data_idx = (Constants.SW_DEVICE_DATA_SET_DEVICE_TYPE_IDX + 1); data_idx < Constants.SW_DEVICE_DATA_LEN; data_idx++)
                            {
                                p_sw_datas.sw_datas[sw_idx].sw_data[data_idx] = 0;
                            }
                        }
                        // 感度設定範囲チェック
                        if (p_sw_datas.sw_datas[sw_idx].sw_data[Constants.SW_DEVICE_DATA_SENSE_IDX] < Constants.SENSITIVITY_MIN || Constants.SENSITIVITY_MAX < p_sw_datas.sw_datas[sw_idx].sw_data[Constants.SW_DEVICE_DATA_SENSE_IDX])
                        {
                            p_sw_datas.sw_datas[sw_idx].sw_data[Constants.SW_DEVICE_DATA_SENSE_IDX] = Constants.SENSITIVITY_DEFAULT;
                        }
                        // 設定タイプの範囲チェック
                        switch (p_sw_datas.sw_datas[sw_idx].sw_data[Constants.SW_DEVICE_DATA_SET_DEVICE_TYPE_IDX])
                        {
                            case Constants.SW_SET_DEVICE_TYPE_NONE:
                                for (int data_idx = Constants.SW_DEVICE_DATA_SET_TYPE_IDX; data_idx < Constants.SW_DEVICE_DATA_LEN; data_idx++)
                                {
                                    p_sw_datas.sw_datas[sw_idx].sw_data[data_idx] = 0;
                                }
                                break;
                            case Constants.SW_SET_DEVICE_TYPE_MOUSE:
                                if (p_sw_datas.sw_datas[sw_idx].sw_data[Constants.SW_DEVICE_DATA_SET_TYPE_IDX] >= Constants.SW_SET_TYPE_MOUSE_NUM)
                                {
                                    for (int data_idx = Constants.SW_DEVICE_DATA_SET_TYPE_IDX; data_idx < Constants.SW_DEVICE_DATA_LEN; data_idx++)
                                    {
                                        p_sw_datas.sw_datas[sw_idx].sw_data[data_idx] = 0;
                                    }
                                }
                                break;
                            case Constants.SW_SET_DEVICE_TYPE_KEYBOARD:
                                if (p_sw_datas.sw_datas[sw_idx].sw_data[Constants.SW_DEVICE_DATA_SET_TYPE_IDX] == 0xFF)
                                {
                                    for (int data_idx = Constants.SW_DEVICE_DATA_SET_TYPE_IDX; data_idx < Constants.SW_DEVICE_DATA_LEN; data_idx++)
                                    {
                                        p_sw_datas.sw_datas[sw_idx].sw_data[data_idx] = 0;
                                    }
                                }
                                break;
                            case Constants.SW_SET_DEVICE_TYPE_JOYSTICK:
                                if (p_sw_datas.sw_datas[sw_idx].sw_data[Constants.SW_DEVICE_DATA_SET_TYPE_IDX] == 0xFF)
                                {
                                    for (int data_idx = Constants.SW_DEVICE_DATA_SET_TYPE_IDX; data_idx < Constants.SW_DEVICE_DATA_LEN; data_idx++)
                                    {
                                        p_sw_datas.sw_datas[sw_idx].sw_data[data_idx] = 0;
                                    }
                                }
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
        public bool Set_Eeprom_Read_An_Info(ref Form1.STR_AN_DATAS p_an_datas, ArrayList p_al)
        {
            bool b_ret = false;
            try
            {
                if (p_al.Count == E2P_AN_INFO_AREA_ALL_SIZE)
                {
                    // AN設定データをセット
                    for (int an_idx = 0; an_idx < Constants.ANALOG_INPUT_NUM; an_idx++)
                    {
                        for (int data_idx = 0; data_idx < E2P_AN_INFO_AN_DATA_SIZE; data_idx++)
                        {
                            p_an_datas.an_datas[an_idx].an_data[data_idx] = (byte)p_al[(E2P_AN_INFO_AN_DATA_SIZE * an_idx) + data_idx];
                        }

                        // デバイスタイプの範囲チェック
                        if (p_an_datas.an_datas[an_idx].an_data[Constants.AN_DEVICE_DATA_SET_DEVICE_TYPE_IDX] >= Constants.AN_SET_DEVICE_TYPE_NUM)
                        {
                            p_an_datas.an_datas[an_idx].an_data[Constants.AN_DEVICE_DATA_SET_DEVICE_TYPE_IDX] = Constants.AN_SET_DEVICE_TYPE_NONE;
                            for (int data_idx = (Constants.AN_DEVICE_DATA_SET_DEVICE_TYPE_IDX + 1); data_idx < Constants.AN_DEVICE_DATA_LEN; data_idx++)
                            {
                                p_an_datas.an_datas[an_idx].an_data[data_idx] = 0;
                            }
                        }
                        switch (p_an_datas.an_datas[an_idx].an_data[Constants.AN_DEVICE_DATA_SET_DEVICE_TYPE_IDX])
                        {
                            case Constants.AN_SET_DEVICE_TYPE_NONE:
                                break;
                            case Constants.AN_SET_DEVICE_TYPE_X:
                            case Constants.AN_SET_DEVICE_TYPE_Y:
                            case Constants.AN_SET_DEVICE_TYPE_Z:
                            case Constants.AN_SET_DEVICE_TYPE_RX:
                            case Constants.AN_SET_DEVICE_TYPE_RY:
                            case Constants.AN_SET_DEVICE_TYPE_RZ:
                            case Constants.AN_SET_DEVICE_TYPE_SL:
                                // 設定値範囲チェック
                                bool check_error_flag = false;
                                int temp_1, temp_2, temp_3, temp_4, temp_5;
                                // 電圧値の大小関係チェック
                                temp_1 = p_an_datas.an_datas[an_idx].an_data[Constants.AN_DEVICE_DATA_VOL1HI_IDX];
                                temp_1 = (temp_1 << 8) + p_an_datas.an_datas[an_idx].an_data[Constants.AN_DEVICE_DATA_VOL1LO_IDX];
                                temp_2 = p_an_datas.an_datas[an_idx].an_data[Constants.AN_DEVICE_DATA_VOL2HI_IDX];
                                temp_2 = (temp_2 << 8) + p_an_datas.an_datas[an_idx].an_data[Constants.AN_DEVICE_DATA_VOL2LO_IDX];
                                temp_3 = p_an_datas.an_datas[an_idx].an_data[Constants.AN_DEVICE_DATA_VOL3HI_IDX];
                                temp_3 = (temp_3 << 8) + p_an_datas.an_datas[an_idx].an_data[Constants.AN_DEVICE_DATA_VOL3LO_IDX];
                                if (temp_1 >= temp_2 || temp_2 >= temp_3)
                                {
                                    check_error_flag = true;
                                }
                                // 出力値の大小関係チェック
                                temp_1 = p_an_datas.an_datas[an_idx].an_data[Constants.AN_DEVICE_DATA_0V_VAL_IDX];
                                temp_2 = p_an_datas.an_datas[an_idx].an_data[Constants.AN_DEVICE_DATA_VAL1_IDX];
                                temp_3 = p_an_datas.an_datas[an_idx].an_data[Constants.AN_DEVICE_DATA_VAL2_IDX];
                                temp_4 = p_an_datas.an_datas[an_idx].an_data[Constants.AN_DEVICE_DATA_VAL3_IDX];
                                temp_5 = p_an_datas.an_datas[an_idx].an_data[Constants.AN_DEVICE_DATA_3V_VAL_IDX];
                                if (temp_1 > temp_2 || temp_2 > temp_3 || temp_3 > temp_4 || temp_4 > temp_5)
                                {
                                    check_error_flag = true;
                                }
                                if (check_error_flag == true)
                                {   // 設定値異常 デフォルト値セット
                                    for (int data_idx = Constants.AN_DEVICE_DATA_0V_VAL_IDX, set_idx = 0; data_idx < Constants.AN_DEVICE_DATA_LEN && set_idx < Form1.analog_lever_setting_default_value.Length; data_idx++, set_idx++)
                                    {
                                        p_an_datas.an_datas[an_idx].an_data[data_idx] = Form1.analog_lever_setting_default_value[set_idx];
                                    }
                                }
                                //
                                break;
                            case Constants.AN_SET_DEVICE_TYPE_MOUSE_X:
                            case Constants.AN_SET_DEVICE_TYPE_MOUSE_Y:
                                // 不感帯設定範囲チェック
                                if (p_an_datas.an_datas[an_idx].an_data[Constants.AN_DEVICE_DATA_DEADZONE_IDX] < Constants.DEAD_ZONE_MIN || Constants.DEAD_ZONE_MAX < p_an_datas.an_datas[an_idx].an_data[Constants.AN_DEVICE_DATA_DEADZONE_IDX])
                                {
                                    p_an_datas.an_datas[an_idx].an_data[Constants.AN_DEVICE_DATA_DEADZONE_IDX] = Constants.DEAD_ZONE_DEFAULT;
                                }
                                break;
                            default:
                                p_an_datas.an_datas[an_idx].an_data[Constants.AN_DEVICE_DATA_SET_DEVICE_TYPE_IDX] = Constants.AN_SET_DEVICE_TYPE_NONE;
                                p_an_datas.an_datas[an_idx].an_data[Constants.AN_DEVICE_DATA_SENSE_IDX] = Constants.SENSITIVITY_DEFAULT;
                                p_an_datas.an_datas[an_idx].an_data[Constants.AN_DEVICE_DATA_SET_TYPE_IDX] = 0;
                                p_an_datas.an_datas[an_idx].an_data[Constants.AN_DEVICE_DATA_CENTER_VAL_HI_IDX] = (byte)((Constants.ANALOG_INPUT_CENTER_DEFAULT_VALUE >> 8) & 0xFF);
                                p_an_datas.an_datas[an_idx].an_data[Constants.AN_DEVICE_DATA_CENTER_VAL_LO_IDX] = (byte)(Constants.ANALOG_INPUT_CENTER_DEFAULT_VALUE & 0xFF);
                                for (int data_idx = Constants.AN_DEVICE_DATA_0V_VAL_IDX; data_idx < Constants.AN_DEVICE_DATA_LEN; data_idx++)
                                {
                                    p_an_datas.an_datas[an_idx].an_data[data_idx] = 0;
                                }
                                break;
                        }
                        // 感度設定範囲チェック
                        if (p_an_datas.an_datas[an_idx].an_data[Constants.AN_DEVICE_DATA_SENSE_IDX] < Constants.SENSITIVITY_MIN || Constants.SENSITIVITY_MAX < p_an_datas.an_datas[an_idx].an_data[Constants.AN_DEVICE_DATA_SENSE_IDX])
                        {
                            p_an_datas.an_datas[an_idx].an_data[Constants.AN_DEVICE_DATA_SENSE_IDX] = Constants.SENSITIVITY_DEFAULT;
                        }
                        // 中立値チェック
                        uint uint_temp = 0;
                        uint_temp = p_an_datas.an_datas[an_idx].an_data[Constants.AN_DEVICE_DATA_CENTER_VAL_HI_IDX];
                        uint_temp = (uint_temp << 8) + p_an_datas.an_datas[an_idx].an_data[Constants.AN_DEVICE_DATA_CENTER_VAL_LO_IDX];
                        if (uint_temp > Constants.ANALOG_INPUT_MAX_VALUE)
                        {
                            p_an_datas.an_datas[an_idx].an_data[Constants.AN_DEVICE_DATA_CENTER_VAL_HI_IDX] = (byte)((Constants.ANALOG_INPUT_CENTER_DEFAULT_VALUE >> 8) & 0xFF);
                            p_an_datas.an_datas[an_idx].an_data[Constants.AN_DEVICE_DATA_CENTER_VAL_LO_IDX] = (byte)(Constants.ANALOG_INPUT_CENTER_DEFAULT_VALUE & 0xFF);
                        }


                        // 設定タイプの範囲チェック
                        p_an_datas.an_datas[an_idx].an_data[Constants.AN_DEVICE_DATA_SET_TYPE_IDX] = 0;
                    }
                }
            }
            catch
            {
            }
            return b_ret;
        }

        public void Set_Eeprom_Write_Status(uint write_type, byte set_status)
        {
            try
            {
                switch (write_type)
                {
                    case E2P_WRITE_TYPE_SW_SETTING:
                        if (set_status == E2P_WRITE_STATUS_RQ
                            && (write_flag_sw_setting == E2P_WRITE_STATUS_NA || write_flag_sw_setting == E2P_WRITE_STATUS_COMP))
                        {
                            write_flag_sw_setting = E2P_WRITE_STATUS_RQ;
                        }
                        if (set_status == E2P_WRITE_STATUS_WRITTING
                            && (write_flag_sw_setting == E2P_WRITE_STATUS_RQ))
                        {
                            write_flag_sw_setting = E2P_WRITE_STATUS_WRITTING;
                        }
                        if (set_status == E2P_WRITE_STATUS_COMP
                            && (write_flag_sw_setting == E2P_WRITE_STATUS_WRITTING))
                        {
                            write_flag_sw_setting = E2P_WRITE_STATUS_COMP;
                        }
                        if (set_status == E2P_WRITE_STATUS_NA)
                        {
                            write_flag_sw_setting = E2P_WRITE_STATUS_NA;
                        }
                        break;
                    case E2P_WRITE_TYPE_AN_SETTING:
                        if (set_status == E2P_WRITE_STATUS_RQ
                            && (write_flag_an_setting == E2P_WRITE_STATUS_NA || write_flag_an_setting == E2P_WRITE_STATUS_COMP))
                        {
                            write_flag_an_setting = E2P_WRITE_STATUS_RQ;
                        }
                        if (set_status == E2P_WRITE_STATUS_WRITTING
                            && (write_flag_an_setting == E2P_WRITE_STATUS_RQ))
                        {
                            write_flag_an_setting = E2P_WRITE_STATUS_WRITTING;
                        }
                        if (set_status == E2P_WRITE_STATUS_COMP
                            && (write_flag_an_setting == E2P_WRITE_STATUS_WRITTING))
                        {
                            write_flag_an_setting = E2P_WRITE_STATUS_COMP;
                        }
                        if (set_status == E2P_WRITE_STATUS_NA)
                        {
                            write_flag_an_setting = E2P_WRITE_STATUS_NA;
                        }
                        break;
                }
            }
            catch
            {
            }
            return;
        }
        public byte Get_Eeprom_Write_Status(uint write_type)
        {
            byte b_ret = E2P_WRITE_STATUS_NA;
            try
            {
                switch (write_type)
                {
                    case E2P_WRITE_TYPE_SW_SETTING:
                        b_ret = write_flag_sw_setting;
                        break;
                    case E2P_WRITE_TYPE_AN_SETTING:
                        b_ret = write_flag_an_setting;
                        break;
                }
            }
            catch
            {
            }
            return b_ret;
        }
        public void Set_Eeprom_Write_Status_Clear(uint write_type)
        {
            try
            {
                if ((write_type & E2P_WRITE_TYPE_SW_SETTING) != 0)
                {
                    write_flag_sw_setting = E2P_WRITE_STATUS_NA;
                }
                if ((write_type & E2P_WRITE_TYPE_AN_SETTING) != 0)
                {
                    write_flag_an_setting = E2P_WRITE_STATUS_NA;
                }
            }
            catch
            {
            }
        }
    }
}
