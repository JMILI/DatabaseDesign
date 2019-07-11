using System;
using System.Collections.Generic;
using System.Text;

namespace BankDeposit.Model.Helper
{
    /// <summary>
    /// 该类用来封装登录界面填写的信息，并用来传输数据，Describe(描述月份信息，横坐标)，Spending(支出)
    /// ，Profits(利润)，Income(收入)
    /// </summary>
    public class StatisticalByMonth
    {
        /// <summary>
        /// Describe(描述月份信息，横坐标)
        /// </summary>
        public string Describe  { get; set; }
        /// <summary>
        /// Spending(支出)
        /// </summary>
        public double Spending { get; set; }
        /// <summary>
        /// Profits(利润)
        /// </summary>
        public double Profits { get; set; }
        /// <summary>
        /// Income(收入)
        /// </summary>
        public double Income { get; set; }

    }
}
