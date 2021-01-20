#include "Main_sub.h"


void Soft_Delay(DWORD delayValue);
void Switch_Input(void);

// *****************************************************************************
// *****************************************************************************
// Section: Software Delay
// *****************************************************************************
// *****************************************************************************
void Soft_Delay(DWORD delayValue)
{
    DWORD tmp32=0;

    TMR4 = 0;
    TMR5 = 0;
    while(1)
    {
        tmp32 = TMR5;                   // Timer32 上位16bit
        tmp32 = (tmp32 << 16) | TMR4;   // Timer32 下位16bit
        if(tmp32 >= delayValue)
        {
            break;
        }
    }
}

void Switch_Input(void)
{
    BYTE fi, fj;
    BYTE sw_now[SW_NUM];

    sw_now[SW_1_NO_IDX] 	= SW_1_NO;
    sw_now[SW_2_NO_IDX] 	= SW_2_NO;
    sw_now[SW_3_NO_IDX] 	= SW_3_NO;
    sw_now[SW_4_NO_IDX] 	= SW_4_NO;
    sw_now[SW_5_NO_IDX] 	= SW_5_NO;
    sw_now[SW_6_NO_IDX] 	= SW_6_NO;
    sw_now[SW_7_NO_IDX] 	= SW_7_NO;
    sw_now[SW_8_NO_IDX] 	= SW_8_NO;
    sw_now[SW_9_NO_IDX] 	= SW_9_NO;
    sw_now[SW_10_NO_IDX] 	= SW_10_NO;
    sw_now[SW_11_NO_IDX] 	= SW_11_NO;
    sw_now[SW_12_NO_IDX] 	= SW_12_NO;
    sw_now[SW_13_NO_IDX] 	= SW_13_NO;
    sw_now[SW_14_NO_IDX] 	= SW_14_NO;
    sw_now[SW_15_NO_IDX] 	= SW_15_NO;

    for( fi = 0; fi < SW_NUM; fi++ )
    {
        if(sw_now[fi] == R_ON)
        {
            sw_press_on_cnt[fi]++;
            if( sw_press_on_cnt[fi] >= SW_ON_DEBOUNCE_TIME)
            {
                sw_now_fix[fi] = N_ON;
                sw_press_on_cnt[fi] = SW_ON_DEBOUNCE_TIME;
                
                if(USB_Sleep_Flag == 1)
                {
                    USBCBSendResume();
                }
            }
            sw_press_off_cnt[fi] = 0;
        }
        else
        {
            sw_press_off_cnt[fi]++;
            if(sw_press_off_cnt[fi] >= SW_OFF_DEBOUNCE_TIME)
            {
                sw_now_fix[fi] = N_OFF;
                sw_press_off_cnt[fi] = SW_OFF_DEBOUNCE_TIME;
            }
            sw_press_on_cnt[fi] = 0;
        }

        // SW Push時の処理追加
        if( sw_now_fix_pre[fi] == N_OFF && sw_now_fix[fi] == N_ON )
        {	// 前回=OFF  今回=ON
            
        }
        else if( sw_now_fix_pre[fi] == N_ON && sw_now_fix[fi] == N_OFF )
        {	// 前回=ON  今回=OFF
            
        }

        // 今回値保存
        sw_now_fix_pre[fi] = sw_now_fix[fi];
    }
}

void SW_Keyboard_Data_Set(BYTE p_sw_no, BYTE p_modify, BYTE p_key)
{
    BYTE found_flag = 0;
    BYTE fi = 0;
    
    if(p_sw_no < SW_NUM && set_keyboard_push_order_write_idx < SET_KEYBOARD_PUSH_ORDER_BUFF_SIZE)
    {
        if(set_keyboard_push_order_write_idx > 0)
        {
            for(fi = 0; fi < set_keyboard_push_order_write_idx; fi++)
            {
                if(set_keyboard_push_order_buff[fi] == p_sw_no)
                {   // 登録済み
                    found_flag = 1;
                    break;
                }
            }
        }
        
        // 未登録のため登録する
        if(found_flag == 0)
        {
            set_keyboard_push_order_buff[set_keyboard_push_order_write_idx] = p_sw_no;
            set_keyboard_push_order_ctrl_bit[set_keyboard_push_order_write_idx] = p_modify;
            set_keyboard_push_order_key_code[set_keyboard_push_order_write_idx] = p_key;
            set_keyboard_push_order_write_idx++;
        }
    }
}
void SW_Output_Keyboard(BYTE* out_buff, BYTE buff_size)
{
    int fi;
    BYTE fj;
    BYTE set_pos = KEYBOARD_KEYCODE_TOP;
    BYTE temp_key_order_buff[KEYBOARD_KEYCODE_NUM];
    BYTE key_order_buff_set_pos = 0;
    BYTE key_order_buff_set_key_count = 0;
    
    // 出力バッファクリア
    for(fi = 0; fi < buff_size; fi++)
    {
        out_buff[fi] = 0;
    }
    
    if(set_keyboard_push_order_write_idx > 0)
    {
        for(fi = (set_keyboard_push_order_write_idx - 1); fi >= 0; fi--)
        {
            if(set_keyboard_push_order_buff[fi] != 0xFF)
            {
#if 1   // キーコードバッファ数以上のキーを押されたら過去キーは消去
                if(key_order_buff_set_key_count < KEYBOARD_KEYCODE_NUM)
                {
                    if(set_keyboard_push_order_key_code[fi] != 0)
                    {
                        key_order_buff_set_key_count++;
                    }
                    
                    temp_key_order_buff[key_order_buff_set_pos] = fi;
                    key_order_buff_set_pos++;
                }
                else
                {
                    set_keyboard_push_order_buff[fi] = 0xFF;
                    set_keyboard_push_order_ctrl_bit[fi] = 0;
                    set_keyboard_push_order_key_code[fi] = 0;
                }
#endif
#if 0   // キーコードバッファ数以上のキーを押されたら過去キーは残す
                temp_key_order_buff[key_order_buff_set_count] = fi;
                key_order_buff_set_count++;
                if(key_order_buff_set_count >= KEYBOARD_KEYCODE_NUM)
                {
                    break;
                }
#endif
            }
        }
        if(key_order_buff_set_pos > 0)
        {
            for(fi = (key_order_buff_set_pos - 1); fi >= 0; fi--)
            {
                out_buff[KEYBOARD_MODIFIER_IDX] |= set_keyboard_push_order_ctrl_bit[temp_key_order_buff[fi]];
                if(set_keyboard_push_order_key_code[temp_key_order_buff[fi]] != 0 && set_pos < KEYBOARD_BUFF_SIZE)
                {
                    out_buff[set_pos++] = set_keyboard_push_order_key_code[temp_key_order_buff[fi]];
                }
            }
        }
    }
}

