namespace MarketInfo
{
    partial class AdvancedDMForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.currentstockl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.importdatabt = new System.Windows.Forms.Button();
            this.okbutton = new System.Windows.Forms.Button();
            this.deletehisfile_bt = new System.Windows.Forms.Button();
            this.openhisdata_bt = new System.Windows.Forms.Button();
            this.getstockdatabt = new System.Windows.Forms.Button();
            this.stockntb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusl = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DatagBox = new System.Windows.Forms.GroupBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.begintime_dtp = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.endtime_dtp = new System.Windows.Forms.DateTimePicker();
            this.go_bt = new System.Windows.Forms.Button();
            this.result_dgv = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.DatagBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.result_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.currentstockl);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.importdatabt);
            this.groupBox1.Controls.Add(this.okbutton);
            this.groupBox1.Controls.Add(this.deletehisfile_bt);
            this.groupBox1.Controls.Add(this.openhisdata_bt);
            this.groupBox1.Controls.Add(this.getstockdatabt);
            this.groupBox1.Controls.Add(this.stockntb);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(271, 135);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "STEP1: Getting Stock Data ";
            // 
            // currentstockl
            // 
            this.currentstockl.AutoSize = true;
            this.currentstockl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.currentstockl.Location = new System.Drawing.Point(88, 55);
            this.currentstockl.Name = "currentstockl";
            this.currentstockl.Size = new System.Drawing.Size(29, 12);
            this.currentstockl.TabIndex = 19;
            this.currentstockl.Text = "text";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(32, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "Current:";
            // 
            // importdatabt
            // 
            this.importdatabt.Location = new System.Drawing.Point(16, 102);
            this.importdatabt.Name = "importdatabt";
            this.importdatabt.Size = new System.Drawing.Size(99, 23);
            this.importdatabt.TabIndex = 17;
            this.importdatabt.Text = "Import Data";
            this.importdatabt.UseVisualStyleBackColor = true;
            this.importdatabt.Click += new System.EventHandler(this.importdatabt_Click);
            // 
            // okbutton
            // 
            this.okbutton.Location = new System.Drawing.Point(169, 26);
            this.okbutton.Name = "okbutton";
            this.okbutton.Size = new System.Drawing.Size(56, 21);
            this.okbutton.TabIndex = 16;
            this.okbutton.Text = "OK";
            this.okbutton.UseVisualStyleBackColor = true;
            this.okbutton.Click += new System.EventHandler(this.okbutton_Click);
            // 
            // deletehisfile_bt
            // 
            this.deletehisfile_bt.Location = new System.Drawing.Point(164, 102);
            this.deletehisfile_bt.Name = "deletehisfile_bt";
            this.deletehisfile_bt.Size = new System.Drawing.Size(62, 23);
            this.deletehisfile_bt.TabIndex = 15;
            this.deletehisfile_bt.Text = "Delete";
            this.deletehisfile_bt.UseVisualStyleBackColor = true;
            this.deletehisfile_bt.Click += new System.EventHandler(this.deletehisfile_bt_Click);
            // 
            // openhisdata_bt
            // 
            this.openhisdata_bt.Location = new System.Drawing.Point(164, 75);
            this.openhisdata_bt.Name = "openhisdata_bt";
            this.openhisdata_bt.Size = new System.Drawing.Size(61, 23);
            this.openhisdata_bt.TabIndex = 14;
            this.openhisdata_bt.Text = "Open";
            this.openhisdata_bt.UseVisualStyleBackColor = true;
            this.openhisdata_bt.Click += new System.EventHandler(this.openhisdata_bt_Click);
            // 
            // getstockdatabt
            // 
            this.getstockdatabt.Location = new System.Drawing.Point(16, 75);
            this.getstockdatabt.Name = "getstockdatabt";
            this.getstockdatabt.Size = new System.Drawing.Size(98, 23);
            this.getstockdatabt.TabIndex = 13;
            this.getstockdatabt.Text = "Download Data";
            this.getstockdatabt.UseVisualStyleBackColor = true;
            this.getstockdatabt.Click += new System.EventHandler(this.getstockdatabt_Click);
            // 
            // stockntb
            // 
            this.stockntb.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.stockntb.Location = new System.Drawing.Point(89, 26);
            this.stockntb.Margin = new System.Windows.Forms.Padding(2);
            this.stockntb.Name = "stockntb";
            this.stockntb.Size = new System.Drawing.Size(62, 21);
            this.stockntb.TabIndex = 10;
            this.stockntb.TextChanged += new System.EventHandler(this.stockntb_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(14, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "Stock Code:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusl});
            this.statusStrip1.Location = new System.Drawing.Point(0, 543);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(869, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusl
            // 
            this.statusl.Name = "statusl";
            this.statusl.Size = new System.Drawing.Size(0, 17);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.go_bt);
            this.groupBox2.Controls.Add(this.endtime_dtp);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.begintime_dtp);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 155);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(271, 385);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "STEP2: Setup Parameters";
            // 
            // DatagBox
            // 
            this.DatagBox.Controls.Add(this.dataGridView);
            this.DatagBox.Location = new System.Drawing.Point(299, 12);
            this.DatagBox.Name = "DatagBox";
            this.DatagBox.Size = new System.Drawing.Size(558, 377);
            this.DatagBox.TabIndex = 3;
            this.DatagBox.TabStop = false;
            this.DatagBox.Text = "Data";
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(11, 20);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.Size = new System.Drawing.Size(535, 351);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.result_dgv);
            this.groupBox3.Location = new System.Drawing.Point(299, 395);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(558, 145);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "STEP3: Results";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(14, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "BeginTime:";
            // 
            // begintime_dtp
            // 
            this.begintime_dtp.Location = new System.Drawing.Point(84, 23);
            this.begintime_dtp.Name = "begintime_dtp";
            this.begintime_dtp.Size = new System.Drawing.Size(107, 21);
            this.begintime_dtp.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(26, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "EndTime:";
            // 
            // endtime_dtp
            // 
            this.endtime_dtp.Location = new System.Drawing.Point(84, 50);
            this.endtime_dtp.Name = "endtime_dtp";
            this.endtime_dtp.Size = new System.Drawing.Size(107, 21);
            this.endtime_dtp.TabIndex = 12;
            // 
            // go_bt
            // 
            this.go_bt.Enabled = false;
            this.go_bt.Location = new System.Drawing.Point(76, 356);
            this.go_bt.Name = "go_bt";
            this.go_bt.Size = new System.Drawing.Size(75, 23);
            this.go_bt.TabIndex = 13;
            this.go_bt.Text = "Go";
            this.go_bt.UseVisualStyleBackColor = true;
            this.go_bt.Click += new System.EventHandler(this.go_bt_Click);
            // 
            // result_dgv
            // 
            this.result_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.result_dgv.Location = new System.Drawing.Point(11, 20);
            this.result_dgv.Name = "result_dgv";
            this.result_dgv.RowTemplate.Height = 23;
            this.result_dgv.Size = new System.Drawing.Size(535, 119);
            this.result_dgv.TabIndex = 0;
            // 
            // AdvancedDMForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 565);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.DatagBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "AdvancedDMForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Advanced Desction Making";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.DatagBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.result_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox stockntb;
        private System.Windows.Forms.Button deletehisfile_bt;
        private System.Windows.Forms.Button openhisdata_bt;
        private System.Windows.Forms.Button getstockdatabt;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusl;
        private System.Windows.Forms.Button okbutton;
        private System.Windows.Forms.Button importdatabt;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox DatagBox;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label currentstockl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker endtime_dtp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker begintime_dtp;
        private System.Windows.Forms.Button go_bt;
        private System.Windows.Forms.DataGridView result_dgv;
    }
}