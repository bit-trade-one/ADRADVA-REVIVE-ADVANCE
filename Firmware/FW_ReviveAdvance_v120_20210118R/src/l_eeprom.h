<<<<<<< HEAD
#ifndef L_EEPROM_H
#define L_EEPROM_H

#include "app.h"

#define EEPROM_PARTS_AT25080B
//#define EEPROM_PARTS_AT25160B
//#define EEPROM_PARTS_AT25320B
//#define EEPROM_PARTS_AT25640B
//#define EEPROM_PARTS_AT25128B
//#define EEPROM_PARTS_AT25256B


#define EEPROM_INST_WREN            0x06        // Set Write Enable
#define EEPROM_INST_WRDI            0x04		// Reset Write Disable
#define EEPROM_INST_RDSR            0x05		// Read Status Register
#define EEPROM_INST_WRSR            0x01		// Write Status Register
#define EEPROM_INST_READ            0x03		// Read Data from Memory Array
#define EEPROM_INST_WRITE           0x02		// Write Data to Memory Array

#ifdef EEPROM_PARTS_AT25080B
#define EEPROM_ADR_BITS             16
#define EEPROM_SIZE                 1024        // 1KByte 1024=0x0400
#define EEPROM_PAGE_SIZE            0x20		//(byte) Page Program
#endif

#ifdef EEPROM_PARTS_AT25160B
#define EEPROM_ADR_BITS             16
#define EEPROM_SIZE                 2048        // 2KByte 2048=0x0800
#define EEPROM_PAGE_SIZE            0x20		//(byte) Page Program
#endif

#ifdef EEPROM_PARTS_AT25320B
#define EEPROM_ADR_BITS             16
#define EEPROM_SIZE                 4096        // 4KByte 4096=0x1000
#define EEPROM_PAGE_SIZE            0x20		//(byte) Page Program
#endif

#ifdef EEPROM_PARTS_AT25640B
#define EEPROM_ADR_BITS             16
#define EEPROM_SIZE                 8192        // 8KByte 8192=0x2000
#define EEPROM_PAGE_SIZE            0x20		//(byte) Page Program
#endif

#ifdef EEPROM_PARTS_AT25128B
#define EEPROM_ADR_BITS             16
#define EEPROM_SIZE                 16384       // 16KByte 16384=0x4000
#define EEPROM_PAGE_SIZE            0x20		//(byte) Page Program
#endif

#ifdef EEPROM_PARTS_AT25256B
#define EEPROM_ADR_BITS             16
#define EEPROM_SIZE                 32768       // 32KByte 32768=0x8000
#define EEPROM_PAGE_SIZE            0x20		//(byte) Page Program
#endif

#if EEPROM_ADR_BITS == 8
typedef BYTE EEPROM_ADR;
#endif

#if EEPROM_ADR_BITS == 16
typedef WORD EEPROM_ADR;
#endif

#if EEPROM_ADR_BITS == 24
typedef DWORD EEPROM_ADR;
#endif

// EEPROM
// Address
#define EEPROM_INIT_DATA_ADR            0x0000
#define EEPROM_INIT_DATA_SIZE           0x0002
#define EEPROM_SW_SETTION_ADR           0x0010
#define EEPROM_SW_SETTION_SIZE          0x0010
#define EEPROM_AN_SETTION_ADR           0x0100
#define EEPROM_AN_SETTION_SIZE          0x0020


#define EEPROM_CS_ON()  LATAbits.LATA9 = 0	// SS RA9 Lo
#define EEPROM_CS_OFF() LATAbits.LATA9 = 1	// SS RA9 Hi

//EEPROM SW設定
typedef struct
{
    BYTE        data[SW_DATA_LEN];            // SW Data
} ST_SW_INFO;
typedef struct
{
    ST_SW_INFO  sw_info[SW_SETTING_NUM];            // Mouse SW
//    BYTE        reserved[8];
} ST_SW_INFOS;
typedef union
{
	BYTE        byte[(SW_SETTING_NUM*SW_DATA_LEN)];
	ST_SW_INFOS SW_Infos;
} UN_SW_INFOS;

