#include "app.h"
#include "l_adc.h"
#include "main_sub.h"


// ADC
WORD ad_input[AD_INPUT_NUM] = {0};
BYTE ad_input_comp[AD_INPUT_NUM] = {0};
BYTE ad_convert_no = 0;
WORD ad_input_average_buff[AD_INPUT_NUM][AD_AVERAGE_NUM] = {0};
BYTE ad_input_average_buff_no = 0;
//WORD ad_input_v12bit[AD_INPUT_NUM] = {0};
//WORD ad_input_v12bit_temp[AD_INPUT_NUM][AD_VIRTUAL_12BIT_NUM] = {0};
//BYTE ad_input_v12_idx = 0;
//BYTE ad_input_v12_cal_start = 0;
//BYTE ad_input_comp_v12bit[AD_INPUT_NUM] = {0};

WORD zero_offset[AD_INPUT_NUM] = {0};
BYTE ad_input_ch_no[AD_INPUT_NUM] = {ANALOG1_CH_NUM, ANALOG2_CH_NUM, ANALOG3_CH_NUM, ANALOG4_CH_NUM, ANALOG5_CH_NUM, ANALOG6_CH_NUM, ANALOG7_CH_NUM, ANALOG8_CH_NUM };

BYTE ad_input_req = 0;
WORD ad_input_time_counter = 0;
BYTE ad_input_no = 0;

void l_adc_init(void);
WORD l_adc_input(BYTE p_ad_ch_no);




void l_adc_init(void)
{
#if 1   // Manual
    AD1CON1 = 0x0000;     // SAMP bit = 0 ends sampling and starts converting
    
    AD1CHS = 0;

    AD1CSSL = 0;
    // Manual Sample, 1TAD=83.33ns(最小値))
    // TAD = Tpb*2*(ADCS+1) = 150TPB
    // 40MHz = 0.025us = Tpb
    // 1TAD = 150TPB = 3.75us
    // Auto-sample time = 12TAD
    AD1CON3 = 0x00000C4A;   // SAMC=12, ADCS=74
    AD1CON2 = 0x00000000;   // VREFH=AVDD, VREFL=AVSS            

//    AD1CON1SET = 0x8000;    // ADC module ON
#endif
#if 0   // automatic
    AD1CON1 = 0x0004;     // ASAM bit = 1 implies acquisition atarts immediately after last

    AD1CHS = 0;

    AD1CSSL = 0;
    // Manual Sample, 1TAD=83.33ns(最小値))
    // TAD = Tpb*2*(ADCS+1) = 150TPB
    // 50MHz = 0.02us = Tpb
    // 1TAD = 150TPB = 3us
    // Auto-sample time = 12TAD
    AD1CON3 = 0x00000C4A;   // SAMC=12, ADCS=74
    AD1CON2 = 0;

//    AD1CON1SET = 0x8000;    // ADC module ON
#endif
}

WORD l_adc_input(BYTE p_ad_no)
{
    BYTE ad_ch_no_error = 0;
    WORD ret_val = 0;
    
    if(p_ad_no >= AD_INPUT_NUM)
    {
        ad_ch_no_error = 1;
    }

#if 1   // Manual
    if(ad_ch_no_error == 0)
    {
        switch(p_ad_no)
        {
            case 0: // アナログ1
                AD1CHS = 0x000A0000;    // Connect AN10 as CH10 input int this example AN10 is the input
                break;
            case 1: // アナログ2
                AD1CHS = 0x00000000;    // Connect AN0 as CH0 input int this example AN0 is the input
                break;
            case 2: // アナログ3
                AD1CHS = 0x00010000;    // Connect AN1 as CH1 input int this example AN1 is the input
                break;
            case 3: // アナログ4
                AD1CHS = 0x00020000;    // Connect AN2 as CH2 input int this example AN2 is the input
                break;
            case 4: // アナログ5
                AD1CHS = 0x00030000;    // Connect AN3 as CH3 input int this example AN3 is the input
                break;
            case 5: // アナログ6
                AD1CHS = 0x00040000;    // Connect AN4 as CH4 input int this example AN4 is the input
                break;
            case 6: // アナログ7
                AD1CHS = 0x00050000;    // Connect AN5 as CH5 input int this example AN5 is the input
                break;
            case 7: // アナログ8
                AD1CHS = 0x00060000;    // Connect AN6 as CH6 input int this example AN6 is the input
                break;
            default:
                ad_ch_no_error = 1;
                break;
        }
        
        if(ad_ch_no_error == 0)
        { 
            AD1CON1SET = 0x8000;    // ADC module ON

            AD1CON1SET = 0x0002;    // start sampleing
            // wait 20us
            Soft_Delay(SOFT_DELAY_10US);
            Soft_Delay(SOFT_DELAY_10US);
            AD1CON1CLR = 0x0002;    // start Converting
            while(!(AD1CON1 & 0x0001)); // conversion done?
//            ad_input[p_ad_no] = ADC1BUF0;
//            ret_val = ad_input[p_ad_no];
            ret_val = ADC1BUF0;
        }
    }
    AD1CON1CLR = 0x8000;    // ADC module OFF
#endif
#if 0   // automatic
    if(ad_ch_no_error == 0)
    {
        switch(p_ad_ch_no)
        {
            case 0:
                AD1CHS = 0x00000000;    // Connect AN0 as CH0 input int this example AN0 is the input
                break;
            case 1:
                AD1CHS = 0x00010000;    // Connect AN1 as CH1 input int this example AN1 is the input
                break;
            case 2:
                AD1CHS = 0x00020000;    // Connect AN2 as CH2 input int this example AN2 is the input
                break;
            case 3:
                AD1CHS = 0x00030000;    // Connect AN3 as CH3 input int this example AN3 is the input
                break;
            case 4:
                AD1CHS = 0x00040000;    // Connect AN4 as CH4 input int this example AN4 is the input
                break;
            case 5:
                AD1CHS = 0x00050000;    // Connect AN5 as CH5 input int this example AN5 is the input
                break;
            case 6:
                AD1CHS = 0x00090000;    // Connect AN9 as CH9 input int this example AN9 is the input
                break;
            case 7:
                AD1CHS = 0x000A0000;    // Connect AN10 as CH10 input int this example AN10 is the input
                break;
            case 8:
                AD1CHS = 0x000B0000;    // Connect AN11 as CH11 input int this example AN11 is the input
                break;
            default:
                break;
        }
        AD1CON1SET = 0x8000;    // ADC module ON
        // wait 20us
        Soft_Delay(SOFT_DELAY_10US);
        Soft_Delay(SOFT_DELAY_10US);
        AD1CON1SET = 0x0002;    // start Converting
//        while(!(AD1CON1 & 0x0001)); // conversion done?
        Soft_Delay(SOFT_DELAY_100US);
        ad_input[p_ad_ch_no] = ADC1BUF0;
    }
    else
    {
        ad_input[p_ad_ch_no] = 0xFFFF;
    }
    AD1CON1CLR = 0x8000;    // ADC module OFF
  
#endif
    return ret_val;
}
