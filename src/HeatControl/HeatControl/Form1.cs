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

            for (int i=0; i<plotXaxisData.Length; i++)
            {
                plotXaxisData[i] = (DateTime.Now + TimeSpan.FromSeconds(OTGW.statusReportInterval * i)).ToOADate();
            }
            this.OTGWFormsPlotFloats.Plot.SetAxisLimits(yMin: 0, yMax: 100);
            this.OTGWFormsPlotFloats.Plot.SetAxisLimits(xMin: plotXaxisData[0], xMax: plotXaxisData[plotXaxisData.Length-1]);
            this.OTGWFormsPlotFloats.Plot.Legend();

            this.plot1 = this.OTGWFormsPlotFloats.Plot.AddSignalXY(plotXaxisData, plotBoilerTemperatureData, label: "BoilerTemp");
            this.plot1.MarkerSize = 0;

            this.plot2 = this.OTGWFormsPlotFloats.Plot.AddSignalXY(plotXaxisData, plotFlameStatusData, label: "Burner");
            this.plot2.FillAboveAndBelow(Color.Aqua, Color.Azure);
            this.plot2.BaselineY = 20;
            this.plot2.OffsetY = 22;
            this.plot2.MarkerSize = 0;

            this.plot3 = this.OTGWFormsPlotFloats.Plot.AddSignalXY(plotXaxisData, plotTapWaterModeData, label: "TapWater");
            this.plot3.FillAboveAndBelow(Color.Aqua, Color.Azure);
            this.plot3.BaselineY = 40;
            this.plot3.OffsetY = 42;
            this.plot3.MarkerSize = 0;

            this.plot4 = this.OTGWFormsPlotFloats.Plot.AddSignalXY(plotXaxisData, plotCentralHeatingModeData, label: "Heating");
            this.plot4.FillAboveAndBelow(Color.Aqua, Color.Azure);
            this.plot4.BaselineY = 60;
            this.plot4.OffsetY = 62;
            this.plot4.MarkerSize = 0;


            this.OTGWFormsPlotFloats.Plot.XAxis.DateTimeFormat(true);
            this.OTGWFormsPlotFloats.Refresh();




        }

        private void OTGWButtonConnect_Click(object sender, EventArgs e)
        {
            this.otgw.Connect(this.OTGWTextboxHostname.Text);
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




        private const int plotXDataLen = 100;
        private double[] plotXaxisData = new double[plotXDataLen];
        private double[] plotBoilerTemperatureData = new double[plotXDataLen];
        
        private double[] plotCentralHeatingModeData = new double[plotXDataLen];
        private double[] plotTapWaterModeData = new double[plotXDataLen];
        private double[] plotFlameStatusData = new double[plotXDataLen];
        private int plotXCount = 0;

        ScottPlot.Plottable.SignalPlotXY plot1;
        ScottPlot.Plottable.SignalPlotXY plot2;
        ScottPlot.Plottable.SignalPlotXY plot3;
        ScottPlot.Plottable.SignalPlotXY plot4;



        private void OTGWPlotter(OTGW.StatusReport status)
        {
            plotXaxisData[plotXCount] = status.dateTime.ToOADate();
            plotBoilerTemperatureData[plotXCount] = status.boilerWaterTemperature.value;
            plotFlameStatusData[plotXCount] = Convert.ToDouble(status.flameStatus.value) * 10;
            plotCentralHeatingModeData[plotXCount] = Convert.ToDouble(status.centralHeatingMode.value) * 10;
            plotTapWaterModeData[plotXCount] = Convert.ToDouble(status.tapWaterMode.value) * 10;

            plotXCount++;



            if (plotXCount == plotXDataLen)
            {
                int skip = plotXDataLen / 10;
                Array.Copy(plotXaxisData, skip, plotXaxisData, 0, plotXDataLen - skip);
                Array.Copy(plotBoilerTemperatureData, skip, plotBoilerTemperatureData, 0, plotXDataLen - skip);
                Array.Copy(plotFlameStatusData, skip, plotFlameStatusData, 0, plotXDataLen - skip);
                Array.Copy(plotCentralHeatingModeData, skip, plotCentralHeatingModeData, 0, plotXDataLen - skip);
                Array.Copy(plotTapWaterModeData, skip, plotTapWaterModeData, 0, plotXDataLen - skip);

                plotXCount -= skip;
                this.OTGWFormsPlotFloats.Plot.SetAxisLimits(xMin: plotXaxisData[0], xMax: plotXaxisData[plotXaxisData.Length - 1]);
            }
            this.plot1.MaxRenderIndex = plotXCount - 1;
            this.plot2.MaxRenderIndex = plotXCount - 1;
            this.plot3.MaxRenderIndex = plotXCount - 1;
            this.plot4.MaxRenderIndex = plotXCount - 1;



            this.OTGWFormsPlotFloats.Invoke((Action)delegate { this.OTGWFormsPlotFloats.Refresh(); });
        }
    }
}

