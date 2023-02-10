﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScottPlot;
using ScottPlot.Plottable;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using System.IO;
using static HeatControl.MaxCubeLogger.MaxCube;
using static HeatControl.MaxCubeLogger;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Globalization;

namespace HeatControl
{
    public partial class Form1 : Form
    {
        private OTGW otgw;
        private MaxCubeLogger maxCubeLogger;
        private FileStream logFileStreamOTGW;
        private FileStream logFileStreamMax;

        public Form1()
        {
            InitializeComponent();

            this.otgw = new OTGW();
            this.maxCubeLogger = new MaxCubeLogger();

            this.listeners = new List<ListernerBase>()
            {
                new ListenerGeneral<string>(this.OTGWLabelVersion, this.otgw.gatewayConfiguration.version),
                new ListenerGeneral<string>(this.OTGWLabelBuild, this.otgw.gatewayConfiguration.build),
                new ListenerGeneral<float>(this.OTGWTextBoxRoomTemp, this.otgw.gatewayStatus.roomTemperature),
                new ListenerGeneral<float>(this.OTGWTextBoxBoilerTemp, this.otgw.gatewayStatus.boilerWaterTemperature),
                new ListenerGeneral<bool>(this.OTGWTextBoxFlameStatus, this.otgw.gatewayStatus.flameStatus),
                new ListenerGeneral<bool>(this.OTGWTextBoxCentralHeatingMode, this.otgw.gatewayStatus.centralHeatingMode),
                new ListenerGeneral<bool>(this.OTGWTextBoxTapWaterMode, this.otgw.gatewayStatus.tapWaterMode),
                new ListenerGeneral<bool>(this.OTGWTextBoxFaultIndication, this.otgw.gatewayStatus.faultIndication),
                new ListenerGeneral<float>(this.OTGWTextBoxControlSetpoint, this.otgw.gatewayStatus.controlSetPoint),
                new ListenerGeneral<float>(this.OTGWTextBoxControlSetpointModified, this.otgw.gatewayStatus.controlSetPointModified),
                new ListenerGeneral<float>(this.OTGWTextBoxRoomSetpoint, this.otgw.gatewayStatus.roomSetPoint),
                new ListenerGeneral<float>(this.OTGWTextBoxWaterPressure, this.otgw.gatewayStatus.waterPressureCHCircuit),
                new ListenerGeneral<float>(this.OTGWTextBoxModulationLevel, this.otgw.gatewayStatus.relativeModulationLevel),
                new ListenerGeneral<float>(this.OTGWTextBoxTapWaterFlow, this.otgw.gatewayStatus.waterFlowRateTap),
                new ListenerGeneral<float>(this.OTGWTextBoxTapWaterTemperature, this.otgw.gatewayStatus.tapWaterTemperature),
                new ListenerGeneral<float>(this.OTGWTextBoxReturnTemperature, this.otgw.gatewayStatus.returnWaterTemperature),
                new ListenerGeneral<float>(this.OTGWTextBoxOutsideTemperature, this.otgw.gatewayStatus.outsideTemperature),

                new ListenerGeneral<bool>(this.OTGWTextBoxDiagCentralHeatingEnabled, this.otgw.gatewayStatus.centralHeatingEnable),
                new ListenerGeneral<bool>(this.OTGWTextBoxDiagTapWaterEnabled, this.otgw.gatewayStatus.tapWaterEnable),
                new ListenerGeneral<bool>(this.OTGWTextBoxDiagCoolingEnabled, this.otgw.gatewayStatus.coolingEnable),
                new ListenerGeneral<bool>(this.OTGWTextBoxDiagOTCActive, this.otgw.gatewayStatus.OTCActive),
                new ListenerGeneral<bool>(this.OTGWTextBoxDiagCH2Enabled, this.otgw.gatewayStatus.CH2Enable),
                new ListenerGeneral<bool>(this.OTGWTextBoxDiagTapWaterPresent, this.otgw.gatewayStatus.tapWaterPresent),
                new ListenerGeneral<bool>(this.OTGWTextBoxDiagControlType, this.otgw.gatewayStatus.controlType),
                new ListenerGeneral<bool>(this.OTGWTextBoxDiagCoolingConfiguration, this.otgw.gatewayStatus.coolingConfiguration),
                new ListenerGeneral<bool>(this.OTGWTextBoxDiagTapWaterConfiguration, this.otgw.gatewayStatus.tapWaterConfiguration),
                new ListenerGeneral<bool>(this.OTGWTextBoxDiagMasterLowOffPumpControl, this.otgw.gatewayStatus.masterLowOffPumpControl),
                new ListenerGeneral<bool>(this.OTGWTextBoxDiagCH2Present, this.otgw.gatewayStatus.CH2Present),
                new ListenerGeneral<bool>(this.OTGWTextBoxDiagServiceRequest, this.otgw.gatewayStatus.serviceRequest),
                new ListenerGeneral<bool>(this.OTGWTextBoxDiagLockoutReset, this.otgw.gatewayStatus.lockoutReset),
                new ListenerGeneral<bool>(this.OTGWTextBoxDiagLowWaterPressure, this.otgw.gatewayStatus.lowWaterPressure),
                new ListenerGeneral<bool>(this.OTGWTextBoxDiagGasFlameFault, this.otgw.gatewayStatus.gasFlameFault),
                new ListenerGeneral<bool>(this.OTGWTextBoxDiagAirPressureFault, this.otgw.gatewayStatus.airPressureFault),
                new ListenerGeneral<bool>(this.OTGWTextBoxDiagWaterOvertemp, this.otgw.gatewayStatus.waterOvertemp),
                new ListenerGeneral<int>(this.OTGWTextBoxDiagOEMFaultCode, this.otgw.gatewayStatus.OEMFaultCode),
                new ListenerGeneral<int>(this.OTGWTextBoxDiagOEMDiagnosticCode, this.otgw.gatewayStatus.OEMDiagnosticCode),
                new ListenerDay(this.OTGWLabelDiagTimeAndDay, this.otgw.gatewayStatus.timeAndDay),
                new ListenerDate(this.OTGWLabelDiagDate, this.otgw.gatewayStatus.date),
                new ListenerGeneral<int>(this.OTGWLabelDiagYear, this.otgw.gatewayStatus.year),
                new ListenerGeneral<int>(this.OTGWTextBoxDiagMasterMemberID, this.otgw.gatewayStatus.masterMemberID),
                new ListenerGeneral<int>(this.OTGWTextBoxDiagSlaveMemberID, this.otgw.gatewayStatus.slaveMemberID),
                new ListenerGeneral<float>(this.OTGWTextBoxDiagSolarStorageTemperature, this.otgw.gatewayStatus.solarStorageTemperature),
                new ListenerGeneral<int>(this.OTGWTextBoxDiagSolarCollectorTemperature, this.otgw.gatewayStatus.solarCollectorTemperature),
                new ListenerGeneral<float>(this.OTGWTextBoxDiagFlowTemperatureCH2, this.otgw.gatewayStatus.flowTemperatureCH2),
                new ListenerGeneral<float>(this.OTGWTextBoxDiagTapWater2Temperature, this.otgw.gatewayStatus.tapWaterTemperature2),
                new ListenerGeneral<int>(this.OTGWTextBoxDiagExhaustTemperature, this.otgw.gatewayStatus.exhaustTemperature),

                new ListenerGeneral<int>(this.OTGWTextBoxDiagBurnerStarts, this.otgw.gatewayStatus.burnerStarts),
                new ListenerGeneral<int>(this.OTGWTextBoxDiagPumpStarts, this.otgw.gatewayStatus.pumpStarts),
                new ListenerGeneral<int>(this.OTGWTextBoxDiagTapWaterValveStarts, this.otgw.gatewayStatus.tapWaterValveStarts),
                new ListenerGeneral<int>(this.OTGWTextBoxDiagTapWaterBurnerStarts, this.otgw.gatewayStatus.tapWaterBurnerStarts),
                new ListenerGeneral<int>(this.OTGWTextBoxDiagBurnerHours, this.otgw.gatewayStatus.burnerOperatingHours),
                new ListenerGeneral<int>(this.OTGWTextBoxDiagPumpHours, this.otgw.gatewayStatus.pumpOperatingHours),
                new ListenerGeneral<int>(this.OTGWTextBoxDiagTapWaterValveHours, this.otgw.gatewayStatus.tapWaterValveHours),
                new ListenerGeneral<int>(this.OTGWTextBoxDiagTapWaterBurnerHours, this.otgw.gatewayStatus.tapWaterBurnerHours),


                new ListenerGeneral<string>(this.OTGWTextBoxDiagVersion, this.otgw.gatewayConfiguration.version),
                new ListenerGeneral<string>(this.OTGWTextBoxDiagBuild, this.otgw.gatewayConfiguration.build),
                new ListenerGeneral<string>(this.OTGWTextBoxDiagClockSpeed, this.otgw.gatewayConfiguration.clockSpeed),
                new ListenerGeneral<string>(this.OTGWTextBoxDiagTemperatureSensorFunction, this.otgw.gatewayConfiguration.temperaturSensorFunction),
                new ListenerGeneral<string>(this.OTGWTextBoxDiagGPIOFunctions, this.otgw.gatewayConfiguration.gpioFunctionsConfiguration),
                new ListenerGeneral<string>(this.OTGWTextBoxDiagGPIOState, this.otgw.gatewayConfiguration.gpioState),
                new ListenerGeneral<string>(this.OTGWTextBoxDiagLedFunctions, this.otgw.gatewayConfiguration.ledFunctionsConfiguration),
                new ListenerGeneral<string>(this.OTGWTextBoxDiagGatewayMode, this.otgw.gatewayConfiguration.gatewayMode),
                new ListenerGeneral<string>(this.OTGWTextBoxDiagSetpointOverride, this.otgw.gatewayConfiguration.setpointOverride),
                new ListenerGeneral<string>(this.OTGWTextBoxDiagSmartPowerMode, this.otgw.gatewayConfiguration.smartPowerModel),
                new ListenerGeneral<string>(this.OTGWTextBoxDiagCauseOfLastReset, this.otgw.gatewayConfiguration.causeOfLastReset),
                new ListenerGeneral<string>(this.OTGWTextBoxDiagRemehaDetectionState, this.otgw.gatewayConfiguration.remehaDetectionState),
                new ListenerGeneral<string>(this.OTGWTextBoxDiagSetbackTemperature, this.otgw.gatewayConfiguration.setbackTemperatureConfiguarion),
                new ListenerGeneral<string>(this.OTGWTextBoxDiagTweaks, this.otgw.gatewayConfiguration.tweaks),
                new ListenerGeneral<string>(this.OTGWTextBoxDiagReferenceVoltage, this.otgw.gatewayConfiguration.referenceVoltage),
                new ListenerGeneral<string>(this.OTGWTextBoxDiagHotWater, this.otgw.gatewayConfiguration.hotWater),

                new ListenerGeneral<float>(this.OTGWTextBoxDiagOpenThermVersionMaster, this.otgw.gatewayStatus.openthermVersionMaster),
                new ListenerGeneral<float>(this.OTGWTextBoxDiagOpenThermVersionSlave, this.otgw.gatewayStatus.openthermVersionSlave),
                new ListenerGeneral<int>(this.OTGWTextBoxDiagProductTypeMaster, this.otgw.gatewayStatus.productTypeMaster),
                new ListenerGeneral<int>(this.OTGWTextBoxDiagProductTypeSlave, this.otgw.gatewayStatus.productTypeSlave),
                new ListenerGeneral<int>(this.OTGWTextBoxDiagProductVersionMaster, this.otgw.gatewayStatus.productVersionMaster),
                new ListenerGeneral<int>(this.OTGWTextBoxDiagProductVersionSlave, this.otgw.gatewayStatus.productVersionSlave),
            };

            this.OTGWLines = new Dictionary<string, Line>()
            {
                ["BoilerTemp"] = new Line(this.OTGWFormsPlot, "BoilerTemp", Color.Blue),
                ["RoomSetpoint"] = new Line(this.OTGWFormsPlot, "RoomSetpoint", Color.Gray),
                ["Setpoint"] = new Line(this.OTGWFormsPlot, "Setpoint", Color.LightBlue),
                ["SetpointMod"] = new Line(this.OTGWFormsPlot, "SetpointMod", Color.AliceBlue),
                ["Modulation"] = new Line(this.OTGWFormsPlot, "Modulation", Color.Pink),
                ["OutsideTemp"] = new Line(this.OTGWFormsPlot, "OutsideTemp", Color.DeepPink),
                ["ReturnTemp"] = new Line(this.OTGWFormsPlot, "ReturnTemp", Color.DarkRed),
                ["Burner"] = new Line(this.OTGWFormsPlot, "Burner", 10, Color.OrangeRed, Color.Yellow),
                ["TapWater"] = new Line(this.OTGWFormsPlot, "TapWater", 40, Color.DarkGreen, Color.LightGreen),
                ["Heating"] = new Line(this.OTGWFormsPlot, "Heating", 70, Color.DarkMagenta, Color.LightPink),
            };

            this.OTGWFormsPlot.Plot.SetAxisLimits(yMin: 0, yMax: 100);
            this.OTGWFormsPlot.Configuration.LockVerticalAxis = true;
            this.OTGWFormsPlot.Configuration.DoubleClickBenchmark = false;
            this.OTGWFormsPlot.Plot.XAxis.DateTimeFormat(true);
            this.OTGWlegend = this.OTGWFormsPlot.Plot.Legend();
            this.OTGWlegend.Orientation = ScottPlot.Orientation.Vertical;
            this.OTGWlegend.Location = ScottPlot.Alignment.UpperLeft;
            this.OTGWlegend.FontSize = 9;
            this.OTGWFormsPlot.Refresh();


            this.MaxFormsPlot.Plot.SetAxisLimits(yMin: 5, yMax: 35);
            this.MaxFormsPlot.Configuration.LockVerticalAxis = true;
            this.MaxFormsPlot.Configuration.DoubleClickBenchmark = false;
            this.MaxFormsPlot.Plot.XAxis.DateTimeFormat(true);
            this.Maxlegend = this.MaxFormsPlot.Plot.Legend();
            this.Maxlegend.Orientation = ScottPlot.Orientation.Vertical;
            this.Maxlegend.Location = ScottPlot.Alignment.UpperLeft;
            this.Maxlegend.FontSize = 9;
            this.MaxFormsPlot.Refresh();

            this.MaxLabelOverviewBoostActive.Visible = false;

            this.controlGraphx = new double[7];
            this.controlGraphy = new double[7];
            this.ParseControlGraphInputs();
            this.MaxFormsPlotControlCurve.Plot.SetAxisLimits(xMin: 0, xMax: 3, yMin: 0, yMax: 100);
            this.MaxFormsPlotControlCurve.Plot.AddSignalXY(this.controlGraphx, this.controlGraphy);
            this.MaxFormsPlotControlCurve.Plot.XLabel("Room temperature error");
            this.MaxFormsPlotControlCurve.Plot.YLabel("Boiler temperature");
            this.MaxFormsPlotControlCurve.Plot.Title("Control graph");
            this.MaxFormsPlotControlCurve.Refresh();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            OTGWButtonDisconnect_Click(sender, e);
            MaxButtonDisconnect_Click(sender, e);
        }