void keyboard_push_order_buff_optimization(void)
{
    BYTE fi, fj, count;
    
    if(set_keyboard_push_order_write_idx > 0)
    {
        count = 0;
        for(fi = 0; fi < set_keyboard_push_order_write_idx; fi++)
        {
            if(set_keyboard_push_order_buff[fi] == 0xFF)
            {
                for(fj = (fi+1); fj < set_keyboard_push_order_write_idx; fj++)
                {
                    if(set_keyboard_push_order_buff[fj] != 0xFF)
                    {
                        set_keyboard_push_order_buff[fi] = set_keyboard_push_order_buff[fj];
                        set_keyboard_push_order_ctrl_bit[fi] = set_keyboard_push_order_ctrl_bit[fj];
                        set_keyboard_push_order_key_code[fi] = set_keyboard_push_order_key_code[fj];
                        
                        set_keyboard_push_order_buff[fj] = 0xFF;
                        set_keyboard_push_order_ctrl_bit[fj] = 0;
                        set_keyboard_push_order_key_code[fj] = 0;
                        
                        count++;
                        break;
                    }
                }
            }
            else
            {
                count++;
            }
        }
        
        set_keyboard_push_order_write_idx = count;
    }
}

void Check_SWInfo(void)
{
    BYTE fi, data_idx;
    
    for(fi = 0; fi < SW_SETTING_NUM; fi++)
    {
        // デバイス設定値チェック
        if(my_sw_infos.SW_Infos.sw_info[fi].data[SW_DATA_SET_DEVICE_TYPE_IDX] >= SW_SET_DEVICE_TYPE_NUM)
        {
            my_sw_infos.SW_Infos.sw_info[fi].data[SW_DATA_SET_DEVICE_TYPE_IDX] = SW_SET_DEVICE_TYPE_NONE;
            for(data_idx = (SW_DATA_SET_DEVICE_TYPE_IDX + 1); data_idx < SW_DATA_LEN; data_idx++)
            {
                my_sw_infos.SW_Infos.sw_info[fi].data[data_idx] = 0;
            }
        }
        // 感度チェック
        if(my_sw_infos.SW_Infos.sw_info[fi].data[SW_DATA_SENSE_IDX] < SENSITIVITY_MIN || SENSITIVITY_MAX < my_sw_infos.SW_Infos.sw_info[fi].data[SW_DATA_SENSE_IDX])
        {
            my_sw_infos.SW_Infos.sw_info[fi].data[SW_DATA_SENSE_IDX] = SENSITIVITY_DEFAULT;
        }
        // デバイス設定毎のデータチェック
        switch(my_sw_infos.SW_Infos.sw_info[fi].data[SW_DATA_SET_DEVICE_TYPE_IDX])
        {
            case SW_SET_DEVICE_TYPE_NONE:
                for(data_idx = SW_DATA_SET_TYPE_IDX; data_idx < SW_DATA_LEN; data_idx++)
                {
                    my_sw_infos.SW_Infos.sw_info[fi].data[data_idx] = 0;
                }
                break;
            case SW_SET_DEVICE_TYPE_MOUSE:
                if(my_sw_infos.SW_Infos.sw_info[fi].data[SW_DATA_SET_TYPE_IDX] >= SW_SET_TYPE_MOUSE_NUM)
                {
                    for(data_idx = SW_DATA_SET_TYPE_IDX; data_idx < SW_DATA_LEN; data_idx++)
                    {
                        my_sw_infos.SW_Infos.sw_info[fi].data[data_idx] = 0;
                    }
                }
                break;
            case SW_SET_DEVICE_TYPE_KEYBOARD:
                if(my_sw_infos.SW_Infos.sw_info[fi].data[SW_DATA_SET_TYPE_IDX] == 0xFF)
                {
                    for(data_idx = SW_DATA_SET_TYPE_IDX; data_idx < SW_DATA_LEN; data_idx++)
                    {
                        my_sw_infos.SW_Infos.sw_info[fi].data[data_idx] = 0;
                    }
                }
                break;
            case SW_SET_DEVICE_TYPE_JOYSTICK:
                if(my_sw_infos.SW_Infos.sw_info[fi].data[SW_DATA_SET_TYPE_IDX] == 0xFF)
                {
                    for(data_idx = SW_DATA_SET_TYPE_IDX; data_idx < SW_DATA_LEN; data_idx++)
                    {
                        my_sw_infos.SW_Infos.sw_info[fi].data[data_idx] = 0;
                    }
                }
                break;
        }
    }
}

