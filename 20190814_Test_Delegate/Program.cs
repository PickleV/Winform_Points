using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _20190814_Test_Delegate
{
    class Program
    {


        public delegate void delegateSay(string name);

        public static void SayEng(string input)
        {
            Console.WriteLine("I am speaking englsih!\t"+input);
        }

        public static void SayCn(string input)
        {
            Console.WriteLine("我在说中文！" + input);
        }

        //确定语言类型

        //public enum Say
        //{
        //    English,Chinese
        //}

        //public static void SayGeneral(string input,Say language)
        //{
        //    //switch (language)
        //    //{
        //    //    case Say.English:
        //    //        SayEng(input);
        //    //        break;
        //    //    case Say.Chinese:
        //    //        SayCn(input);
        //    //        break;
        //    //    default:
        //    //        break;
        //    //}
        //}
        public static void SayGeneral(string input, delegateSay  delSay)
        {
            delSay(input);
        }


        static void Main(string[] args)
        {
            SayEng("哈哈！");
            SayCn("霍霍！");
            Console.WriteLine("----");
            //SayGeneral("小样",Say.English);
            //SayGeneral("哈哈", Say.Chinese);
            SayGeneral("英语",SayEng);
            SayGeneral("中文",SayCn);
            Console.WriteLine("------------");
           


            //绑定方法一
            delegateSay theSay;
            theSay = SayEng;
            theSay = theSay + SayCn;
            SayGeneral("什么",theSay);
            Console.WriteLine(  "---------");


            //-----------------------------------
            //绑定方法2
            delegateSay Say2 = new delegateSay(SayEng);
            Say2 += SayCn;
            SayGeneral("what?", Say2);
            Console.WriteLine("-------------");
            //----------------------------------

            //取消绑定
            Say2 -= SayCn;
            SayGeneral("只有一个",Say2);


            Console.ReadKey();
        }
    }
}
