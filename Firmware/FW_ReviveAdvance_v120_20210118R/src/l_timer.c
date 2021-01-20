<<<<<<< HEAD
#include "app.h"
#include "l_timer.h"
#include "main_sub.h"
#include "l_eeprom.h"
#include "l_spi.h"
#include "l_adc.h"


void timer1_init(void);
void timer2_init(void);
void timer4_init(void);
void Timer1_Task(void);
void Timer2_Task(void);

WORD l_timer1_counter = 0;
WORD l_timer2_counter = 0;

BYTE sw_input_counter = 0;
BYTE sw_input_flag = 0;
BYTE ad_input_counter = 0;
BYTE ad_input_flag = 0;
BYTE digital_input_counter = 0;
BYTE digital_input_flag = 0;
BYTE analog_input_counter = 0;
BYTE analog_input_flag = 0;

// Timer1 初期化
// 1ms
void timer1_init(void)
{
    T1CONbits.ON = 0;       // Timer1 OFF
    TMR1 = 0;
    
    PR1 = TIMER1_PERIOD;
    T1CONbits.TCKPS = 0;    // 0=1:1, 1=1:8, 2=1:64, 3=1:256 prescale
    T1CONbits.TCS = 0;      // Internal clock
    IPC1bits.T1IP = 3;      // interrupt priority
    IPC1bits.T1IS = 1;      // interrupt subpriority
    IFS0bits.T1IF = 0;      // clear timer1 interrupt flag
    IEC0bits.T1IE = 1;      // enable timer1 interrupt
    T1CONbits.ON = 1;       // Timer1 ON
}

// Timer2 初期化
// 1ms
void timer2_init(void)
{
    T2CONbits.ON = 0;       // Timer2 OFF
    TMR2 = 0;
    
    PR2 = TIMER2_PERIOD;
    T2CONbits.TCKPS = 0;    // 0=1:1, 1=1:2, 2=1:4, 3=1:8, 4=1:16, 5=1:32, 6=1:64, 7=1:256 prescale
    T2CONbits.T32 = 0;      // 16-bit timer
    IPC2bits.T2IP = 3;      // interrupt priority
    IPC2bits.T2IS = 1;      // interrupt subpriority
    IFS0bits.T2IF = 0;      // clear timer2 interrupt flag
    IEC0bits.T2IE = 1;      // enable timer2 interrupt
    T2CONbits.ON = 1;       // Timer2 ON
}

// Timer4 初期化
// 32bit
// 1ms
void timer4_init(void)
{
    T4CONbits.ON = 0;       // Timer4 OFF
    TMR4 = 0;
    PR4 = 0;
    T4CONbits.TCKPS = 1;    // 0=1:1, 1=1:2, 2=1:4, 3=1:8, 4=1:16, 5=1:32, 6=1:64, 7=1:256 prescale
    T4CONbits.T32 = 1;      // 0=16bit, 1=32bit timer
//    IPC4bits.T4IP = 3;      // interrupt priority
//    IPC4bits.T4IS = 1;      // interrupt subpriority
    IFS0bits.T4IF = 0;      // clear timer4 interrupt flag
    IEC0bits.T4IE = 0;      // disable timer4 interrupt
    T4CONbits.ON = 1;       // Timer4 ON
}

// Timer1 Task
void Timer1_Task(void)
{
    BYTE fi;
    IFS0bits.T1IF = 0;

    // SW 入力チェック
//    Switch_Input();
    sw_input_counter++;
    if(sw_input_counter >= SW_INPUT_TIME)
    {
        sw_input_counter = 0;
        sw_input_flag = 1;
    }
    // Digital 入力チェック
    digital_input_counter++;
    if(digital_input_counter >= DIGITAL_INPUT_TIME)
    {
        digital_input_counter = 0;
        digital_input_flag = 1;
    }
    // Analog 入力チェック
    analog_input_counter++;
    if(analog_input_counter >= ANALOG_INPUT_TIME)
    {
        analog_input_counter = 0;
        analog_input_flag = 1;
    }

//    // マウスダブルクリック間隔
//    if(mouse_w_click_interval_counter > 0)
//    {
//        mouse_w_click_interval_counter--;
//    }
    if(joystick_out_time_counter > 0)
    {
        joystick_out_time_counter--;
    }
    
    
    debug_arr1[1]++;
}

// Timer2 Task
void Timer2_Task(void)
{
    BYTE fi;
    
    IFS0bits.T2IF = 0;

    l_timer2_counter++;

    // AD 入力チェック
    ad_input_counter++;
    if(ad_input_counter >= AD_INPUT_CYCLE)
    {
        ad_input_counter = 0;
        ad_input_flag = 1;
    }
    
    debug_arr1[2]++;
}
=======
#include "app.h"
#include "l_timer.h"
#include "main_sub.h"
#include "l_eeprom.h"
#include "l_spi.h"
#include "l_adc.h"


