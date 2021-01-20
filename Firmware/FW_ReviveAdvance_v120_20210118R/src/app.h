/*******************************************************************************
 CAN WiFi

  Company:


  File Name:
    app.h

  Summary:
    Application specific header file.

  Description:
    Application specific header file.
 *******************************************************************************/

#ifndef APP_H
#define	APP_H


// *****************************************************************************
// Section: Included Files
// *****************************************************************************
// *****************************************************************************
#include "xc.h"
#include <stdint.h>
#include <stdbool.h>
#include <stddef.h>
#include "GenericTypeDefs.h"
#include "./USB/usb.h"
//#include "usb_config.h"


#if 0
typedef uint8_t		BYTE;                           /* 8-bit unsigned  */
typedef uint16_t	WORD;                           /* 16-bit unsigned */
typedef uint32_t	DWORD;                          /* 32-bit unsigned */

typedef union
{
    WORD Val;
    BYTE v[2];
    struct
    {
        BYTE LB;
        BYTE HB;
    } byte;
} WORD_VAL;

typedef union
{
    DWORD Val;
    WORD w[2];
    BYTE v[4];
    struct
    {
        WORD LW;
        WORD HW;
    } word;
    struct
    {
        BYTE LB;
        BYTE HB;
        BYTE UB;
        BYTE MB;
    } byte;
} DWORD_VAL;
#endif


/** DECLARATIONS ***************************************************/
#define SW_1_NO             PORTCbits.RC1
#define SW_2_NO             PORTCbits.RC2
#define SW_3_NO             PORTAbits.RA8
#define SW_4_NO             PORTBbits.RB4
#define SW_5_NO             PORTCbits.RC4
#define SW_6_NO             PORTCbits.RC5
#define SW_7_NO             PORTBbits.RB5
#define SW_8_NO             PORTBbits.RB7
#define SW_9_NO             PORTBbits.RB8
#define SW_10_NO            PORTBbits.RB9
#define SW_11_NO            PORTCbits.RC6
#define SW_12_NO            PORTCbits.RC7
#define SW_13_NO            PORTCbits.RC8
#define SW_14_NO            PORTCbits.RC9
#define SW_15_NO            PORTBbits.RB13
#define SW_NUM				15		// SW���͐�
#define SW_IDX_MIN          0       // SW �C���f�b�N�X�ŏ��l
#define SW_IDX_MAX          14      // SW �C���f�b�N�X�ő�l
#define	SW_1_NO_IDX			0
#define	SW_2_NO_IDX			1
#define	SW_3_NO_IDX			2
#define	SW_4_NO_IDX			3
#define	SW_5_NO_IDX			4
#define	SW_6_NO_IDX			5
#define	SW_7_NO_IDX			6
#define	SW_8_NO_IDX			7
#define	SW_9_NO_IDX			8
#define	SW_10_NO_IDX        9
#define	SW_11_NO_IDX		10
#define	SW_12_NO_IDX		11
#define	SW_13_NO_IDX		12
#define	SW_14_NO_IDX		13
#define	SW_15_NO_IDX		14
#define SW_ON_DEBOUNCE_TIME		20		// SW ON�f�o�E���X�^�C��
#define SW_OFF_DEBOUNCE_TIME	20		// SW OFF�f�o�E���X�^�C��

#define MOUSE_MOVE_OFF              0
#define MOUSE_MOVE_ON               1
#define MOUSE_MOVE_DIRECTION_NUM    6
#define MOUSE_MOVE_DIRECTION_UP     0
#define MOUSE_MOVE_DIRECTION_DOWN   1
#define MOUSE_MOVE_DIRECTION_LEFT   2
#define MOUSE_MOVE_DIRECTION_RIGHT  3
#define MOUSE_MOVE_DIRECTION_WUP    4
#define MOUSE_MOVE_DIRECTION_WDOWN  5

#define ANALOG_JOYSTICK_X_IDX          0   // �W���C�X�e�B�b�NX
#define ANALOG_JOYSTICK_Y_IDX          1   // �W���C�X�e�B�b�NY
#define ANALOG_JOYSTICK_Z_IDX          2   // �W���C�X�e�B�b�NZ
#define ANALOG_JOYSTICK_RX_IDX         3   // �W���C�X�e�B�b�NRX
#define ANALOG_JOYSTICK_RY_IDX         4   // �W���C�X�e�B�b�NRY
#define ANALOG_JOYSTICK_RZ_IDX         5   // �W���C�X�e�B�b�NRZ
#define ANALOG_JOYSTICK_SL_IDX         6   // �W���C�X�e�B�b�NRZ
#define ANALOG_MOUSE_X_IDX             7   // �}�E�XX
#define ANALOG_MOUSE_Y_IDX             8   // �}�E�XY

