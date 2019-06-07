using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BankDeposit.Model.SqlBank;
using Microsoft.EntityFrameworkCore;

namespace BankDeposit.Data
{
    public class AccessUser
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
        #region 查询银行卡
        public Depositors QueryCardsData(User user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region 查询管理员与行长
        public Depositors QueryManagersData(User user)
        {
            throw new NotImplementedException();
        }
        #endregion

        //public User QueryUserData(User user)
        //{
        //    throw new NotImplementedException();
        //}

        //public void AddData(User user)
        //{
        //    throw new NotImplementedException();
        //}

        //public User UpdateData(User user)
        //{
        //    throw new NotImplementedException();
        //}

        //public void DeleteData(string userId)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
