using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _20200222_Dev_Mode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class Student
        {
            private static Student student = new Student();
            private Student()
            {
                //Private的构造函数，在外面就不能实例化了，因为实例化必然会调用构造函数
            }
            //外面可以调用的方法
            public static Student GetStudent()
            {
                return student;
            }
            // 类中的其它方法，尽量是static ?????
            public static void Say()
            {
                MessageBox.Show("我是秦始皇.....");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
