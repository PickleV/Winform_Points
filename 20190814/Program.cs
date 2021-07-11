using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _20190814
{
    class Program
    {
        class Judge
        {
            //定义一个委托
            public delegate void delegateRun();
            //定义一个事件
            public event delegateRun theRun; 
            //定义一个方法
            public void Begin()
            {
                //引发的事件
                theRun();
            }

        }


        class Runner
        {
            public void Run()
            {
                Console.WriteLine("运动员开始比赛！");
            }
        }

        static void Main(string[] args)
        {
            //开始实现 
            Runner runSports = new Runner();
            Judge judge = new Judge();
            //订阅事件-说明联系

            //触发事件

            Console.ReadLine();
        }
    }
}
