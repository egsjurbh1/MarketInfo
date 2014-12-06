using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace MarketInfo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitReadConfigFile();
        }
        //全局变量
        public class GlobleVar
        {
            public static int time;
            public static String fileName = Directory.GetCurrentDirectory() + "\\stockdata.txt";
            public static String stockfileName = Directory.GetCurrentDirectory() + "\\optionalstock.ini";
            public static String stockmarketurl = "http://image.sinajs.cn/newchart/min/n/";
            public static String stockdataurl = "http://qt.gtimg.cn/q=";
            public static List<string> lns = new List<string>();//声明一个泛型
        }
        //读配置文件
        private void InitReadConfigFile()
        {
            string stock;
            optionallist.Items.Clear();
            GlobleVar.lns.Clear();
            string filepath = GlobleVar.stockfileName;
            FileStream myFs;
            //读Stock文件
            if (Directory.Exists(filepath))
            {
                myFs = new FileStream(filepath, FileMode.Create, FileAccess.ReadWrite);
                myFs.Close();
            }
            StreamReader sw = new StreamReader(filepath, true);

            while (sw.Peek() >= 0)
            {
                stock = sw.ReadLine();
                optionallist.Items.Add(stock);
                GlobleVar.lns.Add(stock);
            }
            sw.Close();
        }

        //及时杀死网关超时的webclient
        public class CNNWebClient : WebClient
        {

            private int _timeOut = 10;

            /**/
            /// <summary>
            /// 过期时间
            /// </summary>
            public int Timeout
            {
                get
                {
                    return _timeOut;
                }
                set
                {
                    if (value <= 0)
                        _timeOut = 10;
                    _timeOut = value;
                }
            }

            /**/
            /// <summary>
            /// 重写GetWebRequest,添加WebRequest对象超时时间
            /// </summary>
            /// <param name="address"></param>
            /// <returns></returns>
            protected override WebRequest GetWebRequest(Uri address)
            {
                HttpWebRequest request = (HttpWebRequest)base.GetWebRequest(address);
                request.Timeout = 1000 * Timeout;
                request.ReadWriteTimeout = 1000 * Timeout;
                return request;
            }
        }

        private void interval_Tick(object sender, EventArgs e)
        {
            string stockdata = "";
  
            ++GlobleVar.time;

            string filepath = GlobleVar.fileName;
            FileStream myFs = new FileStream(filepath, FileMode.Create, FileAccess.ReadWrite);
            //读Stock文件
            //if (!Directory.Exists(filepath))
            //myFs = new FileStream(filepath, FileMode.Create, FileAccess.ReadWrite);
            myFs.Close();
            System.IO.StreamWriter sw = new System.IO.StreamWriter(GlobleVar.fileName, true);
            sw.WriteLine(GlobleVar.time.ToString());

            interval.Interval = Int32.Parse(textBox1.Text);
            interval.Start();
            foreach(string stock in GlobleVar.lns)
            {
                stockmarket_one(stock, ref stockdata);
                sw.WriteLine(stockdata);
            }
            sw.Close();
            //状态显示
            listBox1.Items.Add(DateTime.Now.ToString() + "  " + GlobleVar.time.ToString());// = GlobleVar.time.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
            interval.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //读取数据

            //提取数据
        }

        private void button4_Click(object sender, EventArgs e)
        {
            interval.Interval = Int32.Parse(textBox1.Text);
            textBox1.ReadOnly = true;
        }

        //清空文件
        private void ClearFileBt_Click(object sender, EventArgs e)
        {
            string filepath = GlobleVar.fileName;
           
            //清空行情文件
            File.WriteAllText(filepath, "");
            listBox1.Items.Clear();//清空初始化
            GlobleVar.time = 0;
        }

        //定时刷新
        private void kline1_t_Tick(object sender, EventArgs e, string stockurl)
        {
            kline1_t.Interval = 60000;  //60秒更新一次
            kline1_t.Start();

            SH000001pB.ImageLocation = @stockurl;
        }

        //增加
        private void AddStockbt_Click(object sender, EventArgs e)
        {
            bool isintag = false;
            string stock;
            string filepath = GlobleVar.stockfileName;
            FileStream myFs;
            //读文件
            if (Directory.Exists(filepath))
            {
                myFs = new FileStream(filepath, FileMode.Create, FileAccess.ReadWrite);
                myFs.Close();
            }
            InitReadConfigFile();
            //添加项
            StreamWriter sw = new StreamWriter(GlobleVar.stockfileName, true);
            stock = stockntb.Text;
            if (stock.Length == 6)
            {
                foreach (string s in GlobleVar.lns)
                {
                    if (s == stock)
                    {
                        MessageBox.Show("该股票已加入到自选.");
                        isintag = true;
                        break;
                    }
                }
                if(!isintag)
                    sw.WriteLine(stock);
            }
            else
                MessageBox.Show("股票代码有误.");
            sw.Close();
            
            //读最新文件
            InitReadConfigFile();
        }
        //删除
        private void DeleteStockbt_Click(object sender, EventArgs e)
        {
            string stock;
            InitReadConfigFile();
            //指定要删除的行
            stock = stockntb.Text;
            GlobleVar.lns.Remove(stock);
            File.WriteAllText(GlobleVar.stockfileName, "");
            //写回
            StreamWriter sw = new StreamWriter(GlobleVar.stockfileName, false);
            foreach (string s in GlobleVar.lns)
                sw.WriteLine(s);
            sw.Close();
            
            //读最新文件
            InitReadConfigFile();
        }
        //双击选中
        private void optionallist_DoubleClick(object sender, EventArgs e)
        {
            string stock = "";
            string stockurl = "";
            string stockdataurl = "";
            stockntb.Text = optionallist.Text;
            stock = optionallist.Text;
            //解析
            stock_appendurl(stock, ref stockurl, GlobleVar.stockmarketurl);
            stock_appendurl(stock, ref stockdataurl, GlobleVar.stockdataurl);
            //显示行情
            kline1_t_Tick(sender, e, stockurl);
        }

        //解析拼接股票URL
        private void stock_appendurl(string stock, ref string stockurl, string url)
        {
            string head = stock.Substring(0, 2);

            StringBuilder s = new StringBuilder(url);
            if (head == "60")    //上海
                s.Append("sh");
            else if (head == "00" || head == "30")  //深证
            {
                if (stock != "000001")
                    s.Append("sz");
                else
                    s.Append("sh");
            }
            else if (stock == "399001")
                s.Append("sz");
            else
                throw new Exception("股票代码不正确！");
            s.Append(stock);
            s.Append(".gif");

            stockurl = s.ToString();
        }
        
        //获取单支股票行情 输入股票代码stock
        private void stockmarket_one(string stock, ref string stockdata)
        {         
            string stockurl = "";
            
            CNNWebClient webClient;//通过WebClient方式去获取资源文件
            stock_appendurl(stock, ref stockurl, GlobleVar.stockdataurl);
            Uri uri = new Uri(stockurl, false);
            webClient = new CNNWebClient();
            stockdata = webClient.DownloadString(uri);
            webClient.Dispose(); 
        }
    }


}