void Check_ANInfo(void)
{
    BYTE fi, data_idx;
    WORD w_temp;
    BYTE check_error_flag = 0;
    WORD temp_1, temp_2, temp_3, temp_4, temp_5;
    WORD set_idx = 0;
    
    for(fi = 0; fi < ANALOG_SETTING_NUM; fi++)
    {
        // デバイス設定値チェック
        if(my_an_infos.AN_Infos.an_info[fi].data[ANALOG_DATA_SET_TYPE_IDX] >= ANALOG_SET_TYPE_NUM)
        {
            my_an_infos.AN_Infos.an_info[fi].data[ANALOG_DATA_SET_TYPE_IDX] = ANALOG_SET_TYPE_NONE;
            for(data_idx = (ANALOG_DATA_SET_TYPE_IDX + 1); data_idx < ANALOG_DEVICE_DATA_LEN; data_idx++)
            {
                my_an_infos.AN_Infos.an_info[fi].data[data_idx] = 0;
            }
        }
        switch(my_an_infos.AN_Infos.an_info[fi].data[ANALOG_DATA_SET_TYPE_IDX])
        {
            case ANALOG_SET_TYPE_NONE:
                break;
            case ANALOG_SET_TYPE_JOYSTICK_X:
            case ANALOG_SET_TYPE_JOYSTICK_Y:
            case ANALOG_SET_TYPE_JOYSTICK_Z:
            case ANALOG_SET_TYPE_JOYSTICK_RX:
            case ANALOG_SET_TYPE_JOYSTICK_RY:
            case ANALOG_SET_TYPE_JOYSTICK_RZ:
            case ANALOG_SET_TYPE_JOYSTICK_SL:
                // 設定値範囲チェック
                // 電圧値の大小関係チェック
                temp_1 = my_an_infos.AN_Infos.an_info[fi].data[ANALOG_DATA_VOL1HI_IDX];
                temp_1 = (temp_1 << 8) + my_an_infos.AN_Infos.an_info[fi].data[ANALOG_DATA_VOL1LO_IDX];
                temp_2 = my_an_infos.AN_Infos.an_info[fi].data[ANALOG_DATA_VOL2HI_IDX];
                temp_2 = (temp_2 << 8) + my_an_infos.AN_Infos.an_info[fi].data[ANALOG_DATA_VOL2LO_IDX];
                temp_3 = my_an_infos.AN_Infos.an_info[fi].data[ANALOG_DATA_VOL3HI_IDX];
                temp_3 = (temp_3 << 8) + my_an_infos.AN_Infos.an_info[fi].data[ANALOG_DATA_VOL3LO_IDX];
                if (temp_1 >= temp_2 || temp_2 >= temp_3)
                {
                    check_error_flag = 1;
                }
                // 出力値の大小関係チェック
                temp_1 = my_an_infos.AN_Infos.an_info[fi].data[ANALOG_DATA_0V_VAL_IDX];
                temp_2 = my_an_infos.AN_Infos.an_info[fi].data[ANALOG_DATA_VAL1_IDX];
                temp_3 = my_an_infos.AN_Infos.an_info[fi].data[ANALOG_DATA_VAL2_IDX];
                temp_4 = my_an_infos.AN_Infos.an_info[fi].data[ANALOG_DATA_VAL3_IDX];
                temp_5 = my_an_infos.AN_Infos.an_info[fi].data[ANALOG_DATA_3V_VAL_IDX];
                if (temp_1 > temp_2 || temp_2 > temp_3 || temp_3 > temp_4 || temp_4 > temp_5)
                {
//                    check_error_flag = 1;
                }
                if (check_error_flag == 1)
                {   // 設定値異常 デフォルト値セット
                    set_idx = EEPROM_AN_SETTION_ADR + (EEPROM_AN_SETTION_SIZE * fi) + ANALOG_DATA_0V_VAL_IDX;
                    for (data_idx = ANALOG_DATA_0V_VAL_IDX; data_idx < ANALOG_DEVICE_DATA_LEN; data_idx++, set_idx++)
                    {
                        my_an_infos.AN_Infos.an_info[fi].data[data_idx] = c_eeprom_default_data[set_idx];
                    }
                }
                break;
            case ANALOG_SET_TYPE_MOUSE_X:
            case ANALOG_SET_TYPE_MOUSE_Y:
                // 不感帯チェック
                if(my_an_infos.AN_Infos.an_info[fi].data[ANALOG_DATA_DEADZONE_IDX] < ANALOG_DEAD_ZONE_MIN || ANALOG_DEAD_ZONE_MAX < my_an_infos.AN_Infos.an_info[fi].data[ANALOG_DATA_DEADZONE_IDX])
                {
                    my_an_infos.AN_Infos.an_info[fi].data[ANALOG_DATA_DEADZONE_IDX] = ANALOG_DEAD_ZONE_DEFAULT;
                }
                break;
            default:
                for(data_idx = ANALOG_DATA_SET_TYPE_IDX; data_idx < ANALOG_DEVICE_DATA_LEN; data_idx++)
                {
                    my_an_infos.AN_Infos.an_info[fi].data[data_idx] = 0;
                }
                break;
        }
        
        // 感度チェック
        if(my_an_infos.AN_Infos.an_info[fi].data[ANALOG_DATA_SENSE_IDX] < SENSITIVITY_MIN || SENSITIVITY_MAX < my_an_infos.AN_Infos.an_info[fi].data[ANALOG_DATA_SENSE_IDX])
        {
            my_an_infos.AN_Infos.an_info[fi].data[ANALOG_DATA_SENSE_IDX] = SENSITIVITY_DEFAULT;
        }
        // 中立チェック
        w_temp = my_an_infos.AN_Infos.an_info[fi].data[ANALOG_DATA_CENTER_VAL_HI_IDX];
        w_temp = (w_temp << 8) + my_an_infos.AN_Infos.an_info[fi].data[ANALOG_DATA_CENTER_VAL_LO_IDX];
        if(w_temp > ANALOG_INPUT_MAX_VALUE)
        {
            my_an_infos.AN_Infos.an_info[fi].data[ANALOG_DATA_CENTER_VAL_HI_IDX] = (BYTE)((ANALOG_INPUT_CENTER_DEFAULT_VALUE >> 8) & 0xFF);
            my_an_infos.AN_Infos.an_info[fi].data[ANALOG_DATA_CENTER_VAL_LO_IDX] = (BYTE)(ANALOG_INPUT_CENTER_DEFAULT_VALUE & 0xFF);
        }
        
    }
}

