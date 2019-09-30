// Revive Advance
//
//  ver 1.0.0   2019.09.20  初版 リリース版
//  ver 0.0.1   2019.09.18  試作 初版
//

/********************************************************************
 FileName:      main.c
 Dependencies:  See INCLUDES section
 Processor:     PIC18, PIC24, dsPIC, and PIC32 USB Microcontrollers
 Hardware:      This demo is natively intended to be used on Microchip USB demo
                boards supported by the MCHPFSUSB stack.  See release notes for
                support matrix.  This demo can be modified for use on other 
                hardware platforms.
 Complier:      Microchip C18 (for PIC18), XC16 (for PIC24/dsPIC), XC32 (for PIC32)
 Company:       Microchip Technology, Inc.

 Software License Agreement:

 The software supplied herewith by Microchip Technology Incorporated
 (the "Company") for its PICﾂｮ Microcontroller is intended and
 supplied to you, the Company's customer, for use solely and
 exclusively on Microchip PIC Microcontroller products. The
 software is owned by the Company and/or its supplier, and is
 protected under applicable copyright laws. All rights are reserved.
 Any use in violation of the foregoing restrictions may subject the
 user to criminal sanctions under applicable laws, as well as to
 civil liability for the breach of the terms and conditions of this
 license.

 THIS SOFTWARE IS PROVIDED IN AN "AS IS" CONDITION. NO WARRANTIES,
 WHETHER EXPRESS, IMPLIED OR STATUTORY, INCLUDING, BUT NOT LIMITED
 TO, IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A
 PARTICULAR PURPOSE APPLY TO THIS SOFTWARE. THE COMPANY SHALL NOT,
 IN ANY CIRCUMSTANCES, BE LIABLE FOR SPECIAL, INCIDENTAL OR
 CONSEQUENTIAL DAMAGES, FOR ANY REASON WHATSOEVER.

********************************************************************
 File Description:

 Change History:
  Rev   Description
  ----  -----------------------------------------
  1.0   Initial release
  2.1   Updated for simplicity and to use common
                     coding style
  2.7b  Improvements to USBCBSendResume(), to make it easier to use.
  2.9f  Adding new part support
********************************************************************/

#ifndef MAIN_C
#define MAIN_C

/** INCLUDES *******************************************************/
#include <xc.h>
#include <string.h>
#include "./USB/usb.h"
#include "HardwareProfile.h"
#include "./USB/usb_function_hid.h"
#include "app.h"
#include "main_sub.h"
#include "main_comm.h"
#include "l_spi.h"
#include "l_eeprom.h"
#include "l_timer.h"
#include "l_adc.h"


/** CONFIGURATION **************************************************/

// *****************************************************************************
/*
 Crystal 16MHz
 system clock 40MHz = 16MHz / 4 * 20 / 2
 USB clock 48MHz = 16MHz / 4 * 24 / 2
 PLL Input Divider (FPLLIDIV)                   = Divide by 4
 PLL Multiplier (FPLLMUL)                       = Multiply by 20
 USB PLL Input Divider (UPLLIDIV)               = Divide by 4
 USB PLL Enable (UPLLEN)                        = Enabled
 System PLL Output Clock Divider (FPLLODIV)     = Divide by 2
 Watchdog Timer Enable (FWDTEN)                 = Disabled
 Clock Switching and Monitor Selection (FCKSM)  = Clock Switch Enable,
                                                  Fail Safe Clock Monitoring Enable
 Peripheral Clock Divisor (FPBDIV)              = Divide by 1
*/

// DEVCFG3
#pragma config FVBUSONIO = OFF, FUSBIDIO = OFF
// DEVCFG2
#pragma config FPLLIDIV = DIV_4, FPLLMUL = MUL_20, UPLLIDIV = DIV_4, UPLLEN = ON, FPLLODIV = DIV_2
// DEVCFG1
#pragma config FNOSC = PRIPLL, FSOSCEN = OFF, IESO = OFF, POSCMOD = HS, OSCIOFNC = OFF, FPBDIV = DIV_1, FCKSM = CSDCMD, WDTPS = PS65536, FWDTEN = OFF
// DEVCFG0
#pragma config DEBUG = OFF, JTAGEN = OFF, ICESEL = ICS_PGx1, PWP = OFF, BWP = OFF, CP = OFF


/** DECLARATIONS ***************************************************/

/** VARIABLES ******************************************************/
int8_t	c_version[]="1.0.0";

BYTE ReceivedDataBuffer[RX_DATA_BUFFER_SIZE] RX_DATA_BUFFER_ADDRESS;
BYTE ToSendDataBuffer[TX_DATA_BUFFER_SIZE] TX_DATA_BUFFER_ADDRESS;
BYTE mouse_input[MOUSE_BUFF_SIZE]={0};
BYTE joystick_input[JOYSTICK_BUFF_SIZE]={0};
BYTE keyboard_input[KEYBOARD_BUFF_SIZE]={0};
BYTE keyboard_output[HID_INT_OUT_EP_SIZE]={0};
//BYTE multimedia_input[MULTIMEDIA_BUFF_SIZE]={0};

BYTE mouse_buffer[MOUSE_BUFF_SIZE]={0};
BYTE mouse_buffer_pre[MOUSE_BUFF_SIZE]={0};
BYTE joystick_buffer[JOYSTICK_BUFF_SIZE]={0};
BYTE joystick_buffer_pre[JOYSTICK_BUFF_SIZE]={0};
BYTE joystick_default_value[JOYSTICK_BUFF_SIZE] = {0x00, 0x00, USB_HAT_SWITCH_NULL, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80};
BYTE keyboard_buffer[KEYBOARD_BUFF_SIZE]={0};
BYTE keyboard_buffer_pre[KEYBOARD_BUFF_SIZE]={0};
//BYTE multimedia_buffer[MULTIMEDIA_BUFF_SIZE]={0};
//BYTE multimedia_buffer_pre[MULTIMEDIA_BUFF_SIZE]={0};
#define JOYSTICK_OUT_TIME		50		// ジョイスティック出力継続時間[ms]
WORD joystick_out_time_counter = 0;
BYTE joystick_lever_move_value[JOYSTICK_BUFF_SIZE] = {0};

BYTE mouse_input_out_flag = 0;
BYTE joystick_input_out_flag = 0;
BYTE keyboard_input_out_flag = 0;
//BYTE multimedia_input_out_flag = 0;

// SW入力
BYTE sw_now_fix[SW_NUM]={0};
BYTE sw_now_fix_pre[SW_NUM]={0};
BYTE sw_press_on_cnt[SW_NUM]={0};
BYTE sw_press_off_cnt[SW_NUM]={0};

