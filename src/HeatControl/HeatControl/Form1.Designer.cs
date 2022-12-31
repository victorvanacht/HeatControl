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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.OTGWTabcontrol = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.OTGWTextboxHostname = new System.Windows.Forms.TextBox();
            this.OTGWLabelHostname = new System.Windows.Forms.Label();
            this.OTGWTextboxLog = new System.Windows.Forms.TextBox();
            this.OTGWGroupbox.SuspendLayout();
            this.OTGWTabcontrol.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // OTGWButtonConnect
            // 
            this.OTGWButtonConnect.Location = new System.Drawing.Point(19, 64);
            this.OTGWButtonConnect.Name = "OTGWButtonConnect";
            this.OTGWButtonConnect.Size = new System.Drawing.Size(140, 34);
            this.OTGWButtonConnect.TabIndex = 0;
            this.OTGWButtonConnect.Text = "Connect";
            this.OTGWButtonConnect.UseVisualStyleBackColor = true;
            this.OTGWButtonConnect.Click += new System.EventHandler(this.button1_Click);
            // 
            // OTGWButtonDisconnect
            // 
            this.OTGWButtonDisconnect.Location = new System.Drawing.Point(177, 64);
            this.OTGWButtonDisconnect.Name = "OTGWButtonDisconnect";
            this.OTGWButtonDisconnect.Size = new System.Drawing.Size(140, 31);
            this.OTGWButtonDisconnect.TabIndex = 1;
            this.OTGWButtonDisconnect.Text = "Disconnect";
            this.OTGWButtonDisconnect.UseVisualStyleBackColor = true;
            this.OTGWButtonDisconnect.Click += new System.EventHandler(this.button2_Click);
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
            this.OTGWGroupbox.Enter += new System.EventHandler(this.groupBox1_Enter);
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
            // OTGWTabcontrol
            // 
            this.OTGWTabcontrol.Controls.Add(this.tabPage1);
            this.OTGWTabcontrol.Controls.Add(this.tabPage2);
            this.OTGWTabcontrol.Location = new System.Drawing.Point(16, 107);
            this.OTGWTabcontrol.Name = "OTGWTabcontrol";
            this.OTGWTabcontrol.SelectedIndex = 0;
            this.OTGWTabcontrol.Size = new System.Drawing.Size(695, 399);
            this.OTGWTabcontrol.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(687, 373);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Status Overview";
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.OTGWTextboxLog);
            this.tabPage2.Controls.Add(this.OTGWLabelHostname);
            this.tabPage2.Controls.Add(this.OTGWTextboxHostname);
            this.tabPage2.Controls.Add(this.OTGWButtonConnect);
            this.tabPage2.Controls.Add(this.OTGWButtonDisconnect);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(687, 373);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Connection";
            // 
            // OTGWTextboxHostname
            // 
            this.OTGWTextboxHostname.Location = new System.Drawing.Point(147, 23);
            this.OTGWTextboxHostname.Name = "OTGWTextboxHostname";
            this.OTGWTextboxHostname.Size = new System.Drawing.Size(170, 20);
            this.OTGWTextboxHostname.TabIndex = 2;
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
            // OTGWTextboxLog
            // 
            this.OTGWTextboxLog.Location = new System.Drawing.Point(19, 136);
            this.OTGWTextboxLog.Multiline = true;
            this.OTGWTextboxLog.Name = "OTGWTextboxLog";
            this.OTGWTextboxLog.ReadOnly = true;
            this.OTGWTextboxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.OTGWTextboxLog.Size = new System.Drawing.Size(298, 231);
            this.OTGWTextboxLog.TabIndex = 4;
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
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OTGWButtonConnect;
        private System.Windows.Forms.Button OTGWButtonDisconnect;
        private System.Windows.Forms.GroupBox OTGWGroupbox;
        private System.Windows.Forms.TabControl OTGWTabcontrol;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label OTGWLabelHostname;
        private System.Windows.Forms.TextBox OTGWTextboxHostname;
        private System.Windows.Forms.TextBox OTGWTextboxLog;
    }
}

