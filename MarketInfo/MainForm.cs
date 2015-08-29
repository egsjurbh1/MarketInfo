using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading;

namespace MarketInfo
{
    public partial class MainForm : Form
    {
        
        public MainForm()
        {
            InitializeComponent();
            System_Init();  //系统初始化
        }

        #region 初始化
        /// <summary>
        /// 系统初始化
        /// </summary>
        private void System_Init()
        {  
            string errorMsg = null;
            GeneralClass gc = new GeneralClass();
            SqlProcess sp = new SqlProcess();
            UserAccount ua = new UserAccount();
            
            //界面控制
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
            toolProgressBar.Visible = false;
            //stockdata.txt路径
            CfgStruct.fileName = Directory.GetCurrentDirectory() + "\\stockdata.txt";
            //tmp_his.csv路径
            CfgStruct.hisdatafilepath = Directory.GetCurrentDirectory() + "\\tmp_his.csv";
            //system.ini路径
            string systemfile = Directory.GetCurrentDirectory() + "\\system.ini";
            //读system.ini
            if (!gc.ReadConfigFile(systemfile, ref CfgStruct.dbconnect_str, ref CfgStruct.dbname))
            {
                MessageBox.Show("-10000读取配置文件失败！请检查配置文件system.ini。");
                return;
            }
            //测试数据库连接
            if (!sp.ConnectSQL(CfgStruct.dbconnect_str))
            {
                MessageBox.Show("-10001数据库连接失败！请重新配置。");
                return;
            }
       
            //读系统配置信息
            if (!gc.GetSysConfigFromDB(ref errorMsg))
            {
                MessageBox.Show(errorMsg);
                MessageBox.Show("-10002数据库配置信息有误！请重新配置");
                return;
            }
            //用户登录
            string username = "admin"; //默认admin登陆
            string userpwd = "990818";
            string loginmsg = null;
            bool loginerror = false;
            CfgStruct.curuserid = ua.UserLogin( username, userpwd );
            switch(CfgStruct.curuserid)
            {
                case FlagDef.ACCOUNTWRONG:
                    loginmsg = "-10003没有该账户:" + username;
                    loginerror = true;
                    break;
                case FlagDef.PWDWRONG:
                    loginmsg = "-10003账户密码错误:" + username;
                    loginerror = true;
                    break;
                default:
                    break;
            }
            if (loginerror)
            {
                MessageBox.Show(loginmsg);
                return;
            }

            //读用户配置信息
            if (!gc.GetUserConfigFromDB(CfgStruct.curuserid, ref username))
            {
                MessageBox.Show("-10004用户表及自选股表有误！请检查配置。");
                return;
            }   
            lbusername.Text = username; //用户名显示
            RefreshOptionlist();    //刷新自选列表

            //初始化完成显示
            lb_syssem.Items.Clear();
            string showstock = "系统启动成功。";
            lb_syssem.Items.Add(showstock);
        }
        #endregion

        #region 自选股管理模块
        /// <summary>
        /// 刷新显示列表
        /// </summary>
        private void RefreshOptionlist()
        {
            optionallist.Items.Clear();
            foreach (string stkcodename in CfgStruct.lns)
            {
                optionallist.Items.Add(stkcodename); //列表显示
            }
            //显示个数
            gbOptionlist.Text = "自选" + "(" + CfgStruct.lns.Count.ToString() +")";
        }

        /// <summary>
        /// 选中个股功能100
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void optionallist_SelectedIndexChanged(object sender, EventArgs e)
        {
            string stockget = optionallist.Text.Split(' ')[0];

            Stock_Index si = new Stock_Index();
            GeneralClass gc = new GeneralClass();

            //检验股票代码是否正确
            if (!gc.stock_checkout(stockget, ref si))
            {
                gc.ModiUserStocklistFromDB(CfgStruct.curuserid, stockget, FlagDef.REMOVE);
                MessageBox.Show("e-100001股票代码不正确，已删除.");
                return;
            }
            
            stockntb.Text = stockget;
            CfgStruct.stockcur = stockget;
            lb_syssem.Items.Clear();
               
            string showstock = "当前选择：" + si.stockname;
            lb_syssem.Items.Add(showstock);

            //实时行情获取
            Cycle_stockmarket(sender, e);
        }

