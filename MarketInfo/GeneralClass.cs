using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data;

namespace MarketInfo
{
    //系统参数
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
        public static List<string> lns = new List<string>();//声明一个泛型
    }

    class GeneralClass
    {
        //正则表达式判断
        public bool IsInt(string str)
        {
            string regextext = @"^(-?\d+)(\.\d+)?$";
            Regex regex = new Regex(regextext, RegexOptions.None);
            return regex.IsMatch(str.Trim());
        }

        //摘自网络，下载文件
        //<param name="URL">下载文件地址</param>       
        //
        // <param name="filepath">下载后的存放地址</param>        
        // <param name="Prog">用于显示的进度条</param>   
        public bool DownloadFile(string URL, string filepath)
        {
            try
            {
                System.Net.HttpWebRequest Myrq = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(URL);
                System.Net.HttpWebResponse myrp = (System.Net.HttpWebResponse)Myrq.GetResponse();
                System.IO.Stream st = myrp.GetResponseStream();
                System.IO.Stream so = new System.IO.FileStream(filepath, System.IO.FileMode.Create);
                byte[] by = new byte[1024];
                int osize = st.Read(by, 0, (int)by.Length);
                while (osize > 0)
                {
                    so.Write(by, 0, osize);
                    osize = st.Read(by, 0, (int)by.Length);
                }
                so.Close();
                st.Close();
                myrp.Close();
                Myrq.Abort();
                return true;
            }
            catch (System.Exception e)
            {
                return false;
            }
        }

        //股票代码市场解析，返回1 上海  2 深证
        public int stock_markettype(string stock)
        {
            if (stock.Length != 6)
                return 0;

            string head = stock.Substring(0, 3);

            if (head == "600" || head == "601" || head == "900")    //上海
                return 1;
            else if (head == "000" || head == "300" || head == "200" || head == "002")  //深证
            {
                if (stock != "000001")
                    return 2;
                else
                    return 1;
            }
            else if (stock == "399001")
                return 2;
            else
                return 0;
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
            FileStream fs = new FileStream(fullPath, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            //StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default);
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
                                dt.Columns.Add(dc0);
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
    }
}