// sw mouse
BYTE mouse_move_flag[MOUSE_MOVE_DIRECTION_NUM] = {0};
BYTE mouse_sensitivity[MOUSE_MOVE_DIRECTION_NUM] = {0};
int mouse_count_val[MOUSE_MOVE_DIRECTION_NUM] = {0};
//WORD mouse_count_val_temp[MOUSE_MOVE_DIRECTION_NUM] = {0};
// sw keyboard
BYTE set_keyboard_push_order_buff[SET_KEYBOARD_PUSH_ORDER_BUFF_SIZE];
BYTE set_keyboard_push_order_write_idx = 0;
BYTE set_keyboard_push_order_ctrl_bit[SET_KEYBOARD_PUSH_ORDER_BUFF_SIZE];
BYTE set_keyboard_push_order_key_code[SET_KEYBOARD_PUSH_ORDER_BUFF_SIZE];
// sw joyastick
BYTE joystick_hat_sw_output = 0;
BYTE joystick_lever_output[SW_DATA_JOYSTICK_LEVER_SIZE] = {0};

// AN joystick
BYTE an_joystick_lever_out_flag[ANALOG_SETTING_NUM] = {0};
BYTE an_joystick_lever_out_value[ANALOG_SETTING_NUM] = {0};
WORD an_out_setup_ad_val[ANALOG_SETTING_NUM][ANALOG_MATH_VOL_NUM] = {0};      // アナログ出力値計算用　設定の電圧をアナログ値に変換
BYTE an_out_setup_out_val[ANALOG_SETTING_NUM][ANALOG_MATH_VOL_NUM] = {0};     // アナログ出力値計算用　値
WORD an_out_setup_center_val[ANALOG_SETTING_NUM][ANALOG_MATH_CENTER_NUM] = {0}; // アナログ出力値計算用　中立値（中立値、不感帯最小値、不感帯最大値）
WORD an_mouse_count_val[ANALOG_SETTING_NUM][2] = {0};


//BYTE mouse_w_click_status = MOUSE_DOUBLE_CLICK_STATUS_NONE;
//WORD mouse_w_click_interval_counter = 0;

// EEPROM
BYTE eeprom_read_req_flag = 0;
BYTE eeprom_write_req_flag = 0;



USB_HANDLE USBOutHandle = 0;    //USB handle.  Must be initialized to 0 at startup.
USB_HANDLE USBInHandle = 0;     //USB handle.  Must be initialized to 0 at startup.
USB_HANDLE lastTransmission_Mouse = 0;
USB_HANDLE lastTransmission_Joystick = 0;
USB_HANDLE lastINTransmission_Keyboard = 0;
USB_HANDLE lastOUTTransmission_Keyboard = 0;
//USB_HANDLE lastTransmission_Multimedia = 0;

BYTE USB_Sleep_Flag = 0;

// DEBUG
BYTE debug_arr1[16] ={0};
BYTE debug_arr2[16] ={0};
BYTE debug_arr3[16] ={0};
WORD debug_array_w1[16] = {0};

/** PRIVATE PROTOTYPES *********************************************/
static void InitializeSystem(void);
void ProcessIO(void);
void UserInit(void);
void USBCBSendResume(void);

/** VECTOR REMAPPING ***********************************************/



/********************************************************************
 * Function:        void main(void)
 *
 * PreCondition:    None
 *
 * Input:           None
 *
 * Output:          None
 *
 * Side Effects:    None
 *
 * Overview:        Main program entry point.
 *
 * Note:            None
 *******************************************************************/
#if defined(__18CXX)
void main(void)
#else
int main(void)
#endif
{   
    InitializeSystem();

    #if defined(USB_INTERRUPT)
        USBDeviceAttach();
    #endif

    while(1)
    {
        #if defined(USB_POLLING)
		// Check bus status and service USB interrupts.
        USBDeviceTasks(); // Interrupt or polling method.  If using polling, must call
        				  // this function periodically.  This function will take care
        				  // of processing and responding to SETUP transactions 
        				  // (such as during the enumeration process when you first
        				  // plug in).  USB hosts require that USB devices should accept
        				  // and process SETUP packets in a timely fashion.  Therefore,
        				  // when using polling, this function should be called 
        				  // regularly (such as once every 1.8ms or faster** [see 
        				  // inline code comments in usb_device.c for explanation when
        				  // "or faster" applies])  In most cases, the USBDeviceTasks() 
        				  // function does not take very long to execute (ex: <100 
        				  // instruction cycles) before it returns.
        #endif
    				  

		// Application-specific tasks.
		// Application related code may be added here, or in the ProcessIO() function.
        ProcessIO();        
    }//end while
}//end main


/********************************************************************
 * Function:        static void InitializeSystem(void)
 *
 * PreCondition:    None
 *
 * Input:           None
 *
 * Output:          None
 *
 * Side Effects:    None
 *
 * Overview:        InitializeSystem is a centralize initialization
 *                  routine. All required USB initialization routines
 *                  are called from here.
 *
 *                  User application initialization routine should
 *                  also be called from here.                  
 *
 * Note:            None
 *******************************************************************/
static void InitializeSystem(void)
{
//	The USB specifications require that USB peripheral devices must never source
//	current onto the Vbus pin.  Additionally, USB peripherals should not source
//	current on D+ or D- when the host/hub is not actively powering the Vbus line.
//	When designing a self powered (as opposed to bus powered) USB peripheral
//	device, the firmware should make sure not to turn on the USB module and D+
//	or D- pull up resistor unless Vbus is actively powered.  Therefore, the
//	firmware needs some means to detect when Vbus is being powered by the host.
//	A 5V tolerant I/O pin can be connected to Vbus (through a resistor), and
// 	can be used to detect when Vbus is high (host actively powering), or low
//	(host is shut down or otherwise not supplying power).  The USB firmware
// 	can then periodically poll this I/O pin to know when it is okay to turn on
//	the USB module/D+/D- pull up resistor.  When designing a purely bus powered
//	peripheral device, it is not possible to source current on D+ or D- when the
//	host is not actively providing power on Vbus. Therefore, implementing this
//	bus sense feature is optional.  This firmware can be made to use this bus
//	sense feature by making sure "USE_USB_BUS_SENSE_IO" has been defined in the
//	HardwareProfile.h file.    
    #if defined(USE_USB_BUS_SENSE_IO)
    tris_usb_bus_sense = INPUT_PIN; // See HardwareProfile.h
    #endif
    
//	If the host PC sends a GetStatus (device) request, the firmware must respond
//	and let the host know if the USB peripheral device is currently bus powered
//	or self powered.  See chapter 9 in the official USB specifications for details
//	regarding this request.  If the peripheral device is capable of being both
//	self and bus powered, it should not return a hard coded value for this request.
//	Instead, firmware should check if it is currently self or bus powered, and
//	respond accordingly.  If the hardware has been configured like demonstrated
//	on the PICDEM FS USB Demo Board, an I/O pin can be polled to determine the
//	currently selected power source.  On the PICDEM FS USB Demo Board, "RA2" 
//	is used for	this purpose.  If using this feature, make sure "USE_SELF_POWER_SENSE_IO"
//	has been defined in HardwareProfile - (platform).h, and that an appropriate I/O pin 
//  has been mapped	to it.
    #if defined(USE_SELF_POWER_SENSE_IO)
    tris_self_power = INPUT_PIN;	// See HardwareProfile.h
    #endif

    UserInit();
    
    USBDeviceInit();	//usb_device.c.  Initializes USB module SFRs and firmware
    					//variables to known states.
}//end InitializeSystem