#define RX_DATA_BUFFER_ADDRESS
#define TX_DATA_BUFFER_ADDRESS

#define RX_DATA_BUFFER_SIZE     64
#define TX_DATA_BUFFER_SIZE     64
#define MOUSE_BUFF_SIZE         5
#define JOYSTICK_BUFF_SIZE      10   // button15=2byte, hat sw=1byte, analog6=8bit*6=6byte, slider=8bit=1byte
//#define MULTIMEDIA_BUFF_SIZE    2
#define KEYBOARD_BUFF_SIZE      8
//#define KEYBOARD_BUFF_SIZE      9

#define SET_KEYBOARD_PUSH_ORDER_BUFF_SIZE    0x20
        
//#define KEYBOARD_REPORT_ID_IDX      0		// �L�[�{�[�h�o�́@REPORT ID�i�[�ʒu
//#define KEYBOARD_REPORT_ID          1
//#define MULTIMEDIA_REPORT_ID        2

//#define KEYBOARD_MODIFIER_IDX			1		// �L�[�{�[�h�o�́@Modifier�i�[�ʒu
//#define KEYBOARD_KEYCODE_TOP			3		// �L�[�{�[�h�o�́@Keycode�i�[�擪�ʒu
#define KEYBOARD_MODIFIER_IDX			0		// �L�[�{�[�h�o�́@Modifier�i�[�ʒu
#define KEYBOARD_KEYCODE_TOP			2		// �L�[�{�[�h�o�́@Keycode�i�[�擪�ʒu
//#define KEYBOARD_KEYCODE_NUM			(KEYBOARD_BUFF_SIZE-KEYBOARD_KEYCODE_TOP)		// �L�[�{�[�h�o�́@Keycode�i�[�� (KEYBOARD_BUFF_SIZE-KEYBOARD_KEYCODE_TOP)
#define KEYBOARD_KEYCODE_NUM			6		// �L�[�{�[�h�o�́@Keycode�i�[�� (KEYBOARD_BUFF_SIZE-KEYBOARD_KEYCODE_TOP)
#define KEYBOARD_KEYCODE_L_CTRL			0xE0	// USB�L�[�{�[�h�@��Ctrl
#define KEYBOARD_KEYCODE_L_SHIFT		0xE1	// USB�L�[�{�[�h�@��Shift
#define KEYBOARD_KEYCODE_L_ALT			0xE2	// USB�L�[�{�[�h�@��Alt
#define KEYBOARD_KEYCODE_L_GUI			0xE3	// USB�L�[�{�[�h�@��GUI
#define KEYBOARD_KEYCODE_R_CTRL			0xE4	// USB�L�[�{�[�h�@�ECtrl
#define KEYBOARD_KEYCODE_R_SHIFT		0xE5	// USB�L�[�{�[�h�@�EShift
#define KEYBOARD_KEYCODE_R_ALT			0xE6	// USB�L�[�{�[�h�@�EAlt
#define KEYBOARD_KEYCODE_R_GUI			0xE7	// USB�L�[�{�[�h�@�EGUI
#define MULTIMEDIA_DATA_TOP             0       // �}���`���f�B�A�f�[�^�i�[�擪�ʒu
#define MULTIMEDIA_DATA_DATA1           0       // �}���`���f�B�A�f�[�^1�i�[�ʒu
#define MULTIMEDIA_DATA_DATA2           1       // �}���`���f�B�A�f�[�^2�i�[�ʒu


#define MOUSE_DATA_LEFT_CLICK		0x01		// �}�E�X�f�[�^�@���N���b�N
#define MOUSE_DATA_RIGHT_CLICK		0x02		// �}�E�X�f�[�^�@�E�N���b�N
#define MOUSE_DATA_WHEEL_CLICK		0x04		// �}�E�X�f�[�^�@�z�C�[���N���b�N
#define MOUSE_DATA_B4_CLICK         0x08		// �}�E�X�f�[�^�@�{�^��4�N���b�N
#define MOUSE_DATA_B5_CLICK         0x10		// �}�E�X�f�[�^�@�{�^��5�N���b�N
#define MOUSE_DATA_B6_CLICK         0x20		// �}�E�X�f�[�^�@�{�^��6�N���b�N
#define MOUSE_DATA_B7_CLICK         0x40		// �}�E�X�f�[�^�@�{�^��7�N���b�N
#define MOUSE_DATA_B8_CLICK         0x80		// �}�E�X�f�[�^�@�{�^��8�N���b�N