        private void OTGWButtonConnect_Click(object sender, EventArgs e)
        {
            if (otgw.stateRequest == OTGW.StateRequest.Disconnected)
            {
                this.OTGWButtonConnect.Enabled = false;
                this.OTGWButtonDisconnect.Enabled = true;
                this.OTGWTextBoxLogfileName.Enabled = false;
                this.OTGWCheckBoxAppend.Enabled = false;
                this.OTGWCheckBoxEnableLoggingToFile.Enabled = false;

                this.otgw.hostName = this.OTGWTextboxHostname.Text;

                // Reset the x-axis of the plot to now.
                foreach (KeyValuePair<string, Line> entry in OTGWLines)
                {
                    entry.Value.FillXAxisNow();
                }

                // open log file, if needed
                if (this.OTGWCheckBoxEnableLoggingToFile.Checked)
                {
                    FileMode mode = (this.OTGWCheckBoxAppend.Checked) ? FileMode.Append : FileMode.Create;
                    logFileStreamOTGW = File.Open(this.OTGWTextBoxLogfileName.Text, mode);

                    if (mode == FileMode.Create)
                    {
                        Byte[] heading = new UTF8Encoding().GetBytes(OTGW.StatusReport.heading + "\n");
                        logFileStreamOTGW.Write(heading, 0, heading.Length);
                    }
                    this.otgw.AddStatusReporter(OTGWLogToFile);
                }

                this.otgw.AddLogger(OTGWLogger);
                this.otgw.AddStatusReporter(OTGWPlotter);

                this.otgw.stateRequest = OTGW.StateRequest.Connect;
            }
        }