/******************************************************************************
 * Function:        void UserInit(void)
 *
 * PreCondition:    None
 *
 * Input:           None
 *
 * Output:          None
 *
 * Side Effects:    None
 *
 * Overview:        This routine should take care of all of the demo code
 *                  initialization that is required.
 *
 * Note:            
 *
 *****************************************************************************/
void UserInit(void)
{
    WORD fi, fj;
    BYTE tmp_eeprom_read_buff[EEPROM_PAGE_SIZE];
    EEPROM_ADR eeprom_address;
    WORD w_temp = 0;

    //initialize the variable holding the handle for the last
    // transmission
    USBOutHandle = 0;
    USBInHandle = 0;


    ANSELA = 0x00000003;    // Digital Input (b1=AN1, b0=AN0)
    ANSELB = 0x0000400F;    // Digital Input (b15=AN9, b14=AN10, b13=AN11, b3=AN5, b2=AN4, b1=AN3, b0=AN2)
    ANSELC = 0x00000001;    // Digital Input (b3=AN12, b2=AN8, b1=AN7, b0=AN6)
    
    TRISA = 0x0193;     // RA0-4,7-10
    //RA0 = アナログ2 入力 (AN0)
    //RA1 = アナログ3 入力 (AN1)
    //RA2 =
    //RA3 =
    //RA4 = EEPROM SDI 入力
    //RA7 = BOOT SW 入力
    //RA8 = D03 入力
    //RA9 = EEPROM SS 出力
    //RA10 = 
    TRISB = 0x63BF;     // RB0-15
    //RB0 = アナログ4 入力 (AN2)
    //RB1 = アナログ5 入力 (AN3)
    //RB2 = アナログ6 入力 (AN4)
    //RB3 = アナログ7 入力 (AN5)
    //RB4 = D04 入力
    //RB5 = D07 入力
    //RB6 = xx
    //RB7 = D08 入力
    //RB8 = D09 入力
    //RB9 = D10 入力
    //RB10 =
    //RB11 =
    //RB12 = xx
    //RB13 = D15 入力
    //RB14 = アナログ1 入力 (AN10))
    //RB15 = EEPROM SCK 出力
    TRISC = 0x03F7;     // RC0-9
    //RC0 = アナログ8 入力 (AN6)
    //RC1 = D01 入力
    //RC2 = D02 入力
    //RC3 = EEPROM SDO 出力
    //RC4 = D05 入力
    //RC5 = D06 入力
    //RC6 = D11 入力
    //RC7 = D12 入力
    //RC8 = D13 入力
    //RC9 = D14 入力
    LATA = 0;
    LATB = 0;
    LATC = 0;

    // PPS設定F
    CFGCONbits.IOLOCK = 1;  // Unlock
    //Input
    //Output
    CFGCONbits.IOLOCK = 0;  //Lock

    INTCONbits.MVEC = 1;    // enable multi-vector mode
//    INTCONbits.MVEC = 0;    // enable single-vector mode


    //変数初期化
    // SW
    for(fi = 0; fi < MOUSE_BUFF_SIZE; fi++)
    {
        mouse_input[fi] = 0;
        mouse_buffer[fi] = 0;
    }
    for(fi = 0; fi < KEYBOARD_BUFF_SIZE; fi++)
    {
        keyboard_input[fi] = 0;
        keyboard_buffer[fi] = 0;
    }
    for(fi = 0; fi < JOYSTICK_BUFF_SIZE; fi++)
    {
        joystick_input[fi] = joystick_default_value[fi];
        joystick_buffer[fi] = joystick_default_value[fi];
        joystick_lever_move_value[fi] = joystick_default_value[fi];
    }
    joystick_input_out_flag = 5;
    for(fi = 0; fi < SET_KEYBOARD_PUSH_ORDER_BUFF_SIZE; fi++)
    {
        set_keyboard_push_order_buff[fi] = 0xFF;
        set_keyboard_push_order_ctrl_bit[fi] = 0;
        set_keyboard_push_order_key_code[fi] = 0;        
    }

    /* Timer 1 */
    timer1_init();
    /* Timer 2 */
    timer2_init();
    /* Timer 4 */
    timer4_init();

    // SPI1初期化
    l_spi1_init();  // EEPROM

    // ADC初期化
    l_adc_init();
    // AD値１回読み込み
    for(fi = 0; fi < AD_INPUT_NUM; fi++)
    {
        w_temp = 0;
        for(fj = 0; fj < AD_AVERAGE_NUM; fj++)
        {
            ad_input_average_buff[fi][fj] = l_adc_input(fi);
            w_temp += ad_input_average_buff[fi][fj];
            Soft_Delay(SOFT_DELAY_1MS);
        }
        ad_input[fi] = w_temp / AD_AVERAGE_NUM;
        ad_input_comp[fi] = 1;
    }
    
    // EEPROM初期化チェック
#if 1
    eeprom_n_read(EEPROM_INIT_DATA_ADR, &tmp_eeprom_read_buff[0], EEPROM_INIT_DATA_SIZE);
    if(tmp_eeprom_read_buff[0] != 0x55 || tmp_eeprom_read_buff[1] != 0xAA)
    {   // 未初期化のため、初期化する
        for(eeprom_address = 0; eeprom_address < EEPROM_DEFAULT_DATA_SIZE; )
        {
            for(fi = 0; fi < EEPROM_PAGE_SIZE; fi++)
            {
                tmp_eeprom_read_buff[fi] = c_eeprom_default_data[eeprom_address + fi];
            }
            
            eeprom_n_write(eeprom_address, &tmp_eeprom_read_buff[0], EEPROM_PAGE_SIZE);
            eeprom_address += EEPROM_PAGE_SIZE;
        }
    }
#endif
	// EEPROM読み込みバッファクリア
    u_SWInfo_buffClr(&my_sw_infos);
    u_ANInfo_buffClr(&my_an_infos);
    // EEPROM読み込み
    u_GetSWInfo(&my_sw_infos);
    u_GetANInfo(&my_an_infos);
    // EEPROM読み込み値チェック
    Check_SWInfo();
    Check_ANInfo();
    
    // Analog計算値セット
    set_analog_output_setup_val();

    //割り込み設定
//    INTCONbits.INT2EP = 0;	// INT2割り込みエッジ極性制御　0=立ち下り、1=立ち上がり
//    IPC2bits.INT2IP = 4;        // INT2 Priority
//    IPC2bits.INT2IS = 0;        // INT2 Sub-Priority
//    IFS0bits.INT2IF = 0;        // INT2 Interrupt Flag
//    IEC0bits.INT2IE = 1;        // INT2 Interrupt Enable
//    INTCONbits.INT4EP = 0;	// INT4割り込みエッジ極性制御　0=立ち下り、1=立ち上がり
//    IPC4bits.INT4IP = 4;        // INT4 Priority
//    IPC4bits.INT4IS = 0;        // INT4 Sub-Priority
//    IFS0bits.INT4IF = 0;        // INT4 Interrupt Flag
//    IEC0bits.INT4IE = 1;        // INT4 Interrupt Enable
    
    /* 割り込み許可 */
    INTEnableInterrupts();
    
}//end UserInit