#define MOUSE_DOUBLE_CLICK_STATUS_NONE		0x00
#define MOUSE_DOUBLE_CLICK_STATUS_CLICK1	0x01
#define MOUSE_DOUBLE_CLICK_STATUS_INTERVAL	0x02
#define MOUSE_DOUBLE_CLICK_STATUS_CLICK2	0x04
#define MOUSE_DOUBLE_CLICK_INTERVAL	100			// �}�E�X�_�u���N���b�N�̃N���b�N�Ԋu

#define MASTER_MOUSE_SPEED		50	//	Mouse�̈ړ����x�̒����l
#define MASTER_WHEEL_SPEED		1000

#define USB_MOUSE_BUTTON_IDX_TOP        0
#define USB_MOUSE_MOVE_IDX_TOP          1
#define USB_MOUSE_MOVE_X_IDX            1
#define USB_MOUSE_MOVE_Y_IDX            2
#define USB_MOUSE_MOVE_W_IDX            3
#define USB_JOYSTICK_BUTTON_IDX_TOP     0
#define USB_JOYSTICK_BUTTON_IDX_SIZE	2
#define USB_JOYSTICK_HATSW_IDX          2
#define USB_JOYSTICK_LEVER_IDX_TOP      3
#define USB_JOYSTICK_LEVER_IDX_SIZE 	6
#define USB_JOYSTICK_LEVER_X_IDX        3
#define USB_JOYSTICK_LEVER_Y_IDX        4
#define USB_JOYSTICK_LEVER_Z_IDX        5
#define USB_JOYSTICK_LEVER_RX_IDX       6
#define USB_JOYSTICK_LEVER_RY_IDX       7
#define USB_JOYSTICK_LEVER_RZ_IDX       8
#define USB_JOYSTICK_LEVER_SLIDER_IDX_TOP   9
#define USB_JOYSTICK_LEVER_SLIDER_IDX_SIZE  1   // 

#define USB_JOYSTICK_BUTTON_ID_MIN	0
#define USB_JOYSTICK_BUTTON_ID_MAX	14
#define USB_JOYSTICK_BUTTON_ID_01	0
#define USB_JOYSTICK_BUTTON_ID_02	1
#define USB_JOYSTICK_BUTTON_ID_03	2
#define USB_JOYSTICK_BUTTON_ID_04	3
#define USB_JOYSTICK_BUTTON_ID_05	4
#define USB_JOYSTICK_BUTTON_ID_06	5
#define USB_JOYSTICK_BUTTON_ID_07	6
#define USB_JOYSTICK_BUTTON_ID_08	7
#define USB_JOYSTICK_BUTTON_ID_09	8
#define USB_JOYSTICK_BUTTON_ID_10	9
#define USB_JOYSTICK_BUTTON_ID_11	10
#define USB_JOYSTICK_BUTTON_ID_12	11
#define USB_JOYSTICK_BUTTON_ID_13	12
#define USB_JOYSTICK_BUTTON_ID_14	13
#define USB_JOYSTICK_BUTTON_ID_15	14

#define USB_JOYSTICK_LEVER_CENTER   0x80

#define USB_HAT_SWITCH_PRESS_MASK       0x07
#define USB_HAT_SWITCH_NORTH            0x00
#define USB_HAT_SWITCH_NORTH_EAST       0x01
#define USB_HAT_SWITCH_EAST             0x02
#define USB_HAT_SWITCH_SOUTH_EAST       0x03
#define USB_HAT_SWITCH_SOUTH            0x04
#define USB_HAT_SWITCH_SOUTH_WEST       0x05
#define USB_HAT_SWITCH_WEST             0x06
#define USB_HAT_SWITCH_NORTH_WEST       0x07
#define USB_HAT_SWITCH_NULL             0x08

#define HAT_SWITCH_BIT_NULL             0x00
#define HAT_SWITCH_BIT_NORTH            0x01
#define HAT_SWITCH_BIT_NORTH_EAST       0x02
#define HAT_SWITCH_BIT_EAST             0x04
#define HAT_SWITCH_BIT_SOUTH_EAST       0x08
#define HAT_SWITCH_BIT_SOUTH            0x10
#define HAT_SWITCH_BIT_SOUTH_WEST       0x20
#define HAT_SWITCH_BIT_WEST             0x40
#define HAT_SWITCH_BIT_NORTH_WEST       0x80

