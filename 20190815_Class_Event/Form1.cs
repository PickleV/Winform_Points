using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace _20190815_Class_Event
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Button button_new = new Button();
            button_new.Text = "测试";
            //button_new.Name = "b2";
            button_new.Location = new Point(50,50);
            Controls.Add(button_new);
            //this.button1.Click += new System.EventHandler(this.button1_Click);
            button_new.Click += new EventHandler(button_new_Click);
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student s1 = new Student();
            s1.Name = "abc";
            s1.NameChanged += S1_NameChanged;
            s1.Name = "abc";
            Stopwatch watch = new Stopwatch();
            watch.Start();
            while (watch.ElapsedMilliseconds<5000)
            {
                Thread.Sleep(1);
                Application.DoEvents();
            }
            s1.Name = "haha";
        }

        private void S1_NameChanged(object o, EventArgs e)
        {
            Student student = (Student)o;
            Console.WriteLine("New name is:"+student.Name);
        }

        private void button_new_Click(object sender, EventArgs e)
        {
            MessageBox.Show("这是一个测试！");
        }

        //
       public class Student
        {
            private string name;
            public delegate void NameValueChangeEventHandle(object o,EventArgs e);
            public event NameValueChangeEventHandle NameChanged;
            public event EventHandler<ChangeResult> NamedChanged2;
            public string Name { get { return name; } 
                set
                {
                    string temp = name;
                    name = value;

                    //Check value
                    if (temp!=value)
                    {            
                        //Trigger event
                        if (NameChanged != null)
                        {
                            //EventArgs e = new EventArgs();
                            PropertyChangedEventArgs e = new PropertyChangedEventArgs(Name);
                            NameChanged(this, e);
                        }

                        if (NamedChanged2!=null)
                        {
                            ChangeResult result = new ChangeResult();
                            result.IsSuccess = true;
                            result.Changed2 = value;
                            result.ChangedFrom = temp;
                            NamedChanged2(this, result);
                        }
                    }                 
                } 
            }

            public class ChangeResult:EventArgs
            {
                public bool IsSuccess;
                public string Changed2;
                public string ChangedFrom;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Student s1 = new Student();
            s1.Name = "abc";
            s1.NamedChanged2 += S1_NamedChanged2; ;
            s1.Name = "abd";
        }

        private void S1_NamedChanged2(object sender, Student.ChangeResult e)
        {
            Console.WriteLine("Changed from "+e.ChangedFrom+ " to:"+e.Changed2);
        }
    }
}
