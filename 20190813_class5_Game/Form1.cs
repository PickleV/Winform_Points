using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _20190813_class5_Game
{
    public partial class Form1 : Form
    {
        public class Player
        {
            public int selectionInt;
            public string selectionString;
            public Player(int a)
            {
                selectionInt = a;
                switch (selectionInt)
                {
                    case 1:
                        selectionString = "石头";
                            break;
                    case 2:
                        selectionString = "剪刀";
                        break;
                    case 3:
                        selectionString = "布";
                        break;
                    default:

                        break;
                }
            }
        }

        private int Judge(int a,int b)
        {
            if (a==b)
            {
                return 3;
            }
            else if ((a==1&&b==2)||(a==2&&b==3)||(a==3&&b==1))
            {
                return 1;
            }
            else if ((a == 1 && b == 3) || (a == 2 && b == 1) || (a == 3 && b == 2))
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            //ofd.FilterIndex
        }
    }
}