/********************************************************************
 * Function:        void ProcessIO(void)
 *
 * PreCondition:    None
 *
 * Input:           None
 *
 * Output:          None
 *
 * Side Effects:    None
 *
 * Overview:        This function is a place holder for other user
 *                  routines. It is a mixture of both USB and
 *                  non-USB tasks.
 *
 * Note:            None
 *******************************************************************/
void ProcessIO(void)
{
    BYTE sw_idx, fi, fj;
    WORD w_temp;
    
    debug_arr1[0]++;
    if(debug_arr1[0] == 0)
    {
        debug_arr1[15]++;
    }
    
    // SW 入力チェック
//    if(sw_input_flag != 0)
//    {
//        sw_input_flag = 0;
//        // SW入力
//        Switch_Input();
//    }
    // SW入力
    Switch_Input();
    
    // AD 入力
    if(ad_input_flag != 0)
    {
        ad_input_flag = 0;
        // AD入力
        ad_input_average_buff[ad_input_no][ad_input_average_buff_no] = l_adc_input(ad_input_no);
        // 平均化
        w_temp = 0;
        for(fi = 0; fi < AD_AVERAGE_NUM; fi++)
        {
            w_temp += ad_input_average_buff[ad_input_no][fi];
        }
        ad_input[ad_input_no] = w_temp / AD_AVERAGE_NUM;
        
        ad_input_average_buff_no++;
        if(ad_input_average_buff_no >= AD_AVERAGE_NUM)
        {
            ad_input_average_buff_no = 0;
            
            ad_input_no++;
            if(ad_input_no >= AD_INPUT_NUM)
            {
                ad_input_no = 0;
            }
        }
    }
    
    for(fi = 0; fi < MOUSE_MOVE_DIRECTION_NUM; fi++)
    {
        mouse_move_flag[fi] = MOUSE_MOVE_OFF;
        mouse_sensitivity[fi] = 0;
    }
    joystick_hat_sw_output = 0;
    for(fi = 0; fi < SW_DATA_JOYSTICK_LEVER_SIZE; fi++)
    {
        joystick_lever_output[fi] = 0;
    }
    // Digital入力周期？
    digital_input_flag = 1;
    if(digital_input_flag != 0)
    {
        digital_input_flag = 0;
        
        // SW入力による出力設定
        for(sw_idx = 0; sw_idx < SW_NUM; sw_idx++)
        {
            if(sw_now_fix[sw_idx] == N_ON)
            {   // ON
                switch(my_sw_infos.SW_Infos.sw_info[sw_idx].data[SW_DATA_SET_DEVICE_TYPE_IDX])
                {
                    case SW_SET_DEVICE_TYPE_MOUSE:
                        switch(my_sw_infos.SW_Infos.sw_info[sw_idx].data[SW_DATA_SET_TYPE_IDX])
                        {
                            case SW_SET_TYPE_MOUSE_LCLICK:
                                mouse_buffer[USB_MOUSE_BUTTON_IDX_TOP] |= MOUSE_DATA_LEFT_CLICK;
                                break;
                            case SW_SET_TYPE_MOUSE_RCLICK:
                                mouse_buffer[USB_MOUSE_BUTTON_IDX_TOP] |= MOUSE_DATA_RIGHT_CLICK;
                                break;
                            case SW_SET_TYPE_MOUSE_WHCLICK:
                                mouse_buffer[USB_MOUSE_BUTTON_IDX_TOP] |= MOUSE_DATA_WHEEL_CLICK;
                                break;
                            case SW_SET_TYPE_MOUSE_B4CLICK:
                                mouse_buffer[USB_MOUSE_BUTTON_IDX_TOP] |= MOUSE_DATA_B4_CLICK;
                                break;
                            case SW_SET_TYPE_MOUSE_B5CLICK:
                                mouse_buffer[USB_MOUSE_BUTTON_IDX_TOP] |= MOUSE_DATA_B5_CLICK;
                                break;
                            case SW_SET_TYPE_MOUSE_MOVE_UP:
                                mouse_move_flag[MOUSE_MOVE_DIRECTION_UP] = MOUSE_MOVE_ON;
                                if(mouse_sensitivity[MOUSE_MOVE_DIRECTION_UP] == 0)
                                {
                                    mouse_sensitivity[MOUSE_MOVE_DIRECTION_UP] = my_sw_infos.SW_Infos.sw_info[sw_idx].data[SW_DATA_SENSE_IDX];
                                }
                                break;
                            case SW_SET_TYPE_MOUSE_MOVE_DOWN:
                                mouse_move_flag[MOUSE_MOVE_DIRECTION_DOWN] = MOUSE_MOVE_ON;
                                if(mouse_sensitivity[MOUSE_MOVE_DIRECTION_DOWN] == 0)
                                {
                                    mouse_sensitivity[MOUSE_MOVE_DIRECTION_DOWN] = my_sw_infos.SW_Infos.sw_info[sw_idx].data[SW_DATA_SENSE_IDX];
                                }
                                break;
                            case SW_SET_TYPE_MOUSE_MOVE_LEFT:
                                mouse_move_flag[MOUSE_MOVE_DIRECTION_LEFT] = MOUSE_MOVE_ON;
                                if(mouse_sensitivity[MOUSE_MOVE_DIRECTION_LEFT] == 0)
                                {
                                    mouse_sensitivity[MOUSE_MOVE_DIRECTION_LEFT] = my_sw_infos.SW_Infos.sw_info[sw_idx].data[SW_DATA_SENSE_IDX];
                                }
                                break;
                            case SW_SET_TYPE_MOUSE_MOVE_RIGHT:
                                mouse_move_flag[MOUSE_MOVE_DIRECTION_RIGHT] = MOUSE_MOVE_ON;
                                if(mouse_sensitivity[MOUSE_MOVE_DIRECTION_RIGHT] == 0)
                                {
                                    mouse_sensitivity[MOUSE_MOVE_DIRECTION_RIGHT] = my_sw_infos.SW_Infos.sw_info[sw_idx].data[SW_DATA_SENSE_IDX];
                                }
                                break;
                            case SW_SET_TYPE_MOUSE_WHSCROLL_UP:
                                mouse_move_flag[MOUSE_MOVE_DIRECTION_WUP] = MOUSE_MOVE_ON;
                                if(mouse_sensitivity[MOUSE_MOVE_DIRECTION_WUP] == 0)
                                {
                                    mouse_sensitivity[MOUSE_MOVE_DIRECTION_WUP] = my_sw_infos.SW_Infos.sw_info[sw_idx].data[SW_DATA_SENSE_IDX];
                                }
                                break;
                            case SW_SET_TYPE_MOUSE_WHSCROLL_DOWN:
                                mouse_move_flag[MOUSE_MOVE_DIRECTION_WDOWN] = MOUSE_MOVE_ON;
                                if(mouse_sensitivity[MOUSE_MOVE_DIRECTION_WDOWN] == 0)
                                {
                                    mouse_sensitivity[MOUSE_MOVE_DIRECTION_WDOWN] = my_sw_infos.SW_Infos.sw_info[sw_idx].data[SW_DATA_SENSE_IDX];
                                }
                                break;
                            case SW_SET_TYPE_MOUSE_SPEED:
                                for(fi = 0; fi < MOUSE_MOVE_DIRECTION_NUM; fi++)
                                {
                                    mouse_sensitivity[fi] = my_sw_infos.SW_Infos.sw_info[sw_idx].data[SW_DATA_SENSE_IDX];
                                }
                                break;
                        }
                        //mouse_input_out_flag = 5;
                        break;
                    case SW_SET_DEVICE_TYPE_KEYBOARD:
                        SW_Keyboard_Data_Set(sw_idx, my_sw_infos.SW_Infos.sw_info[sw_idx].data[SW_DATA_MODIFIER_IDX], my_sw_infos.SW_Infos.sw_info[sw_idx].data[SW_DATA_KEY1_IDX]);
                        //set_keyboard_push_order_buff[set_keyboard_push_order_write_idx] = sw_idx;
                        //set_keyboard_push_order_ctrl_bit[set_keyboard_push_order_write_idx] = my_sw_infos.SW_Infos.sw_info[sw_idx].data[SW_DATA_MODIFIER_IDX];
                        //set_keyboard_push_order_key_code[set_keyboard_push_order_write_idx] = my_sw_infos.SW_Infos.sw_info[sw_idx].data[SW_DATA_KEY1_IDX];
                        //set_keyboard_push_order_write_idx++;
                        break;
                    case SW_SET_DEVICE_TYPE_JOYSTICK:
                        for(fi = 0; fi < SW_DATA_JOYSTICK_BTN_SIZE; fi++)
                        {
                            joystick_buffer[USB_JOYSTICK_BUTTON_IDX_TOP + fi] |= my_sw_infos.SW_Infos.sw_info[sw_idx].data[SW_DATA_JOYSTICK_BTN_TOP_IDX + fi];
                        }
                        joystick_hat_sw_output |= my_sw_infos.SW_Infos.sw_info[sw_idx].data[SW_DATA_JOYSTICK_HAT_IDX];
                        for(fi = 0; fi < SW_DATA_JOYSTICK_LEVER_SIZE; fi++)
                        {
                            joystick_lever_output[fi] |= my_sw_infos.SW_Infos.sw_info[sw_idx].data[SW_DATA_JOYSTICK_LEVER_TOP_IDX + fi];
                        }
                        break;
                    default:
                        break;
                }
            
            }
            else
            {   // OFF
                switch(my_sw_infos.SW_Infos.sw_info[sw_idx].data[SW_DATA_SET_DEVICE_TYPE_IDX])
                {
                    case SW_SET_DEVICE_TYPE_KEYBOARD:
                        for(fj = 0; fj < set_keyboard_push_order_write_idx; fj++)
                        {
                            if(set_keyboard_push_order_buff[fj] == sw_idx)
                            {
                                set_keyboard_push_order_buff[fj] = 0xFF;
                                set_keyboard_push_order_ctrl_bit[fj] = 0;
                                set_keyboard_push_order_key_code[fj] = 0;
                                break;
                            }
                        }
                        break;
                }
            }
        }
    }
    
    for(fi = 0; fi < ANALOG_SETTING_NUM; fi++)
    {
        an_joystick_lever_out_flag[fi] = 0;
        an_joystick_lever_out_value[fi] = 0;
    }
    // Analog入力周期？
    analog_input_flag = 1;
    if(analog_input_flag != 0)
    {
        analog_input_flag = 0;
        
        // アナログ入力による出力設定
        for(fi = 0; fi < AD_INPUT_NUM; fi++)
        {
            switch(my_an_infos.AN_Infos.an_info[fi].data[ANALOG_DATA_SET_TYPE_IDX])
            {
                case ANALOG_SET_TYPE_JOYSTICK_X:
                    an_joystick_lever_out_flag[fi] = ANALOG_SET_TYPE_JOYSTICK_X;
                    an_joystick_lever_out_value[fi] = get_analog_joystick_output_val(fi, ad_input[fi]);
                    break;
                case ANALOG_SET_TYPE_JOYSTICK_Y:
                    an_joystick_lever_out_flag[fi] = ANALOG_SET_TYPE_JOYSTICK_Y;
                    an_joystick_lever_out_value[fi] = get_analog_joystick_output_val(fi, ad_input[fi]);
                    break;
                case ANALOG_SET_TYPE_JOYSTICK_Z:
                    an_joystick_lever_out_flag[fi] = ANALOG_SET_TYPE_JOYSTICK_Z;
                    an_joystick_lever_out_value[fi] = get_analog_joystick_output_val(fi, ad_input[fi]);
                    break;
                case ANALOG_SET_TYPE_JOYSTICK_RX:
                    an_joystick_lever_out_flag[fi] = ANALOG_SET_TYPE_JOYSTICK_RX;
                    an_joystick_lever_out_value[fi] = get_analog_joystick_output_val(fi, ad_input[fi]);
                    break;
                case ANALOG_SET_TYPE_JOYSTICK_RY:
                    an_joystick_lever_out_flag[fi] = ANALOG_SET_TYPE_JOYSTICK_RY;
                    an_joystick_lever_out_value[fi] = get_analog_joystick_output_val(fi, ad_input[fi]);
                    break;
                case ANALOG_SET_TYPE_JOYSTICK_RZ:
                    an_joystick_lever_out_flag[fi] = ANALOG_SET_TYPE_JOYSTICK_RZ;
                    an_joystick_lever_out_value[fi] = get_analog_joystick_output_val(fi, ad_input[fi]);
                    break;
                case ANALOG_SET_TYPE_JOYSTICK_SL:
                    an_joystick_lever_out_flag[fi] = ANALOG_SET_TYPE_JOYSTICK_SL;
                    an_joystick_lever_out_value[fi] = get_analog_joystick_output_val(fi, ad_input[fi]);
                    break;
                case ANALOG_SET_TYPE_MOUSE_X:
                    an_joystick_lever_out_flag[fi] = ANALOG_SET_TYPE_MOUSE_X;
                    an_joystick_lever_out_value[fi] = get_analog_mouse_output_val(fi, ad_input[fi]);
                    break;
                case ANALOG_SET_TYPE_MOUSE_Y:
                    an_joystick_lever_out_flag[fi] = ANALOG_SET_TYPE_MOUSE_Y;
                    an_joystick_lever_out_value[fi] = get_analog_mouse_output_val(fi, ad_input[fi]);
                    break;
                default:
                    an_joystick_lever_out_flag[fi] = ANALOG_SET_TYPE_NONE;
                    an_joystick_lever_out_value[fi] = 0;
                    break;
            }
        }
    }
    
    
    // User Application USB tasks
    if((USBDeviceState < CONFIGURED_STATE)||(USBSuspendControl==1))
    {
        USB_Sleep_Flag = 1;
        return;
    }
    else
    {
        if(USBGetRemoteWakeupStatus() == TRUE && USBIsBusSuspended() == TRUE)
        {
            USB_Sleep_Flag = 1;
        }
        else
        {
//            if(USB_Sleep_Flag == 1)
//            {
//
//            }
            USB_Sleep_Flag = 0;
        }
    }

    USB_Comm();

}//end ProcessIO



