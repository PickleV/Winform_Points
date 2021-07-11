using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20201215_Reference_Value_DataType
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        class Class1
        {
           public int a;
          public  string b;
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Class
            //自定义类为引用类型！
            Class1 x1 = new Class1();
            Class1 x2 = x1;
            x1.a = 100;
            Console.WriteLine(x2.a);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s1 = "abc";
            string s2 = s1;
             s2 = "123";
            Console.WriteLine(s1);
        }
    }
}
