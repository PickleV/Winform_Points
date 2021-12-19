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

namespace _20190814_class6_Event
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            player p1 = new player();
            //事件变量+=new 委托类型(方法);
            p1.PlayingHandler += P1_PlayingHandler;
            p1.PlayingEvent();


            Predicate<bool> Test = a => a ? true : false;
            Console.WriteLine(Test(true));


          
        }


        //事件定义和触发通常放到类里
        public class player
        {
            //EventHandler为.Net定义好的通用的委托类型
            //public delegate void EventHandler(object sender, EventArgs e);
            public event EventHandler PlayingHandler;
            public void PlayingEvent()
            {
                if (PlayingHandler != null)
                {
                    EventArgs e = new EventArgs();
                    PlayingHandler(this, e); //触发事件
                }
            }



        }


        private static void P1_PlayingHandler(object sender, EventArgs e)
        {
            Console.WriteLine("This is a Test.");
        }

        public static void OnPlaying(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student s1 = new Student();
            if (s1.GetType()==typeof(Person))
            {
                //False
            }
            //True
            else if(s1 is Person)
            {
                Debug.WriteLine("Student is person.");
            }

        }

        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        class Student : Person,IDisposable
        {
            public int Grade { get; set; }
            private Thread thread;
            public bool IsDisposed { get; set; }

            public Student()
            {
                thread = new Thread(ThreadProcess);
                thread.IsBackground = true;
                thread.Start();
            }

            private void ThreadProcess()
            {
                Debug.WriteLine("Student.ThreadProcess:Start");
                
                while (!this.IsDisposed)
                {
                    Thread.Sleep(1000);
                    Debug.WriteLine("Did something.");
                }
                Debug.WriteLine("Student.ThreadProcess:Finished");
            }

            public void Dispose()
            {
                IsDisposed = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Student> sList = new List<Student>();

            
            Student sA = new Student();
            sA.Name = "ABC";
            sList.Add(sA);
            sList.Clear();

            using (sA)
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Do other things");
        }
    }
}
