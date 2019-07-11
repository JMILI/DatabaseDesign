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
    /// 访问储户表Depositors，对Depositors表进行操作
    /// </summary>
    public class AccessDepositors
    {
        #region 查询储户 （登录的）
        /// <summary>
        /// 传入的对象为User
        /// </summary>
        /// <param name="user">传入登录信息，账号Id,Password,Identify</param>
        /// <returns></returns>
        public Depositors QueryDepositorsData(User user)
        {
            Depositors depositor = new Depositors();
            using (var dbContext = new bankContext())
            {
                depositor = dbContext.Depositors.FromSql("select * from Depositors where  Uid= {0} and Upassword={1} ",
                    user.Id, user.Password).AsNoTracking().ToList().FirstOrDefault();
                return depositor;
            }
        }
        #endregion

        #region 查询储户 （注册的,绑定卡号的）
        /// <summary>
        /// 查询储户 （注册的,绑定卡号的）根据储户账号查询
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public Depositors CheakData(int uid)
        {
            Depositors depositor = new Depositors();
            using (var dbContext = new bankContext())
            {
                return depositor = dbContext.Depositors.FirstOrDefault(a => a.Uid == uid);
            }
        }
        #endregion

        #region 增加账户 
        /// <summary>
        /// 增加账户
        /// </summary>
        /// <param name="depositor">传入前端页面填写的信息，参数对象Depositors：Uid，Uname，Upassword</param>
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

        #region 绑定银行卡
        /// <summary>
        /// 绑定银行卡,数据访问层,根据储户账号Uid，修改Ucid
        /// </summary>
        /// <param name="depositor">前端传入DepositorAndCard对象，属性：Duid,Dname,Dcid</param>
        public void UpdataBandData(DepositorAndCard depositor)
        {
            using (var dbContext = new bankContext())
            {
                //修改数据库信息最好有一些事务操作
                using (var transaction = dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        var sql = @"Update Depositors SET Ucid =  {0} WHERE Uid =  {1}";
                        dbContext.Database.ExecuteSqlCommand(sql, depositor.Dcid, depositor.Duid);
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