        private void OTGWButtonDisconnect_Click(object sender, EventArgs e)
        {
            if (otgw.stateRequest == OTGW.StateRequest.Running)
            {

                this.otgw.stateRequest = OTGW.StateRequest.Disconnect;


                this.otgw.RemoveLogger(OTGWLogger);
                this.otgw.RemoveStatusReporter(OTGWPlotter);

                // close the log file
                if (this.OTGWCheckBoxEnableLoggingToFile.Checked)
                {
                    this.otgw.RemoveStatusReporter(OTGWLogToFile);
                    logFileStreamOTGW.Close();
                }

                this.OTGWButtonConnect.Enabled = true;
                this.OTGWButtonDisconnect.Enabled = false;
                this.OTGWTextBoxLogfileName.Enabled = true;
                this.OTGWCheckBoxAppend.Enabled = true;
                this.OTGWCheckBoxEnableLoggingToFile.Enabled = true;
            }

        }


        private void OTGWLogger(string text)
        {
            if (this.OTGWListboxLog.InvokeRequired)
            {
                this.OTGWListboxLog.Invoke((Action)delegate { OTGWLogger(text); });
            }
            else
            {
                this.OTGWListboxLog.Items.Add(text);
                if (this.OTGWListboxLog.Items.Count > 100)
                {
                    OTGWListboxLog.Items.RemoveAt(0);
                }
                this.OTGWListboxLog.SelectedIndex = this.OTGWListboxLog.Items.Count - 1;
            }
        }


