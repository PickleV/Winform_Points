using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20200922_ListView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

            //imagelist
            ImageList iList = new ImageList();
            iList.Images.Add("haha",Image.FromFile("network.png"));
            iList.ImageSize = new Size(128,128);
            ImageList iListMin = new ImageList();
            iListMin = iList;
            iListMin.ImageSize = new Size(12, 12);

            //Set list view
            listView1.Items.Clear();
            listView1.LargeImageList = iList;
            listView1.SmallImageList = iListMin;
          
            for (int i = 0; i < 5; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = "Item"+(i+1);
                item.ImageKey = "haha";
                
                
                listView1.Items.Add(item);
               // item.SubItems.Add("123");

                ListViewItem item1 = new ListViewItem();
                item.Text = "Item00"+(i+1);
                listView1.Items.Add(item1);
            }

           
        }
    }
}
