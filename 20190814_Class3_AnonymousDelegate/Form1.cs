using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20190814_Class3_AnonymousDelegate
{
    public partial class Form1 : Form

    {
      
        public delegate void DEL(string name); //定义一个委托
        public delegate void DELEGATE01(string[] input);
        public delegate string DELEGATE02(string input);
        ObservableCollection<string> strlist; 


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        
        delegate void delegateTest01();  //定义基本委托
        delegate string delegateToUP(string sInput); //有参数和返回值的委托
        private void button1_Click(object sender, EventArgs e)
        {
            //基本委托,无参数的委托
            delegateTest01 delBasic = MethodTest01; //写法1
            delBasic = new delegateTest01(MethodTest01); //写法2
            delBasic();

            //有参数和返回值的委托
            delegateToUP deleUp = toUp;
            string result = deleUp("abc");

            //
            ISTrue = false;
            DoSth = () => { Console.WriteLine("haha01"); }; //第一个
            DoSth += () => { Console.WriteLine("haha02"); }; //第二个

            


        }


        delegate void delegateBasic();
        delegate void delegateValue(string[] s);
        delegate string delegateFunc(string Input);


        delegate void delValueChange();
        event delValueChange DoSth;
        bool isTrue;
        bool ISTrue
        {
            get { return isTrue; }
            set {
                if (value!=isTrue)
                {
                    DoSth();
                }
            }
        }




        delegate void EventStringChange();
        event EventStringChange StringChanged;

        public string valueString;
        public string ValueString 
        {
            get { return valueString; }
            set
            {
                if (value != valueString)
                {
                    StringChanged();
                    valueString = value;
                }
            }
        }


       
        private void DelegateBasic()
        {
            //basic
            delegateBasic delBasic = MethodTest01;
            delegateValue delValue = toUp;
            delValue(new string[] { });
            delegateFunc delFunc = toUp;
            string s = delFunc("hahah");
            //anonymous
            delBasic = delegate () { };
            //lambda
            delegateBasic delBasic2 = () => { };
            //action function
            Action a1 = () => { };
            Func<string> delFunc1 = () => { return "sdsfs"; };

            //use event
            StringChanged = () => { Console.WriteLine("haha"); };
        }

        public static void MethodTest01()
        {
            // Console.WriteLine("ddd");
            MessageBox.Show("ddd");
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

        //匿名委托
        private void button2_Click(object sender, EventArgs e)
        {

            //隐藏方法名
            delegateTest01 delAnonymous = delegate ()
            {
                MessageBox.Show("Anonymous Delegate .Net 2.0加入");
            };
            delAnonymous();

            //Lambda表达示 
            delegateTest01 delLambda = () => { MessageBox.Show("Lambda表达示 .Net 3.0加入", ".Net 3.0"); };
            delLambda();


            //temp
            ISTrue = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //使用action与Func，就不用自己去声名委托了，action/function都是generic type的委托
            Action delAction = () => { MessageBox.Show("Action Test01"); };
            delAction();

            //后面一个是返回值，前一个是输入参数
            Func<int, int> delFunc = (a) => { MessageBox.Show("Action Test01"); return 1; };

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //线程里的委托
            //Anonymous action
            Task tAction = new Task(() => { });
            tAction.Start();
            //Anonymous func
            Task tFuction = new Task<int>(() => { return 1; });


        }

        private void button5_Click(object sender, EventArgs e)
        {

        }


        public delegate void delegateSay(string name);

        public static void SayEng(string input)
        {
            Console.WriteLine("I am speaking englsih!\t" + input);
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
        public static void SayGeneral(string input, delegateSay delSay)
        {
            delSay(input);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SayEng("哈哈！");
            SayCn("霍霍！");
            Console.WriteLine("----");
            //SayGeneral("小样",Say.English);
            //SayGeneral("哈哈", Say.Chinese);
            SayGeneral("英语", SayEng);
            SayGeneral("中文", SayCn);
            Console.WriteLine("------------");



            //绑定方法一
            delegateSay theSay;
            theSay = SayEng;
            theSay = theSay + SayCn;
            SayGeneral("什么", theSay);
            Console.WriteLine("---------");


            //-----------------------------------
            //绑定方法2
            delegateSay Say2 = new delegateSay(SayEng);
            Say2 += SayCn;
            SayGeneral("what?", Say2);
            Console.WriteLine("-------------");
            //----------------------------------

            //取消绑定
            Say2 -= SayCn;
            SayGeneral("只有一个", Say2);


        }

        private void button7_Click(object sender, EventArgs e)
        {

            //思路：(猫大叫一声，所有的老鼠都开始逃跑，主人被惊醒。)
            // 1、构造出Cat、Mouse、Master三个类，并能使程序运行。
            // 2、从Mouse和Master中提取抽象。
            // 3、联动效应，只要执行Cat.Cryed()就可以使老鼠逃跑，主人惊醒。
            // 通过这个例子，可以看出，委托事件的应用是极其面向对象的，或者说很对象化！

        }

        private void button8_Click(object sender, EventArgs e)
        {
            //一个输入，一个bool输出（return）
            Predicate<string> isUpper = delegate (string s) { return s.Equals(s.ToUpper()); };
            bool result = isUpper("abc");
            Console.WriteLine(result);

            //也可以用Lambda赋值
            Predicate<string> isUpper2 = s => s.Equals(s.ToUpper());
            bool result2 = isUpper2("ABC");
            Console.WriteLine("Result 2 is:" + result2);
        }


        //Multicasting
        private void button9_Click(object sender, EventArgs e)
        {
            del theSay = new del(Say1);
            theSay = theSay + Say2 + Say3;
            theSay();
            Console.WriteLine("减！");
            theSay = theSay - Say1;
            theSay();
            Console.ReadKey();
        }

        public delegate void del();

        public static void Say1() { Console.WriteLine("Say1"); }
        public static void Say2() { Console.WriteLine("Say2"); }
        public static void Say3() { Console.WriteLine("Say3"); }
    }
}
