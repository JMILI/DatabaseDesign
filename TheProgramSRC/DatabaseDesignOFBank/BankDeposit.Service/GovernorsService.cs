using BankDeposit.Data;
using BankDeposit.Model.SqlBank;
using System;
using System.Collections.Generic;
using System.Text;
using BankDeposit.Model.Helper;

namespace BankDeposit.Service
{
    /// <summary>
    /// 业务逻辑层，GovernorsService，对Managers表的操作。
    /// </summary>
    public class GovernorsService
    {
        #region 实例化一些对象
        public static RecordsService recordsService = new RecordsService();
        #endregion

        #region 按月统计收支利润
        /// <summary>
        /// 按月统计收支利润
        /// </summary>
        /// <returns>返回直接可以生成统计图的数据</returns>
        public List<StatisticalByMonth> StatisticalByMonthService()
        {
            List<StatisticalByMonth> statisticalByMonth = new List<StatisticalByMonth>();
            DateTime dt2 = System.DateTime.Now;//当前时间
            int Month = dt2.Month - 1;//当前月份-1，准备赋给差值difference，比如现在8月，初始差值为7.则计算的是一月的数据。差值为0 计算当前8月数据
            int MonthRecord = 1;//月份记录，每计算一个月份增加
            for (int difference = Month; difference >= 0; difference--)//从1月开始统计，知道当前余额，
            {
                statisticalByMonth.Add(StatisticalByMonthService(difference, MonthRecord));
                MonthRecord++;
            }
            return statisticalByMonth;
        }
        /// <summary>
        /// 按月统计每月的利润，支出，收入
        /// </summary>
        /// <param name="i">传入要查询月份和当前月份的差值，注意传入0，表示当前月</param>
        /// <returns>返回StatisticalByMonth对象，对象含，月份Describe，利润Profits，支出Spending，收入Income四个字段</returns>
        public StatisticalByMonth StatisticalByMonthService(int difference, int MonthRecord)
        {
            List<Records> records = new List<Records>();
            records = recordsService.StatisticalByMonthService(difference);
            double Spending = 0;//初始化为0
            double Income = 0;//初始化为0
            foreach (var item in records)
            {
                Income += (double)item.RflowDeposit;//将某月活期期存款累计，当做活期资金银行收入
                Spending += (double)item.Rwithdrawals;//将某月用户取款额累计，当做活期资金银行支出
            }
            StatisticalByMonth statisticalData = new StatisticalByMonth();
            statisticalData.Income = Income / 10000;//以万元为单位，除以10000.
            statisticalData.Spending = Spending / 10000;
            statisticalData.Profits = (Income - Spending) / 10000;
            statisticalData.Describe = MonthRecord + "月";//填写计算结果是几月份的数据
            return statisticalData;
        }
        #endregion
    }
}