// ******************************************************************************************************
// ************** USB Callback Functions ****************************************************************
// ******************************************************************************************************
// The USB firmware stack will call the callback functions USBCBxxx() in response to certain USB related
// events.  For example, if the host PC is powering down, it will stop sending out Start of Frame (SOF)
// packets to your device.  In response to this, all USB devices are supposed to decrease their power
// consumption from the USB Vbus to <2.5mA* each.  The USB module detects this condition (which according
// to the USB specifications is 3+ms of no bus activity/SOF packets) and then calls the USBCBSuspend()
// function.  You should modify these callback functions to take appropriate actions for each of these
// conditions.  For example, in the USBCBSuspend(), you may wish to add code that will decrease power
// consumption from Vbus to <2.5mA (such as by clock switching, turning off LEDs, putting the
// microcontroller to sleep, etc.).  Then, in the USBCBWakeFromSuspend() function, you may then wish to
// add code that undoes the power saving things done in the USBCBSuspend() function.

// The USBCBSendResume() function is special, in that the USB stack will not automatically call this
// function.  This function is meant to be called from the application firmware instead.  See the
// additional comments near the function.

// Note *: The "usb_20.pdf" specs indicate 500uA or 2.5mA, depending upon device classification. However,
// the USB-IF has officially issued an ECN (engineering change notice) changing this to 2.5mA for all 
// devices.  Make sure to re-download the latest specifications to get all of the newest ECNs.

