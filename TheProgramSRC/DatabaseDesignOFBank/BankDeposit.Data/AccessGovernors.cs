using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BankDeposit.Model.SqlBank;
using Microsoft.EntityFrameworkCore;
using BankDeposit.Model.Helper;

namespace BankDeposit.Data
{
    public class AccessGovernors
    {
        #region 查询是否有管理员 （注册的）H
        /// <summary>
        /// 传入的对象为Managers
        /// </summary>
        /// <param name="manager"></param>
        /// <returns></returns>
        public Managers CheakData(int mid)
        {
            Managers governor = new Managers();
            using (var dbContext = new bankContext())
            {
                return governor = dbContext.Managers.FirstOrDefault(a => a.Mid == mid);
            }
        }
        #endregion
        #region 增加管理员
        public void AddData(Managers manager)
        {
            using (var dbContext = new bankContext())
            {
                //修改数据库信息最好有一些事务操作
                using (var transaction = dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        dbContext.Add(manager);
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

        #region 查询管理员(不含行长）H
        public List<Managers> QueryManagerData()
        {
            using (var dbContext = new bankContext())
            {
                return dbContext.Managers.FromSql("select * from Managers where Midentify='管理员'").AsNoTracking().ToList();
            }
        }
        #endregion


    }
}
