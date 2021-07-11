using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace _20190814_class6_Event
{
    static class Program
    {

        public class PlayMusic
        {
            public delegate void  PlayerEventHandler(); //定义一个委托
            public event PlayerEventHandler PlayerPlaying; //定义一个委托的事件
            protected virtual void OnPlayerPlaying()
            {
                if(PlayerPlaying!=null)
                {
                    Console.WriteLine("事件触发！");
                    PlayerPlaying();
                }
                else
                {
                    Console.WriteLine("事件没有触发！");
                }
            }


        }
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            //-------

            PlayMusic e = new PlayMusic();
            e.PlayerPlaying += OnPayperPlaying; //绑定
                //EventArgs e = new EventArgs();
                //delplayover(this.e);  //事件触发
            
            //-------------------
        }


        public static void OnPayperPlaying()
        {
            
            MessageBox.Show("测试吧！");
        }
    }
}