#define LEVER_SWITCH_BIT_X              0x03
#define LEVER_SWITCH_BIT_X_P            0x01
#define LEVER_SWITCH_BIT_X_M            0x02
#define LEVER_SWITCH_BIT_Y              0x0C
#define LEVER_SWITCH_BIT_Y_P            0x04
#define LEVER_SWITCH_BIT_Y_M            0x08
#define LEVER_SWITCH_BIT_Z              0x30
#define LEVER_SWITCH_BIT_Z_P            0x10
#define LEVER_SWITCH_BIT_Z_M            0x20
#define LEVER_SWITCH_BIT_RX             0xC0
#define LEVER_SWITCH_BIT_RX_P           0x40
#define LEVER_SWITCH_BIT_RX_M           0x80
#define LEVER_SWITCH_BIT_RY             0x03
#define LEVER_SWITCH_BIT_RY_P           0x01
#define LEVER_SWITCH_BIT_RY_M           0x02
#define LEVER_SWITCH_BIT_RZ             0x0C
#define LEVER_SWITCH_BIT_RZ_P           0x04
#define LEVER_SWITCH_BIT_RZ_M           0x08
#define LEVER_SWITCH_BIT_SL             0x30
#define LEVER_SWITCH_BIT_SL_P           0x10
#define LEVER_SWITCH_BIT_SL_M           0x20
#define LEVER_SWITCH_BYTE_POS_X_P       0x00
#define LEVER_SWITCH_BYTE_POS_X_M       0x00
#define LEVER_SWITCH_BYTE_POS_Y_P       0x00
#define LEVER_SWITCH_BYTE_POS_Y_M       0x00
#define LEVER_SWITCH_BYTE_POS_Z_P       0x00
#define LEVER_SWITCH_BYTE_POS_Z_M       0x00
#define LEVER_SWITCH_BYTE_POS_RX_P      0x00
#define LEVER_SWITCH_BYTE_POS_RX_M      0x00
#define LEVER_SWITCH_BYTE_POS_RY_P      0x01
#define LEVER_SWITCH_BYTE_POS_RY_M      0x01
#define LEVER_SWITCH_BYTE_POS_RZ_P      0x01
#define LEVER_SWITCH_BYTE_POS_RZ_M      0x01
#define LEVER_SWITCH_BYTE_POS_SL_P      0x01
#define LEVER_SWITCH_BYTE_POS_SL_M      0x01

#define SENSITIVITY_MIN                 1       /* ���x�ݒ�ŏ��l 1 */
#define SENSITIVITY_MAX                 100     /* ���x�ݒ�ő�l 100 */
#define SENSITIVITY_DEFAULT             50      /* ���x�f�t�H���g�l 50 */
#define ANALOG_INPUT_MAX_VALUE              0x03FF
#define ANALOG_INPUT_CENTER_DEFAULT_VALUE   0x0200
#define ANALOG_DEAD_ZONE_MIN            1       /* �s���ѐݒ�ŏ��l 0.01 */
#define ANALOG_DEAD_ZONE_MAX            50      /* �s���ѐݒ�ő�l 0.50 */
#define ANALOG_DEAD_ZONE_DEFAULT        5       /* �s���уf�t�H���g�l 0.05 */
#define ANALOG_VOLTAGE_MAX_VALUE        330     // 330 =  3.3V * 100
            
// SW �ݒ�
#define SW_SETTING_NUM                  15      // �ݒ萔 sw 15
#define SW_DATA_LEN                     0x10    // SW�ݒ�f�[�^��

