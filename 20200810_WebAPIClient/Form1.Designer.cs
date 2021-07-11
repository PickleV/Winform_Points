namespace _20200810_WebAPIClient
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
            this.tbURL = new Sunny.UI.UITextBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.bGet = new System.Windows.Forms.Button();
            this.label100 = new Sunny.UI.UILabel();
            this.tbMeeting = new Sunny.UI.UITextBox();
            this.tbResult = new Sunny.UI.UITextBox();
            this.sdsdsd = new Sunny.UI.UILabel();
            this.tbPres = new Sunny.UI.UITextBox();
            this.SuspendLayout();
            // 
            // tbURL
            // 
            this.tbURL.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbURL.FillColor = System.Drawing.Color.White;
            this.tbURL.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.tbURL.Location = new System.Drawing.Point(155, 36);
            this.tbURL.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbURL.Maximum = 2147483647D;
            this.tbURL.Minimum = -2147483648D;
            this.tbURL.Name = "tbURL";
            this.tbURL.Padding = new System.Windows.Forms.Padding(5);
            this.tbURL.Size = new System.Drawing.Size(447, 29);
            this.tbURL.TabIndex = 0;
            this.tbURL.Text = "URL";
            // 
            // uiLabel1
            // 
            this.uiLabel1.AutoSize = true;
            this.uiLabel1.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.uiLabel1.Location = new System.Drawing.Point(41, 40);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(107, 21);
            this.uiLabel1.TabIndex = 1;
            this.uiLabel1.Text = "Web API Url:";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bGet
            // 
            this.bGet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bGet.Location = new System.Drawing.Point(45, 148);
            this.bGet.Name = "bGet";
            this.bGet.Size = new System.Drawing.Size(93, 29);
            this.bGet.TabIndex = 2;
            this.bGet.Text = "Get Result";
            this.bGet.UseVisualStyleBackColor = true;
            this.bGet.Click += new System.EventHandler(this.bGet_Click);
            // 
            // label100
            // 
            this.label100.AutoSize = true;
            this.label100.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.label100.Location = new System.Drawing.Point(41, 96);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(95, 21);
            this.label100.TabIndex = 4;
            this.label100.Text = "MeetingID:";
            this.label100.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbMeeting
            // 
            this.tbMeeting.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbMeeting.FillColor = System.Drawing.Color.White;
            this.tbMeeting.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.tbMeeting.Location = new System.Drawing.Point(155, 92);
            this.tbMeeting.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbMeeting.Maximum = 2147483647D;
            this.tbMeeting.Minimum = -2147483648D;
            this.tbMeeting.Name = "tbMeeting";
            this.tbMeeting.Padding = new System.Windows.Forms.Padding(5);
            this.tbMeeting.Size = new System.Drawing.Size(122, 29);
            this.tbMeeting.TabIndex = 3;
            this.tbMeeting.Text = "URL";
            // 
            // tbResult
            // 
            this.tbResult.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbResult.FillColor = System.Drawing.Color.White;
            this.tbResult.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.tbResult.Location = new System.Drawing.Point(155, 148);
            this.tbResult.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbResult.Maximum = 2147483647D;
            this.tbResult.Minimum = -2147483648D;
            this.tbResult.Name = "tbResult";
            this.tbResult.Padding = new System.Windows.Forms.Padding(5);
            this.tbResult.Size = new System.Drawing.Size(447, 29);
            this.tbResult.TabIndex = 5;
            this.tbResult.Text = "Null";
            // 
            // sdsdsd
            // 
            this.sdsdsd.AutoSize = true;
            this.sdsdsd.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.sdsdsd.Location = new System.Drawing.Point(410, 96);
            this.sdsdsd.Name = "sdsdsd";
            this.sdsdsd.Size = new System.Drawing.Size(63, 21);
            this.sdsdsd.TabIndex = 7;
            this.sdsdsd.Text = "PresID:";
            this.sdsdsd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbPres
            // 
            this.tbPres.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbPres.FillColor = System.Drawing.Color.White;
            this.tbPres.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.tbPres.Location = new System.Drawing.Point(480, 92);
            this.tbPres.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPres.Maximum = 2147483647D;
            this.tbPres.Minimum = -2147483648D;
            this.tbPres.Name = "tbPres";
            this.tbPres.Padding = new System.Windows.Forms.Padding(5);
            this.tbPres.Size = new System.Drawing.Size(122, 29);
            this.tbPres.TabIndex = 6;
            this.tbPres.Text = "URL";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 276);
            this.Controls.Add(this.sdsdsd);
            this.Controls.Add(this.tbPres);
            this.Controls.Add(this.tbResult);
            this.Controls.Add(this.label100);
            this.Controls.Add(this.tbMeeting);
            this.Controls.Add(this.bGet);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.tbURL);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sunny.UI.UITextBox tbURL;
        private Sunny.UI.UILabel uiLabel1;
        private System.Windows.Forms.Button bGet;
        private Sunny.UI.UILabel label100;
        private Sunny.UI.UITextBox tbMeeting;
        private Sunny.UI.UITextBox tbResult;
        private Sunny.UI.UILabel sdsdsd;
        private Sunny.UI.UITextBox tbPres;
    }
}

