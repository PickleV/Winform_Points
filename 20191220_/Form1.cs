using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20191220_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //1.new方式实例化一个Task，需要通过Start方法启动
            Task task = new Task(() =>
            {
                Thread.Sleep(100);
                MessageBox.Show($"hello, task1的线程ID为{Thread.CurrentThread.ManagedThreadId}");
               
            });
            task.Start();

            //2.Task.Factory.StartNew(Action action)创建和启动一个Task
            Task task2 = Task.Factory.StartNew(() =>
            {
                Thread.Sleep(100);
                MessageBox.Show($"hello, task2的线程ID为{ Thread.CurrentThread.ManagedThreadId}");
            });

            
            //3.Task.Run(Action action)将任务放在线程池队列，返回并启动一个Task
            //Task.Run ，是在.net 4.5以后才支持！！！，就是简化版本的Task.Factory.StartNew
            //Task task3 = Task.Run(() =>
            //{
            //    Thread.Sleep(100);
            //    MessageBox.Show($"hello, task3的线程ID为{ Thread.CurrentThread.ManagedThreadId}");
            //});


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Task t1 = new Task(Method1);
            t1.Start();
            t1.ContinueWith(Method2);
        }

        private void Method1()
        {
            Thread.Sleep(3000);
            MessageBox.Show("Message 1");
        }

        private void Method2(Task t)
        {
            Thread.Sleep(3000);
            MessageBox.Show("Message 2");



        }

        private void button3_Click(object sender, EventArgs e)
        {
            //不阻塞
            Console.WriteLine("-----不阻塞-------");
            Task task1 = new Task(()=> {
                Console.WriteLine("task1");
            });
            task1.Start();
            Task task2 = Task.Factory.StartNew(()=> {
                Console.WriteLine("task2");
            });

            Console.WriteLine("main thread!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //阻塞.WaitAll (全运行完才行)
            Console.WriteLine("-----阻塞----WaitAll---");
            Task task1 = new Task(() => {
                Console.WriteLine("task1");
            });
            task1.Start();
            Task task2 = Task.Factory.StartNew(() => {
                Console.WriteLine("task2");
            });
            Task.WaitAll(new Task[] {task1,task2 });
            Console.WriteLine("main thread!");

            //阻塞.WaitAny (相当于or)
            Console.WriteLine("-----阻塞----WaitAny---");
             task1 = new Task(() => {
                Console.WriteLine("task1");
            });
            task1.Start();
             task2 = Task.Factory.StartNew(() => {
                Console.WriteLine("task2");
            });
            Task.WaitAny(new Task[] { task1, task2 });//wait any 任何一个task运行完，都会回到主线程
            Console.WriteLine("main thread!");

            //直接阻塞
            Console.WriteLine("-----阻塞----Wait---");
            task1 = new Task(() => {
                Console.WriteLine("task1");
            });
            task1.Start();
            task2 = Task.Factory.StartNew(() => {
                Console.WriteLine("task2");
            });
            task2.Wait();//主线程永远在task2之后
            Console.WriteLine("main thread!");

        }

        //
        Task taskStop;
        CancellationTokenSource cts;
        private void button5_Click(object sender, EventArgs e)
        {
            //task的停止
             cts = new CancellationTokenSource();
             taskStop = new Task(()=> {
                Console.WriteLine("started:");
                int a = 1;
                while (!cts.IsCancellationRequested)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine(a+":"+taskStop.Status);
                    a++;
                }

            });
            taskStop.Start();
           
        

        }

        private void button6_Click(object sender, EventArgs e)
        {
            cts.Cancel();
            Console.WriteLine(taskStop.Status);
           
        }


        //sync
        private void button7_Click(object sender, EventArgs e)
        {

            //Run process
          int TimeSpent=DoSth();        
          Console.WriteLine("Time spent:" + TimeSpent);
        }



        private int DoSth()
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            Int64 result = 0;
            for (int i = 0; i < 33333; i++)
            {
                for (int j = 0; j < 33333; j++)
                {
                    result = i + j;
                }
            }

            //Stop count
            watch.Stop();

            return (int)watch.ElapsedMilliseconds;
        }

        //Wrap the job to async method
        private async Task DoSthASync()
        {
            int time = await Task.Run(() => DoSth());
            Console.WriteLine("Time spent:" + time);
        }

        // async
        private async void button8_Click(object sender, EventArgs e)
        {
          await DoSthASync();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void button9_Click(object sender, EventArgs e)
        {
            int time = await Task.Run(() => DoSth());
            Console.WriteLine("Time spent:" + time);
        }

        private async void button10_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            List<Task<int>> taskGroup = new List<Task<int>>();  //create a group of tasks

            //add tasks to group  (4 times)
            taskGroup.Add(Task.Run(() => DoSth()));
            taskGroup.Add(Task.Run(() => DoSth()));
            taskGroup.Add(Task.Run(() => DoSth()));
            taskGroup.Add(Task.Run(() => DoSth()));

            //Get result of all
            int[] results = await Task.WhenAll(taskGroup);

            for (int i = 0; i < results.Count(); i++)
            {
                Console.WriteLine("Time split "+i +":"+ results[i]);
            }

            //Display the result
            Console.WriteLine("Time spent total:" + watch.ElapsedMilliseconds);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            List<Task<int>> taskGroup = new List<Task<int>>();  //create a group of tasks
            List<int> results = new List<int>(); //store result

            //add tasks to group  (4 times)
            DoSth();
            DoSth();
            DoSth();
            DoSth();

            //Display the result
            Console.WriteLine("Time spent:" + watch.ElapsedMilliseconds);
        }

        private async void button12_Click(object sender, EventArgs e)
        {
            await Task.Run(()=> DelayTest3());
            await DelayTest2();
        }

        private async Task DelayTest()
        {
            Console.WriteLine("Test1:"+DateTime.Now.ToString());
            await Task.Delay(3000);
            Console.WriteLine("Test1:" + DateTime.Now.ToString());
            await Task.Delay(3000);
            Console.WriteLine("Test1:" + DateTime.Now.ToString());
        }

        private async Task DelayTest2()
        {
            Console.WriteLine("Test2:" + DateTime.Now.ToString());
            await Task.Delay(3000);
            Console.WriteLine("Test2:" + DateTime.Now.ToString());
            await Task.Delay(3000);
            Console.WriteLine("Test2:" + DateTime.Now.ToString());
        }

        private void DelayTest3()
        {
            Console.WriteLine("Test2:" + DateTime.Now.ToString());
            Thread.Sleep(3000);
            Console.WriteLine("Test2:" + DateTime.Now.ToString());
            Thread.Sleep(3000);
            Console.WriteLine("Test2:" + DateTime.Now.ToString());
        }

        private async void button13_Click(object sender, EventArgs e)
        {
            //Start to run
            Debug.WriteLine("___Started: ");

            Task<Result> tA = Task.Run(()=>RunTask("A")); //Task method 1, normal method
            Task<Result> tB=  RunTaskAsync("B"); //Task method 2, async method

            //Wait for first task
            Task<Result> FinsihedTask= await Task.WhenAny(tA,tB);

            //Display result
            string sTask = FinsihedTask.Result.TaskName;
            bool bResult = FinsihedTask.Result.IsSuccess;
            Debug.WriteLine("Task "+ sTask+" Finished first. Result is:"+ bResult.ToString());

            //Wait for task A and B finish
            await Task.WhenAll(tA, tB);

            ////Run Task 3 after Task A and B
            Task<Result> tC = new Task<Result>(() => RunTask("C")); //Start method 2
            tC.Start();
            
            //Once task C finished, continue with an simple print
            await tC.ContinueWith(taskC => {
                Debug.WriteLine("Run After Task C Finished.");            
            });
        }

        //Task process method 1 async
        private async Task<Result> RunTaskAsync(string TaskName)
        {
            //Init result
            Result result = GenRandomResult();
            result.TaskName = TaskName;//Set Task name;

            //Simulate task finish
            Stopwatch watch = new Stopwatch();
            watch.Start();

            //Wait for task to finish
            while (watch.ElapsedMilliseconds<result.TimeSpending)
            {
               await Task.Delay(1);
            }


            watch.Stop();

            //Show result
            Debug.WriteLine("Task "+TaskName+" Finished in "+ result.TimeSpending+" ms, result is:"+result.IsSuccess);

            //Pass all steps
            return result;
        }


        //Task process method 2 sync
        private  Result RunTask(string TaskName)
        {
            //Init result
            Result result = GenRandomResult();
            result.TaskName = TaskName;//Set Task name;

            //Simulate task finish
            Stopwatch watch = new Stopwatch();
            watch.Start();

            //Wait for task to finish
            while (watch.ElapsedMilliseconds < result.TimeSpending)
            {
                Thread.Sleep(1);
                Application.DoEvents();
            }

            watch.Stop();

            //Show result
            Debug.WriteLine("Task " + TaskName + " Finished in " + result.TimeSpending + " ms, result is:" + result.IsSuccess);

            //Pass all steps
            return result;
        }

        //Random result generator
        private Result GenRandomResult()
        {
            Result result = new Result(); //Init value
            //Notice random will gave same value if use frequently without the seed value.
            //So we need a random int to make sure random works properly
            Random random = new Random(GetRandomInt()); //Init random
            result.IsSuccess = random.Next(0, 2) == 1 ? true : false; //Job will success or fail
            result.TimeSpending=random.NextDouble()*5000; // Spending time in 0-5000 ms
           
            //Pass all steps
            return result;
        }

        //Get random int
        private int GetRandomInt()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] bInt = new byte[4];
            rng.GetBytes(bInt);
            return BitConverter.ToInt32(bInt,0);
        }
       



        //Return result struct
        private struct Result
        {
            public bool IsSuccess; //Is Job done or not
            public double TimeSpending; //Time consuming on each task in ms
            public string TaskName;
        }

        private async void button14_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Restart();
            Thread.Sleep(10);
            Console.WriteLine("Thread Test 1:"+watch.ElapsedMilliseconds);
            watch.Restart();
            await Task.Delay(10);
            Console.WriteLine("Task Test 1:" + watch.ElapsedMilliseconds);

            //Test 2
            watch.Restart();
            Thread.Sleep(100);
            Console.WriteLine("Thread Test 2:" + watch.ElapsedMilliseconds);
            watch.Restart();
            await Task.Delay(100);
            Console.WriteLine("Task Test 2:" + watch.ElapsedMilliseconds);

        }
    }
}