        /// <summary>
        /// 自选股增加功能101
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddStockbt_Click(object sender, EventArgs e)
        {
            GeneralClass gc = new GeneralClass();
            string stkcode = stockntb.Text;
            Stock_Index si = new Stock_Index();

            //校验是否重复
            foreach (string s in CfgStruct.lns)
            {
                string _stkcode = s.Split(' ')[0];
                if (_stkcode == stkcode)
                {
                    MessageBox.Show("自选股列表存在该股票，请勿重复添加");
                    return;
                }
            }
            //校验stkcode
            if (!gc.stock_checkout(stkcode, ref si))
            {
                MessageBox.Show("e-101001股票代码有误");
                //stockntb.Text = "";
                return;
            }

            if(!gc.ModiUserStocklistFromDB(CfgStruct.curuserid, stkcode, FlagDef.ADD))
            {
                MessageBox.Show("e-101002向数据库增加个股失败");
                return;
            }

            RefreshOptionlist();
            stockntb.Text = "";
            stockntb.Focus();
        }

        /// <summary>
        /// 自选股删除功能102
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteStockbt_Click(object sender, EventArgs e)
        {
            MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
            string sdel = "确定要删除" + CfgStruct.stockcur + "吗？";
            DialogResult dr = MessageBox.Show(sdel, "删除确定", messButton);
            if (dr == DialogResult.Cancel)  //如果点击“Cancel”按钮
                return;

            GeneralClass gc = new GeneralClass();
            string stkcode = stockntb.Text;
            Stock_Index si = new Stock_Index();

            //校验stkcode
            if (!gc.stock_checkout(stkcode, ref si))
            {
                MessageBox.Show("e-102001股票代码有误");
                //stockntb.Text = "";
                return;
            }

            //在数据库中删除
            if (!gc.ModiUserStocklistFromDB(CfgStruct.curuserid, stkcode, FlagDef.REMOVE))
            {
                MessageBox.Show("e-102002向数据库删除个股失败");
                return;
            }
          
            RefreshOptionlist();
            stockntb.SelectAll();
            stockntb.Focus();
        }

