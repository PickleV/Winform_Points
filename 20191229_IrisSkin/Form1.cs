using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _20191229_IrisSkin
{
    public partial class Form1 : Form
    {

        public Sunisoft.IrisSkin.SkinEngine theSkin;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //仅在首个窗体中添加此代码即可实现所有窗体皮肤
            theSkin = new Sunisoft.IrisSkin.SkinEngine();
            theSkin.SkinFile = "skins/office2007.ssk";
           // new Sunisoft.IrisSkin.SkinEngine().SkinFile = "skins/Calmness.ssk";

            LoadIrisSkins();
        }


        private void LoadIrisSkins()
        {
            string path = Directory.GetCurrentDirectory() + "/skins/";
            DirectoryInfo di = new DirectoryInfo(path);

            foreach (FileInfo fi in di.GetFiles())
            {
                if (fi.Extension==".ssk")
                {
                    treeView1.Nodes.Add(fi.Name.Substring(0,fi.Name.LastIndexOf(".")));
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Index>-1)
            {
                string path = "skins/"+treeView1.SelectedNode.Text + ".ssk";
                //仅在首个窗体中添加此代码即可实现所有窗体皮肤
                //new Sunisoft.IrisSkin.SkinEngine().SkinFile = path;
                theSkin.SkinFile = path;
                if (!theSkin.Active)
                {
                    theSkin.Active = true;
                }
            }
        }
    }
}
