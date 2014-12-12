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

        //System Initial 
        private void Init()
        {
            stock = "0";
        }

        //Get stock code 
        private void okbutton_Click(object sender, EventArgs e)
        {
            GeneralClass gc = new GeneralClass();
            string stockget = stockntb.Text;

            if (gc.stock_markettype(stockget) == 1 || gc.stock_markettype(stockget) == 2)
            {
                stock = stockget;
                statusl.Text = stock + " Get";
            }
            else
                MessageBox.Show("Error: " + stockget + " is not a stock code.");
        }

        //Download daliy history data
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
                    //修改文件名
                    bool isExist = File.Exists(Directory.GetCurrentDirectory() + newfilename);
                    if (!isExist)
                        File.Copy(filepath, Directory.GetCurrentDirectory() + newfilename);
                    statusl.Text = "Download " + stock + ".csv" + " Successed";
                }
            }
        }

        //Textbox real-time dectction
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

        //open history data file
        private void openhisdata_bt_Click(object sender, EventArgs e)
        {
            string filepath = Directory.GetCurrentDirectory() + "\\" + stock + ".csv";
            if (File.Exists(filepath))
                System.Diagnostics.Process.Start(filepath);
            else
                MessageBox.Show("File " + stock + ".csv" + " not exist.");
        }

        //Delete history file
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

        //Import data to DataTable
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
                
            }
            else
                MessageBox.Show("File " + stock + ".csv" + " not exist.");
        }
    }
}
