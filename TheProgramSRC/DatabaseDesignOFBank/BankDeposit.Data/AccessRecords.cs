using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BankDeposit.Model.SqlBank;
using Microsoft.EntityFrameworkCore;
using BankDeposit.Model.Helper;

namespace BankDeposit.Data
{
    public class AccessRecords
    {
        #region 查询前十项记录
        /// <summary>
        /// 查询最近十项记录,根据cid查询
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

        #region 按月查询记录表
        /// <summary>
        /// 按月查询记录表
        /// </summary>
        /// <param name="difference">传入要查询月份和当前月份的差值，注意传入0，表示当前月</param>
        /// <returns>返回要查询月份的记录</returns>
        public List<Records> StatisticalByMonth(int difference)
        {
            using (bankContext dbContext = new bankContext())
            {
                return dbContext.Records.FromSql(
                            "  SELECT * FROM Records WHERE PERIOD_DIFF(date_format(now(), '%Y%m'), date_format(RnowDateTime, '%Y%m')) = {0} ", difference)
                            .AsNoTracking().ToList();
            }
        }
        #endregion

        #region 取出最后一次交易记录时间
        /// <summary>
        /// 根据cid取出最后一次交易记录时间
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public DateTime? RecordsTimeData(int cid)
        {
            Records record = new Records();
            using (bankContext dbContext = new bankContext())
            {
                //取出记录表中该卡活动的记录中活期存款或者活期取款不为零的第一项记录，
                //记录以降序排列，就可以取出最近对活期存款的操作记录
                record = dbContext.Records.FromSql("select * from Records where Rcid={0} And RflowDeposit != 0 or Rwithdrawals != 0 order by Rid desc", cid).AsNoTracking().ToList().FirstOrDefault();
                return record.RnowDateTime;
            }
        }
        #endregion

        #region 增加交易记录
        /// <summary>
        /// 记录表Records中增加记录,该层为访问层，传入参数：DepositorAndCard，操作类型int v，double money, int mid
        /// </summary>
        /// <param name="dAndC">传入从cooike中获取的储户和储户银行卡信息。其对象为DepositorAndCard</param>
        /// <param name="v">出入参数v代表类型,1：代表取款，2：代表活期存款，其他：代表定期存款。每次传入一个类型的值，其他两项字段默认为0</param>
        /// <param name="money">金额</param>
        /// <param name="mid">业务办理员</param>
        public void Add(DepositorAndCard dAndC, int v, double money, int mid)
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
                        }
                        else if (v == 2)
                        {
                            records.RflowDeposit = money;
                        }
                        else
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
