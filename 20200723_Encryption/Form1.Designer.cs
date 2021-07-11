namespace _20200723_Encryption
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
            this.tbInput = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbOutput = new System.Windows.Forms.TextBox();
            this.bEnMD5 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.bRSA = new System.Windows.Forms.Button();
            this.bEnSha256 = new System.Windows.Forms.Button();
            this.bEnSha512 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.bRSADe = new System.Windows.Forms.Button();
            this.bAESEncrypt = new System.Windows.Forms.Button();
            this.bAESDecrypt = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbInput
            // 
            this.tbInput.Location = new System.Drawing.Point(16, 20);
            this.tbInput.Multiline = true;
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(269, 150);
            this.tbInput.TabIndex = 0;
            this.tbInput.Text = "Input";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbInput);
            this.groupBox1.Location = new System.Drawing.Point(24, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 176);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbOutput);
            this.groupBox2.Location = new System.Drawing.Point(345, 34);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(443, 404);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output";
            // 
            // tbOutput
            // 
            this.tbOutput.Location = new System.Drawing.Point(16, 20);
            this.tbOutput.Multiline = true;
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.Size = new System.Drawing.Size(421, 378);
            this.tbOutput.TabIndex = 0;
            this.tbOutput.Text = "Output";
            // 
            // bEnMD5
            // 
            this.bEnMD5.Location = new System.Drawing.Point(29, 32);
            this.bEnMD5.Name = "bEnMD5";
            this.bEnMD5.Size = new System.Drawing.Size(75, 23);
            this.bEnMD5.TabIndex = 4;
            this.bEnMD5.Text = "MD5";
            this.bEnMD5.UseVisualStyleBackColor = true;
            this.bEnMD5.Click += new System.EventHandler(this.bEnMD5_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.bAESEncrypt);
            this.groupBox3.Controls.Add(this.bRSA);
            this.groupBox3.Controls.Add(this.bEnSha256);
            this.groupBox3.Controls.Add(this.bEnSha512);
            this.groupBox3.Controls.Add(this.bEnMD5);
            this.groupBox3.Location = new System.Drawing.Point(24, 232);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(131, 206);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Encryption";
            // 
            // bRSA
            // 
            this.bRSA.Location = new System.Drawing.Point(29, 120);
            this.bRSA.Name = "bRSA";
            this.bRSA.Size = new System.Drawing.Size(75, 23);
            this.bRSA.TabIndex = 6;
            this.bRSA.Text = "RSA";
            this.bRSA.UseVisualStyleBackColor = true;
            this.bRSA.Click += new System.EventHandler(this.bRSA_Click);
            // 
            // bEnSha256
            // 
            this.bEnSha256.Location = new System.Drawing.Point(29, 61);
            this.bEnSha256.Name = "bEnSha256";
            this.bEnSha256.Size = new System.Drawing.Size(75, 23);
            this.bEnSha256.TabIndex = 5;
            this.bEnSha256.Text = "SHA256";
            this.bEnSha256.UseVisualStyleBackColor = true;
            this.bEnSha256.Click += new System.EventHandler(this.bEnSha256_Click);
            // 
            // bEnSha512
            // 
            this.bEnSha512.Location = new System.Drawing.Point(29, 90);
            this.bEnSha512.Name = "bEnSha512";
            this.bEnSha512.Size = new System.Drawing.Size(75, 23);
            this.bEnSha512.TabIndex = 4;
            this.bEnSha512.Text = "SHA512";
            this.bEnSha512.UseVisualStyleBackColor = true;
            this.bEnSha512.Click += new System.EventHandler(this.bEnSha512_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.bAESDecrypt);
            this.groupBox4.Controls.Add(this.bRSADe);
            this.groupBox4.Location = new System.Drawing.Point(178, 232);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(131, 206);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Decryption";
            // 
            // bRSADe
            // 
            this.bRSADe.Location = new System.Drawing.Point(24, 120);
            this.bRSADe.Name = "bRSADe";
            this.bRSADe.Size = new System.Drawing.Size(75, 23);
            this.bRSADe.TabIndex = 7;
            this.bRSADe.Text = "RSA";
            this.bRSADe.UseVisualStyleBackColor = true;
            this.bRSADe.Click += new System.EventHandler(this.bRSADe_Click);
            // 
            // bAESEncrypt
            // 
            this.bAESEncrypt.Location = new System.Drawing.Point(29, 150);
            this.bAESEncrypt.Name = "bAESEncrypt";
            this.bAESEncrypt.Size = new System.Drawing.Size(75, 23);
            this.bAESEncrypt.TabIndex = 7;
            this.bAESEncrypt.Text = "AES Encryt";
            this.bAESEncrypt.UseVisualStyleBackColor = true;
            this.bAESEncrypt.Click += new System.EventHandler(this.bAESEncrypt_Click);
            // 
            // bAESDecrypt
            // 
            this.bAESDecrypt.Location = new System.Drawing.Point(24, 149);
            this.bAESDecrypt.Name = "bAESDecrypt";
            this.bAESDecrypt.Size = new System.Drawing.Size(75, 23);
            this.bAESDecrypt.TabIndex = 8;
            this.bAESDecrypt.Text = "AES Decryt";
            this.bAESDecrypt.UseVisualStyleBackColor = true;
            this.bAESDecrypt.Click += new System.EventHandler(this.bAESDecrypt_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbOutput;
        private System.Windows.Forms.Button bEnMD5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button bEnSha512;
        private System.Windows.Forms.Button bEnSha256;
        private System.Windows.Forms.Button bRSA;
        private System.Windows.Forms.Button bRSADe;
        private System.Windows.Forms.Button bAESEncrypt;
        private System.Windows.Forms.Button bAESDecrypt;
    }
}

