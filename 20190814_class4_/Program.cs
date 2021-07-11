using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _20190814_class4_
{
    class Program
    {
        public delegate void del();
        static void Main(string[] args)
        {
            del theSay = new del(Say1);
            theSay =theSay+Say2 + Say3;
            theSay();
            Console.WriteLine("减！");
            theSay = theSay - Say1;
            theSay();
            Console.ReadKey();
        }

        public static void Say1() { Console.WriteLine("Say1"); }
        public static void Say2() { Console.WriteLine("Say2"); }
        public static void Say3() { Console.WriteLine("Say3"); }

    }
}
