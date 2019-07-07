﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BankDeposit.Model.SqlBank;
using Microsoft.EntityFrameworkCore;

namespace BankDeposit.Data
{
    public class AccessRecords
    {
        #region 实例化一些工具对象
        public static User user = new User();
        public static Depositors depositor = new Depositors();
        public static Records record = new Records();

    
        #endregion

        #region 查询前十项记录
        /// <summary>
        /// 查询最近十项记录,
        /// </summary>
        /// <returns></returns>
        public List<Records> TenRecordsData(int cid)
        {
            using (bankContext dbContext = new bankContext())
            {
                //通过ViewContext.Iformation属性从数据库中查询视图数据，因为和数据库表不同，
                //我们不会更新数据库视图的数据，所以调用AsNoTracking方法来告诉EF Core不用在DbContext中跟踪返回的Iformation实体，可以提高EF Core的运行效率
                return dbContext.Records.FromSql("select * from Records where Rcid={0} order by Rid desc", cid).AsNoTracking().Take(10).ToList();
            }
        }
        #endregion

        #region 取出最后一次交易记录时间
        public DateTime? RecordsTimeData(int cid)
        {
            using (bankContext dbContext = new bankContext())
            {
                //取出记录表中该卡活动的记录中活期存款或者活期取款不为零的第一项记录，
                //记录以降序排列，就可以取出最近对活期存款的操作记录
                record = dbContext.Records.FromSql("select * from Records where Rcid={0} And RflowDeposit != 0 or Rwithdrawals != 0 order by Rid desc", cid).AsNoTracking().ToList().FirstOrDefault();
                return record.RnowDateTime;
                //DateTime dt1 = Convert.ToDateTime(Convert.ToDateTime(r.Ioldtime).ToString("yyyy-MM-dd HH:mm:ss"));
                //通过ViewContext.Iformation属性从数据库中查询视图数据，因为和数据库表不同，
                //我们不会更新数据库视图的数据，所以调用AsNoTracking方法来告诉EF Core不用在DbContext中跟踪返回的Iformation实体，可以提高EF Core的运行效率
            }
        } 
        #endregion

        #region 增加交易记录
        public void Add(DepositorAndCard dAndC, int v, double money,int mid)
        {
            using (var dbContext = new bankContext())
            {
                //修改数据库信息最好有一些事务操作
                using (var transaction = dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        Records records = new Records();

                        records.Rcid = (int)dAndC.Dcid;
                        records.Ruid = dAndC.Duid;
                        records.Rmid = mid;
                        if (v == 1)
                        {
                            records.Rwithdrawals = money;
                        }else if(v==2){
                            records.RflowDeposit = money;
                        }else
                        {
                            records.RfixDepostit = money;
                        }
                        dbContext.Add(records);
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
