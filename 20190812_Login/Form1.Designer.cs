namespace _20190812.Class3_Text
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
            this.tbUser = new System.Windows.Forms.TextBox();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.b_Login = new System.Windows.Forms.Button();
            this.rb_Teacher = new System.Windows.Forms.RadioButton();
            this.rbStudent = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.uiRichTextBox1 = new Sunny.UI.UIRichTextBox();
            this.uiTextBox1 = new Sunny.UI.UITextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(163, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "QQ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(163, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "密码：";
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(225, 142);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(181, 20);
            this.tbUser.TabIndex = 2;
            // 
            // tbPass
            // 
            this.tbPass.Location = new System.Drawing.Point(225, 189);
            this.tbPass.Name = "tbPass";
            this.tbPass.Size = new System.Drawing.Size(181, 20);
            this.tbPass.TabIndex = 3;
            // 
            // b_Login
            // 
            this.b_Login.Location = new System.Drawing.Point(490, 186);
            this.b_Login.Name = "b_Login";
            this.b_Login.Size = new System.Drawing.Size(75, 25);
            this.b_Login.TabIndex = 4;
            this.b_Login.Text = "登陆";
            this.b_Login.UseVisualStyleBackColor = true;
            this.b_Login.Click += new System.EventHandler(this.b_Login_Click);
            // 
            // rb_Teacher
            // 
            this.rb_Teacher.AutoSize = true;
            this.rb_Teacher.Location = new System.Drawing.Point(225, 258);
            this.rb_Teacher.Name = "rb_Teacher";
            this.rb_Teacher.Size = new System.Drawing.Size(49, 17);
            this.rb_Teacher.TabIndex = 5;
            this.rb_Teacher.TabStop = true;
            this.rb_Teacher.Text = "老师";
            this.rb_Teacher.UseVisualStyleBackColor = true;
            // 
            // rbStudent
            // 
            this.rbStudent.AutoSize = true;
            this.rbStudent.Location = new System.Drawing.Point(356, 258);
            this.rbStudent.Name = "rbStudent";
            this.rbStudent.Size = new System.Drawing.Size(73, 17);
            this.rbStudent.TabIndex = 6;
            this.rbStudent.TabStop = true;
            this.rbStudent.Text = "学生登陆";
            this.rbStudent.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(25, 304);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(181, 84);
            this.textBox1.TabIndex = 7;
            // 
            // uiRichTextBox1
            // 
            this.uiRichTextBox1.AutoWordSelection = true;
            this.uiRichTextBox1.FillColor = System.Drawing.Color.White;
            this.uiRichTextBox1.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.uiRichTextBox1.Location = new System.Drawing.Point(248, 304);
            this.uiRichTextBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiRichTextBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiRichTextBox1.Name = "uiRichTextBox1";
            this.uiRichTextBox1.Padding = new System.Windows.Forms.Padding(2);
            this.uiRichTextBox1.Size = new System.Drawing.Size(197, 84);
            this.uiRichTextBox1.Style = Sunny.UI.UIStyle.Custom;
            this.uiRichTextBox1.TabIndex = 8;
            this.uiRichTextBox1.Text = "uiRichTextBox1";
            // 
            // uiTextBox1
            // 
            this.uiTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox1.FillColor = System.Drawing.Color.White;
            this.uiTextBox1.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.uiTextBox1.Location = new System.Drawing.Point(490, 304);
            this.uiTextBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBox1.Maximum = 2147483647D;
            this.uiTextBox1.Minimum = -2147483648D;
            this.uiTextBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTextBox1.Multiline = true;
            this.uiTextBox1.Name = "uiTextBox1";
            this.uiTextBox1.Padding = new System.Windows.Forms.Padding(5);
            this.uiTextBox1.Size = new System.Drawing.Size(217, 84);
            this.uiTextBox1.TabIndex = 9;
            this.uiTextBox1.Text = "uiTextBox1";
            this.uiTextBox1.DoEnter += new System.EventHandler(this.uiTextBox1_DoEnter);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 488);
            this.Controls.Add(this.uiTextBox1);
            this.Controls.Add(this.uiRichTextBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.rbStudent);
            this.Controls.Add(this.rb_Teacher);
            this.Controls.Add(this.b_Login);
            this.Controls.Add(this.tbPass);
            this.Controls.Add(this.tbUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "用户登陆";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.Button b_Login;
        private System.Windows.Forms.RadioButton rb_Teacher;
        private System.Windows.Forms.RadioButton rbStudent;
        private System.Windows.Forms.TextBox textBox1;
        private Sunny.UI.UIRichTextBox uiRichTextBox1;
        private Sunny.UI.UITextBox uiTextBox1;
    }
}