        private delegate void Listener(object value);
        private List<ListernerBase> listeners;


        private class ListernerBase
        {
            public Control control;

            public ListernerBase(Control control)
            {
                this.control = control;
            }
        }

        private class ListenerGeneral<T> : ListernerBase
        {
            public ListenerGeneral(Control control, OTGW.VarValueName<T> property) : base(control)
            {
                property.AddListener(this.Listener);
            }

            public void Listener(T value)
            {
                if (this.control.InvokeRequired)
                {
                    this.control.Invoke((Action)delegate { this.Listener(value); });
                }
                else
                {
                    this.control.Text = value.ToString();
                }
            }
        }

        private class ListenerDay : ListernerBase
        {
            private string[] daysOfWeek = { "", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            public ListenerDay(Control control, OTGW.IntValueName property) : base(control)
            {
                property.AddListener(this.Listener);
            }

            public void Listener(int value)
            {
                if (this.control.InvokeRequired)
                {
                    this.control.Invoke((Action)delegate { this.Listener(value); });
                }
                else
                {
                    this.control.Text = this.daysOfWeek[value >> 13] + " " + ((value >> 8) & 0x1F).ToString() + ":" + (((value & 0xFF) < 10) ? "0" : "") + (value & 0xFF).ToString();
                }
            }
        }

        private class ListenerDate : ListernerBase
        {
            private string[] months = { "", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

            public ListenerDate(Control control, OTGW.IntValueName property) : base(control)
            {
                property.AddListener(this.Listener);
            }

            public void Listener(int value)
            {
                if (this.control.InvokeRequired)
                {
                    this.control.Invoke((Action)delegate { this.Listener(value); });
                }
                else
                {
                    this.control.Text = this.months[value >> 8] + " " + (value & 0xFF).ToString();
                }
            }
        }


        private Dictionary<string, Line> OTGWLines;
        private ScottPlot.Renderable.Legend OTGWlegend;
        private class Line
        {
            private FormsPlot plot;
            private bool isBool;
            private double[] xData;
            private double[] yData;
            private string name;
            private Color color;
            private Color fillColor;
            private double gain;
            private double offset;

            ScottPlot.Plottable.SignalPlotXY line;
            private int xCount; // number of valid elements in the data array
            private int xLim;   // maximum of elements that should be in the plot (auto-zooming when data arrays are not filled yet)
            private const int xSize = 10000; // maximum size of data arrays

            // Main constructor for all lines
            private Line(FormsPlot plot, bool isBool, string name, double gain, double offset, Color color, Color fillColor)
            {
                this.plot = plot;
                this.name = name;
                this.gain = gain;
                this.offset = offset;
                this.color = color;
                this.fillColor = fillColor;
                this.isBool = isBool;

                this.xCount = 0;
                this.xData = new double[xSize];
                this.yData = new double[xSize];

                this.line = this.plot.Plot.AddSignalXY(this.xData, this.yData, label: name);
                if (this.isBool) this.line.FillAboveAndBelow(fillColor, fillColor);
                this.line.BaselineY = offset;
                this.line.OffsetY = offset + 2;
                this.line.MarkerSize = 0;
                this.line.Color = this.color;

                this.FillXAxisNow();
            }

            //Constructor for float-data lines
            public Line(FormsPlot plot, string name, Color color) : this(plot, false, name, 1, 0, color, color) { }

            //Constructor for bool-data lines
            public Line(FormsPlot plot, string name, double offset, Color color, Color fillColor) : this(plot, true, name, 10, offset, color, fillColor) { }

            public void FillXAxisNow()
            {
                for (int i = 0; i < xSize; i++)
                {
                    xData[i] = (DateTime.Now + TimeSpan.FromSeconds(OTGW.statusReportInterval * i)).ToOADate();
                }
                this.line.MaxRenderIndex = 0;
                this.xLim = 10;
                this.xCount = 0;
                this.plot.Plot.SetAxisLimits(xMin: xData[0], xMax: xData[xLim - 1]);
            }

            public void AddPoint(double xValue, double yValue)
            {
                if (yValue != -1)
                {
                    xData[xCount] = xValue;
                    yData[xCount] = yValue * this.gain;
                    xCount++;

                    if (xCount > xLim)
                    {
                        xLim *= 3;
                        if (xLim > xSize)
                        {
                            xLim = xSize;
                        }
                        this.plot.Plot.SetAxisLimits(xMin: xData[0], xMax: xData[xLim - 1]);
                    }

                    if (xCount == xSize)
                    {
                        int skip = xSize / 10;
                        Array.Copy(xData, skip, xData, 0, xSize - skip);
                        Array.Copy(yData, skip, yData, 0, xSize - skip);
                        xCount -= skip;

                        DateTime xValueDateTime = DateTime.FromOADate(xValue);
                        // extend x-axis
                        for (int i = 1; i < skip; i++)
                        {
                            xData[xSize - skip + i] = (xValueDateTime + TimeSpan.FromSeconds(OTGW.statusReportInterval * i)).ToOADate();
                        }
                        this.plot.Plot.SetAxisLimits(xMin: xData[0], xMax: xData[xSize - 1]);
                    }
                    this.line.MaxRenderIndex = xCount - 1;
                }
            }

