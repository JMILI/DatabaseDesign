using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BankDeposit.Model.SqlBank;
using Microsoft.EntityFrameworkCore;

namespace BankDeposit.Data
{
    /// <summary>
    /// 此类用于ATM系统访问数据
    /// </summary>
    public class AccessFixbalance
    {
        public static Cards card = new Cards();


        #region 查询某用户的定期存款表
        public List<Fixbalances> FixBalanceData(int cid)
        {
            using (bankContext dbContext = new bankContext())
            {
                return dbContext.Fixbalances.FromSql("select * from Fixbalances where Fcid={0} order by Fid desc", cid).AsNoTracking().ToList();
            }
        }
        #endregion

        #region 增加定期存款记录
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