#define SW_DATA_SET_DEVICE_TYPE_IDX         0   // SW�ݒ�f�[�^  �f�o�C�X�^�C�v�i�[�ʒu
#define SW_DATA_SENSE_IDX                   1   // SW�ݒ�f�[�^�@���x�����i�[�ʒu
#define SW_DATA_SET_TYPE_IDX                2   // SW�ݒ�f�[�^  �ݒ�^�C�v�i�[�ʒu
#define SW_DATA_CLICK_IDX                   3   // SW�ݒ�f�[�^�@�}�E�X�f�[�^�@�N���b�N�f�[�^�i�[�ʒu
#define SW_DATA_X_MOVE_IDX                  4   // SW�ݒ�f�[�^�@�}�E�X�f�[�^�@X�ړ��ʊi�[�ʒu
#define SW_DATA_Y_MOVE_IDX                  5   // SW�ݒ�f�[�^�@�}�E�X�f�[�^�@Y�ړ��ʊi�[�ʒu
#define SW_DATA_WHEEL_IDX                   6   // SW�ݒ�f�[�^�@�}�E�X�f�[�^�@�z�C�[���X�N���[���ʊi�[�ʒu
#define SW_DATA_TILT_IDX                    7   // SW�ݒ�f�[�^�@�}�E�X�f�[�^�@�`���g�ړ��ʊi�[�ʒu
#define SW_DATA_MODIFIER_IDX                3   // SW�ݒ�f�[�^�@�L�[�{�[�h�f�[�^�@���f�B�t�@�C�f�[�^�i�[�ʒu
#define SW_DATA_KEY1_IDX                    4   // SW�ݒ�f�[�^�@�L�[�{�[�h�f�[�^�@�L�[�f�[�^1�i�[�ʒu
#define SW_DATA_KEY2_IDX                    5   // SW�ݒ�f�[�^�@�L�[�{�[�h�f�[�^�@�L�[�f�[�^2�i�[�ʒu
#define SW_DATA_KEY3_IDX                    6   // SW�ݒ�f�[�^�@�L�[�{�[�h�f�[�^�@�L�[�f�[�^3�i�[�ʒu
#define SW_DATA_KEY_DELAY_IDX               7   // SW�ݒ�f�[�^�@�L�[�{�[�h�f�[�^�@�L�[���͒x���i�[�ʒu
#define SW_DATA_JOYSTICK_BTN_TOP_IDX        3   // SW�ݒ�f�[�^�@�W���C�X�e�B�b�N�@�{�^���擪�i�[�ʒu
#define SW_DATA_JOYSTICK_BTN_SIZE           2   // SW�ݒ�f�[�^�@�W���C�X�e�B�b�N�@�{�^���i�[�T�C�Y
#define SW_DATA_JOYSTICK_BTN1_IDX           3   // SW�ݒ�f�[�^�@�W���C�X�e�B�b�N�@�{�^��1�i�[�ʒu
#define SW_DATA_JOYSTICK_BTN2_IDX           4   // SW�ݒ�f�[�^�@�W���C�X�e�B�b�N�@�{�^��2�i�[�ʒu
#define SW_DATA_JOYSTICK_HAT_IDX            5   // SW�ݒ�f�[�^�@�W���C�X�e�B�b�N�@HAT SW�i�[�ʒu
#define SW_DATA_JOYSTICK_LEVER_TOP_IDX      6   // SW�ݒ�f�[�^�@�W���C�X�e�B�b�N�@LEVER�擪�i�[�ʒu
#define SW_DATA_JOYSTICK_LEVER_SIZE         2   // SW�ݒ�f�[�^�@�W���C�X�e�B�b�N�@LEVER�i�[�T�C�Y
#define SW_DATA_JOYSTICK_LEVER1_IDX         6   // SW�ݒ�f�[�^�@�W���C�X�e�B�b�N�@LEVER1�i�[�ʒu
#define SW_DATA_JOYSTICK_LEVER2_IDX         7   // SW�ݒ�f�[�^�@�W���C�X�e�B�b�N�@LEVER2�i�[�ʒu


