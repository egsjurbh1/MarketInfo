using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data;
using System.Net;
using System.Text;
using System.Threading;

namespace MarketInfo
{
    //全局系统参数
    public class CfgStruct
    {
        public static int time;
        public static String stockcur;
        public static String hisdatafilepath;
        public static String stockurl;
        public static int stock_n;
        public static String fileName;
        public static String stockfileName;
        public static String market_timeline;
        public static String marketlist_t;
        public static String market_dailyk;
        public static String market_weekk;
        public static String market_monthk;
        public static String market_daily_his_url;
        public static String dbconnect_str;
        public static String dbname;
        public static int curuserid;
        public static List<string> lns = new List<string>();//声明一个泛型
    }

    //全局标识量
    public class FlagDef
    {
        public const int ADD = 1;                  //增加
        public const int REMOVE = 2;               //移除
        public const int SH = 1;                   //沪市
        public const int SZ = 2;                   //深市
        public const int ACCOUNTWRONG = -9998;     //账户不存在标志
        public const int PWDWRONG = -9999;         //密码错误标志
    }

    /// <summary>
    /// stock分析
    /// </summary>
    public class AdvStock
    {
        public static String mystock;
    }

    class GeneralClass
    {
        public string Stkcode { get; set; } //股票代码
        
        //正则表达式判断
        public bool IsInt(string str)
        {
            string regextext = @"^(-?\d+)(\.\d+)?$";
            Regex regex = new Regex(regextext, RegexOptions.None);
            return regex.IsMatch(str.Trim());
        }

