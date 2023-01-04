namespace HeatControl
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
            this.OTGWButtonConnect = new System.Windows.Forms.Button();
            this.OTGWButtonDisconnect = new System.Windows.Forms.Button();
            this.OTGWGroupbox = new System.Windows.Forms.GroupBox();
            this.OTGWTabcontrol = new System.Windows.Forms.TabControl();
            this.OTGWTabStatus = new System.Windows.Forms.TabPage();
            this.OTGWTextBoxTapWaterTemperature = new System.Windows.Forms.TextBox();
            this.OTGWLabelTapWaterTemperature = new System.Windows.Forms.Label();
            this.OTGWTextBoxTapWaterFlow = new System.Windows.Forms.TextBox();
            this.OTGWLabelTapWaterFlow = new System.Windows.Forms.Label();
            this.OTGWTextBoxWaterPressure = new System.Windows.Forms.TextBox();
            this.OTGWLabelWaterPressure = new System.Windows.Forms.Label();
            this.OTGWTextBoxModulationLevel = new System.Windows.Forms.TextBox();
            this.OTGWLabelModulationLevel = new System.Windows.Forms.Label();
            this.OTGWTextBoxRoomSetpoint = new System.Windows.Forms.TextBox();
            this.OTGWLabelRoomSetpoint = new System.Windows.Forms.Label();
            this.OTGWTextBoxControlSetpointModified = new System.Windows.Forms.TextBox();
            this.OTGWLabelSlash = new System.Windows.Forms.Label();
            this.OTGWTextBoxControlSetpoint = new System.Windows.Forms.TextBox();
            this.OTGWLabelControlSetpoint = new System.Windows.Forms.Label();
            this.OTGWTextBoxFaultIndication = new System.Windows.Forms.TextBox();
            this.OTGWLabelFaultIndication = new System.Windows.Forms.Label();
            this.OTGWTextBoxTapWaterMode = new System.Windows.Forms.TextBox();
            this.OTGWLabelTapWaterMode = new System.Windows.Forms.Label();
            this.OTGWTextBoxCentralHeatingMode = new System.Windows.Forms.TextBox();
            this.OTGWLabelCentralHeatingMode = new System.Windows.Forms.Label();
            this.OTGWTextBoxFlameStatus = new System.Windows.Forms.TextBox();
            this.OTGWLabelFlameStatus = new System.Windows.Forms.Label();
            this.OTGWLabelBuild = new System.Windows.Forms.Label();
            this.OTGWLabelVersion = new System.Windows.Forms.Label();
            this.OTGWTextBoxBoilerTemp = new System.Windows.Forms.TextBox();
            this.OTGWLabelBoilerTemp = new System.Windows.Forms.Label();
            this.OTGWTextBoxRoomTemp = new System.Windows.Forms.TextBox();
            this.OTGWLabelRoomTemp = new System.Windows.Forms.Label();
            this.OTGWTabConnection = new System.Windows.Forms.TabPage();
            this.OTGWListboxLog = new System.Windows.Forms.ListBox();
            this.OTGWLabelHostname = new System.Windows.Forms.Label();
            this.OTGWTextboxHostname = new System.Windows.Forms.TextBox();
            this.OTGWTabDiagnostics = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.OTGWLabelReturnTemperature = new System.Windows.Forms.Label();
            this.OTGWTextBoxReturnTemperature = new System.Windows.Forms.TextBox();
            this.OTGWLabelOutsideTemperature = new System.Windows.Forms.Label();
            this.OTGWTextBoxOutsideTemperature = new System.Windows.Forms.TextBox();
            this.OTGWGroupbox.SuspendLayout();
            this.OTGWTabcontrol.SuspendLayout();
            this.OTGWTabStatus.SuspendLayout();
            this.OTGWTabConnection.SuspendLayout();
            this.SuspendLayout();
            // 
            // OTGWButtonConnect
            // 
            this.OTGWButtonConnect.Location = new System.Drawing.Point(19, 64);
            this.OTGWButtonConnect.Name = "OTGWButtonConnect";
            this.OTGWButtonConnect.Size = new System.Drawing.Size(191, 34);
            this.OTGWButtonConnect.TabIndex = 0;
            this.OTGWButtonConnect.Text = "Connect";
            this.OTGWButtonConnect.UseVisualStyleBackColor = true;
            this.OTGWButtonConnect.Click += new System.EventHandler(this.OTGWButtonConnect_Click);
            // 
            // OTGWButtonDisconnect
            // 
            this.OTGWButtonDisconnect.Location = new System.Drawing.Point(216, 64);
            this.OTGWButtonDisconnect.Name = "OTGWButtonDisconnect";
            this.OTGWButtonDisconnect.Size = new System.Drawing.Size(191, 34);
            this.OTGWButtonDisconnect.TabIndex = 1;
            this.OTGWButtonDisconnect.Text = "Disconnect";
            this.OTGWButtonDisconnect.UseVisualStyleBackColor = true;
            this.OTGWButtonDisconnect.Click += new System.EventHandler(this.OTGWButtonDisconnect_Click);
            // 
            // OTGWGroupbox
            // 
            this.OTGWGroupbox.Controls.Add(this.OTGWTabcontrol);
            this.OTGWGroupbox.Location = new System.Drawing.Point(478, 23);
            this.OTGWGroupbox.Name = "OTGWGroupbox";
            this.OTGWGroupbox.Size = new System.Drawing.Size(684, 507);
            this.OTGWGroupbox.TabIndex = 2;
            this.OTGWGroupbox.TabStop = false;
            this.OTGWGroupbox.Text = "OpenTherm Gateway (OTGW)";
            // 
            // OTGWTabcontrol
            // 
            this.OTGWTabcontrol.Controls.Add(this.OTGWTabStatus);
            this.OTGWTabcontrol.Controls.Add(this.OTGWTabConnection);
            this.OTGWTabcontrol.Controls.Add(this.OTGWTabDiagnostics);
            this.OTGWTabcontrol.Location = new System.Drawing.Point(16, 107);
            this.OTGWTabcontrol.Name = "OTGWTabcontrol";
            this.OTGWTabcontrol.SelectedIndex = 0;
            this.OTGWTabcontrol.Size = new System.Drawing.Size(695, 399);
            this.OTGWTabcontrol.TabIndex = 2;
            // 
            // OTGWTabStatus
            // 
            this.OTGWTabStatus.Controls.Add(this.OTGWTextBoxOutsideTemperature);
            this.OTGWTabStatus.Controls.Add(this.OTGWLabelOutsideTemperature);
            this.OTGWTabStatus.Controls.Add(this.OTGWTextBoxReturnTemperature);
            this.OTGWTabStatus.Controls.Add(this.OTGWLabelReturnTemperature);
            this.OTGWTabStatus.Controls.Add(this.OTGWTextBoxTapWaterTemperature);
            this.OTGWTabStatus.Controls.Add(this.OTGWLabelTapWaterTemperature);
            this.OTGWTabStatus.Controls.Add(this.OTGWTextBoxTapWaterFlow);
            this.OTGWTabStatus.Controls.Add(this.OTGWLabelTapWaterFlow);
            this.OTGWTabStatus.Controls.Add(this.OTGWTextBoxWaterPressure);
            this.OTGWTabStatus.Controls.Add(this.OTGWLabelWaterPressure);
            this.OTGWTabStatus.Controls.Add(this.OTGWTextBoxModulationLevel);
            this.OTGWTabStatus.Controls.Add(this.OTGWLabelModulationLevel);
            this.OTGWTabStatus.Controls.Add(this.OTGWTextBoxRoomSetpoint);
            this.OTGWTabStatus.Controls.Add(this.OTGWLabelRoomSetpoint);
            this.OTGWTabStatus.Controls.Add(this.OTGWTextBoxControlSetpointModified);
            this.OTGWTabStatus.Controls.Add(this.OTGWLabelSlash);
            this.OTGWTabStatus.Controls.Add(this.OTGWTextBoxControlSetpoint);
            this.OTGWTabStatus.Controls.Add(this.OTGWLabelControlSetpoint);
            this.OTGWTabStatus.Controls.Add(this.OTGWTextBoxFaultIndication);
            this.OTGWTabStatus.Controls.Add(this.OTGWLabelFaultIndication);
            this.OTGWTabStatus.Controls.Add(this.OTGWTextBoxTapWaterMode);
            this.OTGWTabStatus.Controls.Add(this.OTGWLabelTapWaterMode);
            this.OTGWTabStatus.Controls.Add(this.OTGWTextBoxCentralHeatingMode);
            this.OTGWTabStatus.Controls.Add(this.OTGWLabelCentralHeatingMode);
            this.OTGWTabStatus.Controls.Add(this.OTGWTextBoxFlameStatus);
            this.OTGWTabStatus.Controls.Add(this.OTGWLabelFlameStatus);
            this.OTGWTabStatus.Controls.Add(this.OTGWLabelBuild);
            this.OTGWTabStatus.Controls.Add(this.OTGWLabelVersion);
            this.OTGWTabStatus.Controls.Add(this.OTGWTextBoxBoilerTemp);
            this.OTGWTabStatus.Controls.Add(this.OTGWLabelBoilerTemp);
            this.OTGWTabStatus.Controls.Add(this.OTGWTextBoxRoomTemp);
            this.OTGWTabStatus.Controls.Add(this.OTGWLabelRoomTemp);
            this.OTGWTabStatus.Location = new System.Drawing.Point(4, 22);
            this.OTGWTabStatus.Name = "OTGWTabStatus";
            this.OTGWTabStatus.Padding = new System.Windows.Forms.Padding(3);
            this.OTGWTabStatus.Size = new System.Drawing.Size(687, 373);
            this.OTGWTabStatus.TabIndex = 0;
            this.OTGWTabStatus.Text = "Status Overview";
            // 
            // OTGWTextBoxTapWaterTemperature
            // 
            this.OTGWTextBoxTapWaterTemperature.Location = new System.Drawing.Point(551, 131);
            this.OTGWTextBoxTapWaterTemperature.Name = "OTGWTextBoxTapWaterTemperature";
            this.OTGWTextBoxTapWaterTemperature.Size = new System.Drawing.Size(43, 20);
            this.OTGWTextBoxTapWaterTemperature.TabIndex = 27;
            // 
            // OTGWLabelTapWaterTemperature
            // 
            this.OTGWLabelTapWaterTemperature.AutoSize = true;
            this.OTGWLabelTapWaterTemperature.Location = new System.Drawing.Point(426, 134);
            this.OTGWLabelTapWaterTemperature.Name = "OTGWLabelTapWaterTemperature";
            this.OTGWLabelTapWaterTemperature.Size = new System.Drawing.Size(114, 13);
            this.OTGWLabelTapWaterTemperature.TabIndex = 26;
            this.OTGWLabelTapWaterTemperature.Text = "Tap water temperature";
            // 
            // OTGWTextBoxTapWaterFlow
            // 
            this.OTGWTextBoxTapWaterFlow.Location = new System.Drawing.Point(551, 105);
            this.OTGWTextBoxTapWaterFlow.Name = "OTGWTextBoxTapWaterFlow";
            this.OTGWTextBoxTapWaterFlow.Size = new System.Drawing.Size(43, 20);
            this.OTGWTextBoxTapWaterFlow.TabIndex = 25;
            // 
            // OTGWLabelTapWaterFlow
            // 
            this.OTGWLabelTapWaterFlow.AutoSize = true;
            this.OTGWLabelTapWaterFlow.Location = new System.Drawing.Point(426, 108);
            this.OTGWLabelTapWaterFlow.Name = "OTGWLabelTapWaterFlow";
            this.OTGWLabelTapWaterFlow.Size = new System.Drawing.Size(77, 13);
            this.OTGWLabelTapWaterFlow.TabIndex = 24;
            this.OTGWLabelTapWaterFlow.Text = "Tap water flow";
            // 
            // OTGWTextBoxWaterPressure
            // 
            this.OTGWTextBoxWaterPressure.Location = new System.Drawing.Point(551, 79);
            this.OTGWTextBoxWaterPressure.Name = "OTGWTextBoxWaterPressure";
            this.OTGWTextBoxWaterPressure.Size = new System.Drawing.Size(43, 20);
            this.OTGWTextBoxWaterPressure.TabIndex = 23;
            // 
            // OTGWLabelWaterPressure
            // 
            this.OTGWLabelWaterPressure.AutoSize = true;
            this.OTGWLabelWaterPressure.Location = new System.Drawing.Point(426, 82);
            this.OTGWLabelWaterPressure.Name = "OTGWLabelWaterPressure";
            this.OTGWLabelWaterPressure.Size = new System.Drawing.Size(105, 13);
            this.OTGWLabelWaterPressure.TabIndex = 22;
            this.OTGWLabelWaterPressure.Text = "Boiler water pressure";
            // 
            // OTGWTextBoxModulationLevel
            // 
            this.OTGWTextBoxModulationLevel.Location = new System.Drawing.Point(318, 131);
            this.OTGWTextBoxModulationLevel.Name = "OTGWTextBoxModulationLevel";
            this.OTGWTextBoxModulationLevel.Size = new System.Drawing.Size(43, 20);
            this.OTGWTextBoxModulationLevel.TabIndex = 21;
            // 
            // OTGWLabelModulationLevel
            // 
            this.OTGWLabelModulationLevel.AutoSize = true;
            this.OTGWLabelModulationLevel.Location = new System.Drawing.Point(218, 134);
            this.OTGWLabelModulationLevel.Name = "OTGWLabelModulationLevel";
            this.OTGWLabelModulationLevel.Size = new System.Drawing.Size(84, 13);
            this.OTGWLabelModulationLevel.TabIndex = 20;
            this.OTGWLabelModulationLevel.Text = "Modulation level";
            // 
            // OTGWTextBoxRoomSetpoint
            // 
            this.OTGWTextBoxRoomSetpoint.Location = new System.Drawing.Point(318, 105);
            this.OTGWTextBoxRoomSetpoint.Name = "OTGWTextBoxRoomSetpoint";
            this.OTGWTextBoxRoomSetpoint.Size = new System.Drawing.Size(43, 20);
            this.OTGWTextBoxRoomSetpoint.TabIndex = 19;
            // 
            // OTGWLabelRoomSetpoint
            // 
            this.OTGWLabelRoomSetpoint.AutoSize = true;
            this.OTGWLabelRoomSetpoint.Location = new System.Drawing.Point(218, 108);
            this.OTGWLabelRoomSetpoint.Name = "OTGWLabelRoomSetpoint";
            this.OTGWLabelRoomSetpoint.Size = new System.Drawing.Size(75, 13);
            this.OTGWLabelRoomSetpoint.TabIndex = 18;
            this.OTGWLabelRoomSetpoint.Text = "Room setpoint";
            // 
            // OTGWTextBoxControlSetpointModified
            // 
            this.OTGWTextBoxControlSetpointModified.Location = new System.Drawing.Point(357, 79);
            this.OTGWTextBoxControlSetpointModified.Name = "OTGWTextBoxControlSetpointModified";
            this.OTGWTextBoxControlSetpointModified.Size = new System.Drawing.Size(27, 20);
            this.OTGWTextBoxControlSetpointModified.TabIndex = 17;
            // 
            // OTGWLabelSlash
            // 
            this.OTGWLabelSlash.AutoSize = true;
            this.OTGWLabelSlash.Location = new System.Drawing.Point(346, 82);
            this.OTGWLabelSlash.Name = "OTGWLabelSlash";
            this.OTGWLabelSlash.Size = new System.Drawing.Size(12, 13);
            this.OTGWLabelSlash.TabIndex = 16;
            this.OTGWLabelSlash.Text = "/";
            // 
            // OTGWTextBoxControlSetpoint
            // 
            this.OTGWTextBoxControlSetpoint.Location = new System.Drawing.Point(318, 79);
            this.OTGWTextBoxControlSetpoint.Name = "OTGWTextBoxControlSetpoint";
            this.OTGWTextBoxControlSetpoint.Size = new System.Drawing.Size(27, 20);
            this.OTGWTextBoxControlSetpoint.TabIndex = 15;
            // 
            // OTGWLabelControlSetpoint
            // 
            this.OTGWLabelControlSetpoint.AutoSize = true;
            this.OTGWLabelControlSetpoint.Location = new System.Drawing.Point(218, 82);
            this.OTGWLabelControlSetpoint.Name = "OTGWLabelControlSetpoint";
            this.OTGWLabelControlSetpoint.Size = new System.Drawing.Size(80, 13);
            this.OTGWLabelControlSetpoint.TabIndex = 14;
            this.OTGWLabelControlSetpoint.Text = "Control setpoint";
            // 
            // OTGWTextBoxFaultIndication
            // 
            this.OTGWTextBoxFaultIndication.Location = new System.Drawing.Point(119, 157);
            this.OTGWTextBoxFaultIndication.Name = "OTGWTextBoxFaultIndication";
            this.OTGWTextBoxFaultIndication.Size = new System.Drawing.Size(43, 20);
            this.OTGWTextBoxFaultIndication.TabIndex = 13;
            // 
            // OTGWLabelFaultIndication
            // 
            this.OTGWLabelFaultIndication.AutoSize = true;
            this.OTGWLabelFaultIndication.Location = new System.Drawing.Point(8, 160);
            this.OTGWLabelFaultIndication.Name = "OTGWLabelFaultIndication";
            this.OTGWLabelFaultIndication.Size = new System.Drawing.Size(78, 13);
            this.OTGWLabelFaultIndication.TabIndex = 12;
            this.OTGWLabelFaultIndication.Text = "Fault indication";
            // 
            // OTGWTextBoxTapWaterMode
            // 
            this.OTGWTextBoxTapWaterMode.Location = new System.Drawing.Point(119, 131);
            this.OTGWTextBoxTapWaterMode.Name = "OTGWTextBoxTapWaterMode";
            this.OTGWTextBoxTapWaterMode.Size = new System.Drawing.Size(43, 20);
            this.OTGWTextBoxTapWaterMode.TabIndex = 11;
            // 
            // OTGWLabelTapWaterMode
            // 
            this.OTGWLabelTapWaterMode.AutoSize = true;
            this.OTGWLabelTapWaterMode.Location = new System.Drawing.Point(8, 134);
            this.OTGWLabelTapWaterMode.Name = "OTGWLabelTapWaterMode";
            this.OTGWLabelTapWaterMode.Size = new System.Drawing.Size(84, 13);
            this.OTGWLabelTapWaterMode.TabIndex = 10;
            this.OTGWLabelTapWaterMode.Text = "Tap water mode";
            // 
            // OTGWTextBoxCentralHeatingMode
            // 
            this.OTGWTextBoxCentralHeatingMode.Location = new System.Drawing.Point(119, 105);
            this.OTGWTextBoxCentralHeatingMode.Name = "OTGWTextBoxCentralHeatingMode";
            this.OTGWTextBoxCentralHeatingMode.Size = new System.Drawing.Size(43, 20);
            this.OTGWTextBoxCentralHeatingMode.TabIndex = 9;
            // 
            // OTGWLabelCentralHeatingMode
            // 
            this.OTGWLabelCentralHeatingMode.AutoSize = true;
            this.OTGWLabelCentralHeatingMode.Location = new System.Drawing.Point(8, 108);
            this.OTGWLabelCentralHeatingMode.Name = "OTGWLabelCentralHeatingMode";
            this.OTGWLabelCentralHeatingMode.Size = new System.Drawing.Size(107, 13);
            this.OTGWLabelCentralHeatingMode.TabIndex = 8;
            this.OTGWLabelCentralHeatingMode.Text = "Central heating mode";
            // 
            // OTGWTextBoxFlameStatus
            // 
            this.OTGWTextBoxFlameStatus.Location = new System.Drawing.Point(119, 79);
            this.OTGWTextBoxFlameStatus.Name = "OTGWTextBoxFlameStatus";
            this.OTGWTextBoxFlameStatus.Size = new System.Drawing.Size(43, 20);
            this.OTGWTextBoxFlameStatus.TabIndex = 7;
            // 
            // OTGWLabelFlameStatus
            // 
            this.OTGWLabelFlameStatus.AutoSize = true;
            this.OTGWLabelFlameStatus.Location = new System.Drawing.Point(8, 82);
            this.OTGWLabelFlameStatus.Name = "OTGWLabelFlameStatus";
            this.OTGWLabelFlameStatus.Size = new System.Drawing.Size(66, 13);
            this.OTGWLabelFlameStatus.TabIndex = 6;
            this.OTGWLabelFlameStatus.Text = "Flame status";
            // 
            // OTGWLabelBuild
            // 
            this.OTGWLabelBuild.AutoSize = true;
            this.OTGWLabelBuild.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OTGWLabelBuild.Location = new System.Drawing.Point(238, 12);
            this.OTGWLabelBuild.Name = "OTGWLabelBuild";
            this.OTGWLabelBuild.Size = new System.Drawing.Size(0, 20);
            this.OTGWLabelBuild.TabIndex = 5;
            // 
            // OTGWLabelVersion
            // 
            this.OTGWLabelVersion.AutoSize = true;
            this.OTGWLabelVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OTGWLabelVersion.Location = new System.Drawing.Point(7, 12);
            this.OTGWLabelVersion.Name = "OTGWLabelVersion";
            this.OTGWLabelVersion.Size = new System.Drawing.Size(177, 20);
            this.OTGWLabelVersion.TabIndex = 4;
            this.OTGWLabelVersion.Text = "OpenTherm Gateway";
            // 
            // OTGWTextBoxBoilerTemp
            // 
            this.OTGWTextBoxBoilerTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OTGWTextBoxBoilerTemp.Location = new System.Drawing.Point(494, 44);
            this.OTGWTextBoxBoilerTemp.Name = "OTGWTextBoxBoilerTemp";
            this.OTGWTextBoxBoilerTemp.Size = new System.Drawing.Size(100, 26);
            this.OTGWTextBoxBoilerTemp.TabIndex = 3;
            // 
            // OTGWLabelBoilerTemp
            // 
            this.OTGWLabelBoilerTemp.AutoSize = true;
            this.OTGWLabelBoilerTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OTGWLabelBoilerTemp.Location = new System.Drawing.Point(335, 47);
            this.OTGWLabelBoilerTemp.Name = "OTGWLabelBoilerTemp";
            this.OTGWLabelBoilerTemp.Size = new System.Drawing.Size(140, 20);
            this.OTGWLabelBoilerTemp.TabIndex = 2;
            this.OTGWLabelBoilerTemp.Text = "Boiler temperature";
            // 
            // OTGWTextBoxRoomTemp
            // 
            this.OTGWTextBoxRoomTemp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OTGWTextBoxRoomTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OTGWTextBoxRoomTemp.Location = new System.Drawing.Point(174, 45);
            this.OTGWTextBoxRoomTemp.Name = "OTGWTextBoxRoomTemp";
            this.OTGWTextBoxRoomTemp.Size = new System.Drawing.Size(100, 26);
            this.OTGWTextBoxRoomTemp.TabIndex = 1;
            // 
            // OTGWLabelRoomTemp
            // 
            this.OTGWLabelRoomTemp.AutoSize = true;
            this.OTGWLabelRoomTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OTGWLabelRoomTemp.Location = new System.Drawing.Point(7, 47);
            this.OTGWLabelRoomTemp.Name = "OTGWLabelRoomTemp";
            this.OTGWLabelRoomTemp.Size = new System.Drawing.Size(143, 20);
            this.OTGWLabelRoomTemp.TabIndex = 0;
            this.OTGWLabelRoomTemp.Text = "Room temperature";
            // 
            // OTGWTabConnection
            // 
            this.OTGWTabConnection.Controls.Add(this.OTGWListboxLog);
            this.OTGWTabConnection.Controls.Add(this.OTGWLabelHostname);
            this.OTGWTabConnection.Controls.Add(this.OTGWTextboxHostname);
            this.OTGWTabConnection.Controls.Add(this.OTGWButtonConnect);
            this.OTGWTabConnection.Controls.Add(this.OTGWButtonDisconnect);
            this.OTGWTabConnection.Location = new System.Drawing.Point(4, 22);
            this.OTGWTabConnection.Name = "OTGWTabConnection";
            this.OTGWTabConnection.Padding = new System.Windows.Forms.Padding(3);
            this.OTGWTabConnection.Size = new System.Drawing.Size(687, 373);
            this.OTGWTabConnection.TabIndex = 1;
            this.OTGWTabConnection.Text = "Connection";
            // 
            // OTGWListboxLog
            // 
            this.OTGWListboxLog.FormattingEnabled = true;
            this.OTGWListboxLog.Location = new System.Drawing.Point(19, 116);
            this.OTGWListboxLog.Name = "OTGWListboxLog";
            this.OTGWListboxLog.Size = new System.Drawing.Size(388, 238);
            this.OTGWListboxLog.TabIndex = 5;
            // 
            // OTGWLabelHostname
            // 
            this.OTGWLabelHostname.AutoSize = true;
            this.OTGWLabelHostname.Location = new System.Drawing.Point(16, 26);
            this.OTGWLabelHostname.Name = "OTGWLabelHostname";
            this.OTGWLabelHostname.Size = new System.Drawing.Size(113, 13);
            this.OTGWLabelHostname.TabIndex = 3;
            this.OTGWLabelHostname.Text = "Hostname/ IP-address";
            // 
            // OTGWTextboxHostname
            // 
            this.OTGWTextboxHostname.Location = new System.Drawing.Point(147, 23);
            this.OTGWTextboxHostname.Name = "OTGWTextboxHostname";
            this.OTGWTextboxHostname.Size = new System.Drawing.Size(260, 20);
            this.OTGWTextboxHostname.TabIndex = 2;
            this.OTGWTextboxHostname.Text = "OTGW_wifi";
            // 
            // OTGWTabDiagnostics
            // 
            this.OTGWTabDiagnostics.BackColor = System.Drawing.SystemColors.Control;
            this.OTGWTabDiagnostics.Location = new System.Drawing.Point(4, 22);
            this.OTGWTabDiagnostics.Name = "OTGWTabDiagnostics";
            this.OTGWTabDiagnostics.Padding = new System.Windows.Forms.Padding(3);
            this.OTGWTabDiagnostics.Size = new System.Drawing.Size(687, 373);
            this.OTGWTabDiagnostics.TabIndex = 2;
            this.OTGWTabDiagnostics.Text = "Diagnostics";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(15, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(457, 505);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "EQ-3 Max!";
            // 
            // OTGWLabelReturnTemperature
            // 
            this.OTGWLabelReturnTemperature.AutoSize = true;
            this.OTGWLabelReturnTemperature.Location = new System.Drawing.Point(218, 160);
            this.OTGWLabelReturnTemperature.Name = "OTGWLabelReturnTemperature";
            this.OTGWLabelReturnTemperature.Size = new System.Drawing.Size(98, 13);
            this.OTGWLabelReturnTemperature.TabIndex = 28;
            this.OTGWLabelReturnTemperature.Text = "Return temperature";
            // 
            // OTGWTextBoxReturnTemperature
            // 
            this.OTGWTextBoxReturnTemperature.Location = new System.Drawing.Point(318, 157);
            this.OTGWTextBoxReturnTemperature.Name = "OTGWTextBoxReturnTemperature";
            this.OTGWTextBoxReturnTemperature.Size = new System.Drawing.Size(43, 20);
            this.OTGWTextBoxReturnTemperature.TabIndex = 29;
            // 
            // OTGWLabelOutsideTemperature
            // 
            this.OTGWLabelOutsideTemperature.AutoSize = true;
            this.OTGWLabelOutsideTemperature.Location = new System.Drawing.Point(429, 160);
            this.OTGWLabelOutsideTemperature.Name = "OTGWLabelOutsideTemperature";
            this.OTGWLabelOutsideTemperature.Size = new System.Drawing.Size(102, 13);
            this.OTGWLabelOutsideTemperature.TabIndex = 30;
            this.OTGWLabelOutsideTemperature.Text = "Outside temperature";
            // 
            // OTGWTextBoxOutsideTemperature
            // 
            this.OTGWTextBoxOutsideTemperature.Location = new System.Drawing.Point(551, 160);
            this.OTGWTextBoxOutsideTemperature.Name = "OTGWTextBoxOutsideTemperature";
            this.OTGWTextBoxOutsideTemperature.Size = new System.Drawing.Size(43, 20);
            this.OTGWTextBoxOutsideTemperature.TabIndex = 31;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1216, 549);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.OTGWGroupbox);
            this.Name = "Form1";
            this.Text = "HeatControl";
            this.OTGWGroupbox.ResumeLayout(false);
            this.OTGWTabcontrol.ResumeLayout(false);
            this.OTGWTabStatus.ResumeLayout(false);
            this.OTGWTabStatus.PerformLayout();
            this.OTGWTabConnection.ResumeLayout(false);
            this.OTGWTabConnection.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OTGWButtonConnect;
        private System.Windows.Forms.Button OTGWButtonDisconnect;
        private System.Windows.Forms.GroupBox OTGWGroupbox;
        private System.Windows.Forms.TabControl OTGWTabcontrol;
        private System.Windows.Forms.TabPage OTGWTabStatus;
        private System.Windows.Forms.TabPage OTGWTabConnection;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label OTGWLabelHostname;
        private System.Windows.Forms.TextBox OTGWTextboxHostname;
        private System.Windows.Forms.ListBox OTGWListboxLog;
        private System.Windows.Forms.TextBox OTGWTextBoxRoomTemp;
        private System.Windows.Forms.Label OTGWLabelRoomTemp;
        private System.Windows.Forms.TextBox OTGWTextBoxBoilerTemp;
        private System.Windows.Forms.Label OTGWLabelBoilerTemp;
        private System.Windows.Forms.Label OTGWLabelVersion;
        private System.Windows.Forms.Label OTGWLabelBuild;
        private System.Windows.Forms.TabPage OTGWTabDiagnostics;
        private System.Windows.Forms.TextBox OTGWTextBoxFlameStatus;
        private System.Windows.Forms.Label OTGWLabelFlameStatus;
        private System.Windows.Forms.Label OTGWLabelCentralHeatingMode;
        private System.Windows.Forms.TextBox OTGWTextBoxCentralHeatingMode;
        private System.Windows.Forms.TextBox OTGWTextBoxTapWaterMode;
        private System.Windows.Forms.Label OTGWLabelTapWaterMode;
        private System.Windows.Forms.TextBox OTGWTextBoxFaultIndication;
        private System.Windows.Forms.Label OTGWLabelFaultIndication;
        private System.Windows.Forms.TextBox OTGWTextBoxControlSetpointModified;
        private System.Windows.Forms.Label OTGWLabelSlash;
        private System.Windows.Forms.TextBox OTGWTextBoxControlSetpoint;
        private System.Windows.Forms.Label OTGWLabelControlSetpoint;
        private System.Windows.Forms.TextBox OTGWTextBoxRoomSetpoint;
        private System.Windows.Forms.Label OTGWLabelRoomSetpoint;
        private System.Windows.Forms.TextBox OTGWTextBoxModulationLevel;
        private System.Windows.Forms.Label OTGWLabelModulationLevel;
        private System.Windows.Forms.TextBox OTGWTextBoxWaterPressure;
        private System.Windows.Forms.Label OTGWLabelWaterPressure;
        private System.Windows.Forms.TextBox OTGWTextBoxTapWaterFlow;
        private System.Windows.Forms.Label OTGWLabelTapWaterFlow;
        private System.Windows.Forms.TextBox OTGWTextBoxTapWaterTemperature;
        private System.Windows.Forms.Label OTGWLabelTapWaterTemperature;
        private System.Windows.Forms.TextBox OTGWTextBoxReturnTemperature;
        private System.Windows.Forms.Label OTGWLabelReturnTemperature;
        private System.Windows.Forms.TextBox OTGWTextBoxOutsideTemperature;
        private System.Windows.Forms.Label OTGWLabelOutsideTemperature;
    }
}

