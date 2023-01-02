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
            this.otgw.gatewayStatus.roomTemperature.AddListener(OTGWListenerRoomTemperature);
            this.otgw.gatewayStatus.boilerWaterTemperature.AddListener(OTGWListenerBoilerWaterTemperature);


        }

        private void OTGWButtonConnect_Click(object sender, EventArgs e)
        {
            this.otgw.Connect(this.OTGWTextboxHostname.Text);
        }

        private void OTGWButtonDisconnect_Click(object sender, EventArgs e)
        {
            this.otgw.Disconnect();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

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
                if (this.OTGWListboxLog.Items.Count > 100) OTGWListboxLog.Items.RemoveAt(0);
            }
        }


        private void OTGWListenerRoomTemperature(float value)
        {
            if (this.OTGWTextBoxRoomTemp.InvokeRequired)
            {
                this.OTGWTextBoxRoomTemp.Invoke((Action)delegate { OTGWListenerRoomTemperature(value); });
            }
            else
            {
                this.OTGWTextBoxRoomTemp.Text = value.ToString();
            }
        }


        private void OTGWListenerBoilerWaterTemperature(float value)
        {
            if (this.OTGWTextBoxBoilerTemp.InvokeRequired)
            {
                this.OTGWTextBoxBoilerTemp.Invoke((Action)delegate { OTGWListenerBoilerWaterTemperature(value); });
            }
            else
            {
                this.OTGWTextBoxBoilerTemp.Text = value.ToString();
            }
        }



    }
}
