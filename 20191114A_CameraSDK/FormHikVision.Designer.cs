namespace _20191114A_CameraSDK
{
    partial class FormHikVision
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbCamera1 = new System.Windows.Forms.ComboBox();
            this.bOpen = new System.Windows.Forms.Button();
            this.bSnap = new System.Windows.Forms.Button();
            this.bStop = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DarkGray;
            this.pictureBox1.Location = new System.Drawing.Point(37, 65);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(390, 329);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // cbCamera1
            // 
            this.cbCamera1.DropDownWidth = 200;
            this.cbCamera1.FormattingEnabled = true;
            this.cbCamera1.Location = new System.Drawing.Point(37, 30);
            this.cbCamera1.Name = "cbCamera1";
            this.cbCamera1.Size = new System.Drawing.Size(390, 20);
            this.cbCamera1.TabIndex = 1;
            // 
            // bOpen
            // 
            this.bOpen.Location = new System.Drawing.Point(587, 30);
            this.bOpen.Name = "bOpen";
            this.bOpen.Size = new System.Drawing.Size(75, 23);
            this.bOpen.TabIndex = 2;
            this.bOpen.Text = "打开相机";
            this.bOpen.UseVisualStyleBackColor = true;
            this.bOpen.Click += new System.EventHandler(this.bOpen_Click);
            // 
            // bSnap
            // 
            this.bSnap.Location = new System.Drawing.Point(587, 170);
            this.bSnap.Name = "bSnap";
            this.bSnap.Size = new System.Drawing.Size(75, 23);
            this.bSnap.TabIndex = 3;
            this.bSnap.Text = "采集一帧";
            this.bSnap.UseVisualStyleBackColor = true;
            // 
            // bStop
            // 
            this.bStop.Location = new System.Drawing.Point(587, 100);
            this.bStop.Name = "bStop";
            this.bStop.Size = new System.Drawing.Size(75, 23);
            this.bStop.TabIndex = 4;
            this.bStop.Text = "停止采集";
            this.bStop.UseVisualStyleBackColor = true;
            this.bStop.Click += new System.EventHandler(this.bStop_Click);
            // 
            // FormHikVision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bStop);
            this.Controls.Add(this.bSnap);
            this.Controls.Add(this.bOpen);
            this.Controls.Add(this.cbCamera1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FormHikVision";
            this.Text = "FormHikVision";
            this.Load += new System.EventHandler(this.FormHikVision_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cbCamera1;
        private System.Windows.Forms.Button bOpen;
        private System.Windows.Forms.Button bSnap;
        private System.Windows.Forms.Button bStop;
    }
}