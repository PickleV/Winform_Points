using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _20190812_Class1_Start  //定义命名空间
{
    public partial class Form1 : Form
    {
        public Form1() //构造函数
        {
            InitializeComponent();//初始化组件
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.BackColor = System.Drawing.Color.Red;
            MessageBox.Show("点击");
        }

        private void btn2_color_Change(object sender, EventArgs e)
        {
            MessageBox.Show("颜色变了");
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.Text = "来玩呀！";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();//非模态，后对可以动
           // form2.ShowDialog(); //模态对话框，后台不能动
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Class1.theForm1 = this;
      
        }
    }
}
