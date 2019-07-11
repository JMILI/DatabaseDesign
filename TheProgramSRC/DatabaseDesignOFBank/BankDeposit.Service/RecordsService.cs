using BankDeposit.Data;
using BankDeposit.Model.SqlBank;
using System;
using System.Collections.Generic;
using System.Text;
using BankDeposit.Model.Helper;
namespace BankDeposit.Service
{
    /// <summary>
    /// Records表的业务逻辑处理类。
    /// </summary>
    public class RecordsService
    {
        #region 实例化一些工具对象
        public static AccessRecords accessRecords = new AccessRecords();
        #endregion

        #region 按月统计收支利润
        /// <summary>
        /// 按月查询记录表，主要调用访问层,该层为Service层
        /// </summary>
        /// <param name="i">传入要查询月份和当前月份的差值，注意传入0，表示当前月</param>
        /// <returns>返回访问层的返回值，每月的记录信息（记录表Records）</returns>
        public List<Records> StatisticalByMonthService(int difference)
        {
            return  accessRecords.StatisticalByMonth(difference);
        }
        #endregion

        #region 增加记录
        /// <summary>
        /// 记录表Records中增加记录，业务逻辑层
        /// </summary>
        /// <param name="dAndC">传入从cooike中获取的储户和储户银行卡信息。其对象为DepositorAndCard</param>
        /// <param name="v">出入参数v代表类型,1：代表取款，2：代表活期存款，其他：代表定期存款。每次传入一个类型的值，其他两项字段默认为0</param>
        /// <param name="money">金额</param>
        /// <param name="mid">业务办理员</param>
        public void AddRecordsService(DepositorAndCard dAndC, int v, double money, int mid)
        {
            accessRecords.Add(dAndC, v, money, mid);
        }

        internal DateTime RecordsTimeData(int cid)
        {
            return (DateTime)accessRecords.RecordsTimeData(cid);
        }
        #endregion

    }
}