/******************************************************************************
 * Function:        void USBCBSuspend(void)
 *
 * PreCondition:    None
 *
 * Input:           None
 *
 * Output:          None
 *
 * Side Effects:    None
 *
 * Overview:        Call back that is invoked when a USB suspend is detected
 *
 * Note:            None
 *****************************************************************************/
void USBCBSuspend(void)
{
	//Example power saving code.  Insert appropriate code here for the desired
	//application behavior.  If the microcontroller will be put to sleep, a
	//process similar to that shown below may be used:
	
	//ConfigureIOPinsForLowPower();
	//SaveStateOfAllInterruptEnableBits();
	//DisableAllInterruptEnableBits();
	//EnableOnlyTheInterruptsWhichWillBeUsedToWakeTheMicro();	//should enable at least USBActivityIF as a wake source
	//Sleep();
	//RestoreStateOfAllPreviouslySavedInterruptEnableBits();	//Preferrably, this should be done in the USBCBWakeFromSuspend() function instead.
	//RestoreIOPinsToNormal();									//Preferrably, this should be done in the USBCBWakeFromSuspend() function instead.

	//IMPORTANT NOTE: Do not clear the USBActivityIF (ACTVIF) bit here.  This bit is 
	//cleared inside the usb_device.c file.  Clearing USBActivityIF here will cause 
	//things to not work as intended.	
	
    
    USB_Sleep_Flag = 1;

}



/******************************************************************************
 * Function:        void USBCBWakeFromSuspend(void)
 *
 * PreCondition:    None
 *
 * Input:           None
 *
 * Output:          None
 *
 * Side Effects:    None
 *
 * Overview:        The host may put USB peripheral devices in low power
 *					suspend mode (by "sending" 3+ms of idle).  Once in suspend
 *					mode, the host may wake the device back up by sending non-
 *					idle state signalling.
 *					
 *					This call back is invoked when a wakeup from USB suspend 
 *					is detected.
 *
 * Note:            None
 *****************************************************************************/
