using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MarketInfo
{
    public partial class AdvancedDMForm : Form
    {
        
        static DataTable stockdata = new DataTable();

        public AdvancedDMForm()
        {
            InitializeComponent();
            Init();
        }

        /// <summary>
        /// System Initial 
        /// </summary>
        private void Init()
        {
            AdvStock.mystock = "0";
            currentstockl.Text = "";
            result_dgv.Visible = false;
            flashpoint_dgv.Visible = false;
            flashlight_l.Visible = false;
        }

        /// <summary>
        /// 获取股票代码 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okbutton_Click(object sender, EventArgs e)
        {
            GeneralClass gc = new GeneralClass();
            string stockget = stockntb.Text;
            Stock_Index si = new Stock_Index();

            if (gc.stock_checkout(stockget, ref si))
            {
                AdvStock.mystock = stockget;
                statusl.Text = AdvStock.mystock + " Get";
                currentstockl.Text = si.stockname;
            }
            else
                MessageBox.Show("Error: " + stockget + " is not a stock code.");
        }

        /// <summary>
        ///下载历史数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void getstockdatabt_Click(object sender, EventArgs e)
        {
            GeneralClass gc = new GeneralClass();
            
            statusl.Text = "Download " + AdvStock.mystock + "……";
            string stkcode = AdvStock.mystock;
            if (!gc.downloadstockdata(stkcode))
                statusl.Text = "Download " + AdvStock.mystock + ".csv" + " Failed";
            else         
                statusl.Text = "Download " + AdvStock.mystock + ".csv" + " Successed";  
        }

        /// <summary>
        ///股票代码检查
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stockntb_TextChanged(object sender, EventArgs e)
        {
            GeneralClass gc = new GeneralClass();
            
            if (!gc.IsInt(stockntb.Text))
            {
                MessageBox.Show("Please input stock code!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                stockntb.SelectAll();
                stockntb.Focus();
                return;
            }
        }

        /// <summary>
        /// 打开历史数据文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openhisdata_bt_Click(object sender, EventArgs e)
        {
            string filepath = Directory.GetCurrentDirectory() + "\\" + AdvStock.mystock + ".csv";
            if (File.Exists(filepath))
                System.Diagnostics.Process.Start(filepath);
            else
                MessageBox.Show("File " + AdvStock.mystock + ".csv" + " not exist.");
        }

        /// <summary>
        /// 删除历史数据文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deletehisfile_bt_Click(object sender, EventArgs e)
        {
            string filepath = Directory.GetCurrentDirectory() + "\\" + AdvStock.mystock + ".csv";
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
                statusl.Text = "Delete " + AdvStock.mystock + ".csv" + " successed.";
            }
            else
                MessageBox.Show("File " + AdvStock.mystock + ".csv" + " not exist.");
        }
        /// <summary>
        /// 导入数据到DataTable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void importdatabt_Click(object sender, EventArgs e)
        {
            GeneralClass gc = new GeneralClass();

            string filepath = Directory.GetCurrentDirectory() + "\\" + AdvStock.mystock + ".csv";
            if (File.Exists(filepath))
            {
                statusl.Text = "Importing " + AdvStock.mystock + ".csv" + "……";
                stockdata.Clear();
                stockdata = gc.OpenCSV(filepath);
                statusl.Text = AdvStock.mystock + ".csv" + " data Get.";
                dataGridView.Visible = true;
                dataGridView.DataSource = stockdata;
                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;    //auto columns width
                DatagBox.Text = "Data: " + AdvStock.mystock;
                go_bt.Enabled = true;
            }
            else
                MessageBox.Show("File " + AdvStock.mystock + ".csv" + " not exist.");
        }
        /// <summary>
        /// 分析数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void go_bt_Click(object sender, EventArgs e)
        {
            TradStrategy ts = new TradStrategy();
            //creat datatable
            DataTable result_dt = new DataTable();
            DataTable flashlight_dt = new DataTable();
            //table columns
            DataColumn avgprice_dc = new DataColumn("Avg(P)");
            result_dt.Columns.Add(avgprice_dc);
            DataColumn sdevprice_dc = new DataColumn("Sdev(P)");
            result_dt.Columns.Add(sdevprice_dc);
            DataColumn sdevratioprice_dc = new DataColumn("CV(P)%");
            result_dt.Columns.Add(sdevratioprice_dc);
            DataColumn avgvolume_dc = new DataColumn("Avg(V)");
            result_dt.Columns.Add(avgvolume_dc);
            DataColumn sdevvolume_dc = new DataColumn("Sdev(V)");
            result_dt.Columns.Add(sdevvolume_dc);
            DataColumn sdevratiovolume_dc = new DataColumn("CV(V)%");
            result_dt.Columns.Add(sdevratiovolume_dc);
            DataColumn prate_dc = new DataColumn("GrowthRatio%");
            result_dt.Columns.Add(prate_dc);
            DataColumn aprate_dc = new DataColumn("AGrowthRatio%");
            result_dt.Columns.Add(aprate_dc);

            //stock_trend analysis
            DateTime begintime = begintime_dtp.Value;
            DateTime endtime = endtime_dtp.Value;
            try
            {
                Stock_Index.para_volumeratio = float.Parse(volumeratio_tb.Text);
            }
            catch
            {

            }
            ts.stockdata_analysis(begintime, endtime, stockdata, ref flashlight_dt);

            //Add datarow
            DataRow workrow = result_dt.NewRow();
            workrow[avgprice_dc] = Stock_Index.win_avgprice.ToString("f2");
            workrow[avgvolume_dc] = Stock_Index.win_avgvolume / 100;
            workrow[prate_dc] = (Stock_Index.win_prate * 100).ToString("f2");
            workrow[aprate_dc] = (Stock_Index.win_aprate * 100).ToString("f2");
            workrow[sdevprice_dc] = Stock_Index.win_sdevprice.ToString("f2");
            workrow[sdevvolume_dc] = Stock_Index.win_sdevvolume / 100;
            workrow[sdevratioprice_dc] = (Stock_Index.win_sdevprice / Stock_Index.win_avgprice * 100).ToString("f2");
            workrow[sdevratiovolume_dc] = (Stock_Index.win_sdevvolume / Stock_Index.win_avgvolume * 100).ToString("f2");
            result_dt.Rows.Add(workrow);

            //Show results
            result_dgv.Visible = true;
            result_dgv.DataSource = result_dt;
            result_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;    //auto columns width
            //Show flashpoint
            if (flashlight_dt.Rows.Count != 0)
            {
                flashlight_l.Visible = false;
                flashpoint_dgv.Visible = true;
                flashpoint_dgv.DataSource = flashlight_dt;
                flashpoint_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            else
            {
                flashpoint_dgv.Visible = false;
                flashlight_l.Visible = true;
            }
            statusl.Text = "Compute Success!";

        }
    }
}