            public void SetVisibilty(bool enabled)
            {
                this.line.IsVisible = enabled;
            }
        }
        private void OTGWPlotter(OTGW.StatusReport status)
        {
            double dateTime = status.dateTime.ToOADate();

            OTGWLines["BoilerTemp"].AddPoint(dateTime, status.boilerWaterTemperature.value);
            OTGWLines["RoomSetpoint"].AddPoint(dateTime, status.roomSetPoint.value);
            OTGWLines["Setpoint"].AddPoint(dateTime, status.controlSetPoint.value);
            OTGWLines["SetpointMod"].AddPoint(dateTime, status.controlSetPointModified.value);
            OTGWLines["Modulation"].AddPoint(dateTime, status.relativeModulationLevel.value);
            OTGWLines["OutsideTemp"].AddPoint(dateTime, status.outsideTemperature.value);
            OTGWLines["ReturnTemp"].AddPoint(dateTime, status.returnWaterTemperature.value);
            OTGWLines["Burner"].AddPoint(dateTime, Convert.ToDouble(status.flameStatus.value));
            OTGWLines["TapWater"].AddPoint(dateTime, Convert.ToDouble(status.tapWaterMode.value));
            OTGWLines["Heating"].AddPoint(dateTime, Convert.ToDouble(status.centralHeatingMode.value));

            this.OTGWFormsPlot.Invoke((Action)delegate { this.OTGWFormsPlot.Refresh(); });
        }

        private void OTGWLogToFile(OTGW.StatusReport status)
        {
            Byte[] line = new UTF8Encoding().GetBytes(status.ToString() + "\n");
            logFileStreamOTGW.Write(line, 0, line.Length);
        }

        private void MAXButtonConnect_Click(object sender, EventArgs e)
        {
            if (maxCubeLogger.stateRequest == MaxCubeLogger.StateRequest.Disconnected)
            {
                this.MaxButtonConnect.Enabled = false;
                this.MaxButtonDisconnect.Enabled = true;
                this.MaxTextBoxLogFilename.Enabled = false;
                this.OTGWCheckBoxAppend.Enabled = false;
                this.OTGWCheckBoxEnableLoggingToFile.Enabled = false;

                this.maxCubeLogger.hostName = this.MaxTextBoxHostname.Text;

                /*
                // Reset the x-axis of the plot to now.
                foreach (KeyValuePair<string, Line> entry in lines)
                {
                    entry.Value.FillXAxisNow();
                }
                */

                // open log file, if needed
                if (this.MaxCheckBoxEnableLoggingToFile.Checked)
                {
                    // indicate that the stream is not open yet
                    logFileStreamMax = null;

                    this.maxCubeLogger.AddStatusReporter(MaxLogToFile);
                }

                this.otgw.AddLogger(OTGWLogger);
                this.otgw.AddStatusReporter(OTGWPlotter);

                this.maxCubeLogger.AddLogger(MaxLogger);
                this.maxCubeLogger.AddStatusReporter(MaxPlotter);
                this.maxCubeLogger.AddStatusReporter(MaxController);
                this.maxCubeLogger.stateRequest = MaxCubeLogger.StateRequest.Connect;
            }
        }


        private void MaxButtonDisconnect_Click(object sender, EventArgs e)
        {
            //this.maxCubeLogger.RemoveLogger(MAXLogger);

            if (maxCubeLogger.stateRequest == MaxCubeLogger.StateRequest.Running)
            {

                this.maxCubeLogger.stateRequest = MaxCubeLogger.StateRequest.Disconnect;


                this.maxCubeLogger.RemoveLogger(MaxLogger);

                /*
                this.otgw.RemoveStatusReporter(OTGWPlotter);
                */

                
                // close the log file
                if (this.MaxCheckBoxEnableLoggingToFile.Checked)
                {
                    this.maxCubeLogger.RemoveStatusReporter(MaxLogToFile);
                    logFileStreamMax.Close();
                }

                this.MaxButtonConnect.Enabled = true;
                this.MaxButtonDisconnect.Enabled = false;
                this.MaxTextBoxLogFilename.Enabled = true;
                this.MaxCheckBoxAppend.Enabled = true;
                this.MaxCheckBoxEnableLoggingToFile.Enabled = true;
            }

        }




        private void MaxLogger(string text)
        {
            if (this.MAXListboxLog.InvokeRequired)
            {
                this.MAXListboxLog.Invoke((Action)delegate { MaxLogger(text); });
            }
            else
            {
                this.MAXListboxLog.Items.Add(text);
                if (this.MAXListboxLog.Items.Count > 100)
                {
                    this.MAXListboxLog.Items.RemoveAt(0);
                }
                this.MAXListboxLog.SelectedIndex = this.MAXListboxLog.Items.Count - 1;
            }
        }

        private void MaxTabControl_Selected(object sender, TabControlEventArgs e)
        {
            TabPage selectedTab = this.MaxTabControl.SelectedTab;
            if (selectedTab == this.MaxTabRooms) // see if we need to refresh the Rooms page
            {
                // Make all listboxes empty
                this.MaxListBoxRoomsMaxCube.Items.Clear();
                this.MaxListBoxRoomsRooms.Items.Clear();
                this.MaxListBoxRoomsDevice.Items.Clear();

                if (this.maxCubeLogger.IsConnected())
                {
                    foreach (MaxCubeLogger.MaxCube maxCube in this.maxCubeLogger.maxCubes)
                    {
                        this.MaxListBoxRoomsMaxCube.Items.Add(maxCube.iPAddress.ToString());
                    }
                }

                ClearMaxCube();
                ClearRoom();
                ClearDevice();
            }
        }

