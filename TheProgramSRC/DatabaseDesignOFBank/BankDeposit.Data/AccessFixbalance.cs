using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BankDeposit.Model.SqlBank;
using Microsoft.EntityFrameworkCore;
using BankDeposit.Model.Helper;

namespace BankDeposit.Data
{
    /// <summary>
    /// 数据库，Fixbalance定期存款表的类
    /// </summary>
    public class AccessFixbalance
    {
        #region 查询某用户的定期存款表
        /// <summary>
        /// 查询某用户的定期存款表,根据银行卡账号查询
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public List<Fixbalances> FixBalanceData(int cid)
        {
            using (bankContext dbContext = new bankContext())
            {
                return dbContext.Fixbalances.FromSql("select * from Fixbalances where Fcid={0} order by Fid desc", cid).AsNoTracking().ToList();
            }
        }
        #endregion

        #region 增加定期存款
        /// <summary>
        /// 增加定期存款
        /// </summary>
        /// <param name="fix">Fyear，FfixBalanceRate，FfixBalance，FfixBalance</param>
        public void Add(Fixbalances fix)
        {
            using (var dbContext = new bankContext())
            {
                //修改数据库信息最好有一些事务操作
                using (var transaction = dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        dbContext.Add(fix);
                        dbContext.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        transaction.Rollback();
                    }
                }
            }
        }
        #endregion
    }
}