BYTE get_joystick_hat_sw_usb_output(BYTE p_hat_sw_out_flag)
{
    BYTE ret_val = USB_HAT_SWITCH_NULL;
    
    if((p_hat_sw_out_flag & HAT_SWITCH_BIT_NORTH) == HAT_SWITCH_BIT_NORTH && (p_hat_sw_out_flag & HAT_SWITCH_BIT_SOUTH) == HAT_SWITCH_BIT_SOUTH)
    {   // error
    }
    else if((p_hat_sw_out_flag & HAT_SWITCH_BIT_WEST) == HAT_SWITCH_BIT_WEST && (p_hat_sw_out_flag & HAT_SWITCH_BIT_EAST) == HAT_SWITCH_BIT_EAST)
    {   // error
    }
    else
    {
        if((p_hat_sw_out_flag & HAT_SWITCH_BIT_NORTH) == HAT_SWITCH_BIT_NORTH)
        {
            if((p_hat_sw_out_flag & HAT_SWITCH_BIT_WEST) == HAT_SWITCH_BIT_WEST)
            {
                ret_val = USB_HAT_SWITCH_NORTH_WEST;
            }
            else if((p_hat_sw_out_flag & HAT_SWITCH_BIT_EAST) == HAT_SWITCH_BIT_EAST)
            {
                ret_val = USB_HAT_SWITCH_NORTH_EAST;
            }
            else
            {
                ret_val = USB_HAT_SWITCH_NORTH;
            }
        }
        else if((p_hat_sw_out_flag & HAT_SWITCH_BIT_SOUTH) == HAT_SWITCH_BIT_SOUTH)
        {
            if((p_hat_sw_out_flag & HAT_SWITCH_BIT_WEST) == HAT_SWITCH_BIT_WEST)
            {
                ret_val = USB_HAT_SWITCH_SOUTH_WEST;
            }
            else if((p_hat_sw_out_flag & HAT_SWITCH_BIT_EAST) == HAT_SWITCH_BIT_EAST)
            {
                ret_val = USB_HAT_SWITCH_SOUTH_EAST;
            }
            else
            {
                ret_val = USB_HAT_SWITCH_SOUTH;
            }
        }
        else if((p_hat_sw_out_flag & HAT_SWITCH_BIT_WEST) == HAT_SWITCH_BIT_WEST)
        {
            ret_val = USB_HAT_SWITCH_WEST;
        }
        else if((p_hat_sw_out_flag & HAT_SWITCH_BIT_EAST) == HAT_SWITCH_BIT_EAST)
        {
            ret_val = USB_HAT_SWITCH_EAST;
        }
    }
    
    return ret_val;
}

void set_joystick_lever_usb_output(BYTE* p_joystick_lever_out_flag, BYTE out_flag_size, BYTE* out_buff, BYTE buff_size)
{
    BYTE fi = 0;
    BYTE out_check = 0;
    
    for(fi = 0; fi < out_flag_size; fi++)
    {
        if(p_joystick_lever_out_flag[fi] != 0)
        {
            out_check = 1;
            break;
        }
    }
    if(out_check == 1)
    {
        // X
        if((p_joystick_lever_out_flag[LEVER_SWITCH_BYTE_POS_X_P] & LEVER_SWITCH_BIT_X) == LEVER_SWITCH_BIT_X_P)
        {
            out_buff[USB_JOYSTICK_LEVER_X_IDX] = 0xFF;
        }
        if((p_joystick_lever_out_flag[LEVER_SWITCH_BYTE_POS_X_M] & LEVER_SWITCH_BIT_X) == LEVER_SWITCH_BIT_X_M)
        {
            out_buff[USB_JOYSTICK_LEVER_X_IDX] = 0x00;
        }
        // Y
        if((p_joystick_lever_out_flag[LEVER_SWITCH_BYTE_POS_Y_P] & LEVER_SWITCH_BIT_Y) == LEVER_SWITCH_BIT_Y_P)
        {
            out_buff[USB_JOYSTICK_LEVER_Y_IDX] = 0xFF;
        }
        if((p_joystick_lever_out_flag[LEVER_SWITCH_BYTE_POS_Y_M] & LEVER_SWITCH_BIT_Y) == LEVER_SWITCH_BIT_Y_M)
        {
            out_buff[USB_JOYSTICK_LEVER_Y_IDX] = 0x00;
        }
        // Z
        if((p_joystick_lever_out_flag[LEVER_SWITCH_BYTE_POS_Z_P] & LEVER_SWITCH_BIT_Z) == LEVER_SWITCH_BIT_Z_P)
        {
            out_buff[USB_JOYSTICK_LEVER_Z_IDX] = 0xFF;
        }
        if((p_joystick_lever_out_flag[LEVER_SWITCH_BYTE_POS_Z_M] & LEVER_SWITCH_BIT_Z) == LEVER_SWITCH_BIT_Z_M)
        {
            out_buff[USB_JOYSTICK_LEVER_Z_IDX] = 0x00;
        }
        // RX
        if((p_joystick_lever_out_flag[LEVER_SWITCH_BYTE_POS_RX_P] & LEVER_SWITCH_BIT_RX) == LEVER_SWITCH_BIT_RX_P)
        {
            out_buff[USB_JOYSTICK_LEVER_RX_IDX] = 0xFF;
        }
        if((p_joystick_lever_out_flag[LEVER_SWITCH_BYTE_POS_RX_M] & LEVER_SWITCH_BIT_RX) == LEVER_SWITCH_BIT_RX_M)
        {
            out_buff[USB_JOYSTICK_LEVER_RX_IDX] = 0x00;
        }
        // RY
        if((p_joystick_lever_out_flag[LEVER_SWITCH_BYTE_POS_RY_P] & LEVER_SWITCH_BIT_RY) == LEVER_SWITCH_BIT_RY_P)
        {
            out_buff[USB_JOYSTICK_LEVER_RY_IDX] = 0xFF;
        }
        if((p_joystick_lever_out_flag[LEVER_SWITCH_BYTE_POS_RY_M] & LEVER_SWITCH_BIT_RY) == LEVER_SWITCH_BIT_RY_M)
        {
            out_buff[USB_JOYSTICK_LEVER_RY_IDX] = 0x00;
        }
        // RZ
        if((p_joystick_lever_out_flag[LEVER_SWITCH_BYTE_POS_RZ_P] & LEVER_SWITCH_BIT_RZ) == LEVER_SWITCH_BIT_RZ_P)
        {
            out_buff[USB_JOYSTICK_LEVER_RZ_IDX] = 0xFF;
        }
        if((p_joystick_lever_out_flag[LEVER_SWITCH_BYTE_POS_RZ_M] & LEVER_SWITCH_BIT_RZ) == LEVER_SWITCH_BIT_RZ_M)
        {
            out_buff[USB_JOYSTICK_LEVER_RZ_IDX] = 0x00;
        }
        // SLIDER
        if((p_joystick_lever_out_flag[LEVER_SWITCH_BYTE_POS_SL_P] & LEVER_SWITCH_BIT_SL) == LEVER_SWITCH_BIT_SL_P)
        {
            out_buff[USB_JOYSTICK_LEVER_SLIDER_IDX_TOP] = 0xFF;
        }
        if((p_joystick_lever_out_flag[LEVER_SWITCH_BYTE_POS_SL_M] & LEVER_SWITCH_BIT_SL) == LEVER_SWITCH_BIT_SL_M)
        {
            out_buff[USB_JOYSTICK_LEVER_SLIDER_IDX_TOP] = 0x00;
        }
    }
}

