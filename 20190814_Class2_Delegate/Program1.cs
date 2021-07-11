using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _20190814_Class2_Delegate
{
    class Program1
    {
        public delegate void DEL(string name); //定义一个委托
        public delegate void DELEGATE01(string[] input);
        public delegate string DELEGATE02(string input);
        public delegate void delTest01();  //定义

        static void Main(string[] args)
        {

            //for (int i = 0; i < 10; i++)
            //{
            //    SayCN();
            //}
            //  SayDel(SayCN);

            ////  DEL del = new DEL(SayCN);//实例化委托
            //  DEL del = SayCN; //跟new是一样的，系统自动识别
            //  del();

            //DEL del = Say;
            //del("喵了个咪");
            //string[] input = new string[] { "test","haha","hehe"};
            //string input2 = "";

            //DELEGATE01 theDel = ADD;
            //theDel(input);

            //for (int i = 0; i < input.Length; i++)
            //{
            //    Console.WriteLine(input[i]);
            //}


            //DELEGATE02 theDel2 = toUp;
            //input2 = theDel2("ftyghjkl");
            //Console.WriteLine(input2);



            delTest01 the = MethodTest01;
            the();


            //Stop sign
            Console.ReadKey();


        }

        public static void  MethodTest01()
        {
            Console.WriteLine("ddd");
        }


        public static string toUp(string input)
        {
            return input.ToUpper();
        }

        public static void toUp(string[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                input[i] = input[i].ToUpper();
            }
        }

        public static void toLower(string[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                input[i] = input[i].ToLower();
            }
        }

        public static void ADD(string[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                input[i] = input[i] + "\\";
            }
        }

        public static void Say(String input)
        {
            Console.WriteLine(input);
        }

        public static void SayCN()
        {
            Console.WriteLine("我是中国人！");
        }

        public static void SayUS()
        {
            Console.WriteLine("我是美国人！");
        }

        public static void SayGM()
        {
            Console.WriteLine("我是德国人！");
        }
    }
}
