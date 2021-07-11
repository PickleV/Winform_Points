using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _20200104_Algorithm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] nums = new int[] {22,33,2,1,8,10,11};
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i+1; j < nums.Length; j++)
                {
                    if (nums[i]>nums[j])
                    {
                        int temp = nums[j];
                        nums[j] = nums[i];
                        nums[i] = temp;
                    }
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                Console.WriteLine(nums[i]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int[] nums = new int[] { 22, 33, 2, 1, 8, 10, 11,13,17 };
            int[] numsNew = new int[nums.Length];
            //插入第一个值
            numsNew[0] = nums[0];
            for (int i = 1; i < numsNew.Length; i++)
            { //从第二个值开始插入
                //如果比最大的还大，就放到后面
                if (nums[i] >= numsNew[i-1])
                {//如果大于，就直接放到后面
                    numsNew[i] = nums[i];
                    continue; //下一个数
                }
                //如果不是最大的，就遍历比较，看它比谁小
                //注意不能比大，因为还有可能比所有都小
                for (int j = 0; j < i; j++)
                { //遍历比较已经插入的数
                    if (nums[i]<numsNew[j])
                    { //如果小于，就先移位，后插入
                        for (int m = i; m > j; m--)
                        {
                            numsNew[m] = numsNew[m - 1];
                        }
                        //插入
                        numsNew[j] = nums[i];
                        break; //下一个数
                    }
                }
            }

            Console.WriteLine("结果为：");
            foreach (var item in numsNew)
            {
                Console.WriteLine(item);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int m = 5;
            bool flag = true;
            int sum = 0;
            for (int i = 1; i < m+1; i++)
            {
                if (flag)
                {
                    sum += i;

                }
                else
                {
                    sum += -i;    
                }

                flag = !flag;

            }
            Console.WriteLine("Sum is:"+sum);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //有1、2、3、4个数字，能组成多少个互不相同且无重复数字的三位数
            int count = 0;
            for (int i = 1; i < 5; i++)
            {
                for (int j = 1; j < 5; j++)
                {
                    for (int m = 1; m < 5; m++)
                    {
                        if (i!=j&&i!=m&&j!=m)
                        {
                            Console.WriteLine("Num is:"+i+j+m);
                            count++;
                        }
                    }
                }
            }

            Console.WriteLine("Total num is:"+count);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //12 ? 56 ? *123 = 154 ? 4987
            int a, b;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    for (int m = 0; m < 10; m++)
                    {
                        a = 120560 + i * 1000 + j;
                        b = 15404987 + m * 10000;
                        if (a*123==b)
                        {
                            Console.WriteLine("可能的组合："+a+"*123="+b);
                        }

                    }
                }
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //1、1、2、3、5、8、13、21、34，....
            //算第30个数
            List<int> nums = new List<int>();
            nums.Add(1);
            nums.Add(1);
            int temp=0;
            for (int i = 2; i < 30; i++)
            {
                temp = nums[i - 1] + nums[i - 2];
                nums.Add(temp);
            }

            Console.WriteLine("Num is:");
            for (int i = 0; i < nums.Count; i++)
            {
                Console.Write(nums[i]+",");
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            // "I am a good man",设计一个函数,返回 "man good a am I"。
            string a = "I am a good man";
            string b = a;
            string result="";
            int tag = 0;
            int length = 0;
            while (b.LastIndexOf(" ")>0) //没有时的值为-1
            {
                tag = b.LastIndexOf(" ");
                length = b.Length-1 - tag;
                result += b.Substring(tag + 1, length)+" ";
                b = b.Substring(0,tag);
            }
           
            result += b;
            Console.WriteLine(result);

            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //99乘法表
            for (int i = 1; i < 10; i++)
            {
                Console.WriteLine(" ");
                for (int j = i; j < 10; j++)
                {
                    Console.Write(i.ToString()+"*"+j.ToString()+"="+i*j+"  ");
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //在1~10000的整数中，找出同时符合以下条件的数：
            //a.必须是质数。b.该数字各位数字之和为偶数，如数字12345，各位数字之和为1+2+3+4+5=15，不是偶数。
            for (int i = 1; i < 10001; i++)
            {
                if (!IsPrimeNumber(i))
                {
                    continue;
                }

                if (IsSumEvenV2(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        private bool IsSumEvenV2(int num)
        {
            int sum=0;
            while (num>0)
            {
                sum += num % 10;
                num = num / 10;
            }

            if (sum % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        private bool IsSumEvenV1(int num)
        {
            int a, b, c, d;
            a = num / 1000;
            b = (num % 1000) / 100;
            c = ((num % 1000) % 100) / 10;
            d = ((num % 1000) % 100) % 10;

            int result = a+b+c+d;

            if (result%2==0)
            {
                return true;
            }
            else
            {
                return false;
            }

            
        }

       private  bool IsPrimeNumber(int num)
        {
            for (int i = 2; i < num-1; i++)
            {
                if (num%i==0)
                {
                    return false;
                }
            }


            return true;
        }


        int[] numsSelection = { 3, 4, 8, 2, 7, 100, 33, 68 };
        private void button10_Click(object sender, EventArgs e)
        {
            //选择排序是一种简单直观的排序算法。它的工作原理如下。
            //首先在未排序列中找到最小的元素，存放到排序序列的起始位置。
            //然后，在从剩余未排序元素中继续寻找最小的元素，放到排序序列末尾。以此类推，直到所有元素均排序完毕。
            int smallestIndex = -1;
            for (int i = 0; i < numsSelection.Length; i++)
            {
                GetSmallest(i, out smallestIndex);
                SwapPlace(i, smallestIndex);
            }

            foreach (int item in numsSelection)
            {
                Console.WriteLine(item);
            }

        }

        private void GetSmallest(int StartIndex,out int SmallIndex)
        {
            SmallIndex = -1;          
            for (int i = StartIndex; i < numsSelection.Length; i++)
            {
                bool m_bSmallest = true;
                for (int j = i+1; j < numsSelection.Length; j++)
                {
                    if (numsSelection[i]> numsSelection[j])
                    { //如果比任何一个大，就不是最小
                        m_bSmallest = false;
                        break;
                    }
                }
                if (m_bSmallest)
                {
                    SmallIndex = i;
                    return; //停止，防止第二个最小数出现
                }
            }
        }

        private void SwapPlace(int IndexStart,int IndexSmall)
        {
            if (IndexStart== IndexSmall)
            {
                return;
            }

            int temp = 0;
            temp = numsSelection[IndexStart];
            numsSelection[IndexStart] = numsSelection[IndexSmall];
            numsSelection[IndexSmall] = temp;
        }
    }
}