#define SW_SET_DEVICE_TYPE_NUM                      4   // �ݒ�f�o�C�X�^�C�v��
#define SW_SET_DEVICE_TYPE_NONE                     0   // �ݒ�f�o�C�X�^�C�v�@�Ȃ�
#define SW_SET_DEVICE_TYPE_MOUSE                    1   // �ݒ�f�o�C�X�^�C�v�@�}�E�X
#define SW_SET_DEVICE_TYPE_KEYBOARD                 2   // �ݒ�f�o�C�X�^�C�v�@�L�[�{�[�h
#define SW_SET_DEVICE_TYPE_JOYSTICK                 3   // �ݒ�f�o�C�X�^�C�v�@�W���C�X�e�B�b�N
#define SW_SET_TYPE_NONE                            0
#define SW_SET_TYPE_MOUSE_NUM                       12   // �ݒ�^�C�v�@�}�E�X�@�ݒ萔
#define SW_SET_TYPE_MOUSE_LCLICK                    0   // �ݒ�^�C�v�@�}�E�X�@���N���b�N
#define SW_SET_TYPE_MOUSE_RCLICK                    1   // �ݒ�^�C�v�@�}�E�X�@�E�N���b�N
#define SW_SET_TYPE_MOUSE_WHCLICK                   2   // �ݒ�^�C�v�@�}�E�X�@�z�C�[���N���b�N
#define SW_SET_TYPE_MOUSE_B4CLICK                   3   // �ݒ�^�C�v�@�}�E�X�@�{�^��4
#define SW_SET_TYPE_MOUSE_B5CLICK                   4   // �ݒ�^�C�v�@�}�E�X�@�{�^��5
//#define SW_SET_TYPE_MOUSE_DCLICK                    5   // �ݒ�^�C�v�@�}�E�X�@�_�u���N���b�N
#define SW_SET_TYPE_MOUSE_MOVE_UP                   5   // �ݒ�^�C�v�@�}�E�X�@��ړ�
#define SW_SET_TYPE_MOUSE_MOVE_DOWN                 6   // �ݒ�^�C�v�@�}�E�X�@���ړ�
#define SW_SET_TYPE_MOUSE_MOVE_LEFT                 7   // �ݒ�^�C�v�@�}�E�X�@���ړ�
#define SW_SET_TYPE_MOUSE_MOVE_RIGHT                8   // �ݒ�^�C�v�@�}�E�X�@�E�ړ�
#define SW_SET_TYPE_MOUSE_WHSCROLL_UP               9   // �ݒ�^�C�v�@�}�E�X�@�z�C�[���X�N���[����
#define SW_SET_TYPE_MOUSE_WHSCROLL_DOWN             10  // �ݒ�^�C�v�@�}�E�X�@�z�C�[���X�N���[����
#define SW_SET_TYPE_MOUSE_SPEED                     11  // �ݒ�^�C�v�@�}�E�X�@�J�[�\�����x�ύX
//#define SW_SET_TYPE_MOUSE_TILT                      13   // �ݒ�^�C�v�@�}�E�X�@�`���g��
//#define SW_SET_TYPE_MOUSE_TILT_L                      14   // �ݒ�^�C�v�@�}�E�X�@�`���g��
//#define SW_SET_TYPE_MOUSE_TILT_R                      15   // �ݒ�^�C�v�@�}�E�X�@�`���g�E
#define SW_SET_TYPE_KEYBOARD_NUM                    1   // �ݒ�^�C�v�@�L�[�{�[�h�@�ݒ萔
#define SW_SET_TYPE_KEYBOARD_KEY                    0   // �ݒ�^�C�v�@�L�[�{�[�h�@�L�[
#define SW_SET_TYPE_JOYSTICK_NUM                    0   // �ݒ�^�C�v�@�W���C�X�e�B�b�N�@�ݒ萔

// ANALOG �ݒ�
#define ANALOG_SETTING_NUM                  8      // �ݒ萔 ANALOG 8
#define ANALOG_DEVICE_DATA_LEN              0x20    // ANALOG�f�o�C�X�ݒ�f�[�^��

#define ANALOG_DATA_SET_TYPE_IDX            0   // �A�i���O�ݒ�f�[�^  �Z�b�g�^�C�v�i�[�ʒu
#define ANALOG_DATA_SENSE_IDX               1   // �A�i���O�ݒ�f�[�^�@���x�����i�[�ʒu
#define ANALOG_DATA_CTRL_DATA_IDX           2   // �A�i���O�ݒ�f�[�^  �ݒ�^�C�v�i�[�ʒu
#define ANALOG_DATA_CENTER_VAL_HI_IDX       3   // �A�i���O�ݒ�f�[�^  �����ʒuHI�i�[�ʒu
#define ANALOG_DATA_CENTER_VAL_LO_IDX       4   // �A�i���O�ݒ�f�[�^  �����ʒuLO�i�[�ʒu
#define ANALOG_DATA_0V_VAL_IDX              5   // �A�i���O�ݒ�f�[�^�@0V���̏o�̓f�[�^�i�[�ʒu
#define ANALOG_DATA_3V_VAL_IDX              6   // �A�i���O�ݒ�f�[�^�@3V���̏o�̓f�[�^�i�[�ʒu
#define ANALOG_DATA_VOL1HI_IDX              7   // �A�i���O�ݒ�f�[�^�@�ϊ��d��1HI�i�[�ʒu
#define ANALOG_DATA_VOL1LO_IDX              8   // �A�i���O�ݒ�f�[�^�@�ϊ��d��1LO�i�[�ʒu
#define ANALOG_DATA_VAL1_IDX                9   // �A�i���O�ݒ�f�[�^�@�o�͒l1�i�[�ʒu
#define ANALOG_DATA_VOL2HI_IDX              10  // �A�i���O�ݒ�f�[�^�@�ϊ��d��2HI�i�[�ʒu
#define ANALOG_DATA_VOL2LO_IDX              11  // �A�i���O�ݒ�f�[�^�@�ϊ��d��2LO�i�[�ʒu
#define ANALOG_DATA_VAL2_IDX                12  // �A�i���O�ݒ�f�[�^�@�o�͒l2�i�[�ʒu
#define ANALOG_DATA_VOL3HI_IDX              13  // �A�i���O�ݒ�f�[�^�@�ϊ��d��3HI�i�[�ʒu
#define ANALOG_DATA_VOL3LO_IDX              14  // �A�i���O�ݒ�f�[�^�@�ϊ��d��3LO�i�[�ʒu
#define ANALOG_DATA_VAL3_IDX                15  // �A�i���O�ݒ�f�[�^�@�o�͒l3�i�[�ʒu
#define ANALOG_DATA_DEADZONE_IDX            16  // �A�i���O�ݒ�f�[�^�@�s���ъi�[�ʒu
            
