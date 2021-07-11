using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace _20210224_String
{
    public partial class Form1 : Form
    {
        object lockObject = new object();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

           
            

            Student s1 = new Student();
            Student s2 = new Student();
            Student s3 = new Student();
            s1.Age = 10;
            s2 = s1;
            s2.Age = 20;
            s3 = s1;
            s3.Age = 5;

            
            Debug.Write((s1.Age+ s2.Age+ s3.Age).ToString());

            Thread t1 = new Thread(ProcessDoSth);
            t1.IsBackground = true;
            t1.Start();
        }

        private void ProcessDoSth()
        {
            while (true)
            {
                Thread.Sleep(10);
                //Dosth
            }
        }

        public class Student
        {
            public string Name { get; set; }
            public int Age { get; set; }
          public Student()
            {
                //Dosth
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
          bool result= await DoSth();
        }

        private async Task<bool> DoSth()
        {
            //Do sth
            await Task.Delay(1000);

            //result
            return true;
        }
    }
}
