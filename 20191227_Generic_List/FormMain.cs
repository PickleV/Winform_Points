using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Concurrent;
using _20190814_Class_General;
using System.Diagnostics;

namespace _20191227_Generic_List
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {



        }

        private void button2_Click(object sender, EventArgs e)
        {
            SortedList<int, string> sl = new SortedList<int, string>();
            for (int i = 0; i < 10; i++)
            {
                sl.Add(i, "Value is:" + i.ToString());
            }
            Console.WriteLine("count is:" + sl.Count);
            sl.Remove(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BitArray br = new BitArray(3);
            br.SetAll(false);
            br[0] = true;
            br.Set(1, false);
            br.Set(2, true);
            foreach (bool item in br)
            {
                Console.WriteLine(item.ToString());
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            bool bExit = false;
            foreach (Form item in Application.OpenForms)
            {
                if (item is FormDictionary)
                {
                    bExit = true;
                }
            }
            if (!bExit)
            {
                FormDictionary theForm = new FormDictionary();
                theForm.Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            //后进先出，可以用在后退/前进之类的操作，
            //增加叫Pushing,删除叫popping,Pushing和popping只能对顶层操作
            Stack<string> theStack = new Stack<string>();
            theStack.Push("哈哈");  //增加
            theStack.Push("AA");
            theStack.Push("BB");
            foreach (var item in theStack)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("__");
            //删除
            theStack.Pop(); //显示并删除
            //再显示
            foreach (var item in theStack)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("__");
            Console.WriteLine(theStack.Peek());  //只显示，不删除
            Console.WriteLine(theStack.Count);
            theStack.Clear();
            Console.WriteLine(theStack.Count);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //先进先妯，FIFO,First In First Out
            //Enqueue,Dequeue
            Queue<int> theQ = new Queue<int>();
            for (int i = 0; i < 5; i++)
            {
                theQ.Enqueue(i);
            }
            //输出 
            for (int i = 0; i < theQ.Count; i++)
            {
                Console.WriteLine(theQ.ElementAt(i));
            }
            //peek,查看，不删除
            Console.WriteLine("Peek结果是:" + theQ.Peek());


        }

        private void button6_Click(object sender, EventArgs e)
        {
            //不能重复，速度快
            HashSet<int> theSet = new HashSet<int>();
            for (int i = 0; i < 5; i++)
            {
                theSet.Add(i);
            }
            Console.WriteLine("HashSet length is:" + theSet.Count);
            //子集,全都在另一个集合中。超集，包含子集中的所有目标
            HashSet<int> theSet1 = new HashSet<int>();
            for (int i = 0; i < 3; i++)
            {
                theSet1.Add(i);
            }
            Console.WriteLine("是不是子集:" + theSet1.IsSubsetOf(theSet));  //都包含，所以是子集
            Console.WriteLine("是不是超集:" + theSet1.IsSupersetOf(theSet));  //不都包含，所以不是超集
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FormList winList = new FormList();
            winList.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            BitArray br = new BitArray(3);
            br.SetAll(false);
            br[0] = true;
            br.Set(1, false);
            br.Set(2, true);
            foreach (bool item in br)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {

            //Tuple 应用在多返回值的情况，可以简化代码

            if (InputOutput().Item1)
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Tuple<bool, string> InputOutput()
        {
            return Tuple.Create(true, "haha");
        }

        private void button10_Click(object sender, EventArgs e)
        {


        }

        private void button11_Click(object sender, EventArgs e)
        {
            int a = 3, b = 4;
            Swap(ref a, ref b);
            Console.WriteLine("a={0},b={1}",a,b);
        }

        private void Swap<T>(ref T a,ref T b)
            {
            T temp = b;
            b = a;
            a = temp;
            }

        private void button12_Click(object sender, EventArgs e)
        {
            FormConcurrentBag winBag = new FormConcurrentBag();
            winBag.Show();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Debug.WriteLine($"Is Form Exist:{csMethod.IsFormExist(typeof(FormList))}");
        }

        private void bArrrayByte_Click(object sender, EventArgs e)
        {
            byte[] bData = new byte[] { 0x00,0x01,0x02};
            UpdateByteArray(bData);
            Debug.WriteLine(BitConverter.ToString(bData));

            Debug.WriteLine(BitConverter.ToString(new byte[9]));
        }

        private void UpdateByteArray(byte[] byteArray)
        {
            byteArray[1] = 0x22;
        }
    }
}