void USBCBWakeFromSuspend(void)
{
	// If clock switching or other power savings measures were taken when
	// executing the USBCBSuspend() function, now would be a good time to
	// switch back to normal full power run mode conditions.  The host allows
	// 10+ milliseconds of wakeup time, after which the device must be 
	// fully back to normal, and capable of receiving and processing USB
	// packets.  In order to do this, the USB module must receive proper
	// clocking (IE: 48MHz clock must be available to SIE for full speed USB
	// operation).  
	// Make sure the selected oscillator settings are consistent with USB 
    // operation before returning from this function.
}

/********************************************************************
 * Function:        void USBCB_SOF_Handler(void)
 *
 * PreCondition:    None
 *
 * Input:           None
 *
 * Output:          None
 *
 * Side Effects:    None
 *
 * Overview:        The USB host sends out a SOF packet to full-speed
 *                  devices every 1 ms. This interrupt may be useful
 *                  for isochronous pipes. End designers should
 *                  implement callback routine as necessary.
 *
 * Note:            None
 *******************************************************************/
void USBCB_SOF_Handler(void)
{
    // No need to clear UIRbits.SOFIF to 0 here.
    // Callback caller is already doing that.
}

/*******************************************************************
 * Function:        void USBCBErrorHandler(void)
 *
 * PreCondition:    None
 *
 * Input:           None
 *
 * Output:          None
 *
 * Side Effects:    None
 *
 * Overview:        The purpose of this callback is mainly for
 *                  debugging during development. Check UEIR to see
 *                  which error causes the interrupt.
 *
 * Note:            None
 *******************************************************************/
void USBCBErrorHandler(void)
{
    // No need to clear UEIR to 0 here.
    // Callback caller is already doing that.

	// Typically, user firmware does not need to do anything special
	// if a USB error occurs.  For example, if the host sends an OUT
	// packet to your device, but the packet gets corrupted (ex:
	// because of a bad connection, or the user unplugs the
	// USB cable during the transmission) this will typically set
	// one or more USB error interrupt flags.  Nothing specific
	// needs to be done however, since the SIE will automatically
	// send a "NAK" packet to the host.  In response to this, the
	// host will normally retry to send the packet again, and no
	// data loss occurs.  The system will typically recover
	// automatically, without the need for application firmware
	// intervention.
	
	// Nevertheless, this callback function is provided, such as
	// for debugging purposes.
}


/*******************************************************************
 * Function:        void USBCBCheckOtherReq(void)
 *
 * PreCondition:    None
 *
 * Input:           None
 *
 * Output:          None
 *
 * Side Effects:    None
 *
 * Overview:        When SETUP packets arrive from the host, some
 * 					firmware must process the request and respond
 *					appropriately to fulfill the request.  Some of
 *					the SETUP packets will be for standard
 *					USB "chapter 9" (as in, fulfilling chapter 9 of
 *					the official USB specifications) requests, while
 *					others may be specific to the USB device class
 *					that is being implemented.  For example, a HID
 *					class device needs to be able to respond to
 *					"GET REPORT" type of requests.  This
 *					is not a standard USB chapter 9 request, and 
 *					therefore not handled by usb_device.c.  Instead
 *					this request should be handled by class specific 
 *					firmware, such as that contained in usb_function_hid.c.
 *
 * Note:            None
 *******************************************************************/
void USBCBCheckOtherReq(void)
{
    USBCheckHIDRequest();
}//end


/*******************************************************************
 * Function:        void USBCBStdSetDscHandler(void)
 *
 * PreCondition:    None
 *
 * Input:           None
 *
 * Output:          None
 *
 * Side Effects:    None
 *
 * Overview:        The USBCBStdSetDscHandler() callback function is
 *					called when a SETUP, bRequest: SET_DESCRIPTOR request
 *					arrives.  Typically SET_DESCRIPTOR requests are
 *					not used in most applications, and it is
 *					optional to support this type of request.
 *
 * Note:            None
 *******************************************************************/
void USBCBStdSetDscHandler(void)
{
    // Must claim session ownership if supporting this request
}//end


/*******************************************************************
 * Function:        void USBCBInitEP(void)
 *
 * PreCondition:    None
 *
 * Input:           None
 *
 * Output:          None
 *
 * Side Effects:    None
 *
 * Overview:        This function is called when the device becomes
 *                  initialized, which occurs after the host sends a
 * 					SET_CONFIGURATION (wValue not = 0) request.  This 
 *					callback function should initialize the endpoints 
 *					for the device's usage according to the current 
 *					configuration.
 *
 * Note:            None
 *******************************************************************/
void USBCBInitEP(void)
{
    //enable the HID endpoint
    USBEnableEndpoint(HID_EP1,USB_IN_ENABLED|USB_OUT_ENABLED|USB_HANDSHAKE_ENABLED|USB_DISALLOW_SETUP);
    USBEnableEndpoint(HID_EP2,USB_IN_ENABLED|USB_OUT_ENABLED|USB_HANDSHAKE_ENABLED|USB_DISALLOW_SETUP);
    USBEnableEndpoint(HID_EP3,USB_IN_ENABLED|USB_OUT_ENABLED|USB_HANDSHAKE_ENABLED|USB_DISALLOW_SETUP);
    USBEnableEndpoint(HID_EP4,USB_IN_ENABLED|USB_OUT_ENABLED|USB_HANDSHAKE_ENABLED|USB_DISALLOW_SETUP);
    //Re-arm the OUT endpoint for the next packet
    lastOUTTransmission_Keyboard = HIDRxPacket(HID_EP1,(BYTE*)&keyboard_output[0], HID_INT_OUT_EP_SIZE);
    USBOutHandle = HIDRxPacket(HID_EP4,(BYTE*)&ReceivedDataBuffer,RX_DATA_BUFFER_SIZE);
}