        //摘自网络，下载文件
        //<param name="URL">下载文件地址</param>       
        // <param name="filepath">下载后的存放地址</param>        
        // <param name="Prog">用于显示的进度条</param>   
        public bool DownloadFile(string URL, string filepath)
        {
            try
            {
                HttpWebRequest Myrq = (HttpWebRequest)HttpWebRequest.Create(URL);
                HttpWebResponse myrp = (HttpWebResponse)Myrq.GetResponse();
                Stream st = myrp.GetResponseStream();
                Stream so = new FileStream(filepath, FileMode.Create);
                byte[] by = new byte[1024];
                int osize = st.Read(by, 0, by.Length);
                while (osize > 0)
                {
                    so.Write(by, 0, osize);
                    osize = st.Read(by, 0, by.Length);
                }
                so.Close();
                st.Close();
                myrp.Close();
                Myrq.Abort();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// 读系统配置文件
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="config_s1"></param>
        public bool ReadConfigFile(string filepath, ref string config_s1, ref string dbname)
        {
            //判断配置文件是否存在
            if (!File.Exists(filepath))
                return false;
            //读配置信息
            StreamReader sw = new StreamReader(filepath, true);
            while (sw.Peek() >= 0)
            {
                config_s1 = sw.ReadLine();  //system.ini第一行为数据库配置信息
            }
            sw.Close();
            //解析数据库名字
            string begin = "Initial Catalog=";
            string end = ";Persist Security Info=";
            int beginIndex = config_s1.IndexOf(begin) + begin.Length;
            int endIndex = config_s1.IndexOf(end);
            dbname = " " + config_s1.Substring(beginIndex, endIndex - beginIndex) + "..";
            return true;
        }

        /// <summary>
        ///  读DB系统配置
        /// </summary>
        /// <returns></returns>
        public bool GetSysConfigFromDB(ref string errorMsg)
        {
            SqlProcess sp = new SqlProcess();
            DataTable dt = new DataTable();

            string sql = "select keyname, keyvalue, sysstatus from" + CfgStruct.dbname + "sysconfig";
            sp.ExecSingleSQL(CfgStruct.dbconnect_str, sql, dt);
            //若未查到配置信息，返回false
            if (dt.Rows.Count == 0)
                return false;

            //查找各项配置的值
            DataRow[] dr;
            //Marketlist_Tencent
            dr = dt.Select("keyname = 'Marketlist_Tencent'");
            if (dr[0].Table.Rows.Count == 0)
            {
                errorMsg = "实时行情路径缺少，Marketlist_Tencent not found";
                return false;
            }
            CfgStruct.marketlist_t = dr[0]["keyvalue"].ToString().Trim();
            //Markettimeline_Sina
            dr = dt.Select("keyname = 'Markettimeline_Sina'");
            if (dr[0].Table.Rows.Count == 0)
            {
                errorMsg = "分时线路径缺少，Markettimeline_Sina not found";
                return false;
            }
            CfgStruct.market_timeline = dr[0]["keyvalue"].ToString().Trim();
            //Marketdailyk_Sina
            dr = dt.Select("keyname = 'Marketdailyk_Sina'");
            if (dr[0].Table.Rows.Count == 0)
            {
                errorMsg = "日K线路径缺少，Marketdailyk_Sina not found";
                return false;
            }
            CfgStruct.market_dailyk = dr[0]["keyvalue"].ToString().Trim();
            //Marketweekk_Sina
            dr = dt.Select("keyname = 'Marketweekk_Sina'");
            if (dr[0].Table.Rows.Count == 0)
            {
                errorMsg = "周K线路径缺少，Marketweekk_Sina not found";
                return false;
            }
            CfgStruct.market_weekk = dr[0]["keyvalue"].ToString().Trim();
            //Marketmonthk_Sina
            dr = dt.Select("keyname = 'Marketmonthk_Sina'");
            if (dr[0].Table.Rows.Count == 0)
            {
                errorMsg = "月K线路径缺少，Marketmonthk_Sina not found";
                return false;
            }
            CfgStruct.market_monthk = dr[0]["keyvalue"].ToString().Trim();
            //Market_daily_his_yahoo
            dr = dt.Select("keyname = 'Market_daily_his_yahoo'");
            if (dr[0].Table.Rows.Count == 0)
            {
                errorMsg = "历史数据路径缺少，Market_daily_his_yahoo not found";
                return false;
            }
            CfgStruct.market_daily_his_url = dr[0]["keyvalue"].ToString().Trim();

            return true;
        }

        /// <summary>
        /// DB股票代码校验, 并选出市场代码
        /// 合理返回true，不合理返回false
        /// </summary>
        public bool stock_checkout(string stock, ref Stock_Index si)
        {
            SqlProcess sp = new SqlProcess();
            string stockget = null;
            string dbtable = "stock ";
            DataTable dt = new DataTable();

            //查stock
            string sql = "select stkcode,market,stkname from"+ CfgStruct.dbname + dbtable + "where stkcode =" + "'" + stock +"'";
            sp.ExecSingleSQL(CfgStruct.dbconnect_str, sql, dt);
            //若未查到股票，返回false
            if (dt.Rows.Count == 0)
                return false;
            else
                stockget = dt.Rows[0]["stkcode"].ToString().Trim(); //去掉空格
            
            //比较所选证券代码在DB中是否一致
            if (String.Compare(stock, stockget) == 0)
            {
                si.market = Convert.ToInt32(dt.Rows[0]["market"].ToString().Trim());
                si.stockname = dt.Rows[0]["stkname"].ToString().Trim();
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// 查DB用户配置信息
        /// </summary>
        /// <param name="connectionstring"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public bool GetUserConfigFromDB(int userid, ref string username)
        {
            SqlProcess sp = new SqlProcess();
            DataTable dt = new DataTable();
            
            //查username
            string sql = "select username from" + CfgStruct.dbname + "customer where userid = " + userid.ToString();
            sp.ExecSingleSQL(CfgStruct.dbconnect_str, sql, dt);
            //若未查到配置信息，返回false
            if (dt.Rows.Count == 0)
                return false;
            username = dt.Rows[0]["username"].ToString().Trim();
            dt.Clear();
            sql = null;
            //查stocklist
            sql = "select stocklist from" + CfgStruct.dbname + "cust_stockinfo where userid = " + userid.ToString();
            sp.ExecSingleSQL(CfgStruct.dbconnect_str, sql, dt);
            //若未查到配置信息，返回false
            if (dt.Rows.Count == 0)
                return false;
            string stocklist = dt.Rows[0]["stocklist"].ToString().Trim();
            string[] slist = stocklist.Split(',');
            //加入到自选列表缓存
            foreach (string stkcode in slist)
            {
                if(stkcode != "")
                    CfgStruct.lns.Add(stkcode);
            }

            return true;
        }

        /// <summary>
        /// 修改用户自选表
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="stkcode"></param>
        /// <returns></returns>
        public bool ModiUserStocklistFromDB(int userid, string stkcode, int functype)
        {
            //功能判断
            switch (functype)
            {
                case FlagDef.ADD:
                    //加入到当前自选列表
                    CfgStruct.lns.Add(stkcode);
                    break;
                case FlagDef.REMOVE:
                    //删除当前自选列表中stkcode
                    foreach (string s in CfgStruct.lns)
                    {
                        if (s == stkcode)
                        {
                            CfgStruct.lns.Remove(s);
                            break;
                        }
                    }
                    break;
                default:
                    break;
            }
       
            //生成stklist
            string stklist = null;
            foreach(string s in CfgStruct.lns)
            {
                stklist = stklist + s + ',';
            }

            //更新stklist
            SqlProcess sp = new SqlProcess();
            string sql = "Update" + CfgStruct.dbname + "cust_stockinfo set stocklist = '" + stklist + "' where userid = " + userid.ToString();
            if(!sp.ExecSingleSQL(CfgStruct.dbconnect_str, sql))
                return false;
            return true;
        }

        /// <summary>
        /// 将DataTable中数据写入到CSV文件中
        /// </summary>
        /// <param name="dt">提供保存数据的DataTable</param>
        /// <param name="fileName">CSV的文件路径</param>
        public void SaveCSV(DataTable dt, string fullPath)
        {
            FileInfo fi = new FileInfo(fullPath);
            if (!fi.Directory.Exists)
            {
                fi.Directory.Create();
            }
            FileStream fs = new FileStream(fullPath, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);
            string data = "";
            //写出列名称
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                data += dt.Columns[i].ColumnName.ToString();
                if (i < dt.Columns.Count - 1)
                {
                    data += ",";
                }
            }
            sw.WriteLine(data);
            //写出各行数据
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                data = "";
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    string str = dt.Rows[i][j].ToString();
                    str = str.Replace("\"", "\"\"");//替换英文冒号 英文冒号需要换成两个冒号
                    if (str.Contains(',') || str.Contains('"')
                        || str.Contains('\r') || str.Contains('\n')) //含逗号 冒号 换行符的需要放到引号中
                    {
                        str = string.Format("\"{0}\"", str);
                    }

                    data += str;
                    if (j < dt.Columns.Count - 1)
                    {
                        data += ",";
                    }
                }
                sw.WriteLine(data);
            }
            sw.Close();
            fs.Close();
            DialogResult result = MessageBox.Show("CSV文件保存成功！");
            if (result == DialogResult.OK)
            {
                System.Diagnostics.Process.Start("explorer.exe");
            }
        }

        /// <summary>
        /// 将CSV文件的数据读取到DataTable中
        /// </summary>
        /// <param name="fileName">CSV文件路径</param>
        /// <returns>返回读取了CSV数据的DataTable</returns>
        public DataTable OpenCSV(string filePath)
        {
            //Encoding encoding = Common.GetType(filePath); //Encoding.ASCII;//

            DataTable dt = new DataTable();
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);

            StreamReader sr = new StreamReader(fs);
            //记录每次读取的一行记录
            string strLine = "";
            //记录每行记录中的各字段内容
            string[] aryLine = null;
            string[] tableHead = null;
            //标示列数
            int columnCount = 0;
            //标示是否是读取的第一行
            bool IsFirst = true;
            //逐行读取CSV中的数据
            while ((strLine = sr.ReadLine()) != null)
            {

                if (IsFirst == true)
                {
                    tableHead = strLine.Split(',');
                    IsFirst = false;
                    columnCount = tableHead.Length;
                    //创建列
                    for (int i = 0; i < columnCount; i++)
                    {
                        //格式转换
                        switch (i)
                        {
                            case 0:
                                DataColumn dc0 = new DataColumn(tableHead[i]);
                                dt.Columns.Add(dc0.ToString(), typeof(string));
                                break;
                            case 5:
                                DataColumn dc1 = new DataColumn(tableHead[i]);
                                dt.Columns.Add(dc1.ToString(), typeof(int));
                                break;
                            case 1:
                            case 2:
                            case 3:
                            case 4:
                            case 6:
                                DataColumn dc2 = new DataColumn(tableHead[i]);
                                dt.Columns.Add(dc2.ToString(), typeof(float));
                                break;
                            default:
                                break;
                        }
                    }
                }
                else
                {
                    aryLine = strLine.Split(',');
                    DataRow dr = dt.NewRow();
                    for (int j = 0; j < columnCount; j++)
                    {
                        //格式转换
                        switch (j)
                        {
                            case 0:
                                aryLine[j] = aryLine[j].Replace("-", "");//去除日期串中的‘-’
                                dr[j] = int.Parse(aryLine[j]);//转整型
                                break;
                            case 5:
                                dr[j] = int.Parse(aryLine[j]);
                                break;
                            case 1:
                            case 2:
                            case 3:
                            case 4:
                            case 6:
                                dr[j] = float.Parse(aryLine[j]);
                                break;
                            default:
                                break;
                        }
                        dr[j] = aryLine[j];
                    }
                    dt.Rows.Add(dr);
                }
            }
            if (aryLine != null && aryLine.Length > 0)
            {
                dt.DefaultView.Sort = tableHead[0] + " " + "desc";  //第一列倒排
            }

            sr.Close();
            fs.Close();
            return dt;
        }
        
