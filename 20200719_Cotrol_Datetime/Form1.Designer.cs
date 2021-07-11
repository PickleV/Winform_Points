namespace _20200719_Cotrol_Datetime
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.uiDatetimePicker1 = new Sunny.UI.UIDatetimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.uiColorPicker1 = new Sunny.UI.UIColorPicker();
            this.uiAvatar1 = new Sunny.UI.UIAvatar();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(58, 78);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker2.Location = new System.Drawing.Point(287, 78);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.ShowUpDown = true;
            this.dateTimePicker2.Size = new System.Drawing.Size(165, 20);
            this.dateTimePicker2.TabIndex = 1;
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker3.Location = new System.Drawing.Point(510, 78);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker3.TabIndex = 2;
            // 
            // uiDatetimePicker1
            // 
            this.uiDatetimePicker1.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.uiDatetimePicker1.FillColor = System.Drawing.Color.White;
            this.uiDatetimePicker1.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.uiDatetimePicker1.Location = new System.Drawing.Point(398, 219);
            this.uiDatetimePicker1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiDatetimePicker1.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiDatetimePicker1.Name = "uiDatetimePicker1";
            this.uiDatetimePicker1.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.uiDatetimePicker1.Size = new System.Drawing.Size(199, 29);
            this.uiDatetimePicker1.TabIndex = 3;
            this.uiDatetimePicker1.Text = "uiDatetimePicker1";
            this.uiDatetimePicker1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiDatetimePicker1.Value = new System.DateTime(2020, 7, 19, 19, 40, 58, 586);
            this.uiDatetimePicker1.Click += new System.EventHandler(this.uiDatetimePicker1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(150, 259);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "切换";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // uiColorPicker1
            // 
            this.uiColorPicker1.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.uiColorPicker1.FillColor = System.Drawing.Color.White;
            this.uiColorPicker1.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.uiColorPicker1.Location = new System.Drawing.Point(622, 219);
            this.uiColorPicker1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiColorPicker1.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiColorPicker1.Name = "uiColorPicker1";
            this.uiColorPicker1.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.uiColorPicker1.Size = new System.Drawing.Size(150, 29);
            this.uiColorPicker1.TabIndex = 5;
            this.uiColorPicker1.Text = "uiColorPicker1";
            this.uiColorPicker1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiColorPicker1.Value = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            // 
            // uiAvatar1
            // 
            this.uiAvatar1.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.uiAvatar1.Location = new System.Drawing.Point(570, 298);
            this.uiAvatar1.Name = "uiAvatar1";
            this.uiAvatar1.Size = new System.Drawing.Size(60, 60);
            this.uiAvatar1.TabIndex = 6;
            this.uiAvatar1.Text = "uiAvatar1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.uiAvatar1);
            this.Controls.Add(this.uiColorPicker1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.uiDatetimePicker1);
            this.Controls.Add(this.dateTimePicker3);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private Sunny.UI.UIDatetimePicker uiDatetimePicker1;
        private System.Windows.Forms.Button button1;
        private Sunny.UI.UIColorPicker uiColorPicker1;
        private Sunny.UI.UIAvatar uiAvatar1;
    }
}