void timer1_init(void);
void timer2_init(void);
void timer4_init(void);
void Timer1_Task(void);
void Timer2_Task(void);

WORD l_timer1_counter = 0;
WORD l_timer2_counter = 0;

BYTE sw_input_counter = 0;
BYTE sw_input_flag = 0;
BYTE ad_input_counter = 0;
BYTE ad_input_flag = 0;
BYTE digital_input_counter = 0;
BYTE digital_input_flag = 0;
BYTE analog_input_counter = 0;
BYTE analog_input_flag = 0;

// Timer1 初期化
// 1ms
void timer1_init(void)
{
    T1CONbits.ON = 0;       // Timer1 OFF
    TMR1 = 0;
    
    PR1 = TIMER1_PERIOD;
    T1CONbits.TCKPS = 0;    // 0=1:1, 1=1:8, 2=1:64, 3=1:256 prescale
    T1CONbits.TCS = 0;      // Internal clock
    IPC1bits.T1IP = 3;      // interrupt priority
    IPC1bits.T1IS = 1;      // interrupt subpriority
    IFS0bits.T1IF = 0;      // clear timer1 interrupt flag
    IEC0bits.T1IE = 1;      // enable timer1 interrupt
    T1CONbits.ON = 1;       // Timer1 ON
}

// Timer2 初期化
// 1ms
void timer2_init(void)
{
    T2CONbits.ON = 0;       // Timer2 OFF
    TMR2 = 0;
    
    PR2 = TIMER2_PERIOD;
    T2CONbits.TCKPS = 0;    // 0=1:1, 1=1:2, 2=1:4, 3=1:8, 4=1:16, 5=1:32, 6=1:64, 7=1:256 prescale
    T2CONbits.T32 = 0;      // 16-bit timer
    IPC2bits.T2IP = 3;      // interrupt priority
    IPC2bits.T2IS = 1;      // interrupt subpriority
    IFS0bits.T2IF = 0;      // clear timer2 interrupt flag
    IEC0bits.T2IE = 1;      // enable timer2 interrupt
    T2CONbits.ON = 1;       // Timer2 ON
}

// Timer4 初期化
// 32bit
// 1ms
void timer4_init(void)
{
    T4CONbits.ON = 0;       // Timer4 OFF
    TMR4 = 0;
    PR4 = 0;
    T4CONbits.TCKPS = 1;    // 0=1:1, 1=1:2, 2=1:4, 3=1:8, 4=1:16, 5=1:32, 6=1:64, 7=1:256 prescale
    T4CONbits.T32 = 1;      // 0=16bit, 1=32bit timer
//    IPC4bits.T4IP = 3;      // interrupt priority
//    IPC4bits.T4IS = 1;      // interrupt subpriority
    IFS0bits.T4IF = 0;      // clear timer4 interrupt flag
    IEC0bits.T4IE = 0;      // disable timer4 interrupt
    T4CONbits.ON = 1;       // Timer4 ON
}

// Timer1 Task
void Timer1_Task(void)
{
    BYTE fi;
    IFS0bits.T1IF = 0;

    // SW 入力チェック
//    Switch_Input();
    sw_input_counter++;
    if(sw_input_counter >= SW_INPUT_TIME)
    {
        sw_input_counter = 0;
        sw_input_flag = 1;
    }
    // Digital 入力チェック
    digital_input_counter++;
    if(digital_input_counter >= DIGITAL_INPUT_TIME)
    {
        digital_input_counter = 0;
        digital_input_flag = 1;
    }
    // Analog 入力チェック
    analog_input_counter++;
    if(analog_input_counter >= ANALOG_INPUT_TIME)
    {
        analog_input_counter = 0;
        analog_input_flag = 1;
    }

//    // マウスダブルクリック間隔
//    if(mouse_w_click_interval_counter > 0)
//    {
//        mouse_w_click_interval_counter--;
//    }
    if(joystick_out_time_counter > 0)
    {
        joystick_out_time_counter--;
    }
    
    
    debug_arr1[1]++;
}

// Timer2 Task
void Timer2_Task(void)
{
    BYTE fi;
    
    IFS0bits.T2IF = 0;

    l_timer2_counter++;

    // AD 入力チェック
    ad_input_counter++;
    if(ad_input_counter >= AD_INPUT_CYCLE)
    {
        ad_input_counter = 0;
        ad_input_flag = 1;
    }
    
    debug_arr1[2]++;
}
>>>>>>> Upload-ready
