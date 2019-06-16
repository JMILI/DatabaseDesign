using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BankDeposit.Model.SqlBank;
using Microsoft.EntityFrameworkCore;

namespace BankDeposit.Data
{
    public class AccessDepositors
    {
        #region 实例化一些工具对象
        public static User user = new User();
        public static Depositors depositor = new Depositors();
        #endregion

        #region 查询储户 （登录的）
        /// <summary>
        /// 传入的对象为User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Depositors QueryDepositorsData(User user)
        {
            using (var dbContext = new bankContext())
            {
               return depositor = dbContext.Depositors.FirstOrDefault(a => a.Uid == user.Id);
            }
        }
        #endregion

        #region 查询储户 （注册的）
        /// <summary>
        /// 传入的对象为Depositors
        /// </summary>
        /// <param name="depositor"></param>
        /// <returns></returns>
        public Depositors CheakData(Depositors depositor)
        {
            using (var dbContext = new bankContext())
            {
                return depositor = dbContext.Depositors.FirstOrDefault(a => a.Uid == depositor.Uid);
            }
        }
        #endregion

        #region 增加账户 
        public void AddData(Depositors depositor)
        {
            using (var dbContext = new bankContext())
            {
                //修改数据库信息最好有一些事务操作
                using (var transaction = dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        dbContext.Add(depositor);
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
        #region 查询前十项记录
        /// <summary>
        /// 查询前十项记录
        /// </summary>
        /// <returns></returns>
        public List<Records> TenRecordsData()
        {
            using (bankContext dbContext = new bankContext())
            {
                //通过ViewContext.Iformation属性从数据库中查询视图数据，因为和数据库表不同，
                //我们不会更新数据库视图的数据，所以调用AsNoTracking方法来告诉EF Core不用在DbContext中跟踪返回的Iformation实体，可以提高EF Core的运行效率
                return  dbContext.Records.AsNoTracking().ToList();
            }
        }
        #endregion
    }
}
