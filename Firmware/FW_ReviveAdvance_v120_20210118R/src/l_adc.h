#ifndef L_ADC_H
#define L_ADC_H

#include "app.h"



//ADC
#define AD_INPUT_NUM    8
//#define AD_CH0_IDX      0
//#define AD_CH1_IDX      1
//#define AD_CH2_IDX      2
//#define AD_CH3_IDX      3
//#define AD_CH4_IDX      4
//#define AD_CH5_IDX      5
//#define AD_CH6_IDX      6
//#define AD_CH7_IDX      7
//#define AD_CH8_IDX      8
#define ANALOG1_CH_NUM   10
#define ANALOG2_CH_NUM   0
#define ANALOG3_CH_NUM   1
#define ANALOG4_CH_NUM   2
#define ANALOG5_CH_NUM   3
#define ANALOG6_CH_NUM   4
#define ANALOG7_CH_NUM   5
#define ANALOG8_CH_NUM   6


//#define AD_1_IDX        0
//#define AD_2_IDX        1
////#define AD_3_IDX        2
//#define AD_1_CH_NO      AD_CH4_AN_NUM
//#define AD_2_CH_NO      AD_CH2_AN_NUM
////#define AD_3_CH_NO      AD_CH4_AN_NUM

#define AD_AVERAGE_NUM          8
//#define AD_VIRTUAL_12BIT_NUM    4   // 仮想12ビット時に何回分加算するか

#define AD_INPUT_CYCLE  1          // AD読み込み周期[ms] 0.1ms
//#define AD_INPUT_CYCLE  10         // AD読み込み周期[ms]


// 外部宣言 変数
extern WORD ad_input[AD_INPUT_NUM];
extern BYTE ad_input_comp[AD_INPUT_NUM];
extern BYTE ad_convert_no;
extern WORD ad_input_average_buff[AD_INPUT_NUM][AD_AVERAGE_NUM];
extern BYTE ad_input_average_buff_no;
//extern WORD ad_input_v12bit[AD_INPUT_NUM];
//extern WORD ad_input_v12bit_temp[AD_INPUT_NUM][AD_VIRTUAL_12BIT_NUM];
//extern BYTE ad_input_v12_idx;
//extern BYTE ad_input_v12_cal_start;
//extern BYTE ad_input_comp_v12bit[AD_INPUT_NUM];

extern WORD zero_offset[AD_INPUT_NUM];
extern BYTE ad_input_ch_no[AD_INPUT_NUM];

extern BYTE ad_input_req;
extern WORD ad_input_time_counter;
extern BYTE ad_input_no;



// 外部宣言 関数
extern void l_adc_init(void);
extern WORD l_adc_input(BYTE p_ad_ch_no);



#endif//L_ADC_H