//EEPROM ANALOG設定
typedef struct
{
    BYTE        data[ANALOG_DEVICE_DATA_LEN];            // ANALOG Data
} ST_AN_INFO;
typedef struct
{
    ST_AN_INFO  an_info[ANALOG_SETTING_NUM];            // ANALOG
//    BYTE        reserved[8];
} ST_AN_INFOS;
typedef union
{
	BYTE        byte[(ANALOG_SETTING_NUM*ANALOG_DEVICE_DATA_LEN)];
	ST_AN_INFOS AN_Infos;
} UN_AN_INFOS;


#define EEPROM_DEFAULT_DATA_SIZE    0x200


// 外部宣言 変数　
extern UN_SW_INFOS my_sw_infos;
extern UN_AN_INFOS my_an_infos;

extern const BYTE c_eeprom_default_data[EEPROM_DEFAULT_DATA_SIZE];

//=========================================================
// low level access
//=========================================================
extern void eeprom_wrsr(char val);
extern void eeprom_write_byte(EEPROM_ADR adr,BYTE data);
extern void eeprom_write_word(EEPROM_ADR adr,WORD data);
extern BYTE eeprom_rdsr(void);
extern BYTE eeprom_busy(void);
extern void eeprom_wait_wip(void);
extern BYTE eeprom_read_byte(EEPROM_ADR adr);
extern WORD eeprom_read_word(EEPROM_ADR adr);
extern void eeprom_read_adr(EEPROM_ADR adr);
extern void eeprom_wren(void);
extern void eeprom_wrdi(void);

extern void eeprom_continuous_start(void);
extern void eeprom_continuous_end(void);
extern void eeprom_continuous_write(EEPROM_ADR adr);
extern void eeprom_continuous_read(EEPROM_ADR adr);
extern BYTE eeprom_continuous_access_w(BYTE data);
extern BYTE eeprom_continuous_access_r();

//=========================================================
// hi level access
//=========================================================
extern void eeprom_unprotected(void);
extern void eeprom_protect(void);
extern void eeprom_n_write(EEPROM_ADR adr, BYTE *buf, int len);
extern void eeprom_n_read(EEPROM_ADR adr, BYTE *buf, int len);

extern void u_SWInfo_buffClr(UN_SW_INFOS* p_sw_infos);
extern void u_ANInfo_buffClr(UN_AN_INFOS* p_an_infos);

extern int u_GetSWInfo(UN_SW_INFOS* p_sw_info);
extern int u_GetANInfo(UN_AN_INFOS* p_an_info);


#endif//L_FLASH_H
=======
#ifndef L_EEPROM_H
#define L_EEPROM_H

#include "app.h"

#define EEPROM_PARTS_AT25080B
//#define EEPROM_PARTS_AT25160B
//#define EEPROM_PARTS_AT25320B
//#define EEPROM_PARTS_AT25640B
//#define EEPROM_PARTS_AT25128B
//#define EEPROM_PARTS_AT25256B


#define EEPROM_INST_WREN            0x06        // Set Write Enable
#define EEPROM_INST_WRDI            0x04		// Reset Write Disable
#define EEPROM_INST_RDSR            0x05		// Read Status Register
#define EEPROM_INST_WRSR            0x01		// Write Status Register
#define EEPROM_INST_READ            0x03		// Read Data from Memory Array
#define EEPROM_INST_WRITE           0x02		// Write Data to Memory Array

#ifdef EEPROM_PARTS_AT25080B
#define EEPROM_ADR_BITS             16
#define EEPROM_SIZE                 1024        // 1KByte 1024=0x0400
#define EEPROM_PAGE_SIZE            0x20		//(byte) Page Program
#endif

#ifdef EEPROM_PARTS_AT25160B
#define EEPROM_ADR_BITS             16
#define EEPROM_SIZE                 2048        // 2KByte 2048=0x0800
#define EEPROM_PAGE_SIZE            0x20		//(byte) Page Program
#endif

#ifdef EEPROM_PARTS_AT25320B
#define EEPROM_ADR_BITS             16
#define EEPROM_SIZE                 4096        // 4KByte 4096=0x1000
#define EEPROM_PAGE_SIZE            0x20		//(byte) Page Program
#endif

#ifdef EEPROM_PARTS_AT25640B
#define EEPROM_ADR_BITS             16
#define EEPROM_SIZE                 8192        // 8KByte 8192=0x2000
#define EEPROM_PAGE_SIZE            0x20		//(byte) Page Program
#endif

#ifdef EEPROM_PARTS_AT25128B
#define EEPROM_ADR_BITS             16
#define EEPROM_SIZE                 16384       // 16KByte 16384=0x4000
#define EEPROM_PAGE_SIZE            0x20		//(byte) Page Program
#endif

