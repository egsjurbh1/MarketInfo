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
            this.deletehisfile_bt = new System.Windows.Forms.Button();
            this.openhisdata_bt = new System.Windows.Forms.Button();
            this.getstockdatabt = new System.Windows.Forms.Button();
            this.stockntb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusl = new System.Windows.Forms.ToolStripStatusLabel();
            this.okbutton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.importdatabt = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
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
            // deletehisfile_bt
            // 
            this.deletehisfile_bt.Location = new System.Drawing.Point(163, 98);
            this.deletehisfile_bt.Name = "deletehisfile_bt";
            this.deletehisfile_bt.Size = new System.Drawing.Size(62, 23);
            this.deletehisfile_bt.TabIndex = 15;
            this.deletehisfile_bt.Text = "Delete";
            this.deletehisfile_bt.UseVisualStyleBackColor = true;
            this.deletehisfile_bt.Click += new System.EventHandler(this.deletehisfile_bt_Click);
            // 
            // openhisdata_bt
            // 
            this.openhisdata_bt.Location = new System.Drawing.Point(164, 69);
            this.openhisdata_bt.Name = "openhisdata_bt";
            this.openhisdata_bt.Size = new System.Drawing.Size(61, 23);
            this.openhisdata_bt.TabIndex = 14;
            this.openhisdata_bt.Text = "Open";
            this.openhisdata_bt.UseVisualStyleBackColor = true;
            this.openhisdata_bt.Click += new System.EventHandler(this.openhisdata_bt_Click);
            // 
            // getstockdatabt
            // 
            this.getstockdatabt.Location = new System.Drawing.Point(16, 69);
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
            this.stockntb.Location = new System.Drawing.Point(90, 29);
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
            this.label2.Location = new System.Drawing.Point(14, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "Stock Code:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusl});
            this.statusStrip1.Location = new System.Drawing.Point(0, 399);
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
            // okbutton
            // 
            this.okbutton.Location = new System.Drawing.Point(169, 28);
            this.okbutton.Name = "okbutton";
            this.okbutton.Size = new System.Drawing.Size(56, 21);
            this.okbutton.TabIndex = 16;
            this.okbutton.Text = "OK";
            this.okbutton.UseVisualStyleBackColor = true;
            this.okbutton.Click += new System.EventHandler(this.okbutton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(12, 155);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(271, 234);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "STEP2: Setup Parameters";
            // 
            // importdatabt
            // 
            this.importdatabt.Location = new System.Drawing.Point(16, 98);
            this.importdatabt.Name = "importdatabt";
            this.importdatabt.Size = new System.Drawing.Size(99, 23);
            this.importdatabt.TabIndex = 17;
            this.importdatabt.Text = "Import Data";
            this.importdatabt.UseVisualStyleBackColor = true;
            this.importdatabt.Click += new System.EventHandler(this.importdatabt_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView);
            this.groupBox3.Location = new System.Drawing.Point(299, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(558, 377);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Data";
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
            // AdvancedDMForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 421);
            this.Controls.Add(this.groupBox3);
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
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
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
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridView;
    }
}