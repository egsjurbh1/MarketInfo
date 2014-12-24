using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MarketInfo
{
    /// <summary>
    /// 基础数据类
    /// </summary>
    public class Stock_Index
    {
        /// <summary>
        /// 基础数据
        /// </summary>
        public static double stock_curprice;    //当前股价
        public static int stock_volume;         //成交量
        public static double costirate;         //资金成本利率
        /// <summary>
        /// 交易目标数据
        /// </summary>
        public static int buyvolume;            //买入量 
        public static int sellvolume;           //卖出量
        public static DateTime ab_buytime;      //绝对买点
        public static DateTime ab_selltime;     //绝对卖点
        public static DateTime re_buytime;      //相对买点
        public static DateTime re_selltime;     //相对卖点
        /// <summary>
        /// 盯市分析指标
        /// </summary>
        public static float profitrate;         //收益率
        public static DateTime pre_mtmtime;     //盯市区间前值
        public static DateTime now_mtmtime;     //盯市区间后值
        public static DateTime position_time;   //持仓时间
        public static double accupower;         //区间累积能量
        public static float stoploss_price;     //止损价格
        public static double position_risk;     //持仓风险
        public static int trend_direction;      //趋势方向
        public static float win_avgprice;       //窗口均价
        public static float win_sdevprice;      //窗口价格标准差
        public static long win_avgvolume;       //窗口均量
        public static float win_sdevvolume;     //窗口量标准差
        public static float win_prate;          //窗口增长率
        public static float trend_degree;       //趋势度
        /// <summary>
        /// 公式参数
        /// </summary>
        public static float para_accupower_a;   //累积能量——a权重
        public static float para_accupower_b;   //累积能量——b权重
        public static float para_positionr_a;   //持仓风险——a权重
        public static float para_positionr_b;   //持仓风险——b权重
        public static float para_volumeratio;   //量比
        public static int para_buytimeinterval; //买入区间
    }

    /// <summary>
    /// 交易决策类
    /// </summary>
    class TradStrategy
    {
        /// <summary>
        /// 个股数据分析
        /// </summary>
        /// <param name="begin_time">分析窗口</param>
        /// <param name="end_time"></param>
        /// <param name="stock_dt">个股数据</param>
        public void stockdata_analysis(DateTime begin_time, DateTime end_time, DataTable stock_dt, ref DataTable flashpoint_dt)
        {
            string begintime = begin_time.ToString("yyyyMMdd");
            string endtime = end_time.ToString("yyyyMMdd");

            string avgs_filters = "Date >= " + begintime + " AND " + "Date <= " + endtime;//区间条件
            //区间均价
            object avgstockprice = stock_dt.Compute("Avg([Adj Close])", avgs_filters);
            Stock_Index.win_avgprice = float.Parse(avgstockprice.ToString());
            //区间均量
            object avgstockvolume = stock_dt.Compute("Avg([Volume])", avgs_filters);
            Stock_Index.win_avgvolume = long.Parse(avgstockvolume.ToString());
            //区间股价标准差
            object sdev_price = stock_dt.Compute("StDev([Adj Close])", avgs_filters);
            Stock_Index.win_sdevprice = float.Parse(sdev_price.ToString());
            //区间量标准差
            object sdev_volume = stock_dt.Compute("StDev([Volume])", avgs_filters);
            Stock_Index.win_sdevvolume = float.Parse(sdev_volume.ToString());
            //区间增长率
            DataRow[] dr;
            string sortOrder = "Date DESC";
            dr = stock_dt.Select(avgs_filters, sortOrder);
            float end_price = float.Parse(dr[0].ItemArray[6].ToString());
            Stock_Index.win_prate = (end_price - Stock_Index.win_avgprice) / Stock_Index.win_avgprice;
            //选出暴量异常点
            DataRow[] drf;
            string s_winvolume = (Stock_Index.para_volumeratio * Stock_Index.win_avgvolume).ToString();
            string flashp_filters = avgs_filters + " AND " + "Volume >= " + s_winvolume;
            drf = stock_dt.Select(flashp_filters, sortOrder);
            if(drf.Count() != 0)
                flashpoint_dt = drf.CopyToDataTable();
        }
        /// <summary>
        /// 盯市
        /// </summary>
        public void marktomarket()
        {

        }
    }
}
