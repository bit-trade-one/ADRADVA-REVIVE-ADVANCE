#ifndef MAIN_SUB_H
#define MAIN_SUB_H

#include "app.h"
#include "l_eeprom.h"

// Timer4
// 40MHz プリスケーラ2
// TMRのカウントは0.05us
#define SOFT_DELAY_1US      20
#define SOFT_DELAY_5US      100
#define SOFT_DELAY_10US     200
#define SOFT_DELAY_100US    2000
#define SOFT_DELAY_1MS      20000
#define SOFT_DELAY_10MS     200000
#define SOFT_DELAY_100MS    2000000

extern void Soft_Delay(DWORD delayValue);
extern void Switch_Input(void);
extern void SW_Keyboard_Data_Set(BYTE p_sw_no, BYTE p_modify, BYTE p_key);
extern void SW_Output_Keyboard(BYTE* out_buff, BYTE buff_size);
extern void keyboard_push_order_buff_optimization(void);
extern void Check_SWInfo(void);
extern void Check_ANInfo(void);

extern BYTE get_joystick_hat_sw_usb_output(BYTE p_hat_sw_out_flag);
extern void set_joystick_lever_usb_output(BYTE* p_joystick_lever_out_flag, BYTE out_flag_size, BYTE* out_buff, BYTE buff_size);

extern void set_analog_output_setup_val(void);
extern void set_analog_usb_joystick_output(BYTE* out_buff, BYTE buff_size);
extern void set_analog_usb_mouse_output(BYTE* out_buff, BYTE buff_size);
extern BYTE get_analog_joystick_output_val(BYTE p_analog_no, WORD p_analog_val);
extern BYTE get_analog_mouse_output_val(BYTE p_analog_no, WORD p_analog_val);


#endif //MAIN_SUB_H

