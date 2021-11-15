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

            string s1 = "abc";
            string s2 = s1;
             s1 = "123";
            Console.WriteLine(s2);


        }

        private async Task<bool> DoSth()
        {
            //Do sth
            await Task.Delay(1000);

            //result
            return true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            List<string> sList = new List<string>();
            StringBuilder sBuilder = new StringBuilder();
            string sRaw="";
            
            //Add
            stopwatch.Restart();
            for (int i = 0; i < 1000000; i++)
            {
                sList.Add("xyzabcdefg1234567890");
            }
            if (sList.Count>10000)
            {
                sList.Clear();
            }
            Debug.WriteLine("List<string>.Add:"+stopwatch.ElapsedMilliseconds);

            stopwatch.Restart();
            for (int i = 0; i < 1000000; i++)
            {
                sBuilder.Append("xyzabcdefg1234567890");
            }
            if (sBuilder.Length>200000)
            {
                //sBuilder.Remove(0, 20000);
                sBuilder.Clear();
            }
            Debug.WriteLine("String builder.Add:" + stopwatch.ElapsedMilliseconds);

            //String is the worst
            stopwatch.Restart();
            for (int i = 0; i < 10000; i++)
            {
                sRaw+="xyzabcdefg1234567890";
            }
            //if (sBuilder.Length > 2000)
            //{
            //    //sBuilder.Remove(0, 20000);
            //    sRaw="";
            //}
            Debug.WriteLine("String builder.Add:" + stopwatch.ElapsedMilliseconds);

        }
    }
}