        private void MaxListBoxRoomsMaxCube_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.MaxListBoxRoomsMaxCube.Items.Count > 0)
            {
                this.MaxListBoxRoomsRooms.Items.Clear();
                this.MaxListBoxRoomsDevice.Items.Clear();

                // check if we did not click a line beyond the last line (hence an empty line)
                if (this.MaxListBoxRoomsMaxCube.SelectedIndex < 0)
                {
                    this.MaxListBoxRoomsMaxCube.SelectedIndex = 0;
                }


                MaxCubeLogger.MaxCube maxCube = this.maxCubeLogger.maxCubes[this.MaxListBoxRoomsMaxCube.SelectedIndex];

                foreach (KeyValuePair<int, Room> kvp in maxCube.rooms)
                {
                    this.MaxListBoxRoomsRooms.Items.Add(kvp.Value.name);
                }

                this.MaxTextBoxRoomsCubeName.Text = maxCube.deviceMaxCube.name;
                this.MaxTextBoxRoomsCubeSerialNumber.Text = maxCube.deviceMaxCube.serialNumber;
                this.MaxTextBoxRoomsCubeRfAddress.Text = maxCube.deviceMaxCube.rfAddress.ToString("X6");
                this.MaxTextBoxRoomsCubeVersion.Text = maxCube.deviceMaxCube.version;
                this.MaxTextBoxRoomsDutyCycle.Text = maxCube.deviceMaxCube.dutyCycle.ToString();
                this.MaxTextBoxRoomsEmptyMemorySlots.Text = maxCube.deviceMaxCube.freeMemorySlots.ToString();
                this.MaxTextBoxRoomsPortalURL.Text = maxCube.deviceMaxCube.portalURL;
                this.MaxTextBoxRoomsNTPServer.Text = maxCube.deviceMaxCube.NTPserver;
                this.MaxTextBoxRoomsPortalEnabled.Text = maxCube.deviceMaxCube.portalEnabled.ToString();
                this.MaxTextBoxRoomsPushButtonUp.Text = maxCube.deviceMaxCube.pushButtonUpConfig.ToString();
                this.MaxTextBoxRoomsPushButtonDown.Text = maxCube.deviceMaxCube.pushButtonDownConfig.ToString();
                this.MaxTextBoxRoomsDateTime.Text = maxCube.deviceMaxCube.dateTime.ToString("yyyy-MM-dd   HH:mm");
                ClearRoom();
                ClearDevice();
            }
        }

        private void MaxListBoxRoomsRooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.MaxListBoxRoomsDevice.Items.Clear();

            MaxCubeLogger.MaxCube maxCube = this.maxCubeLogger.maxCubes[this.MaxListBoxRoomsMaxCube.SelectedIndex];
            MaxCubeLogger.MaxCube.Room room = maxCube.rooms[this.MaxListBoxRoomsRooms.SelectedIndex];

            foreach (MaxCubeLogger.MaxCube.DeviceBase device in room.devices)
            {
                this.MaxListBoxRoomsDevice.Items.Add(device.name);
            }

            this.MaxTextBoxRoomsRoomRFAddress.Text = room.rfAddress.ToString("X6");
            this.MaxTextBoxRoomsRoomID.Text = room.roomID.ToString();
            this.MaxTextBoxRoomsRoomActualTemperature.Text = room.actualTemperature.ToString();
            this.MaxTextBoxRoomsRoomConfiguredTemperature.Text = room.configuredTemperature.ToString();

            ClearDevice();
        }

        private void MaxListBoxRoomsDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            MaxCubeLogger.MaxCube maxCube = this.maxCubeLogger.maxCubes[this.MaxListBoxRoomsMaxCube.SelectedIndex];
            MaxCubeLogger.MaxCube.Room room = maxCube.rooms[this.MaxListBoxRoomsRooms.SelectedIndex];
            MaxCubeLogger.MaxCube.DeviceBase device = room.devices[this.MaxListBoxRoomsDevice.SelectedIndex];

            this.MaxTextBoxRoomsDeviceSerialNumber.Text = device.serialNumber;
            this.MaxTextBoxRoomsDeviceRFAddress.Text = device.rfAddress.ToString("X6");

