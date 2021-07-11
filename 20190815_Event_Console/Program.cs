using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace _20190815_Event_Console
{



    class Program
    {

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


        static void Main(string[] args)
        {
            player p1 = new player();     
            //事件变量+=new 委托类型(方法);
            p1.PlayingHandler += P1_PlayingHandler;
            p1.PlayingEvent();


            Predicate<bool> Test = a=> a?true:false;
            Console.WriteLine(Test(true));


            Console.ReadKey();
        }

        private static void P1_PlayingHandler(object sender, EventArgs e)
        {
            Console.WriteLine("This is a Test.");
        }

        public static void OnPlaying(object sender,EventArgs e)
        {

        }
    }
}