#ifdef EEPROM_PARTS_AT25256B
#define EEPROM_ADR_BITS             16
#define EEPROM_SIZE                 32768       // 32KByte 32768=0x8000
#define EEPROM_PAGE_SIZE            0x20		//(byte) Page Program
#endif

#if EEPROM_ADR_BITS == 8
typedef BYTE EEPROM_ADR;
#endif

#if EEPROM_ADR_BITS == 16
typedef WORD EEPROM_ADR;
#endif

#if EEPROM_ADR_BITS == 24
typedef DWORD EEPROM_ADR;
#endif

// EEPROM
// Address
#define EEPROM_INIT_DATA_ADR            0x0000
#define EEPROM_INIT_DATA_SIZE           0x0002
#define EEPROM_SW_SETTION_ADR           0x0010
#define EEPROM_SW_SETTION_SIZE          0x0010
#define EEPROM_AN_SETTION_ADR           0x0100
#define EEPROM_AN_SETTION_SIZE          0x0020


#define EEPROM_CS_ON()  LATAbits.LATA9 = 0	// SS RA9 Lo
#define EEPROM_CS_OFF() LATAbits.LATA9 = 1	// SS RA9 Hi

//EEPROM SW設定
typedef struct
{
    BYTE        data[SW_DATA_LEN];            // SW Data
} ST_SW_INFO;
typedef struct
{
    ST_SW_INFO  sw_info[SW_SETTING_NUM];            // Mouse SW
//    BYTE        reserved[8];
} ST_SW_INFOS;
typedef union
{
	BYTE        byte[(SW_SETTING_NUM*SW_DATA_LEN)];
	ST_SW_INFOS SW_Infos;
} UN_SW_INFOS;

//EEPROM ANALOG設定
typedef struct
{
    BYTE        data[ANALOG_DEVICE_DATA_LEN];            // ANALOG Data
} ST_AN_INFO;
typedef struct
{
    ST_AN_INFO  an_info[ANALOG_SETTING_NUM];            // ANALOG
//    BYTE        reserved[8];
} ST_AN_INFOS;
typedef union
{
	BYTE        byte[(ANALOG_SETTING_NUM*ANALOG_DEVICE_DATA_LEN)];
	ST_AN_INFOS AN_Infos;
} UN_AN_INFOS;


#define EEPROM_DEFAULT_DATA_SIZE    0x200


// 外部宣言 変数　
extern UN_SW_INFOS my_sw_infos;
extern UN_AN_INFOS my_an_infos;

extern const BYTE c_eeprom_default_data[EEPROM_DEFAULT_DATA_SIZE];

//=========================================================
// low level access
//=========================================================
extern void eeprom_wrsr(char val);
extern void eeprom_write_byte(EEPROM_ADR adr,BYTE data);
extern void eeprom_write_word(EEPROM_ADR adr,WORD data);
extern BYTE eeprom_rdsr(void);
extern BYTE eeprom_busy(void);
extern void eeprom_wait_wip(void);
extern BYTE eeprom_read_byte(EEPROM_ADR adr);
extern WORD eeprom_read_word(EEPROM_ADR adr);
extern void eeprom_read_adr(EEPROM_ADR adr);
extern void eeprom_wren(void);
extern void eeprom_wrdi(void);

extern void eeprom_continuous_start(void);
extern void eeprom_continuous_end(void);
extern void eeprom_continuous_write(EEPROM_ADR adr);
extern void eeprom_continuous_read(EEPROM_ADR adr);
extern BYTE eeprom_continuous_access_w(BYTE data);
extern BYTE eeprom_continuous_access_r();

//=========================================================
// hi level access
//=========================================================
extern void eeprom_unprotected(void);
extern void eeprom_protect(void);
extern void eeprom_n_write(EEPROM_ADR adr, BYTE *buf, int len);
extern void eeprom_n_read(EEPROM_ADR adr, BYTE *buf, int len);

extern void u_SWInfo_buffClr(UN_SW_INFOS* p_sw_infos);
extern void u_ANInfo_buffClr(UN_AN_INFOS* p_an_infos);

extern int u_GetSWInfo(UN_SW_INFOS* p_sw_info);
extern int u_GetANInfo(UN_AN_INFOS* p_an_info);


#endif//L_FLASH_H
>>>>>>> Upload-ready