            switch (device.type)
            {
                case DeviceType.HeatingThermostat:
                case DeviceType.HeatingThermostatTODO:
                    this.MaxTextBoxRoomsDeviceType.Text = "Heating thermostat";
                    MaxCubeLogger.MaxCube.DeviceHeatingThermostat heatingThermostat = (MaxCubeLogger.MaxCube.DeviceHeatingThermostat)device;
                    this.MaxTextBoxRoomsDeviceActualTemperature.Text = "";
                    this.MaxTextBoxRoomsDeviceConfiguredTemperature.Text = heatingThermostat.configuredTemperature.ToString();
                    this.MaxTextBoxRoomsDeviceComfortTemperature.Text =heatingThermostat.comfortTemperature.ToString();
                    this.MaxTextBoxRoomsDeviceEcoTemperature.Text = heatingThermostat.ecoTemperature.ToString();
                    this.MaxTextBoxRoomsMinSetpointTemperature.Text = heatingThermostat.minSetpointTemperature.ToString();
                    this.MaxTextBoxRoomsMaxSetpointTemperature.Text = heatingThermostat.maxSetpointTemperature.ToString();
                    this.MaxTextBoxRoomsBoostDuration.Text = heatingThermostat.boostDuration.ToString();
                    this.MaxTextBoxRoomsBoostPercentage.Text = heatingThermostat.boostValvePercentage.ToString();
                    this.MaxTextBoxRoomsDecalcificationDay.Text = heatingThermostat.decalcificationDay.ToString();
                    this.MaxTextBoxRoomsDecalcificationHour.Text = heatingThermostat.decalcificationHours.ToString();
                    this.MaxTextBoxRoomsWindowOpenDuration.Text = heatingThermostat.windowOpenDuration.ToString();
                    this.MaxTextBoxRoomsWindowOpenTemperature.Text = heatingThermostat.windowOpenTemperature.ToString();
                    this.MaxTextBoxRoomsValvePosition.Text = heatingThermostat.valvePosition.ToString();
                    this.MaxTextBoxRoomsValveMaxPercent.Text = heatingThermostat.valveMaxPercent.ToString();
                    this.MaxTextBoxRoomsValveOffsetPercent.Text = heatingThermostat.valveOffsetPercent.ToString();
                    break;
                case DeviceType.WallThermostat:
                    this.MaxTextBoxRoomsDeviceType.Text = "Wall thermostat";
                    MaxCubeLogger.MaxCube.DeviceWallThermostat wallThermostat = (MaxCubeLogger.MaxCube.DeviceWallThermostat)device;
                    this.MaxTextBoxRoomsDeviceActualTemperature.Text = wallThermostat.actualTemperature.ToString();
                    this.MaxTextBoxRoomsDeviceConfiguredTemperature.Text = wallThermostat.configuredTemperature.ToString();
                    this.MaxTextBoxRoomsDeviceComfortTemperature.Text = wallThermostat.comfortTemperature.ToString();
                    this.MaxTextBoxRoomsDeviceEcoTemperature.Text = wallThermostat.ecoTemperature.ToString();
                    this.MaxTextBoxRoomsMinSetpointTemperature.Text = wallThermostat.minSetpointTemperature.ToString();
                    this.MaxTextBoxRoomsMaxSetpointTemperature.Text = wallThermostat.maxSetpointTemperature.ToString();
                    this.MaxTextBoxRoomsBoostDuration.Text = "";
                    this.MaxTextBoxRoomsBoostPercentage.Text = "";
                    this.MaxTextBoxRoomsDecalcificationDay.Text = "";
                    this.MaxTextBoxRoomsDecalcificationHour.Text = "";
                    this.MaxTextBoxRoomsWindowOpenDuration.Text = "";
                    this.MaxTextBoxRoomsWindowOpenTemperature.Text = "";
                    this.MaxTextBoxRoomsValvePosition.Text = "";
                    this.MaxTextBoxRoomsValveMaxPercent.Text = "";
                    this.MaxTextBoxRoomsValveOffsetPercent.Text = "";
                    break;
                case DeviceType.EcoSwitch:
                    this.MaxTextBoxRoomsDeviceType.Text = "Eco switch";
                    MaxCubeLogger.MaxCube.DeviceEcoSwitch ecoSwitch = (MaxCubeLogger.MaxCube.DeviceEcoSwitch)device;
                    break;
                default: 
                    break;
            }
        }

        private void ClearMaxCube()
        {
            this.MaxTextBoxRoomsCubeName.Text = "";
            this.MaxTextBoxRoomsCubeSerialNumber.Text = "";
            this.MaxTextBoxRoomsCubeRfAddress.Text = "";
            this.MaxTextBoxRoomsCubeVersion.Text = "";
            this.MaxTextBoxRoomsDutyCycle.Text = "";
            this.MaxTextBoxRoomsEmptyMemorySlots.Text = "";
            this.MaxTextBoxRoomsPortalURL.Text = "";
            this.MaxTextBoxRoomsNTPServer.Text = "";
            this.MaxTextBoxRoomsPortalEnabled.Text = "";
            this.MaxTextBoxRoomsPushButtonUp.Text = "";
            this.MaxTextBoxRoomsPushButtonDown.Text = "";
            this.MaxTextBoxRoomsDateTime.Text = "";
        }

        private void ClearRoom()
        {
            this.MaxTextBoxRoomsRoomRFAddress.Text = "";
            this.MaxTextBoxRoomsRoomID.Text = "";
            this.MaxTextBoxRoomsRoomActualTemperature.Text = "";
            this.MaxTextBoxRoomsRoomConfiguredTemperature.Text = "";
        }

        private void ClearDevice()
        {
            this.MaxTextBoxRoomsDeviceType.Text = "";
            this.MaxTextBoxRoomsDeviceSerialNumber.Text = "";
            this.MaxTextBoxRoomsDeviceRFAddress.Text = "";
            this.MaxTextBoxRoomsDeviceActualTemperature.Text = "";
            this.MaxTextBoxRoomsDeviceConfiguredTemperature.Text = "";
            this.MaxTextBoxRoomsDeviceComfortTemperature.Text = "";
            this.MaxTextBoxRoomsDeviceEcoTemperature.Text = "";
            this.MaxTextBoxRoomsMinSetpointTemperature.Text = "";
            this.MaxTextBoxRoomsMaxSetpointTemperature.Text = "";
            this.MaxTextBoxRoomsBoostDuration.Text = "";
            this.MaxTextBoxRoomsBoostPercentage.Text = "";
            this.MaxTextBoxRoomsDecalcificationDay.Text = "";
            this.MaxTextBoxRoomsDecalcificationHour.Text = "";
            this.MaxTextBoxRoomsWindowOpenDuration.Text = "";
            this.MaxTextBoxRoomsWindowOpenTemperature.Text = "";
            this.MaxTextBoxRoomsValvePosition.Text = "";
            this.MaxTextBoxRoomsValveMaxPercent.Text = "";
            this.MaxTextBoxRoomsValveOffsetPercent.Text = "";
        }

        private void MaxLogToFile(MaxCubeLogger.StatusReport status)
        {
            if (this.logFileStreamMax == null) 
            {
                //we still have to open the file
                FileMode mode = (this.MaxCheckBoxAppend.Checked) ? FileMode.Append : FileMode.Create;
                logFileStreamMax = File.Open(this.MaxTextBoxLogFilename.Text, mode);

                if (mode == FileMode.Create)
                {
                    Byte[] heading = new UTF8Encoding().GetBytes(status.Heading() + "\n");
                    logFileStreamMax.Write(heading, 0, heading.Length);
                }
            }

            Byte[] line = new UTF8Encoding().GetBytes(status.ToString() + "\n");
            logFileStreamMax.Write(line, 0, line.Length);
        }


        Dictionary<string, Line> maxLines;
        private ScottPlot.Renderable.Legend Maxlegend;
        private Color[] rainbowColors = { // odd color numbers for setpoint, odd numbers for actual temperature
            Color.Blue, Color.DarkBlue,
            Color.Red, Color.DarkRed,
            Color.Yellow, Color.Beige,
            Color.Green, Color.DarkGreen,
            Color.Gray, Color.DarkGray,
            Color.LightBlue, Color.MediumBlue,
            Color.Pink, Color.IndianRed,
            Color.LightPink, Color.MediumTurquoise,
            Color.LightCyan, Color.Cyan,
            Color.LightGray, Color.LightGray
        };

        private static string setpoint = ":Setpoint";
        private static string actual = ":Actual";
        private bool maxPlotStarted = false;


        private void MaxPlotter(MaxCubeLogger.StatusReport status)
        {
            if (this.MaxCheckedListBoxOverviewPlotSelection.InvokeRequired)
            {
                this.MaxCheckedListBoxOverviewPlotSelection.Invoke((Action)delegate { MaxPlotter(status); });
            }
            else
            {
                // fill CheckedListbox if needed
                if (this.MaxCheckedListBoxOverviewPlotSelection.Items.Count == 0)
                {
                    foreach (MaxCubeLogger.StatusReport.RoomReport roomReport in status.report)
                    {
                        this.MaxCheckedListBoxOverviewPlotSelection.Items.Add(roomReport.name);
                    }

                    for (int i = 0; i< this.MaxCheckedListBoxOverviewPlotSelection.Items.Count; i++)
                    {
                        this.MaxCheckedListBoxOverviewPlotSelection.SetItemChecked(i, true);
                    }
                }

                // fill graph if needed
                if ((this.maxLines == null) || (this.maxLines.Count == 0)) {


                    this.maxLines = new Dictionary<string, Line>();
                    for (int i=0; i< status.report.Count; i++) {
                        MaxCubeLogger.StatusReport.RoomReport roomReport = status.report[i];
                        maxLines.Add(roomReport.name + setpoint, new Line(this.MaxFormsPlot, roomReport.name + setpoint, rainbowColors[(i*2)%rainbowColors.Length]));
                        maxLines.Add(roomReport.name + actual, new Line(this.MaxFormsPlot, roomReport.name + actual, rainbowColors[((i*2)+1) % rainbowColors.Length]));
                    }
                }

                double dateTime = status.dateTime.ToOADate();
                foreach (MaxCubeLogger.StatusReport.RoomReport roomReport in status.report)
                {
                    maxLines[roomReport.name + setpoint].AddPoint(dateTime, roomReport.configuredTemperature);
                    maxLines[roomReport.name + actual].AddPoint(dateTime, roomReport.actualTemperature);
                }
                this.MaxFormsPlot.Refresh();

                maxPlotStarted = true;
            }
        }

        private void MaxCheckedListBoxOverviewPlotSelection_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (maxPlotStarted)
            {
                for (int i = 0; i < this.MaxCheckedListBoxOverviewPlotSelection.Items.Count; i++)
                {
                    bool selectionState = this.MaxCheckedListBoxOverviewPlotSelection.GetItemChecked(i);
                    string name = this.MaxCheckedListBoxOverviewPlotSelection.Items[i].ToString();

                    if (i == e.Index)
                    {
                        bool value = (e.NewValue == CheckState.Checked);
                        maxLines[name + setpoint].SetVisibilty(value);
                        maxLines[name + actual].SetVisibilty(value);
                    }
                    else
                    { 
                        maxLines[name + setpoint].SetVisibilty(selectionState);
                        maxLines[name + actual].SetVisibilty(selectionState);
                    }
                }   
                
                this.MaxFormsPlot.Refresh();
            }
        }

        private void MaxController(MaxCubeLogger.StatusReport status)
        {
            // fill CheckedListbox if needed
            if (this.MaxCheckedListBoxOverviewControlSelection.Items.Count == 0)
            {
                foreach (MaxCubeLogger.StatusReport.RoomReport roomReport in status.report)
                {
                    this.MaxCheckedListBoxOverviewControlSelection.Invoke((Action)delegate { this.MaxCheckedListBoxOverviewControlSelection.Items.Add(roomReport.name); });
                }
            }

            // check if boost is active anywhere
            bool boostActive = false;
            foreach (MaxCubeLogger.StatusReport.RoomReport roomReport in status.report)
            {
                if (roomReport.boostActive) boostActive = true;
            }
            this.MaxLabelOverviewBoostActive.Invoke((Action)delegate { this.MaxLabelOverviewBoostActive.Visible = boostActive; });

            float maxTempDifference = float.MinValue;
            foreach (MaxCubeLogger.StatusReport.RoomReport roomReport in status.report)
            {
                int index = this.MaxCheckedListBoxOverviewControlSelection.Items.IndexOf(roomReport.name);
                if (this.MaxCheckedListBoxOverviewControlSelection.GetItemChecked(index))
                {
                    if ((roomReport.configuredTemperature != -1) && (roomReport.actualTemperature != -1))
                    {
                        float difference = roomReport.configuredTemperature - roomReport.actualTemperature;
                        if (difference > maxTempDifference)
                        {
                            maxTempDifference = difference;
                        }
                    }
                }
            }
            Console.WriteLine(maxTempDifference.ToString());


        }

        private double[] controlGraphx;
        private double[] controlGraphy;
        private void MaxTextBoxControlTempXX_TextChanged(object sender, EventArgs e)
        {
            this.ParseControlGraphInputs();
            this.MaxFormsPlotControlCurve.Refresh();
        }

        private void ParseControlGraphInputs()
        {
            Double.TryParse(this.MaxTextBoxControl00.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out controlGraphx[0]);
            Double.TryParse(this.MaxTextBoxControl05.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out controlGraphx[1]);
            Double.TryParse(this.MaxTextBoxControl10.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out controlGraphx[2]);
            Double.TryParse(this.MaxTextBoxControl15.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out controlGraphx[3]);
            Double.TryParse(this.MaxTextBoxControl20.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out controlGraphx[4]);
            Double.TryParse(this.MaxTextBoxControl25.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out controlGraphx[5]);
            Double.TryParse(this.MaxTextBoxControl30.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out controlGraphx[6]);
            Double.TryParse(this.MaxTextBoxControlTemp00.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out controlGraphy[0]);
            Double.TryParse(this.MaxTextBoxControlTemp05.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out controlGraphy[1]);
            Double.TryParse(this.MaxTextBoxControlTemp10.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out controlGraphy[2]);
            Double.TryParse(this.MaxTextBoxControlTemp15.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out controlGraphy[3]);
            Double.TryParse(this.MaxTextBoxControlTemp20.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out controlGraphy[4]);
            Double.TryParse(this.MaxTextBoxControlTemp25.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out controlGraphy[5]);
            Double.TryParse(this.MaxTextBoxControlTemp30.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out controlGraphy[6]);
        }
    }
}


