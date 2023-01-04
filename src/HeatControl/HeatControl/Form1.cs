using System;
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
                new OTGWListener<string>(this.OTGWLabelVersion, this.otgw.gatewayConfiguration.version),
                new OTGWListener<string>(this.OTGWLabelBuild, this.otgw.gatewayConfiguration.build),
                new OTGWListener<float>(this.OTGWTextBoxRoomTemp, this.otgw.gatewayStatus.roomTemperature),
                new OTGWListener<float>(this.OTGWTextBoxBoilerTemp, this.otgw.gatewayStatus.boilerWaterTemperature),
                new OTGWListener<bool>(this.OTGWTextBoxFlameStatus, this.otgw.gatewayStatus.flameStatus),
                new OTGWListener<bool>(this.OTGWTextBoxCentralHeatingMode, this.otgw.gatewayStatus.centralHeatingMode),
                new OTGWListener<bool>(this.OTGWTextBoxTapWaterMode, this.otgw.gatewayStatus.tapWaterMode),
                new OTGWListener<bool>(this.OTGWTextBoxFaultIndication, this.otgw.gatewayStatus.faultIndication),
                new OTGWListener<float>(this.OTGWTextBoxControlSetpoint, this.otgw.gatewayStatus.controlSetPoint),
                new OTGWListener<float>(this.OTGWTextBoxControlSetpointModified, this.otgw.gatewayStatus.controlSetPointModified),
                new OTGWListener<float>(this.OTGWTextBoxRoomSetpoint, this.otgw.gatewayStatus.roomSetPoint),
                new OTGWListener<float>(this.OTGWTextBoxWaterPressure, this.otgw.gatewayStatus.waterPressureCHCircuit),
                new OTGWListener<float>(this.OTGWTextBoxTapWaterFlow, this.otgw.gatewayStatus.waterFlowRateTap),
                new OTGWListener<float>(this.OTGWTextBoxTapWaterTemperature, this.otgw.gatewayStatus.tapWaterTemperature),
                new OTGWListener<float>(this.OTGWTextBoxReturnTemperature, this.otgw.gatewayStatus.returnWaterTemperature),
                new OTGWListener<float>(this.OTGWTextBoxOutsideTemperature, this.otgw.gatewayStatus.outsideTemperature),


                new OTGWListener<string>(this.OTGWTextBoxDiagVersion, this.otgw.gatewayConfiguration.version),
                new OTGWListener<string>(this.OTGWTextBoxDiagBuild, this.otgw.gatewayConfiguration.build),
                new OTGWListener<string>(this.OTGWTextBoxDiagClockSpeed, this.otgw.gatewayConfiguration.clockSpeed),
                new OTGWListener<string>(this.OTGWTextBoxDiagTemperatureSensorFunction, this.otgw.gatewayConfiguration.temperaturSensorFunction),
                new OTGWListener<string>(this.OTGWTextBoxDiagGPIOFunctions, this.otgw.gatewayConfiguration.gpioFunctionsConfiguration),
                new OTGWListener<string>(this.OTGWTextBoxDiagGPIOState, this.otgw.gatewayConfiguration.gpioState),
                new OTGWListener<string>(this.OTGWTextBoxDiagLedFunctions, this.otgw.gatewayConfiguration.ledFunctionsConfiguration),
                new OTGWListener<string>(this.OTGWTextBoxDiagGatewayMode, this.otgw.gatewayConfiguration.gatewayMode),
                new OTGWListener<string>(this.OTGWTextBoxDiagSetpointOverride, this.otgw.gatewayConfiguration.setpointOverride),
                new OTGWListener<string>(this.OTGWTextBoxDiagSmartPowerMode, this.otgw.gatewayConfiguration.smartPowerModel),
                new OTGWListener<string>(this.OTGWTextBoxDiagCauseOfLastReset, this.otgw.gatewayConfiguration.causeOfLastReset),
                new OTGWListener<string>(this.OTGWTextBoxDiagRemehaDetectionState, this.otgw.gatewayConfiguration.remehaDetectionState),
                new OTGWListener<string>(this.OTGWTextBoxDiagSetbackTemperature, this.otgw.gatewayConfiguration.setbackTemperatureConfiguarion),
                new OTGWListener<string>(this.OTGWTextBoxDiagTweaks, this.otgw.gatewayConfiguration.tweaks),
                new OTGWListener<string>(this.OTGWTextBoxDiagReferenceVoltage, this.otgw.gatewayConfiguration.referenceVoltage),
                new OTGWListener<string>(this.OTGWTextBoxDiagHotWater, this.otgw.gatewayConfiguration.hotWater),

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

        private class OTGWListener<T> : ListernerBase
        {
            public OTGWListener(Control control, OTGW.VarValueName<T> property) : base(control)
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
    }
}


