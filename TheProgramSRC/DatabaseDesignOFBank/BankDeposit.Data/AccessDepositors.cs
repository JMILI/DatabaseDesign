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
    }
}
