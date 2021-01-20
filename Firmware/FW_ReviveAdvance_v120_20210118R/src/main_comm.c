#include <string.h>
#include "app.h"
#include "Main_comm.h"
#include "l_eeprom.h"
#include "main_sub.h"
#include "l_adc.h"


void USB_Comm(void)
{
    BYTE fi, fj;
    WORD w_temp;
    BYTE b_temp, b_temp2;
    int8_t tmp;
    EEPROM_ADR eeprom_address;
    BYTE b_temp_arry[2];


// Keyboard
    if(!HIDTxHandleBusy(lastINTransmission_Keyboard))
    {	       	//Load the HID buffer
        
        // キー出力順序バッファ最適化
        keyboard_push_order_buff_optimization();
        SW_Output_Keyboard(keyboard_buffer, KEYBOARD_BUFF_SIZE);
        
        //変化チェック
//        keyboard_input_out_flag = 0;
        for(fi = KEYBOARD_MODIFIER_IDX; fi < KEYBOARD_BUFF_SIZE; fi++)
        {
            if(keyboard_buffer[fi] != keyboard_buffer_pre[fi])
//            if(keyboard_buffer[fi] != keyboard_buffer_pre[fi] || keyboard_buffer[fi] != 0)
            {   // 変化あり のときのみ送信に変更
                keyboard_input_out_flag = 3;
                break;
            }
        }

        // キーボード出力
        if( keyboard_input_out_flag > 0 )
        {
            //出力バッファにデータコピー
            for(fi = 0; fi < KEYBOARD_BUFF_SIZE; fi++)
            {
                keyboard_input[fi] = keyboard_buffer[fi];
                debug_arr3[fi] = keyboard_buffer[fi];   // DEBUG
            }
            
            lastINTransmission_Keyboard = HIDTxPacket(HID_EP1, (BYTE*)&keyboard_input[0], KEYBOARD_BUFF_SIZE);
            keyboard_input_out_flag--;
            
        }
                
        // 今回値保存＆クリア
        for(fi = 0; fi < KEYBOARD_BUFF_SIZE; fi++)
        {
            keyboard_buffer_pre[fi] = keyboard_buffer[fi];
            keyboard_buffer[fi] = 0;
        }
    }
	if(!HIDRxHandleBusy(lastOUTTransmission_Keyboard))
	{
		//Num Lock LED state is in Bit0.
		//Caps Lock LED state is in Bit1.
		//Scroll Lock LED state is in Bit2.
		if(keyboard_output[0] & 0x01)
		{	// Num Lock LED ON
//			LED_1_ON();
		}
		else
		{
//			LED_1_OFF();
		}
		if(keyboard_output[0] & 0x02)
		{	// Caps Lock LED ON
//			LED_2_ON();
		}
		else
		{
//			LED_2_OFF();
		}
		if(keyboard_output[0] & 0x04)
		{	// Scroll Lock LED ON
//			LED_3_ON();
		}
		else
		{
//			LED_3_OFF();
		}
		lastOUTTransmission_Keyboard = HIDRxPacket(HID_EP1,(BYTE*)&keyboard_output[0], HID_INT_OUT_EP_SIZE);
	}
// Joystick
    if(!HIDTxHandleBusy(lastTransmission_Joystick))
    {
        // hat sw set
        joystick_buffer[USB_JOYSTICK_HATSW_IDX] = get_joystick_hat_sw_usb_output(joystick_hat_sw_output);
        // digital Lever set
        set_joystick_lever_usb_output(joystick_lever_output, SW_DATA_JOYSTICK_LEVER_SIZE, joystick_buffer, JOYSTICK_BUFF_SIZE);
        
        // analog output check & set
        set_analog_usb_joystick_output(joystick_buffer, JOYSTICK_BUFF_SIZE);
        
        
        for(fi = 0; fi < JOYSTICK_BUFF_SIZE; fi++)
        {
            joystick_input[fi] = joystick_buffer[fi];
            if(joystick_buffer[fi] != joystick_default_value[fi])
            {
                joystick_input_out_flag = 5;
            }
        }
        
        if(joystick_out_time_counter == 0)
        {
            for(fi = 0; fi < JOYSTICK_BUFF_SIZE; fi++)
            {
                joystick_buffer[fi] = joystick_lever_move_value[fi];
                joystick_buffer[fi] = joystick_default_value[fi];
            }
        }

        if( joystick_input_out_flag > 0 || joystick_out_time_counter > 0)
        {
            lastTransmission_Joystick = HIDTxPacket(HID_EP3, (BYTE*)&joystick_input[0], JOYSTICK_BUFF_SIZE);
            if(joystick_out_time_counter == 0)
            {
                joystick_input_out_flag--;
            }
        }
    }
#if 0
// MultiMedia
    if(!HIDTxHandleBusy(lastTransmission_Multimedia))
    {
//        for(fi = 0; fi < MULTIMEDIA_BUFF_SIZE; fi++)
//        {
//            multimedia_buffer[fi] = 0;
//        }
        
        // SW入力による出力チェック
        if(Get_SW_Input_Output_Status() == 1)
        {
            SW_Output_Multimedia(multimedia_buffer, MULTIMEDIA_BUFF_SIZE);
        }
        Ball_Output_Multimedia(multimedia_buffer, MULTIMEDIA_BUFF_SIZE);
                
        //変化チェック
//        multimedia_input_out_flag = 0;
        for(fi = MULTIMEDIA_DATA_TOP; fi < MULTIMEDIA_BUFF_SIZE; fi++)
        {
            if(multimedia_buffer[fi] != multimedia_buffer_pre[fi])
//            if(multimedia_buffer[fi] != multimedia_buffer_pre[fi] || multimedia_buffer[fi] != 0)
            {   // 変化あり または　0以外
                multimedia_input_out_flag = 3;
                break;
            }
        }
        
        // マルチメディア出力
        if( multimedia_input_out_flag > 0 )
        {
            //出力バッファにデータコピー
            for(fi = 0; fi < MULTIMEDIA_BUFF_SIZE; fi++)
            {
                multimedia_input[fi] = multimedia_buffer[fi];
            }
            
            lastTransmission_Multimedia = HIDTxPacket(HID_EP3, (BYTE*)&multimedia_input[0], MULTIMEDIA_BUFF_SIZE);
            multimedia_input_out_flag--;
        }
        
        // 今回値保存＆クリア
        for(fi = 0; fi < MULTIMEDIA_BUFF_SIZE; fi++)
        {
            multimedia_buffer_pre[fi] = multimedia_buffer[fi];
            multimedia_buffer[fi] = 0;
        }
    }
#endif
// Mouse
    if(!HIDTxHandleBusy(lastTransmission_Mouse))
    {
        // UP
        if(mouse_move_flag[MOUSE_MOVE_DIRECTION_UP] == MOUSE_MOVE_ON && mouse_move_flag[MOUSE_MOVE_DIRECTION_DOWN] == MOUSE_MOVE_OFF)
        {
            mouse_count_val[MOUSE_MOVE_DIRECTION_UP] += mouse_sensitivity[MOUSE_MOVE_DIRECTION_UP];
            if(mouse_count_val[MOUSE_MOVE_DIRECTION_UP] >= MASTER_MOUSE_SPEED)
            {
                mouse_buffer[USB_MOUSE_MOVE_Y_IDX] =  (BYTE)((-1 * (mouse_count_val[MOUSE_MOVE_DIRECTION_UP] / MASTER_MOUSE_SPEED)) & 0xFF);
                mouse_count_val[MOUSE_MOVE_DIRECTION_UP] = mouse_count_val[MOUSE_MOVE_DIRECTION_UP] % MASTER_MOUSE_SPEED;
            }
        }
        else
        {
            mouse_count_val[MOUSE_MOVE_DIRECTION_UP] = 0;
        }
        // DOWN
        if(mouse_move_flag[MOUSE_MOVE_DIRECTION_DOWN] == MOUSE_MOVE_ON && mouse_move_flag[MOUSE_MOVE_DIRECTION_UP] == MOUSE_MOVE_OFF)
        {
            mouse_count_val[MOUSE_MOVE_DIRECTION_DOWN] += mouse_sensitivity[MOUSE_MOVE_DIRECTION_DOWN];
            if(mouse_count_val[MOUSE_MOVE_DIRECTION_DOWN] >= MASTER_MOUSE_SPEED)
            {
                mouse_buffer[USB_MOUSE_MOVE_Y_IDX] =  (BYTE)((mouse_count_val[MOUSE_MOVE_DIRECTION_DOWN] / MASTER_MOUSE_SPEED) & 0xFF);
                mouse_count_val[MOUSE_MOVE_DIRECTION_DOWN] = mouse_count_val[MOUSE_MOVE_DIRECTION_DOWN] % MASTER_MOUSE_SPEED;
            }
        }
        else
        {
            mouse_count_val[MOUSE_MOVE_DIRECTION_DOWN] = 0;
        }
        // LEFT
        if(mouse_move_flag[MOUSE_MOVE_DIRECTION_LEFT] == MOUSE_MOVE_ON && mouse_move_flag[MOUSE_MOVE_DIRECTION_RIGHT] == MOUSE_MOVE_OFF)
        {
            mouse_count_val[MOUSE_MOVE_DIRECTION_LEFT] += mouse_sensitivity[MOUSE_MOVE_DIRECTION_LEFT];
            if(mouse_count_val[MOUSE_MOVE_DIRECTION_LEFT] >= MASTER_MOUSE_SPEED)
            {
                mouse_buffer[USB_MOUSE_MOVE_X_IDX] =  (BYTE)((-1 * (mouse_count_val[MOUSE_MOVE_DIRECTION_LEFT] / MASTER_MOUSE_SPEED)) & 0xFF);
                mouse_count_val[MOUSE_MOVE_DIRECTION_LEFT] = mouse_count_val[MOUSE_MOVE_DIRECTION_LEFT] % MASTER_MOUSE_SPEED;
            }
        }
        else
        {
            mouse_count_val[MOUSE_MOVE_DIRECTION_LEFT] = 0;
        }
        // RIGHT
        if(mouse_move_flag[MOUSE_MOVE_DIRECTION_RIGHT] == MOUSE_MOVE_ON && mouse_move_flag[MOUSE_MOVE_DIRECTION_LEFT] == MOUSE_MOVE_OFF)
        {
            mouse_count_val[MOUSE_MOVE_DIRECTION_RIGHT] += mouse_sensitivity[MOUSE_MOVE_DIRECTION_RIGHT];
            if(mouse_count_val[MOUSE_MOVE_DIRECTION_RIGHT] >= MASTER_MOUSE_SPEED)
            {
                mouse_buffer[USB_MOUSE_MOVE_X_IDX] =  (BYTE)((mouse_count_val[MOUSE_MOVE_DIRECTION_RIGHT] / MASTER_MOUSE_SPEED) & 0xFF);
                mouse_count_val[MOUSE_MOVE_DIRECTION_RIGHT] = mouse_count_val[MOUSE_MOVE_DIRECTION_RIGHT] % MASTER_MOUSE_SPEED;
            }
        }
        else
        {
            mouse_count_val[MOUSE_MOVE_DIRECTION_RIGHT] = 0;
        }
        // WHEEL UP
        if(mouse_move_flag[MOUSE_MOVE_DIRECTION_WUP] == MOUSE_MOVE_ON && mouse_move_flag[MOUSE_MOVE_DIRECTION_WDOWN] == MOUSE_MOVE_OFF)
        {
            mouse_count_val[MOUSE_MOVE_DIRECTION_WUP] += mouse_sensitivity[MOUSE_MOVE_DIRECTION_WUP];
            if(mouse_count_val[MOUSE_MOVE_DIRECTION_WUP] >= MASTER_WHEEL_SPEED)
            {
                mouse_buffer[USB_MOUSE_MOVE_W_IDX] =  (BYTE)((mouse_count_val[MOUSE_MOVE_DIRECTION_WUP] / MASTER_WHEEL_SPEED) & 0xFF);
                mouse_count_val[MOUSE_MOVE_DIRECTION_WUP] = mouse_count_val[MOUSE_MOVE_DIRECTION_WUP] % MASTER_WHEEL_SPEED;
            }
        }
        else
        {
            mouse_count_val[MOUSE_MOVE_DIRECTION_WUP] = 0;
        }
        // WHEEL DOWN
        if(mouse_move_flag[MOUSE_MOVE_DIRECTION_WDOWN] == MOUSE_MOVE_ON && mouse_move_flag[MOUSE_MOVE_DIRECTION_WUP] == MOUSE_MOVE_OFF)
        {
            mouse_count_val[MOUSE_MOVE_DIRECTION_WDOWN] += mouse_sensitivity[MOUSE_MOVE_DIRECTION_WDOWN];
            if(mouse_count_val[MOUSE_MOVE_DIRECTION_WDOWN] >= MASTER_WHEEL_SPEED)
            {
                mouse_buffer[USB_MOUSE_MOVE_W_IDX] =  (BYTE)((-1 * (mouse_count_val[MOUSE_MOVE_DIRECTION_WDOWN] / MASTER_WHEEL_SPEED)) & 0xFF);
                mouse_count_val[MOUSE_MOVE_DIRECTION_WDOWN] = mouse_count_val[MOUSE_MOVE_DIRECTION_WDOWN] % MASTER_WHEEL_SPEED;
            }
        }
        else
        {
            mouse_count_val[MOUSE_MOVE_DIRECTION_WDOWN] = 0;
        }
        
        // analog output check & set
        set_analog_usb_mouse_output(mouse_buffer, MOUSE_BUFF_SIZE);
        
        //変化チェック
#if 1
//        mouse_input_out_flag = 0;
        for( fi = 0; fi < MOUSE_BUFF_SIZE; fi++ )
        {
            if(mouse_buffer[fi] != mouse_buffer_pre[fi] || mouse_buffer[fi] != 0)
//            if(mouse_buffer[fi] != mouse_buffer_pre[fi])
            {   // 変化あり または 0以外
                mouse_input_out_flag = 1;
                break;
            }
        }
#endif

#if 0
	    // ダブルクリックチェック
	    if(mouse_w_click_status != MOUSE_DOUBLE_CLICK_STATUS_NONE)
	    {
		    if(mouse_w_click_status == MOUSE_DOUBLE_CLICK_STATUS_CLICK1)
		    {
				mouse_buffer[USB_MOUSE_BUTTON_IDX_TOP] = MOUSE_DATA_LEFT_CLICK;
				mouse_input_out_flag = 5;
				
				mouse_w_click_interval_counter = MOUSE_DOUBLE_CLICK_INTERVAL;
				mouse_w_click_status = MOUSE_DOUBLE_CLICK_STATUS_INTERVAL;
			}
			else if(mouse_w_click_status == MOUSE_DOUBLE_CLICK_STATUS_INTERVAL)
			{
				if(mouse_w_click_interval_counter == 0)
				{
					mouse_w_click_status = MOUSE_DOUBLE_CLICK_STATUS_CLICK2;
				}
			}
			else if(mouse_w_click_status == MOUSE_DOUBLE_CLICK_STATUS_CLICK2)
			{
				mouse_buffer[USB_MOUSE_BUTTON_IDX_TOP] = MOUSE_DATA_LEFT_CLICK;
				mouse_input_out_flag = 5;
				mouse_w_click_status = MOUSE_DOUBLE_CLICK_STATUS_NONE;
			}	 
		}
#endif

        //Send the 4 byte packet over USB to the host.
        if( mouse_input_out_flag > 0 )
        {
            //出力バッファにデータコピー
            for(fi = 0; fi < MOUSE_BUFF_SIZE; fi++)
            {
                mouse_input[fi] = mouse_buffer[fi];
                debug_arr3[8+fi] = mouse_buffer[fi];   // DEBUG
            }

            lastTransmission_Mouse = HIDTxPacket(HID_EP2, (BYTE*)&mouse_input[0], MOUSE_BUFF_SIZE);
            mouse_input_out_flag--;
        }
        
        // 今回値保存＆クリア
        for(fi = 0; fi < MOUSE_BUFF_SIZE; fi++)
        {
            mouse_buffer_pre[fi] = mouse_buffer[fi];
            mouse_buffer[fi] = 0;
        }
    }
// USB Data
    //Check if we have received an OUT data packet from the host
    if(!HIDRxHandleBusy(USBOutHandle))
    {
        for(fi = 0; fi < TX_DATA_BUFFER_SIZE; fi++)
        {
            ToSendDataBuffer[fi] = 0x00;
        }
        //We just received a packet of data from the USB host.
        //Check the first byte of the packet to see what command the host
        //application software wants us to fulfill.
        switch(ReceivedDataBuffer[0])				//Look at the data the host sent, to see what kind of application specific command it sent.
        {
            case 0x56: // V=0x56 Get Firmware version
                ToSendDataBuffer[0] = 0x56;				//Echo back to the host PC the command we are fulfilling in the first byte.  In this case, the Get Pushbutton State command.
                tmp = strlen(c_version);
                if( 0 < tmp && tmp <= (TX_DATA_BUFFER_SIZE-2) )
                {
                        for( fi = 0; fi < tmp; fi++ )
                        {
                                ToSendDataBuffer[fi+1] = c_version[fi];
                        }
                        // 最後にNULL文字を設定
                        ToSendDataBuffer[fi+1] = 0x00;
                }
                else
                {
                        //バージョン文字列異常
                        ToSendDataBuffer[1] = 0x00;
                }
                if(!HIDTxHandleBusy(USBInHandle))
                {
                    USBInHandle = HIDTxPacket(HID_EP4,(BYTE*)&ToSendDataBuffer[0], TX_DATA_BUFFER_SIZE);
                }
                break;
            /* EEPROM関係 ID 0x10 - 0x1F *************************************************************************************** */
            case 0x11:  // EEPROMからデータを読み込み [0x11,先頭アドレスMSB,LSB,サイズ] -> アンサ[0x11,サイズ,data1, ... , data58]
                ToSendDataBuffer[0] = 0x11;
                /* パラメータチェック 先頭アドレス(0x0000-0x07FF)+データサイズ(1-58)<=0x0800 サイズ=1-58 */
                eeprom_address = ReceivedDataBuffer[1];
                eeprom_address = (eeprom_address << 8) | ReceivedDataBuffer[2];
                if((eeprom_address + ReceivedDataBuffer[3]) <= EEPROM_SIZE && 1 <= ReceivedDataBuffer[3] && ReceivedDataBuffer[3] <= 58)
                {
                    ToSendDataBuffer[1] = ReceivedDataBuffer[3];
                    eeprom_n_read(eeprom_address, &ToSendDataBuffer[2], ReceivedDataBuffer[3]);
                }
                else
                {
                    // NGアンサ
                    ToSendDataBuffer[1] = 0xFF;
                }
                
                if(!HIDTxHandleBusy(USBInHandle))
                {
                    USBInHandle = HIDTxPacket(HID_EP4,(BYTE*)&ToSendDataBuffer[0], TX_DATA_BUFFER_SIZE);
                }
                break;
            case 0x12:  // EEPROMにデータを書込み [0x12,先頭アドレスMSB,LSB,サイズ,data1, ... ,data32]
                /* パラメータチェック 先頭アドレス(0x000000-0x07FF)+データサイズ(1-32)<=0x0800 サイズ=1-32 */
                ToSendDataBuffer[0] = 0x12;
                eeprom_address = ReceivedDataBuffer[1];
                eeprom_address = (eeprom_address << 8) | ReceivedDataBuffer[2];
                if((eeprom_address + ReceivedDataBuffer[3]) <= EEPROM_SIZE && 1 <= ReceivedDataBuffer[3] && ReceivedDataBuffer[3] <= EEPROM_PAGE_SIZE)
                {
                    // ページまたぎチェック
                    w_temp = (eeprom_address & (EEPROM_PAGE_SIZE - 1)) + ReceivedDataBuffer[3];
                    if(w_temp > EEPROM_PAGE_SIZE)
                    {   // ページまたぎの書き込み 2回に分ける
                        // 1回目の書き込みサイズを計算
                        b_temp = EEPROM_PAGE_SIZE - (eeprom_address & (EEPROM_PAGE_SIZE - 1));
                        eeprom_n_write(eeprom_address, &ReceivedDataBuffer[4], b_temp);
                        eeprom_n_write(eeprom_address + b_temp, &ReceivedDataBuffer[4+b_temp], ReceivedDataBuffer[3]-b_temp);
                    }
                    else
                    {
                        eeprom_n_write(eeprom_address, &ReceivedDataBuffer[4], ReceivedDataBuffer[3]);
                    }
                    // OKアンサ
                    ToSendDataBuffer[1] = 0x00;
                }
                else
                {
                    // NGアンサ
                    ToSendDataBuffer[1] = 0xFF;
                }
                if(!HIDTxHandleBusy(USBInHandle))
                {
                    USBInHandle = HIDTxPacket(HID_EP4,(BYTE*)&ToSendDataBuffer[0], TX_DATA_BUFFER_SIZE);
                }
                break;
            case 0x21:  // SW状態取得 [0x21] -> [0x21,SW1,SW2,SW3,SW4,SW5,SW6,SW7,SW8,SW9,SW10,SW11,SW12,SW13,SW14,SW15]
                ToSendDataBuffer[0] = 0x21;
                
                for(fi = 0; fi < SW_NUM; fi++)
                {
                    ToSendDataBuffer[1+fi] = sw_now_fix[fi];
                }
                
                if(!HIDTxHandleBusy(USBInHandle))
                {
                    USBInHandle = HIDTxPacket(HID_EP4,(BYTE*)&ToSendDataBuffer[0], TX_DATA_BUFFER_SIZE);
                }
                break;
            case 0x22:  // アナログ状態取得 [0x22] -> [0x22,AN1Hi,AN1LO,AN2Hi,AN2LO,AN3Hi,AN3LO...,AN8Hi,AN8LO]
                ToSendDataBuffer[0] = 0x22;
                for(fi = 0; fi < ANALOG_SETTING_NUM; fi++)
                {
                    ToSendDataBuffer[1 + (2 * fi)] = (BYTE)((ad_input[fi] >> 8) & 0xFF);
                    ToSendDataBuffer[1 + (2 * fi) + 1] = (BYTE)(ad_input[fi] & 0xFF);
                }
                if(!HIDTxHandleBusy(USBInHandle))
                {
                    USBInHandle = HIDTxPacket(HID_EP4,(BYTE*)&ToSendDataBuffer[0], TX_DATA_BUFFER_SIZE);
                }
                break;
            case 0x31:  // SW設定 取得 [0x31,SW No.] -> [0x31,Ans,SW No.,Data0,Data1,Data2...,Data15]
                ToSendDataBuffer[0] = 0x31;
                ToSendDataBuffer[1] = 0x00;
                ToSendDataBuffer[2] = ReceivedDataBuffer[1];
                if(ReceivedDataBuffer[1] < SW_SETTING_NUM)
                {
                    for(fi = 0; fi < SW_DATA_LEN; fi++)
                    {
                        ToSendDataBuffer[3 + fi] = my_sw_infos.SW_Infos.sw_info[ReceivedDataBuffer[1]].data[fi];
                    }
                }
                else
                {   // NG
                    ToSendDataBuffer[1] = 0xFF;
                }
                
                if(!HIDTxHandleBusy(USBInHandle))
                {
                    USBInHandle = HIDTxPacket(HID_EP4,(BYTE*)&ToSendDataBuffer[0], TX_DATA_BUFFER_SIZE);
                }
                break;
            case 0x32:  // SW設定 設定 [0x32,SW No.,Data0,Data1,Data2...,Data15] -> [0x32,Ans]
                ToSendDataBuffer[0] = 0x32;
                ToSendDataBuffer[1] = 0x00;
                if(ReceivedDataBuffer[1] < SW_SETTING_NUM)
                {
                    for(fi = 0; fi < SW_DATA_LEN; fi++)
                    {
                        my_sw_infos.SW_Infos.sw_info[ReceivedDataBuffer[1]].data[fi] = ReceivedDataBuffer[2 + fi];
                    }
                }
                else
                {   // NG
                    ToSendDataBuffer[1] = 0xFF;
                }
                if(!HIDTxHandleBusy(USBInHandle))
                {
                    USBInHandle = HIDTxPacket(HID_EP4,(BYTE*)&ToSendDataBuffer[0], TX_DATA_BUFFER_SIZE);
                }
                break;
            case 0x33:  // アナログ設定 取得 [0x33,AN No.] -> [0x33,Ans,AN No.,Data0,Data1,Data2...,Data31]
                ToSendDataBuffer[0] = 0x33;
                ToSendDataBuffer[1] = 0x00;
                ToSendDataBuffer[2] = ReceivedDataBuffer[1];
                if(ReceivedDataBuffer[1] < ANALOG_SETTING_NUM)
                {
                    for(fi = 0; fi < ANALOG_DEVICE_DATA_LEN; fi++)
                    {
                        ToSendDataBuffer[3 + fi] = my_an_infos.AN_Infos.an_info[ReceivedDataBuffer[1]].data[fi];
                    }
                }
                else
                {   // NG
                    ToSendDataBuffer[1] = 0xFF;
                }
                if(!HIDTxHandleBusy(USBInHandle))
                {
                    USBInHandle = HIDTxPacket(HID_EP4,(BYTE*)&ToSendDataBuffer[0], TX_DATA_BUFFER_SIZE);
                }
                break;
            case 0x34:  // アナログ設定 設定 [0x34,AN No.,Data0,Data1,Data2...,Data31] -> [0x34,Ans]
                ToSendDataBuffer[0] = 0x34;
                ToSendDataBuffer[1] = 0x00;
                if(ReceivedDataBuffer[1] < ANALOG_SETTING_NUM)
                {
                    for(fi = 0; fi < ANALOG_DEVICE_DATA_LEN; fi++)
                    {
                        if(fi == ANALOG_DATA_CENTER_VAL_HI_IDX || fi == ANALOG_DATA_CENTER_VAL_LO_IDX)
                        {
                            // 中立位置は上書きしない
                        }
                        else
                        {
                            my_an_infos.AN_Infos.an_info[ReceivedDataBuffer[1]].data[fi] = ReceivedDataBuffer[2 + fi];
                        }
                    }
                    
                    // Analog計算値セット
                    set_analog_output_setup_val();
                }
                else
                {   // NG
                    ToSendDataBuffer[1] = 0xFF;
                }
                if(!HIDTxHandleBusy(USBInHandle))
                {
                    USBInHandle = HIDTxPacket(HID_EP4,(BYTE*)&ToSendDataBuffer[0], TX_DATA_BUFFER_SIZE);
                }
                break;
            case 0x35:  // 中立 自動設定 [0x35,AN No.] -> [0x35,Ans]
                ToSendDataBuffer[0] = 0x35;
                ToSendDataBuffer[1] = 0x00;
                if(ReceivedDataBuffer[1] < ANALOG_SETTING_NUM)
                {
                    eeprom_address = EEPROM_AN_SETTION_ADR + (EEPROM_AN_SETTION_SIZE * ReceivedDataBuffer[1]) + ANALOG_DATA_CENTER_VAL_HI_IDX;
                    b_temp_arry[0] = (BYTE)((ad_input[ReceivedDataBuffer[1]] >> 8) & 0xFF);
                    b_temp_arry[1] = (BYTE)(ad_input[ReceivedDataBuffer[1]] & 0xFF);
                    my_an_infos.AN_Infos.an_info[ReceivedDataBuffer[1]].data[ANALOG_DATA_CENTER_VAL_HI_IDX] = b_temp_arry[0];
                    my_an_infos.AN_Infos.an_info[ReceivedDataBuffer[1]].data[ANALOG_DATA_CENTER_VAL_LO_IDX] = b_temp_arry[1];
                    eeprom_n_write(eeprom_address, &b_temp_arry[0], 2);
                    
                    // Analog計算値セット
                    set_analog_output_setup_val();
                }
                else
                {   // NG
                    ToSendDataBuffer[1] = 0xFF;
                }                
                if(!HIDTxHandleBusy(USBInHandle))
                {
                    USBInHandle = HIDTxPacket(HID_EP4,(BYTE*)&ToSendDataBuffer[0], TX_DATA_BUFFER_SIZE);
                }
                break;
            case 0x36:  // 全中立 自動設定 [0x36] -> [0x36,Ans]
                ToSendDataBuffer[0] = 0x36;
                ToSendDataBuffer[1] = 0x00;
                for(fi = 0; fi < ANALOG_SETTING_NUM; fi++)
                {
                    eeprom_address = EEPROM_AN_SETTION_ADR + (EEPROM_AN_SETTION_SIZE * fi) + ANALOG_DATA_CENTER_VAL_HI_IDX;
                    b_temp_arry[0] = (BYTE)((ad_input[fi] >> 8) & 0xFF);
                    b_temp_arry[1] = (BYTE)(ad_input[fi] & 0xFF);
                    eeprom_n_write(eeprom_address, &b_temp_arry[0], 2);
                }
                
                // Analog計算値セット
                set_analog_output_setup_val();
                        
                if(!HIDTxHandleBusy(USBInHandle))
                {
                    USBInHandle = HIDTxPacket(HID_EP4,(BYTE*)&ToSendDataBuffer[0], TX_DATA_BUFFER_SIZE);
                }
                break;
            case 0x37:  // 中立 設定 [0x37,AN No.,CenterVal Hi,CenterVal Lo] -> [0x37,Ans]
                ToSendDataBuffer[0] = 0x37;
                
                if(ReceivedDataBuffer[1] < ANALOG_SETTING_NUM)
                {
                    w_temp = ReceivedDataBuffer[2];
                    w_temp = (w_temp << 8) + ReceivedDataBuffer[3];
                    if(w_temp <= ANALOG_INPUT_MAX_VALUE)
                    {
                        eeprom_address = EEPROM_AN_SETTION_ADR + (EEPROM_AN_SETTION_SIZE * ReceivedDataBuffer[1]) + ANALOG_DATA_CENTER_VAL_HI_IDX;
                        b_temp_arry[0] = ReceivedDataBuffer[2];
                        b_temp_arry[1] = ReceivedDataBuffer[3];
                        my_an_infos.AN_Infos.an_info[ReceivedDataBuffer[1]].data[ANALOG_DATA_CENTER_VAL_HI_IDX] = b_temp_arry[0];
                        my_an_infos.AN_Infos.an_info[ReceivedDataBuffer[1]].data[ANALOG_DATA_CENTER_VAL_LO_IDX] = b_temp_arry[1];
                        eeprom_n_write(eeprom_address, &b_temp_arry[0], 2);
                    
                        // Analog計算値セット
                        set_analog_output_setup_val();
                        
                        ToSendDataBuffer[1] = 0x00;
                    }
                    else
                    {
                        ToSendDataBuffer[1] = 0xFF;
                    }
                }
                else
                {   // NG
                    ToSendDataBuffer[1] = 0xFF;
                }                
                if(!HIDTxHandleBusy(USBInHandle))
                {
                    USBInHandle = HIDTxPacket(HID_EP4,(BYTE*)&ToSendDataBuffer[0], TX_DATA_BUFFER_SIZE);
                }
                break;
            case 0x38:  // アナログ不感帯 設定 [0x38,AN No.,不感帯値] -> [0x38,Ans]
                ToSendDataBuffer[0] = 0x38;
                
                if(ReceivedDataBuffer[1] < ANALOG_SETTING_NUM)
                {
                    if(ANALOG_DEAD_ZONE_MIN <= ReceivedDataBuffer[2] && ReceivedDataBuffer[2] <= ANALOG_DEAD_ZONE_MAX)
                    {
                        eeprom_address = EEPROM_AN_SETTION_ADR + (EEPROM_AN_SETTION_SIZE * ReceivedDataBuffer[1]) + ANALOG_DATA_DEADZONE_IDX;
                        b_temp_arry[0] = ReceivedDataBuffer[2];
                        my_an_infos.AN_Infos.an_info[ReceivedDataBuffer[1]].data[ANALOG_DATA_DEADZONE_IDX] = b_temp_arry[0];
                        eeprom_n_write(eeprom_address, &b_temp_arry[0], 1);
                        
                        // Analog計算値セット
                        set_analog_output_setup_val();
                        
                        ToSendDataBuffer[1] = 0x00; // OK
                    }
                    else
                    {
                        ToSendDataBuffer[1] = 0xFF; // NG
                    }
                }
                else
                {   // NG
                    ToSendDataBuffer[1] = 0xFF;
                }
                if(!HIDTxHandleBusy(USBInHandle))
                {
                    USBInHandle = HIDTxPacket(HID_EP4,(BYTE*)&ToSendDataBuffer[0], TX_DATA_BUFFER_SIZE);
                }
                break;
            case 0x39:  // アナログ感度 設定 [0x39,AN No.,設定感度] -> [0x39,Ans]
                ToSendDataBuffer[0] = 0x39;
                
                if(ReceivedDataBuffer[1] < ANALOG_SETTING_NUM)
                {
                    if(SENSITIVITY_MIN <= ReceivedDataBuffer[2] && ReceivedDataBuffer[2] <= SENSITIVITY_MAX)
                    {
                        eeprom_address = EEPROM_AN_SETTION_ADR + (EEPROM_AN_SETTION_SIZE * ReceivedDataBuffer[1]) + ANALOG_DATA_SENSE_IDX;
                        b_temp_arry[0] = ReceivedDataBuffer[2];
                        my_an_infos.AN_Infos.an_info[ReceivedDataBuffer[1]].data[ANALOG_DATA_SENSE_IDX] = b_temp_arry[0];
                        eeprom_n_write(eeprom_address, &b_temp_arry[0], 1);
                        
                        // Analog計算値セット
                        set_analog_output_setup_val();
                        
                        ToSendDataBuffer[1] = 0x00; // OK
                    }
                    else
                    {
                        ToSendDataBuffer[1] = 0xFF; // NG
                    }
                }
                else
                {   // NG
                    ToSendDataBuffer[1] = 0xFF;
                }
                if(!HIDTxHandleBusy(USBInHandle))
                {
                    USBInHandle = HIDTxPacket(HID_EP4,(BYTE*)&ToSendDataBuffer[0], TX_DATA_BUFFER_SIZE);
                }
                break;
            case 0x61:  // ソフトリセット要求 [0x61] -> [なし]
                // USB停止
                U1PWRCbits.USUSPEND = 1;
                U1PWRCbits.USBPWR = 0;
                U1CONbits.USBEN = 0;
                // 割り込み無効
                INTDisableInterrupts();
//                // システムロック解除
//                SYSKEY = 0xAA996655;
//                SYSKEY = 0x556699AA;
//                // ソフトリセット実行
//                RSWRSTbits.SWRST = 1;             
//                // システムロック設定
//                SYSKEY = 0x33333333;
                for(w_temp = 0; w_temp < 1000; w_temp++)
                {
                    Soft_Delay(SOFT_DELAY_1MS);
                }
                Reset();
                break;
            case 0x62:  // デフォルトセット要求 [0x62] -> [なし]
                ToSendDataBuffer[0] = 0x62;
                ToSendDataBuffer[1] = 0x00;
                
                b_temp = 0x00;
                eeprom_n_write(0x0000, &b_temp, 1);
                
                for(w_temp = 0; w_temp < 1000; w_temp++)
                {
                    Soft_Delay(SOFT_DELAY_1MS);
                }
                
                if(!HIDTxHandleBusy(USBInHandle))
                {
                    USBInHandle = HIDTxPacket(HID_EP4,(BYTE*)&ToSendDataBuffer[0], TX_DATA_BUFFER_SIZE);
                }
                break;
#if 1	//DEBUG
            case 0x40:
                ToSendDataBuffer[0] = 0x40;				//Echo back to the host PC the command we are fulfilling in the first byte.  In this case, the Get Pushbutton State command.
                ToSendDataBuffer[1] = debug_arr1[0];
                ToSendDataBuffer[2] = debug_arr1[1];
                ToSendDataBuffer[3] = debug_arr1[2];
                ToSendDataBuffer[4] = debug_arr1[3];
                ToSendDataBuffer[5] = debug_arr1[4];
                ToSendDataBuffer[6] = debug_arr1[5];
                ToSendDataBuffer[7] = debug_arr1[6];
                ToSendDataBuffer[8] = debug_arr1[7];
                ToSendDataBuffer[9] = debug_arr1[8];
                ToSendDataBuffer[10] = debug_arr1[9];
                ToSendDataBuffer[11] = debug_arr1[10];
                ToSendDataBuffer[12] = debug_arr1[11];
                ToSendDataBuffer[13] = debug_arr1[12];
                ToSendDataBuffer[14] = debug_arr1[13];
                ToSendDataBuffer[15] = debug_arr1[14];
                ToSendDataBuffer[16] = debug_arr1[15];

                if(!HIDTxHandleBusy(USBInHandle))
                {
                    USBInHandle = HIDTxPacket(HID_EP4,(BYTE*)&ToSendDataBuffer[0],TX_DATA_BUFFER_SIZE);
                }
                break;
            case 0x41:
                ToSendDataBuffer[0] = 0x41;				//Echo back to the host PC the command we are fulfilling in the first byte.  In this case, the Get Pushbutton State command.
#if 1
                ToSendDataBuffer[1] = debug_arr2[0];
                ToSendDataBuffer[2] = debug_arr2[1];
                ToSendDataBuffer[3] = debug_arr2[2];
                ToSendDataBuffer[4] = debug_arr2[3];
                ToSendDataBuffer[5] = debug_arr2[4];
                ToSendDataBuffer[6] = debug_arr2[5];
                ToSendDataBuffer[7] = debug_arr2[6];
                ToSendDataBuffer[8] = debug_arr2[7];
                ToSendDataBuffer[9] = debug_arr2[8];
                ToSendDataBuffer[10] = debug_arr2[9];
                ToSendDataBuffer[11] = debug_arr2[10];
                ToSendDataBuffer[12] = debug_arr2[11];
                ToSendDataBuffer[13] = debug_arr2[12];
                ToSendDataBuffer[14] = debug_arr2[13];
                ToSendDataBuffer[15] = debug_arr2[14];
                ToSendDataBuffer[16] = debug_arr2[15];
#else
                for(fi = 0; fi < SW_NUM; fi++)
                {
                    ToSendDataBuffer[1+fi] = sw_now_fix[fi];
                }
#endif

                if(!HIDTxHandleBusy(USBInHandle))
                {
                    USBInHandle = HIDTxPacket(HID_EP4,(BYTE*)&ToSendDataBuffer[0],TX_DATA_BUFFER_SIZE);
                }
                break;
            case 0x42:
                ToSendDataBuffer[0] = 0x42;				//Echo back to the host PC the command we are fulfilling in the first byte.  In this case, the Get Pushbutton State command.
#if 1
                ToSendDataBuffer[1] = debug_arr3[0];
                ToSendDataBuffer[2] = debug_arr3[1];
                ToSendDataBuffer[3] = debug_arr3[2];
                ToSendDataBuffer[4] = debug_arr3[3];
                ToSendDataBuffer[5] = debug_arr3[4];
                ToSendDataBuffer[6] = debug_arr3[5];
                ToSendDataBuffer[7] = debug_arr3[6];
                ToSendDataBuffer[8] = debug_arr3[7];
                ToSendDataBuffer[9] = debug_arr3[8];
                ToSendDataBuffer[10] = debug_arr3[9];
                ToSendDataBuffer[11] = debug_arr3[10];
                ToSendDataBuffer[12] = debug_arr3[11];
                ToSendDataBuffer[13] = debug_arr3[12];
                ToSendDataBuffer[14] = debug_arr3[13];
                ToSendDataBuffer[15] = debug_arr3[14];
                ToSendDataBuffer[16] = debug_arr3[15];
#else
                for(fi = 0; fi < AD_INPUT_NUM; fi++)
                {
                    ToSendDataBuffer[1+(fi*2)] = (BYTE)((ad_input[fi] >> 8) & 0xFF);
                    ToSendDataBuffer[1+(fi*2)+1] = (BYTE)(ad_input[fi] & 0xFF);
                }
#endif
                if(!HIDTxHandleBusy(USBInHandle))
                {
                    USBInHandle = HIDTxPacket(HID_EP4,(BYTE*)&ToSendDataBuffer[0],TX_DATA_BUFFER_SIZE);
                }
                break;
#endif	//DEBUG
        }
        //Re-arm the OUT endpoint, so we can receive the next OUT data packet
        //that the host may try to send us.
        USBOutHandle = HIDRxPacket(HID_EP4, (BYTE*)&ReceivedDataBuffer, RX_DATA_BUFFER_SIZE);
    }


//    return;
}//end USB_Comm()


