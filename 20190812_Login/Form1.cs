using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _20190812.Class3_Text
{
    public partial class Form1 : Form
    {

        public Dictionary<string, string> dictLogin = new Dictionary<string, string>();
        

        public Form1()
        {
            InitializeComponent();
            dictLogin.Add("admin","Password1!");
            dictLogin.Add("user", "123456");
            tbPass.PasswordChar = '*';
            
         }

        private void b_Login_Click(object sender, EventArgs e)
        {
            if (rb_Teacher.Checked)
            {
                if (tbUser.Text=="admin" && tbPass.Text=="Password1!")
                {
                    MessageBox.Show("登陆成功！");
                }
                else
                {
                    MessageBox.Show("帐号或密码错误！");
                }
            }
            else if (rbStudent.Checked)
            {
                if (tbUser.Text == "user" && tbPass.Text == "123456")
                {
                    MessageBox.Show("登陆成功！");
                }
                else
                {

                    MessageBox.Show("帐号或密码错误！");
                }
            }
            else
            {
                MessageBox.Show("请选择学生或者老师！");
            }
        }

        private bool login()
        {
            


            return false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
           DialogResult dr= MessageBox.Show("您真要退出吗？","警告",MessageBoxButtons.YesNo);

            if (dr==DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void uiTextBox1_DoEnter(object sender, EventArgs e)
        {
            uiTextBox1.Text = uiTextBox1.Text + "\r\n";
        }
    }
}
