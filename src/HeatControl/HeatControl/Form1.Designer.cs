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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.OTGWTextBoxRoomTemp = new System.Windows.Forms.TextBox();
            this.OTGWLabelRoomTemp = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.OTGWListboxLog = new System.Windows.Forms.ListBox();
            this.OTGWLabelHostname = new System.Windows.Forms.Label();
            this.OTGWTextboxHostname = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.OTGWLabelBoilerTemp = new System.Windows.Forms.Label();
            this.OTGWTextBoxBoilerTemp = new System.Windows.Forms.TextBox();
            this.OTGWGroupbox.SuspendLayout();
            this.OTGWTabcontrol.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
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
            this.OTGWGroupbox.Enter += new System.EventHandler(this.groupBox1_Enter);
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
            this.tabPage1.Controls.Add(this.OTGWTextBoxBoilerTemp);
            this.tabPage1.Controls.Add(this.OTGWLabelBoilerTemp);
            this.tabPage1.Controls.Add(this.OTGWTextBoxRoomTemp);
            this.tabPage1.Controls.Add(this.OTGWLabelRoomTemp);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(687, 373);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Status Overview";
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // OTGWTextBoxRoomTemp
            // 
            this.OTGWTextBoxRoomTemp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OTGWTextBoxRoomTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OTGWTextBoxRoomTemp.Location = new System.Drawing.Point(173, 32);
            this.OTGWTextBoxRoomTemp.Name = "OTGWTextBoxRoomTemp";
            this.OTGWTextBoxRoomTemp.Size = new System.Drawing.Size(100, 26);
            this.OTGWTextBoxRoomTemp.TabIndex = 1;
            // 
            // OTGWLabelRoomTemp
            // 
            this.OTGWLabelRoomTemp.AutoSize = true;
            this.OTGWLabelRoomTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OTGWLabelRoomTemp.Location = new System.Drawing.Point(6, 34);
            this.OTGWLabelRoomTemp.Name = "OTGWLabelRoomTemp";
            this.OTGWLabelRoomTemp.Size = new System.Drawing.Size(143, 20);
            this.OTGWLabelRoomTemp.TabIndex = 0;
            this.OTGWLabelRoomTemp.Text = "Room temperature";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.OTGWListboxLog);
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
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(15, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(457, 505);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "EQ-3 Max!";
            // 
            // OTGWLabelBoilerTemp
            // 
            this.OTGWLabelBoilerTemp.AutoSize = true;
            this.OTGWLabelBoilerTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OTGWLabelBoilerTemp.Location = new System.Drawing.Point(9, 73);
            this.OTGWLabelBoilerTemp.Name = "OTGWLabelBoilerTemp";
            this.OTGWLabelBoilerTemp.Size = new System.Drawing.Size(140, 20);
            this.OTGWLabelBoilerTemp.TabIndex = 2;
            this.OTGWLabelBoilerTemp.Text = "Boiler temperature";
            // 
            // OTGWTextBoxBoilerTemp
            // 
            this.OTGWTextBoxBoilerTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OTGWTextBoxBoilerTemp.Location = new System.Drawing.Point(173, 70);
            this.OTGWTextBoxBoilerTemp.Name = "OTGWTextBoxBoilerTemp";
            this.OTGWTextBoxBoilerTemp.Size = new System.Drawing.Size(100, 26);
            this.OTGWTextBoxBoilerTemp.TabIndex = 3;
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
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
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
        private System.Windows.Forms.ListBox OTGWListboxLog;
        private System.Windows.Forms.TextBox OTGWTextBoxRoomTemp;
        private System.Windows.Forms.Label OTGWLabelRoomTemp;
        private System.Windows.Forms.TextBox OTGWTextBoxBoilerTemp;
        private System.Windows.Forms.Label OTGWLabelBoilerTemp;
    }
}

