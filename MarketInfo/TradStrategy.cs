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
    public class Stock_AnalysisIndex
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
        public static double stoploss_price;    //止损价格
        public static double position_risk;     //持仓风险
        public static int trend_direction;      //趋势方向
        public static double win_avgprice;      //窗口均价
        public static float trend_degree;       //趋势度
        /// <summary>
        /// 公式参数
        /// </summary>
        public static float para_accupower_a;   //累积能量——a权重
        public static float para_accupower_b;   //累积能量——b权重
        public static float para_positionr_a;   //持仓风险——a权重
        public static float para_positionr_b;   //持仓风险——b权重
    }

    /// <summary>
    /// 交易决策类
    /// </summary>
    class TradStrategy
    {
        /// <summary>
        /// 股票趋势判断
        /// 输入：分析窗口，个股数据；
        /// 输出：趋势方向，趋势度；
        /// </summary>
        /// <param name="begin_time"></param>
        /// <param name="end_time"></param>
        /// <param name="stock_dt"></param>
        public void stock_trend(DateTime begin_time, DateTime end_time, DataTable stock_dt)
        {
            string begintime = begin_time.ToString("yyyy-MM-dd");
            string endtime = end_time.ToString("yyyy-MM-dd");

            //string avgs_filters = "Date>=" + begintime + " AND " + "Date<=" + endtime;
            string avgs_filters = "Adj Close>=" + "8" + " AND " + "Adj Close<=" + "9";
            object avgstockprice = stock_dt.Compute("Avg([Adj Close])", "");

            Stock_AnalysisIndex.win_avgprice = double.Parse(avgstockprice.ToString());
        }
        /// <summary>
        /// 盯市
        /// </summary>
        public void marktomarket()
        {

        }
    }
}
