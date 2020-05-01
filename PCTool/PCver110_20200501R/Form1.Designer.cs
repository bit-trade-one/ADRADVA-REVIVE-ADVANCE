namespace ReviveUSBAdvance
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.ReadWriteThread = new System.ComponentModel.BackgroundWorker();
            this.FormUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.KeyboardValue_txtbx = new System.Windows.Forms.TextBox();
            this.PushbuttonStateTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.MouseMove_UD = new System.Windows.Forms.NumericUpDown();
            this.Button12_cbox = new System.Windows.Forms.CheckBox();
            this.Button11_cbox = new System.Windows.Forms.CheckBox();
            this.Button10_cbox = new System.Windows.Forms.CheckBox();
            this.Button9_cbox = new System.Windows.Forms.CheckBox();
            this.Button8_cbox = new System.Windows.Forms.CheckBox();
            this.Button7_cbox = new System.Windows.Forms.CheckBox();
            this.cmbbx_digital_pin = new System.Windows.Forms.ComboBox();
            this.Button6_cbox = new System.Windows.Forms.CheckBox();
            this.Button5_cbox = new System.Windows.Forms.CheckBox();
            this.Button4_cbox = new System.Windows.Forms.CheckBox();
            this.Button3_cbox = new System.Windows.Forms.CheckBox();
            this.Button2_cbox = new System.Windows.Forms.CheckBox();
            this.Button1_cbox = new System.Windows.Forms.CheckBox();
            this.LeverYM_cbox = new System.Windows.Forms.CheckBox();
            this.LeverYP_cbox = new System.Windows.Forms.CheckBox();
            this.LeverXM_cbox = new System.Windows.Forms.CheckBox();
            this.LeverXP_cbox = new System.Windows.Forms.CheckBox();
            this.Win_cbox = new System.Windows.Forms.CheckBox();
            this.Shift_cbox = new System.Windows.Forms.CheckBox();
            this.Alt_cbox = new System.Windows.Forms.CheckBox();
            this.Ctrl_cbox = new System.Windows.Forms.CheckBox();
            this.cmbbx_digital_assign = new System.Windows.Forms.ComboBox();
            this.cmbbx_digital_device_type = new System.Windows.Forms.ComboBox();
            this.devicetype_lbl4 = new System.Windows.Forms.Label();
            this.devicetype_lbl1 = new System.Windows.Forms.Label();
            this.devicetype_lbl3 = new System.Windows.Forms.Label();
            this.devicetype_lbl2 = new System.Windows.Forms.Label();
            this.devicetype_lbl9 = new System.Windows.Forms.Label();
            this.devicetype_lbl8 = new System.Windows.Forms.Label();
            this.devicetype_lbl7 = new System.Windows.Forms.Label();
            this.DeviceAssign_lbl4 = new System.Windows.Forms.Label();
            this.DeviceAssign_lbl1 = new System.Windows.Forms.Label();
            this.DeviceAssign_lbl3 = new System.Windows.Forms.Label();
            this.DeviceAssign_lbl2 = new System.Windows.Forms.Label();
            this.DeviceAssign_lbl9 = new System.Windows.Forms.Label();
            this.DeviceAssign_lbl8 = new System.Windows.Forms.Label();
            this.DeviceAssign_lbl7 = new System.Windows.Forms.Label();
            this.StatusBox_lbl = new System.Windows.Forms.Label();
            this.StatusBox_lbl2 = new System.Windows.Forms.Label();
            this.devicetype_lbl5 = new System.Windows.Forms.Label();
            this.devicetype_lbl6 = new System.Windows.Forms.Label();
            this.DeviceAssign_lbl5 = new System.Windows.Forms.Label();
            this.DeviceAssign_lbl6 = new System.Windows.Forms.Label();
            this.devicetype_lbl10 = new System.Windows.Forms.Label();
            this.devicetype_lbl11 = new System.Windows.Forms.Label();
            this.devicetype_lbl12 = new System.Windows.Forms.Label();
            this.DeviceAssign_lbl10 = new System.Windows.Forms.Label();
            this.DeviceAssign_lbl11 = new System.Windows.Forms.Label();
            this.DeviceAssign_lbl12 = new System.Windows.Forms.Label();
            this.chkbx_analog_calibration = new System.Windows.Forms.CheckBox();
            this.lbl_output_val = new System.Windows.Forms.Label();
            this.num_analog_sensitivity = new System.Windows.Forms.NumericUpDown();
            this.gbx_analog_calibration = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.num_analog_dead_zone = new System.Windows.Forms.NumericUpDown();
            this.chkbx_center_calibration = new System.Windows.Forms.CheckBox();
            this.lbl_analog_sensitivity = new System.Windows.Forms.Label();
            this.pic_analog_arrow5 = new System.Windows.Forms.PictureBox();
            this.pic_analog_arrow4 = new System.Windows.Forms.PictureBox();
            this.pic_analog_arrow3 = new System.Windows.Forms.PictureBox();
            this.pic_analog_arrow2 = new System.Windows.Forms.PictureBox();
            this.pic_analog_arrow1 = new System.Windows.Forms.PictureBox();
            this.lbl_analog_set_type = new System.Windows.Forms.Label();
            this.lbl_analog_pin_no = new System.Windows.Forms.Label();
            this.btn_analog_set = new System.Windows.Forms.Button();
            this.lbl_input_vol5 = new System.Windows.Forms.Label();
            this.num_output_val5 = new System.Windows.Forms.NumericUpDown();
            this.num_output_val4 = new System.Windows.Forms.NumericUpDown();
            this.num_input_vol4 = new System.Windows.Forms.NumericUpDown();
            this.num_output_val3 = new System.Windows.Forms.NumericUpDown();
            this.num_input_vol3 = new System.Windows.Forms.NumericUpDown();
            this.num_output_val2 = new System.Windows.Forms.NumericUpDown();
            this.num_output_val1 = new System.Windows.Forms.NumericUpDown();
            this.lbl_input_vol1 = new System.Windows.Forms.Label();
            this.lbl_input_voltage = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cmbbx_analog_set_type = new System.Windows.Forms.ComboBox();
            this.cmbbx_analog_pin = new System.Windows.Forms.ComboBox();
            this.num_input_vol2 = new System.Windows.Forms.NumericUpDown();
            this.Button13_cbox = new System.Windows.Forms.CheckBox();
            this.Button14_cbox = new System.Windows.Forms.CheckBox();
            this.Button15_cbox = new System.Windows.Forms.CheckBox();
            this.btn_soft_reset = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.colum_lbl = new System.Windows.Forms.Label();
            this.Debug_label3 = new System.Windows.Forms.Label();
            this.Debug_label4 = new System.Windows.Forms.Label();
            this.Debug_label2 = new System.Windows.Forms.Label();
            this.Debug_label1 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btn_debug_eeprom_write5 = new System.Windows.Forms.Button();
            this.btn_debug_eeprom_write4 = new System.Windows.Forms.Button();
            this.btn_debug_eeprom_write3 = new System.Windows.Forms.Button();
            this.btn_debug_eeprom_write2 = new System.Windows.Forms.Button();
            this.btn_debug_eeprom_write1 = new System.Windows.Forms.Button();
            this.rtxtbx_debug_flash_read = new System.Windows.Forms.RichTextBox();
            this.txtbx_debug_flash_read_size = new System.Windows.Forms.TextBox();
            this.txtbx_debug_flash_read_addr = new System.Windows.Forms.TextBox();
            this.btn_debug_flash_read = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.DeviceAssign_lbl13 = new System.Windows.Forms.Label();
            this.devicetype_lbl13 = new System.Windows.Forms.Label();
            this.DeviceAssign_lbl14 = new System.Windows.Forms.Label();
            this.devicetype_lbl14 = new System.Windows.Forms.Label();
            this.DeviceAssign_lbl15 = new System.Windows.Forms.Label();
            this.devicetype_lbl15 = new System.Windows.Forms.Label();
            this.lbl_analog1_status = new System.Windows.Forms.Label();
            this.lbl_analog1_assign = new System.Windows.Forms.Label();
            this.lbl_analog2_assign = new System.Windows.Forms.Label();
            this.lbl_analog2_status = new System.Windows.Forms.Label();
            this.lbl_analog3_assign = new System.Windows.Forms.Label();
            this.lbl_analog3_status = new System.Windows.Forms.Label();
            this.lbl_analog4_assign = new System.Windows.Forms.Label();
            this.lbl_analog4_status = new System.Windows.Forms.Label();
            this.lbl_analog8_assign = new System.Windows.Forms.Label();
            this.lbl_analog8_status = new System.Windows.Forms.Label();
            this.lbl_analog7_assign = new System.Windows.Forms.Label();
            this.lbl_analog7_status = new System.Windows.Forms.Label();
            this.lbl_analog6_assign = new System.Windows.Forms.Label();
            this.lbl_analog6_status = new System.Windows.Forms.Label();
            this.lbl_analog5_assign = new System.Windows.Forms.Label();
            this.lbl_analog5_status = new System.Windows.Forms.Label();
            this.hatsw_up_cbox = new System.Windows.Forms.CheckBox();
            this.hatsw_right_cbox = new System.Windows.Forms.CheckBox();
            this.hatsw_down_cbox = new System.Windows.Forms.CheckBox();
            this.hatsw_left_cbox = new System.Windows.Forms.CheckBox();
            this.lbl_FW_Version = new System.Windows.Forms.Label();
            this.btn_default_reset = new System.Windows.Forms.Button();
            this.LeverSliderM_cbox = new System.Windows.Forms.CheckBox();
            this.LeverSliderP_cbox = new System.Windows.Forms.CheckBox();
            this.lbl_sw_mouse_title2 = new System.Windows.Forms.Label();
            this.lbl_sw_mouse_title1 = new System.Windows.Forms.Label();
            this.LeverRZP_cbox = new System.Windows.Forms.CheckBox();
            this.LeverRZM_cbox = new System.Windows.Forms.CheckBox();
            this.LeverRYP_cbox = new System.Windows.Forms.CheckBox();
            this.LeverRYM_cbox = new System.Windows.Forms.CheckBox();
            this.LeverRXP_cbox = new System.Windows.Forms.CheckBox();
            this.LeverRXM_cbox = new System.Windows.Forms.CheckBox();
            this.LeverZP_cbox = new System.Windows.Forms.CheckBox();
            this.LeverZM_cbox = new System.Windows.Forms.CheckBox();
            this.lbl_digital_assign = new System.Windows.Forms.Label();
            this.lbl_digital_device_type = new System.Windows.Forms.Label();
            this.lbl_digital_pin_no = new System.Windows.Forms.Label();
            this.btn_digital_set = new System.Windows.Forms.Button();
            this.Arrow_Com_pb = new System.Windows.Forms.PictureBox();
            this.Arrow_Mouse1_pb = new System.Windows.Forms.PictureBox();
            this.Arrow_Mouse2_pb = new System.Windows.Forms.PictureBox();
            this.Arrow_Mouse3_pb = new System.Windows.Forms.PictureBox();
            this.Arrow_Keyboard_pb = new System.Windows.Forms.PictureBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbx_setting_list = new System.Windows.Forms.GroupBox();
            this.pnl_analog_setting = new System.Windows.Forms.Panel();
            this.pnl_digital_setting = new System.Windows.Forms.Panel();
            this.Revive_Advance_Device_pb = new System.Windows.Forms.PictureBox();
            this.dig_tabA_pb = new System.Windows.Forms.PictureBox();
            this.ana_tabA_pb = new System.Windows.Forms.PictureBox();
            this.dig_tabB_pb = new System.Windows.Forms.PictureBox();
            this.ana_tabB_pb = new System.Windows.Forms.PictureBox();
            this.PinAN08A_pb = new System.Windows.Forms.PictureBox();
            this.PinAN07A_pb = new System.Windows.Forms.PictureBox();
            this.PinAN06A_pb = new System.Windows.Forms.PictureBox();
            this.PinAN05A_pb = new System.Windows.Forms.PictureBox();
            this.PinAN04A_pb = new System.Windows.Forms.PictureBox();
            this.PinAN03A_pb = new System.Windows.Forms.PictureBox();
            this.PinAN02A_pb = new System.Windows.Forms.PictureBox();
            this.PinAN01A_pb = new System.Windows.Forms.PictureBox();
            this.PinAN08B_pb = new System.Windows.Forms.PictureBox();
            this.PinAN07B_pb = new System.Windows.Forms.PictureBox();
            this.PinAN06B_pb = new System.Windows.Forms.PictureBox();
            this.PinAN05B_pb = new System.Windows.Forms.PictureBox();
            this.PinAN04B_pb = new System.Windows.Forms.PictureBox();
            this.PinAN03B_pb = new System.Windows.Forms.PictureBox();
            this.PinAN02B_pb = new System.Windows.Forms.PictureBox();
            this.PinAN01B_pb = new System.Windows.Forms.PictureBox();
            this.Pin06A_pb = new System.Windows.Forms.PictureBox();
            this.Pin06B_pb = new System.Windows.Forms.PictureBox();
            this.ButtonPressIcon15 = new System.Windows.Forms.PictureBox();
            this.Pin15A_pb = new System.Windows.Forms.PictureBox();
            this.Pin15B_pb = new System.Windows.Forms.PictureBox();
            this.ButtonPressIcon14 = new System.Windows.Forms.PictureBox();
            this.Pin14A_pb = new System.Windows.Forms.PictureBox();
            this.Pin14B_pb = new System.Windows.Forms.PictureBox();
            this.ButtonPressIcon13 = new System.Windows.Forms.PictureBox();
            this.Pin13A_pb = new System.Windows.Forms.PictureBox();
            this.Pin13B_pb = new System.Windows.Forms.PictureBox();
            this.ButtonPressIcon12 = new System.Windows.Forms.PictureBox();
            this.ButtonPressIcon11 = new System.Windows.Forms.PictureBox();
            this.ButtonPressIcon10 = new System.Windows.Forms.PictureBox();
            this.ButtonPressIcon9 = new System.Windows.Forms.PictureBox();
            this.ButtonPressIcon8 = new System.Windows.Forms.PictureBox();
            this.Pin12A_pb = new System.Windows.Forms.PictureBox();
            this.Pin11A_pb = new System.Windows.Forms.PictureBox();
            this.Pin10A_pb = new System.Windows.Forms.PictureBox();
            this.Pin09A_pb = new System.Windows.Forms.PictureBox();
            this.Pin08A_pb = new System.Windows.Forms.PictureBox();
            this.Pin01A_pb = new System.Windows.Forms.PictureBox();
            this.Pin02A_pb = new System.Windows.Forms.PictureBox();
            this.Pin03A_pb = new System.Windows.Forms.PictureBox();
            this.Pin04A_pb = new System.Windows.Forms.PictureBox();
            this.Pin05A_pb = new System.Windows.Forms.PictureBox();
            this.Pin02B_pb = new System.Windows.Forms.PictureBox();
            this.Pin03B_pb = new System.Windows.Forms.PictureBox();
            this.Pin04B_pb = new System.Windows.Forms.PictureBox();
            this.Pin01B_pb = new System.Windows.Forms.PictureBox();
            this.Pin05B_pb = new System.Windows.Forms.PictureBox();
            this.Pin07A_pb = new System.Windows.Forms.PictureBox();
            this.Pin07B_pb = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.Status_C_pb = new System.Windows.Forms.PictureBox();
            this.ButtonPressIcon5 = new System.Windows.Forms.PictureBox();
            this.ButtonPressIcon6 = new System.Windows.Forms.PictureBox();
            this.ButtonPressIcon7 = new System.Windows.Forms.PictureBox();
            this.ButtonPressIcon4 = new System.Windows.Forms.PictureBox();
            this.ButtonPressIcon3 = new System.Windows.Forms.PictureBox();
            this.ButtonPressIcon2 = new System.Windows.Forms.PictureBox();
            this.ButtonPressIcon1 = new System.Windows.Forms.PictureBox();
            this.Pin08B_pb = new System.Windows.Forms.PictureBox();
            this.Pin09B_pb = new System.Windows.Forms.PictureBox();
            this.Pin10B_pb = new System.Windows.Forms.PictureBox();
            this.Pin11B_pb = new System.Windows.Forms.PictureBox();
            this.Pin12B_pb = new System.Windows.Forms.PictureBox();
            this.Status_NC_pb = new System.Windows.Forms.PictureBox();
            this.BackGround_pb = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.MouseMove_UD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_analog_sensitivity)).BeginInit();
            this.gbx_analog_calibration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_analog_dead_zone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_analog_arrow5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_analog_arrow4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_analog_arrow3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_analog_arrow2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_analog_arrow1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_output_val5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_output_val4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_input_vol4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_output_val3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_input_vol3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_output_val2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_output_val1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_input_vol2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Arrow_Com_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Arrow_Mouse1_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Arrow_Mouse2_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Arrow_Mouse3_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Arrow_Keyboard_pb)).BeginInit();
            this.gbx_setting_list.SuspendLayout();
            this.pnl_analog_setting.SuspendLayout();
            this.pnl_digital_setting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Revive_Advance_Device_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dig_tabA_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ana_tabA_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dig_tabB_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ana_tabB_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinAN08A_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinAN07A_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinAN06A_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinAN05A_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinAN04A_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinAN03A_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinAN02A_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinAN01A_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinAN08B_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinAN07B_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinAN06B_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinAN05B_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinAN04B_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinAN03B_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinAN02B_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinAN01B_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin06A_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin06B_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonPressIcon15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin15A_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin15B_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonPressIcon14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin14A_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin14B_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonPressIcon13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin13A_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin13B_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonPressIcon12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonPressIcon11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonPressIcon10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonPressIcon9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonPressIcon8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin12A_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin11A_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin10A_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin09A_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin08A_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin01A_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin02A_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin03A_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin04A_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin05A_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin02B_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin03B_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin04B_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin01B_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin05B_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin07A_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin07B_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Status_C_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonPressIcon5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonPressIcon6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonPressIcon7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonPressIcon4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonPressIcon3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonPressIcon2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonPressIcon1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin08B_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin09B_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin10B_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin11B_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin12B_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Status_NC_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackGround_pb)).BeginInit();
            this.SuspendLayout();
            // 
            // ReadWriteThread
            // 
            this.ReadWriteThread.WorkerReportsProgress = true;
            this.ReadWriteThread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ReadWriteThread_DoWork);
            // 
            // FormUpdateTimer
            // 
            this.FormUpdateTimer.Enabled = true;
            this.FormUpdateTimer.Interval = 50;
            this.FormUpdateTimer.Tick += new System.EventHandler(this.FormUpdateTimer_Tick);
            // 
            // KeyboardValue_txtbx
            // 
            this.KeyboardValue_txtbx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.KeyboardValue_txtbx.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.KeyboardValue_txtbx.Location = new System.Drawing.Point(73, 220);
            this.KeyboardValue_txtbx.Name = "KeyboardValue_txtbx";
            this.KeyboardValue_txtbx.Size = new System.Drawing.Size(100, 19);
            this.KeyboardValue_txtbx.TabIndex = 35;
            this.KeyboardValue_txtbx.Text = "ここに入力";
            this.KeyboardValue_txtbx.Visible = false;
            this.KeyboardValue_txtbx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyboardValue_txtbx_KeyDown);
            this.KeyboardValue_txtbx.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyboardValue_txtbx_KeyUp);
            this.KeyboardValue_txtbx.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.KeyboardValue_txtbx_PreviewKeyDown);
            // 
            // PushbuttonStateTooltip
            // 
            this.PushbuttonStateTooltip.AutomaticDelay = 20;
            this.PushbuttonStateTooltip.AutoPopDelay = 20000;
            this.PushbuttonStateTooltip.InitialDelay = 15;
            this.PushbuttonStateTooltip.ReshowDelay = 15;
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 2000;
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 1000;
            this.toolTip1.ReshowDelay = 100;
            // 
            // MouseMove_UD
            // 
            this.MouseMove_UD.BackColor = System.Drawing.SystemColors.Window;
            this.MouseMove_UD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.MouseMove_UD.Location = new System.Drawing.Point(58, 177);
            this.MouseMove_UD.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.MouseMove_UD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MouseMove_UD.Name = "MouseMove_UD";
            this.MouseMove_UD.Size = new System.Drawing.Size(128, 19);
            this.MouseMove_UD.TabIndex = 21;
            this.MouseMove_UD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MouseMove_UD.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.MouseMove_UD.Visible = false;
            this.MouseMove_UD.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // Button12_cbox
            // 
            this.Button12_cbox.BackColor = System.Drawing.Color.Transparent;
            this.Button12_cbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.Button12_cbox.Location = new System.Drawing.Point(175, 345);
            this.Button12_cbox.Name = "Button12_cbox";
            this.Button12_cbox.Size = new System.Drawing.Size(75, 16);
            this.Button12_cbox.TabIndex = 81;
            this.Button12_cbox.Tag = "11";
            this.Button12_cbox.Text = "ボタン12";
            this.Button12_cbox.UseVisualStyleBackColor = false;
            this.Button12_cbox.Visible = false;
            this.Button12_cbox.CheckedChanged += new System.EventHandler(this.Joystick_Button_CheckedChanged);
            // 
            // Button11_cbox
            // 
            this.Button11_cbox.BackColor = System.Drawing.Color.Transparent;
            this.Button11_cbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.Button11_cbox.Location = new System.Drawing.Point(175, 327);
            this.Button11_cbox.Name = "Button11_cbox";
            this.Button11_cbox.Size = new System.Drawing.Size(75, 16);
            this.Button11_cbox.TabIndex = 80;
            this.Button11_cbox.Tag = "10";
            this.Button11_cbox.Text = "ボタン11";
            this.Button11_cbox.UseVisualStyleBackColor = false;
            this.Button11_cbox.Visible = false;
            this.Button11_cbox.CheckedChanged += new System.EventHandler(this.Joystick_Button_CheckedChanged);
            // 
            // Button10_cbox
            // 
            this.Button10_cbox.BackColor = System.Drawing.Color.Transparent;
            this.Button10_cbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.Button10_cbox.Location = new System.Drawing.Point(95, 399);
            this.Button10_cbox.Name = "Button10_cbox";
            this.Button10_cbox.Size = new System.Drawing.Size(75, 16);
            this.Button10_cbox.TabIndex = 79;
            this.Button10_cbox.Tag = "9";
            this.Button10_cbox.Text = "ボタン10";
            this.Button10_cbox.UseVisualStyleBackColor = false;
            this.Button10_cbox.Visible = false;
            this.Button10_cbox.CheckedChanged += new System.EventHandler(this.Joystick_Button_CheckedChanged);
            // 
            // Button9_cbox
            // 
            this.Button9_cbox.BackColor = System.Drawing.Color.Transparent;
            this.Button9_cbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.Button9_cbox.Location = new System.Drawing.Point(95, 381);
            this.Button9_cbox.Name = "Button9_cbox";
            this.Button9_cbox.Size = new System.Drawing.Size(75, 16);
            this.Button9_cbox.TabIndex = 78;
            this.Button9_cbox.Tag = "8";
            this.Button9_cbox.Text = "ボタン9";
            this.Button9_cbox.UseVisualStyleBackColor = false;
            this.Button9_cbox.Visible = false;
            this.Button9_cbox.CheckedChanged += new System.EventHandler(this.Joystick_Button_CheckedChanged);
            // 
            // Button8_cbox
            // 
            this.Button8_cbox.BackColor = System.Drawing.Color.Transparent;
            this.Button8_cbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.Button8_cbox.Location = new System.Drawing.Point(95, 363);
            this.Button8_cbox.Name = "Button8_cbox";
            this.Button8_cbox.Size = new System.Drawing.Size(75, 16);
            this.Button8_cbox.TabIndex = 77;
            this.Button8_cbox.Tag = "7";
            this.Button8_cbox.Text = "ボタン8";
            this.Button8_cbox.UseVisualStyleBackColor = false;
            this.Button8_cbox.Visible = false;
            this.Button8_cbox.CheckedChanged += new System.EventHandler(this.Joystick_Button_CheckedChanged);
            // 
            // Button7_cbox
            // 
            this.Button7_cbox.BackColor = System.Drawing.Color.Transparent;
            this.Button7_cbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.Button7_cbox.Location = new System.Drawing.Point(95, 345);
            this.Button7_cbox.Name = "Button7_cbox";
            this.Button7_cbox.Size = new System.Drawing.Size(75, 16);
            this.Button7_cbox.TabIndex = 76;
            this.Button7_cbox.Tag = "6";
            this.Button7_cbox.Text = "ボタン7";
            this.Button7_cbox.UseVisualStyleBackColor = false;
            this.Button7_cbox.Visible = false;
            this.Button7_cbox.CheckedChanged += new System.EventHandler(this.Joystick_Button_CheckedChanged);
            // 
            // cmbbx_digital_pin
            // 
            this.cmbbx_digital_pin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbx_digital_pin.Enabled = false;
            this.cmbbx_digital_pin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.cmbbx_digital_pin.FormattingEnabled = true;
            this.cmbbx_digital_pin.Location = new System.Drawing.Point(15, 33);
            this.cmbbx_digital_pin.MaxDropDownItems = 12;
            this.cmbbx_digital_pin.Name = "cmbbx_digital_pin";
            this.cmbbx_digital_pin.Size = new System.Drawing.Size(170, 20);
            this.cmbbx_digital_pin.TabIndex = 12;
            this.cmbbx_digital_pin.SelectedIndexChanged += new System.EventHandler(this.cmbbx_digital_pin_SelectedIndexChanged);
            // 
            // Button6_cbox
            // 
            this.Button6_cbox.BackColor = System.Drawing.Color.Transparent;
            this.Button6_cbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.Button6_cbox.Location = new System.Drawing.Point(95, 327);
            this.Button6_cbox.Name = "Button6_cbox";
            this.Button6_cbox.Size = new System.Drawing.Size(75, 16);
            this.Button6_cbox.TabIndex = 75;
            this.Button6_cbox.Tag = "5";
            this.Button6_cbox.Text = "ボタン6";
            this.Button6_cbox.UseVisualStyleBackColor = false;
            this.Button6_cbox.Visible = false;
            this.Button6_cbox.CheckedChanged += new System.EventHandler(this.Joystick_Button_CheckedChanged);
            // 
            // Button5_cbox
            // 
            this.Button5_cbox.BackColor = System.Drawing.Color.Transparent;
            this.Button5_cbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.Button5_cbox.Location = new System.Drawing.Point(15, 399);
            this.Button5_cbox.Name = "Button5_cbox";
            this.Button5_cbox.Size = new System.Drawing.Size(75, 16);
            this.Button5_cbox.TabIndex = 74;
            this.Button5_cbox.Tag = "4";
            this.Button5_cbox.Text = "ボタン5";
            this.Button5_cbox.UseVisualStyleBackColor = false;
            this.Button5_cbox.Visible = false;
            this.Button5_cbox.CheckedChanged += new System.EventHandler(this.Joystick_Button_CheckedChanged);
            // 
            // Button4_cbox
            // 
            this.Button4_cbox.BackColor = System.Drawing.Color.Transparent;
            this.Button4_cbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.Button4_cbox.Location = new System.Drawing.Point(15, 381);
            this.Button4_cbox.Name = "Button4_cbox";
            this.Button4_cbox.Size = new System.Drawing.Size(75, 16);
            this.Button4_cbox.TabIndex = 73;
            this.Button4_cbox.Tag = "3";
            this.Button4_cbox.Text = "ボタン4";
            this.Button4_cbox.UseVisualStyleBackColor = false;
            this.Button4_cbox.Visible = false;
            this.Button4_cbox.CheckedChanged += new System.EventHandler(this.Joystick_Button_CheckedChanged);
            // 
            // Button3_cbox
            // 
            this.Button3_cbox.BackColor = System.Drawing.Color.Transparent;
            this.Button3_cbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.Button3_cbox.Location = new System.Drawing.Point(15, 363);
            this.Button3_cbox.Name = "Button3_cbox";
            this.Button3_cbox.Size = new System.Drawing.Size(75, 16);
            this.Button3_cbox.TabIndex = 72;
            this.Button3_cbox.Tag = "2";
            this.Button3_cbox.Text = "ボタン3";
            this.Button3_cbox.UseVisualStyleBackColor = false;
            this.Button3_cbox.Visible = false;
            this.Button3_cbox.CheckedChanged += new System.EventHandler(this.Joystick_Button_CheckedChanged);
            // 
            // Button2_cbox
            // 
            this.Button2_cbox.BackColor = System.Drawing.Color.Transparent;
            this.Button2_cbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.Button2_cbox.Location = new System.Drawing.Point(15, 345);
            this.Button2_cbox.Name = "Button2_cbox";
            this.Button2_cbox.Size = new System.Drawing.Size(75, 16);
            this.Button2_cbox.TabIndex = 71;
            this.Button2_cbox.Tag = "1";
            this.Button2_cbox.Text = "ボタン2";
            this.Button2_cbox.UseVisualStyleBackColor = false;
            this.Button2_cbox.Visible = false;
            this.Button2_cbox.CheckedChanged += new System.EventHandler(this.Joystick_Button_CheckedChanged);
            // 
            // Button1_cbox
            // 
            this.Button1_cbox.BackColor = System.Drawing.Color.Transparent;
            this.Button1_cbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.Button1_cbox.Location = new System.Drawing.Point(15, 327);
            this.Button1_cbox.Name = "Button1_cbox";
            this.Button1_cbox.Size = new System.Drawing.Size(75, 16);
            this.Button1_cbox.TabIndex = 70;
            this.Button1_cbox.Tag = "0";
            this.Button1_cbox.Text = "ボタン1";
            this.Button1_cbox.UseVisualStyleBackColor = false;
            this.Button1_cbox.Visible = false;
            this.Button1_cbox.CheckedChanged += new System.EventHandler(this.Joystick_Button_CheckedChanged);
            // 
            // LeverYM_cbox
            // 
            this.LeverYM_cbox.AutoSize = true;
            this.LeverYM_cbox.BackColor = System.Drawing.Color.Transparent;
            this.LeverYM_cbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.LeverYM_cbox.Location = new System.Drawing.Point(125, 153);
            this.LeverYM_cbox.Name = "LeverYM_cbox";
            this.LeverYM_cbox.Size = new System.Drawing.Size(70, 16);
            this.LeverYM_cbox.TabIndex = 44;
            this.LeverYM_cbox.Tag = "3";
            this.LeverYM_cbox.Text = "レバーY -";
            this.LeverYM_cbox.UseVisualStyleBackColor = false;
            this.LeverYM_cbox.Visible = false;
            this.LeverYM_cbox.CheckedChanged += new System.EventHandler(this.Joystick_Lever_CheckedChanged);
            // 
            // LeverYP_cbox
            // 
            this.LeverYP_cbox.AutoSize = true;
            this.LeverYP_cbox.BackColor = System.Drawing.Color.Transparent;
            this.LeverYP_cbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.LeverYP_cbox.Location = new System.Drawing.Point(15, 153);
            this.LeverYP_cbox.Name = "LeverYP_cbox";
            this.LeverYP_cbox.Size = new System.Drawing.Size(70, 16);
            this.LeverYP_cbox.TabIndex = 43;
            this.LeverYP_cbox.Tag = "2";
            this.LeverYP_cbox.Text = "レバーY +";
            this.LeverYP_cbox.UseVisualStyleBackColor = false;
            this.LeverYP_cbox.Visible = false;
            this.LeverYP_cbox.CheckedChanged += new System.EventHandler(this.Joystick_Lever_CheckedChanged);
            // 
            // LeverXM_cbox
            // 
            this.LeverXM_cbox.AutoSize = true;
            this.LeverXM_cbox.BackColor = System.Drawing.Color.Transparent;
            this.LeverXM_cbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.LeverXM_cbox.Location = new System.Drawing.Point(125, 135);
            this.LeverXM_cbox.Name = "LeverXM_cbox";
            this.LeverXM_cbox.Size = new System.Drawing.Size(70, 16);
            this.LeverXM_cbox.TabIndex = 42;
            this.LeverXM_cbox.Tag = "1";
            this.LeverXM_cbox.Text = "レバーX -";
            this.LeverXM_cbox.UseVisualStyleBackColor = false;
            this.LeverXM_cbox.Visible = false;
            this.LeverXM_cbox.CheckedChanged += new System.EventHandler(this.Joystick_Lever_CheckedChanged);
            // 
            // LeverXP_cbox
            // 
            this.LeverXP_cbox.AutoSize = true;
            this.LeverXP_cbox.BackColor = System.Drawing.Color.Transparent;
            this.LeverXP_cbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.LeverXP_cbox.Location = new System.Drawing.Point(15, 135);
            this.LeverXP_cbox.Name = "LeverXP_cbox";
            this.LeverXP_cbox.Size = new System.Drawing.Size(70, 16);
            this.LeverXP_cbox.TabIndex = 41;
            this.LeverXP_cbox.Tag = "0";
            this.LeverXP_cbox.Text = "レバーX +";
            this.LeverXP_cbox.UseVisualStyleBackColor = false;
            this.LeverXP_cbox.Visible = false;
            this.LeverXP_cbox.CheckedChanged += new System.EventHandler(this.Joystick_Lever_CheckedChanged);
            // 
            // Win_cbox
            // 
            this.Win_cbox.AutoSize = true;
            this.Win_cbox.BackColor = System.Drawing.Color.Transparent;
            this.Win_cbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.Win_cbox.Location = new System.Drawing.Point(102, 190);
            this.Win_cbox.Name = "Win_cbox";
            this.Win_cbox.Size = new System.Drawing.Size(42, 16);
            this.Win_cbox.TabIndex = 34;
            this.Win_cbox.Tag = "3";
            this.Win_cbox.Text = "Win";
            this.Win_cbox.UseVisualStyleBackColor = false;
            this.Win_cbox.Visible = false;
            this.Win_cbox.CheckedChanged += new System.EventHandler(this.keyboard_modifier_CheckedChanged);
            // 
            // Shift_cbox
            // 
            this.Shift_cbox.AutoSize = true;
            this.Shift_cbox.BackColor = System.Drawing.Color.Transparent;
            this.Shift_cbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.Shift_cbox.Location = new System.Drawing.Point(102, 150);
            this.Shift_cbox.Name = "Shift_cbox";
            this.Shift_cbox.Size = new System.Drawing.Size(48, 16);
            this.Shift_cbox.TabIndex = 32;
            this.Shift_cbox.Tag = "1";
            this.Shift_cbox.Text = "Shift";
            this.Shift_cbox.UseVisualStyleBackColor = false;
            this.Shift_cbox.Visible = false;
            this.Shift_cbox.CheckedChanged += new System.EventHandler(this.keyboard_modifier_CheckedChanged);
            // 
            // Alt_cbox
            // 
            this.Alt_cbox.AutoSize = true;
            this.Alt_cbox.BackColor = System.Drawing.Color.Transparent;
            this.Alt_cbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.Alt_cbox.Location = new System.Drawing.Point(102, 170);
            this.Alt_cbox.Name = "Alt_cbox";
            this.Alt_cbox.Size = new System.Drawing.Size(39, 16);
            this.Alt_cbox.TabIndex = 33;
            this.Alt_cbox.Tag = "2";
            this.Alt_cbox.Text = "Alt";
            this.Alt_cbox.UseVisualStyleBackColor = false;
            this.Alt_cbox.Visible = false;
            this.Alt_cbox.CheckedChanged += new System.EventHandler(this.keyboard_modifier_CheckedChanged);
            // 
            // Ctrl_cbox
            // 
            this.Ctrl_cbox.AutoSize = true;
            this.Ctrl_cbox.BackColor = System.Drawing.Color.Transparent;
            this.Ctrl_cbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.Ctrl_cbox.Location = new System.Drawing.Point(102, 130);
            this.Ctrl_cbox.Name = "Ctrl_cbox";
            this.Ctrl_cbox.Size = new System.Drawing.Size(43, 16);
            this.Ctrl_cbox.TabIndex = 31;
            this.Ctrl_cbox.Tag = "0";
            this.Ctrl_cbox.Text = "Ctrl";
            this.Ctrl_cbox.UseVisualStyleBackColor = false;
            this.Ctrl_cbox.Visible = false;
            this.Ctrl_cbox.CheckedChanged += new System.EventHandler(this.keyboard_modifier_CheckedChanged);
            // 
            // cmbbx_digital_assign
            // 
            this.cmbbx_digital_assign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbx_digital_assign.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.cmbbx_digital_assign.FormattingEnabled = true;
            this.cmbbx_digital_assign.Location = new System.Drawing.Point(15, 123);
            this.cmbbx_digital_assign.Name = "cmbbx_digital_assign";
            this.cmbbx_digital_assign.Size = new System.Drawing.Size(170, 20);
            this.cmbbx_digital_assign.TabIndex = 16;
            this.cmbbx_digital_assign.Visible = false;
            this.cmbbx_digital_assign.SelectedIndexChanged += new System.EventHandler(this.cmbbx_digital_assign_SelectedIndexChanged);
            // 
            // cmbbx_digital_device_type
            // 
            this.cmbbx_digital_device_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbx_digital_device_type.Enabled = false;
            this.cmbbx_digital_device_type.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.cmbbx_digital_device_type.FormattingEnabled = true;
            this.cmbbx_digital_device_type.Location = new System.Drawing.Point(15, 78);
            this.cmbbx_digital_device_type.Name = "cmbbx_digital_device_type";
            this.cmbbx_digital_device_type.Size = new System.Drawing.Size(170, 20);
            this.cmbbx_digital_device_type.TabIndex = 14;
            this.cmbbx_digital_device_type.SelectedIndexChanged += new System.EventHandler(this.cmbbx_digital_device_type_SelectedIndexChanged);
            // 
            // devicetype_lbl4
            // 
            this.devicetype_lbl4.AutoSize = true;
            this.devicetype_lbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(221)))), ((int)(((byte)(223)))));
            this.devicetype_lbl4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.devicetype_lbl4.Location = new System.Drawing.Point(1049, 289);
            this.devicetype_lbl4.Name = "devicetype_lbl4";
            this.devicetype_lbl4.Size = new System.Drawing.Size(33, 12);
            this.devicetype_lbl4.TabIndex = 99;
            this.devicetype_lbl4.Tag = "3";
            this.devicetype_lbl4.Text = "04Pin";
            // 
            // devicetype_lbl1
            // 
            this.devicetype_lbl1.AutoSize = true;
            this.devicetype_lbl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(221)))), ((int)(((byte)(223)))));
            this.devicetype_lbl1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.devicetype_lbl1.Location = new System.Drawing.Point(1049, 154);
            this.devicetype_lbl1.Name = "devicetype_lbl1";
            this.devicetype_lbl1.Size = new System.Drawing.Size(33, 12);
            this.devicetype_lbl1.TabIndex = 100;
            this.devicetype_lbl1.Tag = "0";
            this.devicetype_lbl1.Text = "01Pin";
            // 
            // devicetype_lbl3
            // 
            this.devicetype_lbl3.AutoSize = true;
            this.devicetype_lbl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(221)))), ((int)(((byte)(223)))));
            this.devicetype_lbl3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.devicetype_lbl3.Location = new System.Drawing.Point(1048, 237);
            this.devicetype_lbl3.Name = "devicetype_lbl3";
            this.devicetype_lbl3.Size = new System.Drawing.Size(33, 12);
            this.devicetype_lbl3.TabIndex = 101;
            this.devicetype_lbl3.Tag = "2";
            this.devicetype_lbl3.Text = "03Pin";
            // 
            // devicetype_lbl2
            // 
            this.devicetype_lbl2.AutoSize = true;
            this.devicetype_lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(221)))), ((int)(((byte)(223)))));
            this.devicetype_lbl2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.devicetype_lbl2.Location = new System.Drawing.Point(1049, 185);
            this.devicetype_lbl2.Name = "devicetype_lbl2";
            this.devicetype_lbl2.Size = new System.Drawing.Size(33, 12);
            this.devicetype_lbl2.TabIndex = 102;
            this.devicetype_lbl2.Tag = "1";
            this.devicetype_lbl2.Text = "02Pin";
            // 
            // devicetype_lbl9
            // 
            this.devicetype_lbl9.AutoSize = true;
            this.devicetype_lbl9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(221)))), ((int)(((byte)(223)))));
            this.devicetype_lbl9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.devicetype_lbl9.Location = new System.Drawing.Point(1284, 289);
            this.devicetype_lbl9.Name = "devicetype_lbl9";
            this.devicetype_lbl9.Size = new System.Drawing.Size(33, 12);
            this.devicetype_lbl9.TabIndex = 103;
            this.devicetype_lbl9.Tag = "8";
            this.devicetype_lbl9.Text = "09Pin";
            // 
            // devicetype_lbl8
            // 
            this.devicetype_lbl8.AutoSize = true;
            this.devicetype_lbl8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(221)))), ((int)(((byte)(223)))));
            this.devicetype_lbl8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.devicetype_lbl8.Location = new System.Drawing.Point(1284, 341);
            this.devicetype_lbl8.Name = "devicetype_lbl8";
            this.devicetype_lbl8.Size = new System.Drawing.Size(33, 12);
            this.devicetype_lbl8.TabIndex = 104;
            this.devicetype_lbl8.Tag = "7";
            this.devicetype_lbl8.Text = "08Pin";
            // 
            // devicetype_lbl7
            // 
            this.devicetype_lbl7.AutoSize = true;
            this.devicetype_lbl7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(221)))), ((int)(((byte)(223)))));
            this.devicetype_lbl7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.devicetype_lbl7.Location = new System.Drawing.Point(1284, 393);
            this.devicetype_lbl7.Name = "devicetype_lbl7";
            this.devicetype_lbl7.Size = new System.Drawing.Size(33, 12);
            this.devicetype_lbl7.TabIndex = 105;
            this.devicetype_lbl7.Tag = "6";
            this.devicetype_lbl7.Text = "07Pin";
            // 
            // DeviceAssign_lbl4
            // 
            this.DeviceAssign_lbl4.AutoSize = true;
            this.DeviceAssign_lbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(221)))), ((int)(((byte)(223)))));
            this.DeviceAssign_lbl4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.DeviceAssign_lbl4.Location = new System.Drawing.Point(1049, 301);
            this.DeviceAssign_lbl4.Name = "DeviceAssign_lbl4";
            this.DeviceAssign_lbl4.Size = new System.Drawing.Size(40, 12);
            this.DeviceAssign_lbl4.TabIndex = 106;
            this.DeviceAssign_lbl4.Tag = "3";
            this.DeviceAssign_lbl4.Text = "Assign";
            this.DeviceAssign_lbl4.MouseEnter += new System.EventHandler(this.lbl_sw_assign_MouseEnter);
            // 
            // DeviceAssign_lbl1
            // 
            this.DeviceAssign_lbl1.AutoSize = true;
            this.DeviceAssign_lbl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(221)))), ((int)(((byte)(223)))));
            this.DeviceAssign_lbl1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.DeviceAssign_lbl1.Location = new System.Drawing.Point(1049, 166);
            this.DeviceAssign_lbl1.Name = "DeviceAssign_lbl1";
            this.DeviceAssign_lbl1.Size = new System.Drawing.Size(40, 12);
            this.DeviceAssign_lbl1.TabIndex = 107;
            this.DeviceAssign_lbl1.Tag = "0";
            this.DeviceAssign_lbl1.Text = "Assign";
            this.DeviceAssign_lbl1.MouseEnter += new System.EventHandler(this.lbl_sw_assign_MouseEnter);
            // 
            // DeviceAssign_lbl3
            // 
            this.DeviceAssign_lbl3.AutoSize = true;
            this.DeviceAssign_lbl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(221)))), ((int)(((byte)(223)))));
            this.DeviceAssign_lbl3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.DeviceAssign_lbl3.Location = new System.Drawing.Point(1048, 249);
            this.DeviceAssign_lbl3.Name = "DeviceAssign_lbl3";
            this.DeviceAssign_lbl3.Size = new System.Drawing.Size(40, 12);
            this.DeviceAssign_lbl3.TabIndex = 108;
            this.DeviceAssign_lbl3.Tag = "2";
            this.DeviceAssign_lbl3.Text = "Assign";
            this.DeviceAssign_lbl3.MouseEnter += new System.EventHandler(this.lbl_sw_assign_MouseEnter);
            // 
            // DeviceAssign_lbl2
            // 
            this.DeviceAssign_lbl2.AutoSize = true;
            this.DeviceAssign_lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(221)))), ((int)(((byte)(223)))));
            this.DeviceAssign_lbl2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.DeviceAssign_lbl2.Location = new System.Drawing.Point(1048, 197);
            this.DeviceAssign_lbl2.Name = "DeviceAssign_lbl2";
            this.DeviceAssign_lbl2.Size = new System.Drawing.Size(40, 12);
            this.DeviceAssign_lbl2.TabIndex = 109;
            this.DeviceAssign_lbl2.Tag = "1";
            this.DeviceAssign_lbl2.Text = "Assign";
            this.DeviceAssign_lbl2.MouseEnter += new System.EventHandler(this.lbl_sw_assign_MouseEnter);
            // 
            // DeviceAssign_lbl9
            // 
            this.DeviceAssign_lbl9.AutoSize = true;
            this.DeviceAssign_lbl9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(221)))), ((int)(((byte)(223)))));
            this.DeviceAssign_lbl9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.DeviceAssign_lbl9.Location = new System.Drawing.Point(1284, 301);
            this.DeviceAssign_lbl9.Name = "DeviceAssign_lbl9";
            this.DeviceAssign_lbl9.Size = new System.Drawing.Size(40, 12);
            this.DeviceAssign_lbl9.TabIndex = 110;
            this.DeviceAssign_lbl9.Tag = "8";
            this.DeviceAssign_lbl9.Text = "Assign";
            this.DeviceAssign_lbl9.MouseEnter += new System.EventHandler(this.lbl_sw_assign_MouseEnter);
            // 
            // DeviceAssign_lbl8
            // 
            this.DeviceAssign_lbl8.AutoSize = true;
            this.DeviceAssign_lbl8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(221)))), ((int)(((byte)(223)))));
            this.DeviceAssign_lbl8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.DeviceAssign_lbl8.Location = new System.Drawing.Point(1284, 353);
            this.DeviceAssign_lbl8.Name = "DeviceAssign_lbl8";
            this.DeviceAssign_lbl8.Size = new System.Drawing.Size(40, 12);
            this.DeviceAssign_lbl8.TabIndex = 111;
            this.DeviceAssign_lbl8.Tag = "7";
            this.DeviceAssign_lbl8.Text = "Assign";
            this.DeviceAssign_lbl8.MouseEnter += new System.EventHandler(this.lbl_sw_assign_MouseEnter);
            // 
            // DeviceAssign_lbl7
            // 
            this.DeviceAssign_lbl7.AutoSize = true;
            this.DeviceAssign_lbl7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(221)))), ((int)(((byte)(223)))));
            this.DeviceAssign_lbl7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.DeviceAssign_lbl7.Location = new System.Drawing.Point(1284, 405);
            this.DeviceAssign_lbl7.Name = "DeviceAssign_lbl7";
            this.DeviceAssign_lbl7.Size = new System.Drawing.Size(40, 12);
            this.DeviceAssign_lbl7.TabIndex = 112;
            this.DeviceAssign_lbl7.Tag = "6";
            this.DeviceAssign_lbl7.Text = "Assign";
            this.DeviceAssign_lbl7.MouseEnter += new System.EventHandler(this.lbl_sw_assign_MouseEnter);
            // 
            // StatusBox_lbl
            // 
            this.StatusBox_lbl.AutoSize = true;
            this.StatusBox_lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(214)))), ((int)(((byte)(214)))));
            this.StatusBox_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.StatusBox_lbl.Location = new System.Drawing.Point(876, 587);
            this.StatusBox_lbl.Name = "StatusBox_lbl";
            this.StatusBox_lbl.Size = new System.Drawing.Size(79, 12);
            this.StatusBox_lbl.TabIndex = 117;
            this.StatusBox_lbl.Text = "デバイス未接続";
            // 
            // StatusBox_lbl2
            // 
            this.StatusBox_lbl2.AutoSize = true;
            this.StatusBox_lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(214)))), ((int)(((byte)(214)))));
            this.StatusBox_lbl2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.StatusBox_lbl2.Location = new System.Drawing.Point(18, 587);
            this.StatusBox_lbl2.Name = "StatusBox_lbl2";
            this.StatusBox_lbl2.Size = new System.Drawing.Size(292, 12);
            this.StatusBox_lbl2.TabIndex = 118;
            this.StatusBox_lbl2.Text = "REVIVE USB ADVANCE, Configuration Tool起動しました";
            // 
            // devicetype_lbl5
            // 
            this.devicetype_lbl5.AutoSize = true;
            this.devicetype_lbl5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(221)))), ((int)(((byte)(223)))));
            this.devicetype_lbl5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.devicetype_lbl5.Location = new System.Drawing.Point(1049, 341);
            this.devicetype_lbl5.Name = "devicetype_lbl5";
            this.devicetype_lbl5.Size = new System.Drawing.Size(33, 12);
            this.devicetype_lbl5.TabIndex = 153;
            this.devicetype_lbl5.Tag = "4";
            this.devicetype_lbl5.Text = "05Pin";
            // 
            // devicetype_lbl6
            // 
            this.devicetype_lbl6.AutoSize = true;
            this.devicetype_lbl6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(221)))), ((int)(((byte)(223)))));
            this.devicetype_lbl6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.devicetype_lbl6.Location = new System.Drawing.Point(1049, 393);
            this.devicetype_lbl6.Name = "devicetype_lbl6";
            this.devicetype_lbl6.Size = new System.Drawing.Size(33, 12);
            this.devicetype_lbl6.TabIndex = 154;
            this.devicetype_lbl6.Tag = "5";
            this.devicetype_lbl6.Text = "06Pin";
            // 
            // DeviceAssign_lbl5
            // 
            this.DeviceAssign_lbl5.AutoSize = true;
            this.DeviceAssign_lbl5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(221)))), ((int)(((byte)(223)))));
            this.DeviceAssign_lbl5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.DeviceAssign_lbl5.Location = new System.Drawing.Point(1049, 353);
            this.DeviceAssign_lbl5.Name = "DeviceAssign_lbl5";
            this.DeviceAssign_lbl5.Size = new System.Drawing.Size(40, 12);
            this.DeviceAssign_lbl5.TabIndex = 155;
            this.DeviceAssign_lbl5.Tag = "4";
            this.DeviceAssign_lbl5.Text = "Assign";
            this.DeviceAssign_lbl5.MouseEnter += new System.EventHandler(this.lbl_sw_assign_MouseEnter);
            // 
            // DeviceAssign_lbl6
            // 
            this.DeviceAssign_lbl6.AutoSize = true;
            this.DeviceAssign_lbl6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(221)))), ((int)(((byte)(223)))));
            this.DeviceAssign_lbl6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.DeviceAssign_lbl6.Location = new System.Drawing.Point(1049, 405);
            this.DeviceAssign_lbl6.Name = "DeviceAssign_lbl6";
            this.DeviceAssign_lbl6.Size = new System.Drawing.Size(40, 12);
            this.DeviceAssign_lbl6.TabIndex = 156;
            this.DeviceAssign_lbl6.Tag = "5";
            this.DeviceAssign_lbl6.Text = "Assign";
            this.DeviceAssign_lbl6.MouseEnter += new System.EventHandler(this.lbl_sw_assign_MouseEnter);
            // 
            // devicetype_lbl10
            // 
            this.devicetype_lbl10.AutoSize = true;
            this.devicetype_lbl10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(221)))), ((int)(((byte)(223)))));
            this.devicetype_lbl10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.devicetype_lbl10.Location = new System.Drawing.Point(1284, 237);
            this.devicetype_lbl10.Name = "devicetype_lbl10";
            this.devicetype_lbl10.Size = new System.Drawing.Size(33, 12);
            this.devicetype_lbl10.TabIndex = 157;
            this.devicetype_lbl10.Tag = "9";
            this.devicetype_lbl10.Text = "10Pin";
            // 
            // devicetype_lbl11
            // 
            this.devicetype_lbl11.AutoSize = true;
            this.devicetype_lbl11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(221)))), ((int)(((byte)(223)))));
            this.devicetype_lbl11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.devicetype_lbl11.Location = new System.Drawing.Point(1284, 185);
            this.devicetype_lbl11.Name = "devicetype_lbl11";
            this.devicetype_lbl11.Size = new System.Drawing.Size(33, 12);
            this.devicetype_lbl11.TabIndex = 158;
            this.devicetype_lbl11.Tag = "10";
            this.devicetype_lbl11.Text = "11Pin";
            // 
            // devicetype_lbl12
            // 
            this.devicetype_lbl12.AutoSize = true;
            this.devicetype_lbl12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(221)))), ((int)(((byte)(223)))));
            this.devicetype_lbl12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.devicetype_lbl12.Location = new System.Drawing.Point(1284, 132);
            this.devicetype_lbl12.Name = "devicetype_lbl12";
            this.devicetype_lbl12.Size = new System.Drawing.Size(33, 12);
            this.devicetype_lbl12.TabIndex = 159;
            this.devicetype_lbl12.Tag = "11";
            this.devicetype_lbl12.Text = "12Pin";
            // 
            // DeviceAssign_lbl10
            // 
            this.DeviceAssign_lbl10.AutoSize = true;
            this.DeviceAssign_lbl10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(221)))), ((int)(((byte)(223)))));
            this.DeviceAssign_lbl10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.DeviceAssign_lbl10.Location = new System.Drawing.Point(1284, 249);
            this.DeviceAssign_lbl10.Name = "DeviceAssign_lbl10";
            this.DeviceAssign_lbl10.Size = new System.Drawing.Size(40, 12);
            this.DeviceAssign_lbl10.TabIndex = 160;
            this.DeviceAssign_lbl10.Tag = "9";
            this.DeviceAssign_lbl10.Text = "Assign";
            this.DeviceAssign_lbl10.MouseEnter += new System.EventHandler(this.lbl_sw_assign_MouseEnter);
            // 
            // DeviceAssign_lbl11
            // 
            this.DeviceAssign_lbl11.AutoSize = true;
            this.DeviceAssign_lbl11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(221)))), ((int)(((byte)(223)))));
            this.DeviceAssign_lbl11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.DeviceAssign_lbl11.Location = new System.Drawing.Point(1284, 197);
            this.DeviceAssign_lbl11.Name = "DeviceAssign_lbl11";
            this.DeviceAssign_lbl11.Size = new System.Drawing.Size(40, 12);
            this.DeviceAssign_lbl11.TabIndex = 161;
            this.DeviceAssign_lbl11.Tag = "10";
            this.DeviceAssign_lbl11.Text = "Assign";
            this.DeviceAssign_lbl11.MouseEnter += new System.EventHandler(this.lbl_sw_assign_MouseEnter);
            // 
            // DeviceAssign_lbl12
            // 
            this.DeviceAssign_lbl12.AutoSize = true;
            this.DeviceAssign_lbl12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(221)))), ((int)(((byte)(223)))));
            this.DeviceAssign_lbl12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.DeviceAssign_lbl12.Location = new System.Drawing.Point(1284, 144);
            this.DeviceAssign_lbl12.Name = "DeviceAssign_lbl12";
            this.DeviceAssign_lbl12.Size = new System.Drawing.Size(40, 12);
            this.DeviceAssign_lbl12.TabIndex = 162;
            this.DeviceAssign_lbl12.Tag = "11";
            this.DeviceAssign_lbl12.Text = "Assign";
            this.DeviceAssign_lbl12.MouseEnter += new System.EventHandler(this.lbl_sw_assign_MouseEnter);
            // 
            // chkbx_analog_calibration
            // 
            this.chkbx_analog_calibration.AutoSize = true;
            this.chkbx_analog_calibration.Location = new System.Drawing.Point(25, 157);
            this.chkbx_analog_calibration.Name = "chkbx_analog_calibration";
            this.chkbx_analog_calibration.Size = new System.Drawing.Size(102, 16);
            this.chkbx_analog_calibration.TabIndex = 241;
            this.chkbx_analog_calibration.Text = "キャリブレーション";
            this.chkbx_analog_calibration.UseVisualStyleBackColor = true;
            this.chkbx_analog_calibration.CheckedChanged += new System.EventHandler(this.chkbx_analog_calibration_CheckedChanged);
            // 
            // lbl_output_val
            // 
            this.lbl_output_val.Location = new System.Drawing.Point(120, 113);
            this.lbl_output_val.Name = "lbl_output_val";
            this.lbl_output_val.Size = new System.Drawing.Size(100, 14);
            this.lbl_output_val.TabIndex = 211;
            this.lbl_output_val.Text = "出力値";
            this.lbl_output_val.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // num_analog_sensitivity
            // 
            this.num_analog_sensitivity.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.num_analog_sensitivity.Location = new System.Drawing.Point(125, 120);
            this.num_analog_sensitivity.Name = "num_analog_sensitivity";
            this.num_analog_sensitivity.Size = new System.Drawing.Size(75, 23);
            this.num_analog_sensitivity.TabIndex = 206;
            this.num_analog_sensitivity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.num_analog_sensitivity.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // gbx_analog_calibration
            // 
            this.gbx_analog_calibration.Controls.Add(this.label1);
            this.gbx_analog_calibration.Controls.Add(this.num_analog_dead_zone);
            this.gbx_analog_calibration.Controls.Add(this.chkbx_center_calibration);
            this.gbx_analog_calibration.Location = new System.Drawing.Point(17, 165);
            this.gbx_analog_calibration.Name = "gbx_analog_calibration";
            this.gbx_analog_calibration.Size = new System.Drawing.Size(215, 100);
            this.gbx_analog_calibration.TabIndex = 240;
            this.gbx_analog_calibration.TabStop = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(18, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 21);
            this.label1.TabIndex = 243;
            this.label1.Text = "不感帯±[V]";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // num_analog_dead_zone
            // 
            this.num_analog_dead_zone.DecimalPlaces = 2;
            this.num_analog_dead_zone.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.num_analog_dead_zone.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.num_analog_dead_zone.Location = new System.Drawing.Point(88, 70);
            this.num_analog_dead_zone.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.num_analog_dead_zone.Name = "num_analog_dead_zone";
            this.num_analog_dead_zone.Size = new System.Drawing.Size(80, 23);
            this.num_analog_dead_zone.TabIndex = 244;
            this.num_analog_dead_zone.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.num_analog_dead_zone.Value = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            // 
            // chkbx_center_calibration
            // 
            this.chkbx_center_calibration.AutoSize = true;
            this.chkbx_center_calibration.Checked = true;
            this.chkbx_center_calibration.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbx_center_calibration.Location = new System.Drawing.Point(15, 20);
            this.chkbx_center_calibration.Name = "chkbx_center_calibration";
            this.chkbx_center_calibration.Size = new System.Drawing.Size(96, 16);
            this.chkbx_center_calibration.TabIndex = 242;
            this.chkbx_center_calibration.Text = "中立位置調整";
            this.chkbx_center_calibration.UseVisualStyleBackColor = true;
            // 
            // lbl_analog_sensitivity
            // 
            this.lbl_analog_sensitivity.Location = new System.Drawing.Point(15, 100);
            this.lbl_analog_sensitivity.Name = "lbl_analog_sensitivity";
            this.lbl_analog_sensitivity.Size = new System.Drawing.Size(180, 14);
            this.lbl_analog_sensitivity.TabIndex = 205;
            this.lbl_analog_sensitivity.Text = "感度[低 1 <---> 100 高]";
            // 
            // pic_analog_arrow5
            // 
            this.pic_analog_arrow5.BackColor = System.Drawing.Color.Transparent;
            this.pic_analog_arrow5.Image = global::Revive_USB_Advance_CT.Properties.Resources.A_arrow;
            this.pic_analog_arrow5.Location = new System.Drawing.Point(106, 257);
            this.pic_analog_arrow5.Name = "pic_analog_arrow5";
            this.pic_analog_arrow5.Size = new System.Drawing.Size(12, 9);
            this.pic_analog_arrow5.TabIndex = 254;
            this.pic_analog_arrow5.TabStop = false;
            // 
            // pic_analog_arrow4
            // 
            this.pic_analog_arrow4.BackColor = System.Drawing.Color.Transparent;
            this.pic_analog_arrow4.Image = global::Revive_USB_Advance_CT.Properties.Resources.A_arrow;
            this.pic_analog_arrow4.Location = new System.Drawing.Point(106, 232);
            this.pic_analog_arrow4.Name = "pic_analog_arrow4";
            this.pic_analog_arrow4.Size = new System.Drawing.Size(12, 9);
            this.pic_analog_arrow4.TabIndex = 253;
            this.pic_analog_arrow4.TabStop = false;
            // 
            // pic_analog_arrow3
            // 
            this.pic_analog_arrow3.BackColor = System.Drawing.Color.Transparent;
            this.pic_analog_arrow3.Image = global::Revive_USB_Advance_CT.Properties.Resources.A_arrow;
            this.pic_analog_arrow3.Location = new System.Drawing.Point(106, 197);
            this.pic_analog_arrow3.Name = "pic_analog_arrow3";
            this.pic_analog_arrow3.Size = new System.Drawing.Size(12, 9);
            this.pic_analog_arrow3.TabIndex = 252;
            this.pic_analog_arrow3.TabStop = false;
            // 
            // pic_analog_arrow2
            // 
            this.pic_analog_arrow2.BackColor = System.Drawing.Color.Transparent;
            this.pic_analog_arrow2.Image = global::Revive_USB_Advance_CT.Properties.Resources.A_arrow;
            this.pic_analog_arrow2.Location = new System.Drawing.Point(106, 162);
            this.pic_analog_arrow2.Name = "pic_analog_arrow2";
            this.pic_analog_arrow2.Size = new System.Drawing.Size(12, 9);
            this.pic_analog_arrow2.TabIndex = 251;
            this.pic_analog_arrow2.TabStop = false;
            // 
            // pic_analog_arrow1
            // 
            this.pic_analog_arrow1.BackColor = System.Drawing.Color.Transparent;
            this.pic_analog_arrow1.Image = global::Revive_USB_Advance_CT.Properties.Resources.A_arrow;
            this.pic_analog_arrow1.Location = new System.Drawing.Point(106, 137);
            this.pic_analog_arrow1.Name = "pic_analog_arrow1";
            this.pic_analog_arrow1.Size = new System.Drawing.Size(12, 9);
            this.pic_analog_arrow1.TabIndex = 201;
            this.pic_analog_arrow1.TabStop = false;
            // 
            // lbl_analog_set_type
            // 
            this.lbl_analog_set_type.Location = new System.Drawing.Point(15, 54);
            this.lbl_analog_set_type.Name = "lbl_analog_set_type";
            this.lbl_analog_set_type.Size = new System.Drawing.Size(100, 16);
            this.lbl_analog_set_type.TabIndex = 203;
            this.lbl_analog_set_type.Text = "設定";
            this.lbl_analog_set_type.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lbl_analog_pin_no
            // 
            this.lbl_analog_pin_no.Location = new System.Drawing.Point(15, 15);
            this.lbl_analog_pin_no.Name = "lbl_analog_pin_no";
            this.lbl_analog_pin_no.Size = new System.Drawing.Size(100, 16);
            this.lbl_analog_pin_no.TabIndex = 201;
            this.lbl_analog_pin_no.Text = "ピン番号";
            this.lbl_analog_pin_no.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // btn_analog_set
            // 
            this.btn_analog_set.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_analog_set.BackgroundImage")));
            this.btn_analog_set.Location = new System.Drawing.Point(65, 435);
            this.btn_analog_set.Name = "btn_analog_set";
            this.btn_analog_set.Size = new System.Drawing.Size(121, 29);
            this.btn_analog_set.TabIndex = 250;
            this.btn_analog_set.UseVisualStyleBackColor = true;
            this.btn_analog_set.Click += new System.EventHandler(this.btn_analog_set_Click);
            // 
            // lbl_input_vol5
            // 
            this.lbl_input_vol5.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_input_vol5.Location = new System.Drawing.Point(22, 250);
            this.lbl_input_vol5.Name = "lbl_input_vol5";
            this.lbl_input_vol5.Size = new System.Drawing.Size(77, 21);
            this.lbl_input_vol5.TabIndex = 220;
            this.lbl_input_vol5.Tag = "5";
            this.lbl_input_vol5.Text = "3.3V";
            this.lbl_input_vol5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // num_output_val5
            // 
            this.num_output_val5.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.num_output_val5.Location = new System.Drawing.Point(125, 250);
            this.num_output_val5.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.num_output_val5.Name = "num_output_val5";
            this.num_output_val5.Size = new System.Drawing.Size(75, 23);
            this.num_output_val5.TabIndex = 221;
            this.num_output_val5.Tag = "5";
            this.num_output_val5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.num_output_val5.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.num_output_val5.ValueChanged += new System.EventHandler(this.num_output_val_ValueChanged);
            // 
            // num_output_val4
            // 
            this.num_output_val4.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.num_output_val4.Location = new System.Drawing.Point(125, 225);
            this.num_output_val4.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.num_output_val4.Name = "num_output_val4";
            this.num_output_val4.Size = new System.Drawing.Size(75, 23);
            this.num_output_val4.TabIndex = 219;
            this.num_output_val4.Tag = "4";
            this.num_output_val4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.num_output_val4.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.num_output_val4.ValueChanged += new System.EventHandler(this.num_output_val_ValueChanged);
            // 
            // num_input_vol4
            // 
            this.num_input_vol4.DecimalPlaces = 2;
            this.num_input_vol4.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.num_input_vol4.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.num_input_vol4.Location = new System.Drawing.Point(25, 225);
            this.num_input_vol4.Maximum = new decimal(new int[] {
            33,
            0,
            0,
            65536});
            this.num_input_vol4.Name = "num_input_vol4";
            this.num_input_vol4.Size = new System.Drawing.Size(75, 23);
            this.num_input_vol4.TabIndex = 218;
            this.num_input_vol4.Tag = "4";
            this.num_input_vol4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.num_input_vol4.Value = new decimal(new int[] {
            325,
            0,
            0,
            131072});
            this.num_input_vol4.ValueChanged += new System.EventHandler(this.num_input_vol_ValueChanged);
            // 
            // num_output_val3
            // 
            this.num_output_val3.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.num_output_val3.Location = new System.Drawing.Point(125, 190);
            this.num_output_val3.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.num_output_val3.Name = "num_output_val3";
            this.num_output_val3.Size = new System.Drawing.Size(75, 23);
            this.num_output_val3.TabIndex = 217;
            this.num_output_val3.Tag = "3";
            this.num_output_val3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.num_output_val3.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.num_output_val3.ValueChanged += new System.EventHandler(this.num_output_val_ValueChanged);
            // 
            // num_input_vol3
            // 
            this.num_input_vol3.DecimalPlaces = 2;
            this.num_input_vol3.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.num_input_vol3.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.num_input_vol3.Location = new System.Drawing.Point(25, 190);
            this.num_input_vol3.Maximum = new decimal(new int[] {
            33,
            0,
            0,
            65536});
            this.num_input_vol3.Name = "num_input_vol3";
            this.num_input_vol3.Size = new System.Drawing.Size(75, 23);
            this.num_input_vol3.TabIndex = 216;
            this.num_input_vol3.Tag = "3";
            this.num_input_vol3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.num_input_vol3.Value = new decimal(new int[] {
            165,
            0,
            0,
            131072});
            this.num_input_vol3.ValueChanged += new System.EventHandler(this.num_input_vol_ValueChanged);
            // 
            // num_output_val2
            // 
            this.num_output_val2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.num_output_val2.Location = new System.Drawing.Point(125, 155);
            this.num_output_val2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.num_output_val2.Name = "num_output_val2";
            this.num_output_val2.Size = new System.Drawing.Size(75, 23);
            this.num_output_val2.TabIndex = 215;
            this.num_output_val2.Tag = "2";
            this.num_output_val2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.num_output_val2.ValueChanged += new System.EventHandler(this.num_output_val_ValueChanged);
            // 
            // num_output_val1
            // 
            this.num_output_val1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.num_output_val1.Location = new System.Drawing.Point(125, 130);
            this.num_output_val1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.num_output_val1.Name = "num_output_val1";
            this.num_output_val1.Size = new System.Drawing.Size(75, 23);
            this.num_output_val1.TabIndex = 213;
            this.num_output_val1.Tag = "1";
            this.num_output_val1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.num_output_val1.ValueChanged += new System.EventHandler(this.num_output_val_ValueChanged);
            // 
            // lbl_input_vol1
            // 
            this.lbl_input_vol1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_input_vol1.Location = new System.Drawing.Point(22, 130);
            this.lbl_input_vol1.Name = "lbl_input_vol1";
            this.lbl_input_vol1.Size = new System.Drawing.Size(77, 21);
            this.lbl_input_vol1.TabIndex = 212;
            this.lbl_input_vol1.Tag = "1";
            this.lbl_input_vol1.Text = "0V";
            this.lbl_input_vol1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_input_voltage
            // 
            this.lbl_input_voltage.Location = new System.Drawing.Point(15, 113);
            this.lbl_input_voltage.Name = "lbl_input_voltage";
            this.lbl_input_voltage.Size = new System.Drawing.Size(100, 14);
            this.lbl_input_voltage.TabIndex = 210;
            this.lbl_input_voltage.Text = "入力電圧[V]";
            this.lbl_input_voltage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(10, 280);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(230, 130);
            this.chart1.TabIndex = 230;
            this.chart1.Text = "chart1";
            // 
            // cmbbx_analog_set_type
            // 
            this.cmbbx_analog_set_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbx_analog_set_type.FormattingEnabled = true;
            this.cmbbx_analog_set_type.Location = new System.Drawing.Point(15, 72);
            this.cmbbx_analog_set_type.Name = "cmbbx_analog_set_type";
            this.cmbbx_analog_set_type.Size = new System.Drawing.Size(170, 20);
            this.cmbbx_analog_set_type.TabIndex = 204;
            this.cmbbx_analog_set_type.SelectedIndexChanged += new System.EventHandler(this.cmbbx_analog_set_type_SelectedIndexChanged);
            // 
            // cmbbx_analog_pin
            // 
            this.cmbbx_analog_pin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbx_analog_pin.FormattingEnabled = true;
            this.cmbbx_analog_pin.Location = new System.Drawing.Point(15, 33);
            this.cmbbx_analog_pin.Name = "cmbbx_analog_pin";
            this.cmbbx_analog_pin.Size = new System.Drawing.Size(170, 20);
            this.cmbbx_analog_pin.TabIndex = 202;
            this.cmbbx_analog_pin.SelectedIndexChanged += new System.EventHandler(this.cmbbx_analog_pin_SelectedIndexChanged);
            // 
            // num_input_vol2
            // 
            this.num_input_vol2.DecimalPlaces = 2;
            this.num_input_vol2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.num_input_vol2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.num_input_vol2.Location = new System.Drawing.Point(25, 155);
            this.num_input_vol2.Maximum = new decimal(new int[] {
            33,
            0,
            0,
            65536});
            this.num_input_vol2.Name = "num_input_vol2";
            this.num_input_vol2.Size = new System.Drawing.Size(75, 23);
            this.num_input_vol2.TabIndex = 214;
            this.num_input_vol2.Tag = "2";
            this.num_input_vol2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.num_input_vol2.Value = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.num_input_vol2.ValueChanged += new System.EventHandler(this.num_input_vol_ValueChanged);
            // 
            // Button13_cbox
            // 
            this.Button13_cbox.BackColor = System.Drawing.Color.Transparent;
            this.Button13_cbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.Button13_cbox.Location = new System.Drawing.Point(175, 363);
            this.Button13_cbox.Name = "Button13_cbox";
            this.Button13_cbox.Size = new System.Drawing.Size(75, 16);
            this.Button13_cbox.TabIndex = 82;
            this.Button13_cbox.Tag = "12";
            this.Button13_cbox.Text = "ボタン13";
            this.Button13_cbox.UseVisualStyleBackColor = false;
            this.Button13_cbox.Visible = false;
            this.Button13_cbox.CheckedChanged += new System.EventHandler(this.Joystick_Button_CheckedChanged);
            // 
            // Button14_cbox
            // 
            this.Button14_cbox.BackColor = System.Drawing.Color.Transparent;
            this.Button14_cbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.Button14_cbox.Location = new System.Drawing.Point(175, 381);
            this.Button14_cbox.Name = "Button14_cbox";
            this.Button14_cbox.Size = new System.Drawing.Size(75, 16);
            this.Button14_cbox.TabIndex = 83;
            this.Button14_cbox.Tag = "13";
            this.Button14_cbox.Text = "ボタン14";
            this.Button14_cbox.UseVisualStyleBackColor = false;
            this.Button14_cbox.Visible = false;
            this.Button14_cbox.CheckedChanged += new System.EventHandler(this.Joystick_Button_CheckedChanged);
            // 
            // Button15_cbox
            // 
            this.Button15_cbox.BackColor = System.Drawing.Color.Transparent;
            this.Button15_cbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.Button15_cbox.Location = new System.Drawing.Point(175, 399);
            this.Button15_cbox.Name = "Button15_cbox";
            this.Button15_cbox.Size = new System.Drawing.Size(75, 16);
            this.Button15_cbox.TabIndex = 84;
            this.Button15_cbox.Tag = "14";
            this.Button15_cbox.Text = "ボタン15";
            this.Button15_cbox.UseVisualStyleBackColor = false;
            this.Button15_cbox.Visible = false;
            this.Button15_cbox.CheckedChanged += new System.EventHandler(this.Joystick_Button_CheckedChanged);
            // 
            // btn_soft_reset
            // 
            this.btn_soft_reset.Location = new System.Drawing.Point(414, 517);
            this.btn_soft_reset.Name = "btn_soft_reset";
            this.btn_soft_reset.Size = new System.Drawing.Size(160, 23);
            this.btn_soft_reset.TabIndex = 201;
            this.btn_soft_reset.Text = "Firmware Update";
            this.btn_soft_reset.UseVisualStyleBackColor = true;
            this.btn_soft_reset.Click += new System.EventHandler(this.btn_soft_reset_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Black;
            this.groupBox1.Controls.Add(this.colum_lbl);
            this.groupBox1.Controls.Add(this.Debug_label3);
            this.groupBox1.Controls.Add(this.Debug_label4);
            this.groupBox1.Controls.Add(this.Debug_label2);
            this.groupBox1.Controls.Add(this.Debug_label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 635);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(790, 135);
            this.groupBox1.TabIndex = 901;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DEBUG";
            // 
            // colum_lbl
            // 
            this.colum_lbl.AutoSize = true;
            this.colum_lbl.BackColor = System.Drawing.Color.Black;
            this.colum_lbl.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F);
            this.colum_lbl.ForeColor = System.Drawing.Color.White;
            this.colum_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.colum_lbl.Location = new System.Drawing.Point(15, 24);
            this.colum_lbl.Name = "colum_lbl";
            this.colum_lbl.Size = new System.Drawing.Size(56, 16);
            this.colum_lbl.TabIndex = 901;
            this.colum_lbl.Text = "label1";
            // 
            // Debug_label3
            // 
            this.Debug_label3.AutoSize = true;
            this.Debug_label3.BackColor = System.Drawing.Color.Black;
            this.Debug_label3.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F);
            this.Debug_label3.ForeColor = System.Drawing.Color.White;
            this.Debug_label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Debug_label3.Location = new System.Drawing.Point(15, 84);
            this.Debug_label3.Name = "Debug_label3";
            this.Debug_label3.Size = new System.Drawing.Size(56, 16);
            this.Debug_label3.TabIndex = 904;
            this.Debug_label3.Text = "debug1";
            // 
            // Debug_label4
            // 
            this.Debug_label4.AutoSize = true;
            this.Debug_label4.BackColor = System.Drawing.Color.Black;
            this.Debug_label4.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F);
            this.Debug_label4.ForeColor = System.Drawing.Color.White;
            this.Debug_label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Debug_label4.Location = new System.Drawing.Point(15, 104);
            this.Debug_label4.Name = "Debug_label4";
            this.Debug_label4.Size = new System.Drawing.Size(56, 16);
            this.Debug_label4.TabIndex = 905;
            this.Debug_label4.Text = "debug1";
            // 
            // Debug_label2
            // 
            this.Debug_label2.AutoSize = true;
            this.Debug_label2.BackColor = System.Drawing.Color.Black;
            this.Debug_label2.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F);
            this.Debug_label2.ForeColor = System.Drawing.Color.White;
            this.Debug_label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Debug_label2.Location = new System.Drawing.Point(15, 64);
            this.Debug_label2.Name = "Debug_label2";
            this.Debug_label2.Size = new System.Drawing.Size(56, 16);
            this.Debug_label2.TabIndex = 903;
            this.Debug_label2.Text = "debug1";
            // 
            // Debug_label1
            // 
            this.Debug_label1.AutoSize = true;
            this.Debug_label1.BackColor = System.Drawing.Color.Black;
            this.Debug_label1.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F);
            this.Debug_label1.ForeColor = System.Drawing.Color.White;
            this.Debug_label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Debug_label1.Location = new System.Drawing.Point(15, 44);
            this.Debug_label1.Name = "Debug_label1";
            this.Debug_label1.Size = new System.Drawing.Size(56, 16);
            this.Debug_label1.TabIndex = 902;
            this.Debug_label1.Text = "debug1";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btn_debug_eeprom_write5);
            this.groupBox5.Controls.Add(this.btn_debug_eeprom_write4);
            this.groupBox5.Controls.Add(this.btn_debug_eeprom_write3);
            this.groupBox5.Controls.Add(this.btn_debug_eeprom_write2);
            this.groupBox5.Controls.Add(this.btn_debug_eeprom_write1);
            this.groupBox5.Controls.Add(this.rtxtbx_debug_flash_read);
            this.groupBox5.Controls.Add(this.txtbx_debug_flash_read_size);
            this.groupBox5.Controls.Add(this.txtbx_debug_flash_read_addr);
            this.groupBox5.Controls.Add(this.btn_debug_flash_read);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Location = new System.Drawing.Point(799, 630);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(429, 262);
            this.groupBox5.TabIndex = 951;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "DEBUG EEPROM Read";
            // 
            // btn_debug_eeprom_write5
            // 
            this.btn_debug_eeprom_write5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_debug_eeprom_write5.Location = new System.Drawing.Point(328, 230);
            this.btn_debug_eeprom_write5.Name = "btn_debug_eeprom_write5";
            this.btn_debug_eeprom_write5.Size = new System.Drawing.Size(75, 23);
            this.btn_debug_eeprom_write5.TabIndex = 961;
            this.btn_debug_eeprom_write5.Tag = "5";
            this.btn_debug_eeprom_write5.Text = "w5";
            this.btn_debug_eeprom_write5.UseVisualStyleBackColor = true;
            // 
            // btn_debug_eeprom_write4
            // 
            this.btn_debug_eeprom_write4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_debug_eeprom_write4.Location = new System.Drawing.Point(247, 230);
            this.btn_debug_eeprom_write4.Name = "btn_debug_eeprom_write4";
            this.btn_debug_eeprom_write4.Size = new System.Drawing.Size(75, 23);
            this.btn_debug_eeprom_write4.TabIndex = 960;
            this.btn_debug_eeprom_write4.Tag = "4";
            this.btn_debug_eeprom_write4.Text = "w4";
            this.btn_debug_eeprom_write4.UseVisualStyleBackColor = true;
            // 
            // btn_debug_eeprom_write3
            // 
            this.btn_debug_eeprom_write3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_debug_eeprom_write3.Location = new System.Drawing.Point(166, 230);
            this.btn_debug_eeprom_write3.Name = "btn_debug_eeprom_write3";
            this.btn_debug_eeprom_write3.Size = new System.Drawing.Size(75, 23);
            this.btn_debug_eeprom_write3.TabIndex = 959;
            this.btn_debug_eeprom_write3.Tag = "3";
            this.btn_debug_eeprom_write3.Text = "w3";
            this.btn_debug_eeprom_write3.UseVisualStyleBackColor = true;
            // 
            // btn_debug_eeprom_write2
            // 
            this.btn_debug_eeprom_write2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_debug_eeprom_write2.Location = new System.Drawing.Point(86, 230);
            this.btn_debug_eeprom_write2.Name = "btn_debug_eeprom_write2";
            this.btn_debug_eeprom_write2.Size = new System.Drawing.Size(75, 23);
            this.btn_debug_eeprom_write2.TabIndex = 958;
            this.btn_debug_eeprom_write2.Tag = "2";
            this.btn_debug_eeprom_write2.Text = "w2";
            this.btn_debug_eeprom_write2.UseVisualStyleBackColor = true;
            // 
            // btn_debug_eeprom_write1
            // 
            this.btn_debug_eeprom_write1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_debug_eeprom_write1.Location = new System.Drawing.Point(5, 230);
            this.btn_debug_eeprom_write1.Name = "btn_debug_eeprom_write1";
            this.btn_debug_eeprom_write1.Size = new System.Drawing.Size(75, 23);
            this.btn_debug_eeprom_write1.TabIndex = 957;
            this.btn_debug_eeprom_write1.Tag = "1";
            this.btn_debug_eeprom_write1.Text = "w1";
            this.btn_debug_eeprom_write1.UseVisualStyleBackColor = true;
            // 
            // rtxtbx_debug_flash_read
            // 
            this.rtxtbx_debug_flash_read.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F);
            this.rtxtbx_debug_flash_read.Location = new System.Drawing.Point(5, 42);
            this.rtxtbx_debug_flash_read.Name = "rtxtbx_debug_flash_read";
            this.rtxtbx_debug_flash_read.Size = new System.Drawing.Size(415, 180);
            this.rtxtbx_debug_flash_read.TabIndex = 956;
            this.rtxtbx_debug_flash_read.Text = "";
            // 
            // txtbx_debug_flash_read_size
            // 
            this.txtbx_debug_flash_read_size.Location = new System.Drawing.Point(270, 16);
            this.txtbx_debug_flash_read_size.Name = "txtbx_debug_flash_read_size";
            this.txtbx_debug_flash_read_size.Size = new System.Drawing.Size(47, 19);
            this.txtbx_debug_flash_read_size.TabIndex = 954;
            this.txtbx_debug_flash_read_size.Text = "200";
            this.txtbx_debug_flash_read_size.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtbx_debug_flash_read_addr
            // 
            this.txtbx_debug_flash_read_addr.Location = new System.Drawing.Point(130, 16);
            this.txtbx_debug_flash_read_addr.Name = "txtbx_debug_flash_read_addr";
            this.txtbx_debug_flash_read_addr.Size = new System.Drawing.Size(60, 19);
            this.txtbx_debug_flash_read_addr.TabIndex = 952;
            this.txtbx_debug_flash_read_addr.Text = "0";
            this.txtbx_debug_flash_read_addr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btn_debug_flash_read
            // 
            this.btn_debug_flash_read.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_debug_flash_read.Location = new System.Drawing.Point(320, 16);
            this.btn_debug_flash_read.Name = "btn_debug_flash_read";
            this.btn_debug_flash_read.Size = new System.Drawing.Size(99, 23);
            this.btn_debug_flash_read.TabIndex = 955;
            this.btn_debug_flash_read.Text = "EEPROM Read";
            this.btn_debug_flash_read.UseVisualStyleBackColor = true;
            this.btn_debug_flash_read.Click += new System.EventHandler(this.btn_debug_flash_read_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(200, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 12);
            this.label9.TabIndex = 953;
            this.label9.Text = "Read Size";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(5, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 12);
            this.label8.TabIndex = 951;
            this.label8.Text = "Read Start Address";
            // 
            // DeviceAssign_lbl13
            // 
            this.DeviceAssign_lbl13.AutoSize = true;
            this.DeviceAssign_lbl13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(221)))), ((int)(((byte)(223)))));
            this.DeviceAssign_lbl13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.DeviceAssign_lbl13.Location = new System.Drawing.Point(1213, 117);
            this.DeviceAssign_lbl13.Name = "DeviceAssign_lbl13";
            this.DeviceAssign_lbl13.Size = new System.Drawing.Size(40, 12);
            this.DeviceAssign_lbl13.TabIndex = 956;
            this.DeviceAssign_lbl13.Tag = "12";
            this.DeviceAssign_lbl13.Text = "Assign";
            this.DeviceAssign_lbl13.MouseEnter += new System.EventHandler(this.lbl_sw_assign_MouseEnter);
            // 
            // devicetype_lbl13
            // 
            this.devicetype_lbl13.AutoSize = true;
            this.devicetype_lbl13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(221)))), ((int)(((byte)(223)))));
            this.devicetype_lbl13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.devicetype_lbl13.Location = new System.Drawing.Point(1213, 105);
            this.devicetype_lbl13.Name = "devicetype_lbl13";
            this.devicetype_lbl13.Size = new System.Drawing.Size(33, 12);
            this.devicetype_lbl13.TabIndex = 955;
            this.devicetype_lbl13.Tag = "12";
            this.devicetype_lbl13.Text = "13Pin";
            // 
            // DeviceAssign_lbl14
            // 
            this.DeviceAssign_lbl14.AutoSize = true;
            this.DeviceAssign_lbl14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(221)))), ((int)(((byte)(223)))));
            this.DeviceAssign_lbl14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.DeviceAssign_lbl14.Location = new System.Drawing.Point(1212, 151);
            this.DeviceAssign_lbl14.Name = "DeviceAssign_lbl14";
            this.DeviceAssign_lbl14.Size = new System.Drawing.Size(40, 12);
            this.DeviceAssign_lbl14.TabIndex = 961;
            this.DeviceAssign_lbl14.Tag = "13";
            this.DeviceAssign_lbl14.Text = "Assign";
            this.DeviceAssign_lbl14.MouseEnter += new System.EventHandler(this.lbl_sw_assign_MouseEnter);
            // 
            // devicetype_lbl14
            // 
            this.devicetype_lbl14.AutoSize = true;
            this.devicetype_lbl14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(221)))), ((int)(((byte)(223)))));
            this.devicetype_lbl14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.devicetype_lbl14.Location = new System.Drawing.Point(1212, 139);
            this.devicetype_lbl14.Name = "devicetype_lbl14";
            this.devicetype_lbl14.Size = new System.Drawing.Size(33, 12);
            this.devicetype_lbl14.TabIndex = 960;
            this.devicetype_lbl14.Tag = "13";
            this.devicetype_lbl14.Text = "14Pin";
            // 
            // DeviceAssign_lbl15
            // 
            this.DeviceAssign_lbl15.AutoSize = true;
            this.DeviceAssign_lbl15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(221)))), ((int)(((byte)(223)))));
            this.DeviceAssign_lbl15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.DeviceAssign_lbl15.Location = new System.Drawing.Point(1213, 185);
            this.DeviceAssign_lbl15.Name = "DeviceAssign_lbl15";
            this.DeviceAssign_lbl15.Size = new System.Drawing.Size(40, 12);
            this.DeviceAssign_lbl15.TabIndex = 966;
            this.DeviceAssign_lbl15.Tag = "14";
            this.DeviceAssign_lbl15.Text = "Assign";
            this.DeviceAssign_lbl15.MouseEnter += new System.EventHandler(this.lbl_sw_assign_MouseEnter);
            // 
            // devicetype_lbl15
            // 
            this.devicetype_lbl15.AutoSize = true;
            this.devicetype_lbl15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(221)))), ((int)(((byte)(223)))));
            this.devicetype_lbl15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.devicetype_lbl15.Location = new System.Drawing.Point(1213, 173);
            this.devicetype_lbl15.Name = "devicetype_lbl15";
            this.devicetype_lbl15.Size = new System.Drawing.Size(33, 12);
            this.devicetype_lbl15.TabIndex = 965;
            this.devicetype_lbl15.Tag = "14";
            this.devicetype_lbl15.Text = "15Pin";
            // 
            // lbl_analog1_status
            // 
            this.lbl_analog1_status.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(221)))), ((int)(((byte)(223)))));
            this.lbl_analog1_status.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.lbl_analog1_status.Location = new System.Drawing.Point(343, 388);
            this.lbl_analog1_status.Name = "lbl_analog1_status";
            this.lbl_analog1_status.Size = new System.Drawing.Size(25, 12);
            this.lbl_analog1_status.TabIndex = 967;
            this.lbl_analog1_status.Tag = "0";
            this.lbl_analog1_status.Text = "A1";
            // 
            // lbl_analog1_assign
            // 
            this.lbl_analog1_assign.AutoSize = true;
            this.lbl_analog1_assign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(221)))), ((int)(((byte)(223)))));
            this.lbl_analog1_assign.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.lbl_analog1_assign.Location = new System.Drawing.Point(1128, 206);
            this.lbl_analog1_assign.Name = "lbl_analog1_assign";
            this.lbl_analog1_assign.Size = new System.Drawing.Size(88, 12);
            this.lbl_analog1_assign.TabIndex = 968;
            this.lbl_analog1_assign.Tag = "0";
            this.lbl_analog1_assign.Text = "AN 1PIN Assign";
            this.lbl_analog1_assign.MouseEnter += new System.EventHandler(this.lbl_sw_assign_MouseEnter);
            // 
            // lbl_analog2_assign
            // 
            this.lbl_analog2_assign.AutoSize = true;
            this.lbl_analog2_assign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(221)))), ((int)(((byte)(223)))));
            this.lbl_analog2_assign.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.lbl_analog2_assign.Location = new System.Drawing.Point(1128, 233);
            this.lbl_analog2_assign.Name = "lbl_analog2_assign";
            this.lbl_analog2_assign.Size = new System.Drawing.Size(88, 12);
            this.lbl_analog2_assign.TabIndex = 970;
            this.lbl_analog2_assign.Tag = "1";
            this.lbl_analog2_assign.Text = "AN 2PIN Assign";
            this.lbl_analog2_assign.MouseEnter += new System.EventHandler(this.lbl_sw_assign_MouseEnter);
            // 
            // lbl_analog2_status
            // 
            this.lbl_analog2_status.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(221)))), ((int)(((byte)(223)))));
            this.lbl_analog2_status.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.lbl_analog2_status.Location = new System.Drawing.Point(368, 388);
            this.lbl_analog2_status.Name = "lbl_analog2_status";
            this.lbl_analog2_status.Size = new System.Drawing.Size(25, 12);
            this.lbl_analog2_status.TabIndex = 969;
            this.lbl_analog2_status.Tag = "1";
            this.lbl_analog2_status.Text = "A2";
            // 
            // lbl_analog3_assign
            // 
            this.lbl_analog3_assign.AutoSize = true;
            this.lbl_analog3_assign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(221)))), ((int)(((byte)(223)))));
            this.lbl_analog3_assign.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.lbl_analog3_assign.Location = new System.Drawing.Point(1128, 261);
            this.lbl_analog3_assign.Name = "lbl_analog3_assign";
            this.lbl_analog3_assign.Size = new System.Drawing.Size(88, 12);
            this.lbl_analog3_assign.TabIndex = 972;
            this.lbl_analog3_assign.Tag = "2";
            this.lbl_analog3_assign.Text = "AN 3PIN Assign";
            this.lbl_analog3_assign.MouseEnter += new System.EventHandler(this.lbl_sw_assign_MouseEnter);
            // 
            // lbl_analog3_status
            // 
            this.lbl_analog3_status.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(221)))), ((int)(((byte)(223)))));
            this.lbl_analog3_status.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.lbl_analog3_status.Location = new System.Drawing.Point(393, 388);
            this.lbl_analog3_status.Name = "lbl_analog3_status";
            this.lbl_analog3_status.Size = new System.Drawing.Size(25, 12);
            this.lbl_analog3_status.TabIndex = 971;
            this.lbl_analog3_status.Tag = "2";
            this.lbl_analog3_status.Text = "A3";
            // 
            // lbl_analog4_assign
            // 
            this.lbl_analog4_assign.AutoSize = true;
            this.lbl_analog4_assign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(221)))), ((int)(((byte)(223)))));
            this.lbl_analog4_assign.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.lbl_analog4_assign.Location = new System.Drawing.Point(1128, 289);
            this.lbl_analog4_assign.Name = "lbl_analog4_assign";
            this.lbl_analog4_assign.Size = new System.Drawing.Size(88, 12);
            this.lbl_analog4_assign.TabIndex = 974;
            this.lbl_analog4_assign.Tag = "3";
            this.lbl_analog4_assign.Text = "AN 4PIN Assign";
            this.lbl_analog4_assign.MouseEnter += new System.EventHandler(this.lbl_sw_assign_MouseEnter);
            // 
            // lbl_analog4_status
            // 
            this.lbl_analog4_status.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(221)))), ((int)(((byte)(223)))));
            this.lbl_analog4_status.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.lbl_analog4_status.Location = new System.Drawing.Point(418, 388);
            this.lbl_analog4_status.Name = "lbl_analog4_status";
            this.lbl_analog4_status.Size = new System.Drawing.Size(25, 12);
            this.lbl_analog4_status.TabIndex = 973;
            this.lbl_analog4_status.Tag = "3";
            this.lbl_analog4_status.Text = "A4";
            // 
            // lbl_analog8_assign
            // 
            this.lbl_analog8_assign.AutoSize = true;
            this.lbl_analog8_assign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(221)))), ((int)(((byte)(223)))));
            this.lbl_analog8_assign.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.lbl_analog8_assign.Location = new System.Drawing.Point(1128, 409);
            this.lbl_analog8_assign.Name = "lbl_analog8_assign";
            this.lbl_analog8_assign.Size = new System.Drawing.Size(88, 12);
            this.lbl_analog8_assign.TabIndex = 982;
            this.lbl_analog8_assign.Tag = "7";
            this.lbl_analog8_assign.Text = "AN 8PIN Assign";
            this.lbl_analog8_assign.MouseEnter += new System.EventHandler(this.lbl_sw_assign_MouseEnter);
            // 
            // lbl_analog8_status
            // 
            this.lbl_analog8_status.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(221)))), ((int)(((byte)(223)))));
            this.lbl_analog8_status.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.lbl_analog8_status.Location = new System.Drawing.Point(592, 388);
            this.lbl_analog8_status.Name = "lbl_analog8_status";
            this.lbl_analog8_status.Size = new System.Drawing.Size(25, 12);
            this.lbl_analog8_status.TabIndex = 981;
            this.lbl_analog8_status.Tag = "7";
            this.lbl_analog8_status.Text = "A8";
            // 
            // lbl_analog7_assign
            // 
            this.lbl_analog7_assign.AutoSize = true;
            this.lbl_analog7_assign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(221)))), ((int)(((byte)(223)))));
            this.lbl_analog7_assign.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.lbl_analog7_assign.Location = new System.Drawing.Point(1128, 379);
            this.lbl_analog7_assign.Name = "lbl_analog7_assign";
            this.lbl_analog7_assign.Size = new System.Drawing.Size(88, 12);
            this.lbl_analog7_assign.TabIndex = 980;
            this.lbl_analog7_assign.Tag = "6";
            this.lbl_analog7_assign.Text = "AN 7PIN Assign";
            this.lbl_analog7_assign.MouseEnter += new System.EventHandler(this.lbl_sw_assign_MouseEnter);
            // 
            // lbl_analog7_status
            // 
            this.lbl_analog7_status.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(221)))), ((int)(((byte)(223)))));
            this.lbl_analog7_status.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.lbl_analog7_status.Location = new System.Drawing.Point(567, 388);
            this.lbl_analog7_status.Name = "lbl_analog7_status";
            this.lbl_analog7_status.Size = new System.Drawing.Size(25, 12);
            this.lbl_analog7_status.TabIndex = 979;
            this.lbl_analog7_status.Tag = "6";
            this.lbl_analog7_status.Text = "A7";
            // 
            // lbl_analog6_assign
            // 
            this.lbl_analog6_assign.AutoSize = true;
            this.lbl_analog6_assign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(221)))), ((int)(((byte)(223)))));
            this.lbl_analog6_assign.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.lbl_analog6_assign.Location = new System.Drawing.Point(1128, 351);
            this.lbl_analog6_assign.Name = "lbl_analog6_assign";
            this.lbl_analog6_assign.Size = new System.Drawing.Size(88, 12);
            this.lbl_analog6_assign.TabIndex = 978;
            this.lbl_analog6_assign.Tag = "5";
            this.lbl_analog6_assign.Text = "AN 6PIN Assign";
            this.lbl_analog6_assign.MouseEnter += new System.EventHandler(this.lbl_sw_assign_MouseEnter);
            // 
            // lbl_analog6_status
            // 
            this.lbl_analog6_status.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(221)))), ((int)(((byte)(223)))));
            this.lbl_analog6_status.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.lbl_analog6_status.Location = new System.Drawing.Point(542, 388);
            this.lbl_analog6_status.Name = "lbl_analog6_status";
            this.lbl_analog6_status.Size = new System.Drawing.Size(25, 12);
            this.lbl_analog6_status.TabIndex = 977;
            this.lbl_analog6_status.Tag = "5";
            this.lbl_analog6_status.Text = "A6";
            // 
            // lbl_analog5_assign
            // 
            this.lbl_analog5_assign.AutoSize = true;
            this.lbl_analog5_assign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(221)))), ((int)(((byte)(223)))));
            this.lbl_analog5_assign.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.lbl_analog5_assign.Location = new System.Drawing.Point(1128, 324);
            this.lbl_analog5_assign.Name = "lbl_analog5_assign";
            this.lbl_analog5_assign.Size = new System.Drawing.Size(88, 12);
            this.lbl_analog5_assign.TabIndex = 976;
            this.lbl_analog5_assign.Tag = "4";
            this.lbl_analog5_assign.Text = "AN 5PIN Assign";
            this.lbl_analog5_assign.MouseEnter += new System.EventHandler(this.lbl_sw_assign_MouseEnter);
            // 
            // lbl_analog5_status
            // 
            this.lbl_analog5_status.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(221)))), ((int)(((byte)(223)))));
            this.lbl_analog5_status.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.lbl_analog5_status.Location = new System.Drawing.Point(443, 388);
            this.lbl_analog5_status.Name = "lbl_analog5_status";
            this.lbl_analog5_status.Size = new System.Drawing.Size(25, 12);
            this.lbl_analog5_status.TabIndex = 975;
            this.lbl_analog5_status.Tag = "4";
            this.lbl_analog5_status.Text = "A5";
            // 
            // hatsw_up_cbox
            // 
            this.hatsw_up_cbox.BackColor = System.Drawing.Color.Transparent;
            this.hatsw_up_cbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.hatsw_up_cbox.Location = new System.Drawing.Point(75, 268);
            this.hatsw_up_cbox.Name = "hatsw_up_cbox";
            this.hatsw_up_cbox.Size = new System.Drawing.Size(100, 16);
            this.hatsw_up_cbox.TabIndex = 60;
            this.hatsw_up_cbox.Tag = "0";
            this.hatsw_up_cbox.Text = "HatSW 上";
            this.hatsw_up_cbox.UseVisualStyleBackColor = false;
            this.hatsw_up_cbox.Visible = false;
            this.hatsw_up_cbox.CheckedChanged += new System.EventHandler(this.Joystick_HatSW_CheckedChanged);
            // 
            // hatsw_right_cbox
            // 
            this.hatsw_right_cbox.BackColor = System.Drawing.Color.Transparent;
            this.hatsw_right_cbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.hatsw_right_cbox.Location = new System.Drawing.Point(125, 286);
            this.hatsw_right_cbox.Name = "hatsw_right_cbox";
            this.hatsw_right_cbox.Size = new System.Drawing.Size(100, 16);
            this.hatsw_right_cbox.TabIndex = 61;
            this.hatsw_right_cbox.Tag = "1";
            this.hatsw_right_cbox.Text = "HatSW 右";
            this.hatsw_right_cbox.UseVisualStyleBackColor = false;
            this.hatsw_right_cbox.Visible = false;
            this.hatsw_right_cbox.CheckedChanged += new System.EventHandler(this.Joystick_HatSW_CheckedChanged);
            // 
            // hatsw_down_cbox
            // 
            this.hatsw_down_cbox.BackColor = System.Drawing.Color.Transparent;
            this.hatsw_down_cbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.hatsw_down_cbox.Location = new System.Drawing.Point(75, 304);
            this.hatsw_down_cbox.Name = "hatsw_down_cbox";
            this.hatsw_down_cbox.Size = new System.Drawing.Size(100, 16);
            this.hatsw_down_cbox.TabIndex = 62;
            this.hatsw_down_cbox.Tag = "2";
            this.hatsw_down_cbox.Text = "HatSW 下";
            this.hatsw_down_cbox.UseVisualStyleBackColor = false;
            this.hatsw_down_cbox.Visible = false;
            this.hatsw_down_cbox.CheckedChanged += new System.EventHandler(this.Joystick_HatSW_CheckedChanged);
            // 
            // hatsw_left_cbox
            // 
            this.hatsw_left_cbox.BackColor = System.Drawing.Color.Transparent;
            this.hatsw_left_cbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.hatsw_left_cbox.Location = new System.Drawing.Point(15, 286);
            this.hatsw_left_cbox.Name = "hatsw_left_cbox";
            this.hatsw_left_cbox.Size = new System.Drawing.Size(100, 16);
            this.hatsw_left_cbox.TabIndex = 63;
            this.hatsw_left_cbox.Tag = "3";
            this.hatsw_left_cbox.Text = "HatSW 左";
            this.hatsw_left_cbox.UseVisualStyleBackColor = false;
            this.hatsw_left_cbox.Visible = false;
            this.hatsw_left_cbox.CheckedChanged += new System.EventHandler(this.Joystick_HatSW_CheckedChanged);
            // 
            // lbl_FW_Version
            // 
            this.lbl_FW_Version.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(214)))), ((int)(((byte)(214)))));
            this.lbl_FW_Version.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.lbl_FW_Version.Location = new System.Drawing.Point(677, 587);
            this.lbl_FW_Version.Name = "lbl_FW_Version";
            this.lbl_FW_Version.Size = new System.Drawing.Size(180, 12);
            this.lbl_FW_Version.TabIndex = 987;
            this.lbl_FW_Version.Text = "FW";
            // 
            // btn_default_reset
            // 
            this.btn_default_reset.Location = new System.Drawing.Point(578, 517);
            this.btn_default_reset.Name = "btn_default_reset";
            this.btn_default_reset.Size = new System.Drawing.Size(160, 23);
            this.btn_default_reset.TabIndex = 988;
            this.btn_default_reset.Text = "Default Reset";
            this.btn_default_reset.UseVisualStyleBackColor = true;
            this.btn_default_reset.Click += new System.EventHandler(this.btn_default_reset_Click);
            // 
            // LeverSliderM_cbox
            // 
            this.LeverSliderM_cbox.AutoSize = true;
            this.LeverSliderM_cbox.BackColor = System.Drawing.Color.Transparent;
            this.LeverSliderM_cbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.LeverSliderM_cbox.Location = new System.Drawing.Point(125, 243);
            this.LeverSliderM_cbox.Name = "LeverSliderM_cbox";
            this.LeverSliderM_cbox.Size = new System.Drawing.Size(79, 16);
            this.LeverSliderM_cbox.TabIndex = 54;
            this.LeverSliderM_cbox.Tag = "11";
            this.LeverSliderM_cbox.Text = "スライダー -";
            this.LeverSliderM_cbox.UseVisualStyleBackColor = false;
            this.LeverSliderM_cbox.Visible = false;
            // 
            // LeverSliderP_cbox
            // 
            this.LeverSliderP_cbox.AutoSize = true;
            this.LeverSliderP_cbox.BackColor = System.Drawing.Color.Transparent;
            this.LeverSliderP_cbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.LeverSliderP_cbox.Location = new System.Drawing.Point(15, 243);
            this.LeverSliderP_cbox.Name = "LeverSliderP_cbox";
            this.LeverSliderP_cbox.Size = new System.Drawing.Size(79, 16);
            this.LeverSliderP_cbox.TabIndex = 53;
            this.LeverSliderP_cbox.Tag = "10";
            this.LeverSliderP_cbox.Text = "スライダー +";
            this.LeverSliderP_cbox.UseVisualStyleBackColor = false;
            this.LeverSliderP_cbox.Visible = false;
            // 
            // lbl_sw_mouse_title2
            // 
            this.lbl_sw_mouse_title2.Location = new System.Drawing.Point(50, 199);
            this.lbl_sw_mouse_title2.Name = "lbl_sw_mouse_title2";
            this.lbl_sw_mouse_title2.Size = new System.Drawing.Size(150, 35);
            this.lbl_sw_mouse_title2.TabIndex = 990;
            this.lbl_sw_mouse_title2.Text = "割当て";
            this.lbl_sw_mouse_title2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_sw_mouse_title1
            // 
            this.lbl_sw_mouse_title1.Location = new System.Drawing.Point(50, 157);
            this.lbl_sw_mouse_title1.Name = "lbl_sw_mouse_title1";
            this.lbl_sw_mouse_title1.Size = new System.Drawing.Size(150, 16);
            this.lbl_sw_mouse_title1.TabIndex = 989;
            this.lbl_sw_mouse_title1.Text = "割当て";
            this.lbl_sw_mouse_title1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // LeverRZP_cbox
            // 
            this.LeverRZP_cbox.AutoSize = true;
            this.LeverRZP_cbox.BackColor = System.Drawing.Color.Transparent;
            this.LeverRZP_cbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.LeverRZP_cbox.Location = new System.Drawing.Point(15, 225);
            this.LeverRZP_cbox.Name = "LeverRZP_cbox";
            this.LeverRZP_cbox.Size = new System.Drawing.Size(78, 16);
            this.LeverRZP_cbox.TabIndex = 51;
            this.LeverRZP_cbox.Tag = "10";
            this.LeverRZP_cbox.Text = "レバーRZ +";
            this.LeverRZP_cbox.UseVisualStyleBackColor = false;
            this.LeverRZP_cbox.Visible = false;
            // 
            // LeverRZM_cbox
            // 
            this.LeverRZM_cbox.AutoSize = true;
            this.LeverRZM_cbox.BackColor = System.Drawing.Color.Transparent;
            this.LeverRZM_cbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.LeverRZM_cbox.Location = new System.Drawing.Point(125, 225);
            this.LeverRZM_cbox.Name = "LeverRZM_cbox";
            this.LeverRZM_cbox.Size = new System.Drawing.Size(78, 16);
            this.LeverRZM_cbox.TabIndex = 52;
            this.LeverRZM_cbox.Tag = "11";
            this.LeverRZM_cbox.Text = "レバーRZ -";
            this.LeverRZM_cbox.UseVisualStyleBackColor = false;
            this.LeverRZM_cbox.Visible = false;
            // 
            // LeverRYP_cbox
            // 
            this.LeverRYP_cbox.AutoSize = true;
            this.LeverRYP_cbox.BackColor = System.Drawing.Color.Transparent;
            this.LeverRYP_cbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.LeverRYP_cbox.Location = new System.Drawing.Point(15, 207);
            this.LeverRYP_cbox.Name = "LeverRYP_cbox";
            this.LeverRYP_cbox.Size = new System.Drawing.Size(78, 16);
            this.LeverRYP_cbox.TabIndex = 49;
            this.LeverRYP_cbox.Tag = "8";
            this.LeverRYP_cbox.Text = "レバーRY +";
            this.LeverRYP_cbox.UseVisualStyleBackColor = false;
            this.LeverRYP_cbox.Visible = false;
            // 
            // LeverRYM_cbox
            // 
            this.LeverRYM_cbox.AutoSize = true;
            this.LeverRYM_cbox.BackColor = System.Drawing.Color.Transparent;
            this.LeverRYM_cbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.LeverRYM_cbox.Location = new System.Drawing.Point(125, 207);
            this.LeverRYM_cbox.Name = "LeverRYM_cbox";
            this.LeverRYM_cbox.Size = new System.Drawing.Size(78, 16);
            this.LeverRYM_cbox.TabIndex = 50;
            this.LeverRYM_cbox.Tag = "9";
            this.LeverRYM_cbox.Text = "レバーRY -";
            this.LeverRYM_cbox.UseVisualStyleBackColor = false;
            this.LeverRYM_cbox.Visible = false;
            // 
            // LeverRXP_cbox
            // 
            this.LeverRXP_cbox.AutoSize = true;
            this.LeverRXP_cbox.BackColor = System.Drawing.Color.Transparent;
            this.LeverRXP_cbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.LeverRXP_cbox.Location = new System.Drawing.Point(15, 189);
            this.LeverRXP_cbox.Name = "LeverRXP_cbox";
            this.LeverRXP_cbox.Size = new System.Drawing.Size(78, 16);
            this.LeverRXP_cbox.TabIndex = 47;
            this.LeverRXP_cbox.Tag = "6";
            this.LeverRXP_cbox.Text = "レバーRX +";
            this.LeverRXP_cbox.UseVisualStyleBackColor = false;
            this.LeverRXP_cbox.Visible = false;
            // 
            // LeverRXM_cbox
            // 
            this.LeverRXM_cbox.AutoSize = true;
            this.LeverRXM_cbox.BackColor = System.Drawing.Color.Transparent;
            this.LeverRXM_cbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.LeverRXM_cbox.Location = new System.Drawing.Point(125, 189);
            this.LeverRXM_cbox.Name = "LeverRXM_cbox";
            this.LeverRXM_cbox.Size = new System.Drawing.Size(78, 16);
            this.LeverRXM_cbox.TabIndex = 48;
            this.LeverRXM_cbox.Tag = "7";
            this.LeverRXM_cbox.Text = "レバーRX -";
            this.LeverRXM_cbox.UseVisualStyleBackColor = false;
            this.LeverRXM_cbox.Visible = false;
            // 
            // LeverZP_cbox
            // 
            this.LeverZP_cbox.AutoSize = true;
            this.LeverZP_cbox.BackColor = System.Drawing.Color.Transparent;
            this.LeverZP_cbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.LeverZP_cbox.Location = new System.Drawing.Point(15, 171);
            this.LeverZP_cbox.Name = "LeverZP_cbox";
            this.LeverZP_cbox.Size = new System.Drawing.Size(70, 16);
            this.LeverZP_cbox.TabIndex = 45;
            this.LeverZP_cbox.Tag = "4";
            this.LeverZP_cbox.Text = "レバーZ +";
            this.LeverZP_cbox.UseVisualStyleBackColor = false;
            this.LeverZP_cbox.Visible = false;
            // 
            // LeverZM_cbox
            // 
            this.LeverZM_cbox.AutoSize = true;
            this.LeverZM_cbox.BackColor = System.Drawing.Color.Transparent;
            this.LeverZM_cbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.LeverZM_cbox.Location = new System.Drawing.Point(125, 171);
            this.LeverZM_cbox.Name = "LeverZM_cbox";
            this.LeverZM_cbox.Size = new System.Drawing.Size(70, 16);
            this.LeverZM_cbox.TabIndex = 46;
            this.LeverZM_cbox.Tag = "5";
            this.LeverZM_cbox.Text = "レバーZ -";
            this.LeverZM_cbox.UseVisualStyleBackColor = false;
            this.LeverZM_cbox.Visible = false;
            // 
            // lbl_digital_assign
            // 
            this.lbl_digital_assign.Location = new System.Drawing.Point(15, 105);
            this.lbl_digital_assign.Name = "lbl_digital_assign";
            this.lbl_digital_assign.Size = new System.Drawing.Size(100, 16);
            this.lbl_digital_assign.TabIndex = 15;
            this.lbl_digital_assign.Text = "割当て";
            this.lbl_digital_assign.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lbl_digital_device_type
            // 
            this.lbl_digital_device_type.Location = new System.Drawing.Point(15, 60);
            this.lbl_digital_device_type.Name = "lbl_digital_device_type";
            this.lbl_digital_device_type.Size = new System.Drawing.Size(100, 16);
            this.lbl_digital_device_type.TabIndex = 13;
            this.lbl_digital_device_type.Text = "デバイスタイプ";
            this.lbl_digital_device_type.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lbl_digital_pin_no
            // 
            this.lbl_digital_pin_no.Location = new System.Drawing.Point(15, 15);
            this.lbl_digital_pin_no.Name = "lbl_digital_pin_no";
            this.lbl_digital_pin_no.Size = new System.Drawing.Size(100, 16);
            this.lbl_digital_pin_no.TabIndex = 11;
            this.lbl_digital_pin_no.Text = "ピン番号";
            this.lbl_digital_pin_no.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // btn_digital_set
            // 
            this.btn_digital_set.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_digital_set.BackgroundImage")));
            this.btn_digital_set.Enabled = false;
            this.btn_digital_set.Location = new System.Drawing.Point(65, 435);
            this.btn_digital_set.Name = "btn_digital_set";
            this.btn_digital_set.Size = new System.Drawing.Size(121, 29);
            this.btn_digital_set.TabIndex = 99;
            this.btn_digital_set.UseVisualStyleBackColor = true;
            this.btn_digital_set.Click += new System.EventHandler(this.btn_digital_set_Click);
            // 
            // Arrow_Com_pb
            // 
            this.Arrow_Com_pb.BackColor = System.Drawing.Color.Transparent;
            this.Arrow_Com_pb.Image = global::Revive_USB_Advance_CT.Properties.Resources.F_arrow;
            this.Arrow_Com_pb.Location = new System.Drawing.Point(121, 420);
            this.Arrow_Com_pb.Name = "Arrow_Com_pb";
            this.Arrow_Com_pb.Size = new System.Drawing.Size(9, 12);
            this.Arrow_Com_pb.TabIndex = 115;
            this.Arrow_Com_pb.TabStop = false;
            this.Arrow_Com_pb.Visible = false;
            // 
            // Arrow_Mouse1_pb
            // 
            this.Arrow_Mouse1_pb.BackColor = System.Drawing.Color.Transparent;
            this.Arrow_Mouse1_pb.Image = global::Revive_USB_Advance_CT.Properties.Resources.F_arrow;
            this.Arrow_Mouse1_pb.Location = new System.Drawing.Point(11, 447);
            this.Arrow_Mouse1_pb.Name = "Arrow_Mouse1_pb";
            this.Arrow_Mouse1_pb.Size = new System.Drawing.Size(9, 12);
            this.Arrow_Mouse1_pb.TabIndex = 133;
            this.Arrow_Mouse1_pb.TabStop = false;
            this.Arrow_Mouse1_pb.Visible = false;
            // 
            // Arrow_Mouse2_pb
            // 
            this.Arrow_Mouse2_pb.BackColor = System.Drawing.Color.Transparent;
            this.Arrow_Mouse2_pb.Image = global::Revive_USB_Advance_CT.Properties.Resources.F_arrow;
            this.Arrow_Mouse2_pb.Location = new System.Drawing.Point(26, 447);
            this.Arrow_Mouse2_pb.Name = "Arrow_Mouse2_pb";
            this.Arrow_Mouse2_pb.Size = new System.Drawing.Size(9, 12);
            this.Arrow_Mouse2_pb.TabIndex = 135;
            this.Arrow_Mouse2_pb.TabStop = false;
            this.Arrow_Mouse2_pb.Visible = false;
            // 
            // Arrow_Mouse3_pb
            // 
            this.Arrow_Mouse3_pb.BackColor = System.Drawing.Color.Transparent;
            this.Arrow_Mouse3_pb.Image = global::Revive_USB_Advance_CT.Properties.Resources.F_arrow;
            this.Arrow_Mouse3_pb.Location = new System.Drawing.Point(40, 447);
            this.Arrow_Mouse3_pb.Name = "Arrow_Mouse3_pb";
            this.Arrow_Mouse3_pb.Size = new System.Drawing.Size(9, 12);
            this.Arrow_Mouse3_pb.TabIndex = 137;
            this.Arrow_Mouse3_pb.TabStop = false;
            this.Arrow_Mouse3_pb.Visible = false;
            // 
            // Arrow_Keyboard_pb
            // 
            this.Arrow_Keyboard_pb.BackColor = System.Drawing.Color.Transparent;
            this.Arrow_Keyboard_pb.Image = global::Revive_USB_Advance_CT.Properties.Resources.F_arrow;
            this.Arrow_Keyboard_pb.Location = new System.Drawing.Point(198, 441);
            this.Arrow_Keyboard_pb.Name = "Arrow_Keyboard_pb";
            this.Arrow_Keyboard_pb.Size = new System.Drawing.Size(9, 12);
            this.Arrow_Keyboard_pb.TabIndex = 114;
            this.Arrow_Keyboard_pb.TabStop = false;
            this.Arrow_Keyboard_pb.Visible = false;
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.Silver;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(10, 20);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(200, 420);
            this.listView1.TabIndex = 990;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 2;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Pin";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 35;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Type";
            this.columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Assign";
            this.columnHeader4.Width = 300;
            // 
            // gbx_setting_list
            // 
            this.gbx_setting_list.BackColor = System.Drawing.Color.White;
            this.gbx_setting_list.Controls.Add(this.listView1);
            this.gbx_setting_list.Location = new System.Drawing.Point(763, 15);
            this.gbx_setting_list.Name = "gbx_setting_list";
            this.gbx_setting_list.Size = new System.Drawing.Size(220, 450);
            this.gbx_setting_list.TabIndex = 991;
            this.gbx_setting_list.TabStop = false;
            this.gbx_setting_list.Text = "設定リスト";
            // 
            // pnl_analog_setting
            // 
            this.pnl_analog_setting.BackColor = System.Drawing.Color.White;
            this.pnl_analog_setting.Controls.Add(this.chkbx_analog_calibration);
            this.pnl_analog_setting.Controls.Add(this.lbl_analog_pin_no);
            this.pnl_analog_setting.Controls.Add(this.lbl_output_val);
            this.pnl_analog_setting.Controls.Add(this.num_input_vol2);
            this.pnl_analog_setting.Controls.Add(this.num_analog_sensitivity);
            this.pnl_analog_setting.Controls.Add(this.cmbbx_analog_pin);
            this.pnl_analog_setting.Controls.Add(this.gbx_analog_calibration);
            this.pnl_analog_setting.Controls.Add(this.cmbbx_analog_set_type);
            this.pnl_analog_setting.Controls.Add(this.lbl_analog_sensitivity);
            this.pnl_analog_setting.Controls.Add(this.chart1);
            this.pnl_analog_setting.Controls.Add(this.pic_analog_arrow5);
            this.pnl_analog_setting.Controls.Add(this.lbl_input_voltage);
            this.pnl_analog_setting.Controls.Add(this.pic_analog_arrow4);
            this.pnl_analog_setting.Controls.Add(this.lbl_input_vol1);
            this.pnl_analog_setting.Controls.Add(this.pic_analog_arrow3);
            this.pnl_analog_setting.Controls.Add(this.num_output_val1);
            this.pnl_analog_setting.Controls.Add(this.pic_analog_arrow2);
            this.pnl_analog_setting.Controls.Add(this.num_output_val2);
            this.pnl_analog_setting.Controls.Add(this.pic_analog_arrow1);
            this.pnl_analog_setting.Controls.Add(this.num_input_vol3);
            this.pnl_analog_setting.Controls.Add(this.lbl_analog_set_type);
            this.pnl_analog_setting.Controls.Add(this.num_output_val3);
            this.pnl_analog_setting.Controls.Add(this.num_input_vol4);
            this.pnl_analog_setting.Controls.Add(this.btn_analog_set);
            this.pnl_analog_setting.Controls.Add(this.num_output_val4);
            this.pnl_analog_setting.Controls.Add(this.lbl_input_vol5);
            this.pnl_analog_setting.Controls.Add(this.num_output_val5);
            this.pnl_analog_setting.Location = new System.Drawing.Point(15, 57);
            this.pnl_analog_setting.Name = "pnl_analog_setting";
            this.pnl_analog_setting.Size = new System.Drawing.Size(260, 475);
            this.pnl_analog_setting.TabIndex = 1012;
            // 
            // pnl_digital_setting
            // 
            this.pnl_digital_setting.BackColor = System.Drawing.Color.White;
            this.pnl_digital_setting.Controls.Add(this.LeverSliderM_cbox);
            this.pnl_digital_setting.Controls.Add(this.lbl_digital_pin_no);
            this.pnl_digital_setting.Controls.Add(this.LeverSliderP_cbox);
            this.pnl_digital_setting.Controls.Add(this.Arrow_Keyboard_pb);
            this.pnl_digital_setting.Controls.Add(this.lbl_sw_mouse_title2);
            this.pnl_digital_setting.Controls.Add(this.Arrow_Mouse3_pb);
            this.pnl_digital_setting.Controls.Add(this.lbl_sw_mouse_title1);
            this.pnl_digital_setting.Controls.Add(this.Arrow_Mouse2_pb);
            this.pnl_digital_setting.Controls.Add(this.LeverRZP_cbox);
            this.pnl_digital_setting.Controls.Add(this.Arrow_Mouse1_pb);
            this.pnl_digital_setting.Controls.Add(this.LeverRZM_cbox);
            this.pnl_digital_setting.Controls.Add(this.Arrow_Com_pb);
            this.pnl_digital_setting.Controls.Add(this.LeverRYP_cbox);
            this.pnl_digital_setting.Controls.Add(this.Win_cbox);
            this.pnl_digital_setting.Controls.Add(this.LeverRYM_cbox);
            this.pnl_digital_setting.Controls.Add(this.Shift_cbox);
            this.pnl_digital_setting.Controls.Add(this.LeverRXP_cbox);
            this.pnl_digital_setting.Controls.Add(this.Alt_cbox);
            this.pnl_digital_setting.Controls.Add(this.LeverRXM_cbox);
            this.pnl_digital_setting.Controls.Add(this.Ctrl_cbox);
            this.pnl_digital_setting.Controls.Add(this.LeverZP_cbox);
            this.pnl_digital_setting.Controls.Add(this.KeyboardValue_txtbx);
            this.pnl_digital_setting.Controls.Add(this.LeverZM_cbox);
            this.pnl_digital_setting.Controls.Add(this.MouseMove_UD);
            this.pnl_digital_setting.Controls.Add(this.lbl_digital_assign);
            this.pnl_digital_setting.Controls.Add(this.Button14_cbox);
            this.pnl_digital_setting.Controls.Add(this.lbl_digital_device_type);
            this.pnl_digital_setting.Controls.Add(this.Button13_cbox);
            this.pnl_digital_setting.Controls.Add(this.Button12_cbox);
            this.pnl_digital_setting.Controls.Add(this.hatsw_left_cbox);
            this.pnl_digital_setting.Controls.Add(this.Button11_cbox);
            this.pnl_digital_setting.Controls.Add(this.hatsw_down_cbox);
            this.pnl_digital_setting.Controls.Add(this.Button15_cbox);
            this.pnl_digital_setting.Controls.Add(this.cmbbx_digital_pin);
            this.pnl_digital_setting.Controls.Add(this.Button9_cbox);
            this.pnl_digital_setting.Controls.Add(this.hatsw_right_cbox);
            this.pnl_digital_setting.Controls.Add(this.Button8_cbox);
            this.pnl_digital_setting.Controls.Add(this.cmbbx_digital_device_type);
            this.pnl_digital_setting.Controls.Add(this.Button7_cbox);
            this.pnl_digital_setting.Controls.Add(this.hatsw_up_cbox);
            this.pnl_digital_setting.Controls.Add(this.Button6_cbox);
            this.pnl_digital_setting.Controls.Add(this.cmbbx_digital_assign);
            this.pnl_digital_setting.Controls.Add(this.Button10_cbox);
            this.pnl_digital_setting.Controls.Add(this.btn_digital_set);
            this.pnl_digital_setting.Controls.Add(this.Button4_cbox);
            this.pnl_digital_setting.Controls.Add(this.LeverYM_cbox);
            this.pnl_digital_setting.Controls.Add(this.Button3_cbox);
            this.pnl_digital_setting.Controls.Add(this.LeverXP_cbox);
            this.pnl_digital_setting.Controls.Add(this.Button2_cbox);
            this.pnl_digital_setting.Controls.Add(this.LeverXM_cbox);
            this.pnl_digital_setting.Controls.Add(this.Button1_cbox);
            this.pnl_digital_setting.Controls.Add(this.LeverYP_cbox);
            this.pnl_digital_setting.Controls.Add(this.Button5_cbox);
            this.pnl_digital_setting.Location = new System.Drawing.Point(30, 69);
            this.pnl_digital_setting.Name = "pnl_digital_setting";
            this.pnl_digital_setting.Size = new System.Drawing.Size(260, 475);
            this.pnl_digital_setting.TabIndex = 1013;
            // 
            // Revive_Advance_Device_pb
            // 
            this.Revive_Advance_Device_pb.BackgroundImage = global::Revive_USB_Advance_CT.Properties.Resources.AD_MAIN_OFF;
            this.Revive_Advance_Device_pb.InitialImage = global::Revive_USB_Advance_CT.Properties.Resources.AD_MAIN_OFF;
            this.Revive_Advance_Device_pb.Location = new System.Drawing.Point(305, 146);
            this.Revive_Advance_Device_pb.Name = "Revive_Advance_Device_pb";
            this.Revive_Advance_Device_pb.Size = new System.Drawing.Size(412, 175);
            this.Revive_Advance_Device_pb.TabIndex = 1014;
            this.Revive_Advance_Device_pb.TabStop = false;
            // 
            // dig_tabA_pb
            // 
            this.dig_tabA_pb.BackgroundImage = global::Revive_USB_Advance_CT.Properties.Resources.AD_TAB_DIGI_ON;
            this.dig_tabA_pb.Location = new System.Drawing.Point(100, 15);
            this.dig_tabA_pb.Name = "dig_tabA_pb";
            this.dig_tabA_pb.Size = new System.Drawing.Size(78, 41);
            this.dig_tabA_pb.TabIndex = 1010;
            this.dig_tabA_pb.TabStop = false;
            // 
            // ana_tabA_pb
            // 
            this.ana_tabA_pb.BackgroundImage = global::Revive_USB_Advance_CT.Properties.Resources.AD_TAB_ANA_ON;
            this.ana_tabA_pb.Location = new System.Drawing.Point(15, 15);
            this.ana_tabA_pb.Name = "ana_tabA_pb";
            this.ana_tabA_pb.Size = new System.Drawing.Size(78, 41);
            this.ana_tabA_pb.TabIndex = 1008;
            this.ana_tabA_pb.TabStop = false;
            // 
            // dig_tabB_pb
            // 
            this.dig_tabB_pb.BackgroundImage = global::Revive_USB_Advance_CT.Properties.Resources.AD_TAB_DIGI_OFF;
            this.dig_tabB_pb.Location = new System.Drawing.Point(100, 15);
            this.dig_tabB_pb.Name = "dig_tabB_pb";
            this.dig_tabB_pb.Size = new System.Drawing.Size(78, 41);
            this.dig_tabB_pb.TabIndex = 1011;
            this.dig_tabB_pb.TabStop = false;
            this.dig_tabB_pb.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dig_tabB_pb_MouseClick);
            // 
            // ana_tabB_pb
            // 
            this.ana_tabB_pb.BackgroundImage = global::Revive_USB_Advance_CT.Properties.Resources.AD_TAB_ANA_OFF;
            this.ana_tabB_pb.Location = new System.Drawing.Point(15, 15);
            this.ana_tabB_pb.Name = "ana_tabB_pb";
            this.ana_tabB_pb.Size = new System.Drawing.Size(78, 41);
            this.ana_tabB_pb.TabIndex = 1009;
            this.ana_tabB_pb.TabStop = false;
            this.ana_tabB_pb.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ana_tabB_pb_MouseClick);
            // 
            // PinAN08A_pb
            // 
            this.PinAN08A_pb.BackColor = System.Drawing.SystemColors.Control;
            this.PinAN08A_pb.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_A08_ON;
            this.PinAN08A_pb.Location = new System.Drawing.Point(592, 344);
            this.PinAN08A_pb.Name = "PinAN08A_pb";
            this.PinAN08A_pb.Size = new System.Drawing.Size(25, 42);
            this.PinAN08A_pb.TabIndex = 999;
            this.PinAN08A_pb.TabStop = false;
            this.PinAN08A_pb.Tag = "7";
            this.PinAN08A_pb.Visible = false;
            // 
            // PinAN07A_pb
            // 
            this.PinAN07A_pb.BackColor = System.Drawing.SystemColors.Control;
            this.PinAN07A_pb.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_A07_ON;
            this.PinAN07A_pb.Location = new System.Drawing.Point(567, 344);
            this.PinAN07A_pb.Name = "PinAN07A_pb";
            this.PinAN07A_pb.Size = new System.Drawing.Size(25, 42);
            this.PinAN07A_pb.TabIndex = 998;
            this.PinAN07A_pb.TabStop = false;
            this.PinAN07A_pb.Tag = "6";
            this.PinAN07A_pb.Visible = false;
            // 
            // PinAN06A_pb
            // 
            this.PinAN06A_pb.BackColor = System.Drawing.SystemColors.Control;
            this.PinAN06A_pb.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_A06_ON;
            this.PinAN06A_pb.Location = new System.Drawing.Point(542, 344);
            this.PinAN06A_pb.Name = "PinAN06A_pb";
            this.PinAN06A_pb.Size = new System.Drawing.Size(25, 42);
            this.PinAN06A_pb.TabIndex = 997;
            this.PinAN06A_pb.TabStop = false;
            this.PinAN06A_pb.Tag = "5";
            this.PinAN06A_pb.Visible = false;
            // 
            // PinAN05A_pb
            // 
            this.PinAN05A_pb.BackColor = System.Drawing.SystemColors.Control;
            this.PinAN05A_pb.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_A05_ON;
            this.PinAN05A_pb.Location = new System.Drawing.Point(443, 344);
            this.PinAN05A_pb.Name = "PinAN05A_pb";
            this.PinAN05A_pb.Size = new System.Drawing.Size(25, 42);
            this.PinAN05A_pb.TabIndex = 996;
            this.PinAN05A_pb.TabStop = false;
            this.PinAN05A_pb.Tag = "4";
            this.PinAN05A_pb.Visible = false;
            // 
            // PinAN04A_pb
            // 
            this.PinAN04A_pb.BackColor = System.Drawing.SystemColors.Control;
            this.PinAN04A_pb.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_A04_ON;
            this.PinAN04A_pb.Location = new System.Drawing.Point(418, 344);
            this.PinAN04A_pb.Name = "PinAN04A_pb";
            this.PinAN04A_pb.Size = new System.Drawing.Size(25, 42);
            this.PinAN04A_pb.TabIndex = 995;
            this.PinAN04A_pb.TabStop = false;
            this.PinAN04A_pb.Tag = "3";
            this.PinAN04A_pb.Visible = false;
            // 
            // PinAN03A_pb
            // 
            this.PinAN03A_pb.BackColor = System.Drawing.SystemColors.Control;
            this.PinAN03A_pb.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_A03_ON;
            this.PinAN03A_pb.Location = new System.Drawing.Point(393, 344);
            this.PinAN03A_pb.Name = "PinAN03A_pb";
            this.PinAN03A_pb.Size = new System.Drawing.Size(25, 42);
            this.PinAN03A_pb.TabIndex = 994;
            this.PinAN03A_pb.TabStop = false;
            this.PinAN03A_pb.Tag = "2";
            this.PinAN03A_pb.Visible = false;
            // 
            // PinAN02A_pb
            // 
            this.PinAN02A_pb.BackColor = System.Drawing.SystemColors.Control;
            this.PinAN02A_pb.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_A02_ON;
            this.PinAN02A_pb.Location = new System.Drawing.Point(368, 344);
            this.PinAN02A_pb.Name = "PinAN02A_pb";
            this.PinAN02A_pb.Size = new System.Drawing.Size(25, 42);
            this.PinAN02A_pb.TabIndex = 993;
            this.PinAN02A_pb.TabStop = false;
            this.PinAN02A_pb.Tag = "1";
            this.PinAN02A_pb.Visible = false;
            // 
            // PinAN01A_pb
            // 
            this.PinAN01A_pb.BackColor = System.Drawing.SystemColors.Control;
            this.PinAN01A_pb.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_A01_ON;
            this.PinAN01A_pb.Location = new System.Drawing.Point(343, 344);
            this.PinAN01A_pb.Name = "PinAN01A_pb";
            this.PinAN01A_pb.Size = new System.Drawing.Size(25, 42);
            this.PinAN01A_pb.TabIndex = 992;
            this.PinAN01A_pb.TabStop = false;
            this.PinAN01A_pb.Tag = "0";
            this.PinAN01A_pb.Visible = false;
            // 
            // PinAN08B_pb
            // 
            this.PinAN08B_pb.BackColor = System.Drawing.SystemColors.Control;
            this.PinAN08B_pb.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_A08_OFF;
            this.PinAN08B_pb.Location = new System.Drawing.Point(592, 344);
            this.PinAN08B_pb.Name = "PinAN08B_pb";
            this.PinAN08B_pb.Size = new System.Drawing.Size(25, 42);
            this.PinAN08B_pb.TabIndex = 1007;
            this.PinAN08B_pb.TabStop = false;
            this.PinAN08B_pb.Tag = "7";
            this.PinAN08B_pb.Click += new System.EventHandler(this.AnalogPIN_Click);
            // 
            // PinAN07B_pb
            // 
            this.PinAN07B_pb.BackColor = System.Drawing.SystemColors.Control;
            this.PinAN07B_pb.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_A07_OFF;
            this.PinAN07B_pb.Location = new System.Drawing.Point(567, 344);
            this.PinAN07B_pb.Name = "PinAN07B_pb";
            this.PinAN07B_pb.Size = new System.Drawing.Size(25, 42);
            this.PinAN07B_pb.TabIndex = 1006;
            this.PinAN07B_pb.TabStop = false;
            this.PinAN07B_pb.Tag = "6";
            this.PinAN07B_pb.Click += new System.EventHandler(this.AnalogPIN_Click);
            // 
            // PinAN06B_pb
            // 
            this.PinAN06B_pb.BackColor = System.Drawing.SystemColors.Control;
            this.PinAN06B_pb.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_A06_OFF;
            this.PinAN06B_pb.Location = new System.Drawing.Point(542, 344);
            this.PinAN06B_pb.Name = "PinAN06B_pb";
            this.PinAN06B_pb.Size = new System.Drawing.Size(25, 42);
            this.PinAN06B_pb.TabIndex = 1005;
            this.PinAN06B_pb.TabStop = false;
            this.PinAN06B_pb.Tag = "5";
            this.PinAN06B_pb.Click += new System.EventHandler(this.AnalogPIN_Click);
            // 
            // PinAN05B_pb
            // 
            this.PinAN05B_pb.BackColor = System.Drawing.SystemColors.Control;
            this.PinAN05B_pb.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_A05_OFF;
            this.PinAN05B_pb.Location = new System.Drawing.Point(443, 344);
            this.PinAN05B_pb.Name = "PinAN05B_pb";
            this.PinAN05B_pb.Size = new System.Drawing.Size(25, 42);
            this.PinAN05B_pb.TabIndex = 1004;
            this.PinAN05B_pb.TabStop = false;
            this.PinAN05B_pb.Tag = "4";
            this.PinAN05B_pb.Click += new System.EventHandler(this.AnalogPIN_Click);
            // 
            // PinAN04B_pb
            // 
            this.PinAN04B_pb.BackColor = System.Drawing.SystemColors.Control;
            this.PinAN04B_pb.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_A04_OFF;
            this.PinAN04B_pb.Location = new System.Drawing.Point(418, 344);
            this.PinAN04B_pb.Name = "PinAN04B_pb";
            this.PinAN04B_pb.Size = new System.Drawing.Size(25, 42);
            this.PinAN04B_pb.TabIndex = 1003;
            this.PinAN04B_pb.TabStop = false;
            this.PinAN04B_pb.Tag = "3";
            this.PinAN04B_pb.Click += new System.EventHandler(this.AnalogPIN_Click);
            // 
            // PinAN03B_pb
            // 
            this.PinAN03B_pb.BackColor = System.Drawing.SystemColors.Control;
            this.PinAN03B_pb.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_A03_OFF;
            this.PinAN03B_pb.Location = new System.Drawing.Point(393, 344);
            this.PinAN03B_pb.Name = "PinAN03B_pb";
            this.PinAN03B_pb.Size = new System.Drawing.Size(25, 42);
            this.PinAN03B_pb.TabIndex = 1002;
            this.PinAN03B_pb.TabStop = false;
            this.PinAN03B_pb.Tag = "2";
            this.PinAN03B_pb.Click += new System.EventHandler(this.AnalogPIN_Click);
            // 
            // PinAN02B_pb
            // 
            this.PinAN02B_pb.BackColor = System.Drawing.SystemColors.Control;
            this.PinAN02B_pb.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_A02_OFF;
            this.PinAN02B_pb.Location = new System.Drawing.Point(368, 344);
            this.PinAN02B_pb.Name = "PinAN02B_pb";
            this.PinAN02B_pb.Size = new System.Drawing.Size(25, 42);
            this.PinAN02B_pb.TabIndex = 1001;
            this.PinAN02B_pb.TabStop = false;
            this.PinAN02B_pb.Tag = "1";
            this.PinAN02B_pb.Click += new System.EventHandler(this.AnalogPIN_Click);
            // 
            // PinAN01B_pb
            // 
            this.PinAN01B_pb.BackColor = System.Drawing.SystemColors.Control;
            this.PinAN01B_pb.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_A01_OFF;
            this.PinAN01B_pb.Location = new System.Drawing.Point(343, 344);
            this.PinAN01B_pb.Name = "PinAN01B_pb";
            this.PinAN01B_pb.Size = new System.Drawing.Size(25, 42);
            this.PinAN01B_pb.TabIndex = 1000;
            this.PinAN01B_pb.TabStop = false;
            this.PinAN01B_pb.Tag = "0";
            this.PinAN01B_pb.Click += new System.EventHandler(this.AnalogPIN_Click);
            // 
            // Pin06A_pb
            // 
            this.Pin06A_pb.BackColor = System.Drawing.SystemColors.Control;
            this.Pin06A_pb.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_D06_ON;
            this.Pin06A_pb.Location = new System.Drawing.Point(616, 81);
            this.Pin06A_pb.Name = "Pin06A_pb";
            this.Pin06A_pb.Size = new System.Drawing.Size(25, 42);
            this.Pin06A_pb.TabIndex = 127;
            this.Pin06A_pb.TabStop = false;
            this.Pin06A_pb.Tag = "5";
            this.Pin06A_pb.Visible = false;
            // 
            // Pin06B_pb
            // 
            this.Pin06B_pb.BackColor = System.Drawing.SystemColors.Control;
            this.Pin06B_pb.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_D06_OFF;
            this.Pin06B_pb.Location = new System.Drawing.Point(616, 81);
            this.Pin06B_pb.Name = "Pin06B_pb";
            this.Pin06B_pb.Size = new System.Drawing.Size(25, 42);
            this.Pin06B_pb.TabIndex = 121;
            this.Pin06B_pb.TabStop = false;
            this.Pin06B_pb.Tag = "5";
            this.Pin06B_pb.Click += new System.EventHandler(this.DigitalPIN_Click);
            // 
            // ButtonPressIcon15
            // 
            this.ButtonPressIcon15.BackColor = System.Drawing.Color.White;
            this.ButtonPressIcon15.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_ON;
            this.ButtonPressIcon15.Location = new System.Drawing.Point(344, 69);
            this.ButtonPressIcon15.Name = "ButtonPressIcon15";
            this.ButtonPressIcon15.Size = new System.Drawing.Size(25, 13);
            this.ButtonPressIcon15.TabIndex = 964;
            this.ButtonPressIcon15.TabStop = false;
            this.ButtonPressIcon15.Visible = false;
            // 
            // Pin15A_pb
            // 
            this.Pin15A_pb.BackColor = System.Drawing.SystemColors.Control;
            this.Pin15A_pb.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_D15_ON;
            this.Pin15A_pb.Location = new System.Drawing.Point(344, 82);
            this.Pin15A_pb.Name = "Pin15A_pb";
            this.Pin15A_pb.Size = new System.Drawing.Size(25, 42);
            this.Pin15A_pb.TabIndex = 962;
            this.Pin15A_pb.TabStop = false;
            this.Pin15A_pb.Tag = "14";
            this.Pin15A_pb.Visible = false;
            // 
            // Pin15B_pb
            // 
            this.Pin15B_pb.BackColor = System.Drawing.SystemColors.Control;
            this.Pin15B_pb.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_D15_OFF;
            this.Pin15B_pb.Location = new System.Drawing.Point(344, 82);
            this.Pin15B_pb.Name = "Pin15B_pb";
            this.Pin15B_pb.Size = new System.Drawing.Size(25, 42);
            this.Pin15B_pb.TabIndex = 963;
            this.Pin15B_pb.TabStop = false;
            this.Pin15B_pb.Tag = "14";
            this.Pin15B_pb.Click += new System.EventHandler(this.DigitalPIN_Click);
            // 
            // ButtonPressIcon14
            // 
            this.ButtonPressIcon14.BackColor = System.Drawing.Color.White;
            this.ButtonPressIcon14.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_ON;
            this.ButtonPressIcon14.Location = new System.Drawing.Point(370, 69);
            this.ButtonPressIcon14.Name = "ButtonPressIcon14";
            this.ButtonPressIcon14.Size = new System.Drawing.Size(25, 13);
            this.ButtonPressIcon14.TabIndex = 959;
            this.ButtonPressIcon14.TabStop = false;
            this.ButtonPressIcon14.Visible = false;
            // 
            // Pin14A_pb
            // 
            this.Pin14A_pb.BackColor = System.Drawing.SystemColors.Control;
            this.Pin14A_pb.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_D14_ON;
            this.Pin14A_pb.Location = new System.Drawing.Point(369, 82);
            this.Pin14A_pb.Name = "Pin14A_pb";
            this.Pin14A_pb.Size = new System.Drawing.Size(25, 42);
            this.Pin14A_pb.TabIndex = 957;
            this.Pin14A_pb.TabStop = false;
            this.Pin14A_pb.Tag = "13";
            this.Pin14A_pb.Visible = false;
            // 
            // Pin14B_pb
            // 
            this.Pin14B_pb.BackColor = System.Drawing.SystemColors.Control;
            this.Pin14B_pb.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_D14_OFF;
            this.Pin14B_pb.Location = new System.Drawing.Point(370, 82);
            this.Pin14B_pb.Name = "Pin14B_pb";
            this.Pin14B_pb.Size = new System.Drawing.Size(25, 42);
            this.Pin14B_pb.TabIndex = 958;
            this.Pin14B_pb.TabStop = false;
            this.Pin14B_pb.Tag = "13";
            this.Pin14B_pb.Click += new System.EventHandler(this.DigitalPIN_Click);
            // 
            // ButtonPressIcon13
            // 
            this.ButtonPressIcon13.BackColor = System.Drawing.Color.White;
            this.ButtonPressIcon13.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_ON;
            this.ButtonPressIcon13.Location = new System.Drawing.Point(394, 69);
            this.ButtonPressIcon13.Name = "ButtonPressIcon13";
            this.ButtonPressIcon13.Size = new System.Drawing.Size(25, 13);
            this.ButtonPressIcon13.TabIndex = 954;
            this.ButtonPressIcon13.TabStop = false;
            this.ButtonPressIcon13.Visible = false;
            // 
            // Pin13A_pb
            // 
            this.Pin13A_pb.BackColor = System.Drawing.SystemColors.Control;
            this.Pin13A_pb.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_D13_ON;
            this.Pin13A_pb.Location = new System.Drawing.Point(394, 82);
            this.Pin13A_pb.Name = "Pin13A_pb";
            this.Pin13A_pb.Size = new System.Drawing.Size(25, 42);
            this.Pin13A_pb.TabIndex = 952;
            this.Pin13A_pb.TabStop = false;
            this.Pin13A_pb.Tag = "12";
            this.Pin13A_pb.Visible = false;
            // 
            // Pin13B_pb
            // 
            this.Pin13B_pb.BackColor = System.Drawing.SystemColors.Control;
            this.Pin13B_pb.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_D13_OFF;
            this.Pin13B_pb.Location = new System.Drawing.Point(394, 82);
            this.Pin13B_pb.Name = "Pin13B_pb";
            this.Pin13B_pb.Size = new System.Drawing.Size(25, 42);
            this.Pin13B_pb.TabIndex = 953;
            this.Pin13B_pb.TabStop = false;
            this.Pin13B_pb.Tag = "12";
            this.Pin13B_pb.Click += new System.EventHandler(this.DigitalPIN_Click);
            // 
            // ButtonPressIcon12
            // 
            this.ButtonPressIcon12.BackColor = System.Drawing.Color.White;
            this.ButtonPressIcon12.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_ON;
            this.ButtonPressIcon12.Location = new System.Drawing.Point(420, 69);
            this.ButtonPressIcon12.Name = "ButtonPressIcon12";
            this.ButtonPressIcon12.Size = new System.Drawing.Size(25, 13);
            this.ButtonPressIcon12.TabIndex = 152;
            this.ButtonPressIcon12.TabStop = false;
            this.ButtonPressIcon12.Visible = false;
            // 
            // ButtonPressIcon11
            // 
            this.ButtonPressIcon11.BackColor = System.Drawing.Color.White;
            this.ButtonPressIcon11.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_ON;
            this.ButtonPressIcon11.Location = new System.Drawing.Point(444, 69);
            this.ButtonPressIcon11.Name = "ButtonPressIcon11";
            this.ButtonPressIcon11.Size = new System.Drawing.Size(25, 13);
            this.ButtonPressIcon11.TabIndex = 151;
            this.ButtonPressIcon11.TabStop = false;
            this.ButtonPressIcon11.Visible = false;
            // 
            // ButtonPressIcon10
            // 
            this.ButtonPressIcon10.BackColor = System.Drawing.Color.White;
            this.ButtonPressIcon10.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_ON;
            this.ButtonPressIcon10.Location = new System.Drawing.Point(469, 69);
            this.ButtonPressIcon10.Name = "ButtonPressIcon10";
            this.ButtonPressIcon10.Size = new System.Drawing.Size(25, 13);
            this.ButtonPressIcon10.TabIndex = 150;
            this.ButtonPressIcon10.TabStop = false;
            this.ButtonPressIcon10.Visible = false;
            // 
            // ButtonPressIcon9
            // 
            this.ButtonPressIcon9.BackColor = System.Drawing.Color.White;
            this.ButtonPressIcon9.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_ON;
            this.ButtonPressIcon9.Location = new System.Drawing.Point(541, 68);
            this.ButtonPressIcon9.Name = "ButtonPressIcon9";
            this.ButtonPressIcon9.Size = new System.Drawing.Size(25, 13);
            this.ButtonPressIcon9.TabIndex = 149;
            this.ButtonPressIcon9.TabStop = false;
            this.ButtonPressIcon9.Visible = false;
            // 
            // ButtonPressIcon8
            // 
            this.ButtonPressIcon8.BackColor = System.Drawing.Color.White;
            this.ButtonPressIcon8.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_ON;
            this.ButtonPressIcon8.Location = new System.Drawing.Point(567, 68);
            this.ButtonPressIcon8.Name = "ButtonPressIcon8";
            this.ButtonPressIcon8.Size = new System.Drawing.Size(25, 13);
            this.ButtonPressIcon8.TabIndex = 148;
            this.ButtonPressIcon8.TabStop = false;
            this.ButtonPressIcon8.Visible = false;
            // 
            // Pin12A_pb
            // 
            this.Pin12A_pb.BackColor = System.Drawing.SystemColors.Control;
            this.Pin12A_pb.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_D12_ON;
            this.Pin12A_pb.Location = new System.Drawing.Point(419, 82);
            this.Pin12A_pb.Name = "Pin12A_pb";
            this.Pin12A_pb.Size = new System.Drawing.Size(25, 42);
            this.Pin12A_pb.TabIndex = 142;
            this.Pin12A_pb.TabStop = false;
            this.Pin12A_pb.Tag = "11";
            this.Pin12A_pb.Visible = false;
            // 
            // Pin11A_pb
            // 
            this.Pin11A_pb.BackColor = System.Drawing.SystemColors.Control;
            this.Pin11A_pb.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_D11_ON;
            this.Pin11A_pb.Location = new System.Drawing.Point(444, 82);
            this.Pin11A_pb.Name = "Pin11A_pb";
            this.Pin11A_pb.Size = new System.Drawing.Size(25, 42);
            this.Pin11A_pb.TabIndex = 141;
            this.Pin11A_pb.TabStop = false;
            this.Pin11A_pb.Tag = "10";
            this.Pin11A_pb.Visible = false;
            // 
            // Pin10A_pb
            // 
            this.Pin10A_pb.BackColor = System.Drawing.SystemColors.Control;
            this.Pin10A_pb.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_D10_ON;
            this.Pin10A_pb.Location = new System.Drawing.Point(469, 82);
            this.Pin10A_pb.Name = "Pin10A_pb";
            this.Pin10A_pb.Size = new System.Drawing.Size(25, 42);
            this.Pin10A_pb.TabIndex = 140;
            this.Pin10A_pb.TabStop = false;
            this.Pin10A_pb.Tag = "9";
            this.Pin10A_pb.Visible = false;
            // 
            // Pin09A_pb
            // 
            this.Pin09A_pb.BackColor = System.Drawing.SystemColors.Control;
            this.Pin09A_pb.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_D09_ON;
            this.Pin09A_pb.Location = new System.Drawing.Point(541, 81);
            this.Pin09A_pb.Name = "Pin09A_pb";
            this.Pin09A_pb.Size = new System.Drawing.Size(25, 42);
            this.Pin09A_pb.TabIndex = 139;
            this.Pin09A_pb.TabStop = false;
            this.Pin09A_pb.Tag = "8";
            this.Pin09A_pb.Visible = false;
            // 
            // Pin08A_pb
            // 
            this.Pin08A_pb.BackColor = System.Drawing.SystemColors.Control;
            this.Pin08A_pb.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_D08_ON;
            this.Pin08A_pb.Location = new System.Drawing.Point(566, 81);
            this.Pin08A_pb.Name = "Pin08A_pb";
            this.Pin08A_pb.Size = new System.Drawing.Size(25, 42);
            this.Pin08A_pb.TabIndex = 138;
            this.Pin08A_pb.TabStop = false;
            this.Pin08A_pb.Tag = "7";
            this.Pin08A_pb.Visible = false;
            // 
            // Pin01A_pb
            // 
            this.Pin01A_pb.BackColor = System.Drawing.SystemColors.Control;
            this.Pin01A_pb.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_D01_ON;
            this.Pin01A_pb.Location = new System.Drawing.Point(642, 344);
            this.Pin01A_pb.Name = "Pin01A_pb";
            this.Pin01A_pb.Size = new System.Drawing.Size(25, 42);
            this.Pin01A_pb.TabIndex = 132;
            this.Pin01A_pb.TabStop = false;
            this.Pin01A_pb.Tag = "0";
            this.Pin01A_pb.Visible = false;
            // 
            // Pin02A_pb
            // 
            this.Pin02A_pb.BackColor = System.Drawing.SystemColors.Control;
            this.Pin02A_pb.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_D02_ON;
            this.Pin02A_pb.Location = new System.Drawing.Point(667, 344);
            this.Pin02A_pb.Name = "Pin02A_pb";
            this.Pin02A_pb.Size = new System.Drawing.Size(25, 42);
            this.Pin02A_pb.TabIndex = 131;
            this.Pin02A_pb.TabStop = false;
            this.Pin02A_pb.Tag = "1";
            this.Pin02A_pb.Visible = false;
            // 
            // Pin03A_pb
            // 
            this.Pin03A_pb.BackColor = System.Drawing.SystemColors.Control;
            this.Pin03A_pb.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_D03_ON;
            this.Pin03A_pb.Location = new System.Drawing.Point(692, 344);
            this.Pin03A_pb.Name = "Pin03A_pb";
            this.Pin03A_pb.Size = new System.Drawing.Size(25, 42);
            this.Pin03A_pb.TabIndex = 130;
            this.Pin03A_pb.TabStop = false;
            this.Pin03A_pb.Tag = "2";
            this.Pin03A_pb.Visible = false;
            // 
            // Pin04A_pb
            // 
            this.Pin04A_pb.BackColor = System.Drawing.SystemColors.Control;
            this.Pin04A_pb.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_D04_ON;
            this.Pin04A_pb.Location = new System.Drawing.Point(666, 81);
            this.Pin04A_pb.Name = "Pin04A_pb";
            this.Pin04A_pb.Size = new System.Drawing.Size(25, 42);
            this.Pin04A_pb.TabIndex = 129;
            this.Pin04A_pb.TabStop = false;
            this.Pin04A_pb.Tag = "3";
            this.Pin04A_pb.Visible = false;
            // 
            // Pin05A_pb
            // 
            this.Pin05A_pb.BackColor = System.Drawing.SystemColors.Control;
            this.Pin05A_pb.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_D05_ON;
            this.Pin05A_pb.Location = new System.Drawing.Point(641, 81);
            this.Pin05A_pb.Name = "Pin05A_pb";
            this.Pin05A_pb.Size = new System.Drawing.Size(25, 42);
            this.Pin05A_pb.TabIndex = 128;
            this.Pin05A_pb.TabStop = false;
            this.Pin05A_pb.Tag = "4";
            this.Pin05A_pb.Visible = false;
            // 
            // Pin02B_pb
            // 
            this.Pin02B_pb.BackColor = System.Drawing.SystemColors.Control;
            this.Pin02B_pb.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_D02_OFF;
            this.Pin02B_pb.Location = new System.Drawing.Point(667, 344);
            this.Pin02B_pb.Name = "Pin02B_pb";
            this.Pin02B_pb.Size = new System.Drawing.Size(25, 42);
            this.Pin02B_pb.TabIndex = 126;
            this.Pin02B_pb.TabStop = false;
            this.Pin02B_pb.Tag = "1";
            this.Pin02B_pb.Click += new System.EventHandler(this.DigitalPIN_Click);
            // 
            // Pin03B_pb
            // 
            this.Pin03B_pb.BackColor = System.Drawing.SystemColors.Control;
            this.Pin03B_pb.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_D03_OFF;
            this.Pin03B_pb.Location = new System.Drawing.Point(692, 344);
            this.Pin03B_pb.Name = "Pin03B_pb";
            this.Pin03B_pb.Size = new System.Drawing.Size(25, 42);
            this.Pin03B_pb.TabIndex = 125;
            this.Pin03B_pb.TabStop = false;
            this.Pin03B_pb.Tag = "2";
            this.Pin03B_pb.Click += new System.EventHandler(this.DigitalPIN_Click);
            // 
            // Pin04B_pb
            // 
            this.Pin04B_pb.BackColor = System.Drawing.SystemColors.Control;
            this.Pin04B_pb.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_D04_OFF;
            this.Pin04B_pb.Location = new System.Drawing.Point(666, 81);
            this.Pin04B_pb.Name = "Pin04B_pb";
            this.Pin04B_pb.Size = new System.Drawing.Size(25, 42);
            this.Pin04B_pb.TabIndex = 124;
            this.Pin04B_pb.TabStop = false;
            this.Pin04B_pb.Tag = "3";
            this.Pin04B_pb.Click += new System.EventHandler(this.DigitalPIN_Click);
            // 
            // Pin01B_pb
            // 
            this.Pin01B_pb.BackColor = System.Drawing.SystemColors.Control;
            this.Pin01B_pb.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_D01_OFF;
            this.Pin01B_pb.Location = new System.Drawing.Point(642, 344);
            this.Pin01B_pb.Name = "Pin01B_pb";
            this.Pin01B_pb.Size = new System.Drawing.Size(25, 42);
            this.Pin01B_pb.TabIndex = 123;
            this.Pin01B_pb.TabStop = false;
            this.Pin01B_pb.Tag = "0";
            this.Pin01B_pb.Click += new System.EventHandler(this.DigitalPIN_Click);
            // 
            // Pin05B_pb
            // 
            this.Pin05B_pb.BackColor = System.Drawing.SystemColors.Control;
            this.Pin05B_pb.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_D05_OFF;
            this.Pin05B_pb.Location = new System.Drawing.Point(641, 81);
            this.Pin05B_pb.Name = "Pin05B_pb";
            this.Pin05B_pb.Size = new System.Drawing.Size(25, 42);
            this.Pin05B_pb.TabIndex = 122;
            this.Pin05B_pb.TabStop = false;
            this.Pin05B_pb.Tag = "4";
            this.Pin05B_pb.Click += new System.EventHandler(this.DigitalPIN_Click);
            // 
            // Pin07A_pb
            // 
            this.Pin07A_pb.BackColor = System.Drawing.SystemColors.Control;
            this.Pin07A_pb.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_D07_ON;
            this.Pin07A_pb.Location = new System.Drawing.Point(591, 81);
            this.Pin07A_pb.Name = "Pin07A_pb";
            this.Pin07A_pb.Size = new System.Drawing.Size(25, 42);
            this.Pin07A_pb.TabIndex = 120;
            this.Pin07A_pb.TabStop = false;
            this.Pin07A_pb.Tag = "6";
            this.Pin07A_pb.Visible = false;
            // 
            // Pin07B_pb
            // 
            this.Pin07B_pb.BackColor = System.Drawing.SystemColors.Control;
            this.Pin07B_pb.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_D07_OFF;
            this.Pin07B_pb.Location = new System.Drawing.Point(591, 81);
            this.Pin07B_pb.Name = "Pin07B_pb";
            this.Pin07B_pb.Size = new System.Drawing.Size(25, 42);
            this.Pin07B_pb.TabIndex = 119;
            this.Pin07B_pb.TabStop = false;
            this.Pin07B_pb.Tag = "6";
            this.Pin07B_pb.Click += new System.EventHandler(this.DigitalPIN_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.Image = global::Revive_USB_Advance_CT.Properties.Resources.F_wariate;
            this.pictureBox5.Location = new System.Drawing.Point(342, 619);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(34, 13);
            this.pictureBox5.TabIndex = 113;
            this.pictureBox5.TabStop = false;
            // 
            // Status_C_pb
            // 
            this.Status_C_pb.BackColor = System.Drawing.Color.Transparent;
            this.Status_C_pb.Image = global::Revive_USB_Advance_CT.Properties.Resources.ON;
            this.Status_C_pb.Location = new System.Drawing.Point(963, 589);
            this.Status_C_pb.Name = "Status_C_pb";
            this.Status_C_pb.Size = new System.Drawing.Size(27, 8);
            this.Status_C_pb.TabIndex = 94;
            this.Status_C_pb.TabStop = false;
            this.Status_C_pb.Visible = false;
            // 
            // ButtonPressIcon5
            // 
            this.ButtonPressIcon5.BackColor = System.Drawing.Color.White;
            this.ButtonPressIcon5.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_ON;
            this.ButtonPressIcon5.Location = new System.Drawing.Point(641, 68);
            this.ButtonPressIcon5.Name = "ButtonPressIcon5";
            this.ButtonPressIcon5.Size = new System.Drawing.Size(25, 13);
            this.ButtonPressIcon5.TabIndex = 92;
            this.ButtonPressIcon5.TabStop = false;
            this.ButtonPressIcon5.Visible = false;
            // 
            // ButtonPressIcon6
            // 
            this.ButtonPressIcon6.BackColor = System.Drawing.Color.White;
            this.ButtonPressIcon6.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_ON;
            this.ButtonPressIcon6.Location = new System.Drawing.Point(617, 68);
            this.ButtonPressIcon6.Name = "ButtonPressIcon6";
            this.ButtonPressIcon6.Size = new System.Drawing.Size(25, 13);
            this.ButtonPressIcon6.TabIndex = 91;
            this.ButtonPressIcon6.TabStop = false;
            this.ButtonPressIcon6.Visible = false;
            // 
            // ButtonPressIcon7
            // 
            this.ButtonPressIcon7.BackColor = System.Drawing.Color.White;
            this.ButtonPressIcon7.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_ON;
            this.ButtonPressIcon7.Location = new System.Drawing.Point(591, 68);
            this.ButtonPressIcon7.Name = "ButtonPressIcon7";
            this.ButtonPressIcon7.Size = new System.Drawing.Size(25, 13);
            this.ButtonPressIcon7.TabIndex = 90;
            this.ButtonPressIcon7.TabStop = false;
            this.ButtonPressIcon7.Visible = false;
            // 
            // ButtonPressIcon4
            // 
            this.ButtonPressIcon4.BackColor = System.Drawing.Color.White;
            this.ButtonPressIcon4.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_ON;
            this.ButtonPressIcon4.Location = new System.Drawing.Point(666, 68);
            this.ButtonPressIcon4.Name = "ButtonPressIcon4";
            this.ButtonPressIcon4.Size = new System.Drawing.Size(25, 13);
            this.ButtonPressIcon4.TabIndex = 87;
            this.ButtonPressIcon4.TabStop = false;
            this.ButtonPressIcon4.Visible = false;
            // 
            // ButtonPressIcon3
            // 
            this.ButtonPressIcon3.BackColor = System.Drawing.Color.White;
            this.ButtonPressIcon3.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_ON;
            this.ButtonPressIcon3.Location = new System.Drawing.Point(692, 388);
            this.ButtonPressIcon3.Name = "ButtonPressIcon3";
            this.ButtonPressIcon3.Size = new System.Drawing.Size(25, 13);
            this.ButtonPressIcon3.TabIndex = 86;
            this.ButtonPressIcon3.TabStop = false;
            this.ButtonPressIcon3.Visible = false;
            // 
            // ButtonPressIcon2
            // 
            this.ButtonPressIcon2.BackColor = System.Drawing.Color.White;
            this.ButtonPressIcon2.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_ON;
            this.ButtonPressIcon2.InitialImage = null;
            this.ButtonPressIcon2.Location = new System.Drawing.Point(667, 388);
            this.ButtonPressIcon2.Name = "ButtonPressIcon2";
            this.ButtonPressIcon2.Size = new System.Drawing.Size(25, 13);
            this.ButtonPressIcon2.TabIndex = 85;
            this.ButtonPressIcon2.TabStop = false;
            this.ButtonPressIcon2.Visible = false;
            // 
            // ButtonPressIcon1
            // 
            this.ButtonPressIcon1.BackColor = System.Drawing.Color.Transparent;
            this.ButtonPressIcon1.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_ON;
            this.ButtonPressIcon1.Location = new System.Drawing.Point(642, 388);
            this.ButtonPressIcon1.Name = "ButtonPressIcon1";
            this.ButtonPressIcon1.Size = new System.Drawing.Size(25, 13);
            this.ButtonPressIcon1.TabIndex = 84;
            this.ButtonPressIcon1.TabStop = false;
            this.ButtonPressIcon1.Visible = false;
            // 
            // Pin08B_pb
            // 
            this.Pin08B_pb.BackColor = System.Drawing.SystemColors.Control;
            this.Pin08B_pb.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_D08_OFF;
            this.Pin08B_pb.Location = new System.Drawing.Point(566, 81);
            this.Pin08B_pb.Name = "Pin08B_pb";
            this.Pin08B_pb.Size = new System.Drawing.Size(25, 42);
            this.Pin08B_pb.TabIndex = 143;
            this.Pin08B_pb.TabStop = false;
            this.Pin08B_pb.Tag = "7";
            this.Pin08B_pb.Click += new System.EventHandler(this.DigitalPIN_Click);
            // 
            // Pin09B_pb
            // 
            this.Pin09B_pb.BackColor = System.Drawing.SystemColors.Control;
            this.Pin09B_pb.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_D09_OFF;
            this.Pin09B_pb.Location = new System.Drawing.Point(541, 81);
            this.Pin09B_pb.Name = "Pin09B_pb";
            this.Pin09B_pb.Size = new System.Drawing.Size(25, 42);
            this.Pin09B_pb.TabIndex = 144;
            this.Pin09B_pb.TabStop = false;
            this.Pin09B_pb.Tag = "8";
            this.Pin09B_pb.Click += new System.EventHandler(this.DigitalPIN_Click);
            // 
            // Pin10B_pb
            // 
            this.Pin10B_pb.BackColor = System.Drawing.SystemColors.Control;
            this.Pin10B_pb.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_D10_OFF;
            this.Pin10B_pb.Location = new System.Drawing.Point(469, 82);
            this.Pin10B_pb.Name = "Pin10B_pb";
            this.Pin10B_pb.Size = new System.Drawing.Size(25, 42);
            this.Pin10B_pb.TabIndex = 145;
            this.Pin10B_pb.TabStop = false;
            this.Pin10B_pb.Tag = "9";
            this.Pin10B_pb.Click += new System.EventHandler(this.DigitalPIN_Click);
            // 
            // Pin11B_pb
            // 
            this.Pin11B_pb.BackColor = System.Drawing.SystemColors.Control;
            this.Pin11B_pb.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_D11_OFF;
            this.Pin11B_pb.Location = new System.Drawing.Point(444, 82);
            this.Pin11B_pb.Name = "Pin11B_pb";
            this.Pin11B_pb.Size = new System.Drawing.Size(25, 42);
            this.Pin11B_pb.TabIndex = 146;
            this.Pin11B_pb.TabStop = false;
            this.Pin11B_pb.Tag = "10";
            this.Pin11B_pb.Click += new System.EventHandler(this.DigitalPIN_Click);
            // 
            // Pin12B_pb
            // 
            this.Pin12B_pb.BackColor = System.Drawing.SystemColors.Control;
            this.Pin12B_pb.Image = global::Revive_USB_Advance_CT.Properties.Resources.AD_D12_OFF;
            this.Pin12B_pb.Location = new System.Drawing.Point(419, 82);
            this.Pin12B_pb.Name = "Pin12B_pb";
            this.Pin12B_pb.Size = new System.Drawing.Size(25, 42);
            this.Pin12B_pb.TabIndex = 147;
            this.Pin12B_pb.TabStop = false;
            this.Pin12B_pb.Tag = "11";
            this.Pin12B_pb.Click += new System.EventHandler(this.DigitalPIN_Click);
            // 
            // Status_NC_pb
            // 
            this.Status_NC_pb.BackColor = System.Drawing.Color.Transparent;
            this.Status_NC_pb.Image = global::Revive_USB_Advance_CT.Properties.Resources.OFF;
            this.Status_NC_pb.Location = new System.Drawing.Point(963, 589);
            this.Status_NC_pb.Name = "Status_NC_pb";
            this.Status_NC_pb.Size = new System.Drawing.Size(27, 8);
            this.Status_NC_pb.TabIndex = 95;
            this.Status_NC_pb.TabStop = false;
            this.Status_NC_pb.Visible = false;
            // 
            // BackGround_pb
            // 
            this.BackGround_pb.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BackGround_pb.BackgroundImage")));
            this.BackGround_pb.Location = new System.Drawing.Point(0, 0);
            this.BackGround_pb.Name = "BackGround_pb";
            this.BackGround_pb.Size = new System.Drawing.Size(1000, 600);
            this.BackGround_pb.TabIndex = 163;
            this.BackGround_pb.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1344, 809);
            this.Controls.Add(this.Revive_Advance_Device_pb);
            this.Controls.Add(this.pnl_digital_setting);
            this.Controls.Add(this.pnl_analog_setting);
            this.Controls.Add(this.dig_tabA_pb);
            this.Controls.Add(this.ana_tabA_pb);
            this.Controls.Add(this.dig_tabB_pb);
            this.Controls.Add(this.ana_tabB_pb);
            this.Controls.Add(this.PinAN08A_pb);
            this.Controls.Add(this.PinAN07A_pb);
            this.Controls.Add(this.PinAN06A_pb);
            this.Controls.Add(this.PinAN05A_pb);
            this.Controls.Add(this.PinAN04A_pb);
            this.Controls.Add(this.PinAN03A_pb);
            this.Controls.Add(this.PinAN02A_pb);
            this.Controls.Add(this.PinAN01A_pb);
            this.Controls.Add(this.PinAN08B_pb);
            this.Controls.Add(this.PinAN07B_pb);
            this.Controls.Add(this.PinAN06B_pb);
            this.Controls.Add(this.PinAN05B_pb);
            this.Controls.Add(this.PinAN04B_pb);
            this.Controls.Add(this.PinAN03B_pb);
            this.Controls.Add(this.PinAN02B_pb);
            this.Controls.Add(this.PinAN01B_pb);
            this.Controls.Add(this.gbx_setting_list);
            this.Controls.Add(this.Pin06A_pb);
            this.Controls.Add(this.Pin06B_pb);
            this.Controls.Add(this.btn_default_reset);
            this.Controls.Add(this.lbl_FW_Version);
            this.Controls.Add(this.lbl_analog8_assign);
            this.Controls.Add(this.lbl_analog8_status);
            this.Controls.Add(this.lbl_analog7_assign);
            this.Controls.Add(this.lbl_analog7_status);
            this.Controls.Add(this.lbl_analog6_assign);
            this.Controls.Add(this.lbl_analog6_status);
            this.Controls.Add(this.lbl_analog5_assign);
            this.Controls.Add(this.lbl_analog5_status);
            this.Controls.Add(this.lbl_analog4_assign);
            this.Controls.Add(this.lbl_analog4_status);
            this.Controls.Add(this.lbl_analog3_assign);
            this.Controls.Add(this.lbl_analog3_status);
            this.Controls.Add(this.lbl_analog2_assign);
            this.Controls.Add(this.lbl_analog2_status);
            this.Controls.Add(this.lbl_analog1_assign);
            this.Controls.Add(this.lbl_analog1_status);
            this.Controls.Add(this.DeviceAssign_lbl15);
            this.Controls.Add(this.devicetype_lbl15);
            this.Controls.Add(this.ButtonPressIcon15);
            this.Controls.Add(this.Pin15A_pb);
            this.Controls.Add(this.Pin15B_pb);
            this.Controls.Add(this.DeviceAssign_lbl14);
            this.Controls.Add(this.devicetype_lbl14);
            this.Controls.Add(this.ButtonPressIcon14);
            this.Controls.Add(this.Pin14A_pb);
            this.Controls.Add(this.Pin14B_pb);
            this.Controls.Add(this.DeviceAssign_lbl13);
            this.Controls.Add(this.devicetype_lbl13);
            this.Controls.Add(this.ButtonPressIcon13);
            this.Controls.Add(this.Pin13A_pb);
            this.Controls.Add(this.Pin13B_pb);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_soft_reset);
            this.Controls.Add(this.DeviceAssign_lbl12);
            this.Controls.Add(this.DeviceAssign_lbl11);
            this.Controls.Add(this.DeviceAssign_lbl10);
            this.Controls.Add(this.devicetype_lbl12);
            this.Controls.Add(this.devicetype_lbl11);
            this.Controls.Add(this.devicetype_lbl10);
            this.Controls.Add(this.DeviceAssign_lbl6);
            this.Controls.Add(this.DeviceAssign_lbl5);
            this.Controls.Add(this.devicetype_lbl6);
            this.Controls.Add(this.devicetype_lbl5);
            this.Controls.Add(this.ButtonPressIcon12);
            this.Controls.Add(this.ButtonPressIcon11);
            this.Controls.Add(this.ButtonPressIcon10);
            this.Controls.Add(this.ButtonPressIcon9);
            this.Controls.Add(this.ButtonPressIcon8);
            this.Controls.Add(this.Pin12A_pb);
            this.Controls.Add(this.Pin11A_pb);
            this.Controls.Add(this.Pin10A_pb);
            this.Controls.Add(this.Pin09A_pb);
            this.Controls.Add(this.Pin08A_pb);
            this.Controls.Add(this.Pin01A_pb);
            this.Controls.Add(this.Pin02A_pb);
            this.Controls.Add(this.Pin03A_pb);
            this.Controls.Add(this.Pin04A_pb);
            this.Controls.Add(this.Pin05A_pb);
            this.Controls.Add(this.Pin02B_pb);
            this.Controls.Add(this.Pin03B_pb);
            this.Controls.Add(this.Pin04B_pb);
            this.Controls.Add(this.Pin01B_pb);
            this.Controls.Add(this.Pin05B_pb);
            this.Controls.Add(this.Pin07A_pb);
            this.Controls.Add(this.Pin07B_pb);
            this.Controls.Add(this.StatusBox_lbl2);
            this.Controls.Add(this.StatusBox_lbl);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.DeviceAssign_lbl7);
            this.Controls.Add(this.DeviceAssign_lbl8);
            this.Controls.Add(this.DeviceAssign_lbl9);
            this.Controls.Add(this.DeviceAssign_lbl2);
            this.Controls.Add(this.DeviceAssign_lbl3);
            this.Controls.Add(this.DeviceAssign_lbl1);
            this.Controls.Add(this.DeviceAssign_lbl4);
            this.Controls.Add(this.devicetype_lbl7);
            this.Controls.Add(this.devicetype_lbl8);
            this.Controls.Add(this.devicetype_lbl9);
            this.Controls.Add(this.devicetype_lbl2);
            this.Controls.Add(this.devicetype_lbl3);
            this.Controls.Add(this.devicetype_lbl1);
            this.Controls.Add(this.devicetype_lbl4);
            this.Controls.Add(this.Status_C_pb);
            this.Controls.Add(this.ButtonPressIcon5);
            this.Controls.Add(this.ButtonPressIcon6);
            this.Controls.Add(this.ButtonPressIcon7);
            this.Controls.Add(this.ButtonPressIcon4);
            this.Controls.Add(this.ButtonPressIcon3);
            this.Controls.Add(this.ButtonPressIcon2);
            this.Controls.Add(this.ButtonPressIcon1);
            this.Controls.Add(this.Pin08B_pb);
            this.Controls.Add(this.Pin09B_pb);
            this.Controls.Add(this.Pin10B_pb);
            this.Controls.Add(this.Pin11B_pb);
            this.Controls.Add(this.Pin12B_pb);
            this.Controls.Add(this.Status_NC_pb);
            this.Controls.Add(this.BackGround_pb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1350, 838);
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "REVIVE USB ADVANCE, Configuration Tool ver ";
            ((System.ComponentModel.ISupportInitialize)(this.MouseMove_UD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_analog_sensitivity)).EndInit();
            this.gbx_analog_calibration.ResumeLayout(false);
            this.gbx_analog_calibration.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_analog_dead_zone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_analog_arrow5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_analog_arrow4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_analog_arrow3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_analog_arrow2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_analog_arrow1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_output_val5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_output_val4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_input_vol4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_output_val3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_input_vol3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_output_val2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_output_val1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_input_vol2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Arrow_Com_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Arrow_Mouse1_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Arrow_Mouse2_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Arrow_Mouse3_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Arrow_Keyboard_pb)).EndInit();
            this.gbx_setting_list.ResumeLayout(false);
            this.pnl_analog_setting.ResumeLayout(false);
            this.pnl_analog_setting.PerformLayout();
            this.pnl_digital_setting.ResumeLayout(false);
            this.pnl_digital_setting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Revive_Advance_Device_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dig_tabA_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ana_tabA_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dig_tabB_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ana_tabB_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinAN08A_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinAN07A_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinAN06A_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinAN05A_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinAN04A_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinAN03A_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinAN02A_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinAN01A_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinAN08B_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinAN07B_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinAN06B_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinAN05B_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinAN04B_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinAN03B_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinAN02B_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinAN01B_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin06A_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin06B_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonPressIcon15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin15A_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin15B_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonPressIcon14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin14A_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin14B_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonPressIcon13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin13A_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin13B_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonPressIcon12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonPressIcon11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonPressIcon10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonPressIcon9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonPressIcon8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin12A_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin11A_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin10A_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin09A_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin08A_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin01A_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin02A_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin03A_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin04A_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin05A_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin02B_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin03B_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin04B_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin01B_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin05B_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin07A_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin07B_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Status_C_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonPressIcon5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonPressIcon6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonPressIcon7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonPressIcon4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonPressIcon3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonPressIcon2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonPressIcon1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin08B_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin09B_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin10B_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin11B_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pin12B_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Status_NC_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackGround_pb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_digital_set;
        private System.ComponentModel.BackgroundWorker ReadWriteThread;
        private System.Windows.Forms.Timer FormUpdateTimer;
        private System.Windows.Forms.ToolTip PushbuttonStateTooltip;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox cmbbx_digital_device_type;
        private System.Windows.Forms.ComboBox cmbbx_digital_assign;
        private System.Windows.Forms.TextBox KeyboardValue_txtbx;
        private System.Windows.Forms.CheckBox Ctrl_cbox;
        private System.Windows.Forms.CheckBox Win_cbox;
        private System.Windows.Forms.CheckBox Shift_cbox;
        private System.Windows.Forms.CheckBox Alt_cbox;
        private System.Windows.Forms.CheckBox LeverXM_cbox;
        private System.Windows.Forms.CheckBox LeverXP_cbox;
        private System.Windows.Forms.CheckBox LeverYM_cbox;
        private System.Windows.Forms.CheckBox LeverYP_cbox;
        private System.Windows.Forms.CheckBox Button6_cbox;
        private System.Windows.Forms.CheckBox Button5_cbox;
        private System.Windows.Forms.CheckBox Button4_cbox;
        private System.Windows.Forms.CheckBox Button3_cbox;
        private System.Windows.Forms.CheckBox Button2_cbox;
        private System.Windows.Forms.CheckBox Button1_cbox;
        private System.Windows.Forms.ComboBox cmbbx_digital_pin;
        private System.Windows.Forms.CheckBox Button12_cbox;
        private System.Windows.Forms.CheckBox Button11_cbox;
        private System.Windows.Forms.CheckBox Button10_cbox;
        private System.Windows.Forms.CheckBox Button9_cbox;
        private System.Windows.Forms.CheckBox Button8_cbox;
        private System.Windows.Forms.CheckBox Button7_cbox;
        private System.Windows.Forms.NumericUpDown MouseMove_UD;
        private System.Windows.Forms.PictureBox ButtonPressIcon1;
        private System.Windows.Forms.PictureBox ButtonPressIcon2;
        private System.Windows.Forms.PictureBox ButtonPressIcon3;
        private System.Windows.Forms.PictureBox ButtonPressIcon4;
        private System.Windows.Forms.PictureBox ButtonPressIcon7;
        private System.Windows.Forms.PictureBox ButtonPressIcon6;
        private System.Windows.Forms.PictureBox ButtonPressIcon5;
        private System.Windows.Forms.PictureBox Status_C_pb;
        private System.Windows.Forms.PictureBox Status_NC_pb;
        private System.Windows.Forms.Label devicetype_lbl4;
        private System.Windows.Forms.Label devicetype_lbl1;
        private System.Windows.Forms.Label devicetype_lbl3;
        private System.Windows.Forms.Label devicetype_lbl2;
        private System.Windows.Forms.Label devicetype_lbl9;
        private System.Windows.Forms.Label devicetype_lbl8;
        private System.Windows.Forms.Label devicetype_lbl7;
        private System.Windows.Forms.Label DeviceAssign_lbl4;
        private System.Windows.Forms.Label DeviceAssign_lbl1;
        private System.Windows.Forms.Label DeviceAssign_lbl3;
        private System.Windows.Forms.Label DeviceAssign_lbl2;
        private System.Windows.Forms.Label DeviceAssign_lbl9;
        private System.Windows.Forms.Label DeviceAssign_lbl8;
        private System.Windows.Forms.Label DeviceAssign_lbl7;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox Arrow_Keyboard_pb;
        private System.Windows.Forms.PictureBox Arrow_Com_pb;
        private System.Windows.Forms.Label StatusBox_lbl;
        private System.Windows.Forms.Label StatusBox_lbl2;
        private System.Windows.Forms.PictureBox Pin07B_pb;
        private System.Windows.Forms.PictureBox Pin07A_pb;
        private System.Windows.Forms.PictureBox Pin06B_pb;
        private System.Windows.Forms.PictureBox Pin05B_pb;
        private System.Windows.Forms.PictureBox Pin01B_pb;
        private System.Windows.Forms.PictureBox Pin04B_pb;
        private System.Windows.Forms.PictureBox Pin03B_pb;
        private System.Windows.Forms.PictureBox Pin02B_pb;
        private System.Windows.Forms.PictureBox Pin06A_pb;
        private System.Windows.Forms.PictureBox Pin05A_pb;
        private System.Windows.Forms.PictureBox Pin04A_pb;
        private System.Windows.Forms.PictureBox Pin03A_pb;
        private System.Windows.Forms.PictureBox Pin02A_pb;
        private System.Windows.Forms.PictureBox Pin01A_pb;
        private System.Windows.Forms.PictureBox Arrow_Mouse1_pb;
        private System.Windows.Forms.PictureBox Arrow_Mouse2_pb;
        private System.Windows.Forms.PictureBox Arrow_Mouse3_pb;
        private System.Windows.Forms.PictureBox Pin08A_pb;
        private System.Windows.Forms.PictureBox Pin09A_pb;
        private System.Windows.Forms.PictureBox Pin10A_pb;
        private System.Windows.Forms.PictureBox Pin11A_pb;
        private System.Windows.Forms.PictureBox Pin12A_pb;
        private System.Windows.Forms.PictureBox Pin08B_pb;
        private System.Windows.Forms.PictureBox Pin09B_pb;
        private System.Windows.Forms.PictureBox Pin10B_pb;
        private System.Windows.Forms.PictureBox Pin11B_pb;
        private System.Windows.Forms.PictureBox Pin12B_pb;
        private System.Windows.Forms.PictureBox ButtonPressIcon8;
        private System.Windows.Forms.PictureBox ButtonPressIcon9;
        private System.Windows.Forms.PictureBox ButtonPressIcon10;
        private System.Windows.Forms.PictureBox ButtonPressIcon11;
        private System.Windows.Forms.PictureBox ButtonPressIcon12;
        private System.Windows.Forms.Label devicetype_lbl5;
        private System.Windows.Forms.Label devicetype_lbl6;
        private System.Windows.Forms.Label DeviceAssign_lbl5;
        private System.Windows.Forms.Label DeviceAssign_lbl6;
        private System.Windows.Forms.Label devicetype_lbl10;
        private System.Windows.Forms.Label devicetype_lbl11;
        private System.Windows.Forms.Label devicetype_lbl12;
        private System.Windows.Forms.Label DeviceAssign_lbl10;
        private System.Windows.Forms.Label DeviceAssign_lbl11;
        private System.Windows.Forms.Label DeviceAssign_lbl12;
        private System.Windows.Forms.PictureBox BackGround_pb;
        private System.Windows.Forms.ComboBox cmbbx_analog_set_type;
        private System.Windows.Forms.ComboBox cmbbx_analog_pin;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label lbl_input_vol5;
        private System.Windows.Forms.NumericUpDown num_output_val5;
        private System.Windows.Forms.NumericUpDown num_output_val4;
        private System.Windows.Forms.NumericUpDown num_input_vol4;
        private System.Windows.Forms.NumericUpDown num_output_val3;
        private System.Windows.Forms.NumericUpDown num_input_vol3;
        private System.Windows.Forms.NumericUpDown num_output_val2;
        private System.Windows.Forms.NumericUpDown num_input_vol2;
        private System.Windows.Forms.NumericUpDown num_output_val1;
        private System.Windows.Forms.Label lbl_input_vol1;
        private System.Windows.Forms.Label lbl_output_val;
        private System.Windows.Forms.Label lbl_input_voltage;
        private System.Windows.Forms.Label lbl_analog_set_type;
        private System.Windows.Forms.Label lbl_analog_pin_no;
        private System.Windows.Forms.Button btn_analog_set;
        private System.Windows.Forms.PictureBox pic_analog_arrow1;
        private System.Windows.Forms.PictureBox pic_analog_arrow5;
        private System.Windows.Forms.PictureBox pic_analog_arrow4;
        private System.Windows.Forms.PictureBox pic_analog_arrow3;
        private System.Windows.Forms.PictureBox pic_analog_arrow2;
        private System.Windows.Forms.CheckBox Button13_cbox;
        private System.Windows.Forms.CheckBox Button14_cbox;
        private System.Windows.Forms.CheckBox Button15_cbox;
        private System.Windows.Forms.Button btn_soft_reset;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label colum_lbl;
        private System.Windows.Forms.Label Debug_label3;
        private System.Windows.Forms.Label Debug_label4;
        private System.Windows.Forms.Label Debug_label2;
        private System.Windows.Forms.Label Debug_label1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btn_debug_eeprom_write5;
        private System.Windows.Forms.Button btn_debug_eeprom_write4;
        private System.Windows.Forms.Button btn_debug_eeprom_write3;
        private System.Windows.Forms.Button btn_debug_eeprom_write2;
        private System.Windows.Forms.Button btn_debug_eeprom_write1;
        private System.Windows.Forms.RichTextBox rtxtbx_debug_flash_read;
        private System.Windows.Forms.TextBox txtbx_debug_flash_read_size;
        private System.Windows.Forms.TextBox txtbx_debug_flash_read_addr;
        private System.Windows.Forms.Button btn_debug_flash_read;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label DeviceAssign_lbl13;
        private System.Windows.Forms.Label devicetype_lbl13;
        private System.Windows.Forms.PictureBox ButtonPressIcon13;
        private System.Windows.Forms.PictureBox Pin13A_pb;
        private System.Windows.Forms.PictureBox Pin13B_pb;
        private System.Windows.Forms.Label DeviceAssign_lbl14;
        private System.Windows.Forms.Label devicetype_lbl14;
        private System.Windows.Forms.PictureBox ButtonPressIcon14;
        private System.Windows.Forms.PictureBox Pin14A_pb;
        private System.Windows.Forms.PictureBox Pin14B_pb;
        private System.Windows.Forms.Label DeviceAssign_lbl15;
        private System.Windows.Forms.Label devicetype_lbl15;
        private System.Windows.Forms.PictureBox ButtonPressIcon15;
        private System.Windows.Forms.PictureBox Pin15A_pb;
        private System.Windows.Forms.PictureBox Pin15B_pb;
        private System.Windows.Forms.Label lbl_analog1_status;
        private System.Windows.Forms.Label lbl_analog1_assign;
        private System.Windows.Forms.Label lbl_analog2_assign;
        private System.Windows.Forms.Label lbl_analog2_status;
        private System.Windows.Forms.Label lbl_analog3_assign;
        private System.Windows.Forms.Label lbl_analog3_status;
        private System.Windows.Forms.Label lbl_analog4_assign;
        private System.Windows.Forms.Label lbl_analog4_status;
        private System.Windows.Forms.Label lbl_analog8_assign;
        private System.Windows.Forms.Label lbl_analog8_status;
        private System.Windows.Forms.Label lbl_analog7_assign;
        private System.Windows.Forms.Label lbl_analog7_status;
        private System.Windows.Forms.Label lbl_analog6_assign;
        private System.Windows.Forms.Label lbl_analog6_status;
        private System.Windows.Forms.Label lbl_analog5_assign;
        private System.Windows.Forms.Label lbl_analog5_status;
        private System.Windows.Forms.CheckBox hatsw_up_cbox;
        private System.Windows.Forms.CheckBox hatsw_right_cbox;
        private System.Windows.Forms.CheckBox hatsw_down_cbox;
        private System.Windows.Forms.CheckBox hatsw_left_cbox;
        private System.Windows.Forms.Label lbl_FW_Version;
        private System.Windows.Forms.Button btn_default_reset;
        private System.Windows.Forms.NumericUpDown num_analog_sensitivity;
        private System.Windows.Forms.Label lbl_analog_sensitivity;
        private System.Windows.Forms.CheckBox LeverRZP_cbox;
        private System.Windows.Forms.CheckBox LeverRZM_cbox;
        private System.Windows.Forms.CheckBox LeverRYP_cbox;
        private System.Windows.Forms.CheckBox LeverRYM_cbox;
        private System.Windows.Forms.CheckBox LeverRXP_cbox;
        private System.Windows.Forms.CheckBox LeverRXM_cbox;
        private System.Windows.Forms.CheckBox LeverZP_cbox;
        private System.Windows.Forms.CheckBox LeverZM_cbox;
        private System.Windows.Forms.Label lbl_digital_assign;
        private System.Windows.Forms.Label lbl_digital_device_type;
        private System.Windows.Forms.Label lbl_digital_pin_no;
        private System.Windows.Forms.Label lbl_sw_mouse_title2;
        private System.Windows.Forms.Label lbl_sw_mouse_title1;
        private System.Windows.Forms.GroupBox gbx_analog_calibration;
        private System.Windows.Forms.CheckBox chkbx_analog_calibration;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown num_analog_dead_zone;
        private System.Windows.Forms.CheckBox chkbx_center_calibration;
        private System.Windows.Forms.CheckBox LeverSliderM_cbox;
        private System.Windows.Forms.CheckBox LeverSliderP_cbox;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.GroupBox gbx_setting_list;
        private System.Windows.Forms.PictureBox PinAN01A_pb;
        private System.Windows.Forms.PictureBox PinAN02A_pb;
        private System.Windows.Forms.PictureBox PinAN03A_pb;
        private System.Windows.Forms.PictureBox PinAN04A_pb;
        private System.Windows.Forms.PictureBox PinAN05A_pb;
        private System.Windows.Forms.PictureBox PinAN06A_pb;
        private System.Windows.Forms.PictureBox PinAN07A_pb;
        private System.Windows.Forms.PictureBox PinAN08A_pb;
        private System.Windows.Forms.PictureBox PinAN01B_pb;
        private System.Windows.Forms.PictureBox PinAN02B_pb;
        private System.Windows.Forms.PictureBox PinAN03B_pb;
        private System.Windows.Forms.PictureBox PinAN04B_pb;
        private System.Windows.Forms.PictureBox PinAN05B_pb;
        private System.Windows.Forms.PictureBox PinAN06B_pb;
        private System.Windows.Forms.PictureBox PinAN07B_pb;
        private System.Windows.Forms.PictureBox PinAN08B_pb;
        private System.Windows.Forms.PictureBox ana_tabA_pb;
        private System.Windows.Forms.PictureBox ana_tabB_pb;
        private System.Windows.Forms.PictureBox dig_tabA_pb;
        private System.Windows.Forms.PictureBox dig_tabB_pb;
        private System.Windows.Forms.Panel pnl_analog_setting;
        private System.Windows.Forms.Panel pnl_digital_setting;
        private System.Windows.Forms.PictureBox Revive_Advance_Device_pb;
    }
}