#define ANALOG_SET_TYPE_NUM                 10   // �ݒ�^�C�v�@�ݒ萔
#define ANALOG_SET_TYPE_NONE                0   // �ݒ�^�C�v�@�Ȃ�
#define ANALOG_SET_TYPE_JOYSTICK_X          1   // �ݒ�^�C�v�@�W���C�X�e�B�b�NX
#define ANALOG_SET_TYPE_JOYSTICK_Y          2   // �ݒ�^�C�v�@�W���C�X�e�B�b�NY
#define ANALOG_SET_TYPE_JOYSTICK_Z          3   // �ݒ�^�C�v�@�W���C�X�e�B�b�NZ
#define ANALOG_SET_TYPE_JOYSTICK_RX         4   // �ݒ�^�C�v�@�W���C�X�e�B�b�NRX
#define ANALOG_SET_TYPE_JOYSTICK_RY         5   // �ݒ�^�C�v�@�W���C�X�e�B�b�NRY
#define ANALOG_SET_TYPE_JOYSTICK_RZ         6   // �ݒ�^�C�v�@�W���C�X�e�B�b�NRZ
#define ANALOG_SET_TYPE_JOYSTICK_SL         7   // �ݒ�^�C�v�@�W���C�X�e�B�b�NSL
#define ANALOG_SET_TYPE_MOUSE_X             8   // �ݒ�^�C�v�@�}�E�XX
#define ANALOG_SET_TYPE_MOUSE_Y             9   // �ݒ�^�C�v�@�}�E�XY

#define ANALOG_MATH_VOL_NUM                 5   // �A�i���O�v�Z�p �d���̐�
#define ANALOG_MATH_CENTER_NUM              3   // �A�i���O�v�Z�p�@�����l�i�����l�A�s���эŏ��l�A�s���эő�l�j

#define N_ON    1		// normal ON
#define N_OFF   0		// normal OFF
#define R_ON    0		// reverse ON
#define R_OFF   1		// reverse OFF



//--------------------------------------------------
//�f�B���C�֐�
//--------------------------------------------------
// 40MHz = 1���� 0.025us
// 1us = 40���� = Delay10TCY(4);
// 5us = 200���� = Delay10TCYx(20);
// 10us = 400���� = Delay100TCYx(4);
// 50us = 2,000���� = Delay100TCYx(20);
// 100us = 4,000���� = Delay100TCYx(40);
// 1ms = 40,000���� = Delay10KTCYx(4);
// 10ms = 400,000���� = Delay10KTCYx(40);
// 100ms = 4,000,000���� = Delay10KTCYx(400)
#define DELAY_1us() Delay10TCYx(4)
#define DELAY_5us() Delay10TCYx(20)
#define DELAY_10us() Delay100TCYx(4)
#define DELAY_50us() Delay100TCYx(20)
#define DELAY_100us() Delay100TCYx(40)
#define DELAY_1ms() Delay10KTCYx(4)
#define DELAY_5ms() Delay10KTCYx(20)
#define DELAY_10ms() Delay10KTCYx(40)
#define DELAY_50ms() Delay10KTCYx(200)
#define DELAY_100ms() Delay10KTCYx(400)

extern void USBCBSendResume(void);

/*********************************************************
 * Extern symbols
 ********************************************************/