/********************************************************************
 * Function:        void USBCBSendResume(void)
 *
 * PreCondition:    None
 *
 * Input:           None
 *
 * Output:          None
 *
 * Side Effects:    None
 *
 * Overview:        The USB specifications allow some types of USB
 * 					peripheral devices to wake up a host PC (such
 *					as if it is in a low power suspend to RAM state).
 *					This can be a very useful feature in some
 *					USB applications, such as an Infrared remote
 *					control	receiver.  If a user presses the "power"
 *					button on a remote control, it is nice that the
 *					IR receiver can detect this signalling, and then
 *					send a USB "command" to the PC to wake up.
 *					
 *					The USBCBSendResume() "callback" function is used
 *					to send this special USB signalling which wakes 
 *					up the PC.  This function may be called by
 *					application firmware to wake up the PC.  This
 *					function will only be able to wake up the host if
 *                  all of the below are true:
 *					
 *					1.  The USB driver used on the host PC supports
 *						the remote wakeup capability.
 *					2.  The USB configuration descriptor indicates
 *						the device is remote wakeup capable in the
 *						bmAttributes field.
 *					3.  The USB host PC is currently sleeping,
 *						and has previously sent your device a SET 
 *						FEATURE setup packet which "armed" the
 *						remote wakeup capability.   
 *
 *                  If the host has not armed the device to perform remote wakeup,
 *                  then this function will return without actually performing a
 *                  remote wakeup sequence.  This is the required behavior, 
 *                  as a USB device that has not been armed to perform remote 
 *                  wakeup must not drive remote wakeup signalling onto the bus;
 *                  doing so will cause USB compliance testing failure.
 *                  
 *					This callback should send a RESUME signal that
 *                  has the period of 1-15ms.
 *
 * Note:            This function does nothing and returns quickly, if the USB
 *                  bus and host are not in a suspended condition, or are 
 *                  otherwise not in a remote wakeup ready state.  Therefore, it
 *                  is safe to optionally call this function regularly, ex: 
 *                  anytime application stimulus occurs, as the function will
 *                  have no effect, until the bus really is in a state ready
 *                  to accept remote wakeup. 
 *
 *                  When this function executes, it may perform clock switching,
 *                  depending upon the application specific code in 
 *                  USBCBWakeFromSuspend().  This is needed, since the USB
 *                  bus will no longer be suspended by the time this function
 *                  returns.  Therefore, the USB module will need to be ready
 *                  to receive traffic from the host.
 *
 *                  The modifiable section in this routine may be changed
 *                  to meet the application needs. Current implementation
 *                  temporary blocks other functions from executing for a
 *                  period of ~3-15 ms depending on the core frequency.
 *
 *                  According to USB 2.0 specification section 7.1.7.7,
 *                  "The remote wakeup device must hold the resume signaling
 *                  for at least 1 ms but for no more than 15 ms."
 *                  The idea here is to use a delay counter loop, using a
 *                  common value that would work over a wide range of core
 *                  frequencies.
 *                  That value selected is 1800. See table below:
 *                  ==========================================================
 *                  Core Freq(MHz)      MIP         RESUME Signal Period (ms)
 *                  ==========================================================
 *                      48              12          1.05
 *                       4              1           12.6
 *                  ==========================================================
 *                  * These timing could be incorrect when using code
 *                    optimization or extended instruction mode,
 *                    or when having other interrupts enabled.
 *                    Make sure to verify using the MPLAB SIM's Stopwatch
 *                    and verify the actual signal on an oscilloscope.
 *******************************************************************/
void USBCBSendResume(void)
{
    static WORD delay_count;
    
    //First verify that the host has armed us to perform remote wakeup.
    //It does this by sending a SET_FEATURE request to enable remote wakeup,
    //usually just before the host goes to standby mode (note: it will only
    //send this SET_FEATURE request if the configuration descriptor declares
    //the device as remote wakeup capable, AND, if the feature is enabled
    //on the host (ex: on Windows based hosts, in the device manager 
    //properties page for the USB device, power management tab, the 
    //"Allow this device to bring the computer out of standby." checkbox 
    //should be checked).
    if(USBGetRemoteWakeupStatus() == TRUE) 
    {
        //Verify that the USB bus is in fact suspended, before we send
        //remote wakeup signalling.
        if(USBIsBusSuspended() == TRUE)
        {
            USBMaskInterrupts();
            
            //Clock switch to settings consistent with normal USB operation.
            USBCBWakeFromSuspend();
            USBSuspendControl = 0; 
            USBBusIsSuspended = FALSE;  //So we don't execute this code again, 
                                        //until a new suspend condition is detected.

            //Section 7.1.7.7 of the USB 2.0 specifications indicates a USB
            //device must continuously see 5ms+ of idle on the bus, before it sends
            //remote wakeup signalling.  One way to be certain that this parameter
            //gets met, is to add a 2ms+ blocking delay here (2ms plus at 
            //least 3ms from bus idle to USBIsBusSuspended() == TRUE, yeilds
            //5ms+ total delay since start of idle).
            delay_count = 3600U;        
            do
            {
                delay_count--;
            }while(delay_count);
            
            //Now drive the resume K-state signalling onto the USB bus.
            USBResumeControl = 1;       // Start RESUME signaling
            delay_count = 1800U;        // Set RESUME line for 1-13 ms
            do
            {
                delay_count--;
            }while(delay_count);
            USBResumeControl = 0;       //Finished driving resume signalling

            USBUnmaskInterrupts();
        }
    }
}


/*******************************************************************
 * Function:        BOOL USER_USB_CALLBACK_EVENT_HANDLER(
 *                        USB_EVENT event, void *pdata, WORD size)
 *
 * PreCondition:    None
 *
 * Input:           USB_EVENT event - the type of event
 *                  void *pdata - pointer to the event data
 *                  WORD size - size of the event data
 *
 * Output:          None
 *
 * Side Effects:    None
 *
 * Overview:        This function is called from the USB stack to
 *                  notify a user application that a USB event
 *                  occured.  This callback is in interrupt context
 *                  when the USB_INTERRUPT option is selected.
 *
 * Note:            None
 *******************************************************************/
BOOL USER_USB_CALLBACK_EVENT_HANDLER(int event, void *pdata, WORD size)
{
    switch(event)
    {
        case EVENT_TRANSFER:
            //Add application specific callback task or callback function here if desired.
            break;
        case EVENT_SOF:
            USBCB_SOF_Handler();
            break;
        case EVENT_SUSPEND:
            USBCBSuspend();
            break;
        case EVENT_RESUME:
            USBCBWakeFromSuspend();
            break;
        case EVENT_CONFIGURED: 
            USBCBInitEP();
            break;
        case EVENT_SET_DESCRIPTOR:
            USBCBStdSetDscHandler();
            break;
        case EVENT_EP0_REQUEST:
            USBCBCheckOtherReq();
            break;
        case EVENT_BUS_ERROR:
            USBCBErrorHandler();
            break;
        case EVENT_TRANSFER_TERMINATED:
            //Add application specific callback task or callback function here if desired.
            //The EVENT_TRANSFER_TERMINATED event occurs when the host performs a CLEAR
            //FEATURE (endpoint halt) request on an application endpoint which was 
            //previously armed (UOWN was = 1).  Here would be a good place to:
            //1.  Determine which endpoint the transaction that just got terminated was 
            //      on, by checking the handle value in the *pdata.
            //2.  Re-arm the endpoint if desired (typically would be the case for OUT 
            //      endpoints).
            break;
        default:
            break;
    }      
    return TRUE; 
}

/** EOF main.c *************************************************/
#endif