        /// <summary>
        /// 下载指定股票的历史数据
        /// </summary>
        /// <param name="stkcode"></param>
        /// <returns></returns>
        public void downloadstockdata(ref string msg)
        {
            string stkcode = Stkcode;
            string filepath = CfgStruct.hisdatafilepath;
            bool IsStockCode = false;

            StringBuilder sburl = new StringBuilder(CfgStruct.market_daily_his_url);
            sburl.Append(stkcode);
            string newfilename = "\\" + stkcode + ".csv";
            Stock_Index si = new Stock_Index();
            if (!stock_checkout(stkcode, ref si))
                return;
            switch (si.market)
            {
                case FlagDef.SH:
                    sburl.Append(".ss");
                    IsStockCode = true;
                    break;
                case FlagDef.SZ:
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
                string url = sburl.ToString();

                if (DownloadFile(url, filepath))
                {
                    File.Copy(filepath, Directory.GetCurrentDirectory() + newfilename, true);//每次下载覆盖
                    msg = stkcode + "下载成功";
                }
                else
                    msg = stkcode + "下载失败";
            }
            Thread.Sleep(500);
        }

        public bool downloadstockdata(string stkcode)
        {
            string filepath = CfgStruct.hisdatafilepath;
            bool IsStockCode = false;

            StringBuilder sburl = new StringBuilder(CfgStruct.market_daily_his_url);
            sburl.Append(stkcode);
            string newfilename = "\\" + stkcode + ".csv";
            Stock_Index si = new Stock_Index();
            if (!stock_checkout(stkcode, ref si))
                return false;
            switch (si.market)
            {
                case FlagDef.SH:
                    sburl.Append(".ss");
                    IsStockCode = true;
                    break;
                case FlagDef.SZ:
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
                string url = sburl.ToString();

                if (!DownloadFile(url, filepath))
                    return false;
                else
                    File.Copy(filepath, Directory.GetCurrentDirectory() + newfilename, true);//每次下载覆盖
            }

            return true;
        }

    }
}
