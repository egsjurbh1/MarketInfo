namespace MarketInfo
{
    partial class MainForm
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.interval = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.ClearFileBt = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SH000001pB = new System.Windows.Forms.PictureBox();
            this.kline1_t = new System.Windows.Forms.Timer(this.components);
            this.optionallist = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DeleteStockbt = new System.Windows.Forms.Button();
            this.AddStockbt = new System.Windows.Forms.Button();
            this.stockntb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SH000001pB)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(5, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "数据记录开始";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.interval_Tick);
            // 
            // interval
            // 
            this.interval.Interval = 3000;
            this.interval.Tick += new System.EventHandler(this.interval_Tick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(119, 71);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "数据记录结束";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(19, 22);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(236, 208);
            this.listBox1.TabIndex = 3;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(5, 101);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "数据提取";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(104, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(88, 21);
            this.textBox1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "提取间隔(ms)";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(64, 42);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "确定";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // ClearFileBt
            // 
            this.ClearFileBt.Location = new System.Drawing.Point(119, 100);
            this.ClearFileBt.Margin = new System.Windows.Forms.Padding(2);
            this.ClearFileBt.Name = "ClearFileBt";
            this.ClearFileBt.Size = new System.Drawing.Size(73, 23);
            this.ClearFileBt.TabIndex = 8;
            this.ClearFileBt.Text = "清空文件";
            this.ClearFileBt.UseVisualStyleBackColor = true;
            this.ClearFileBt.Click += new System.EventHandler(this.ClearFileBt_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ClearFileBt);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Location = new System.Drawing.Point(19, 258);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(235, 138);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "参数";
            // 
            // SH000001pB
            // 
            this.SH000001pB.ImageLocation = "";
            this.SH000001pB.Location = new System.Drawing.Point(276, 22);
            this.SH000001pB.Margin = new System.Windows.Forms.Padding(2);
            this.SH000001pB.Name = "SH000001pB";
            this.SH000001pB.Size = new System.Drawing.Size(596, 259);
            this.SH000001pB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.SH000001pB.TabIndex = 10;
            this.SH000001pB.TabStop = false;
            // 
            // optionallist
            // 
            this.optionallist.FormattingEnabled = true;
            this.optionallist.ItemHeight = 12;
            this.optionallist.Location = new System.Drawing.Point(891, 22);
            this.optionallist.Margin = new System.Windows.Forms.Padding(2);
            this.optionallist.Name = "optionallist";
            this.optionallist.Size = new System.Drawing.Size(168, 208);
            this.optionallist.Sorted = true;
            this.optionallist.TabIndex = 12;
            this.optionallist.DoubleClick += new System.EventHandler(this.optionallist_DoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DeleteStockbt);
            this.groupBox2.Controls.Add(this.AddStockbt);
            this.groupBox2.Controls.Add(this.stockntb);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(893, 243);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(166, 139);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "管理";
            // 
            // DeleteStockbt
            // 
            this.DeleteStockbt.Location = new System.Drawing.Point(95, 47);
            this.DeleteStockbt.Margin = new System.Windows.Forms.Padding(2);
            this.DeleteStockbt.Name = "DeleteStockbt";
            this.DeleteStockbt.Size = new System.Drawing.Size(56, 23);
            this.DeleteStockbt.TabIndex = 10;
            this.DeleteStockbt.Text = "删除";
            this.DeleteStockbt.UseVisualStyleBackColor = true;
            this.DeleteStockbt.Click += new System.EventHandler(this.DeleteStockbt_Click);
            // 
            // AddStockbt
            // 
            this.AddStockbt.Location = new System.Drawing.Point(14, 47);
            this.AddStockbt.Margin = new System.Windows.Forms.Padding(2);
            this.AddStockbt.Name = "AddStockbt";
            this.AddStockbt.Size = new System.Drawing.Size(56, 23);
            this.AddStockbt.TabIndex = 9;
            this.AddStockbt.Text = "增加";
            this.AddStockbt.UseVisualStyleBackColor = true;
            this.AddStockbt.Click += new System.EventHandler(this.AddStockbt_Click);
            // 
            // stockntb
            // 
            this.stockntb.Location = new System.Drawing.Point(65, 18);
            this.stockntb.Margin = new System.Windows.Forms.Padding(2);
            this.stockntb.Name = "stockntb";
            this.stockntb.Size = new System.Drawing.Size(86, 21);
            this.stockntb.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "股票代码：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "控制台信息";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(889, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "自选股";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(274, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 16;
            this.label5.Text = "行情";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 401);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.optionallist);
            this.Controls.Add(this.SH000001pB);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listBox1);
            this.Name = "MainForm";
            this.Text = "MarketInfoV0.1.1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SH000001pB)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer interval;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button ClearFileBt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox SH000001pB;
        private System.Windows.Forms.Timer kline1_t;
        private System.Windows.Forms.ListBox optionallist;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button DeleteStockbt;
        private System.Windows.Forms.Button AddStockbt;
        private System.Windows.Forms.TextBox stockntb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

