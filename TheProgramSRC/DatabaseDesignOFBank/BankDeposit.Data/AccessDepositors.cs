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
        public static User user = new User();
        public static Depositors depositor= new Depositors();
        #region 查询储户
        public Depositors QueryDepositorsData(User user)
        {
            using (var dbContext = new bankContext())
            {
               return depositor = dbContext.Depositors.FirstOrDefault(a => a.Uid == user.Id);
            }
        }
        #endregion
        #region 增加账户
        public void AddData(Depositors depositor)
        {
            using (var dbContext = new bankContext())
            {
                dbContext.Add(depositor);
                dbContext.SaveChanges();
            }
        }
        #endregion

    }
}
