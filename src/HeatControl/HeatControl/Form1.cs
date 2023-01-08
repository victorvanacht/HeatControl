using System;
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

namespace HeatControl
{
    public partial class Form1 : Form
    {
        private OTGW otgw;

        public Form1()
        {
            InitializeComponent();

            this.otgw = new OTGW();
            this.otgw.AddLogger(OTGWLogger);
            this.otgw.AddStatusReporter(OTGWPlotter);

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

            this.lines = new Dictionary<string, Line>()
            {
                ["BoilerTemp"] = new Line(this.OTGWFormsPlotFloats, "BoilerTemp", Color.Blue),
                ["RoomSetpoint"] = new Line(this.OTGWFormsPlotFloats, "RoomSetpoint", Color.Gray),
                ["Setpoint"] = new Line(this.OTGWFormsPlotFloats, "Setpoint", Color.LightBlue),
                ["SetpointMod"] = new Line(this.OTGWFormsPlotFloats, "SetpointMod", Color.AliceBlue),
                ["Modulation"] = new Line(this.OTGWFormsPlotFloats, "Modulation", Color.Pink),
                ["OutsideTemp"] = new Line(this.OTGWFormsPlotFloats, "OutsideTemp", Color.DeepPink),
                ["ReturnTemp"] = new Line(this.OTGWFormsPlotFloats, "ReturnTemp", Color.DarkRed),
                ["Burner"] = new Line(this.OTGWFormsPlotFloats, "Burner", 10, Color.OrangeRed, Color.Yellow),
                ["TapWater"] = new Line(this.OTGWFormsPlotFloats, "TapWater", 40, Color.DarkGreen, Color.LightGreen),
                ["Heating"] = new Line(this.OTGWFormsPlotFloats, "Heating", 70, Color.DarkMagenta, Color.LightPink),
            };

            this.OTGWFormsPlotFloats.Plot.SetAxisLimits(yMin: 0, yMax: 100);
            this.OTGWFormsPlotFloats.Configuration.LockVerticalAxis = true;
            this.OTGWFormsPlotFloats.Configuration.DoubleClickBenchmark = false;
            this.OTGWFormsPlotFloats.Plot.XAxis.DateTimeFormat(true);
            this.legend = this.OTGWFormsPlotFloats.Plot.Legend();
            this.legend.Orientation = ScottPlot.Orientation.Vertical;
            this.legend.Location = ScottPlot.Alignment.UpperLeft;
            this.legend.FontSize = 9;
            this.OTGWFormsPlotFloats.Refresh();
        }

        private void OTGWButtonConnect_Click(object sender, EventArgs e)
        {
            this.otgw.Connect(this.OTGWTextboxHostname.Text);

            // Reset the x-axis of the plot to now.
            foreach (KeyValuePair<string, Line> entry in lines)
            {
                entry.Value.FillXAxisNow();
            }
        }

        private void OTGWButtonDisconnect_Click(object sender, EventArgs e)
        {
            this.otgw.Disconnect();
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
                this.OTGWListboxLog.SelectedIndex = this.OTGWListboxLog.Items.Count-1;
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
                    this.control.Text = this.daysOfWeek[value >> 13] + " " + ((value >> 8)&0x1F).ToString() + ":" + (((value & 0xFF)<10)?"0":"") + (value & 0xFF).ToString();
                }
            }
        }

        private class ListenerDate : ListernerBase
        {
            private string[] months = { "", "January", "February", "March", "April", "May","June", "July", "August", "September", "October", "November", "December" };

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


        private Dictionary<string,Line> lines;
        private ScottPlot.Renderable.Legend legend;
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

                    if (xCount>xLim)
                    {
                        xLim *= 3;
                        if (xLim>xSize)
                        {
                            xLim = xSize;
                        }
                        this.plot.Plot.SetAxisLimits(xMin: xData[0], xMax: xData[xLim-1]);
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
                            xData[xSize-skip+i] = (xValueDateTime + TimeSpan.FromSeconds(OTGW.statusReportInterval * i)).ToOADate();
                        }
                        this.plot.Plot.SetAxisLimits(xMin: xData[0], xMax: xData[xSize - 1]);
                    }
                    this.line.MaxRenderIndex = xCount - 1;
                }
            }
        }
        private void OTGWPlotter(OTGW.StatusReport status)
        {
            double dateTime = status.dateTime.ToOADate();

            lines["BoilerTemp"].AddPoint(dateTime, status.boilerWaterTemperature.value);
            lines["RoomSetpoint"].AddPoint(dateTime, status.roomSetPoint.value);
            lines["Setpoint"].AddPoint(dateTime, status.controlSetPoint.value);
            lines["SetpointMod"].AddPoint(dateTime, status.controlSetPointModified.value);
            lines["Modulation"].AddPoint(dateTime, status.relativeModulationLevel.value);
            lines["OutsideTemp"].AddPoint(dateTime, status.outsideTemperature.value);
            lines["ReturnTemp"].AddPoint(dateTime, status.returnWaterTemperature.value);
            lines["Burner"].AddPoint(dateTime, Convert.ToDouble(status.flameStatus.value));
            lines["TapWater"].AddPoint(dateTime, Convert.ToDouble(status.tapWaterMode.value));
            lines["Heating"].AddPoint(dateTime, Convert.ToDouble(status.centralHeatingMode.value));

            this.OTGWFormsPlotFloats.Invoke((Action)delegate { this.OTGWFormsPlotFloats.Refresh(); });
        }
    }
}