// アナログ出力値の計算用の現在の電圧値と値をセット
void set_analog_output_setup_val(void)
{
    BYTE fi, fj;
    DWORD dw_temp;
    WORD w_temp, w_temp2;
    
    for(fi = 0; fi < ANALOG_SETTING_NUM; fi++)
    {
        // アナログ　ジョイスティック
        if(ANALOG_SET_TYPE_JOYSTICK_X <= my_an_infos.AN_Infos.an_info[fi].data[ANALOG_DATA_SET_TYPE_IDX] && my_an_infos.AN_Infos.an_info[fi].data[ANALOG_DATA_SET_TYPE_IDX] <= ANALOG_SET_TYPE_JOYSTICK_SL)
        {
            // 0V
            an_out_setup_ad_val[fi][0] = 0;
            an_out_setup_out_val[fi][0] = my_an_infos.AN_Infos.an_info[fi].data[ANALOG_DATA_0V_VAL_IDX];
            // 1
            dw_temp = my_an_infos.AN_Infos.an_info[fi].data[ANALOG_DATA_VOL1HI_IDX];
            dw_temp = (dw_temp << 8) | my_an_infos.AN_Infos.an_info[fi].data[ANALOG_DATA_VOL1LO_IDX];
            dw_temp = dw_temp & ANALOG_INPUT_MAX_VALUE;
            dw_temp = dw_temp * ANALOG_INPUT_MAX_VALUE / ANALOG_VOLTAGE_MAX_VALUE;
            an_out_setup_ad_val[fi][1] = (WORD)dw_temp;
            an_out_setup_out_val[fi][1] = my_an_infos.AN_Infos.an_info[fi].data[ANALOG_DATA_VAL1_IDX];
            // 2
            dw_temp = my_an_infos.AN_Infos.an_info[fi].data[ANALOG_DATA_VOL2HI_IDX];
            dw_temp = (dw_temp << 8) | my_an_infos.AN_Infos.an_info[fi].data[ANALOG_DATA_VOL2LO_IDX];
            dw_temp = dw_temp & ANALOG_INPUT_MAX_VALUE;
            dw_temp = dw_temp * ANALOG_INPUT_MAX_VALUE / ANALOG_VOLTAGE_MAX_VALUE;
            an_out_setup_ad_val[fi][2] = (WORD)dw_temp;
            an_out_setup_out_val[fi][2] = my_an_infos.AN_Infos.an_info[fi].data[ANALOG_DATA_VAL2_IDX];
            // 3
            dw_temp = my_an_infos.AN_Infos.an_info[fi].data[ANALOG_DATA_VOL3HI_IDX];
            dw_temp = (dw_temp << 8) | my_an_infos.AN_Infos.an_info[fi].data[ANALOG_DATA_VOL3LO_IDX];
            dw_temp = dw_temp & ANALOG_INPUT_MAX_VALUE;
            dw_temp = dw_temp * ANALOG_INPUT_MAX_VALUE / ANALOG_VOLTAGE_MAX_VALUE;
            an_out_setup_ad_val[fi][3] = (WORD)dw_temp;
            an_out_setup_out_val[fi][3] = my_an_infos.AN_Infos.an_info[fi].data[ANALOG_DATA_VAL3_IDX];
            // 3.3V
            an_out_setup_ad_val[fi][4] = ANALOG_INPUT_MAX_VALUE;
            an_out_setup_out_val[fi][4] = my_an_infos.AN_Infos.an_info[fi].data[ANALOG_DATA_3V_VAL_IDX];
            
            for(fj = 0; fj < ANALOG_MATH_CENTER_NUM; fj++)
            {
                an_out_setup_center_val[fi][fj] = 0;
            }
        }
        else if(ANALOG_SET_TYPE_MOUSE_X <= my_an_infos.AN_Infos.an_info[fi].data[ANALOG_DATA_SET_TYPE_IDX] && my_an_infos.AN_Infos.an_info[fi].data[ANALOG_DATA_SET_TYPE_IDX] <= ANALOG_SET_TYPE_MOUSE_Y)
        {   // アナログ　マウス
            w_temp = my_an_infos.AN_Infos.an_info[fi].data[ANALOG_DATA_CENTER_VAL_HI_IDX];
            w_temp = (w_temp << 8) + my_an_infos.AN_Infos.an_info[fi].data[ANALOG_DATA_CENTER_VAL_LO_IDX];
            an_out_setup_center_val[fi][0] = w_temp;    // 中立値セット
            
            // 不感帯セット
            if(ANALOG_DEAD_ZONE_MIN <= my_an_infos.AN_Infos.an_info[fi].data[ANALOG_DATA_DEADZONE_IDX] && my_an_infos.AN_Infos.an_info[fi].data[ANALOG_DATA_DEADZONE_IDX] <= ANALOG_DEAD_ZONE_MAX)
            {   // 不感帯の電圧値設定からAD値へ変換
                dw_temp = ((DWORD)my_an_infos.AN_Infos.an_info[fi].data[ANALOG_DATA_DEADZONE_IDX] * (DWORD)ANALOG_INPUT_MAX_VALUE) / ANALOG_VOLTAGE_MAX_VALUE;
                w_temp2 = (WORD)dw_temp;    // 不感帯AD値
            }
            else
            {   // 不感帯設定値異常 デフォルト値で計算
                dw_temp = ((DWORD)ANALOG_DEAD_ZONE_DEFAULT * (DWORD)ANALOG_INPUT_MAX_VALUE) / ANALOG_VOLTAGE_MAX_VALUE;
                w_temp2 = (WORD)dw_temp;    // 不感帯AD値
            }
            // 不感帯最小値セット
            if(w_temp >= w_temp2)
            {
                an_out_setup_center_val[fi][1] = w_temp - w_temp2;
            }
            else
            {
                an_out_setup_center_val[fi][1] = 0;
            }
            // 不感帯最大値セット
            an_out_setup_center_val[fi][2] = w_temp + w_temp2;
            if(an_out_setup_center_val[fi][2] > ANALOG_INPUT_MAX_VALUE)
            {
                an_out_setup_center_val[fi][2] = ANALOG_INPUT_MAX_VALUE;
            }
            
            for(fj = 0; fj < ANALOG_MATH_VOL_NUM; fj++)
            {
                an_out_setup_ad_val[fi][fj] = 0;
                an_out_setup_out_val[fi][fj] = 0;
            }
        }
        else
        {
            for(fj = 0; fj < ANALOG_MATH_VOL_NUM; fj++)
            {
                an_out_setup_ad_val[fi][fj] = 0;
                an_out_setup_out_val[fi][fj] = 0;
            }
            for(fj = 0; fj < ANALOG_MATH_CENTER_NUM; fj++)
            {
                an_out_setup_center_val[fi][fj] = 0;
            }
        }
    }
    
}
// アナログ出力のUSBジョイスティック出力値をセット
void set_analog_usb_joystick_output(BYTE* out_buff, BYTE buff_size)
{
    int fi;
    
    for(fi = (ANALOG_SETTING_NUM-1); fi >= 0; fi--)
    {
        switch(an_joystick_lever_out_flag[fi])
        {
            case ANALOG_SET_TYPE_JOYSTICK_X:
                out_buff[USB_JOYSTICK_LEVER_X_IDX] = an_joystick_lever_out_value[fi];
                break;
            case ANALOG_SET_TYPE_JOYSTICK_Y:
                out_buff[USB_JOYSTICK_LEVER_Y_IDX] = an_joystick_lever_out_value[fi];
                break;
            case ANALOG_SET_TYPE_JOYSTICK_Z:
                out_buff[USB_JOYSTICK_LEVER_Z_IDX] = an_joystick_lever_out_value[fi];
                break;
            case ANALOG_SET_TYPE_JOYSTICK_RX:
                out_buff[USB_JOYSTICK_LEVER_RX_IDX] = an_joystick_lever_out_value[fi];
                break;
            case ANALOG_SET_TYPE_JOYSTICK_RY:
                out_buff[USB_JOYSTICK_LEVER_RY_IDX] = an_joystick_lever_out_value[fi];
                break;
            case ANALOG_SET_TYPE_JOYSTICK_RZ:
                out_buff[USB_JOYSTICK_LEVER_RZ_IDX] = an_joystick_lever_out_value[fi];
                break;
            case ANALOG_SET_TYPE_JOYSTICK_SL:
                out_buff[USB_JOYSTICK_LEVER_SLIDER_IDX_TOP] = an_joystick_lever_out_value[fi];
                break;
        }
    }
}
// アナログ出力のUSBマウス出力値をセット
void set_analog_usb_mouse_output(BYTE* out_buff, BYTE buff_size)
{
    int fi;
    BYTE b_temp;
    
    for(fi = (ANALOG_SETTING_NUM-1); fi >= 0; fi--)
    {
        switch(an_joystick_lever_out_flag[fi])
        {
            case ANALOG_SET_TYPE_MOUSE_X:
                if(an_joystick_lever_out_value[fi] != 0)
                {
                    if(an_joystick_lever_out_value[fi] <= 0x7F)
                    {   // プラス方向
                        b_temp = an_joystick_lever_out_value[fi];
                        an_mouse_count_val[fi][0] += b_temp;
                        an_mouse_count_val[fi][1] = 0;
                        
                        if(an_mouse_count_val[fi][0] >= MASTER_MOUSE_SPEED)
                        {
                            out_buff[USB_MOUSE_MOVE_X_IDX] = (BYTE)((an_mouse_count_val[fi][0] / MASTER_MOUSE_SPEED) & 0xFF);
                            an_mouse_count_val[fi][0] = an_mouse_count_val[fi][0] % MASTER_MOUSE_SPEED;
                        }
                    }
                    else
                    {   // マイナス方向
                        b_temp = 0x100 - an_joystick_lever_out_value[fi];
                        an_mouse_count_val[fi][1] += b_temp;
                        an_mouse_count_val[fi][0] = 0;
                        
                        if(an_mouse_count_val[fi][1] >= MASTER_MOUSE_SPEED)
                        {
                            out_buff[USB_MOUSE_MOVE_X_IDX] = (BYTE)((-1 * (an_mouse_count_val[fi][1] / MASTER_MOUSE_SPEED)) & 0xFF);
                            an_mouse_count_val[fi][1] = an_mouse_count_val[fi][1] % MASTER_MOUSE_SPEED;
                        }
                    }
                }
                else
                {
                    an_mouse_count_val[fi][0] = 0;
                    an_mouse_count_val[fi][1] = 0;
                }
                break;
            case ANALOG_SET_TYPE_MOUSE_Y:
                if(an_joystick_lever_out_value[fi] != 0)
                {
                    if(an_joystick_lever_out_value[fi] <= 0x7F)
                    {   // プラス方向
                        b_temp = an_joystick_lever_out_value[fi];
                        an_mouse_count_val[fi][0] += b_temp;
                        an_mouse_count_val[fi][1] = 0;
                        
                        if(an_mouse_count_val[fi][0] >= MASTER_MOUSE_SPEED)
                        {
                            out_buff[USB_MOUSE_MOVE_Y_IDX] = (BYTE)((an_mouse_count_val[fi][0] / MASTER_MOUSE_SPEED) & 0xFF);
                            an_mouse_count_val[fi][0] = an_mouse_count_val[fi][0] % MASTER_MOUSE_SPEED;
                        }
                    }
                    else
                    {   // マイナス方向
                        b_temp = 0x100 - an_joystick_lever_out_value[fi];
                        an_mouse_count_val[fi][1] += b_temp;
                        an_mouse_count_val[fi][0] = 0;
                        
                        if(an_mouse_count_val[fi][1] >= MASTER_MOUSE_SPEED)
                        {
                            out_buff[USB_MOUSE_MOVE_Y_IDX] = (BYTE)((-1 * (an_mouse_count_val[fi][1] / MASTER_MOUSE_SPEED)) & 0xFF);
                            an_mouse_count_val[fi][1] = an_mouse_count_val[fi][1] % MASTER_MOUSE_SPEED;
                        }
                    }
                }
                else
                {
                    an_mouse_count_val[fi][0] = 0;
                    an_mouse_count_val[fi][1] = 0;
                }
                break;
            default:
                an_mouse_count_val[fi][0] = 0;
                an_mouse_count_val[fi][1] = 0;
                break;
        }
    }
}

