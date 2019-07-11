using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using BankDeposit.Model.SqlBank;
using BankDeposit.Model.Helper;
using Microsoft.EntityFrameworkCore;

namespace BankDeposit.Data
{
    /// <summary>
    /// 此类用于ATM系统访问数据
    /// </summary>
    public class AccessCards
    {

        #region 查询银行卡（登录的）
        /// <summary>
        /// 查询银行卡（登录的）
        /// </summary>
        /// <param name="user">传入登录信息，账号Id,Password,Identify</param>
        /// <returns></returns>
        public Cards QueryCardsData(User user)
        {
            Cards card = new Cards();
            using (var dbContext = new bankContext())
            {
                card = dbContext.Cards.FromSql("select * from Cards where  Cid= {0} and Cpassword={1} ",
                    user.Id, user.Password).AsNoTracking().ToList().FirstOrDefault();//查询并验证密码
                return card;
            }
        }
        #endregion

        #region 查询银行卡
        /// <summary>
        /// 查询银行卡，根据Cid银行卡账号查询
        /// </summary>
        /// <param name="cid">传入银行卡账号</param>
        /// <returns></returns>
        public Cards CardsData(int? cid)
        {
            using (var dbContext = new bankContext())
            {
                return dbContext.Cards.FirstOrDefault(a => a.Cid == cid);//查询
            }
        }
        #endregion

        #region 查询前十项记录
        /// <summary>
        /// 查询最近十项记录,根据Cid银行卡账号查询
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

        #region 更新银行卡表
        /// <summary>
        /// 更新银行卡表,根据cid,更新活期存款余额
        /// </summary>
        /// <param name="cid"></param>
        /// <param name="money"></param>
        public void UpdateCards(int cid, double money)
        {
            using (var dbContext = new bankContext())
            {
                //修改数据库信息最好有一些事务操作
                using (var transaction = dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        var sql = @"Update Cards SET CflowBalance =  {0} WHERE Cid =  {1}";
                        dbContext.Database.ExecuteSqlCommand(sql, money, cid);
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

        #region 增添银行卡用户
        /// <summary>
        /// 增添银行卡用户
        /// </summary>
        /// <param name="card">前端页面填写的信息：CflowBalanceRate，Cpassword，Cuid</param>
        public void Add(Cards card)
        {
            using (var dbContext = new bankContext())
            {
                //修改数据库信息最好有一些事务操作
                using (var transaction = dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        dbContext.Add(card);
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
