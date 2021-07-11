namespace _20190816_Class01_SerialPort
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
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbVerify = new System.Windows.Forms.ComboBox();
            this.cbStopBits = new System.Windows.Forms.ComboBox();
            this.cb_Bits = new System.Windows.Forms.ComboBox();
            this.cbPortRate = new System.Windows.Forms.ComboBox();
            this.cbPortNumber = new System.Windows.Forms.ComboBox();
            this.bPortOpen = new System.Windows.Forms.Button();
            this.tbReceive = new System.Windows.Forms.TextBox();
            this.bPortSend = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbSend = new System.Windows.Forms.TextBox();
            this.rbRecString = new System.Windows.Forms.RadioButton();
            this.rbRecHex = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(34, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "串口号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(34, 295);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "校验位";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(34, 236);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "停止位";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(34, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "数据位";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(34, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "波特率";
            // 
            // rbString
            // 
            this.rbString.AutoSize = true;
            this.rbString.Checked = true;
            this.rbString.Location = new System.Drawing.Point(441, 90);
            this.rbString.Name = "rbString";
            this.rbString.Size = new System.Drawing.Size(59, 16);
            this.rbString.TabIndex = 6;
            this.rbString.TabStop = true;
            this.rbString.Text = "字符串";
            this.rbString.UseVisualStyleBackColor = true;
            // 
            // rbHex
            // 
            this.rbHex.AutoSize = true;
            this.rbHex.Location = new System.Drawing.Point(441, 118);
            this.rbHex.Name = "rbHex";
            this.rbHex.Size = new System.Drawing.Size(59, 16);
            this.rbHex.TabIndex = 7;
            this.rbHex.TabStop = true;
            this.rbHex.Text = "16进制";
            this.rbHex.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(142, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 19);
            this.label6.TabIndex = 8;
            this.label6.Text = "串口配置";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbVerify);
            this.groupBox1.Controls.Add(this.cbStopBits);
            this.groupBox1.Controls.Add(this.cb_Bits);
            this.groupBox1.Controls.Add(this.cbPortRate);
            this.groupBox1.Controls.Add(this.cbPortNumber);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(40, 132);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 369);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "串口配置";
            // 
            // cbVerify
            // 
            this.cbVerify.FormattingEnabled = true;
            this.cbVerify.Location = new System.Drawing.Point(134, 292);
            this.cbVerify.Name = "cbVerify";
            this.cbVerify.Size = new System.Drawing.Size(121, 24);
            this.cbVerify.TabIndex = 14;
            this.cbVerify.Tag = "Parity";
            this.cbVerify.SelectedIndexChanged += new System.EventHandler(this.cbPortNumber_SelectedIndexChanged_CommonEvent);
            // 
            // cbStopBits
            // 
            this.cbStopBits.FormattingEnabled = true;
            this.cbStopBits.Items.AddRange(new object[] {
            "None",
            "1",
            "1.5",
            "2"});
            this.cbStopBits.Location = new System.Drawing.Point(134, 232);
            this.cbStopBits.Name = "cbStopBits";
            this.cbStopBits.Size = new System.Drawing.Size(121, 24);
            this.cbStopBits.TabIndex = 13;
            this.cbStopBits.Tag = "StopBits";
            this.cbStopBits.SelectedIndexChanged += new System.EventHandler(this.cbPortNumber_SelectedIndexChanged_CommonEvent);
            // 
            // cb_Bits
            // 
            this.cb_Bits.FormattingEnabled = true;
            this.cb_Bits.Location = new System.Drawing.Point(134, 176);
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
            this.cbPortRate.Location = new System.Drawing.Point(134, 117);
            this.cbPortRate.Name = "cbPortRate";
            this.cbPortRate.Size = new System.Drawing.Size(121, 24);
            this.cbPortRate.TabIndex = 11;
            this.cbPortRate.Tag = "BaudRate";
            this.cbPortRate.SelectedIndexChanged += new System.EventHandler(this.cbPortNumber_SelectedIndexChanged_CommonEvent);
            // 
            // cbPortNumber
            // 
            this.cbPortNumber.FormattingEnabled = true;
            this.cbPortNumber.Location = new System.Drawing.Point(134, 59);
            this.cbPortNumber.Name = "cbPortNumber";
            this.cbPortNumber.Size = new System.Drawing.Size(121, 24);
            this.cbPortNumber.TabIndex = 10;
            this.cbPortNumber.Tag = "PortName";
            this.cbPortNumber.SelectedIndexChanged += new System.EventHandler(this.cbPortNumber_SelectedIndexChanged_CommonEvent);
            // 
            // bPortOpen
            // 
            this.bPortOpen.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bPortOpen.Location = new System.Drawing.Point(815, 152);
            this.bPortOpen.Name = "bPortOpen";
            this.bPortOpen.Size = new System.Drawing.Size(98, 31);
            this.bPortOpen.TabIndex = 10;
            this.bPortOpen.Text = "打开串口";
            this.bPortOpen.UseVisualStyleBackColor = true;
            this.bPortOpen.Click += new System.EventHandler(this.bPortOpen_Click);
            // 
            // tbReceive
            // 
            this.tbReceive.Location = new System.Drawing.Point(0, 20);
            this.tbReceive.Multiline = true;
            this.tbReceive.Name = "tbReceive";
            this.tbReceive.Size = new System.Drawing.Size(386, 141);
            this.tbReceive.TabIndex = 11;
            this.tbReceive.Tag = "";
            // 
            // bPortSend
            // 
            this.bPortSend.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bPortSend.Location = new System.Drawing.Point(429, 38);
            this.bPortSend.Name = "bPortSend";
            this.bPortSend.Size = new System.Drawing.Size(98, 31);
            this.bPortSend.TabIndex = 12;
            this.bPortSend.Text = "发送";
            this.bPortSend.UseVisualStyleBackColor = true;
            this.bPortSend.Click += new System.EventHandler(this.bPortSend_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbReceive);
            this.groupBox2.Location = new System.Drawing.Point(386, 132);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(409, 177);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "接收区";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbSend);
            this.groupBox3.Controls.Add(this.bPortSend);
            this.groupBox3.Controls.Add(this.rbString);
            this.groupBox3.Controls.Add(this.rbHex);
            this.groupBox3.Location = new System.Drawing.Point(386, 315);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(563, 177);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "发送区";
            // 
            // tbSend
            // 
            this.tbSend.Location = new System.Drawing.Point(6, 20);
            this.tbSend.Multiline = true;
            this.tbSend.Name = "tbSend";
            this.tbSend.Size = new System.Drawing.Size(386, 141);
            this.tbSend.TabIndex = 11;
            this.tbSend.Tag = "";
            // 
            // rbRecString
            // 
            this.rbRecString.AutoSize = true;
            this.rbRecString.Checked = true;
            this.rbRecString.Location = new System.Drawing.Point(815, 216);
            this.rbRecString.Name = "rbRecString";
            this.rbRecString.Size = new System.Drawing.Size(59, 16);
            this.rbRecString.TabIndex = 17;
            this.rbRecString.TabStop = true;
            this.rbRecString.Text = "字符串";
            this.rbRecString.UseVisualStyleBackColor = true;
            // 
            // rbRecHex
            // 
            this.rbRecHex.AutoSize = true;
            this.rbRecHex.Location = new System.Drawing.Point(815, 248);
            this.rbRecHex.Name = "rbRecHex";
            this.rbRecHex.Size = new System.Drawing.Size(59, 16);
            this.rbRecHex.TabIndex = 18;
            this.rbRecHex.TabStop = true;
            this.rbRecHex.Text = "16进制";
            this.rbRecHex.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.rbRecString);
            this.Controls.Add(this.rbRecHex);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.bPortOpen);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Name = "Form1";
            this.Text = "串口通信";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbString;
        private System.Windows.Forms.RadioButton rbHex;
        private System.Windows.Forms.Label label6;
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
    }
}

