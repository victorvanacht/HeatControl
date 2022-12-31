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
            otgw.AddLogger(OTGWLogger);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.otgw.Connect("192.168.50.150");
        }

        private void button2_Click(object sender, EventArgs e)
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
            string line = text + "\n\r\n\r";

            if (this.OTGWTextboxLog.InvokeRequired)
            {
                this.OTGWTextboxLog.Invoke((Action)delegate { this.OTGWTextboxLog.Text += line; });
            }
            else
            {
                this.OTGWTextboxLog.Text += line;
            }
        }
    }
}
