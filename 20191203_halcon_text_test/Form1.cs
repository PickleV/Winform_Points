using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HalconDotNet;

namespace _20191203_halcon_text_test
{
    public partial class Form1 : Form
    {
        HTuple hv_WindowHandle = null;

        public Form1()
        {
            InitializeComponent();
            
            HOperatorSet.OpenWindow(0, 0, pictureBox1.Width, pictureBox1.Height, pictureBox1.Handle, "visible", "", out hv_WindowHandle);
            HDevWindowStack.Push(hv_WindowHandle); //窗口放到堆栈    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog(); //新建立打开文件对象
                                                                  //openFileDialog.Title = "请选择文件"; //打开的文件选择对话框上的标题,如果需要标题的话！
            openFileDialog.Filter = "所有文件(*.*)|*.*";   //设置文件类型
                                                                         // open.Filter = "CSV文件(*.csv)|*.csv|XML文件(*.xml)|*.xml|文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            openFileDialog.FilterIndex = 1; //设置默认文件类型显示顺序
            openFileDialog.RestoreDirectory = true;//保存对话框是否记忆上次打开的目录
                                                   //openFileDialog.Multiselect = false;//设置是否允许多选,默认为单选

            HObject theImage = null;
            if (openFileDialog.ShowDialog() == DialogResult.OK)//按下确定选择的按钮
            {
                string localFilePath = openFileDialog.FileName.ToString(); //获得文件路径
                HOperatorSet.ReadImage(out theImage, localFilePath);
                HalconDisplay(theImage,hv_WindowHandle);

 



            }
        }


        private void HalconDisplay(HObject theImage,HTuple theWindow)
        {
            HOperatorSet.ClearWindow(theWindow);
            HTuple w, h;
            HOperatorSet.GetImageSize(theImage,out w,out h);
            HOperatorSet.SetPart(theWindow,0,0,h,w);
            HOperatorSet.DispObj(theImage, theWindow);

        }

        private void button2_Click(object sender, EventArgs e)
        {

            //复制这个dll就好了
           // hcanvas.dll

                        //文字
                        HTuple hv_Font, hv_Colors;
            HOperatorSet.QueryFont(hv_WindowHandle, out hv_Font);
            HOperatorSet.QueryColor(hv_WindowHandle, out hv_Colors);
             HOperatorSet.SetFont(hv_WindowHandle, "Arial-Bold-30");
            HOperatorSet.DispText(hv_WindowHandle, "hello", "window", "top",
   "left", "green", new HTuple(), new HTuple());
        }
    }
}