BYTE get_analog_joystick_output_val(BYTE p_analog_no, WORD p_analog_val)
{
    BYTE ret_val = 0x80;//中立
    WORD w_temp = 0;
    BYTE b_temp = 0;
    
    if(p_analog_no < ANALOG_SETTING_NUM)
    {
        if(p_analog_val <= an_out_setup_ad_val[p_analog_no][1])
        {
            w_temp = an_out_setup_ad_val[p_analog_no][1] - an_out_setup_ad_val[p_analog_no][0];
            b_temp = an_out_setup_out_val[p_analog_no][1] - an_out_setup_out_val[p_analog_no][0];
            if(b_temp == 0 || w_temp == 0)
            {
                ret_val = an_out_setup_out_val[p_analog_no][1];
            }
            else
            {
                if(an_out_setup_out_val[p_analog_no][1] > an_out_setup_out_val[p_analog_no][0])
                {
                    w_temp = (p_analog_val - an_out_setup_ad_val[p_analog_no][0]) * b_temp / w_temp;
                    w_temp += an_out_setup_out_val[p_analog_no][0];
                    if(w_temp > 0xFF)
                    {
                        w_temp = 0xFF;
                    }
                    ret_val = (BYTE)w_temp;
                }
                else
                {
                    b_temp = an_out_setup_out_val[p_analog_no][0] - an_out_setup_out_val[p_analog_no][1];
                    
                    w_temp = (p_analog_val - an_out_setup_ad_val[p_analog_no][0]) * b_temp / w_temp;
                    w_temp = an_out_setup_out_val[p_analog_no][0] - w_temp;
                    if(w_temp > 0xFF)
                    {
                        w_temp = 0xFF;
                    }
                    ret_val = (BYTE)w_temp;
                }
            }
        }
        else if(p_analog_val <= an_out_setup_ad_val[p_analog_no][2])
        {
            w_temp = an_out_setup_ad_val[p_analog_no][2] - an_out_setup_ad_val[p_analog_no][1];
            b_temp = an_out_setup_out_val[p_analog_no][2] - an_out_setup_out_val[p_analog_no][1];
            if(b_temp == 0 || w_temp == 0)
            {
                ret_val = an_out_setup_out_val[p_analog_no][2];
            }
            else
            {
                if(an_out_setup_out_val[p_analog_no][2] > an_out_setup_out_val[p_analog_no][1])
                {
                    w_temp = (p_analog_val - an_out_setup_ad_val[p_analog_no][1]) * b_temp / w_temp;
                    w_temp += an_out_setup_out_val[p_analog_no][1];
                    if(w_temp > 0xFF)
                    {
                        w_temp = 0xFF;
                    }
                    ret_val = (BYTE)w_temp;
                }
                else
                {
                    b_temp = an_out_setup_out_val[p_analog_no][1] - an_out_setup_out_val[p_analog_no][2];
                    
                    w_temp = (p_analog_val - an_out_setup_ad_val[p_analog_no][1]) * b_temp / w_temp;
                    w_temp = an_out_setup_out_val[p_analog_no][1] - w_temp;
                    if(w_temp > 0xFF)
                    {
                        w_temp = 0xFF;
                    }
                    ret_val = (BYTE)w_temp;
                }
            }
        }
        else if(p_analog_val <= an_out_setup_ad_val[p_analog_no][3])
        {
            w_temp = an_out_setup_ad_val[p_analog_no][3] - an_out_setup_ad_val[p_analog_no][2];
            b_temp = an_out_setup_out_val[p_analog_no][3] - an_out_setup_out_val[p_analog_no][2];
            if(b_temp == 0 || w_temp == 0)
            {
                ret_val = an_out_setup_out_val[p_analog_no][3];
            }
            else
            {
                if(an_out_setup_out_val[p_analog_no][3] > an_out_setup_out_val[p_analog_no][2])
                {
                    w_temp = (p_analog_val - an_out_setup_ad_val[p_analog_no][2]) * b_temp / w_temp;
                    w_temp += an_out_setup_out_val[p_analog_no][2];
                    if(w_temp > 0xFF)
                    {
                        w_temp = 0xFF;
                    }
                    ret_val = (BYTE)w_temp;
                }
                else
                {
                    b_temp = an_out_setup_out_val[p_analog_no][2] - an_out_setup_out_val[p_analog_no][3];
                    
                    w_temp = (p_analog_val - an_out_setup_ad_val[p_analog_no][2]) * b_temp / w_temp;
                    w_temp = an_out_setup_out_val[p_analog_no][2] - w_temp;
                    if(w_temp > 0xFF)
                    {
                        w_temp = 0xFF;
                    }
                    ret_val = (BYTE)w_temp;
                }
            }
        }
        else
        {
            w_temp = an_out_setup_ad_val[p_analog_no][4] - an_out_setup_ad_val[p_analog_no][3];
            b_temp = an_out_setup_out_val[p_analog_no][4] - an_out_setup_out_val[p_analog_no][3];
            if(b_temp == 0 || w_temp == 0)
            {
                ret_val = an_out_setup_out_val[p_analog_no][4];
            }
            else
            {
                if(an_out_setup_out_val[p_analog_no][4] > an_out_setup_out_val[p_analog_no][3])
                {
                    w_temp = (p_analog_val - an_out_setup_ad_val[p_analog_no][3]) * b_temp / w_temp;
                    w_temp += an_out_setup_out_val[p_analog_no][3];
                    if(w_temp > 0xFF)
                    {
                        w_temp = 0xFF;
                    }
                    ret_val = (BYTE)w_temp;
                }
                else
                {
                    b_temp = an_out_setup_out_val[p_analog_no][3] - an_out_setup_out_val[p_analog_no][4];
                    
                    w_temp = (p_analog_val - an_out_setup_ad_val[p_analog_no][3]) * b_temp / w_temp;
                    w_temp = an_out_setup_out_val[p_analog_no][3] - w_temp;
                    if(w_temp > 0xFF)
                    {
                        w_temp = 0xFF;
                    }
                    ret_val = (BYTE)w_temp;
                }
            }
        }
    }
    
    return ret_val;
}

