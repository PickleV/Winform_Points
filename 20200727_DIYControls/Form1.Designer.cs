namespace _20200727_DIYControls
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.可调时钟1 = new UserControlLibrary.可调时钟();
            this.工控仪表盘1 = new UserControlLibrary.工控仪表盘();
            this.扇形进度条1 = new UserControlLibrary.扇形进度条();
            this.水平滑动条1 = new UserControlLibrary.水平滑动条();
            this.环形进度条1 = new UserControlLibrary.环形进度条();
            this.SuspendLayout();
            // 
            // 可调时钟1
            // 
            this.可调时钟1.BackColor = System.Drawing.Color.Transparent;
            this.可调时钟1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("可调时钟1.BackgroundImage")));
            this.可调时钟1.Location = new System.Drawing.Point(24, 30);
            this.可调时钟1.MaximumSize = new System.Drawing.Size(255, 255);
            this.可调时钟1.MinimumSize = new System.Drawing.Size(255, 255);
            this.可调时钟1.Name = "可调时钟1";
            this.可调时钟1.Size = new System.Drawing.Size(255, 255);
            this.可调时钟1.TabIndex = 0;
            // 
            // 工控仪表盘1
            // 
            this.工控仪表盘1.BackColor = System.Drawing.Color.Transparent;
            this.工控仪表盘1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("工控仪表盘1.BackgroundImage")));
            this.工控仪表盘1.Location = new System.Drawing.Point(571, 30);
            this.工控仪表盘1.MaximumSize = new System.Drawing.Size(300, 300);
            this.工控仪表盘1.MinimumSize = new System.Drawing.Size(300, 300);
            this.工控仪表盘1.Name = "工控仪表盘1";
            this.工控仪表盘1.Size = new System.Drawing.Size(300, 300);
            this.工控仪表盘1.TabIndex = 1;
            this.工控仪表盘1.ValueMax = 100D;
            this.工控仪表盘1.ValueVal = 0D;
            // 
            // 扇形进度条1
            // 
            this.扇形进度条1.BackColor = System.Drawing.Color.Transparent;
            this.扇形进度条1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("扇形进度条1.BackgroundImage")));
            this.扇形进度条1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.扇形进度条1.Location = new System.Drawing.Point(42, 323);
            this.扇形进度条1.MaxValue = 100;
            this.扇形进度条1.MinValue = 0;
            this.扇形进度条1.Name = "扇形进度条1";
            this.扇形进度条1.Size = new System.Drawing.Size(175, 167);
            this.扇形进度条1.TabIndex = 2;
            this.扇形进度条1.TextFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            this.扇形进度条1.Value = 50F;
            this.扇形进度条1.上层颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.扇形进度条1.底层颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            this.扇形进度条1.状态颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(83)))));
            this.扇形进度条1.环形宽度 = 20F;
            // 
            // 水平滑动条1
            // 
            this.水平滑动条1.BackColor = System.Drawing.Color.Transparent;
            this.水平滑动条1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("水平滑动条1.BackgroundImage")));
            this.水平滑动条1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.水平滑动条1.Location = new System.Drawing.Point(361, 354);
            this.水平滑动条1.MaxValue = 100D;
            this.水平滑动条1.MinValue = 0D;
            this.水平滑动条1.Name = "水平滑动条1";
            this.水平滑动条1.Size = new System.Drawing.Size(371, 45);
            this.水平滑动条1.TabIndex = 3;
            this.水平滑动条1.底层颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            this.水平滑动条1.当前值 = 20D;
            this.水平滑动条1.是否显示标签 = false;
            this.水平滑动条1.进度条颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(195)))), ((int)(((byte)(69)))));
            // 
            // 环形进度条1
            // 
            this.环形进度条1.BackColor = System.Drawing.Color.Transparent;
            this.环形进度条1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("环形进度条1.BackgroundImage")));
            this.环形进度条1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.环形进度条1.Location = new System.Drawing.Point(295, 75);
            this.环形进度条1.MaxValue = 100;
            this.环形进度条1.MinValue = 0;
            this.环形进度条1.Name = "环形进度条1";
            this.环形进度条1.Size = new System.Drawing.Size(246, 229);
            this.环形进度条1.TabIndex = 4;
            this.环形进度条1.Value = 50F;
            this.环形进度条1.底层颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            this.环形进度条1.环条宽度 = 20F;
            this.环形进度条1.环条颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(83)))));
            this.环形进度条1.颜色起始位置 = -90F;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 542);
            this.Controls.Add(this.环形进度条1);
            this.Controls.Add(this.水平滑动条1);
            this.Controls.Add(this.扇形进度条1);
            this.Controls.Add(this.工控仪表盘1);
            this.Controls.Add(this.可调时钟1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControlLibrary.可调时钟 可调时钟1;
        private UserControlLibrary.工控仪表盘 工控仪表盘1;
        private UserControlLibrary.扇形进度条 扇形进度条1;
        private UserControlLibrary.水平滑动条 水平滑动条1;
        private UserControlLibrary.环形进度条 环形进度条1;
    }
}