extern int8_t	c_version[];
extern BYTE sw_now_fix[SW_NUM];
extern BYTE sw_now_fix_pre[SW_NUM];
extern BYTE sw_press_on_cnt[SW_NUM];
extern BYTE sw_press_off_cnt[SW_NUM];

extern BYTE mouse_move_flag[MOUSE_MOVE_DIRECTION_NUM];
extern BYTE mouse_sensitivity[MOUSE_MOVE_DIRECTION_NUM];
extern int mouse_count_val[MOUSE_MOVE_DIRECTION_NUM];
//extern WORD mouse_count_val_temp[MOUSE_MOVE_DIRECTION_NUM];
extern BYTE set_keyboard_push_order_buff[SET_KEYBOARD_PUSH_ORDER_BUFF_SIZE];
extern BYTE set_keyboard_push_order_write_idx;
extern BYTE set_keyboard_push_order_ctrl_bit[SET_KEYBOARD_PUSH_ORDER_BUFF_SIZE];
extern BYTE set_keyboard_push_order_key_code[SET_KEYBOARD_PUSH_ORDER_BUFF_SIZE];
extern BYTE joystick_hat_sw_output;
extern BYTE joystick_lever_output[SW_DATA_JOYSTICK_LEVER_SIZE];

extern BYTE an_joystick_lever_out_flag[ANALOG_SETTING_NUM];
extern BYTE an_joystick_lever_out_value[ANALOG_SETTING_NUM];
extern WORD an_out_setup_ad_val[ANALOG_SETTING_NUM][ANALOG_MATH_VOL_NUM];
extern BYTE an_out_setup_out_val[ANALOG_SETTING_NUM][ANALOG_MATH_VOL_NUM];
extern WORD an_out_setup_center_val[ANALOG_SETTING_NUM][ANALOG_MATH_CENTER_NUM];
extern WORD an_mouse_count_val[ANALOG_SETTING_NUM][2];

//extern BYTE mouse_w_click_status;
//extern WORD mouse_w_click_interval_counter;

extern BYTE ReceivedDataBuffer[RX_DATA_BUFFER_SIZE] RX_DATA_BUFFER_ADDRESS;
extern BYTE ToSendDataBuffer[TX_DATA_BUFFER_SIZE] TX_DATA_BUFFER_ADDRESS;
extern BYTE mouse_input[MOUSE_BUFF_SIZE];
extern BYTE joystick_input[JOYSTICK_BUFF_SIZE];
extern BYTE keyboard_input[KEYBOARD_BUFF_SIZE];
extern BYTE keyboard_output[HID_INT_OUT_EP_SIZE];
//extern BYTE multimedia_input[MULTIMEDIA_BUFF_SIZE];
extern BYTE mouse_buffer[MOUSE_BUFF_SIZE];
extern BYTE mouse_buffer_pre[MOUSE_BUFF_SIZE];
extern BYTE joystick_buffer[JOYSTICK_BUFF_SIZE];
extern BYTE joystick_buffer_pre[JOYSTICK_BUFF_SIZE];
extern BYTE joystick_default_value[JOYSTICK_BUFF_SIZE];
extern BYTE keyboard_buffer[KEYBOARD_BUFF_SIZE];
extern BYTE keyboard_buffer_pre[KEYBOARD_BUFF_SIZE];
extern WORD joystick_out_time_counter;
extern BYTE joystick_lever_move_value[JOYSTICK_BUFF_SIZE];

//extern BYTE multimedia_buffer[MULTIMEDIA_BUFF_SIZE];
//extern BYTE multimedia_buffer_pre[MULTIMEDIA_BUFF_SIZE];
extern BYTE mouse_input_out_flag;
extern BYTE joystick_input_out_flag;
extern BYTE keyboard_input_out_flag;
//extern BYTE multimedia_input_out_flag;


// FLASH
extern BYTE eeprom_read_req_flag;
extern BYTE eeprom_write_req_flag;

extern BYTE USB_Sleep_Flag;

extern USB_HANDLE USBOutHandle;
extern USB_HANDLE USBInHandle;
extern USB_HANDLE lastTransmission_Mouse;
extern USB_HANDLE lastTransmission_Joystick;
extern USB_HANDLE lastINTransmission_Keyboard;
extern USB_HANDLE lastOUTTransmission_Keyboard;
//extern USB_HANDLE lastTransmission_Multimedia;

// DEBUG
extern BYTE debug_arr1[16];
extern BYTE debug_arr2[16];
extern BYTE debug_arr3[16];
extern WORD debug_array_w1[16];


#endif	/* APP_H */

