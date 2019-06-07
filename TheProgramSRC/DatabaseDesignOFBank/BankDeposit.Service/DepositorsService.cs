using BankDeposit.Data;
using BankDeposit.Model.SqlBank;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankDeposit.Service
{
   public class DepositorsService
    {
        public static AccessDepositors access = new AccessDepositors();
        public static Depositors depositor = new Depositors();
        #region 查询储户
        public Depositors QueryDepositorsService(User user)
        {
            return access.QueryDepositorsData(user);
        }

        public void AddService(Depositors depositor)
        {
            access.AddData(depositor);
            //throw new NotImplementedException();
        }
        #endregion
    }
}
