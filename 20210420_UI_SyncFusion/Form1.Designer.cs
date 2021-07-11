
namespace _20210420_UI_SyncFusion
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.currencyTextBox1 = new Syncfusion.Windows.Forms.Tools.CurrencyTextBox();
            this.percentTextBox1 = new Syncfusion.Windows.Forms.Tools.PercentTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.currencyTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.percentTextBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // currencyTextBox1
            // 
            this.currencyTextBox1.DecimalValue = new decimal(new int[] {
            100,
            0,
            0,
            131072});
            this.currencyTextBox1.Location = new System.Drawing.Point(300, 58);
            this.currencyTextBox1.Name = "currencyTextBox1";
            this.currencyTextBox1.Size = new System.Drawing.Size(100, 20);
            this.currencyTextBox1.TabIndex = 0;
            this.currencyTextBox1.Text = "$1.00";
            // 
            // percentTextBox1
            // 
            this.percentTextBox1.Location = new System.Drawing.Point(415, 136);
            this.percentTextBox1.Name = "percentTextBox1";
            this.percentTextBox1.Size = new System.Drawing.Size(100, 20);
            this.percentTextBox1.TabIndex = 1;
            this.percentTextBox1.Text = "0.00%";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.percentTextBox1);
            this.Controls.Add(this.currencyTextBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.currencyTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.percentTextBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.CurrencyTextBox currencyTextBox1;
        private Syncfusion.Windows.Forms.Tools.PercentTextBox percentTextBox1;
    }
}

