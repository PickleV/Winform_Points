using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _20190814_Class5_传值
{
    public partial class Form1 : Form
    {
        
      //  Form1 form1;

        public Form1()
        {
            InitializeComponent();
           // form1 = this;
        }

        private void button1_Click(object sender, EventArgs e)
        {


          bool  bExist = false;

            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                if (Application.OpenForms[i] is Form2)
                {
                    bExist = true;
                }              
            }
            if (bExist)
            {
                MessageBox.Show("窗口已经打开！");
            }
            else
            {
                Form2 form2 = new Form2(ChangeTextBox);
                form2.Show();
            }
            
            
            
        }

        public void ChangeTextBox(string input)
        {
            textBox1.Text = input;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Student xiaoming = new Student() { Name="haha",Age=100};

            DoSth(xiaoming);

            Console.WriteLine(xiaoming.Age);
             

        }

        private void DoSth(Student student)
        {
            student.Age = 111;
        }

        class Student
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}