        /// <summary>
        /// 股票输入框检验，限定为数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stockntb_TextChanged(object sender, EventArgs e)
        {
            GeneralClass gc = new GeneralClass();

            if (!gc.IsInt(stockntb.Text))
            {
                MessageBox.Show("应该是一个数字", "数据输入错误提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                stockntb.SelectAll();
                stockntb.Focus();
                return;
            }
        }

        /// <summary>
        /// 下载历史数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_dlstockdata_Click(object sender, EventArgs e)
        {
            GeneralClass gc = new GeneralClass();
            lb_syssem.Items.Clear();

            int iTotal = 0;
            int iSuccess = 0;
            int nthread = CfgStruct.lns.Count;
            Thread[] tds = new Thread[nthread];
            string[] msg = new string[nthread + 1];

            foreach (string stkcode in CfgStruct.lns)
            {
                gc.Stkcode = stkcode;
                tds[iTotal] = new Thread(new ThreadStart(delegate ()
                {
                    gc.downloadstockdata(msg[iTotal]);
                }));
                ++iTotal;
            }
            foreach (Thread t in tds)
            {
                t.Start();
                ++iSuccess;
            }

            lbstatusdl.Text = iSuccess.ToString();
            //    if (!gc.downloadstockdata(stkcode))
            //    {
            //        //提示              
            //        msg = stkcode + "下载失败。";
            //        ++iSuccess;
            //    }
            //    else
            //        msg = stkcode + "下载成功。";

            //    lb_syssem.Items.Add(msg);
            //    ++iTotal;
            //}
            //msg = "处理" + iTotal.ToString() + "," + "成功" + iSuccess.ToString() + "," + "失败" + (iTotal - iSuccess).ToString();
            string msgs = "下载线程启动";
            lb_syssem.Items.Add(msgs);
        }

        #endregion

        #region 实时行情获取
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
        //定时获取行情
        private void Cycle_stockmarket(object sender, EventArgs e)
        {     
            stock_t.Interval = 3000;    //更新周期 3秒
            Market_comboB.Enabled = true;

            //解析
            stock_appendurl(CfgStruct.stockcur, ref CfgStruct.stockurl, CfgStruct.market_timeline, true);
            Market_comboB.SelectedItem = "分时";

            stock_t_Tick(sender, e);
        }
                
        //定时器：更新指定股票数据
        private void stock_t_Tick(object sender, EventArgs e)
        {       
            stock_t.Start();           
            //行情图
            stockmarketgraph(CfgStruct.stockurl);
            //个股信息
            try
            {
                stockinfo(CfgStruct.stockcur);
            }
            catch (InvalidCastException e1)
            {
                throw (e1);
            }
            time_l.Text = DateTime.Now.ToString();
        }

        //拼接股票URL
        private void stock_appendurl(string stock, ref string stockurl, string url, bool ispicture)
        {
            GeneralClass gc = new GeneralClass();
            string head = stock.Substring(0, 2);
            Stock_Index si = new Stock_Index();

            if (!gc.stock_checkout(stock, ref si))
                return; 
               
            StringBuilder s = new StringBuilder(url);
            switch (si.market)
            {
                case FlagDef.SH: //上海
                    s.Append("sh");
                    break;
                case FlagDef.SZ: //深证
                    s.Append("sz");
                    break;
                default:
                    return;
            }
                
            s.Append(stock);
            if(ispicture)
                s.Append(".gif");

            stockurl = s.ToString();
        }
        
        //获取单支股票行情
        private void stockmarket_one(string stock, ref string stockdata)
        {         
            string stockurl = "";

            CNNWebClient webClient = new CNNWebClient();    //通过WebClient方式去获取资源文件
            stock_appendurl(stock, ref stockurl, CfgStruct.marketlist_t,false);
            Uri uri = new Uri(stockurl, false);
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
            try
            {
                stockmarket_one(stock, ref stockdata);
            }
            catch (InvalidCastException e)
            {
                throw (e);
            }
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
        #endregion

        #region 抓实时数据模块
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
            toolStatusl.Text = "抓取数据中…" + DateTime.Now.ToString() + "  " + CfgStruct.time.ToString();
        }
        //停止
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
            interval.Dispose();
            toolStatusl.Text = "";
        }
        //设定时间间隔
        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != String.Empty)
                interval.Interval = Int32.Parse(textBox1.Text);
            else
                MessageBox.Show("请设定时间间隔.");
        }
        //打开文件
        private void openfilebt_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(CfgStruct.fileName);
        }
        //清空文件
        private void ClearFileBt_Click(object sender, EventArgs e)
        {
            string filepath = CfgStruct.fileName;

            //清空行情文件
            File.WriteAllText(filepath, "");
            CfgStruct.time = 0;
        }
        #endregion

        #region 关于
        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new AboutForm()).ShowDialog();
        }


        #endregion

        #region 高级决策
        private void AdvDMMenuItem_Click(object sender, EventArgs e)
        {
            AdvancedDMForm admf = new AdvancedDMForm();
            admf.Show();
        }

        #endregion

        #region 批量分析
        private void BAMenuItem_Click(object sender, EventArgs e)
        {
            BatchAnalysisForm baf = new BatchAnalysisForm();
            baf.Show();
        }



        #endregion

        /// <summary>
        /// 右键导航高级分析
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TSMIAdvancedA_Click(object sender, EventArgs e)
        {
            AdvancedDMForm admf = new AdvancedDMForm();
            admf.Show();
        }

        /// <summary>
        /// 右键下载历史数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TSMIDownloaddata_Click(object sender, EventArgs e)
        {
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }


}