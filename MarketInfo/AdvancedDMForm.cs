using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Globalization;

namespace MarketInfo
{
    public partial class AdvancedDMForm : Form
    {
        static string stock = "";
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
            stock = "0";
            currentstockl.Text = "";
            result_dgv.Visible = false;
            flashpoint_dgv.Visible = false;
            flashlight_l.Visible = false;
        }

        /// <summary>
        /// Get stock code 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okbutton_Click(object sender, EventArgs e)
        {
            GeneralClass gc = new GeneralClass();
            string stockget = stockntb.Text;

            if (gc.stock_markettype(stockget) == 1 || gc.stock_markettype(stockget) == 2)
            {
                stock = stockget;
                statusl.Text = stock + " Get";
                currentstockl.Text = stock;
            }
            else
                MessageBox.Show("Error: " + stockget + " is not a stock code.");
        }

        /// <summary>
        /// Download daliy history data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void getstockdatabt_Click(object sender, EventArgs e)
        {
            GeneralClass gc = new GeneralClass();
            string filepath = CfgStruct.hisdatafilepath;
            bool IsStockCode = false;

            StringBuilder sburl = new StringBuilder(CfgStruct.market_daily_his_url);
            sburl.Append(stock);
            string newfilename = "\\" + stock + ".csv";
            int market_code = gc.stock_markettype(stock);
            switch (market_code)
            {
                case 1:
                    sburl.Append(".ss");
                    IsStockCode = true;
                    break;
                case 2:
                    sburl.Append(".sz");
                    IsStockCode = true;
                    break;
                default:
                    MessageBox.Show("Stock code error!");
                    IsStockCode = false;
                    break;
            }

            if (IsStockCode)
            {
                statusl.Text = "Download " + stock + "……";
                string url = sburl.ToString();

                if (!gc.DownloadFile(url, filepath))
                    MessageBox.Show(stock + " Download Error!");
                else
                {
                    //每次下载覆盖
                    File.Copy(filepath, Directory.GetCurrentDirectory() + newfilename, true);
                    statusl.Text = "Download " + stock + ".csv" + " Successed";
                }
            }
        }

        /// <summary>
        /// Textbox real-time dectction
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
        /// open history data file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openhisdata_bt_Click(object sender, EventArgs e)
        {
            string filepath = Directory.GetCurrentDirectory() + "\\" + stock + ".csv";
            if (File.Exists(filepath))
                System.Diagnostics.Process.Start(filepath);
            else
                MessageBox.Show("File " + stock + ".csv" + " not exist.");
        }

        /// <summary>
        /// Delete history file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deletehisfile_bt_Click(object sender, EventArgs e)
        {
            string filepath = Directory.GetCurrentDirectory() + "\\" + stock + ".csv";
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
                statusl.Text = "Delete " + stock + ".csv" + " successed.";
            }
            else
                MessageBox.Show("File " + stock + ".csv" + " not exist.");
        }
        /// <summary>
        /// Import data to DataTable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void importdatabt_Click(object sender, EventArgs e)
        {
            GeneralClass gc = new GeneralClass();

            string filepath = Directory.GetCurrentDirectory() + "\\" + stock + ".csv";
            if (File.Exists(filepath))
            {
                statusl.Text = "Importing " + stock + ".csv" + "……";
                stockdata.Clear();
                stockdata = gc.OpenCSV(filepath);
                statusl.Text = stock + ".csv" + " data Get.";
                dataGridView.Visible = true;
                dataGridView.DataSource = stockdata;
                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;    //auto columns width
                DatagBox.Text = "Data: " + stock;
                go_bt.Enabled = true;
            }
            else
                MessageBox.Show("File " + stock + ".csv" + " not exist.");
        }
        /// <summary>
        /// go and analysis
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
