namespace _20190820_SQLServer
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bUpdate = new System.Windows.Forms.Button();
            this.bSelect = new System.Windows.Forms.Button();
            this.bDelete = new System.Windows.Forms.Button();
            this.bInsert = new System.Windows.Forms.Button();
            this.数据导入 = new System.Windows.Forms.GroupBox();
            this.bExport = new System.Windows.Forms.Button();
            this.bImport = new System.Windows.Forms.Button();
            this.picGreen = new System.Windows.Forms.PictureBox();
            this.picRed = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.连接ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.数据导入.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRed)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 178);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(818, 429);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bUpdate);
            this.groupBox1.Controls.Add(this.bSelect);
            this.groupBox1.Controls.Add(this.bDelete);
            this.groupBox1.Controls.Add(this.bInsert);
            this.groupBox1.Location = new System.Drawing.Point(12, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(397, 74);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据库操作";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // bUpdate
            // 
            this.bUpdate.Location = new System.Drawing.Point(213, 26);
            this.bUpdate.Name = "bUpdate";
            this.bUpdate.Size = new System.Drawing.Size(75, 25);
            this.bUpdate.TabIndex = 3;
            this.bUpdate.Text = "修改";
            this.bUpdate.UseVisualStyleBackColor = true;
            this.bUpdate.Click += new System.EventHandler(this.bUpdate_Click);
            // 
            // bSelect
            // 
            this.bSelect.Location = new System.Drawing.Point(12, 26);
            this.bSelect.Name = "bSelect";
            this.bSelect.Size = new System.Drawing.Size(75, 25);
            this.bSelect.TabIndex = 2;
            this.bSelect.Text = "查询";
            this.bSelect.UseVisualStyleBackColor = true;
            this.bSelect.Click += new System.EventHandler(this.bSelect_Click);
            // 
            // bDelete
            // 
            this.bDelete.Location = new System.Drawing.Point(304, 26);
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(75, 25);
            this.bDelete.TabIndex = 1;
            this.bDelete.Text = "删除";
            this.bDelete.UseVisualStyleBackColor = true;
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // bInsert
            // 
            this.bInsert.Location = new System.Drawing.Point(111, 26);
            this.bInsert.Name = "bInsert";
            this.bInsert.Size = new System.Drawing.Size(75, 25);
            this.bInsert.TabIndex = 0;
            this.bInsert.Text = "增加";
            this.bInsert.UseVisualStyleBackColor = true;
            this.bInsert.Click += new System.EventHandler(this.bInsert_Click);
            // 
            // 数据导入
            // 
            this.数据导入.Controls.Add(this.bExport);
            this.数据导入.Controls.Add(this.bImport);
            this.数据导入.Location = new System.Drawing.Point(432, 40);
            this.数据导入.Name = "数据导入";
            this.数据导入.Size = new System.Drawing.Size(244, 74);
            this.数据导入.TabIndex = 2;
            this.数据导入.TabStop = false;
            this.数据导入.Text = "文件操作";
            // 
            // bExport
            // 
            this.bExport.Location = new System.Drawing.Point(132, 26);
            this.bExport.Name = "bExport";
            this.bExport.Size = new System.Drawing.Size(75, 25);
            this.bExport.TabIndex = 5;
            this.bExport.Text = "导出";
            this.bExport.UseVisualStyleBackColor = true;
            // 
            // bImport
            // 
            this.bImport.Location = new System.Drawing.Point(39, 26);
            this.bImport.Name = "bImport";
            this.bImport.Size = new System.Drawing.Size(75, 25);
            this.bImport.TabIndex = 4;
            this.bImport.Text = "导入";
            this.bImport.UseVisualStyleBackColor = true;
            this.bImport.Click += new System.EventHandler(this.bImport_Click);
            // 
            // picGreen
            // 
            this.picGreen.Image = ((System.Drawing.Image)(resources.GetObject("picGreen.Image")));
            this.picGreen.Location = new System.Drawing.Point(27, 22);
            this.picGreen.Name = "picGreen";
            this.picGreen.Size = new System.Drawing.Size(42, 46);
            this.picGreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picGreen.TabIndex = 3;
            this.picGreen.TabStop = false;
            this.picGreen.Visible = false;
            // 
            // picRed
            // 
            this.picRed.Image = ((System.Drawing.Image)(resources.GetObject("picRed.Image")));
            this.picRed.Location = new System.Drawing.Point(27, 22);
            this.picRed.Name = "picRed";
            this.picRed.Size = new System.Drawing.Size(42, 46);
            this.picRed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picRed.TabIndex = 4;
            this.picRed.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.连接ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(818, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // 连接ToolStripMenuItem
            // 
            this.连接ToolStripMenuItem.Name = "连接ToolStripMenuItem";
            this.连接ToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.连接ToolStripMenuItem.Text = "连接数据库";
            this.连接ToolStripMenuItem.Click += new System.EventHandler(this.连接ToolStripMenuItem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.picRed);
            this.groupBox2.Controls.Add(this.picGreen);
            this.groupBox2.Location = new System.Drawing.Point(702, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(94, 74);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "连接状态";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 133);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 25);
            this.button1.TabIndex = 7;
            this.button1.Text = "运行有返回值的存储过程";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 607);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.数据导入);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Main";
            this.Text = "SQLServer";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.数据导入.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRed)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bInsert;
        private System.Windows.Forms.Button bUpdate;
        private System.Windows.Forms.Button bSelect;
        private System.Windows.Forms.Button bDelete;
        private System.Windows.Forms.GroupBox 数据导入;
        private System.Windows.Forms.Button bExport;
        private System.Windows.Forms.Button bImport;
        private System.Windows.Forms.PictureBox picGreen;
        private System.Windows.Forms.PictureBox picRed;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 连接ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
    }
}

