namespace _20200614_UpWork_SerialPort_BitWise
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rbString = new System.Windows.Forms.RadioButton();
            this.rbHex = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bFind = new System.Windows.Forms.Button();
            this.cbVerify = new System.Windows.Forms.ComboBox();
            this.cbStopBits = new System.Windows.Forms.ComboBox();
            this.bPortOpen = new System.Windows.Forms.Button();
            this.cb_Bits = new System.Windows.Forms.ComboBox();
            this.cbPortRate = new System.Windows.Forms.ComboBox();
            this.cbPortNumber = new System.Windows.Forms.ComboBox();
            this.tbReceive = new System.Windows.Forms.TextBox();
            this.bPortSend = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.rbRecString = new System.Windows.Forms.RadioButton();
            this.bClear = new System.Windows.Forms.Button();
            this.rbRecHex = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.bCMD1 = new System.Windows.Forms.Button();
            this.bCMD2 = new System.Windows.Forms.Button();
            this.bCMD3 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tbSend = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bSearchDevice = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(34, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Port No.:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(16, 320);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Verification:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(34, 256);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Stop Bits:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(34, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Data Bits:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(34, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Baud Rate:";
            // 
            // rbString
            // 
            this.rbString.AutoSize = true;
            this.rbString.Location = new System.Drawing.Point(46, 63);
            this.rbString.Name = "rbString";
            this.rbString.Size = new System.Drawing.Size(52, 17);
            this.rbString.TabIndex = 6;
            this.rbString.Text = "String";
            this.rbString.UseVisualStyleBackColor = true;
            this.rbString.CheckedChanged += new System.EventHandler(this.rbString_CheckedChanged);
            // 
            // rbHex
            // 
            this.rbHex.AutoSize = true;
            this.rbHex.Checked = true;
            this.rbHex.Location = new System.Drawing.Point(46, 96);
            this.rbHex.Name = "rbHex";
            this.rbHex.Size = new System.Drawing.Size(44, 17);
            this.rbHex.TabIndex = 7;
            this.rbHex.TabStop = true;
            this.rbHex.Text = "Hex";
            this.rbHex.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bSearchDevice);
            this.groupBox1.Controls.Add(this.bFind);
            this.groupBox1.Controls.Add(this.cbVerify);
            this.groupBox1.Controls.Add(this.cbStopBits);
            this.groupBox1.Controls.Add(this.bPortOpen);
            this.groupBox1.Controls.Add(this.cb_Bits);
            this.groupBox1.Controls.Add(this.cbPortRate);
            this.groupBox1.Controls.Add(this.cbPortNumber);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(293, 567);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Serial Config";
            // 
            // bFind
            // 
            this.bFind.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bFind.Location = new System.Drawing.Point(12, 370);
            this.bFind.Name = "bFind";
            this.bFind.Size = new System.Drawing.Size(116, 34);
            this.bFind.TabIndex = 15;
            this.bFind.Text = "Search Ports";
            this.bFind.UseVisualStyleBackColor = true;
            this.bFind.Click += new System.EventHandler(this.bFind_Click);
            // 
            // cbVerify
            // 
            this.cbVerify.FormattingEnabled = true;
            this.cbVerify.Location = new System.Drawing.Point(134, 316);
            this.cbVerify.Name = "cbVerify";
            this.cbVerify.Size = new System.Drawing.Size(121, 24);
            this.cbVerify.TabIndex = 14;
            this.cbVerify.Tag = "Parity";
            this.cbVerify.SelectedIndexChanged += new System.EventHandler(this.cbPortNumber_SelectedIndexChanged_CommonEvent);
            // 
            // cbStopBits
            // 
            this.cbStopBits.FormattingEnabled = true;
            this.cbStopBits.Location = new System.Drawing.Point(134, 251);
            this.cbStopBits.Name = "cbStopBits";
            this.cbStopBits.Size = new System.Drawing.Size(121, 24);
            this.cbStopBits.TabIndex = 13;
            this.cbStopBits.Tag = "StopBits";
            this.cbStopBits.SelectedIndexChanged += new System.EventHandler(this.cbPortNumber_SelectedIndexChanged_CommonEvent);
            // 
            // bPortOpen
            // 
            this.bPortOpen.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bPortOpen.Location = new System.Drawing.Point(157, 370);
            this.bPortOpen.Name = "bPortOpen";
            this.bPortOpen.Size = new System.Drawing.Size(98, 34);
            this.bPortOpen.TabIndex = 10;
            this.bPortOpen.Text = "Open Port";
            this.bPortOpen.UseVisualStyleBackColor = true;
            this.bPortOpen.Click += new System.EventHandler(this.bPortOpen_Click);
            // 
            // cb_Bits
            // 
            this.cb_Bits.FormattingEnabled = true;
            this.cb_Bits.Location = new System.Drawing.Point(134, 191);
            this.cb_Bits.Name = "cb_Bits";
            this.cb_Bits.Size = new System.Drawing.Size(121, 24);
            this.cb_Bits.TabIndex = 12;
            this.cb_Bits.Tag = "DataBits";
            this.cb_Bits.SelectedIndexChanged += new System.EventHandler(this.cbPortNumber_SelectedIndexChanged_CommonEvent);
            // 
            // cbPortRate
            // 
            this.cbPortRate.FormattingEnabled = true;
            this.cbPortRate.Items.AddRange(new object[] {
            "2400",
            "4800",
            "9600",
            "19200"});
            this.cbPortRate.Location = new System.Drawing.Point(134, 127);
            this.cbPortRate.Name = "cbPortRate";
            this.cbPortRate.Size = new System.Drawing.Size(121, 24);
            this.cbPortRate.TabIndex = 11;
            this.cbPortRate.Tag = "BaudRate";
            this.cbPortRate.SelectedIndexChanged += new System.EventHandler(this.cbPortNumber_SelectedIndexChanged_CommonEvent);
            // 
            // cbPortNumber
            // 
            this.cbPortNumber.FormattingEnabled = true;
            this.cbPortNumber.Location = new System.Drawing.Point(134, 64);
            this.cbPortNumber.Name = "cbPortNumber";
            this.cbPortNumber.Size = new System.Drawing.Size(121, 24);
            this.cbPortNumber.TabIndex = 10;
            this.cbPortNumber.Tag = "PortName";
            this.cbPortNumber.SelectedIndexChanged += new System.EventHandler(this.cbPortNumber_SelectedIndexChanged_CommonEvent);
            // 
            // tbReceive
            // 
            this.tbReceive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbReceive.Location = new System.Drawing.Point(3, 3);
            this.tbReceive.Multiline = true;
            this.tbReceive.Name = "tbReceive";
            this.tbReceive.Size = new System.Drawing.Size(436, 250);
            this.tbReceive.TabIndex = 11;
            this.tbReceive.Tag = "";
            // 
            // bPortSend
            // 
            this.bPortSend.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bPortSend.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bPortSend.Location = new System.Drawing.Point(473, 205);
            this.bPortSend.Name = "bPortSend";
            this.bPortSend.Size = new System.Drawing.Size(98, 34);
            this.bPortSend.TabIndex = 12;
            this.bPortSend.Text = "Send";
            this.bPortSend.UseVisualStyleBackColor = true;
            this.bPortSend.Click += new System.EventHandler(this.bPortSend_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(608, 275);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Receiving";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel2.Controls.Add(this.panel6, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tbReceive, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(602, 256);
            this.tableLayoutPanel2.TabIndex = 20;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.rbRecString);
            this.panel6.Controls.Add(this.bClear);
            this.panel6.Controls.Add(this.rbRecHex);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(445, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(154, 250);
            this.panel6.TabIndex = 21;
            // 
            // rbRecString
            // 
            this.rbRecString.AutoSize = true;
            this.rbRecString.Location = new System.Drawing.Point(46, 69);
            this.rbRecString.Name = "rbRecString";
            this.rbRecString.Size = new System.Drawing.Size(52, 17);
            this.rbRecString.TabIndex = 17;
            this.rbRecString.Text = "String";
            this.rbRecString.UseVisualStyleBackColor = true;
            this.rbRecString.CheckedChanged += new System.EventHandler(this.rbRecString_CheckedChanged);
            // 
            // bClear
            // 
            this.bClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bClear.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bClear.Location = new System.Drawing.Point(30, 200);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(98, 34);
            this.bClear.TabIndex = 19;
            this.bClear.Text = "Clear";
            this.bClear.UseVisualStyleBackColor = true;
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
            // 
            // rbRecHex
            // 
            this.rbRecHex.AutoSize = true;
            this.rbRecHex.Checked = true;
            this.rbRecHex.Location = new System.Drawing.Point(46, 109);
            this.rbRecHex.Name = "rbRecHex";
            this.rbRecHex.Size = new System.Drawing.Size(44, 17);
            this.rbRecHex.TabIndex = 18;
            this.rbRecHex.TabStop = true;
            this.rbRecHex.Text = "Hex";
            this.rbRecHex.UseVisualStyleBackColor = true;
            this.rbRecHex.CheckedChanged += new System.EventHandler(this.rbRecHex_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(608, 292);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sending";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel1.Controls.Add(this.bPortSend, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbSend, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 63.15789F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36.84211F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(602, 273);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.bCMD1);
            this.panel5.Controls.Add(this.bCMD2);
            this.panel5.Controls.Add(this.bCMD3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 175);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(436, 95);
            this.panel5.TabIndex = 17;
            // 
            // bCMD1
            // 
            this.bCMD1.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bCMD1.Location = new System.Drawing.Point(19, 32);
            this.bCMD1.Name = "bCMD1";
            this.bCMD1.Size = new System.Drawing.Size(98, 34);
            this.bCMD1.TabIndex = 13;
            this.bCMD1.Text = "CMD.01";
            this.bCMD1.UseVisualStyleBackColor = true;
            this.bCMD1.Click += new System.EventHandler(this.bCMD1_Click);
            // 
            // bCMD2
            // 
            this.bCMD2.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bCMD2.Location = new System.Drawing.Point(141, 32);
            this.bCMD2.Name = "bCMD2";
            this.bCMD2.Size = new System.Drawing.Size(98, 34);
            this.bCMD2.TabIndex = 14;
            this.bCMD2.Text = "CMD.02";
            this.bCMD2.UseVisualStyleBackColor = true;
            this.bCMD2.Click += new System.EventHandler(this.bCMD2_Click);
            // 
            // bCMD3
            // 
            this.bCMD3.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bCMD3.Location = new System.Drawing.Point(257, 32);
            this.bCMD3.Name = "bCMD3";
            this.bCMD3.Size = new System.Drawing.Size(98, 34);
            this.bCMD3.TabIndex = 15;
            this.bCMD3.Text = "CMD.03";
            this.bCMD3.UseVisualStyleBackColor = true;
            this.bCMD3.Click += new System.EventHandler(this.bCMD3_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.rbString);
            this.panel4.Controls.Add(this.rbHex);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(445, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(154, 166);
            this.panel4.TabIndex = 17;
            // 
            // tbSend
            // 
            this.tbSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSend.Location = new System.Drawing.Point(3, 3);
            this.tbSend.Multiline = true;
            this.tbSend.Name = "tbSend";
            this.tbSend.Size = new System.Drawing.Size(436, 166);
            this.tbSend.TabIndex = 11;
            this.tbSend.Tag = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(293, 567);
            this.panel1.TabIndex = 17;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(293, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(608, 292);
            this.panel2.TabIndex = 18;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(293, 292);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(608, 275);
            this.panel3.TabIndex = 19;
            // 
            // bSearchDevice
            // 
            this.bSearchDevice.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bSearchDevice.Location = new System.Drawing.Point(12, 420);
            this.bSearchDevice.Name = "bSearchDevice";
            this.bSearchDevice.Size = new System.Drawing.Size(116, 34);
            this.bSearchDevice.TabIndex = 16;
            this.bSearchDevice.Text = "Search Device";
            this.bSearchDevice.UseVisualStyleBackColor = true;
            this.bSearchDevice.Click += new System.EventHandler(this.bSearchDevice_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 567);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Serial Com";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbString;
        private System.Windows.Forms.RadioButton rbHex;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbVerify;
        private System.Windows.Forms.ComboBox cbStopBits;
        private System.Windows.Forms.ComboBox cb_Bits;
        private System.Windows.Forms.ComboBox cbPortRate;
        private System.Windows.Forms.ComboBox cbPortNumber;
        private System.Windows.Forms.Button bPortOpen;
        private System.Windows.Forms.TextBox tbReceive;
        private System.Windows.Forms.Button bPortSend;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbSend;
        private System.Windows.Forms.RadioButton rbRecString;
        private System.Windows.Forms.RadioButton rbRecHex;
        private System.Windows.Forms.Button bCMD3;
        private System.Windows.Forms.Button bCMD2;
        private System.Windows.Forms.Button bCMD1;
        private System.Windows.Forms.Button bClear;
        private System.Windows.Forms.Button bFind;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button bSearchDevice;
    }
}

