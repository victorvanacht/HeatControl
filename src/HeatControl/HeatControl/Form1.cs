﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            };

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
                    this.control.Text = this.daysOfWeek[value >> 13] + " " + ((value >> 8)&0x1F).ToString() + ":" + (value & 0xFF).ToString();
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





    }
}