BYTE get_analog_mouse_output_val(BYTE p_analog_no, WORD p_analog_val)
{
    BYTE ret_val = 0;//
    DWORD dw_temp = 0;
    
    if(p_analog_no < ANALOG_SETTING_NUM)
    {
        if(p_analog_val >= 0x3FE)
        {   // 0x3FFまで上がりきらない
            p_analog_val = ANALOG_INPUT_MAX_VALUE;
        }
                
        // 中立範囲チェック
        if(an_out_setup_center_val[p_analog_no][1] <= p_analog_val && p_analog_val <= an_out_setup_center_val[p_analog_no][2])
        {   // 中立 出力なし
            
        }
        else if(an_out_setup_center_val[p_analog_no][1] > p_analog_val)
        {   // マイナス方向
            if(an_out_setup_center_val[p_analog_no][1] == 0)
            {   // 出力なし
                
            }
            else
            {
                dw_temp = an_out_setup_center_val[p_analog_no][1] - p_analog_val;
                dw_temp = dw_temp * my_an_infos.AN_Infos.an_info[p_analog_no].data[ANALOG_DATA_SENSE_IDX];
                dw_temp = dw_temp / an_out_setup_center_val[p_analog_no][1];
                ret_val = (BYTE)(dw_temp & 0xFF);
                ret_val = 0x100 - ret_val;
            }
        }
        else if(an_out_setup_center_val[p_analog_no][2] < p_analog_val)
        {   // プラス方向
            if(an_out_setup_center_val[p_analog_no][2] == ANALOG_INPUT_MAX_VALUE)
            {   // 出力なし
                
            }
            else
            {
                dw_temp = p_analog_val - an_out_setup_center_val[p_analog_no][2];
                dw_temp = dw_temp * my_an_infos.AN_Infos.an_info[p_analog_no].data[ANALOG_DATA_SENSE_IDX];
                dw_temp = dw_temp / (ANALOG_INPUT_MAX_VALUE - an_out_setup_center_val[p_analog_no][2]);
                ret_val = (BYTE)(dw_temp & 0xFF);
            }
        }
        else
        {
            // 出力なし
        }
    }
    
    return ret_val;
}


