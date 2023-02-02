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
            this.components = new System.ComponentModel.Container();
            this.OTGWButtonConnect = new System.Windows.Forms.Button();
            this.OTGWButtonDisconnect = new System.Windows.Forms.Button();
            this.OTGWGroupbox = new System.Windows.Forms.GroupBox();
            this.OTGWTabcontrol = new System.Windows.Forms.TabControl();
            this.OTGWTabStatus = new System.Windows.Forms.TabPage();
            this.OTGWFormsPlotFloats = new ScottPlot.FormsPlot();
            this.OTGWTextBoxOutsideTemperature = new System.Windows.Forms.TextBox();
            this.OTGWLabelOutsideTemperature = new System.Windows.Forms.Label();
            this.OTGWTextBoxReturnTemperature = new System.Windows.Forms.TextBox();
            this.OTGWLabelReturnTemperature = new System.Windows.Forms.Label();
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
            this.OTGWCheckBoxEnableLoggingToFile = new System.Windows.Forms.CheckBox();
            this.OTGWCheckBoxAppend = new System.Windows.Forms.CheckBox();
            this.OTGWLabelAppend = new System.Windows.Forms.Label();
            this.OTGWTextBoxLogfileName = new System.Windows.Forms.TextBox();
            this.OTGWLabelLogfileName = new System.Windows.Forms.Label();
            this.OTGWListboxLog = new System.Windows.Forms.ListBox();
            this.OTGWLabelHostname = new System.Windows.Forms.Label();
            this.OTGWTextboxHostname = new System.Windows.Forms.TextBox();
            this.OTGWTabBoilerDiagnostics = new System.Windows.Forms.TabPage();
            this.OTGWTextBoxDiagTapWaterBurnerHours = new System.Windows.Forms.TextBox();
            this.OTGWLabelDiagTapBurnerHours = new System.Windows.Forms.Label();
            this.OTGWTextBoxDiagTapWaterValveHours = new System.Windows.Forms.TextBox();
            this.OTGWLabelDiagTapWaterValveHours = new System.Windows.Forms.Label();
            this.OTGWTextBoxDiagPumpHours = new System.Windows.Forms.TextBox();
            this.OTGWLabelDiagPumpHours = new System.Windows.Forms.Label();
            this.OTGWTextBoxDiagBurnerHours = new System.Windows.Forms.TextBox();
            this.OTGWLabelDiagBurnerHours = new System.Windows.Forms.Label();
            this.OTGWTextBoxDiagTapWaterBurnerStarts = new System.Windows.Forms.TextBox();
            this.OTGWLabelDiagTapWaterBurnerStarts = new System.Windows.Forms.Label();
            this.OTGWTextBoxDiagTapWaterValveStarts = new System.Windows.Forms.TextBox();
            this.OTGWLabelDiagTapWaterValveStarts = new System.Windows.Forms.Label();
            this.OTGWTextBoxDiagPumpStarts = new System.Windows.Forms.TextBox();
            this.OTGWLabelDiagPumpStarts = new System.Windows.Forms.Label();
            this.OTGWTextBoxDiagBurnerStarts = new System.Windows.Forms.TextBox();
            this.OTGWLabelDiagBurnerStarts = new System.Windows.Forms.Label();
            this.OTGWTextBoxDiagExhaustTemperature = new System.Windows.Forms.TextBox();
            this.OTGWLabelDiagExhaustTemperature = new System.Windows.Forms.Label();
            this.OTGWTextBoxDiagTapWater2Temperature = new System.Windows.Forms.TextBox();
            this.OTGWLabelDiagTapWater2Temperature = new System.Windows.Forms.Label();
            this.OTGWTextBoxDiagFlowTemperatureCH2 = new System.Windows.Forms.TextBox();
            this.OTGWLabelDiagFlowTemperatureCH2 = new System.Windows.Forms.Label();
            this.OTGWTextBoxDiagSolarCollectorTemperature = new System.Windows.Forms.TextBox();
            this.OTGWLabelDiagSolarCollectorTemperature = new System.Windows.Forms.Label();
            this.OTGWTextBoxDiagSolarStorageTemperature = new System.Windows.Forms.TextBox();
            this.OTGWLabelDiagSolarStorageTemperature = new System.Windows.Forms.Label();
            this.OTGWLabelDiagYear = new System.Windows.Forms.Label();
            this.OTGWLabelDiagTimeAndDay = new System.Windows.Forms.Label();
            this.OTGWTextBoxDiagOEMDiagnosticCode = new System.Windows.Forms.TextBox();
            this.OTGWLabelDiagOEMDiagnosticCode = new System.Windows.Forms.Label();
            this.OTGWLabelDiagDate = new System.Windows.Forms.Label();
            this.OTGWTextBoxDiagOEMFaultCode = new System.Windows.Forms.TextBox();
            this.OTGWLabelDiagOEMFaultCode = new System.Windows.Forms.Label();
            this.OTGWTextBoxDiagWaterOvertemp = new System.Windows.Forms.TextBox();
            this.OTGWLabelDiagWaterOvertemp = new System.Windows.Forms.Label();
            this.OTGWTextBoxDiagAirPressureFault = new System.Windows.Forms.TextBox();
            this.OTGWLabelDiagAirPressureFault = new System.Windows.Forms.Label();
            this.OTGWTextBoxDiagGasFlameFault = new System.Windows.Forms.TextBox();
            this.OTGWLabelDiagGasFlameFault = new System.Windows.Forms.Label();
            this.OTGWTextBoxDiagLowWaterPressure = new System.Windows.Forms.TextBox();
            this.OTGWLabelDiagLowWaterPressure = new System.Windows.Forms.Label();
            this.OTGWTextBoxDiagLockoutReset = new System.Windows.Forms.TextBox();
            this.OTGWLabelDiagLockoutReset = new System.Windows.Forms.Label();
            this.OTGWTextBoxDiagServiceRequest = new System.Windows.Forms.TextBox();
            this.OTGWLabelDiagServiceRequest = new System.Windows.Forms.Label();
            this.OTGWTextBoxDiagCH2Present = new System.Windows.Forms.TextBox();
            this.OTGWLabelDiagCH2Present = new System.Windows.Forms.Label();
            this.OTGWTextBoxDiagMasterLowOffPumpControl = new System.Windows.Forms.TextBox();
            this.OTGWLabelDiagMasterLowOffPumpControl = new System.Windows.Forms.Label();
            this.OTGWTextBoxDiagTapWaterConfiguration = new System.Windows.Forms.TextBox();
            this.OTGWLabelDiagTapWaterConfiguration = new System.Windows.Forms.Label();
            this.OTGWTextBoxDiagCoolingConfiguration = new System.Windows.Forms.TextBox();
            this.OTGWLabelDiagCoolingConfiguration = new System.Windows.Forms.Label();
            this.OTGWTextBoxDiagControlType = new System.Windows.Forms.TextBox();
            this.OTGWLabelDiagControlType = new System.Windows.Forms.Label();
            this.OTGWTextBoxDiagTapWaterPresent = new System.Windows.Forms.TextBox();
            this.OTGWLabelDiagTapWaterPresent = new System.Windows.Forms.Label();
            this.OTGWTextBoxDiagSlaveMemberID = new System.Windows.Forms.TextBox();
            this.OTGWLabelDiagSlaveMemberID = new System.Windows.Forms.Label();
            this.OTGWTextBoxDiagMasterMemberID = new System.Windows.Forms.TextBox();
            this.OTGWLabelDiagMasterMemberID = new System.Windows.Forms.Label();
            this.OTGWTextBoxDiagCH2Enabled = new System.Windows.Forms.TextBox();
            this.OTGWLabelDiagCH2Enabled = new System.Windows.Forms.Label();
            this.OTGWTextBoxDiagOTCActive = new System.Windows.Forms.TextBox();
            this.OTGWLabelDiagOTCActive = new System.Windows.Forms.Label();
            this.OTGWTextBoxDiagCoolingEnabled = new System.Windows.Forms.TextBox();
            this.OTGWLabelDiagCoolingEnabled = new System.Windows.Forms.Label();
            this.OTGWTextBoxDiagTapWaterEnabled = new System.Windows.Forms.TextBox();
            this.OTGWLabelDiagTapWaterEnabled = new System.Windows.Forms.Label();
            this.OTGWTextBoxDiagCentralHeatingEnabled = new System.Windows.Forms.TextBox();
            this.OTGWLabelDiagCentralHeatingEnabled = new System.Windows.Forms.Label();
            this.OTGWTabOTGWDiagnostics = new System.Windows.Forms.TabPage();
            this.OTGWTextBoxDiagProductVersionSlave = new System.Windows.Forms.TextBox();
            this.OTGWLabelProductVersionSlave = new System.Windows.Forms.Label();
            this.OTGWTextBoxDiagProductVersionMaster = new System.Windows.Forms.TextBox();
            this.OTGWLabelDiagProductVersionMaster = new System.Windows.Forms.Label();
            this.OTGWTextBoxDiagProductTypeSlave = new System.Windows.Forms.TextBox();
            this.OTGWLabelProductTypeSlave = new System.Windows.Forms.Label();
            this.OTGWTextBoxDiagProductTypeMaster = new System.Windows.Forms.TextBox();
            this.OTGWLabelDiagProductTypeMaster = new System.Windows.Forms.Label();
            this.OTGWTextBoxDiagOpenThermVersionSlave = new System.Windows.Forms.TextBox();
            this.OTGWLabelDiagOpenThermVersionSlave = new System.Windows.Forms.Label();
            this.OTGWTextBoxDiagOpenThermVersionMaster = new System.Windows.Forms.TextBox();
            this.OTGWLabelDiagOpenThermVersionMaster = new System.Windows.Forms.Label();
            this.OTGWTextBoxDiagHotWater = new System.Windows.Forms.TextBox();
            this.OTGWLabelDiagHotWater = new System.Windows.Forms.Label();
            this.OTGWLabelDiagReferenceVoltage = new System.Windows.Forms.Label();
            this.OTGWTextBoxDiagReferenceVoltage = new System.Windows.Forms.TextBox();
            this.OTGWLabelDiagTweaks = new System.Windows.Forms.Label();
            this.OTGWTextBoxDiagTweaks = new System.Windows.Forms.TextBox();
            this.OTGWTextBoxDiagSetbackTemperature = new System.Windows.Forms.TextBox();
            this.OTGWLabelDiagSetbackTemperature = new System.Windows.Forms.Label();
            this.OTGWTextBoxDiagRemehaDetectionState = new System.Windows.Forms.TextBox();
            this.OTGWLabelDiagRemehaDetectionState = new System.Windows.Forms.Label();
            this.OTGWTextBoxDiagCauseOfLastReset = new System.Windows.Forms.TextBox();
            this.OTGWLabelDiagCauseOfLastReset = new System.Windows.Forms.Label();
            this.OTGWTextBoxDiagSmartPowerMode = new System.Windows.Forms.TextBox();
            this.OTGWLabelDiagSmartPowerMode = new System.Windows.Forms.Label();
            this.OTGWTextBoxDiagSetpointOverride = new System.Windows.Forms.TextBox();
            this.OTGWLabelDiagSetpointOverride = new System.Windows.Forms.Label();
            this.OTGWTextBoxDiagGatewayMode = new System.Windows.Forms.TextBox();
            this.OTGWLabelDiagGatewayMode = new System.Windows.Forms.Label();
            this.OTGWTextBoxDiagLedFunctions = new System.Windows.Forms.TextBox();
            this.OTGWLabelDiagLedFunctions = new System.Windows.Forms.Label();
            this.OTGWTextBoxDiagGPIOState = new System.Windows.Forms.TextBox();
            this.OTGWTextBoxDiagGPIOFunctions = new System.Windows.Forms.TextBox();
            this.OTGWLabelDiagGPIOState = new System.Windows.Forms.Label();
            this.OTGWLabelDiagGPIOFucntions = new System.Windows.Forms.Label();
            this.OTGWTextBoxDiagTemperatureSensorFunction = new System.Windows.Forms.TextBox();
            this.OTGWLabelDiagTemperatureSensorFunction = new System.Windows.Forms.Label();
            this.OTGWTextBoxDiagClockSpeed = new System.Windows.Forms.TextBox();
            this.OTGWLabelDiagClockSpeed = new System.Windows.Forms.Label();
            this.OTGWTextBoxDiagBuild = new System.Windows.Forms.TextBox();
            this.OTGWLabelDiagBuild = new System.Windows.Forms.Label();
            this.OTGWTextBoxDiagVersion = new System.Windows.Forms.TextBox();
            this.OTGWLabelDiagVersion = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.MaxTabControl = new System.Windows.Forms.TabControl();
            this.MaxTabPageStatusOverview = new System.Windows.Forms.TabPage();
            this.MaxTabConnection = new System.Windows.Forms.TabPage();
            this.MaxLabelHostName = new System.Windows.Forms.Label();
            this.MAXListboxLog = new System.Windows.Forms.ListBox();
            this.MaxTextBoxHostname = new System.Windows.Forms.TextBox();
            this.MaxButtonDisconnect = new System.Windows.Forms.Button();
            this.MaxButtonConnect = new System.Windows.Forms.Button();
            this.MaxTabRooms = new System.Windows.Forms.TabPage();
            this.MaxTextBoxRoomsNTPServer = new System.Windows.Forms.TextBox();
            this.MaxLabelRoomsNTPServer = new System.Windows.Forms.Label();
            this.MaxTextBoxRoomsValveOffsetPercent = new System.Windows.Forms.TextBox();
            this.MaxTextBoxRoomsValveMaxPercent = new System.Windows.Forms.TextBox();
            this.MaxTextBoxRoomsValvePosition = new System.Windows.Forms.TextBox();
            this.MaxLabelRoomsValveOffsetPercent = new System.Windows.Forms.Label();
            this.MaxLabelRoomsValveMaxPercent = new System.Windows.Forms.Label();
            this.MaxLabelRoomsValvePosition = new System.Windows.Forms.Label();
            this.MaxTextBoxRoomsWindowOpenTemperature = new System.Windows.Forms.TextBox();
            this.MaxTextBoxRoomsWindowOpenDuration = new System.Windows.Forms.TextBox();
            this.MaxLabelRoomsWindowOpenTemperature = new System.Windows.Forms.Label();
            this.MaxLabelRoomsWindowOpenDuration = new System.Windows.Forms.Label();
            this.MaxTextBoxRoomsMaxSetpointTemperature = new System.Windows.Forms.TextBox();
            this.MaxTextBoxRoomsMinSetpointTemperature = new System.Windows.Forms.TextBox();
            this.MaxLabelRoomsMaxSetpointTemperature = new System.Windows.Forms.Label();
            this.MaxLabelRoomsMinSetPointTemperature = new System.Windows.Forms.Label();
            this.MaxTextBoxRoomsDecalcificationHour = new System.Windows.Forms.TextBox();
            this.MaxTextBoxRoomsDecalcificationDay = new System.Windows.Forms.TextBox();
            this.MaxLabelRoomsDecalcificationHour = new System.Windows.Forms.Label();
            this.MaxLabelRoomsDecalcificationDay = new System.Windows.Forms.Label();
            this.MaxTextBoxRoomsBoostPercentage = new System.Windows.Forms.TextBox();
            this.MaxTextBoxRoomsBoostDuration = new System.Windows.Forms.TextBox();
            this.MaxLabelRoomsBoostPercentage = new System.Windows.Forms.Label();
            this.MaxLabelRoomsBoostDuration = new System.Windows.Forms.Label();
            this.MaxTextBoxRoomsDeviceComfortTemperature = new System.Windows.Forms.TextBox();
            this.MaxTextBoxRoomsDeviceEcoTemperature = new System.Windows.Forms.TextBox();
            this.MaxLabelRoomsDeviceComfortTemperature = new System.Windows.Forms.Label();
            this.MaxLabelRoomsDeviceEcoTemperature = new System.Windows.Forms.Label();
            this.MaxTextBoxRoomsDeviceType = new System.Windows.Forms.TextBox();
            this.MaxLabelRoomsDeviceType = new System.Windows.Forms.Label();
            this.MaxTextBoxRoomsDeviceActualTemperature = new System.Windows.Forms.TextBox();
            this.MaxTextBoxRoomsDeviceConfiguredTemperature = new System.Windows.Forms.TextBox();
            this.MaxLabelRoomsDeviceActualTemperature = new System.Windows.Forms.Label();
            this.MaxLabelRoomsDeviceConfiguredTemperature = new System.Windows.Forms.Label();
            this.MaxTextBoxRoomsDeviceRFAddress = new System.Windows.Forms.TextBox();
            this.MaxLabelRoomsDeviceRFAddress = new System.Windows.Forms.Label();
            this.MaxTextBoxRoomsDeviceSerialNumber = new System.Windows.Forms.TextBox();
            this.MaxLabelRoomsDeviceSerialNumber = new System.Windows.Forms.Label();
            this.MaxTextBoxRoomsRoomConfiguredTemperature = new System.Windows.Forms.TextBox();
            this.MaxLabelRoomsRoomConfiguredTemperature = new System.Windows.Forms.Label();
            this.MaxTextBoxRoomsRoomActualTemperature = new System.Windows.Forms.TextBox();
            this.MaxLabelRoomsRoomActualTemperature = new System.Windows.Forms.Label();
            this.MaxTextBoxRoomsRoomRFAddress = new System.Windows.Forms.TextBox();
            this.MaxTextBoxRoomsRoomID = new System.Windows.Forms.TextBox();
            this.MaxLabelRoomsRoomID = new System.Windows.Forms.Label();
            this.MaxLabelRoomsRoomRFAddress = new System.Windows.Forms.Label();
            this.MaxTextBoxRoomsDateTime = new System.Windows.Forms.TextBox();
            this.MaxLabelRoomsDateTime = new System.Windows.Forms.Label();
            this.MaxTextBoxRoomsPushButtonDown = new System.Windows.Forms.TextBox();
            this.MaxTextBoxRoomsPushButtonUp = new System.Windows.Forms.TextBox();
            this.MaxLabelRoomsPushButtonDown = new System.Windows.Forms.Label();
            this.MaxLabelRoomsPushButtonUp = new System.Windows.Forms.Label();
            this.MaxTextBoxRoomsPortalEnabled = new System.Windows.Forms.TextBox();
            this.MaxLabelRoomsPortalEnabled = new System.Windows.Forms.Label();
            this.MaxTextBoxRoomsCubeVersion = new System.Windows.Forms.TextBox();
            this.MaxLabelRoomsCubeVersion = new System.Windows.Forms.Label();
            this.MaxTextBoxRoomsPortalURL = new System.Windows.Forms.TextBox();
            this.MaxLabelRoomsPortalURL = new System.Windows.Forms.Label();
            this.MaxTextBoxRoomsEmptyMemorySlots = new System.Windows.Forms.TextBox();
            this.MaxTextBoxRoomsDutyCycle = new System.Windows.Forms.TextBox();
            this.MaxLabelRoomsEmptyMemorySlots = new System.Windows.Forms.Label();
            this.MaxLabelRoomsDutyCycle = new System.Windows.Forms.Label();
            this.MaxTextBoxRoomsCubeRfAddress = new System.Windows.Forms.TextBox();
            this.MaxTextBoxRoomsCubeSerialNumber = new System.Windows.Forms.TextBox();
            this.MaxTextBoxRoomsCubeName = new System.Windows.Forms.TextBox();
            this.MaxLabelRFAddress = new System.Windows.Forms.Label();
            this.MaxLabelRoomsSerialNumber = new System.Windows.Forms.Label();
            this.MaxLabelRoomsName = new System.Windows.Forms.Label();
            this.MaxListBoxRoomsDevice = new System.Windows.Forms.ListBox();
            this.MaxLabelRoomsDevice = new System.Windows.Forms.Label();
            this.MaxListBoxRoomsRooms = new System.Windows.Forms.ListBox();
            this.MaxListBoxRoomsMaxCube = new System.Windows.Forms.ListBox();
            this.MaxLabelRoomsRoom = new System.Windows.Forms.Label();
            this.MaxLabelRoomsMaxCube = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.MaxCheckBoxEnableLoggingToFile = new System.Windows.Forms.CheckBox();
            this.MaxLabelLogFilename = new System.Windows.Forms.Label();
            this.MaxTextBoxLogFilename = new System.Windows.Forms.TextBox();
            this.MaxLabelAppend = new System.Windows.Forms.Label();
            this.MaxCheckBoxAppend = new System.Windows.Forms.CheckBox();
            this.OTGWGroupbox.SuspendLayout();
            this.OTGWTabcontrol.SuspendLayout();
            this.OTGWTabStatus.SuspendLayout();
            this.OTGWTabConnection.SuspendLayout();
            this.OTGWTabBoilerDiagnostics.SuspendLayout();
            this.OTGWTabOTGWDiagnostics.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.MaxTabControl.SuspendLayout();
            this.MaxTabConnection.SuspendLayout();
            this.MaxTabRooms.SuspendLayout();
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
            this.OTGWButtonDisconnect.Enabled = false;
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
            this.OTGWGroupbox.Location = new System.Drawing.Point(682, 23);
            this.OTGWGroupbox.Name = "OTGWGroupbox";
            this.OTGWGroupbox.Size = new System.Drawing.Size(670, 555);
            this.OTGWGroupbox.TabIndex = 2;
            this.OTGWGroupbox.TabStop = false;
            this.OTGWGroupbox.Text = "OpenTherm Gateway (OTGW)";
            // 
            // OTGWTabcontrol
            // 
            this.OTGWTabcontrol.Controls.Add(this.OTGWTabStatus);
            this.OTGWTabcontrol.Controls.Add(this.OTGWTabConnection);
            this.OTGWTabcontrol.Controls.Add(this.OTGWTabBoilerDiagnostics);
            this.OTGWTabcontrol.Controls.Add(this.OTGWTabOTGWDiagnostics);
            this.OTGWTabcontrol.Location = new System.Drawing.Point(6, 19);
            this.OTGWTabcontrol.Name = "OTGWTabcontrol";
            this.OTGWTabcontrol.SelectedIndex = 0;
            this.OTGWTabcontrol.Size = new System.Drawing.Size(632, 530);
            this.OTGWTabcontrol.TabIndex = 2;
            // 
            // OTGWTabStatus
            // 
            this.OTGWTabStatus.Controls.Add(this.OTGWFormsPlotFloats);
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
            this.OTGWTabStatus.Size = new System.Drawing.Size(624, 504);
            this.OTGWTabStatus.TabIndex = 0;
            this.OTGWTabStatus.Text = "Status Overview";
            // 
            // OTGWFormsPlotFloats
            // 
            this.OTGWFormsPlotFloats.Location = new System.Drawing.Point(0, 186);
            this.OTGWFormsPlotFloats.Margin = new System.Windows.Forms.Padding(0);
            this.OTGWFormsPlotFloats.Name = "OTGWFormsPlotFloats";
            this.OTGWFormsPlotFloats.Size = new System.Drawing.Size(624, 322);
            this.OTGWFormsPlotFloats.TabIndex = 32;
            // 
            // OTGWTextBoxOutsideTemperature
            // 
            this.OTGWTextBoxOutsideTemperature.Location = new System.Drawing.Point(551, 160);
            this.OTGWTextBoxOutsideTemperature.Name = "OTGWTextBoxOutsideTemperature";
            this.OTGWTextBoxOutsideTemperature.ReadOnly = true;
            this.OTGWTextBoxOutsideTemperature.Size = new System.Drawing.Size(43, 20);
            this.OTGWTextBoxOutsideTemperature.TabIndex = 31;
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
            // OTGWTextBoxReturnTemperature
            // 
            this.OTGWTextBoxReturnTemperature.Location = new System.Drawing.Point(318, 157);
            this.OTGWTextBoxReturnTemperature.Name = "OTGWTextBoxReturnTemperature";
            this.OTGWTextBoxReturnTemperature.ReadOnly = true;
            this.OTGWTextBoxReturnTemperature.Size = new System.Drawing.Size(43, 20);
            this.OTGWTextBoxReturnTemperature.TabIndex = 29;
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
            // OTGWTextBoxTapWaterTemperature
            // 
            this.OTGWTextBoxTapWaterTemperature.Location = new System.Drawing.Point(551, 131);
            this.OTGWTextBoxTapWaterTemperature.Name = "OTGWTextBoxTapWaterTemperature";
            this.OTGWTextBoxTapWaterTemperature.ReadOnly = true;
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
            this.OTGWTextBoxTapWaterFlow.ReadOnly = true;
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
            this.OTGWTextBoxWaterPressure.ReadOnly = true;
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
            this.OTGWTextBoxModulationLevel.ReadOnly = true;
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
            this.OTGWTextBoxRoomSetpoint.ReadOnly = true;
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
            this.OTGWTextBoxControlSetpointModified.ReadOnly = true;
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
            this.OTGWTextBoxControlSetpoint.ReadOnly = true;
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
            this.OTGWTextBoxFaultIndication.ReadOnly = true;
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
            this.OTGWTextBoxTapWaterMode.ReadOnly = true;
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
            this.OTGWTextBoxCentralHeatingMode.ReadOnly = true;
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
            this.OTGWTextBoxFlameStatus.ReadOnly = true;
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
            this.OTGWTextBoxBoilerTemp.ReadOnly = true;
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
            this.OTGWTextBoxRoomTemp.ReadOnly = true;
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
            this.OTGWTabConnection.Controls.Add(this.OTGWCheckBoxEnableLoggingToFile);
            this.OTGWTabConnection.Controls.Add(this.OTGWCheckBoxAppend);
            this.OTGWTabConnection.Controls.Add(this.OTGWLabelAppend);
            this.OTGWTabConnection.Controls.Add(this.OTGWTextBoxLogfileName);
            this.OTGWTabConnection.Controls.Add(this.OTGWLabelLogfileName);
            this.OTGWTabConnection.Controls.Add(this.OTGWListboxLog);
            this.OTGWTabConnection.Controls.Add(this.OTGWLabelHostname);
            this.OTGWTabConnection.Controls.Add(this.OTGWTextboxHostname);
            this.OTGWTabConnection.Controls.Add(this.OTGWButtonConnect);
            this.OTGWTabConnection.Controls.Add(this.OTGWButtonDisconnect);
            this.OTGWTabConnection.Location = new System.Drawing.Point(4, 22);
            this.OTGWTabConnection.Name = "OTGWTabConnection";
            this.OTGWTabConnection.Padding = new System.Windows.Forms.Padding(3);
            this.OTGWTabConnection.Size = new System.Drawing.Size(624, 504);
            this.OTGWTabConnection.TabIndex = 1;
            this.OTGWTabConnection.Text = "Connection";
            // 
            // OTGWCheckBoxEnableLoggingToFile
            // 
            this.OTGWCheckBoxEnableLoggingToFile.AutoSize = true;
            this.OTGWCheckBoxEnableLoggingToFile.Location = new System.Drawing.Point(19, 387);
            this.OTGWCheckBoxEnableLoggingToFile.Name = "OTGWCheckBoxEnableLoggingToFile";
            this.OTGWCheckBoxEnableLoggingToFile.Size = new System.Drawing.Size(124, 17);
            this.OTGWCheckBoxEnableLoggingToFile.TabIndex = 11;
            this.OTGWCheckBoxEnableLoggingToFile.Text = "Enable logging to file";
            this.OTGWCheckBoxEnableLoggingToFile.UseVisualStyleBackColor = true;
            // 
            // OTGWCheckBoxAppend
            // 
            this.OTGWCheckBoxAppend.AutoSize = true;
            this.OTGWCheckBoxAppend.Location = new System.Drawing.Point(392, 406);
            this.OTGWCheckBoxAppend.Name = "OTGWCheckBoxAppend";
            this.OTGWCheckBoxAppend.Size = new System.Drawing.Size(15, 14);
            this.OTGWCheckBoxAppend.TabIndex = 10;
            this.OTGWCheckBoxAppend.UseVisualStyleBackColor = true;
            // 
            // OTGWLabelAppend
            // 
            this.OTGWLabelAppend.AutoSize = true;
            this.OTGWLabelAppend.Location = new System.Drawing.Point(342, 407);
            this.OTGWLabelAppend.Name = "OTGWLabelAppend";
            this.OTGWLabelAppend.Size = new System.Drawing.Size(44, 13);
            this.OTGWLabelAppend.TabIndex = 9;
            this.OTGWLabelAppend.Text = "Append";
            // 
            // OTGWTextBoxLogfileName
            // 
            this.OTGWTextBoxLogfileName.Location = new System.Drawing.Point(107, 404);
            this.OTGWTextBoxLogfileName.Name = "OTGWTextBoxLogfileName";
            this.OTGWTextBoxLogfileName.Size = new System.Drawing.Size(221, 20);
            this.OTGWTextBoxLogfileName.TabIndex = 7;
            this.OTGWTextBoxLogfileName.Text = "E:\\HeatControlLogOTGW.txt";
            // 
            // OTGWLabelLogfileName
            // 
            this.OTGWLabelLogfileName.AutoSize = true;
            this.OTGWLabelLogfileName.Location = new System.Drawing.Point(16, 407);
            this.OTGWLabelLogfileName.Name = "OTGWLabelLogfileName";
            this.OTGWLabelLogfileName.Size = new System.Drawing.Size(67, 13);
            this.OTGWLabelLogfileName.TabIndex = 6;
            this.OTGWLabelLogfileName.Text = "Log filename";
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
            // OTGWTabBoilerDiagnostics
            // 
            this.OTGWTabBoilerDiagnostics.BackColor = System.Drawing.SystemColors.Control;
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWTextBoxDiagTapWaterBurnerHours);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWLabelDiagTapBurnerHours);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWTextBoxDiagTapWaterValveHours);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWLabelDiagTapWaterValveHours);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWTextBoxDiagPumpHours);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWLabelDiagPumpHours);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWTextBoxDiagBurnerHours);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWLabelDiagBurnerHours);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWTextBoxDiagTapWaterBurnerStarts);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWLabelDiagTapWaterBurnerStarts);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWTextBoxDiagTapWaterValveStarts);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWLabelDiagTapWaterValveStarts);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWTextBoxDiagPumpStarts);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWLabelDiagPumpStarts);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWTextBoxDiagBurnerStarts);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWLabelDiagBurnerStarts);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWTextBoxDiagExhaustTemperature);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWLabelDiagExhaustTemperature);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWTextBoxDiagTapWater2Temperature);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWLabelDiagTapWater2Temperature);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWTextBoxDiagFlowTemperatureCH2);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWLabelDiagFlowTemperatureCH2);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWTextBoxDiagSolarCollectorTemperature);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWLabelDiagSolarCollectorTemperature);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWTextBoxDiagSolarStorageTemperature);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWLabelDiagSolarStorageTemperature);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWLabelDiagYear);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWLabelDiagTimeAndDay);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWTextBoxDiagOEMDiagnosticCode);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWLabelDiagOEMDiagnosticCode);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWLabelDiagDate);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWTextBoxDiagOEMFaultCode);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWLabelDiagOEMFaultCode);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWTextBoxDiagWaterOvertemp);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWLabelDiagWaterOvertemp);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWTextBoxDiagAirPressureFault);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWLabelDiagAirPressureFault);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWTextBoxDiagGasFlameFault);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWLabelDiagGasFlameFault);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWTextBoxDiagLowWaterPressure);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWLabelDiagLowWaterPressure);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWTextBoxDiagLockoutReset);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWLabelDiagLockoutReset);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWTextBoxDiagServiceRequest);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWLabelDiagServiceRequest);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWTextBoxDiagCH2Present);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWLabelDiagCH2Present);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWTextBoxDiagMasterLowOffPumpControl);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWLabelDiagMasterLowOffPumpControl);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWTextBoxDiagTapWaterConfiguration);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWLabelDiagTapWaterConfiguration);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWTextBoxDiagCoolingConfiguration);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWLabelDiagCoolingConfiguration);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWTextBoxDiagControlType);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWLabelDiagControlType);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWTextBoxDiagTapWaterPresent);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWLabelDiagTapWaterPresent);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWTextBoxDiagSlaveMemberID);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWLabelDiagSlaveMemberID);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWTextBoxDiagMasterMemberID);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWLabelDiagMasterMemberID);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWTextBoxDiagCH2Enabled);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWLabelDiagCH2Enabled);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWTextBoxDiagOTCActive);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWLabelDiagOTCActive);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWTextBoxDiagCoolingEnabled);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWLabelDiagCoolingEnabled);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWTextBoxDiagTapWaterEnabled);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWLabelDiagTapWaterEnabled);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWTextBoxDiagCentralHeatingEnabled);
            this.OTGWTabBoilerDiagnostics.Controls.Add(this.OTGWLabelDiagCentralHeatingEnabled);
            this.OTGWTabBoilerDiagnostics.Location = new System.Drawing.Point(4, 22);
            this.OTGWTabBoilerDiagnostics.Name = "OTGWTabBoilerDiagnostics";
            this.OTGWTabBoilerDiagnostics.Padding = new System.Windows.Forms.Padding(3);
            this.OTGWTabBoilerDiagnostics.Size = new System.Drawing.Size(624, 504);
            this.OTGWTabBoilerDiagnostics.TabIndex = 2;
            this.OTGWTabBoilerDiagnostics.Text = "Boiler diagnostics";
            // 
            // OTGWTextBoxDiagTapWaterBurnerHours
            // 
            this.OTGWTextBoxDiagTapWaterBurnerHours.Location = new System.Drawing.Point(526, 317);
            this.OTGWTextBoxDiagTapWaterBurnerHours.Name = "OTGWTextBoxDiagTapWaterBurnerHours";
            this.OTGWTextBoxDiagTapWaterBurnerHours.ReadOnly = true;
            this.OTGWTextBoxDiagTapWaterBurnerHours.Size = new System.Drawing.Size(54, 20);
            this.OTGWTextBoxDiagTapWaterBurnerHours.TabIndex = 66;
            // 
            // OTGWLabelDiagTapBurnerHours
            // 
            this.OTGWLabelDiagTapBurnerHours.AutoSize = true;
            this.OTGWLabelDiagTapBurnerHours.Location = new System.Drawing.Point(417, 320);
            this.OTGWLabelDiagTapBurnerHours.Name = "OTGWLabelDiagTapBurnerHours";
            this.OTGWLabelDiagTapBurnerHours.Size = new System.Drawing.Size(88, 13);
            this.OTGWLabelDiagTapBurnerHours.TabIndex = 65;
            this.OTGWLabelDiagTapBurnerHours.Text = "Tap burner hours";
            // 
            // OTGWTextBoxDiagTapWaterValveHours
            // 
            this.OTGWTextBoxDiagTapWaterValveHours.Location = new System.Drawing.Point(526, 291);
            this.OTGWTextBoxDiagTapWaterValveHours.Name = "OTGWTextBoxDiagTapWaterValveHours";
            this.OTGWTextBoxDiagTapWaterValveHours.ReadOnly = true;
            this.OTGWTextBoxDiagTapWaterValveHours.Size = new System.Drawing.Size(54, 20);
            this.OTGWTextBoxDiagTapWaterValveHours.TabIndex = 64;
            // 
            // OTGWLabelDiagTapWaterValveHours
            // 
            this.OTGWLabelDiagTapWaterValveHours.AutoSize = true;
            this.OTGWLabelDiagTapWaterValveHours.Location = new System.Drawing.Point(417, 294);
            this.OTGWLabelDiagTapWaterValveHours.Name = "OTGWLabelDiagTapWaterValveHours";
            this.OTGWLabelDiagTapWaterValveHours.Size = new System.Drawing.Size(84, 13);
            this.OTGWLabelDiagTapWaterValveHours.TabIndex = 63;
            this.OTGWLabelDiagTapWaterValveHours.Text = "Tap valve hours";
            // 
            // OTGWTextBoxDiagPumpHours
            // 
            this.OTGWTextBoxDiagPumpHours.Location = new System.Drawing.Point(526, 265);
            this.OTGWTextBoxDiagPumpHours.Name = "OTGWTextBoxDiagPumpHours";
            this.OTGWTextBoxDiagPumpHours.ReadOnly = true;
            this.OTGWTextBoxDiagPumpHours.Size = new System.Drawing.Size(54, 20);
            this.OTGWTextBoxDiagPumpHours.TabIndex = 62;
            // 
            // OTGWLabelDiagPumpHours
            // 
            this.OTGWLabelDiagPumpHours.AutoSize = true;
            this.OTGWLabelDiagPumpHours.Location = new System.Drawing.Point(417, 268);
            this.OTGWLabelDiagPumpHours.Name = "OTGWLabelDiagPumpHours";
            this.OTGWLabelDiagPumpHours.Size = new System.Drawing.Size(63, 13);
            this.OTGWLabelDiagPumpHours.TabIndex = 61;
            this.OTGWLabelDiagPumpHours.Text = "Pump hours";
            // 
            // OTGWTextBoxDiagBurnerHours
            // 
            this.OTGWTextBoxDiagBurnerHours.Location = new System.Drawing.Point(526, 239);
            this.OTGWTextBoxDiagBurnerHours.Name = "OTGWTextBoxDiagBurnerHours";
            this.OTGWTextBoxDiagBurnerHours.ReadOnly = true;
            this.OTGWTextBoxDiagBurnerHours.Size = new System.Drawing.Size(54, 20);
            this.OTGWTextBoxDiagBurnerHours.TabIndex = 60;
            // 
            // OTGWLabelDiagBurnerHours
            // 
            this.OTGWLabelDiagBurnerHours.AutoSize = true;
            this.OTGWLabelDiagBurnerHours.Location = new System.Drawing.Point(417, 242);
            this.OTGWLabelDiagBurnerHours.Name = "OTGWLabelDiagBurnerHours";
            this.OTGWLabelDiagBurnerHours.Size = new System.Drawing.Size(67, 13);
            this.OTGWLabelDiagBurnerHours.TabIndex = 59;
            this.OTGWLabelDiagBurnerHours.Text = "Burner hours";
            // 
            // OTGWTextBoxDiagTapWaterBurnerStarts
            // 
            this.OTGWTextBoxDiagTapWaterBurnerStarts.Location = new System.Drawing.Point(329, 317);
            this.OTGWTextBoxDiagTapWaterBurnerStarts.Name = "OTGWTextBoxDiagTapWaterBurnerStarts";
            this.OTGWTextBoxDiagTapWaterBurnerStarts.ReadOnly = true;
            this.OTGWTextBoxDiagTapWaterBurnerStarts.Size = new System.Drawing.Size(54, 20);
            this.OTGWTextBoxDiagTapWaterBurnerStarts.TabIndex = 58;
            // 
            // OTGWLabelDiagTapWaterBurnerStarts
            // 
            this.OTGWLabelDiagTapWaterBurnerStarts.AutoSize = true;
            this.OTGWLabelDiagTapWaterBurnerStarts.Location = new System.Drawing.Point(222, 320);
            this.OTGWLabelDiagTapWaterBurnerStarts.Name = "OTGWLabelDiagTapWaterBurnerStarts";
            this.OTGWLabelDiagTapWaterBurnerStarts.Size = new System.Drawing.Size(87, 13);
            this.OTGWLabelDiagTapWaterBurnerStarts.TabIndex = 57;
            this.OTGWLabelDiagTapWaterBurnerStarts.Text = "Tap burner starts";
            // 
            // OTGWTextBoxDiagTapWaterValveStarts
            // 
            this.OTGWTextBoxDiagTapWaterValveStarts.Location = new System.Drawing.Point(329, 291);
            this.OTGWTextBoxDiagTapWaterValveStarts.Name = "OTGWTextBoxDiagTapWaterValveStarts";
            this.OTGWTextBoxDiagTapWaterValveStarts.ReadOnly = true;
            this.OTGWTextBoxDiagTapWaterValveStarts.Size = new System.Drawing.Size(54, 20);
            this.OTGWTextBoxDiagTapWaterValveStarts.TabIndex = 56;
            // 
            // OTGWLabelDiagTapWaterValveStarts
            // 
            this.OTGWLabelDiagTapWaterValveStarts.AutoSize = true;
            this.OTGWLabelDiagTapWaterValveStarts.Location = new System.Drawing.Point(222, 294);
            this.OTGWLabelDiagTapWaterValveStarts.Name = "OTGWLabelDiagTapWaterValveStarts";
            this.OTGWLabelDiagTapWaterValveStarts.Size = new System.Drawing.Size(83, 13);
            this.OTGWLabelDiagTapWaterValveStarts.TabIndex = 55;
            this.OTGWLabelDiagTapWaterValveStarts.Text = "Tap valve starts";
            // 
            // OTGWTextBoxDiagPumpStarts
            // 
            this.OTGWTextBoxDiagPumpStarts.Location = new System.Drawing.Point(329, 265);
            this.OTGWTextBoxDiagPumpStarts.Name = "OTGWTextBoxDiagPumpStarts";
            this.OTGWTextBoxDiagPumpStarts.ReadOnly = true;
            this.OTGWTextBoxDiagPumpStarts.Size = new System.Drawing.Size(54, 20);
            this.OTGWTextBoxDiagPumpStarts.TabIndex = 54;
            // 
            // OTGWLabelDiagPumpStarts
            // 
            this.OTGWLabelDiagPumpStarts.AutoSize = true;
            this.OTGWLabelDiagPumpStarts.Location = new System.Drawing.Point(222, 268);
            this.OTGWLabelDiagPumpStarts.Name = "OTGWLabelDiagPumpStarts";
            this.OTGWLabelDiagPumpStarts.Size = new System.Drawing.Size(62, 13);
            this.OTGWLabelDiagPumpStarts.TabIndex = 53;
            this.OTGWLabelDiagPumpStarts.Text = "Pump starts";
            // 
            // OTGWTextBoxDiagBurnerStarts
            // 
            this.OTGWTextBoxDiagBurnerStarts.Location = new System.Drawing.Point(329, 239);
            this.OTGWTextBoxDiagBurnerStarts.Name = "OTGWTextBoxDiagBurnerStarts";
            this.OTGWTextBoxDiagBurnerStarts.ReadOnly = true;
            this.OTGWTextBoxDiagBurnerStarts.Size = new System.Drawing.Size(54, 20);
            this.OTGWTextBoxDiagBurnerStarts.TabIndex = 52;
            // 
            // OTGWLabelDiagBurnerStarts
            // 
            this.OTGWLabelDiagBurnerStarts.AutoSize = true;
            this.OTGWLabelDiagBurnerStarts.Location = new System.Drawing.Point(222, 242);
            this.OTGWLabelDiagBurnerStarts.Name = "OTGWLabelDiagBurnerStarts";
            this.OTGWLabelDiagBurnerStarts.Size = new System.Drawing.Size(66, 13);
            this.OTGWLabelDiagBurnerStarts.TabIndex = 51;
            this.OTGWLabelDiagBurnerStarts.Text = "Burner starts";
            // 
            // OTGWTextBoxDiagExhaustTemperature
            // 
            this.OTGWTextBoxDiagExhaustTemperature.Location = new System.Drawing.Point(135, 343);
            this.OTGWTextBoxDiagExhaustTemperature.Name = "OTGWTextBoxDiagExhaustTemperature";
            this.OTGWTextBoxDiagExhaustTemperature.ReadOnly = true;
            this.OTGWTextBoxDiagExhaustTemperature.Size = new System.Drawing.Size(54, 20);
            this.OTGWTextBoxDiagExhaustTemperature.TabIndex = 50;
            // 
            // OTGWLabelDiagExhaustTemperature
            // 
            this.OTGWLabelDiagExhaustTemperature.AutoSize = true;
            this.OTGWLabelDiagExhaustTemperature.Location = new System.Drawing.Point(12, 346);
            this.OTGWLabelDiagExhaustTemperature.Name = "OTGWLabelDiagExhaustTemperature";
            this.OTGWLabelDiagExhaustTemperature.Size = new System.Drawing.Size(104, 13);
            this.OTGWLabelDiagExhaustTemperature.TabIndex = 49;
            this.OTGWLabelDiagExhaustTemperature.Text = "Exhaust temperature";
            // 
            // OTGWTextBoxDiagTapWater2Temperature
            // 
            this.OTGWTextBoxDiagTapWater2Temperature.Location = new System.Drawing.Point(135, 317);
            this.OTGWTextBoxDiagTapWater2Temperature.Name = "OTGWTextBoxDiagTapWater2Temperature";
            this.OTGWTextBoxDiagTapWater2Temperature.ReadOnly = true;
            this.OTGWTextBoxDiagTapWater2Temperature.Size = new System.Drawing.Size(54, 20);
            this.OTGWTextBoxDiagTapWater2Temperature.TabIndex = 48;
            // 
            // OTGWLabelDiagTapWater2Temperature
            // 
            this.OTGWLabelDiagTapWater2Temperature.AutoSize = true;
            this.OTGWLabelDiagTapWater2Temperature.Location = new System.Drawing.Point(12, 320);
            this.OTGWLabelDiagTapWater2Temperature.Name = "OTGWLabelDiagTapWater2Temperature";
            this.OTGWLabelDiagTapWater2Temperature.Size = new System.Drawing.Size(90, 13);
            this.OTGWLabelDiagTapWater2Temperature.TabIndex = 47;
            this.OTGWLabelDiagTapWater2Temperature.Text = "Tap water 2 temp";
            // 
            // OTGWTextBoxDiagFlowTemperatureCH2
            // 
            this.OTGWTextBoxDiagFlowTemperatureCH2.Location = new System.Drawing.Point(135, 291);
            this.OTGWTextBoxDiagFlowTemperatureCH2.Name = "OTGWTextBoxDiagFlowTemperatureCH2";
            this.OTGWTextBoxDiagFlowTemperatureCH2.ReadOnly = true;
            this.OTGWTextBoxDiagFlowTemperatureCH2.Size = new System.Drawing.Size(54, 20);
            this.OTGWTextBoxDiagFlowTemperatureCH2.TabIndex = 46;
            // 
            // OTGWLabelDiagFlowTemperatureCH2
            // 
            this.OTGWLabelDiagFlowTemperatureCH2.AutoSize = true;
            this.OTGWLabelDiagFlowTemperatureCH2.Location = new System.Drawing.Point(12, 294);
            this.OTGWLabelDiagFlowTemperatureCH2.Name = "OTGWLabelDiagFlowTemperatureCH2";
            this.OTGWLabelDiagFlowTemperatureCH2.Size = new System.Drawing.Size(121, 13);
            this.OTGWLabelDiagFlowTemperatureCH2.TabIndex = 45;
            this.OTGWLabelDiagFlowTemperatureCH2.Text = "Centr.Heat. 2 Flow temp";
            // 
            // OTGWTextBoxDiagSolarCollectorTemperature
            // 
            this.OTGWTextBoxDiagSolarCollectorTemperature.Location = new System.Drawing.Point(135, 265);
            this.OTGWTextBoxDiagSolarCollectorTemperature.Name = "OTGWTextBoxDiagSolarCollectorTemperature";
            this.OTGWTextBoxDiagSolarCollectorTemperature.ReadOnly = true;
            this.OTGWTextBoxDiagSolarCollectorTemperature.Size = new System.Drawing.Size(54, 20);
            this.OTGWTextBoxDiagSolarCollectorTemperature.TabIndex = 44;
            // 
            // OTGWLabelDiagSolarCollectorTemperature
            // 
            this.OTGWLabelDiagSolarCollectorTemperature.AutoSize = true;
            this.OTGWLabelDiagSolarCollectorTemperature.Location = new System.Drawing.Point(12, 268);
            this.OTGWLabelDiagSolarCollectorTemperature.Name = "OTGWLabelDiagSolarCollectorTemperature";
            this.OTGWLabelDiagSolarCollectorTemperature.Size = new System.Drawing.Size(100, 13);
            this.OTGWLabelDiagSolarCollectorTemperature.TabIndex = 43;
            this.OTGWLabelDiagSolarCollectorTemperature.Text = "Solar collector temp";
            // 
            // OTGWTextBoxDiagSolarStorageTemperature
            // 
            this.OTGWTextBoxDiagSolarStorageTemperature.Location = new System.Drawing.Point(135, 239);
            this.OTGWTextBoxDiagSolarStorageTemperature.Name = "OTGWTextBoxDiagSolarStorageTemperature";
            this.OTGWTextBoxDiagSolarStorageTemperature.ReadOnly = true;
            this.OTGWTextBoxDiagSolarStorageTemperature.Size = new System.Drawing.Size(54, 20);
            this.OTGWTextBoxDiagSolarStorageTemperature.TabIndex = 42;
            // 
            // OTGWLabelDiagSolarStorageTemperature
            // 
            this.OTGWLabelDiagSolarStorageTemperature.AutoSize = true;
            this.OTGWLabelDiagSolarStorageTemperature.Location = new System.Drawing.Point(12, 242);
            this.OTGWLabelDiagSolarStorageTemperature.Name = "OTGWLabelDiagSolarStorageTemperature";
            this.OTGWLabelDiagSolarStorageTemperature.Size = new System.Drawing.Size(95, 13);
            this.OTGWLabelDiagSolarStorageTemperature.TabIndex = 35;
            this.OTGWLabelDiagSolarStorageTemperature.Text = "Solar storage temp";
            // 
            // OTGWLabelDiagYear
            // 
            this.OTGWLabelDiagYear.AutoSize = true;
            this.OTGWLabelDiagYear.Location = new System.Drawing.Point(589, 357);
            this.OTGWLabelDiagYear.Name = "OTGWLabelDiagYear";
            this.OTGWLabelDiagYear.Size = new System.Drawing.Size(29, 13);
            this.OTGWLabelDiagYear.TabIndex = 34;
            this.OTGWLabelDiagYear.Text = "Year";
            // 
            // OTGWLabelDiagTimeAndDay
            // 
            this.OTGWLabelDiagTimeAndDay.AutoSize = true;
            this.OTGWLabelDiagTimeAndDay.Location = new System.Drawing.Point(404, 357);
            this.OTGWLabelDiagTimeAndDay.Name = "OTGWLabelDiagTimeAndDay";
            this.OTGWLabelDiagTimeAndDay.Size = new System.Drawing.Size(30, 13);
            this.OTGWLabelDiagTimeAndDay.TabIndex = 32;
            this.OTGWLabelDiagTimeAndDay.Text = "Time";
            // 
            // OTGWTextBoxDiagOEMDiagnosticCode
            // 
            this.OTGWTextBoxDiagOEMDiagnosticCode.Location = new System.Drawing.Point(564, 191);
            this.OTGWTextBoxDiagOEMDiagnosticCode.Name = "OTGWTextBoxDiagOEMDiagnosticCode";
            this.OTGWTextBoxDiagOEMDiagnosticCode.ReadOnly = true;
            this.OTGWTextBoxDiagOEMDiagnosticCode.Size = new System.Drawing.Size(54, 20);
            this.OTGWTextBoxDiagOEMDiagnosticCode.TabIndex = 41;
            // 
            // OTGWLabelDiagOEMDiagnosticCode
            // 
            this.OTGWLabelDiagOEMDiagnosticCode.AutoSize = true;
            this.OTGWLabelDiagOEMDiagnosticCode.Location = new System.Drawing.Point(464, 194);
            this.OTGWLabelDiagOEMDiagnosticCode.Name = "OTGWLabelDiagOEMDiagnosticCode";
            this.OTGWLabelDiagOEMDiagnosticCode.Size = new System.Drawing.Size(86, 13);
            this.OTGWLabelDiagOEMDiagnosticCode.TabIndex = 40;
            this.OTGWLabelDiagOEMDiagnosticCode.Text = "OEM Diag. code";
            // 
            // OTGWLabelDiagDate
            // 
            this.OTGWLabelDiagDate.AutoSize = true;
            this.OTGWLabelDiagDate.Location = new System.Drawing.Point(517, 357);
            this.OTGWLabelDiagDate.Name = "OTGWLabelDiagDate";
            this.OTGWLabelDiagDate.Size = new System.Drawing.Size(30, 13);
            this.OTGWLabelDiagDate.TabIndex = 33;
            this.OTGWLabelDiagDate.Text = "Date";
            // 
            // OTGWTextBoxDiagOEMFaultCode
            // 
            this.OTGWTextBoxDiagOEMFaultCode.Location = new System.Drawing.Point(564, 165);
            this.OTGWTextBoxDiagOEMFaultCode.Name = "OTGWTextBoxDiagOEMFaultCode";
            this.OTGWTextBoxDiagOEMFaultCode.ReadOnly = true;
            this.OTGWTextBoxDiagOEMFaultCode.Size = new System.Drawing.Size(54, 20);
            this.OTGWTextBoxDiagOEMFaultCode.TabIndex = 39;
            // 
            // OTGWLabelDiagOEMFaultCode
            // 
            this.OTGWLabelDiagOEMFaultCode.AutoSize = true;
            this.OTGWLabelDiagOEMFaultCode.Location = new System.Drawing.Point(464, 168);
            this.OTGWLabelDiagOEMFaultCode.Name = "OTGWLabelDiagOEMFaultCode";
            this.OTGWLabelDiagOEMFaultCode.Size = new System.Drawing.Size(84, 13);
            this.OTGWLabelDiagOEMFaultCode.TabIndex = 38;
            this.OTGWLabelDiagOEMFaultCode.Text = "OEM Fault code";
            // 
            // OTGWTextBoxDiagWaterOvertemp
            // 
            this.OTGWTextBoxDiagWaterOvertemp.Location = new System.Drawing.Point(564, 139);
            this.OTGWTextBoxDiagWaterOvertemp.Name = "OTGWTextBoxDiagWaterOvertemp";
            this.OTGWTextBoxDiagWaterOvertemp.ReadOnly = true;
            this.OTGWTextBoxDiagWaterOvertemp.Size = new System.Drawing.Size(54, 20);
            this.OTGWTextBoxDiagWaterOvertemp.TabIndex = 37;
            // 
            // OTGWLabelDiagWaterOvertemp
            // 
            this.OTGWLabelDiagWaterOvertemp.AutoSize = true;
            this.OTGWLabelDiagWaterOvertemp.Location = new System.Drawing.Point(464, 143);
            this.OTGWLabelDiagWaterOvertemp.Name = "OTGWLabelDiagWaterOvertemp";
            this.OTGWLabelDiagWaterOvertemp.Size = new System.Drawing.Size(83, 13);
            this.OTGWLabelDiagWaterOvertemp.TabIndex = 36;
            this.OTGWLabelDiagWaterOvertemp.Text = "Water overtemp";
            // 
            // OTGWTextBoxDiagAirPressureFault
            // 
            this.OTGWTextBoxDiagAirPressureFault.Location = new System.Drawing.Point(564, 113);
            this.OTGWTextBoxDiagAirPressureFault.Name = "OTGWTextBoxDiagAirPressureFault";
            this.OTGWTextBoxDiagAirPressureFault.ReadOnly = true;
            this.OTGWTextBoxDiagAirPressureFault.Size = new System.Drawing.Size(54, 20);
            this.OTGWTextBoxDiagAirPressureFault.TabIndex = 35;
            // 
            // OTGWLabelDiagAirPressureFault
            // 
            this.OTGWLabelDiagAirPressureFault.AutoSize = true;
            this.OTGWLabelDiagAirPressureFault.Location = new System.Drawing.Point(464, 116);
            this.OTGWLabelDiagAirPressureFault.Name = "OTGWLabelDiagAirPressureFault";
            this.OTGWLabelDiagAirPressureFault.Size = new System.Drawing.Size(85, 13);
            this.OTGWLabelDiagAirPressureFault.TabIndex = 34;
            this.OTGWLabelDiagAirPressureFault.Text = "Air pressure fault";
            // 
            // OTGWTextBoxDiagGasFlameFault
            // 
            this.OTGWTextBoxDiagGasFlameFault.Location = new System.Drawing.Point(564, 87);
            this.OTGWTextBoxDiagGasFlameFault.Name = "OTGWTextBoxDiagGasFlameFault";
            this.OTGWTextBoxDiagGasFlameFault.ReadOnly = true;
            this.OTGWTextBoxDiagGasFlameFault.Size = new System.Drawing.Size(54, 20);
            this.OTGWTextBoxDiagGasFlameFault.TabIndex = 33;
            // 
            // OTGWLabelDiagGasFlameFault
            // 
            this.OTGWLabelDiagGasFlameFault.AutoSize = true;
            this.OTGWLabelDiagGasFlameFault.Location = new System.Drawing.Point(464, 90);
            this.OTGWLabelDiagGasFlameFault.Name = "OTGWLabelDiagGasFlameFault";
            this.OTGWLabelDiagGasFlameFault.Size = new System.Drawing.Size(77, 13);
            this.OTGWLabelDiagGasFlameFault.TabIndex = 32;
            this.OTGWLabelDiagGasFlameFault.Text = "Gas flame fault";
            // 
            // OTGWTextBoxDiagLowWaterPressure
            // 
            this.OTGWTextBoxDiagLowWaterPressure.Location = new System.Drawing.Point(564, 61);
            this.OTGWTextBoxDiagLowWaterPressure.Name = "OTGWTextBoxDiagLowWaterPressure";
            this.OTGWTextBoxDiagLowWaterPressure.ReadOnly = true;
            this.OTGWTextBoxDiagLowWaterPressure.Size = new System.Drawing.Size(54, 20);
            this.OTGWTextBoxDiagLowWaterPressure.TabIndex = 31;
            // 
            // OTGWLabelDiagLowWaterPressure
            // 
            this.OTGWLabelDiagLowWaterPressure.AutoSize = true;
            this.OTGWLabelDiagLowWaterPressure.Location = new System.Drawing.Point(464, 64);
            this.OTGWLabelDiagLowWaterPressure.Name = "OTGWLabelDiagLowWaterPressure";
            this.OTGWLabelDiagLowWaterPressure.Size = new System.Drawing.Size(99, 13);
            this.OTGWLabelDiagLowWaterPressure.TabIndex = 30;
            this.OTGWLabelDiagLowWaterPressure.Text = "Low water pressure";
            // 
            // OTGWTextBoxDiagLockoutReset
            // 
            this.OTGWTextBoxDiagLockoutReset.Location = new System.Drawing.Point(564, 35);
            this.OTGWTextBoxDiagLockoutReset.Name = "OTGWTextBoxDiagLockoutReset";
            this.OTGWTextBoxDiagLockoutReset.ReadOnly = true;
            this.OTGWTextBoxDiagLockoutReset.Size = new System.Drawing.Size(54, 20);
            this.OTGWTextBoxDiagLockoutReset.TabIndex = 29;
            // 
            // OTGWLabelDiagLockoutReset
            // 
            this.OTGWLabelDiagLockoutReset.AutoSize = true;
            this.OTGWLabelDiagLockoutReset.Location = new System.Drawing.Point(464, 38);
            this.OTGWLabelDiagLockoutReset.Name = "OTGWLabelDiagLockoutReset";
            this.OTGWLabelDiagLockoutReset.Size = new System.Drawing.Size(72, 13);
            this.OTGWLabelDiagLockoutReset.TabIndex = 28;
            this.OTGWLabelDiagLockoutReset.Text = "Lockout reset";
            // 
            // OTGWTextBoxDiagServiceRequest
            // 
            this.OTGWTextBoxDiagServiceRequest.Location = new System.Drawing.Point(564, 9);
            this.OTGWTextBoxDiagServiceRequest.Name = "OTGWTextBoxDiagServiceRequest";
            this.OTGWTextBoxDiagServiceRequest.ReadOnly = true;
            this.OTGWTextBoxDiagServiceRequest.Size = new System.Drawing.Size(54, 20);
            this.OTGWTextBoxDiagServiceRequest.TabIndex = 27;
            // 
            // OTGWLabelDiagServiceRequest
            // 
            this.OTGWLabelDiagServiceRequest.AutoSize = true;
            this.OTGWLabelDiagServiceRequest.Location = new System.Drawing.Point(464, 12);
            this.OTGWLabelDiagServiceRequest.Name = "OTGWLabelDiagServiceRequest";
            this.OTGWLabelDiagServiceRequest.Size = new System.Drawing.Size(81, 13);
            this.OTGWLabelDiagServiceRequest.TabIndex = 26;
            this.OTGWLabelDiagServiceRequest.Text = "Service request";
            // 
            // OTGWTextBoxDiagCH2Present
            // 
            this.OTGWTextBoxDiagCH2Present.Location = new System.Drawing.Point(369, 113);
            this.OTGWTextBoxDiagCH2Present.Name = "OTGWTextBoxDiagCH2Present";
            this.OTGWTextBoxDiagCH2Present.ReadOnly = true;
            this.OTGWTextBoxDiagCH2Present.Size = new System.Drawing.Size(54, 20);
            this.OTGWTextBoxDiagCH2Present.TabIndex = 25;
            // 
            // OTGWLabelDiagCH2Present
            // 
            this.OTGWLabelDiagCH2Present.AutoSize = true;
            this.OTGWLabelDiagCH2Present.Location = new System.Drawing.Point(222, 116);
            this.OTGWLabelDiagCH2Present.Name = "OTGWLabelDiagCH2Present";
            this.OTGWLabelDiagCH2Present.Size = new System.Drawing.Size(125, 13);
            this.OTGWLabelDiagCH2Present.TabIndex = 24;
            this.OTGWLabelDiagCH2Present.Text = "Central heating 2 present";
            // 
            // OTGWTextBoxDiagMasterLowOffPumpControl
            // 
            this.OTGWTextBoxDiagMasterLowOffPumpControl.Location = new System.Drawing.Point(369, 139);
            this.OTGWTextBoxDiagMasterLowOffPumpControl.Name = "OTGWTextBoxDiagMasterLowOffPumpControl";
            this.OTGWTextBoxDiagMasterLowOffPumpControl.ReadOnly = true;
            this.OTGWTextBoxDiagMasterLowOffPumpControl.Size = new System.Drawing.Size(54, 20);
            this.OTGWTextBoxDiagMasterLowOffPumpControl.TabIndex = 23;
            // 
            // OTGWLabelDiagMasterLowOffPumpControl
            // 
            this.OTGWLabelDiagMasterLowOffPumpControl.AutoSize = true;
            this.OTGWLabelDiagMasterLowOffPumpControl.Location = new System.Drawing.Point(222, 142);
            this.OTGWLabelDiagMasterLowOffPumpControl.Name = "OTGWLabelDiagMasterLowOffPumpControl";
            this.OTGWLabelDiagMasterLowOffPumpControl.Size = new System.Drawing.Size(147, 13);
            this.OTGWLabelDiagMasterLowOffPumpControl.TabIndex = 22;
            this.OTGWLabelDiagMasterLowOffPumpControl.Text = "Master low off && Pump control";
            // 
            // OTGWTextBoxDiagTapWaterConfiguration
            // 
            this.OTGWTextBoxDiagTapWaterConfiguration.Location = new System.Drawing.Point(369, 87);
            this.OTGWTextBoxDiagTapWaterConfiguration.Name = "OTGWTextBoxDiagTapWaterConfiguration";
            this.OTGWTextBoxDiagTapWaterConfiguration.ReadOnly = true;
            this.OTGWTextBoxDiagTapWaterConfiguration.Size = new System.Drawing.Size(54, 20);
            this.OTGWTextBoxDiagTapWaterConfiguration.TabIndex = 21;
            // 
            // OTGWLabelDiagTapWaterConfiguration
            // 
            this.OTGWLabelDiagTapWaterConfiguration.AutoSize = true;
            this.OTGWLabelDiagTapWaterConfiguration.Location = new System.Drawing.Point(222, 90);
            this.OTGWLabelDiagTapWaterConfiguration.Name = "OTGWLabelDiagTapWaterConfiguration";
            this.OTGWLabelDiagTapWaterConfiguration.Size = new System.Drawing.Size(119, 13);
            this.OTGWLabelDiagTapWaterConfiguration.TabIndex = 20;
            this.OTGWLabelDiagTapWaterConfiguration.Text = "Tap water configuration";
            // 
            // OTGWTextBoxDiagCoolingConfiguration
            // 
            this.OTGWTextBoxDiagCoolingConfiguration.Location = new System.Drawing.Point(369, 61);
            this.OTGWTextBoxDiagCoolingConfiguration.Name = "OTGWTextBoxDiagCoolingConfiguration";
            this.OTGWTextBoxDiagCoolingConfiguration.ReadOnly = true;
            this.OTGWTextBoxDiagCoolingConfiguration.Size = new System.Drawing.Size(54, 20);
            this.OTGWTextBoxDiagCoolingConfiguration.TabIndex = 19;
            // 
            // OTGWLabelDiagCoolingConfiguration
            // 
            this.OTGWLabelDiagCoolingConfiguration.AutoSize = true;
            this.OTGWLabelDiagCoolingConfiguration.Location = new System.Drawing.Point(222, 64);
            this.OTGWLabelDiagCoolingConfiguration.Name = "OTGWLabelDiagCoolingConfiguration";
            this.OTGWLabelDiagCoolingConfiguration.Size = new System.Drawing.Size(106, 13);
            this.OTGWLabelDiagCoolingConfiguration.TabIndex = 18;
            this.OTGWLabelDiagCoolingConfiguration.Text = "Cooling configuration";
            // 
            // OTGWTextBoxDiagControlType
            // 
            this.OTGWTextBoxDiagControlType.Location = new System.Drawing.Point(369, 9);
            this.OTGWTextBoxDiagControlType.Name = "OTGWTextBoxDiagControlType";
            this.OTGWTextBoxDiagControlType.ReadOnly = true;
            this.OTGWTextBoxDiagControlType.Size = new System.Drawing.Size(54, 20);
            this.OTGWTextBoxDiagControlType.TabIndex = 17;
            // 
            // OTGWLabelDiagControlType
            // 
            this.OTGWLabelDiagControlType.AutoSize = true;
            this.OTGWLabelDiagControlType.Location = new System.Drawing.Point(222, 12);
            this.OTGWLabelDiagControlType.Name = "OTGWLabelDiagControlType";
            this.OTGWLabelDiagControlType.Size = new System.Drawing.Size(63, 13);
            this.OTGWLabelDiagControlType.TabIndex = 16;
            this.OTGWLabelDiagControlType.Text = "Control type";
            // 
            // OTGWTextBoxDiagTapWaterPresent
            // 
            this.OTGWTextBoxDiagTapWaterPresent.Location = new System.Drawing.Point(369, 35);
            this.OTGWTextBoxDiagTapWaterPresent.Name = "OTGWTextBoxDiagTapWaterPresent";
            this.OTGWTextBoxDiagTapWaterPresent.ReadOnly = true;
            this.OTGWTextBoxDiagTapWaterPresent.Size = new System.Drawing.Size(54, 20);
            this.OTGWTextBoxDiagTapWaterPresent.TabIndex = 15;
            // 
            // OTGWLabelDiagTapWaterPresent
            // 
            this.OTGWLabelDiagTapWaterPresent.AutoSize = true;
            this.OTGWLabelDiagTapWaterPresent.Location = new System.Drawing.Point(222, 38);
            this.OTGWLabelDiagTapWaterPresent.Name = "OTGWLabelDiagTapWaterPresent";
            this.OTGWLabelDiagTapWaterPresent.Size = new System.Drawing.Size(93, 13);
            this.OTGWLabelDiagTapWaterPresent.TabIndex = 14;
            this.OTGWLabelDiagTapWaterPresent.Text = "Tap water present";
            // 
            // OTGWTextBoxDiagSlaveMemberID
            // 
            this.OTGWTextBoxDiagSlaveMemberID.Location = new System.Drawing.Point(369, 191);
            this.OTGWTextBoxDiagSlaveMemberID.Name = "OTGWTextBoxDiagSlaveMemberID";
            this.OTGWTextBoxDiagSlaveMemberID.ReadOnly = true;
            this.OTGWTextBoxDiagSlaveMemberID.Size = new System.Drawing.Size(54, 20);
            this.OTGWTextBoxDiagSlaveMemberID.TabIndex = 13;
            // 
            // OTGWLabelDiagSlaveMemberID
            // 
            this.OTGWLabelDiagSlaveMemberID.AutoSize = true;
            this.OTGWLabelDiagSlaveMemberID.Location = new System.Drawing.Point(222, 194);
            this.OTGWLabelDiagSlaveMemberID.Name = "OTGWLabelDiagSlaveMemberID";
            this.OTGWLabelDiagSlaveMemberID.Size = new System.Drawing.Size(88, 13);
            this.OTGWLabelDiagSlaveMemberID.TabIndex = 12;
            this.OTGWLabelDiagSlaveMemberID.Text = "Slave member ID";
            // 
            // OTGWTextBoxDiagMasterMemberID
            // 
            this.OTGWTextBoxDiagMasterMemberID.Location = new System.Drawing.Point(135, 191);
            this.OTGWTextBoxDiagMasterMemberID.Name = "OTGWTextBoxDiagMasterMemberID";
            this.OTGWTextBoxDiagMasterMemberID.ReadOnly = true;
            this.OTGWTextBoxDiagMasterMemberID.Size = new System.Drawing.Size(54, 20);
            this.OTGWTextBoxDiagMasterMemberID.TabIndex = 11;
            // 
            // OTGWLabelDiagMasterMemberID
            // 
            this.OTGWLabelDiagMasterMemberID.AutoSize = true;
            this.OTGWLabelDiagMasterMemberID.Location = new System.Drawing.Point(12, 194);
            this.OTGWLabelDiagMasterMemberID.Name = "OTGWLabelDiagMasterMemberID";
            this.OTGWLabelDiagMasterMemberID.Size = new System.Drawing.Size(93, 13);
            this.OTGWLabelDiagMasterMemberID.TabIndex = 10;
            this.OTGWLabelDiagMasterMemberID.Text = "Master member ID";
            // 
            // OTGWTextBoxDiagCH2Enabled
            // 
            this.OTGWTextBoxDiagCH2Enabled.Location = new System.Drawing.Point(135, 113);
            this.OTGWTextBoxDiagCH2Enabled.Name = "OTGWTextBoxDiagCH2Enabled";
            this.OTGWTextBoxDiagCH2Enabled.ReadOnly = true;
            this.OTGWTextBoxDiagCH2Enabled.Size = new System.Drawing.Size(54, 20);
            this.OTGWTextBoxDiagCH2Enabled.TabIndex = 9;
            // 
            // OTGWLabelDiagCH2Enabled
            // 
            this.OTGWLabelDiagCH2Enabled.AutoSize = true;
            this.OTGWLabelDiagCH2Enabled.Location = new System.Drawing.Point(6, 116);
            this.OTGWLabelDiagCH2Enabled.Name = "OTGWLabelDiagCH2Enabled";
            this.OTGWLabelDiagCH2Enabled.Size = new System.Drawing.Size(128, 13);
            this.OTGWLabelDiagCH2Enabled.TabIndex = 8;
            this.OTGWLabelDiagCH2Enabled.Text = "Central heating 2 enabled";
            // 
            // OTGWTextBoxDiagOTCActive
            // 
            this.OTGWTextBoxDiagOTCActive.Location = new System.Drawing.Point(135, 87);
            this.OTGWTextBoxDiagOTCActive.Name = "OTGWTextBoxDiagOTCActive";
            this.OTGWTextBoxDiagOTCActive.ReadOnly = true;
            this.OTGWTextBoxDiagOTCActive.Size = new System.Drawing.Size(54, 20);
            this.OTGWTextBoxDiagOTCActive.TabIndex = 7;
            // 
            // OTGWLabelDiagOTCActive
            // 
            this.OTGWLabelDiagOTCActive.AutoSize = true;
            this.OTGWLabelDiagOTCActive.Location = new System.Drawing.Point(6, 90);
            this.OTGWLabelDiagOTCActive.Name = "OTGWLabelDiagOTCActive";
            this.OTGWLabelDiagOTCActive.Size = new System.Drawing.Size(61, 13);
            this.OTGWLabelDiagOTCActive.TabIndex = 6;
            this.OTGWLabelDiagOTCActive.Text = "OTC active";
            // 
            // OTGWTextBoxDiagCoolingEnabled
            // 
            this.OTGWTextBoxDiagCoolingEnabled.Location = new System.Drawing.Point(135, 61);
            this.OTGWTextBoxDiagCoolingEnabled.Name = "OTGWTextBoxDiagCoolingEnabled";
            this.OTGWTextBoxDiagCoolingEnabled.ReadOnly = true;
            this.OTGWTextBoxDiagCoolingEnabled.Size = new System.Drawing.Size(54, 20);
            this.OTGWTextBoxDiagCoolingEnabled.TabIndex = 5;
            // 
            // OTGWLabelDiagCoolingEnabled
            // 
            this.OTGWLabelDiagCoolingEnabled.AutoSize = true;
            this.OTGWLabelDiagCoolingEnabled.Location = new System.Drawing.Point(6, 64);
            this.OTGWLabelDiagCoolingEnabled.Name = "OTGWLabelDiagCoolingEnabled";
            this.OTGWLabelDiagCoolingEnabled.Size = new System.Drawing.Size(83, 13);
            this.OTGWLabelDiagCoolingEnabled.TabIndex = 4;
            this.OTGWLabelDiagCoolingEnabled.Text = "Cooling enabled";
            // 
            // OTGWTextBoxDiagTapWaterEnabled
            // 
            this.OTGWTextBoxDiagTapWaterEnabled.Location = new System.Drawing.Point(135, 35);
            this.OTGWTextBoxDiagTapWaterEnabled.Name = "OTGWTextBoxDiagTapWaterEnabled";
            this.OTGWTextBoxDiagTapWaterEnabled.ReadOnly = true;
            this.OTGWTextBoxDiagTapWaterEnabled.Size = new System.Drawing.Size(54, 20);
            this.OTGWTextBoxDiagTapWaterEnabled.TabIndex = 3;
            // 
            // OTGWLabelDiagTapWaterEnabled
            // 
            this.OTGWLabelDiagTapWaterEnabled.AutoSize = true;
            this.OTGWLabelDiagTapWaterEnabled.Location = new System.Drawing.Point(6, 38);
            this.OTGWLabelDiagTapWaterEnabled.Name = "OTGWLabelDiagTapWaterEnabled";
            this.OTGWLabelDiagTapWaterEnabled.Size = new System.Drawing.Size(96, 13);
            this.OTGWLabelDiagTapWaterEnabled.TabIndex = 2;
            this.OTGWLabelDiagTapWaterEnabled.Text = "Tap water enabled";
            // 
            // OTGWTextBoxDiagCentralHeatingEnabled
            // 
            this.OTGWTextBoxDiagCentralHeatingEnabled.Location = new System.Drawing.Point(135, 9);
            this.OTGWTextBoxDiagCentralHeatingEnabled.Name = "OTGWTextBoxDiagCentralHeatingEnabled";
            this.OTGWTextBoxDiagCentralHeatingEnabled.ReadOnly = true;
            this.OTGWTextBoxDiagCentralHeatingEnabled.Size = new System.Drawing.Size(54, 20);
            this.OTGWTextBoxDiagCentralHeatingEnabled.TabIndex = 1;
            // 
            // OTGWLabelDiagCentralHeatingEnabled
            // 
            this.OTGWLabelDiagCentralHeatingEnabled.AutoSize = true;
            this.OTGWLabelDiagCentralHeatingEnabled.Location = new System.Drawing.Point(6, 12);
            this.OTGWLabelDiagCentralHeatingEnabled.Name = "OTGWLabelDiagCentralHeatingEnabled";
            this.OTGWLabelDiagCentralHeatingEnabled.Size = new System.Drawing.Size(119, 13);
            this.OTGWLabelDiagCentralHeatingEnabled.TabIndex = 0;
            this.OTGWLabelDiagCentralHeatingEnabled.Text = "Central heating enabled";
            // 
            // OTGWTabOTGWDiagnostics
            // 
            this.OTGWTabOTGWDiagnostics.BackColor = System.Drawing.SystemColors.Control;
            this.OTGWTabOTGWDiagnostics.Controls.Add(this.OTGWTextBoxDiagProductVersionSlave);
            this.OTGWTabOTGWDiagnostics.Controls.Add(this.OTGWLabelProductVersionSlave);
            this.OTGWTabOTGWDiagnostics.Controls.Add(this.OTGWTextBoxDiagProductVersionMaster);
            this.OTGWTabOTGWDiagnostics.Controls.Add(this.OTGWLabelDiagProductVersionMaster);
            this.OTGWTabOTGWDiagnostics.Controls.Add(this.OTGWTextBoxDiagProductTypeSlave);
            this.OTGWTabOTGWDiagnostics.Controls.Add(this.OTGWLabelProductTypeSlave);
            this.OTGWTabOTGWDiagnostics.Controls.Add(this.OTGWTextBoxDiagProductTypeMaster);
            this.OTGWTabOTGWDiagnostics.Controls.Add(this.OTGWLabelDiagProductTypeMaster);
            this.OTGWTabOTGWDiagnostics.Controls.Add(this.OTGWTextBoxDiagOpenThermVersionSlave);
            this.OTGWTabOTGWDiagnostics.Controls.Add(this.OTGWLabelDiagOpenThermVersionSlave);
            this.OTGWTabOTGWDiagnostics.Controls.Add(this.OTGWTextBoxDiagOpenThermVersionMaster);
            this.OTGWTabOTGWDiagnostics.Controls.Add(this.OTGWLabelDiagOpenThermVersionMaster);
            this.OTGWTabOTGWDiagnostics.Controls.Add(this.OTGWTextBoxDiagHotWater);
            this.OTGWTabOTGWDiagnostics.Controls.Add(this.OTGWLabelDiagHotWater);
            this.OTGWTabOTGWDiagnostics.Controls.Add(this.OTGWLabelDiagReferenceVoltage);
            this.OTGWTabOTGWDiagnostics.Controls.Add(this.OTGWTextBoxDiagReferenceVoltage);
            this.OTGWTabOTGWDiagnostics.Controls.Add(this.OTGWLabelDiagTweaks);
            this.OTGWTabOTGWDiagnostics.Controls.Add(this.OTGWTextBoxDiagTweaks);
            this.OTGWTabOTGWDiagnostics.Controls.Add(this.OTGWTextBoxDiagSetbackTemperature);
            this.OTGWTabOTGWDiagnostics.Controls.Add(this.OTGWLabelDiagSetbackTemperature);
            this.OTGWTabOTGWDiagnostics.Controls.Add(this.OTGWTextBoxDiagRemehaDetectionState);
            this.OTGWTabOTGWDiagnostics.Controls.Add(this.OTGWLabelDiagRemehaDetectionState);
            this.OTGWTabOTGWDiagnostics.Controls.Add(this.OTGWTextBoxDiagCauseOfLastReset);
            this.OTGWTabOTGWDiagnostics.Controls.Add(this.OTGWLabelDiagCauseOfLastReset);
            this.OTGWTabOTGWDiagnostics.Controls.Add(this.OTGWTextBoxDiagSmartPowerMode);
            this.OTGWTabOTGWDiagnostics.Controls.Add(this.OTGWLabelDiagSmartPowerMode);
            this.OTGWTabOTGWDiagnostics.Controls.Add(this.OTGWTextBoxDiagSetpointOverride);
            this.OTGWTabOTGWDiagnostics.Controls.Add(this.OTGWLabelDiagSetpointOverride);
            this.OTGWTabOTGWDiagnostics.Controls.Add(this.OTGWTextBoxDiagGatewayMode);
            this.OTGWTabOTGWDiagnostics.Controls.Add(this.OTGWLabelDiagGatewayMode);
            this.OTGWTabOTGWDiagnostics.Controls.Add(this.OTGWTextBoxDiagLedFunctions);
            this.OTGWTabOTGWDiagnostics.Controls.Add(this.OTGWLabelDiagLedFunctions);
            this.OTGWTabOTGWDiagnostics.Controls.Add(this.OTGWTextBoxDiagGPIOState);
            this.OTGWTabOTGWDiagnostics.Controls.Add(this.OTGWTextBoxDiagGPIOFunctions);
            this.OTGWTabOTGWDiagnostics.Controls.Add(this.OTGWLabelDiagGPIOState);
            this.OTGWTabOTGWDiagnostics.Controls.Add(this.OTGWLabelDiagGPIOFucntions);
            this.OTGWTabOTGWDiagnostics.Controls.Add(this.OTGWTextBoxDiagTemperatureSensorFunction);
            this.OTGWTabOTGWDiagnostics.Controls.Add(this.OTGWLabelDiagTemperatureSensorFunction);
            this.OTGWTabOTGWDiagnostics.Controls.Add(this.OTGWTextBoxDiagClockSpeed);
            this.OTGWTabOTGWDiagnostics.Controls.Add(this.OTGWLabelDiagClockSpeed);
            this.OTGWTabOTGWDiagnostics.Controls.Add(this.OTGWTextBoxDiagBuild);
            this.OTGWTabOTGWDiagnostics.Controls.Add(this.OTGWLabelDiagBuild);
            this.OTGWTabOTGWDiagnostics.Controls.Add(this.OTGWTextBoxDiagVersion);
            this.OTGWTabOTGWDiagnostics.Controls.Add(this.OTGWLabelDiagVersion);
            this.OTGWTabOTGWDiagnostics.Location = new System.Drawing.Point(4, 22);
            this.OTGWTabOTGWDiagnostics.Name = "OTGWTabOTGWDiagnostics";
            this.OTGWTabOTGWDiagnostics.Padding = new System.Windows.Forms.Padding(3);
            this.OTGWTabOTGWDiagnostics.Size = new System.Drawing.Size(624, 504);
            this.OTGWTabOTGWDiagnostics.TabIndex = 3;
            this.OTGWTabOTGWDiagnostics.Text = "OTGW Diagnostics";
            // 
            // OTGWTextBoxDiagProductVersionSlave
            // 
            this.OTGWTextBoxDiagProductVersionSlave.Location = new System.Drawing.Point(563, 323);
            this.OTGWTextBoxDiagProductVersionSlave.Name = "OTGWTextBoxDiagProductVersionSlave";
            this.OTGWTextBoxDiagProductVersionSlave.ReadOnly = true;
            this.OTGWTextBoxDiagProductVersionSlave.Size = new System.Drawing.Size(55, 20);
            this.OTGWTextBoxDiagProductVersionSlave.TabIndex = 43;
            // 
            // OTGWLabelProductVersionSlave
            // 
            this.OTGWLabelProductVersionSlave.AutoSize = true;
            this.OTGWLabelProductVersionSlave.Location = new System.Drawing.Point(430, 326);
            this.OTGWLabelProductVersionSlave.Name = "OTGWLabelProductVersionSlave";
            this.OTGWLabelProductVersionSlave.Size = new System.Drawing.Size(109, 13);
            this.OTGWLabelProductVersionSlave.TabIndex = 42;
            this.OTGWLabelProductVersionSlave.Text = "Product version slave";
            // 
            // OTGWTextBoxDiagProductVersionMaster
            // 
            this.OTGWTextBoxDiagProductVersionMaster.Location = new System.Drawing.Point(563, 297);
            this.OTGWTextBoxDiagProductVersionMaster.Name = "OTGWTextBoxDiagProductVersionMaster";
            this.OTGWTextBoxDiagProductVersionMaster.ReadOnly = true;
            this.OTGWTextBoxDiagProductVersionMaster.Size = new System.Drawing.Size(55, 20);
            this.OTGWTextBoxDiagProductVersionMaster.TabIndex = 41;
            // 
            // OTGWLabelDiagProductVersionMaster
            // 
            this.OTGWLabelDiagProductVersionMaster.AutoSize = true;
            this.OTGWLabelDiagProductVersionMaster.Location = new System.Drawing.Point(430, 300);
            this.OTGWLabelDiagProductVersionMaster.Name = "OTGWLabelDiagProductVersionMaster";
            this.OTGWLabelDiagProductVersionMaster.Size = new System.Drawing.Size(116, 13);
            this.OTGWLabelDiagProductVersionMaster.TabIndex = 40;
            this.OTGWLabelDiagProductVersionMaster.Text = "Product version Master";
            // 
            // OTGWTextBoxDiagProductTypeSlave
            // 
            this.OTGWTextBoxDiagProductTypeSlave.Location = new System.Drawing.Point(352, 323);
            this.OTGWTextBoxDiagProductTypeSlave.Name = "OTGWTextBoxDiagProductTypeSlave";
            this.OTGWTextBoxDiagProductTypeSlave.ReadOnly = true;
            this.OTGWTextBoxDiagProductTypeSlave.Size = new System.Drawing.Size(56, 20);
            this.OTGWTextBoxDiagProductTypeSlave.TabIndex = 39;
            // 
            // OTGWLabelProductTypeSlave
            // 
            this.OTGWLabelProductTypeSlave.AutoSize = true;
            this.OTGWLabelProductTypeSlave.Location = new System.Drawing.Point(239, 326);
            this.OTGWLabelProductTypeSlave.Name = "OTGWLabelProductTypeSlave";
            this.OTGWLabelProductTypeSlave.Size = new System.Drawing.Size(95, 13);
            this.OTGWLabelProductTypeSlave.TabIndex = 38;
            this.OTGWLabelProductTypeSlave.Text = "Product type slave";
            // 
            // OTGWTextBoxDiagProductTypeMaster
            // 
            this.OTGWTextBoxDiagProductTypeMaster.Location = new System.Drawing.Point(352, 297);
            this.OTGWTextBoxDiagProductTypeMaster.Name = "OTGWTextBoxDiagProductTypeMaster";
            this.OTGWTextBoxDiagProductTypeMaster.ReadOnly = true;
            this.OTGWTextBoxDiagProductTypeMaster.Size = new System.Drawing.Size(55, 20);
            this.OTGWTextBoxDiagProductTypeMaster.TabIndex = 37;
            // 
            // OTGWLabelDiagProductTypeMaster
            // 
            this.OTGWLabelDiagProductTypeMaster.AutoSize = true;
            this.OTGWLabelDiagProductTypeMaster.Location = new System.Drawing.Point(239, 300);
            this.OTGWLabelDiagProductTypeMaster.Name = "OTGWLabelDiagProductTypeMaster";
            this.OTGWLabelDiagProductTypeMaster.Size = new System.Drawing.Size(101, 13);
            this.OTGWLabelDiagProductTypeMaster.TabIndex = 36;
            this.OTGWLabelDiagProductTypeMaster.Text = "Product type master";
            // 
            // OTGWTextBoxDiagOpenThermVersionSlave
            // 
            this.OTGWTextBoxDiagOpenThermVersionSlave.Location = new System.Drawing.Point(159, 323);
            this.OTGWTextBoxDiagOpenThermVersionSlave.Name = "OTGWTextBoxDiagOpenThermVersionSlave";
            this.OTGWTextBoxDiagOpenThermVersionSlave.ReadOnly = true;
            this.OTGWTextBoxDiagOpenThermVersionSlave.Size = new System.Drawing.Size(55, 20);
            this.OTGWTextBoxDiagOpenThermVersionSlave.TabIndex = 35;
            // 
            // OTGWLabelDiagOpenThermVersionSlave
            // 
            this.OTGWLabelDiagOpenThermVersionSlave.AutoSize = true;
            this.OTGWLabelDiagOpenThermVersionSlave.Location = new System.Drawing.Point(7, 326);
            this.OTGWLabelDiagOpenThermVersionSlave.Name = "OTGWLabelDiagOpenThermVersionSlave";
            this.OTGWLabelDiagOpenThermVersionSlave.Size = new System.Drawing.Size(128, 13);
            this.OTGWLabelDiagOpenThermVersionSlave.TabIndex = 34;
            this.OTGWLabelDiagOpenThermVersionSlave.Text = "OpenTherm version slave";
            // 
            // OTGWTextBoxDiagOpenThermVersionMaster
            // 
            this.OTGWTextBoxDiagOpenThermVersionMaster.Location = new System.Drawing.Point(159, 297);
            this.OTGWTextBoxDiagOpenThermVersionMaster.Name = "OTGWTextBoxDiagOpenThermVersionMaster";
            this.OTGWTextBoxDiagOpenThermVersionMaster.ReadOnly = true;
            this.OTGWTextBoxDiagOpenThermVersionMaster.Size = new System.Drawing.Size(55, 20);
            this.OTGWTextBoxDiagOpenThermVersionMaster.TabIndex = 33;
            // 
            // OTGWLabelDiagOpenThermVersionMaster
            // 
            this.OTGWLabelDiagOpenThermVersionMaster.AutoSize = true;
            this.OTGWLabelDiagOpenThermVersionMaster.Location = new System.Drawing.Point(6, 300);
            this.OTGWLabelDiagOpenThermVersionMaster.Name = "OTGWLabelDiagOpenThermVersionMaster";
            this.OTGWLabelDiagOpenThermVersionMaster.Size = new System.Drawing.Size(134, 13);
            this.OTGWLabelDiagOpenThermVersionMaster.TabIndex = 32;
            this.OTGWLabelDiagOpenThermVersionMaster.Text = "OpenTherm version master";
            // 
            // OTGWTextBoxDiagHotWater
            // 
            this.OTGWTextBoxDiagHotWater.Location = new System.Drawing.Point(536, 235);
            this.OTGWTextBoxDiagHotWater.Name = "OTGWTextBoxDiagHotWater";
            this.OTGWTextBoxDiagHotWater.ReadOnly = true;
            this.OTGWTextBoxDiagHotWater.Size = new System.Drawing.Size(82, 20);
            this.OTGWTextBoxDiagHotWater.TabIndex = 31;
            // 
            // OTGWLabelDiagHotWater
            // 
            this.OTGWLabelDiagHotWater.AutoSize = true;
            this.OTGWLabelDiagHotWater.Location = new System.Drawing.Point(384, 235);
            this.OTGWLabelDiagHotWater.Name = "OTGWLabelDiagHotWater";
            this.OTGWLabelDiagHotWater.Size = new System.Drawing.Size(53, 13);
            this.OTGWLabelDiagHotWater.TabIndex = 30;
            this.OTGWLabelDiagHotWater.Text = "Hot water";
            // 
            // OTGWLabelDiagReferenceVoltage
            // 
            this.OTGWLabelDiagReferenceVoltage.AutoSize = true;
            this.OTGWLabelDiagReferenceVoltage.Location = new System.Drawing.Point(6, 105);
            this.OTGWLabelDiagReferenceVoltage.Name = "OTGWLabelDiagReferenceVoltage";
            this.OTGWLabelDiagReferenceVoltage.Size = new System.Drawing.Size(95, 13);
            this.OTGWLabelDiagReferenceVoltage.TabIndex = 29;
            this.OTGWLabelDiagReferenceVoltage.Text = "Reference voltage";
            // 
            // OTGWTextBoxDiagReferenceVoltage
            // 
            this.OTGWTextBoxDiagReferenceVoltage.Location = new System.Drawing.Point(159, 102);
            this.OTGWTextBoxDiagReferenceVoltage.Name = "OTGWTextBoxDiagReferenceVoltage";
            this.OTGWTextBoxDiagReferenceVoltage.ReadOnly = true;
            this.OTGWTextBoxDiagReferenceVoltage.Size = new System.Drawing.Size(82, 20);
            this.OTGWTextBoxDiagReferenceVoltage.TabIndex = 28;
            // 
            // OTGWLabelDiagTweaks
            // 
            this.OTGWLabelDiagTweaks.AutoSize = true;
            this.OTGWLabelDiagTweaks.Location = new System.Drawing.Point(384, 209);
            this.OTGWLabelDiagTweaks.Name = "OTGWLabelDiagTweaks";
            this.OTGWLabelDiagTweaks.Size = new System.Drawing.Size(45, 13);
            this.OTGWLabelDiagTweaks.TabIndex = 27;
            this.OTGWLabelDiagTweaks.Text = "Tweaks";
            // 
            // OTGWTextBoxDiagTweaks
            // 
            this.OTGWTextBoxDiagTweaks.Location = new System.Drawing.Point(536, 206);
            this.OTGWTextBoxDiagTweaks.Name = "OTGWTextBoxDiagTweaks";
            this.OTGWTextBoxDiagTweaks.ReadOnly = true;
            this.OTGWTextBoxDiagTweaks.Size = new System.Drawing.Size(82, 20);
            this.OTGWTextBoxDiagTweaks.TabIndex = 26;
            // 
            // OTGWTextBoxDiagSetbackTemperature
            // 
            this.OTGWTextBoxDiagSetbackTemperature.Location = new System.Drawing.Point(536, 180);
            this.OTGWTextBoxDiagSetbackTemperature.Name = "OTGWTextBoxDiagSetbackTemperature";
            this.OTGWTextBoxDiagSetbackTemperature.ReadOnly = true;
            this.OTGWTextBoxDiagSetbackTemperature.Size = new System.Drawing.Size(82, 20);
            this.OTGWTextBoxDiagSetbackTemperature.TabIndex = 25;
            // 
            // OTGWLabelDiagSetbackTemperature
            // 
            this.OTGWLabelDiagSetbackTemperature.AutoSize = true;
            this.OTGWLabelDiagSetbackTemperature.Location = new System.Drawing.Point(384, 183);
            this.OTGWLabelDiagSetbackTemperature.Name = "OTGWLabelDiagSetbackTemperature";
            this.OTGWLabelDiagSetbackTemperature.Size = new System.Drawing.Size(106, 13);
            this.OTGWLabelDiagSetbackTemperature.TabIndex = 24;
            this.OTGWLabelDiagSetbackTemperature.Text = "Setback temperature";
            // 
            // OTGWTextBoxDiagRemehaDetectionState
            // 
            this.OTGWTextBoxDiagRemehaDetectionState.Location = new System.Drawing.Point(536, 154);
            this.OTGWTextBoxDiagRemehaDetectionState.Name = "OTGWTextBoxDiagRemehaDetectionState";
            this.OTGWTextBoxDiagRemehaDetectionState.ReadOnly = true;
            this.OTGWTextBoxDiagRemehaDetectionState.Size = new System.Drawing.Size(82, 20);
            this.OTGWTextBoxDiagRemehaDetectionState.TabIndex = 23;
            // 
            // OTGWLabelDiagRemehaDetectionState
            // 
            this.OTGWLabelDiagRemehaDetectionState.AutoSize = true;
            this.OTGWLabelDiagRemehaDetectionState.Location = new System.Drawing.Point(384, 157);
            this.OTGWLabelDiagRemehaDetectionState.Name = "OTGWLabelDiagRemehaDetectionState";
            this.OTGWLabelDiagRemehaDetectionState.Size = new System.Drawing.Size(120, 13);
            this.OTGWLabelDiagRemehaDetectionState.TabIndex = 22;
            this.OTGWLabelDiagRemehaDetectionState.Text = "Remeha detection state";
            // 
            // OTGWTextBoxDiagCauseOfLastReset
            // 
            this.OTGWTextBoxDiagCauseOfLastReset.Location = new System.Drawing.Point(159, 235);
            this.OTGWTextBoxDiagCauseOfLastReset.Name = "OTGWTextBoxDiagCauseOfLastReset";
            this.OTGWTextBoxDiagCauseOfLastReset.ReadOnly = true;
            this.OTGWTextBoxDiagCauseOfLastReset.Size = new System.Drawing.Size(82, 20);
            this.OTGWTextBoxDiagCauseOfLastReset.TabIndex = 21;
            // 
            // OTGWLabelDiagCauseOfLastReset
            // 
            this.OTGWLabelDiagCauseOfLastReset.AutoSize = true;
            this.OTGWLabelDiagCauseOfLastReset.Location = new System.Drawing.Point(7, 235);
            this.OTGWLabelDiagCauseOfLastReset.Name = "OTGWLabelDiagCauseOfLastReset";
            this.OTGWLabelDiagCauseOfLastReset.Size = new System.Drawing.Size(94, 13);
            this.OTGWLabelDiagCauseOfLastReset.TabIndex = 20;
            this.OTGWLabelDiagCauseOfLastReset.Text = "Cause of last reset";
            // 
            // OTGWTextBoxDiagSmartPowerMode
            // 
            this.OTGWTextBoxDiagSmartPowerMode.Location = new System.Drawing.Point(536, 128);
            this.OTGWTextBoxDiagSmartPowerMode.Name = "OTGWTextBoxDiagSmartPowerMode";
            this.OTGWTextBoxDiagSmartPowerMode.ReadOnly = true;
            this.OTGWTextBoxDiagSmartPowerMode.Size = new System.Drawing.Size(82, 20);
            this.OTGWTextBoxDiagSmartPowerMode.TabIndex = 19;
            // 
            // OTGWLabelDiagSmartPowerMode
            // 
            this.OTGWLabelDiagSmartPowerMode.AutoSize = true;
            this.OTGWLabelDiagSmartPowerMode.Location = new System.Drawing.Point(383, 131);
            this.OTGWLabelDiagSmartPowerMode.Name = "OTGWLabelDiagSmartPowerMode";
            this.OTGWLabelDiagSmartPowerMode.Size = new System.Drawing.Size(95, 13);
            this.OTGWLabelDiagSmartPowerMode.TabIndex = 18;
            this.OTGWLabelDiagSmartPowerMode.Text = "Smart-power mode";
            // 
            // OTGWTextBoxDiagSetpointOverride
            // 
            this.OTGWTextBoxDiagSetpointOverride.Location = new System.Drawing.Point(536, 102);
            this.OTGWTextBoxDiagSetpointOverride.Name = "OTGWTextBoxDiagSetpointOverride";
            this.OTGWTextBoxDiagSetpointOverride.ReadOnly = true;
            this.OTGWTextBoxDiagSetpointOverride.Size = new System.Drawing.Size(82, 20);
            this.OTGWTextBoxDiagSetpointOverride.TabIndex = 17;
            // 
            // OTGWLabelDiagSetpointOverride
            // 
            this.OTGWLabelDiagSetpointOverride.AutoSize = true;
            this.OTGWLabelDiagSetpointOverride.Location = new System.Drawing.Point(383, 105);
            this.OTGWLabelDiagSetpointOverride.Name = "OTGWLabelDiagSetpointOverride";
            this.OTGWLabelDiagSetpointOverride.Size = new System.Drawing.Size(87, 13);
            this.OTGWLabelDiagSetpointOverride.TabIndex = 16;
            this.OTGWLabelDiagSetpointOverride.Text = "Setpoint override";
            // 
            // OTGWTextBoxDiagGatewayMode
            // 
            this.OTGWTextBoxDiagGatewayMode.Location = new System.Drawing.Point(536, 76);
            this.OTGWTextBoxDiagGatewayMode.Name = "OTGWTextBoxDiagGatewayMode";
            this.OTGWTextBoxDiagGatewayMode.ReadOnly = true;
            this.OTGWTextBoxDiagGatewayMode.Size = new System.Drawing.Size(82, 20);
            this.OTGWTextBoxDiagGatewayMode.TabIndex = 15;
            // 
            // OTGWLabelDiagGatewayMode
            // 
            this.OTGWLabelDiagGatewayMode.AutoSize = true;
            this.OTGWLabelDiagGatewayMode.Location = new System.Drawing.Point(384, 79);
            this.OTGWLabelDiagGatewayMode.Name = "OTGWLabelDiagGatewayMode";
            this.OTGWLabelDiagGatewayMode.Size = new System.Drawing.Size(78, 13);
            this.OTGWLabelDiagGatewayMode.TabIndex = 14;
            this.OTGWLabelDiagGatewayMode.Text = "Gateway mode";
            // 
            // OTGWTextBoxDiagLedFunctions
            // 
            this.OTGWTextBoxDiagLedFunctions.Location = new System.Drawing.Point(159, 206);
            this.OTGWTextBoxDiagLedFunctions.Name = "OTGWTextBoxDiagLedFunctions";
            this.OTGWTextBoxDiagLedFunctions.ReadOnly = true;
            this.OTGWTextBoxDiagLedFunctions.Size = new System.Drawing.Size(82, 20);
            this.OTGWTextBoxDiagLedFunctions.TabIndex = 13;
            // 
            // OTGWLabelDiagLedFunctions
            // 
            this.OTGWLabelDiagLedFunctions.AutoSize = true;
            this.OTGWLabelDiagLedFunctions.Location = new System.Drawing.Point(6, 209);
            this.OTGWLabelDiagLedFunctions.Name = "OTGWLabelDiagLedFunctions";
            this.OTGWLabelDiagLedFunctions.Size = new System.Drawing.Size(74, 13);
            this.OTGWLabelDiagLedFunctions.TabIndex = 12;
            this.OTGWLabelDiagLedFunctions.Text = "LED functions";
            // 
            // OTGWTextBoxDiagGPIOState
            // 
            this.OTGWTextBoxDiagGPIOState.Location = new System.Drawing.Point(159, 180);
            this.OTGWTextBoxDiagGPIOState.Name = "OTGWTextBoxDiagGPIOState";
            this.OTGWTextBoxDiagGPIOState.ReadOnly = true;
            this.OTGWTextBoxDiagGPIOState.Size = new System.Drawing.Size(82, 20);
            this.OTGWTextBoxDiagGPIOState.TabIndex = 11;
            // 
            // OTGWTextBoxDiagGPIOFunctions
            // 
            this.OTGWTextBoxDiagGPIOFunctions.Location = new System.Drawing.Point(159, 154);
            this.OTGWTextBoxDiagGPIOFunctions.Name = "OTGWTextBoxDiagGPIOFunctions";
            this.OTGWTextBoxDiagGPIOFunctions.ReadOnly = true;
            this.OTGWTextBoxDiagGPIOFunctions.Size = new System.Drawing.Size(82, 20);
            this.OTGWTextBoxDiagGPIOFunctions.TabIndex = 10;
            // 
            // OTGWLabelDiagGPIOState
            // 
            this.OTGWLabelDiagGPIOState.AutoSize = true;
            this.OTGWLabelDiagGPIOState.Location = new System.Drawing.Point(6, 183);
            this.OTGWLabelDiagGPIOState.Name = "OTGWLabelDiagGPIOState";
            this.OTGWLabelDiagGPIOState.Size = new System.Drawing.Size(59, 13);
            this.OTGWLabelDiagGPIOState.TabIndex = 9;
            this.OTGWLabelDiagGPIOState.Text = "GPIO state";
            // 
            // OTGWLabelDiagGPIOFucntions
            // 
            this.OTGWLabelDiagGPIOFucntions.AutoSize = true;
            this.OTGWLabelDiagGPIOFucntions.Location = new System.Drawing.Point(6, 157);
            this.OTGWLabelDiagGPIOFucntions.Name = "OTGWLabelDiagGPIOFucntions";
            this.OTGWLabelDiagGPIOFucntions.Size = new System.Drawing.Size(79, 13);
            this.OTGWLabelDiagGPIOFucntions.TabIndex = 8;
            this.OTGWLabelDiagGPIOFucntions.Text = "GPIO functions";
            // 
            // OTGWTextBoxDiagTemperatureSensorFunction
            // 
            this.OTGWTextBoxDiagTemperatureSensorFunction.Location = new System.Drawing.Point(159, 128);
            this.OTGWTextBoxDiagTemperatureSensorFunction.Name = "OTGWTextBoxDiagTemperatureSensorFunction";
            this.OTGWTextBoxDiagTemperatureSensorFunction.ReadOnly = true;
            this.OTGWTextBoxDiagTemperatureSensorFunction.Size = new System.Drawing.Size(82, 20);
            this.OTGWTextBoxDiagTemperatureSensorFunction.TabIndex = 7;
            // 
            // OTGWLabelDiagTemperatureSensorFunction
            // 
            this.OTGWLabelDiagTemperatureSensorFunction.AutoSize = true;
            this.OTGWLabelDiagTemperatureSensorFunction.Location = new System.Drawing.Point(6, 131);
            this.OTGWLabelDiagTemperatureSensorFunction.Name = "OTGWLabelDiagTemperatureSensorFunction";
            this.OTGWLabelDiagTemperatureSensorFunction.Size = new System.Drawing.Size(142, 13);
            this.OTGWLabelDiagTemperatureSensorFunction.TabIndex = 6;
            this.OTGWLabelDiagTemperatureSensorFunction.Text = "Temperature sensor function";
            // 
            // OTGWTextBoxDiagClockSpeed
            // 
            this.OTGWTextBoxDiagClockSpeed.Location = new System.Drawing.Point(159, 76);
            this.OTGWTextBoxDiagClockSpeed.Name = "OTGWTextBoxDiagClockSpeed";
            this.OTGWTextBoxDiagClockSpeed.ReadOnly = true;
            this.OTGWTextBoxDiagClockSpeed.Size = new System.Drawing.Size(82, 20);
            this.OTGWTextBoxDiagClockSpeed.TabIndex = 5;
            // 
            // OTGWLabelDiagClockSpeed
            // 
            this.OTGWLabelDiagClockSpeed.AutoSize = true;
            this.OTGWLabelDiagClockSpeed.Location = new System.Drawing.Point(6, 79);
            this.OTGWLabelDiagClockSpeed.Name = "OTGWLabelDiagClockSpeed";
            this.OTGWLabelDiagClockSpeed.Size = new System.Drawing.Size(63, 13);
            this.OTGWLabelDiagClockSpeed.TabIndex = 4;
            this.OTGWLabelDiagClockSpeed.Text = "Clockspeed";
            // 
            // OTGWTextBoxDiagBuild
            // 
            this.OTGWTextBoxDiagBuild.Location = new System.Drawing.Point(159, 50);
            this.OTGWTextBoxDiagBuild.Name = "OTGWTextBoxDiagBuild";
            this.OTGWTextBoxDiagBuild.ReadOnly = true;
            this.OTGWTextBoxDiagBuild.Size = new System.Drawing.Size(459, 20);
            this.OTGWTextBoxDiagBuild.TabIndex = 3;
            // 
            // OTGWLabelDiagBuild
            // 
            this.OTGWLabelDiagBuild.AutoSize = true;
            this.OTGWLabelDiagBuild.Location = new System.Drawing.Point(6, 53);
            this.OTGWLabelDiagBuild.Name = "OTGWLabelDiagBuild";
            this.OTGWLabelDiagBuild.Size = new System.Drawing.Size(30, 13);
            this.OTGWLabelDiagBuild.TabIndex = 2;
            this.OTGWLabelDiagBuild.Text = "Build";
            // 
            // OTGWTextBoxDiagVersion
            // 
            this.OTGWTextBoxDiagVersion.Location = new System.Drawing.Point(159, 24);
            this.OTGWTextBoxDiagVersion.Name = "OTGWTextBoxDiagVersion";
            this.OTGWTextBoxDiagVersion.ReadOnly = true;
            this.OTGWTextBoxDiagVersion.Size = new System.Drawing.Size(459, 20);
            this.OTGWTextBoxDiagVersion.TabIndex = 1;
            // 
            // OTGWLabelDiagVersion
            // 
            this.OTGWLabelDiagVersion.AutoSize = true;
            this.OTGWLabelDiagVersion.Location = new System.Drawing.Point(6, 27);
            this.OTGWLabelDiagVersion.Name = "OTGWLabelDiagVersion";
            this.OTGWLabelDiagVersion.Size = new System.Drawing.Size(42, 13);
            this.OTGWLabelDiagVersion.TabIndex = 0;
            this.OTGWLabelDiagVersion.Text = "Version";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.MaxTabControl);
            this.groupBox2.Location = new System.Drawing.Point(15, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(661, 753);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "EQ-3 Max!";
            // 
            // MaxTabControl
            // 
            this.MaxTabControl.Controls.Add(this.MaxTabPageStatusOverview);
            this.MaxTabControl.Controls.Add(this.MaxTabConnection);
            this.MaxTabControl.Controls.Add(this.MaxTabRooms);
            this.MaxTabControl.Location = new System.Drawing.Point(6, 19);
            this.MaxTabControl.Name = "MaxTabControl";
            this.MaxTabControl.SelectedIndex = 0;
            this.MaxTabControl.Size = new System.Drawing.Size(649, 728);
            this.MaxTabControl.TabIndex = 5;
            this.MaxTabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.MaxTabControl_Selected);
            // 
            // MaxTabPageStatusOverview
            // 
            this.MaxTabPageStatusOverview.BackColor = System.Drawing.SystemColors.Control;
            this.MaxTabPageStatusOverview.Location = new System.Drawing.Point(4, 22);
            this.MaxTabPageStatusOverview.Name = "MaxTabPageStatusOverview";
            this.MaxTabPageStatusOverview.Padding = new System.Windows.Forms.Padding(3);
            this.MaxTabPageStatusOverview.Size = new System.Drawing.Size(641, 702);
            this.MaxTabPageStatusOverview.TabIndex = 0;
            this.MaxTabPageStatusOverview.Text = "Status Overview";
            // 
            // MaxTabConnection
            // 
            this.MaxTabConnection.BackColor = System.Drawing.SystemColors.Control;
            this.MaxTabConnection.Controls.Add(this.MaxCheckBoxAppend);
            this.MaxTabConnection.Controls.Add(this.MaxLabelAppend);
            this.MaxTabConnection.Controls.Add(this.MaxTextBoxLogFilename);
            this.MaxTabConnection.Controls.Add(this.MaxLabelLogFilename);
            this.MaxTabConnection.Controls.Add(this.MaxCheckBoxEnableLoggingToFile);
            this.MaxTabConnection.Controls.Add(this.MaxLabelHostName);
            this.MaxTabConnection.Controls.Add(this.MAXListboxLog);
            this.MaxTabConnection.Controls.Add(this.MaxTextBoxHostname);
            this.MaxTabConnection.Controls.Add(this.MaxButtonDisconnect);
            this.MaxTabConnection.Controls.Add(this.MaxButtonConnect);
            this.MaxTabConnection.Location = new System.Drawing.Point(4, 22);
            this.MaxTabConnection.Name = "MaxTabConnection";
            this.MaxTabConnection.Padding = new System.Windows.Forms.Padding(3);
            this.MaxTabConnection.Size = new System.Drawing.Size(641, 702);
            this.MaxTabConnection.TabIndex = 1;
            this.MaxTabConnection.Text = "Connection";
            // 
            // MaxLabelHostName
            // 
            this.MaxLabelHostName.AutoSize = true;
            this.MaxLabelHostName.Location = new System.Drawing.Point(6, 26);
            this.MaxLabelHostName.Name = "MaxLabelHostName";
            this.MaxLabelHostName.Size = new System.Drawing.Size(113, 13);
            this.MaxLabelHostName.TabIndex = 2;
            this.MaxLabelHostName.Text = "Hostname/ IP-address";
            // 
            // MAXListboxLog
            // 
            this.MAXListboxLog.FormattingEnabled = true;
            this.MAXListboxLog.Location = new System.Drawing.Point(6, 116);
            this.MAXListboxLog.Name = "MAXListboxLog";
            this.MAXListboxLog.Size = new System.Drawing.Size(418, 238);
            this.MAXListboxLog.TabIndex = 4;
            // 
            // MaxTextBoxHostname
            // 
            this.MaxTextBoxHostname.Location = new System.Drawing.Point(156, 23);
            this.MaxTextBoxHostname.Name = "MaxTextBoxHostname";
            this.MaxTextBoxHostname.Size = new System.Drawing.Size(268, 20);
            this.MaxTextBoxHostname.TabIndex = 3;
            this.MaxTextBoxHostname.Text = "KEQ0567251";
            // 
            // MaxButtonDisconnect
            // 
            this.MaxButtonDisconnect.Enabled = false;
            this.MaxButtonDisconnect.Location = new System.Drawing.Point(233, 67);
            this.MaxButtonDisconnect.Name = "MaxButtonDisconnect";
            this.MaxButtonDisconnect.Size = new System.Drawing.Size(191, 31);
            this.MaxButtonDisconnect.TabIndex = 1;
            this.MaxButtonDisconnect.Text = "Disconnect";
            this.MaxButtonDisconnect.UseVisualStyleBackColor = true;
            this.MaxButtonDisconnect.Click += new System.EventHandler(this.MaxButtonDisconnect_Click);
            // 
            // MaxButtonConnect
            // 
            this.MaxButtonConnect.Location = new System.Drawing.Point(6, 64);
            this.MaxButtonConnect.Name = "MaxButtonConnect";
            this.MaxButtonConnect.Size = new System.Drawing.Size(191, 34);
            this.MaxButtonConnect.TabIndex = 0;
            this.MaxButtonConnect.Text = "Connect";
            this.MaxButtonConnect.UseVisualStyleBackColor = true;
            this.MaxButtonConnect.Click += new System.EventHandler(this.MAXButtonConnect_Click);
            // 
            // MaxTabRooms
            // 
            this.MaxTabRooms.BackColor = System.Drawing.SystemColors.Control;
            this.MaxTabRooms.Controls.Add(this.MaxTextBoxRoomsNTPServer);
            this.MaxTabRooms.Controls.Add(this.MaxLabelRoomsNTPServer);
            this.MaxTabRooms.Controls.Add(this.MaxTextBoxRoomsValveOffsetPercent);
            this.MaxTabRooms.Controls.Add(this.MaxTextBoxRoomsValveMaxPercent);
            this.MaxTabRooms.Controls.Add(this.MaxTextBoxRoomsValvePosition);
            this.MaxTabRooms.Controls.Add(this.MaxLabelRoomsValveOffsetPercent);
            this.MaxTabRooms.Controls.Add(this.MaxLabelRoomsValveMaxPercent);
            this.MaxTabRooms.Controls.Add(this.MaxLabelRoomsValvePosition);
            this.MaxTabRooms.Controls.Add(this.MaxTextBoxRoomsWindowOpenTemperature);
            this.MaxTabRooms.Controls.Add(this.MaxTextBoxRoomsWindowOpenDuration);
            this.MaxTabRooms.Controls.Add(this.MaxLabelRoomsWindowOpenTemperature);
            this.MaxTabRooms.Controls.Add(this.MaxLabelRoomsWindowOpenDuration);
            this.MaxTabRooms.Controls.Add(this.MaxTextBoxRoomsMaxSetpointTemperature);
            this.MaxTabRooms.Controls.Add(this.MaxTextBoxRoomsMinSetpointTemperature);
            this.MaxTabRooms.Controls.Add(this.MaxLabelRoomsMaxSetpointTemperature);
            this.MaxTabRooms.Controls.Add(this.MaxLabelRoomsMinSetPointTemperature);
            this.MaxTabRooms.Controls.Add(this.MaxTextBoxRoomsDecalcificationHour);
            this.MaxTabRooms.Controls.Add(this.MaxTextBoxRoomsDecalcificationDay);
            this.MaxTabRooms.Controls.Add(this.MaxLabelRoomsDecalcificationHour);
            this.MaxTabRooms.Controls.Add(this.MaxLabelRoomsDecalcificationDay);
            this.MaxTabRooms.Controls.Add(this.MaxTextBoxRoomsBoostPercentage);
            this.MaxTabRooms.Controls.Add(this.MaxTextBoxRoomsBoostDuration);
            this.MaxTabRooms.Controls.Add(this.MaxLabelRoomsBoostPercentage);
            this.MaxTabRooms.Controls.Add(this.MaxLabelRoomsBoostDuration);
            this.MaxTabRooms.Controls.Add(this.MaxTextBoxRoomsDeviceComfortTemperature);
            this.MaxTabRooms.Controls.Add(this.MaxTextBoxRoomsDeviceEcoTemperature);
            this.MaxTabRooms.Controls.Add(this.MaxLabelRoomsDeviceComfortTemperature);
            this.MaxTabRooms.Controls.Add(this.MaxLabelRoomsDeviceEcoTemperature);
            this.MaxTabRooms.Controls.Add(this.MaxTextBoxRoomsDeviceType);
            this.MaxTabRooms.Controls.Add(this.MaxLabelRoomsDeviceType);
            this.MaxTabRooms.Controls.Add(this.MaxTextBoxRoomsDeviceActualTemperature);
            this.MaxTabRooms.Controls.Add(this.MaxTextBoxRoomsDeviceConfiguredTemperature);
            this.MaxTabRooms.Controls.Add(this.MaxLabelRoomsDeviceActualTemperature);
            this.MaxTabRooms.Controls.Add(this.MaxLabelRoomsDeviceConfiguredTemperature);
            this.MaxTabRooms.Controls.Add(this.MaxTextBoxRoomsDeviceRFAddress);
            this.MaxTabRooms.Controls.Add(this.MaxLabelRoomsDeviceRFAddress);
            this.MaxTabRooms.Controls.Add(this.MaxTextBoxRoomsDeviceSerialNumber);
            this.MaxTabRooms.Controls.Add(this.MaxLabelRoomsDeviceSerialNumber);
            this.MaxTabRooms.Controls.Add(this.MaxTextBoxRoomsRoomConfiguredTemperature);
            this.MaxTabRooms.Controls.Add(this.MaxLabelRoomsRoomConfiguredTemperature);
            this.MaxTabRooms.Controls.Add(this.MaxTextBoxRoomsRoomActualTemperature);
            this.MaxTabRooms.Controls.Add(this.MaxLabelRoomsRoomActualTemperature);
            this.MaxTabRooms.Controls.Add(this.MaxTextBoxRoomsRoomRFAddress);
            this.MaxTabRooms.Controls.Add(this.MaxTextBoxRoomsRoomID);
            this.MaxTabRooms.Controls.Add(this.MaxLabelRoomsRoomID);
            this.MaxTabRooms.Controls.Add(this.MaxLabelRoomsRoomRFAddress);
            this.MaxTabRooms.Controls.Add(this.MaxTextBoxRoomsDateTime);
            this.MaxTabRooms.Controls.Add(this.MaxLabelRoomsDateTime);
            this.MaxTabRooms.Controls.Add(this.MaxTextBoxRoomsPushButtonDown);
            this.MaxTabRooms.Controls.Add(this.MaxTextBoxRoomsPushButtonUp);
            this.MaxTabRooms.Controls.Add(this.MaxLabelRoomsPushButtonDown);
            this.MaxTabRooms.Controls.Add(this.MaxLabelRoomsPushButtonUp);
            this.MaxTabRooms.Controls.Add(this.MaxTextBoxRoomsPortalEnabled);
            this.MaxTabRooms.Controls.Add(this.MaxLabelRoomsPortalEnabled);
            this.MaxTabRooms.Controls.Add(this.MaxTextBoxRoomsCubeVersion);
            this.MaxTabRooms.Controls.Add(this.MaxLabelRoomsCubeVersion);
            this.MaxTabRooms.Controls.Add(this.MaxTextBoxRoomsPortalURL);
            this.MaxTabRooms.Controls.Add(this.MaxLabelRoomsPortalURL);
            this.MaxTabRooms.Controls.Add(this.MaxTextBoxRoomsEmptyMemorySlots);
            this.MaxTabRooms.Controls.Add(this.MaxTextBoxRoomsDutyCycle);
            this.MaxTabRooms.Controls.Add(this.MaxLabelRoomsEmptyMemorySlots);
            this.MaxTabRooms.Controls.Add(this.MaxLabelRoomsDutyCycle);
            this.MaxTabRooms.Controls.Add(this.MaxTextBoxRoomsCubeRfAddress);
            this.MaxTabRooms.Controls.Add(this.MaxTextBoxRoomsCubeSerialNumber);
            this.MaxTabRooms.Controls.Add(this.MaxTextBoxRoomsCubeName);
            this.MaxTabRooms.Controls.Add(this.MaxLabelRFAddress);
            this.MaxTabRooms.Controls.Add(this.MaxLabelRoomsSerialNumber);
            this.MaxTabRooms.Controls.Add(this.MaxLabelRoomsName);
            this.MaxTabRooms.Controls.Add(this.MaxListBoxRoomsDevice);
            this.MaxTabRooms.Controls.Add(this.MaxLabelRoomsDevice);
            this.MaxTabRooms.Controls.Add(this.MaxListBoxRoomsRooms);
            this.MaxTabRooms.Controls.Add(this.MaxListBoxRoomsMaxCube);
            this.MaxTabRooms.Controls.Add(this.MaxLabelRoomsRoom);
            this.MaxTabRooms.Controls.Add(this.MaxLabelRoomsMaxCube);
            this.MaxTabRooms.Location = new System.Drawing.Point(4, 22);
            this.MaxTabRooms.Name = "MaxTabRooms";
            this.MaxTabRooms.Padding = new System.Windows.Forms.Padding(3);
            this.MaxTabRooms.Size = new System.Drawing.Size(641, 702);
            this.MaxTabRooms.TabIndex = 2;
            this.MaxTabRooms.Text = "Rooms";
            // 
            // MaxTextBoxRoomsNTPServer
            // 
            this.MaxTextBoxRoomsNTPServer.Location = new System.Drawing.Point(79, 145);
            this.MaxTextBoxRoomsNTPServer.Name = "MaxTextBoxRoomsNTPServer";
            this.MaxTextBoxRoomsNTPServer.ReadOnly = true;
            this.MaxTextBoxRoomsNTPServer.Size = new System.Drawing.Size(310, 20);
            this.MaxTextBoxRoomsNTPServer.TabIndex = 74;
            // 
            // MaxLabelRoomsNTPServer
            // 
            this.MaxLabelRoomsNTPServer.AutoSize = true;
            this.MaxLabelRoomsNTPServer.Location = new System.Drawing.Point(6, 148);
            this.MaxLabelRoomsNTPServer.Name = "MaxLabelRoomsNTPServer";
            this.MaxLabelRoomsNTPServer.Size = new System.Drawing.Size(61, 13);
            this.MaxLabelRoomsNTPServer.TabIndex = 73;
            this.MaxLabelRoomsNTPServer.Text = "NTP server";
            // 
            // MaxTextBoxRoomsValveOffsetPercent
            // 
            this.MaxTextBoxRoomsValveOffsetPercent.Location = new System.Drawing.Point(557, 559);
            this.MaxTextBoxRoomsValveOffsetPercent.Name = "MaxTextBoxRoomsValveOffsetPercent";
            this.MaxTextBoxRoomsValveOffsetPercent.ReadOnly = true;
            this.MaxTextBoxRoomsValveOffsetPercent.Size = new System.Drawing.Size(35, 20);
            this.MaxTextBoxRoomsValveOffsetPercent.TabIndex = 72;
            // 
            // MaxTextBoxRoomsValveMaxPercent
            // 
            this.MaxTextBoxRoomsValveMaxPercent.Location = new System.Drawing.Point(557, 533);
            this.MaxTextBoxRoomsValveMaxPercent.Name = "MaxTextBoxRoomsValveMaxPercent";
            this.MaxTextBoxRoomsValveMaxPercent.ReadOnly = true;
            this.MaxTextBoxRoomsValveMaxPercent.Size = new System.Drawing.Size(35, 20);
            this.MaxTextBoxRoomsValveMaxPercent.TabIndex = 71;
            // 
            // MaxTextBoxRoomsValvePosition
            // 
            this.MaxTextBoxRoomsValvePosition.Location = new System.Drawing.Point(557, 507);
            this.MaxTextBoxRoomsValvePosition.Name = "MaxTextBoxRoomsValvePosition";
            this.MaxTextBoxRoomsValvePosition.ReadOnly = true;
            this.MaxTextBoxRoomsValvePosition.Size = new System.Drawing.Size(35, 20);
            this.MaxTextBoxRoomsValvePosition.TabIndex = 70;
            // 
            // MaxLabelRoomsValveOffsetPercent
            // 
            this.MaxLabelRoomsValveOffsetPercent.AutoSize = true;
            this.MaxLabelRoomsValveOffsetPercent.Location = new System.Drawing.Point(450, 562);
            this.MaxLabelRoomsValveOffsetPercent.Name = "MaxLabelRoomsValveOffsetPercent";
            this.MaxLabelRoomsValveOffsetPercent.Size = new System.Drawing.Size(102, 13);
            this.MaxLabelRoomsValveOffsetPercent.TabIndex = 69;
            this.MaxLabelRoomsValveOffsetPercent.Text = "Valve offset percent";
            // 
            // MaxLabelRoomsValveMaxPercent
            // 
            this.MaxLabelRoomsValveMaxPercent.AutoSize = true;
            this.MaxLabelRoomsValveMaxPercent.Location = new System.Drawing.Point(450, 536);
            this.MaxLabelRoomsValveMaxPercent.Name = "MaxLabelRoomsValveMaxPercent";
            this.MaxLabelRoomsValveMaxPercent.Size = new System.Drawing.Size(95, 13);
            this.MaxLabelRoomsValveMaxPercent.TabIndex = 68;
            this.MaxLabelRoomsValveMaxPercent.Text = "Valve max percent";
            // 
            // MaxLabelRoomsValvePosition
            // 
            this.MaxLabelRoomsValvePosition.AutoSize = true;
            this.MaxLabelRoomsValvePosition.Location = new System.Drawing.Point(450, 510);
            this.MaxLabelRoomsValvePosition.Name = "MaxLabelRoomsValvePosition";
            this.MaxLabelRoomsValvePosition.Size = new System.Drawing.Size(73, 13);
            this.MaxLabelRoomsValvePosition.TabIndex = 67;
            this.MaxLabelRoomsValvePosition.Text = "Valve position";
            // 
            // MaxTextBoxRoomsWindowOpenTemperature
            // 
            this.MaxTextBoxRoomsWindowOpenTemperature.Location = new System.Drawing.Point(357, 582);
            this.MaxTextBoxRoomsWindowOpenTemperature.Name = "MaxTextBoxRoomsWindowOpenTemperature";
            this.MaxTextBoxRoomsWindowOpenTemperature.ReadOnly = true;
            this.MaxTextBoxRoomsWindowOpenTemperature.Size = new System.Drawing.Size(35, 20);
            this.MaxTextBoxRoomsWindowOpenTemperature.TabIndex = 66;
            // 
            // MaxTextBoxRoomsWindowOpenDuration
            // 
            this.MaxTextBoxRoomsWindowOpenDuration.Location = new System.Drawing.Point(357, 556);
            this.MaxTextBoxRoomsWindowOpenDuration.Name = "MaxTextBoxRoomsWindowOpenDuration";
            this.MaxTextBoxRoomsWindowOpenDuration.ReadOnly = true;
            this.MaxTextBoxRoomsWindowOpenDuration.Size = new System.Drawing.Size(35, 20);
            this.MaxTextBoxRoomsWindowOpenDuration.TabIndex = 65;
            // 
            // MaxLabelRoomsWindowOpenTemperature
            // 
            this.MaxLabelRoomsWindowOpenTemperature.AutoSize = true;
            this.MaxLabelRoomsWindowOpenTemperature.Location = new System.Drawing.Point(224, 585);
            this.MaxLabelRoomsWindowOpenTemperature.Name = "MaxLabelRoomsWindowOpenTemperature";
            this.MaxLabelRoomsWindowOpenTemperature.Size = new System.Drawing.Size(132, 13);
            this.MaxLabelRoomsWindowOpenTemperature.TabIndex = 64;
            this.MaxLabelRoomsWindowOpenTemperature.Text = "Window open temperature";
            // 
            // MaxLabelRoomsWindowOpenDuration
            // 
            this.MaxLabelRoomsWindowOpenDuration.AutoSize = true;
            this.MaxLabelRoomsWindowOpenDuration.Location = new System.Drawing.Point(224, 559);
            this.MaxLabelRoomsWindowOpenDuration.Name = "MaxLabelRoomsWindowOpenDuration";
            this.MaxLabelRoomsWindowOpenDuration.Size = new System.Drawing.Size(114, 13);
            this.MaxLabelRoomsWindowOpenDuration.TabIndex = 63;
            this.MaxLabelRoomsWindowOpenDuration.Text = "Window open duration";
            // 
            // MaxTextBoxRoomsMaxSetpointTemperature
            // 
            this.MaxTextBoxRoomsMaxSetpointTemperature.Location = new System.Drawing.Point(134, 637);
            this.MaxTextBoxRoomsMaxSetpointTemperature.Name = "MaxTextBoxRoomsMaxSetpointTemperature";
            this.MaxTextBoxRoomsMaxSetpointTemperature.ReadOnly = true;
            this.MaxTextBoxRoomsMaxSetpointTemperature.Size = new System.Drawing.Size(35, 20);
            this.MaxTextBoxRoomsMaxSetpointTemperature.TabIndex = 62;
            // 
            // MaxTextBoxRoomsMinSetpointTemperature
            // 
            this.MaxTextBoxRoomsMinSetpointTemperature.Location = new System.Drawing.Point(134, 611);
            this.MaxTextBoxRoomsMinSetpointTemperature.Name = "MaxTextBoxRoomsMinSetpointTemperature";
            this.MaxTextBoxRoomsMinSetpointTemperature.ReadOnly = true;
            this.MaxTextBoxRoomsMinSetpointTemperature.Size = new System.Drawing.Size(35, 20);
            this.MaxTextBoxRoomsMinSetpointTemperature.TabIndex = 61;
            // 
            // MaxLabelRoomsMaxSetpointTemperature
            // 
            this.MaxLabelRoomsMaxSetpointTemperature.AutoSize = true;
            this.MaxLabelRoomsMaxSetpointTemperature.Location = new System.Drawing.Point(6, 640);
            this.MaxLabelRoomsMaxSetpointTemperature.Name = "MaxLabelRoomsMaxSetpointTemperature";
            this.MaxLabelRoomsMaxSetpointTemperature.Size = new System.Drawing.Size(126, 13);
            this.MaxLabelRoomsMaxSetpointTemperature.TabIndex = 60;
            this.MaxLabelRoomsMaxSetpointTemperature.Text = "Max setpoint temperature";
            // 
            // MaxLabelRoomsMinSetPointTemperature
            // 
            this.MaxLabelRoomsMinSetPointTemperature.AutoSize = true;
            this.MaxLabelRoomsMinSetPointTemperature.Location = new System.Drawing.Point(6, 614);
            this.MaxLabelRoomsMinSetPointTemperature.Name = "MaxLabelRoomsMinSetPointTemperature";
            this.MaxLabelRoomsMinSetPointTemperature.Size = new System.Drawing.Size(123, 13);
            this.MaxLabelRoomsMinSetPointTemperature.TabIndex = 59;
            this.MaxLabelRoomsMinSetPointTemperature.Text = "Min setpoint temperature";
            // 
            // MaxTextBoxRoomsDecalcificationHour
            // 
            this.MaxTextBoxRoomsDecalcificationHour.Location = new System.Drawing.Point(357, 634);
            this.MaxTextBoxRoomsDecalcificationHour.Name = "MaxTextBoxRoomsDecalcificationHour";
            this.MaxTextBoxRoomsDecalcificationHour.ReadOnly = true;
            this.MaxTextBoxRoomsDecalcificationHour.Size = new System.Drawing.Size(35, 20);
            this.MaxTextBoxRoomsDecalcificationHour.TabIndex = 58;
            // 
            // MaxTextBoxRoomsDecalcificationDay
            // 
            this.MaxTextBoxRoomsDecalcificationDay.Location = new System.Drawing.Point(357, 608);
            this.MaxTextBoxRoomsDecalcificationDay.Name = "MaxTextBoxRoomsDecalcificationDay";
            this.MaxTextBoxRoomsDecalcificationDay.ReadOnly = true;
            this.MaxTextBoxRoomsDecalcificationDay.Size = new System.Drawing.Size(35, 20);
            this.MaxTextBoxRoomsDecalcificationDay.TabIndex = 57;
            // 
            // MaxLabelRoomsDecalcificationHour
            // 
            this.MaxLabelRoomsDecalcificationHour.AutoSize = true;
            this.MaxLabelRoomsDecalcificationHour.Location = new System.Drawing.Point(224, 637);
            this.MaxLabelRoomsDecalcificationHour.Name = "MaxLabelRoomsDecalcificationHour";
            this.MaxLabelRoomsDecalcificationHour.Size = new System.Drawing.Size(101, 13);
            this.MaxLabelRoomsDecalcificationHour.TabIndex = 56;
            this.MaxLabelRoomsDecalcificationHour.Text = "Decalcification hour";
            // 
            // MaxLabelRoomsDecalcificationDay
            // 
            this.MaxLabelRoomsDecalcificationDay.AutoSize = true;
            this.MaxLabelRoomsDecalcificationDay.Location = new System.Drawing.Point(224, 611);
            this.MaxLabelRoomsDecalcificationDay.Name = "MaxLabelRoomsDecalcificationDay";
            this.MaxLabelRoomsDecalcificationDay.Size = new System.Drawing.Size(97, 13);
            this.MaxLabelRoomsDecalcificationDay.TabIndex = 55;
            this.MaxLabelRoomsDecalcificationDay.Text = "Decalcification day";
            // 
            // MaxTextBoxRoomsBoostPercentage
            // 
            this.MaxTextBoxRoomsBoostPercentage.Location = new System.Drawing.Point(357, 530);
            this.MaxTextBoxRoomsBoostPercentage.Name = "MaxTextBoxRoomsBoostPercentage";
            this.MaxTextBoxRoomsBoostPercentage.ReadOnly = true;
            this.MaxTextBoxRoomsBoostPercentage.Size = new System.Drawing.Size(35, 20);
            this.MaxTextBoxRoomsBoostPercentage.TabIndex = 54;
            // 
            // MaxTextBoxRoomsBoostDuration
            // 
            this.MaxTextBoxRoomsBoostDuration.Location = new System.Drawing.Point(357, 504);
            this.MaxTextBoxRoomsBoostDuration.Name = "MaxTextBoxRoomsBoostDuration";
            this.MaxTextBoxRoomsBoostDuration.ReadOnly = true;
            this.MaxTextBoxRoomsBoostDuration.Size = new System.Drawing.Size(35, 20);
            this.MaxTextBoxRoomsBoostDuration.TabIndex = 53;
            // 
            // MaxLabelRoomsBoostPercentage
            // 
            this.MaxLabelRoomsBoostPercentage.AutoSize = true;
            this.MaxLabelRoomsBoostPercentage.Location = new System.Drawing.Point(224, 533);
            this.MaxLabelRoomsBoostPercentage.Name = "MaxLabelRoomsBoostPercentage";
            this.MaxLabelRoomsBoostPercentage.Size = new System.Drawing.Size(91, 13);
            this.MaxLabelRoomsBoostPercentage.TabIndex = 52;
            this.MaxLabelRoomsBoostPercentage.Text = "Boost percentage";
            // 
            // MaxLabelRoomsBoostDuration
            // 
            this.MaxLabelRoomsBoostDuration.AutoSize = true;
            this.MaxLabelRoomsBoostDuration.Location = new System.Drawing.Point(224, 507);
            this.MaxLabelRoomsBoostDuration.Name = "MaxLabelRoomsBoostDuration";
            this.MaxLabelRoomsBoostDuration.Size = new System.Drawing.Size(75, 13);
            this.MaxLabelRoomsBoostDuration.TabIndex = 51;
            this.MaxLabelRoomsBoostDuration.Text = "Boost duration";
            // 
            // MaxTextBoxRoomsDeviceComfortTemperature
            // 
            this.MaxTextBoxRoomsDeviceComfortTemperature.Location = new System.Drawing.Point(134, 585);
            this.MaxTextBoxRoomsDeviceComfortTemperature.Name = "MaxTextBoxRoomsDeviceComfortTemperature";
            this.MaxTextBoxRoomsDeviceComfortTemperature.ReadOnly = true;
            this.MaxTextBoxRoomsDeviceComfortTemperature.Size = new System.Drawing.Size(35, 20);
            this.MaxTextBoxRoomsDeviceComfortTemperature.TabIndex = 50;
            // 
            // MaxTextBoxRoomsDeviceEcoTemperature
            // 
            this.MaxTextBoxRoomsDeviceEcoTemperature.Location = new System.Drawing.Point(134, 559);
            this.MaxTextBoxRoomsDeviceEcoTemperature.Name = "MaxTextBoxRoomsDeviceEcoTemperature";
            this.MaxTextBoxRoomsDeviceEcoTemperature.ReadOnly = true;
            this.MaxTextBoxRoomsDeviceEcoTemperature.Size = new System.Drawing.Size(35, 20);
            this.MaxTextBoxRoomsDeviceEcoTemperature.TabIndex = 49;
            // 
            // MaxLabelRoomsDeviceComfortTemperature
            // 
            this.MaxLabelRoomsDeviceComfortTemperature.AutoSize = true;
            this.MaxLabelRoomsDeviceComfortTemperature.Location = new System.Drawing.Point(6, 588);
            this.MaxLabelRoomsDeviceComfortTemperature.Name = "MaxLabelRoomsDeviceComfortTemperature";
            this.MaxLabelRoomsDeviceComfortTemperature.Size = new System.Drawing.Size(102, 13);
            this.MaxLabelRoomsDeviceComfortTemperature.TabIndex = 48;
            this.MaxLabelRoomsDeviceComfortTemperature.Text = "Comfort temperature";
            // 
            // MaxLabelRoomsDeviceEcoTemperature
            // 
            this.MaxLabelRoomsDeviceEcoTemperature.AutoSize = true;
            this.MaxLabelRoomsDeviceEcoTemperature.Location = new System.Drawing.Point(6, 562);
            this.MaxLabelRoomsDeviceEcoTemperature.Name = "MaxLabelRoomsDeviceEcoTemperature";
            this.MaxLabelRoomsDeviceEcoTemperature.Size = new System.Drawing.Size(85, 13);
            this.MaxLabelRoomsDeviceEcoTemperature.TabIndex = 47;
            this.MaxLabelRoomsDeviceEcoTemperature.Text = "Eco temperature";
            // 
            // MaxTextBoxRoomsDeviceType
            // 
            this.MaxTextBoxRoomsDeviceType.Location = new System.Drawing.Point(392, 356);
            this.MaxTextBoxRoomsDeviceType.Name = "MaxTextBoxRoomsDeviceType";
            this.MaxTextBoxRoomsDeviceType.ReadOnly = true;
            this.MaxTextBoxRoomsDeviceType.Size = new System.Drawing.Size(133, 20);
            this.MaxTextBoxRoomsDeviceType.TabIndex = 46;
            // 
            // MaxLabelRoomsDeviceType
            // 
            this.MaxLabelRoomsDeviceType.AutoSize = true;
            this.MaxLabelRoomsDeviceType.Location = new System.Drawing.Point(344, 359);
            this.MaxLabelRoomsDeviceType.Name = "MaxLabelRoomsDeviceType";
            this.MaxLabelRoomsDeviceType.Size = new System.Drawing.Size(31, 13);
            this.MaxLabelRoomsDeviceType.TabIndex = 45;
            this.MaxLabelRoomsDeviceType.Text = "Type";
            // 
            // MaxTextBoxRoomsDeviceActualTemperature
            // 
            this.MaxTextBoxRoomsDeviceActualTemperature.Location = new System.Drawing.Point(134, 533);
            this.MaxTextBoxRoomsDeviceActualTemperature.Name = "MaxTextBoxRoomsDeviceActualTemperature";
            this.MaxTextBoxRoomsDeviceActualTemperature.ReadOnly = true;
            this.MaxTextBoxRoomsDeviceActualTemperature.Size = new System.Drawing.Size(35, 20);
            this.MaxTextBoxRoomsDeviceActualTemperature.TabIndex = 44;
            // 
            // MaxTextBoxRoomsDeviceConfiguredTemperature
            // 
            this.MaxTextBoxRoomsDeviceConfiguredTemperature.Location = new System.Drawing.Point(134, 507);
            this.MaxTextBoxRoomsDeviceConfiguredTemperature.Name = "MaxTextBoxRoomsDeviceConfiguredTemperature";
            this.MaxTextBoxRoomsDeviceConfiguredTemperature.ReadOnly = true;
            this.MaxTextBoxRoomsDeviceConfiguredTemperature.Size = new System.Drawing.Size(35, 20);
            this.MaxTextBoxRoomsDeviceConfiguredTemperature.TabIndex = 43;
            // 
            // MaxLabelRoomsDeviceActualTemperature
            // 
            this.MaxLabelRoomsDeviceActualTemperature.AutoSize = true;
            this.MaxLabelRoomsDeviceActualTemperature.Location = new System.Drawing.Point(6, 536);
            this.MaxLabelRoomsDeviceActualTemperature.Name = "MaxLabelRoomsDeviceActualTemperature";
            this.MaxLabelRoomsDeviceActualTemperature.Size = new System.Drawing.Size(96, 13);
            this.MaxLabelRoomsDeviceActualTemperature.TabIndex = 42;
            this.MaxLabelRoomsDeviceActualTemperature.Text = "Actual temperature";
            // 
            // MaxLabelRoomsDeviceConfiguredTemperature
            // 
            this.MaxLabelRoomsDeviceConfiguredTemperature.AutoSize = true;
            this.MaxLabelRoomsDeviceConfiguredTemperature.Location = new System.Drawing.Point(6, 510);
            this.MaxLabelRoomsDeviceConfiguredTemperature.Name = "MaxLabelRoomsDeviceConfiguredTemperature";
            this.MaxLabelRoomsDeviceConfiguredTemperature.Size = new System.Drawing.Size(117, 13);
            this.MaxLabelRoomsDeviceConfiguredTemperature.TabIndex = 41;
            this.MaxLabelRoomsDeviceConfiguredTemperature.Text = "Configured temperature";
            // 
            // MaxTextBoxRoomsDeviceRFAddress
            // 
            this.MaxTextBoxRoomsDeviceRFAddress.Location = new System.Drawing.Point(79, 477);
            this.MaxTextBoxRoomsDeviceRFAddress.Name = "MaxTextBoxRoomsDeviceRFAddress";
            this.MaxTextBoxRoomsDeviceRFAddress.ReadOnly = true;
            this.MaxTextBoxRoomsDeviceRFAddress.Size = new System.Drawing.Size(90, 20);
            this.MaxTextBoxRoomsDeviceRFAddress.TabIndex = 40;
            // 
            // MaxLabelRoomsDeviceRFAddress
            // 
            this.MaxLabelRoomsDeviceRFAddress.AutoSize = true;
            this.MaxLabelRoomsDeviceRFAddress.Location = new System.Drawing.Point(6, 480);
            this.MaxLabelRoomsDeviceRFAddress.Name = "MaxLabelRoomsDeviceRFAddress";
            this.MaxLabelRoomsDeviceRFAddress.Size = new System.Drawing.Size(61, 13);
            this.MaxLabelRoomsDeviceRFAddress.TabIndex = 39;
            this.MaxLabelRoomsDeviceRFAddress.Text = "RF address";
            // 
            // MaxTextBoxRoomsDeviceSerialNumber
            // 
            this.MaxTextBoxRoomsDeviceSerialNumber.Location = new System.Drawing.Point(79, 451);
            this.MaxTextBoxRoomsDeviceSerialNumber.Name = "MaxTextBoxRoomsDeviceSerialNumber";
            this.MaxTextBoxRoomsDeviceSerialNumber.ReadOnly = true;
            this.MaxTextBoxRoomsDeviceSerialNumber.Size = new System.Drawing.Size(90, 20);
            this.MaxTextBoxRoomsDeviceSerialNumber.TabIndex = 38;
            // 
            // MaxLabelRoomsDeviceSerialNumber
            // 
            this.MaxLabelRoomsDeviceSerialNumber.AutoSize = true;
            this.MaxLabelRoomsDeviceSerialNumber.Location = new System.Drawing.Point(6, 451);
            this.MaxLabelRoomsDeviceSerialNumber.Name = "MaxLabelRoomsDeviceSerialNumber";
            this.MaxLabelRoomsDeviceSerialNumber.Size = new System.Drawing.Size(71, 13);
            this.MaxLabelRoomsDeviceSerialNumber.TabIndex = 37;
            this.MaxLabelRoomsDeviceSerialNumber.Text = "Serial number";
            // 
            // MaxTextBoxRoomsRoomConfiguredTemperature
            // 
            this.MaxTextBoxRoomsRoomConfiguredTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaxTextBoxRoomsRoomConfiguredTemperature.Location = new System.Drawing.Point(477, 193);
            this.MaxTextBoxRoomsRoomConfiguredTemperature.Name = "MaxTextBoxRoomsRoomConfiguredTemperature";
            this.MaxTextBoxRoomsRoomConfiguredTemperature.ReadOnly = true;
            this.MaxTextBoxRoomsRoomConfiguredTemperature.Size = new System.Drawing.Size(48, 26);
            this.MaxTextBoxRoomsRoomConfiguredTemperature.TabIndex = 36;
            // 
            // MaxLabelRoomsRoomConfiguredTemperature
            // 
            this.MaxLabelRoomsRoomConfiguredTemperature.AutoSize = true;
            this.MaxLabelRoomsRoomConfiguredTemperature.Location = new System.Drawing.Point(344, 201);
            this.MaxLabelRoomsRoomConfiguredTemperature.Name = "MaxLabelRoomsRoomConfiguredTemperature";
            this.MaxLabelRoomsRoomConfiguredTemperature.Size = new System.Drawing.Size(117, 13);
            this.MaxLabelRoomsRoomConfiguredTemperature.TabIndex = 35;
            this.MaxLabelRoomsRoomConfiguredTemperature.Text = "Configured temperature";
            // 
            // MaxTextBoxRoomsRoomActualTemperature
            // 
            this.MaxTextBoxRoomsRoomActualTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaxTextBoxRoomsRoomActualTemperature.Location = new System.Drawing.Point(477, 228);
            this.MaxTextBoxRoomsRoomActualTemperature.Name = "MaxTextBoxRoomsRoomActualTemperature";
            this.MaxTextBoxRoomsRoomActualTemperature.ReadOnly = true;
            this.MaxTextBoxRoomsRoomActualTemperature.Size = new System.Drawing.Size(48, 26);
            this.MaxTextBoxRoomsRoomActualTemperature.TabIndex = 34;
            // 
            // MaxLabelRoomsRoomActualTemperature
            // 
            this.MaxLabelRoomsRoomActualTemperature.AutoSize = true;
            this.MaxLabelRoomsRoomActualTemperature.Location = new System.Drawing.Point(344, 236);
            this.MaxLabelRoomsRoomActualTemperature.Name = "MaxLabelRoomsRoomActualTemperature";
            this.MaxLabelRoomsRoomActualTemperature.Size = new System.Drawing.Size(96, 13);
            this.MaxLabelRoomsRoomActualTemperature.TabIndex = 33;
            this.MaxLabelRoomsRoomActualTemperature.Text = "Actual temperature";
            // 
            // MaxTextBoxRoomsRoomRFAddress
            // 
            this.MaxTextBoxRoomsRoomRFAddress.Location = new System.Drawing.Point(79, 302);
            this.MaxTextBoxRoomsRoomRFAddress.Name = "MaxTextBoxRoomsRoomRFAddress";
            this.MaxTextBoxRoomsRoomRFAddress.ReadOnly = true;
            this.MaxTextBoxRoomsRoomRFAddress.Size = new System.Drawing.Size(90, 20);
            this.MaxTextBoxRoomsRoomRFAddress.TabIndex = 32;
            // 
            // MaxTextBoxRoomsRoomID
            // 
            this.MaxTextBoxRoomsRoomID.Location = new System.Drawing.Point(79, 276);
            this.MaxTextBoxRoomsRoomID.Name = "MaxTextBoxRoomsRoomID";
            this.MaxTextBoxRoomsRoomID.ReadOnly = true;
            this.MaxTextBoxRoomsRoomID.Size = new System.Drawing.Size(90, 20);
            this.MaxTextBoxRoomsRoomID.TabIndex = 31;
            // 
            // MaxLabelRoomsRoomID
            // 
            this.MaxLabelRoomsRoomID.AutoSize = true;
            this.MaxLabelRoomsRoomID.Location = new System.Drawing.Point(6, 279);
            this.MaxLabelRoomsRoomID.Name = "MaxLabelRoomsRoomID";
            this.MaxLabelRoomsRoomID.Size = new System.Drawing.Size(49, 13);
            this.MaxLabelRoomsRoomID.TabIndex = 30;
            this.MaxLabelRoomsRoomID.Text = "Room ID";
            // 
            // MaxLabelRoomsRoomRFAddress
            // 
            this.MaxLabelRoomsRoomRFAddress.AutoSize = true;
            this.MaxLabelRoomsRoomRFAddress.Location = new System.Drawing.Point(6, 305);
            this.MaxLabelRoomsRoomRFAddress.Name = "MaxLabelRoomsRoomRFAddress";
            this.MaxLabelRoomsRoomRFAddress.Size = new System.Drawing.Size(61, 13);
            this.MaxLabelRoomsRoomRFAddress.TabIndex = 29;
            this.MaxLabelRoomsRoomRFAddress.Text = "RF address";
            // 
            // MaxTextBoxRoomsDateTime
            // 
            this.MaxTextBoxRoomsDateTime.Location = new System.Drawing.Point(492, 14);
            this.MaxTextBoxRoomsDateTime.Name = "MaxTextBoxRoomsDateTime";
            this.MaxTextBoxRoomsDateTime.ReadOnly = true;
            this.MaxTextBoxRoomsDateTime.Size = new System.Drawing.Size(100, 20);
            this.MaxTextBoxRoomsDateTime.TabIndex = 28;
            // 
            // MaxLabelRoomsDateTime
            // 
            this.MaxLabelRoomsDateTime.AutoSize = true;
            this.MaxLabelRoomsDateTime.Location = new System.Drawing.Point(412, 17);
            this.MaxLabelRoomsDateTime.Name = "MaxLabelRoomsDateTime";
            this.MaxLabelRoomsDateTime.Size = new System.Drawing.Size(57, 13);
            this.MaxLabelRoomsDateTime.TabIndex = 27;
            this.MaxLabelRoomsDateTime.Text = "Date/ time";
            // 
            // MaxTextBoxRoomsPushButtonDown
            // 
            this.MaxTextBoxRoomsPushButtonDown.Location = new System.Drawing.Point(550, 67);
            this.MaxTextBoxRoomsPushButtonDown.Name = "MaxTextBoxRoomsPushButtonDown";
            this.MaxTextBoxRoomsPushButtonDown.ReadOnly = true;
            this.MaxTextBoxRoomsPushButtonDown.Size = new System.Drawing.Size(42, 20);
            this.MaxTextBoxRoomsPushButtonDown.TabIndex = 26;
            // 
            // MaxTextBoxRoomsPushButtonUp
            // 
            this.MaxTextBoxRoomsPushButtonUp.Location = new System.Drawing.Point(550, 41);
            this.MaxTextBoxRoomsPushButtonUp.Name = "MaxTextBoxRoomsPushButtonUp";
            this.MaxTextBoxRoomsPushButtonUp.ReadOnly = true;
            this.MaxTextBoxRoomsPushButtonUp.Size = new System.Drawing.Size(42, 20);
            this.MaxTextBoxRoomsPushButtonUp.TabIndex = 25;
            // 
            // MaxLabelRoomsPushButtonDown
            // 
            this.MaxLabelRoomsPushButtonDown.AutoSize = true;
            this.MaxLabelRoomsPushButtonDown.Location = new System.Drawing.Point(450, 70);
            this.MaxLabelRoomsPushButtonDown.Name = "MaxLabelRoomsPushButtonDown";
            this.MaxLabelRoomsPushButtonDown.Size = new System.Drawing.Size(93, 13);
            this.MaxLabelRoomsPushButtonDown.TabIndex = 24;
            this.MaxLabelRoomsPushButtonDown.Text = "Push button down";
            // 
            // MaxLabelRoomsPushButtonUp
            // 
            this.MaxLabelRoomsPushButtonUp.AutoSize = true;
            this.MaxLabelRoomsPushButtonUp.Location = new System.Drawing.Point(450, 44);
            this.MaxLabelRoomsPushButtonUp.Name = "MaxLabelRoomsPushButtonUp";
            this.MaxLabelRoomsPushButtonUp.Size = new System.Drawing.Size(79, 13);
            this.MaxLabelRoomsPushButtonUp.TabIndex = 23;
            this.MaxLabelRoomsPushButtonUp.Text = "Push button up";
            // 
            // MaxTextBoxRoomsPortalEnabled
            // 
            this.MaxTextBoxRoomsPortalEnabled.Location = new System.Drawing.Point(550, 119);
            this.MaxTextBoxRoomsPortalEnabled.Name = "MaxTextBoxRoomsPortalEnabled";
            this.MaxTextBoxRoomsPortalEnabled.ReadOnly = true;
            this.MaxTextBoxRoomsPortalEnabled.Size = new System.Drawing.Size(42, 20);
            this.MaxTextBoxRoomsPortalEnabled.TabIndex = 22;
            // 
            // MaxLabelRoomsPortalEnabled
            // 
            this.MaxLabelRoomsPortalEnabled.AutoSize = true;
            this.MaxLabelRoomsPortalEnabled.Location = new System.Drawing.Point(450, 122);
            this.MaxLabelRoomsPortalEnabled.Name = "MaxLabelRoomsPortalEnabled";
            this.MaxLabelRoomsPortalEnabled.Size = new System.Drawing.Size(75, 13);
            this.MaxLabelRoomsPortalEnabled.TabIndex = 21;
            this.MaxLabelRoomsPortalEnabled.Text = "Portal enabled";
            // 
            // MaxTextBoxRoomsCubeVersion
            // 
            this.MaxTextBoxRoomsCubeVersion.Location = new System.Drawing.Point(347, 41);
            this.MaxTextBoxRoomsCubeVersion.Name = "MaxTextBoxRoomsCubeVersion";
            this.MaxTextBoxRoomsCubeVersion.ReadOnly = true;
            this.MaxTextBoxRoomsCubeVersion.Size = new System.Drawing.Size(42, 20);
            this.MaxTextBoxRoomsCubeVersion.TabIndex = 20;
            // 
            // MaxLabelRoomsCubeVersion
            // 
            this.MaxLabelRoomsCubeVersion.AutoSize = true;
            this.MaxLabelRoomsCubeVersion.Location = new System.Drawing.Point(242, 44);
            this.MaxLabelRoomsCubeVersion.Name = "MaxLabelRoomsCubeVersion";
            this.MaxLabelRoomsCubeVersion.Size = new System.Drawing.Size(42, 13);
            this.MaxLabelRoomsCubeVersion.TabIndex = 19;
            this.MaxLabelRoomsCubeVersion.Text = "Version";
            // 
            // MaxTextBoxRoomsPortalURL
            // 
            this.MaxTextBoxRoomsPortalURL.Location = new System.Drawing.Point(79, 119);
            this.MaxTextBoxRoomsPortalURL.Name = "MaxTextBoxRoomsPortalURL";
            this.MaxTextBoxRoomsPortalURL.ReadOnly = true;
            this.MaxTextBoxRoomsPortalURL.Size = new System.Drawing.Size(311, 20);
            this.MaxTextBoxRoomsPortalURL.TabIndex = 18;
            // 
            // MaxLabelRoomsPortalURL
            // 
            this.MaxLabelRoomsPortalURL.AutoSize = true;
            this.MaxLabelRoomsPortalURL.Location = new System.Drawing.Point(6, 122);
            this.MaxLabelRoomsPortalURL.Name = "MaxLabelRoomsPortalURL";
            this.MaxLabelRoomsPortalURL.Size = new System.Drawing.Size(59, 13);
            this.MaxLabelRoomsPortalURL.TabIndex = 17;
            this.MaxLabelRoomsPortalURL.Text = "Portal URL";
            // 
            // MaxTextBoxRoomsEmptyMemorySlots
            // 
            this.MaxTextBoxRoomsEmptyMemorySlots.Location = new System.Drawing.Point(347, 93);
            this.MaxTextBoxRoomsEmptyMemorySlots.Name = "MaxTextBoxRoomsEmptyMemorySlots";
            this.MaxTextBoxRoomsEmptyMemorySlots.ReadOnly = true;
            this.MaxTextBoxRoomsEmptyMemorySlots.Size = new System.Drawing.Size(42, 20);
            this.MaxTextBoxRoomsEmptyMemorySlots.TabIndex = 16;
            // 
            // MaxTextBoxRoomsDutyCycle
            // 
            this.MaxTextBoxRoomsDutyCycle.Location = new System.Drawing.Point(347, 67);
            this.MaxTextBoxRoomsDutyCycle.Name = "MaxTextBoxRoomsDutyCycle";
            this.MaxTextBoxRoomsDutyCycle.ReadOnly = true;
            this.MaxTextBoxRoomsDutyCycle.Size = new System.Drawing.Size(42, 20);
            this.MaxTextBoxRoomsDutyCycle.TabIndex = 15;
            // 
            // MaxLabelRoomsEmptyMemorySlots
            // 
            this.MaxLabelRoomsEmptyMemorySlots.AutoSize = true;
            this.MaxLabelRoomsEmptyMemorySlots.Location = new System.Drawing.Point(242, 96);
            this.MaxLabelRoomsEmptyMemorySlots.Name = "MaxLabelRoomsEmptyMemorySlots";
            this.MaxLabelRoomsEmptyMemorySlots.Size = new System.Drawing.Size(99, 13);
            this.MaxLabelRoomsEmptyMemorySlots.TabIndex = 14;
            this.MaxLabelRoomsEmptyMemorySlots.Text = "Empty memory slots";
            // 
            // MaxLabelRoomsDutyCycle
            // 
            this.MaxLabelRoomsDutyCycle.AutoSize = true;
            this.MaxLabelRoomsDutyCycle.Location = new System.Drawing.Point(242, 70);
            this.MaxLabelRoomsDutyCycle.Name = "MaxLabelRoomsDutyCycle";
            this.MaxLabelRoomsDutyCycle.Size = new System.Drawing.Size(57, 13);
            this.MaxLabelRoomsDutyCycle.TabIndex = 13;
            this.MaxLabelRoomsDutyCycle.Text = "Duty cycle";
            // 
            // MaxTextBoxRoomsCubeRfAddress
            // 
            this.MaxTextBoxRoomsCubeRfAddress.Location = new System.Drawing.Point(79, 93);
            this.MaxTextBoxRoomsCubeRfAddress.Name = "MaxTextBoxRoomsCubeRfAddress";
            this.MaxTextBoxRoomsCubeRfAddress.ReadOnly = true;
            this.MaxTextBoxRoomsCubeRfAddress.Size = new System.Drawing.Size(90, 20);
            this.MaxTextBoxRoomsCubeRfAddress.TabIndex = 12;
            // 
            // MaxTextBoxRoomsCubeSerialNumber
            // 
            this.MaxTextBoxRoomsCubeSerialNumber.Location = new System.Drawing.Point(79, 67);
            this.MaxTextBoxRoomsCubeSerialNumber.Name = "MaxTextBoxRoomsCubeSerialNumber";
            this.MaxTextBoxRoomsCubeSerialNumber.ReadOnly = true;
            this.MaxTextBoxRoomsCubeSerialNumber.Size = new System.Drawing.Size(90, 20);
            this.MaxTextBoxRoomsCubeSerialNumber.TabIndex = 11;
            // 
            // MaxTextBoxRoomsCubeName
            // 
            this.MaxTextBoxRoomsCubeName.Location = new System.Drawing.Point(79, 41);
            this.MaxTextBoxRoomsCubeName.Name = "MaxTextBoxRoomsCubeName";
            this.MaxTextBoxRoomsCubeName.ReadOnly = true;
            this.MaxTextBoxRoomsCubeName.Size = new System.Drawing.Size(90, 20);
            this.MaxTextBoxRoomsCubeName.TabIndex = 10;
            // 
            // MaxLabelRFAddress
            // 
            this.MaxLabelRFAddress.AutoSize = true;
            this.MaxLabelRFAddress.Location = new System.Drawing.Point(6, 96);
            this.MaxLabelRFAddress.Name = "MaxLabelRFAddress";
            this.MaxLabelRFAddress.Size = new System.Drawing.Size(61, 13);
            this.MaxLabelRFAddress.TabIndex = 9;
            this.MaxLabelRFAddress.Text = "RF address";
            // 
            // MaxLabelRoomsSerialNumber
            // 
            this.MaxLabelRoomsSerialNumber.AutoSize = true;
            this.MaxLabelRoomsSerialNumber.Location = new System.Drawing.Point(6, 70);
            this.MaxLabelRoomsSerialNumber.Name = "MaxLabelRoomsSerialNumber";
            this.MaxLabelRoomsSerialNumber.Size = new System.Drawing.Size(71, 13);
            this.MaxLabelRoomsSerialNumber.TabIndex = 8;
            this.MaxLabelRoomsSerialNumber.Text = "Serial number";
            // 
            // MaxLabelRoomsName
            // 
            this.MaxLabelRoomsName.AutoSize = true;
            this.MaxLabelRoomsName.Location = new System.Drawing.Point(6, 44);
            this.MaxLabelRoomsName.Name = "MaxLabelRoomsName";
            this.MaxLabelRoomsName.Size = new System.Drawing.Size(35, 13);
            this.MaxLabelRoomsName.TabIndex = 7;
            this.MaxLabelRoomsName.Text = "Name";
            // 
            // MaxListBoxRoomsDevice
            // 
            this.MaxListBoxRoomsDevice.FormattingEnabled = true;
            this.MaxListBoxRoomsDevice.Location = new System.Drawing.Point(79, 350);
            this.MaxListBoxRoomsDevice.Name = "MaxListBoxRoomsDevice";
            this.MaxListBoxRoomsDevice.ScrollAlwaysVisible = true;
            this.MaxListBoxRoomsDevice.Size = new System.Drawing.Size(191, 95);
            this.MaxListBoxRoomsDevice.TabIndex = 6;
            this.MaxListBoxRoomsDevice.SelectedIndexChanged += new System.EventHandler(this.MaxListBoxRoomsDevice_SelectedIndexChanged);
            // 
            // MaxLabelRoomsDevice
            // 
            this.MaxLabelRoomsDevice.AutoSize = true;
            this.MaxLabelRoomsDevice.Location = new System.Drawing.Point(6, 359);
            this.MaxLabelRoomsDevice.Name = "MaxLabelRoomsDevice";
            this.MaxLabelRoomsDevice.Size = new System.Drawing.Size(41, 13);
            this.MaxLabelRoomsDevice.TabIndex = 5;
            this.MaxLabelRoomsDevice.Text = "Device";
            // 
            // MaxListBoxRoomsRooms
            // 
            this.MaxListBoxRoomsRooms.FormattingEnabled = true;
            this.MaxListBoxRoomsRooms.Location = new System.Drawing.Point(79, 175);
            this.MaxListBoxRoomsRooms.Name = "MaxListBoxRoomsRooms";
            this.MaxListBoxRoomsRooms.ScrollAlwaysVisible = true;
            this.MaxListBoxRoomsRooms.Size = new System.Drawing.Size(191, 95);
            this.MaxListBoxRoomsRooms.TabIndex = 4;
            this.MaxListBoxRoomsRooms.SelectedIndexChanged += new System.EventHandler(this.MaxListBoxRoomsRooms_SelectedIndexChanged);
            // 
            // MaxListBoxRoomsMaxCube
            // 
            this.MaxListBoxRoomsMaxCube.FormattingEnabled = true;
            this.MaxListBoxRoomsMaxCube.Location = new System.Drawing.Point(79, 6);
            this.MaxListBoxRoomsMaxCube.Name = "MaxListBoxRoomsMaxCube";
            this.MaxListBoxRoomsMaxCube.ScrollAlwaysVisible = true;
            this.MaxListBoxRoomsMaxCube.Size = new System.Drawing.Size(191, 30);
            this.MaxListBoxRoomsMaxCube.TabIndex = 3;
            this.MaxListBoxRoomsMaxCube.SelectedIndexChanged += new System.EventHandler(this.MaxListBoxRoomsMaxCube_SelectedIndexChanged);
            // 
            // MaxLabelRoomsRoom
            // 
            this.MaxLabelRoomsRoom.AutoSize = true;
            this.MaxLabelRoomsRoom.Location = new System.Drawing.Point(6, 175);
            this.MaxLabelRoomsRoom.Name = "MaxLabelRoomsRoom";
            this.MaxLabelRoomsRoom.Size = new System.Drawing.Size(35, 13);
            this.MaxLabelRoomsRoom.TabIndex = 2;
            this.MaxLabelRoomsRoom.Text = "Room";
            // 
            // MaxLabelRoomsMaxCube
            // 
            this.MaxLabelRoomsMaxCube.AutoSize = true;
            this.MaxLabelRoomsMaxCube.Location = new System.Drawing.Point(6, 17);
            this.MaxLabelRoomsMaxCube.Name = "MaxLabelRoomsMaxCube";
            this.MaxLabelRoomsMaxCube.Size = new System.Drawing.Size(52, 13);
            this.MaxLabelRoomsMaxCube.TabIndex = 0;
            this.MaxLabelRoomsMaxCube.Text = "MaxCube";
            // 
            // MaxCheckBoxEnableLoggingToFile
            // 
            this.MaxCheckBoxEnableLoggingToFile.AutoSize = true;
            this.MaxCheckBoxEnableLoggingToFile.Location = new System.Drawing.Point(6, 387);
            this.MaxCheckBoxEnableLoggingToFile.Name = "MaxCheckBoxEnableLoggingToFile";
            this.MaxCheckBoxEnableLoggingToFile.Size = new System.Drawing.Size(124, 17);
            this.MaxCheckBoxEnableLoggingToFile.TabIndex = 5;
            this.MaxCheckBoxEnableLoggingToFile.Text = "Enable logging to file";
            this.MaxCheckBoxEnableLoggingToFile.UseVisualStyleBackColor = true;
            // 
            // MaxLabelLogFilename
            // 
            this.MaxLabelLogFilename.AutoSize = true;
            this.MaxLabelLogFilename.Location = new System.Drawing.Point(3, 407);
            this.MaxLabelLogFilename.Name = "MaxLabelLogFilename";
            this.MaxLabelLogFilename.Size = new System.Drawing.Size(67, 13);
            this.MaxLabelLogFilename.TabIndex = 6;
            this.MaxLabelLogFilename.Text = "Log filename";
            // 
            // MaxTextBoxLogFilename
            // 
            this.MaxTextBoxLogFilename.Location = new System.Drawing.Point(94, 404);
            this.MaxTextBoxLogFilename.Name = "MaxTextBoxLogFilename";
            this.MaxTextBoxLogFilename.Size = new System.Drawing.Size(245, 20);
            this.MaxTextBoxLogFilename.TabIndex = 7;
            this.MaxTextBoxLogFilename.Text = "E:\\HeatControlLogMaxcube.txt";
            // 
            // MaxLabelAppend
            // 
            this.MaxLabelAppend.AutoSize = true;
            this.MaxLabelAppend.Location = new System.Drawing.Point(359, 406);
            this.MaxLabelAppend.Name = "MaxLabelAppend";
            this.MaxLabelAppend.Size = new System.Drawing.Size(44, 13);
            this.MaxLabelAppend.TabIndex = 8;
            this.MaxLabelAppend.Text = "Append";
            // 
            // MaxCheckBoxAppend
            // 
            this.MaxCheckBoxAppend.AutoSize = true;
            this.MaxCheckBoxAppend.Location = new System.Drawing.Point(409, 406);
            this.MaxCheckBoxAppend.Name = "MaxCheckBoxAppend";
            this.MaxCheckBoxAppend.Size = new System.Drawing.Size(15, 14);
            this.MaxCheckBoxAppend.TabIndex = 9;
            this.MaxCheckBoxAppend.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 788);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.OTGWGroupbox);
            this.Name = "Form1";
            this.Text = "HeatControl";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.OTGWGroupbox.ResumeLayout(false);
            this.OTGWTabcontrol.ResumeLayout(false);
            this.OTGWTabStatus.ResumeLayout(false);
            this.OTGWTabStatus.PerformLayout();
            this.OTGWTabConnection.ResumeLayout(false);
            this.OTGWTabConnection.PerformLayout();
            this.OTGWTabBoilerDiagnostics.ResumeLayout(false);
            this.OTGWTabBoilerDiagnostics.PerformLayout();
            this.OTGWTabOTGWDiagnostics.ResumeLayout(false);
            this.OTGWTabOTGWDiagnostics.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.MaxTabControl.ResumeLayout(false);
            this.MaxTabConnection.ResumeLayout(false);
            this.MaxTabConnection.PerformLayout();
            this.MaxTabRooms.ResumeLayout(false);
            this.MaxTabRooms.PerformLayout();
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
        private System.Windows.Forms.TabPage OTGWTabBoilerDiagnostics;
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
        private System.Windows.Forms.TabPage OTGWTabOTGWDiagnostics;
        private System.Windows.Forms.Label OTGWLabelDiagVersion;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagVersion;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagBuild;
        private System.Windows.Forms.Label OTGWLabelDiagBuild;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagClockSpeed;
        private System.Windows.Forms.Label OTGWLabelDiagClockSpeed;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagTemperatureSensorFunction;
        private System.Windows.Forms.Label OTGWLabelDiagTemperatureSensorFunction;
        private System.Windows.Forms.Label OTGWLabelDiagGPIOFucntions;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagGPIOState;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagGPIOFunctions;
        private System.Windows.Forms.Label OTGWLabelDiagGPIOState;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagLedFunctions;
        private System.Windows.Forms.Label OTGWLabelDiagLedFunctions;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagGatewayMode;
        private System.Windows.Forms.Label OTGWLabelDiagGatewayMode;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagSetpointOverride;
        private System.Windows.Forms.Label OTGWLabelDiagSetpointOverride;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagSmartPowerMode;
        private System.Windows.Forms.Label OTGWLabelDiagSmartPowerMode;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagCauseOfLastReset;
        private System.Windows.Forms.Label OTGWLabelDiagCauseOfLastReset;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagRemehaDetectionState;
        private System.Windows.Forms.Label OTGWLabelDiagRemehaDetectionState;
        private System.Windows.Forms.Label OTGWLabelDiagSetbackTemperature;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagSetbackTemperature;
        private System.Windows.Forms.Label OTGWLabelDiagTweaks;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagTweaks;
        private System.Windows.Forms.Label OTGWLabelDiagReferenceVoltage;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagReferenceVoltage;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagHotWater;
        private System.Windows.Forms.Label OTGWLabelDiagHotWater;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagCentralHeatingEnabled;
        private System.Windows.Forms.Label OTGWLabelDiagCentralHeatingEnabled;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagTapWaterEnabled;
        private System.Windows.Forms.Label OTGWLabelDiagTapWaterEnabled;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagCoolingEnabled;
        private System.Windows.Forms.Label OTGWLabelDiagCoolingEnabled;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagOTCActive;
        private System.Windows.Forms.Label OTGWLabelDiagOTCActive;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagCH2Enabled;
        private System.Windows.Forms.Label OTGWLabelDiagCH2Enabled;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagSlaveMemberID;
        private System.Windows.Forms.Label OTGWLabelDiagSlaveMemberID;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagMasterMemberID;
        private System.Windows.Forms.Label OTGWLabelDiagMasterMemberID;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagTapWaterPresent;
        private System.Windows.Forms.Label OTGWLabelDiagTapWaterPresent;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagControlType;
        private System.Windows.Forms.Label OTGWLabelDiagControlType;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagCoolingConfiguration;
        private System.Windows.Forms.Label OTGWLabelDiagCoolingConfiguration;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagTapWaterConfiguration;
        private System.Windows.Forms.Label OTGWLabelDiagTapWaterConfiguration;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagMasterLowOffPumpControl;
        private System.Windows.Forms.Label OTGWLabelDiagMasterLowOffPumpControl;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagCH2Present;
        private System.Windows.Forms.Label OTGWLabelDiagCH2Present;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagServiceRequest;
        private System.Windows.Forms.Label OTGWLabelDiagServiceRequest;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagLockoutReset;
        private System.Windows.Forms.Label OTGWLabelDiagLockoutReset;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagLowWaterPressure;
        private System.Windows.Forms.Label OTGWLabelDiagLowWaterPressure;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagGasFlameFault;
        private System.Windows.Forms.Label OTGWLabelDiagGasFlameFault;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagAirPressureFault;
        private System.Windows.Forms.Label OTGWLabelDiagAirPressureFault;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagWaterOvertemp;
        private System.Windows.Forms.Label OTGWLabelDiagWaterOvertemp;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagOEMFaultCode;
        private System.Windows.Forms.Label OTGWLabelDiagOEMFaultCode;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagOEMDiagnosticCode;
        private System.Windows.Forms.Label OTGWLabelDiagOEMDiagnosticCode;
        private System.Windows.Forms.Label OTGWLabelDiagTimeAndDay;
        private System.Windows.Forms.Label OTGWLabelDiagYear;
        private System.Windows.Forms.Label OTGWLabelDiagDate;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagSolarStorageTemperature;
        private System.Windows.Forms.Label OTGWLabelDiagSolarStorageTemperature;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagSolarCollectorTemperature;
        private System.Windows.Forms.Label OTGWLabelDiagSolarCollectorTemperature;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagFlowTemperatureCH2;
        private System.Windows.Forms.Label OTGWLabelDiagFlowTemperatureCH2;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagExhaustTemperature;
        private System.Windows.Forms.Label OTGWLabelDiagExhaustTemperature;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagTapWater2Temperature;
        private System.Windows.Forms.Label OTGWLabelDiagTapWater2Temperature;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagBurnerStarts;
        private System.Windows.Forms.Label OTGWLabelDiagBurnerStarts;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagPumpStarts;
        private System.Windows.Forms.Label OTGWLabelDiagPumpStarts;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagTapWaterValveStarts;
        private System.Windows.Forms.Label OTGWLabelDiagTapWaterValveStarts;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagTapWaterBurnerStarts;
        private System.Windows.Forms.Label OTGWLabelDiagTapWaterBurnerStarts;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagBurnerHours;
        private System.Windows.Forms.Label OTGWLabelDiagBurnerHours;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagPumpHours;
        private System.Windows.Forms.Label OTGWLabelDiagPumpHours;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagTapWaterValveHours;
        private System.Windows.Forms.Label OTGWLabelDiagTapWaterValveHours;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagTapWaterBurnerHours;
        private System.Windows.Forms.Label OTGWLabelDiagTapBurnerHours;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagOpenThermVersionMaster;
        private System.Windows.Forms.Label OTGWLabelDiagOpenThermVersionMaster;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagOpenThermVersionSlave;
        private System.Windows.Forms.Label OTGWLabelDiagOpenThermVersionSlave;
        private System.Windows.Forms.Label OTGWLabelProductVersionSlave;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagProductVersionMaster;
        private System.Windows.Forms.Label OTGWLabelDiagProductVersionMaster;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagProductTypeSlave;
        private System.Windows.Forms.Label OTGWLabelProductTypeSlave;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagProductTypeMaster;
        private System.Windows.Forms.Label OTGWLabelDiagProductTypeMaster;
        private System.Windows.Forms.TextBox OTGWTextBoxDiagProductVersionSlave;
        private ScottPlot.FormsPlot OTGWFormsPlotFloats;
        private System.Windows.Forms.TextBox OTGWTextBoxLogfileName;
        private System.Windows.Forms.Label OTGWLabelLogfileName;
        private System.Windows.Forms.CheckBox OTGWCheckBoxAppend;
        private System.Windows.Forms.Label OTGWLabelAppend;
        private System.Windows.Forms.CheckBox OTGWCheckBoxEnableLoggingToFile;
        private System.Windows.Forms.Button MaxButtonConnect;
        private System.Windows.Forms.Label MaxLabelHostName;
        private System.Windows.Forms.Button MaxButtonDisconnect;
        private System.Windows.Forms.TextBox MaxTextBoxHostname;
        private System.Windows.Forms.ListBox MAXListboxLog;
        private System.Windows.Forms.TabControl MaxTabControl;
        private System.Windows.Forms.TabPage MaxTabPageStatusOverview;
        private System.Windows.Forms.TabPage MaxTabConnection;
        private System.Windows.Forms.TabPage MaxTabRooms;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ListBox MaxListBoxRoomsDevice;
        private System.Windows.Forms.Label MaxLabelRoomsDevice;
        private System.Windows.Forms.ListBox MaxListBoxRoomsRooms;
        private System.Windows.Forms.ListBox MaxListBoxRoomsMaxCube;
        private System.Windows.Forms.Label MaxLabelRoomsRoom;
        private System.Windows.Forms.Label MaxLabelRoomsMaxCube;
        private System.Windows.Forms.TextBox MaxTextBoxRoomsCubeRfAddress;
        private System.Windows.Forms.TextBox MaxTextBoxRoomsCubeSerialNumber;
        private System.Windows.Forms.TextBox MaxTextBoxRoomsCubeName;
        private System.Windows.Forms.Label MaxLabelRFAddress;
        private System.Windows.Forms.Label MaxLabelRoomsSerialNumber;
        private System.Windows.Forms.Label MaxLabelRoomsName;
        private System.Windows.Forms.TextBox MaxTextBoxRoomsEmptyMemorySlots;
        private System.Windows.Forms.TextBox MaxTextBoxRoomsDutyCycle;
        private System.Windows.Forms.Label MaxLabelRoomsEmptyMemorySlots;
        private System.Windows.Forms.Label MaxLabelRoomsDutyCycle;
        private System.Windows.Forms.TextBox MaxTextBoxRoomsPortalURL;
        private System.Windows.Forms.Label MaxLabelRoomsPortalURL;
        private System.Windows.Forms.TextBox MaxTextBoxRoomsCubeVersion;
        private System.Windows.Forms.Label MaxLabelRoomsCubeVersion;
        private System.Windows.Forms.TextBox MaxTextBoxRoomsPortalEnabled;
        private System.Windows.Forms.Label MaxLabelRoomsPortalEnabled;
        private System.Windows.Forms.TextBox MaxTextBoxRoomsPushButtonDown;
        private System.Windows.Forms.TextBox MaxTextBoxRoomsPushButtonUp;
        private System.Windows.Forms.Label MaxLabelRoomsPushButtonDown;
        private System.Windows.Forms.Label MaxLabelRoomsPushButtonUp;
        private System.Windows.Forms.TextBox MaxTextBoxRoomsDateTime;
        private System.Windows.Forms.Label MaxLabelRoomsDateTime;
        private System.Windows.Forms.Label MaxLabelRoomsRoomID;
        private System.Windows.Forms.Label MaxLabelRoomsRoomRFAddress;
        private System.Windows.Forms.TextBox MaxTextBoxRoomsRoomRFAddress;
        private System.Windows.Forms.TextBox MaxTextBoxRoomsRoomID;
        private System.Windows.Forms.TextBox MaxTextBoxRoomsRoomActualTemperature;
        private System.Windows.Forms.Label MaxLabelRoomsRoomActualTemperature;
        private System.Windows.Forms.TextBox MaxTextBoxRoomsRoomConfiguredTemperature;
        private System.Windows.Forms.Label MaxLabelRoomsRoomConfiguredTemperature;
        private System.Windows.Forms.TextBox MaxTextBoxRoomsDeviceRFAddress;
        private System.Windows.Forms.Label MaxLabelRoomsDeviceRFAddress;
        private System.Windows.Forms.TextBox MaxTextBoxRoomsDeviceSerialNumber;
        private System.Windows.Forms.Label MaxLabelRoomsDeviceSerialNumber;
        private System.Windows.Forms.TextBox MaxTextBoxRoomsDeviceActualTemperature;
        private System.Windows.Forms.TextBox MaxTextBoxRoomsDeviceConfiguredTemperature;
        private System.Windows.Forms.Label MaxLabelRoomsDeviceActualTemperature;
        private System.Windows.Forms.Label MaxLabelRoomsDeviceConfiguredTemperature;
        private System.Windows.Forms.TextBox MaxTextBoxRoomsDeviceType;
        private System.Windows.Forms.Label MaxLabelRoomsDeviceType;
        private System.Windows.Forms.TextBox MaxTextBoxRoomsDeviceComfortTemperature;
        private System.Windows.Forms.TextBox MaxTextBoxRoomsDeviceEcoTemperature;
        private System.Windows.Forms.Label MaxLabelRoomsDeviceComfortTemperature;
        private System.Windows.Forms.Label MaxLabelRoomsDeviceEcoTemperature;
        private System.Windows.Forms.TextBox MaxTextBoxRoomsBoostPercentage;
        private System.Windows.Forms.TextBox MaxTextBoxRoomsBoostDuration;
        private System.Windows.Forms.Label MaxLabelRoomsBoostPercentage;
        private System.Windows.Forms.Label MaxLabelRoomsBoostDuration;
        private System.Windows.Forms.TextBox MaxTextBoxRoomsDecalcificationHour;
        private System.Windows.Forms.TextBox MaxTextBoxRoomsDecalcificationDay;
        private System.Windows.Forms.Label MaxLabelRoomsDecalcificationHour;
        private System.Windows.Forms.Label MaxLabelRoomsDecalcificationDay;
        private System.Windows.Forms.TextBox MaxTextBoxRoomsMinSetpointTemperature;
        private System.Windows.Forms.Label MaxLabelRoomsMaxSetpointTemperature;
        private System.Windows.Forms.Label MaxLabelRoomsMinSetPointTemperature;
        private System.Windows.Forms.TextBox MaxTextBoxRoomsMaxSetpointTemperature;
        private System.Windows.Forms.TextBox MaxTextBoxRoomsWindowOpenTemperature;
        private System.Windows.Forms.TextBox MaxTextBoxRoomsWindowOpenDuration;
        private System.Windows.Forms.Label MaxLabelRoomsWindowOpenTemperature;
        private System.Windows.Forms.Label MaxLabelRoomsWindowOpenDuration;
        private System.Windows.Forms.Label MaxLabelRoomsValvePosition;
        private System.Windows.Forms.TextBox MaxTextBoxRoomsValveOffsetPercent;
        private System.Windows.Forms.TextBox MaxTextBoxRoomsValveMaxPercent;
        private System.Windows.Forms.TextBox MaxTextBoxRoomsValvePosition;
        private System.Windows.Forms.Label MaxLabelRoomsValveOffsetPercent;
        private System.Windows.Forms.Label MaxLabelRoomsValveMaxPercent;
        private System.Windows.Forms.TextBox MaxTextBoxRoomsNTPServer;
        private System.Windows.Forms.Label MaxLabelRoomsNTPServer;
        private System.Windows.Forms.CheckBox MaxCheckBoxAppend;
        private System.Windows.Forms.Label MaxLabelAppend;
        private System.Windows.Forms.TextBox MaxTextBoxLogFilename;
        private System.Windows.Forms.Label MaxLabelLogFilename;
        private System.Windows.Forms.CheckBox MaxCheckBoxEnableLoggingToFile;
    }
}

