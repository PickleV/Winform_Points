using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20190820_SQLServer
{
    public partial class Main : Form

    {
      
       

        public Main()
        {
            InitializeComponent();
         
        }

        

        private void bUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count==0)
            {
                MessageBox.Show("请先查询出数据，再点击修改！");
            }
            else
            {
                WInUpdate wInUpdate = new WInUpdate(dataGridView1);
                wInUpdate.ShowDialog();
            }
          
        }

        private void bSelect_Click(object sender, EventArgs e)
        {
            bool flag = false;
            foreach (var item in Application.OpenForms)
            {
                if (item is WinSelect)
                {
                    
                    flag = true;
                    
                }
            }

            if (flag == false)
            {
                WinSelect winSelect = new WinSelect(this);
                winSelect.Show();
            }


        }

        private void bInsert_Click(object sender, EventArgs e)
        {
           
            foreach (var item in Application.OpenForms)
            {
                if (item is WinInsert)
                {
                    return; //直接跳出事件
                }
            }        
                WinInsert winInsert = new WinInsert();
                winInsert.Show();                
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Thread tInstance = new Thread(GetInstances);
            tInstance.Start();
            //

        }


        private void GetInstances()
        {
            MessageBox.Show("正在读取实例列表，请等待！");
            //SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
            //DataTable theTable = instance.GetDataSources();
            DataTable theTable = SqlDataSourceEnumerator.Instance.GetDataSources();
            MessageBox.Show("实例数为："+theTable.Rows.Count.ToString()+"个！");
            //BindingSource theSource = new BindingSource();        
            //theSource.DataSource = theTable.DefaultView;
            this.Invoke(new MethodInvoker(delegate{ dataGridView1.DataSource = theTable; }));
        //    dataGridView1.DataSource = theTable.DefaultView;

        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                if (Application.OpenForms[i] is WinDelete)
                {
                    Application.OpenForms[i].Activate(); //显示窗体到前台
                    //Application.OpenForms[i].Show();

                    return;
                }         
            }
            WinDelete winDelete = new WinDelete();
            winDelete.Show();
        }

        private void bImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "CSV文件(*.csv)|*.csv|XML文件(*.xml)|*.xml|文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            open.ShowDialog();
        }

        private void 连接ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
