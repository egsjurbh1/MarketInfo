namespace MarketInfo
{
    partial class BatchAnalysisForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btExport = new System.Windows.Forms.Button();
            this.btAnalysis = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.endtime_dtp = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.begintime_dtp = new System.Windows.Forms.DateTimePicker();
            this.btGetData = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.processbar = new System.Windows.Forms.ProgressBar();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btExport);
            this.panel1.Controls.Add(this.btAnalysis);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.endtime_dtp);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.begintime_dtp);
            this.panel1.Controls.Add(this.btGetData);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(869, 67);
            this.panel1.TabIndex = 0;
            // 
            // btExport
            // 
            this.btExport.Location = new System.Drawing.Point(771, 10);
            this.btExport.Name = "btExport";
            this.btExport.Size = new System.Drawing.Size(80, 23);
            this.btExport.TabIndex = 18;
            this.btExport.Text = "导出结果";
            this.btExport.UseVisualStyleBackColor = true;
            // 
            // btAnalysis
            // 
            this.btAnalysis.Location = new System.Drawing.Point(676, 10);
            this.btAnalysis.Name = "btAnalysis";
            this.btAnalysis.Size = new System.Drawing.Size(80, 23);
            this.btAnalysis.TabIndex = 17;
            this.btAnalysis.Text = "分析数据";
            this.btAnalysis.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(492, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 16;
            this.label1.Text = "Model:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(539, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(103, 20);
            this.comboBox1.TabIndex = 15;
            // 
            // endtime_dtp
            // 
            this.endtime_dtp.Location = new System.Drawing.Point(369, 12);
            this.endtime_dtp.Name = "endtime_dtp";
            this.endtime_dtp.Size = new System.Drawing.Size(107, 21);
            this.endtime_dtp.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(310, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "EndDate:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(115, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "BeginDate:";
            // 
            // begintime_dtp
            // 
            this.begintime_dtp.Location = new System.Drawing.Point(186, 12);
            this.begintime_dtp.Name = "begintime_dtp";
            this.begintime_dtp.Size = new System.Drawing.Size(107, 21);
            this.begintime_dtp.TabIndex = 11;
            // 
            // btGetData
            // 
            this.btGetData.Location = new System.Drawing.Point(12, 10);
            this.btGetData.Name = "btGetData";
            this.btGetData.Size = new System.Drawing.Size(91, 23);
            this.btGetData.TabIndex = 0;
            this.btGetData.Text = "下载历史数据";
            this.btGetData.UseVisualStyleBackColor = true;
            this.btGetData.Click += new System.EventHandler(this.btGetData_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.processbar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 284);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(869, 79);
            this.panel2.TabIndex = 1;
            // 
            // processbar
            // 
            this.processbar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.processbar.Location = new System.Drawing.Point(0, 62);
            this.processbar.Name = "processbar";
            this.processbar.Size = new System.Drawing.Size(869, 17);
            this.processbar.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 67);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(869, 217);
            this.panel3.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(869, 217);
            this.dataGridView1.TabIndex = 0;
            // 
            // BatchAnalysisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 363);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "BatchAnalysisForm";
            this.Text = "批量分析";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btGetData;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ProgressBar processbar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DateTimePicker begintime_dtp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btExport;
        private System.Windows.Forms.Button btAnalysis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DateTimePicker endtime_dtp;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}