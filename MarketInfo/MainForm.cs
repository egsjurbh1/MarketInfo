using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Configuration;

namespace MarketInfo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Init_ReadConfigFile();
            ReadOptionalStockFile();
        }
        //全局变量
        public class CfgStruct
        {
            public static int time;
            public static String stockcur;
            public static String stockurl;
            public static int stock_n;
            public static String fileName;
            public static String stockfileName;
            public static String market_timeline;
            public static String marketlist_t;
            public static String market_dailyk;
            public static String market_weekk;
            public static String market_monthk;
            public static List<string> lns = new List<string>();//声明一个泛型
        }
        //读app.config配置
        private void Init_ReadConfigFile()
        {
            CfgStruct.fileName = Directory.GetCurrentDirectory() + ConfigurationSettings.AppSettings["StockDataFileName"];
            CfgStruct.stockfileName = Directory.GetCurrentDirectory() + ConfigurationSettings.AppSettings["OptionalStockFileName"];
            CfgStruct.marketlist_t = ConfigurationSettings.AppSettings["Marketlist_Tencent"];
            CfgStruct.market_timeline = ConfigurationSettings.AppSettings["Markettimeline_Sina"];
            CfgStruct.market_dailyk = ConfigurationSettings.AppSettings["Marketdailyk_Sina"];
            CfgStruct.market_weekk = ConfigurationSettings.AppSettings["Marketweekk_Sina"];
            CfgStruct.market_monthk = ConfigurationSettings.AppSettings["Marketmonthk_Sina"];
            stockname_l.Visible = false;
            stockprice_l.Visible = false;
            updownpercent_l.Visible = false;
            volumem_l.Visible = false;
            volumev_l.Visible = false;
            preprice_l.Visible = false;
            cirmarketvalue_l.Visible = false;
            totalvalue_l.Visible = false;
            amplitude_l.Visible = false;
            pbratio_l.Visible = false;
            peratio_l.Visible = false;
            turnoverrate_l.Visible = false;
        }
        //读Stock自选文件
        private void ReadOptionalStockFile()
        {
            string stock;
            optionallist.Items.Clear();
            CfgStruct.lns.Clear();
            string filepath = CfgStruct.stockfileName;
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
                CfgStruct.lns.Add(stock);
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
        //抓数据
        private void interval_Tick(object sender, EventArgs e)
        {
            string stockdata = "";
  
            ++CfgStruct.time;

            string filepath = CfgStruct.fileName;
            FileStream myFs;
            //读Stock文件
            if (Directory.Exists(filepath))
            {
                myFs = new FileStream(filepath, FileMode.Create, FileAccess.ReadWrite);
                myFs.Close();
            }
            StreamWriter sw = new StreamWriter(CfgStruct.fileName, true);
            sw.WriteLine(CfgStruct.time.ToString());
            try
            {
                interval.Interval = Int32.Parse(textBox1.Text);
            }
            catch (InvalidCastException ex)
            {
                throw (ex);
            }
            interval.Start();
            foreach (string stock in CfgStruct.lns)
            {
                stockmarket_one(stock, ref stockdata);
                sw.WriteLine(stockdata);
            }
            sw.Close();
            //状态显示
            listBox1.Items.Add(DateTime.Now.ToString() + "  " + CfgStruct.time.ToString());// = CfgStruct.time.ToString();

            }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
            interval.Dispose();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != String.Empty)
                interval.Interval = Int32.Parse(textBox1.Text);
            else
                MessageBox.Show("请设定时间间隔.");
        }

        //清空文件
        private void ClearFileBt_Click(object sender, EventArgs e)
        {
            string filepath = CfgStruct.fileName;
           
            //清空行情文件
            File.WriteAllText(filepath, "");
            listBox1.Items.Clear();//清空初始化
            CfgStruct.time = 0;
        }

        //增加
        private void AddStockbt_Click(object sender, EventArgs e)
        {
            bool isintag = false;
            string stock;
            string filepath = CfgStruct.stockfileName;
            FileStream myFs;
            //读文件
            if (Directory.Exists(filepath))
            {
                myFs = new FileStream(filepath, FileMode.Create, FileAccess.ReadWrite);
                myFs.Close();
            }
            ReadOptionalStockFile();
            //添加项
            StreamWriter sw = new StreamWriter(CfgStruct.stockfileName, true);
            stock = stockntb.Text;
            if (stock.Length == 6)
            {
                foreach (string s in CfgStruct.lns)
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
            ReadOptionalStockFile();
        }

        //删除
        private void DeleteStockbt_Click(object sender, EventArgs e)
        {
            string stock;
            ReadOptionalStockFile();
            //指定要删除的行
            stock = stockntb.Text;
            CfgStruct.lns.Remove(stock);
            File.WriteAllText(CfgStruct.stockfileName, "");
            //写回
            StreamWriter sw = new StreamWriter(CfgStruct.stockfileName, false);
            foreach (string s in CfgStruct.lns)
                sw.WriteLine(s);
            sw.Close();
            
            //读最新文件
            ReadOptionalStockFile();
        }

        //双击选中
        private void optionallist_SelectedIndexChanged(object sender, EventArgs e)
        {
            stock_t.Interval = 1000;    //更新周期 1秒
            CfgStruct.stockcur = optionallist.Text;
            Market_comboB.Enabled = true;

            //解析
            stock_appendurl(CfgStruct.stockcur, ref CfgStruct.stockurl, CfgStruct.market_timeline, true);
            Market_comboB.SelectedItem = "分时";

            stockntb.Text = optionallist.Text;
            stock_t_Tick(sender, e);
        }

        //定时器：更新指定股票数据
        private void stock_t_Tick(object sender, EventArgs e)
        {       
            stock_t.Start();           
            //行情图
            stockmarketgraph(CfgStruct.stockurl);
            //个股信息
            stockinfo(CfgStruct.stockcur);
            time_l.Text = DateTime.Now.ToString();
        }

        //解析拼接股票URL
        private void stock_appendurl(string stock, ref string stockurl, string url, bool ispicture)
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
            if(ispicture)
                s.Append(".gif");

            stockurl = s.ToString();
        }
        
        //获取单支股票行情 输入股票代码stock
        private void stockmarket_one(string stock, ref string stockdata)
        {         
            string stockurl = "";
            
            CNNWebClient webClient;//通过WebClient方式去获取资源文件
            stock_appendurl(stock, ref stockurl, CfgStruct.marketlist_t,false);
            Uri uri = new Uri(stockurl, false);
            webClient = new CNNWebClient();
            try
            {
                stockdata = webClient.DownloadString(uri);
            }
            catch(InvalidCastException e)
            {
                throw (e);
            }

            webClient.Dispose();
       }

        //Market下拉选单
        private void Market_comboB_SelectedIndexChanged(object sender, EventArgs e)
        {
            string stock = "";
            string stock_timeline_url = "";
            string stock_dailyk_url = "";
            string stock_weekk_url = "";
            string stock_monthk_url = "";

            stock = CfgStruct.stockcur;
            switch (Market_comboB.SelectedItem.ToString())
            {
                case "分时":
                    //解析
                    stock_appendurl(stock, ref CfgStruct.stockurl, CfgStruct.market_timeline, true);
                    break;
                case "日K":
                    //解析
                    stock_appendurl(stock, ref CfgStruct.stockurl, CfgStruct.market_dailyk, true);
                    break;
                case "周K":
                    //解析
                    stock_appendurl(stock, ref CfgStruct.stockurl, CfgStruct.market_weekk, true);
                    break;
                case "月K":
                    //解析
                    stock_appendurl(stock, ref CfgStruct.stockurl, CfgStruct.market_monthk, true);
                    break;
                default:
                    break;
            }
        }

        //获取stock分时K线图
        private void stockmarketgraph(string stockurl)
        {
            SH000001pB.ImageLocation = @stockurl;
        }

        //股票信息获取
        private void stockinfo(string stock)
        {
            string stockdata = "";
            int i = 0;

            //获取股票行情信息
            stockmarket_one(stock, ref stockdata);
            //解析
            string[] stockArry = stockdata.Split('~');
            foreach(string str in stockArry)
            {
                switch(i)
                {
                    case 1: //名称
                        stockname_l.Visible = true;
                        stockname_l.Text = str;
                        break;
                    case 3: //当前价格
                        stockprice_l.Visible = true;
                        stockprice_l.Text = str;
                        break;
                    case 4: //昨日价格
                        preprice_l.Visible = true;
                        preprice_l.Text = str;
                        break;
                    case 9: //buy1 price
                        buy1p_l.Visible = true;
                        buy1p_l.Text = str;
                        break;
                    case 10: //buy1 
                        buy1v_l.Visible = true;
                        buy1v_l.Text = str;
                        break;
                    case 11: //buy2 price
                        buy2p_l.Visible = true;
                        buy2p_l.Text = str;
                        break;
                    case 12: //buy2
                        buy2v_l.Visible = true;
                        buy2v_l.Text = str;
                        break;
                    case 13: //buy3 price
                        buy3p_l.Visible = true;
                        buy3p_l.Text = str;
                        break;
                    case 14: //buy3
                        buy3v_l.Visible = true;
                        buy3v_l.Text = str;
                        break;
                    case 15: //buy4 price
                        buy4p_l.Visible = true;
                        buy4p_l.Text = str;
                        break;
                    case 16: //buy4
                        buy4v_l.Visible = true;
                        buy4v_l.Text = str;
                        break;
                    case 17: //buy5 price
                        buy5p_l.Visible = true;
                        buy5p_l.Text = str;
                        break;
                    case 18: //buy1 price
                        buy5v_l.Visible = true;
                        buy5v_l.Text = str;
                        break;
                    case 19: //sell1 price
                        sell1p_l.Visible = true;
                        sell1p_l.Text = str;
                        break;
                    case 20: //sell1
                        sell1v_l.Visible = true;
                        sell1v_l.Text = str;
                        break;
                    case 21: //sell2 price
                        sell2p_l.Visible = true;
                        sell2p_l.Text = str;
                        break;
                    case 22: //sell2
                        sell2v_l.Visible = true;
                        sell2v_l.Text = str;
                        break;
                    case 23: //sell3 price
                        sell3p_l.Visible = true;
                        sell3p_l.Text = str;
                        break;
                    case 24: //sell3
                        sell3v_l.Visible = true;
                        sell3v_l.Text = str;
                        break;
                    case 25: //sell4 price
                        sell4p_l.Visible = true;
                        sell4p_l.Text = str;
                        break;
                    case 26: //sell4
                        sell4v_l.Visible = true;
                        sell4v_l.Text = str;
                        break;
                    case 27: //sell5 price
                        sell5p_l.Visible = true;
                        sell5p_l.Text = str;
                        break;
                    case 28: //sell5
                        sell5v_l.Visible = true;
                        sell5v_l.Text = str;
                        break;
                    case 32: //涨跌%
                        updownpercent_l.Visible = true;
                        updownpercent_l.Text = str;
                        if (float.Parse(str) > 0)
                        {
                            updownpercent_l.ForeColor = Color.Red;
                            stockprice_l.ForeColor = Color.Red;
                        }
                        else
                        {
                            updownpercent_l.ForeColor = Color.Green;
                            stockprice_l.ForeColor = Color.Green;
                        }
                        break;
                    case 36: //成交量（手）
                        volumev_l.Visible = true;
                        volumev_l.Text = str;
                        break;
                    case 37: //成交额（万）
                        volumem_l.Visible = true;
                        volumem_l.Text = str;
                        break;
                    case 38: //换手率
                        turnoverrate_l.Visible = true;
                        turnoverrate_l.Text = str;
                        break;
                    case 39: //市盈率
                        peratio_l.Visible = true;
                        peratio_l.Text = str;
                        break;
                    case 43: //振幅
                        amplitude_l.Visible = true;
                        amplitude_l.Text = str;
                        break;
                    case 44: //流通市值
                        cirmarketvalue_l.Visible = true;
                        cirmarketvalue_l.Text = str;
                        break;
                    case 45: //总市值
                        totalvalue_l.Visible = true;
                        totalvalue_l.Text = str;
                        break;
                    case 46: //市净率
                        pbratio_l.Visible = true;
                        pbratio_l.Text = str;
                        break;
                    default:
                        break;
                }
                ++i;
            }
        }
        //打开文件
        private void openfilebt_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(CfgStruct.fileName);
        }
    }


}