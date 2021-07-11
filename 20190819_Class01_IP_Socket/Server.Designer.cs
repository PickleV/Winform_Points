namespace _20190819_Class01_IP_Socket
{
    partial class Server
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
            this.bSend = new System.Windows.Forms.Button();
            this.tbSend = new System.Windows.Forms.TextBox();
            this.tbReceive = new System.Windows.Forms.TextBox();
            this.bClient = new System.Windows.Forms.Button();
            this.bStart = new System.Windows.Forms.Button();
            this.bStop = new System.Windows.Forms.Button();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.bInfo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bSend
            // 
            this.bSend.Location = new System.Drawing.Point(516, 356);
            this.bSend.Name = "bSend";
            this.bSend.Size = new System.Drawing.Size(75, 23);
            this.bSend.TabIndex = 0;
            this.bSend.Text = "发送数据";
            this.bSend.UseVisualStyleBackColor = true;
            this.bSend.Click += new System.EventHandler(this.bSend_Click);
            // 
            // tbSend
            // 
            this.tbSend.Location = new System.Drawing.Point(28, 114);
            this.tbSend.Multiline = true;
            this.tbSend.Name = "tbSend";
            this.tbSend.Size = new System.Drawing.Size(439, 106);
            this.tbSend.TabIndex = 1;
            // 
            // tbReceive
            // 
            this.tbReceive.Location = new System.Drawing.Point(28, 273);
            this.tbReceive.Multiline = true;
            this.tbReceive.Name = "tbReceive";
            this.tbReceive.Size = new System.Drawing.Size(439, 106);
            this.tbReceive.TabIndex = 2;
            // 
            // bClient
            // 
            this.bClient.Location = new System.Drawing.Point(713, 415);
            this.bClient.Name = "bClient";
            this.bClient.Size = new System.Drawing.Size(75, 23);
            this.bClient.TabIndex = 3;
            this.bClient.Text = "客户端";
            this.bClient.UseVisualStyleBackColor = true;
            this.bClient.Click += new System.EventHandler(this.bClient_Click);
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(421, 49);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(75, 23);
            this.bStart.TabIndex = 4;
            this.bStart.Text = "启动监听";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // bStop
            // 
            this.bStop.Enabled = false;
            this.bStop.Location = new System.Drawing.Point(525, 49);
            this.bStop.Name = "bStop";
            this.bStop.Size = new System.Drawing.Size(75, 23);
            this.bStop.TabIndex = 5;
            this.bStop.Text = "停止监听";
            this.bStop.UseVisualStyleBackColor = true;
            this.bStop.Click += new System.EventHandler(this.bStop_Click);
            // 
            // tbIP
            // 
            this.tbIP.Location = new System.Drawing.Point(55, 49);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(143, 21);
            this.tbIP.TabIndex = 6;
            this.tbIP.Text = "127.0.0.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(232, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "Port:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(273, 49);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(100, 21);
            this.tbPort.TabIndex = 8;
            this.tbPort.Text = "54321";
            // 
            // bInfo
            // 
            this.bInfo.Location = new System.Drawing.Point(621, 415);
            this.bInfo.Name = "bInfo";
            this.bInfo.Size = new System.Drawing.Size(75, 23);
            this.bInfo.TabIndex = 10;
            this.bInfo.Text = "信息";
            this.bInfo.UseVisualStyleBackColor = true;
            this.bInfo.Click += new System.EventHandler(this.button1_Click);
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bInfo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbIP);
            this.Controls.Add(this.bStop);
            this.Controls.Add(this.bStart);
            this.Controls.Add(this.bClient);
            this.Controls.Add(this.tbReceive);
            this.Controls.Add(this.tbSend);
            this.Controls.Add(this.bSend);
            this.Name = "Server";
            this.Text = "TCP通信";
            this.Load += new System.EventHandler(this.Server_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bSend;
        private System.Windows.Forms.TextBox tbSend;
        private System.Windows.Forms.TextBox tbReceive;
        private System.Windows.Forms.Button bClient;
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.Button bStop;
        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Button bInfo;
    }
}

