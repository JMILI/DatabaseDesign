using BankDeposit.Data;
using BankDeposit.Model.SqlBank;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankDeposit.Service
{
    public class FixbalanceService
    {
        #region 实例化一些工具对象
        public static AccessFixbalance accessFixbalance = new AccessFixbalance();
        public static List<Fixbalances> fixbalances = new List<Fixbalances>();
        public static List<Fixbalances> newFixbalances = new List<Fixbalances>();
        #endregion

        #region 银行卡计算利息和余额
        /// <summary>
        /// 是FixBalanceService的方法，银行卡计算利息和余额，没有更新数据库功能。只负责查询
        /// </summary>
        /// <param name="cid">那个卡？</param>
        /// <returns>返回计算后的定期存款表的所有记录</returns>
        public List<Fixbalances> FixBalancesService(int cid)
        {
            fixbalances = accessFixbalance.FixBalanceData(cid);
            DateTime dt2 = System.DateTime.Now;
            Double Year;
            double Rate;
            foreach (var item in fixbalances)
            {
                var balance = (double)item.FfixBalance;
                DateTime dt1 = (DateTime)item.FbusinessTime;
                Year = dt2.Year - dt1.Year;
                Rate = Year * balance;//算出利息，按年计算

                item.FfixBalance = Rate + balance;//得到计算后的定期存款余额，数据库没有更新
                newFixbalances.Add(item);
            }
            return newFixbalances;
        }
        #endregion

    }
}
