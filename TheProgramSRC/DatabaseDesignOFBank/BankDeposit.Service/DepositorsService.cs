using BankDeposit.Data;
using BankDeposit.Model.SqlBank;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankDeposit.Service
{
   public class DepositorsService
    {
        #region 实例化一些工具对象
        public static AccessDepositors access = new AccessDepositors();
        public static Depositors depositor = new Depositors();
        #endregion

        #region 查询储户
        public Depositors QueryDepositorsService(User user)
        {
            return access.QueryDepositorsData(user);
        }
        #endregion

        #region 增肌储户
        public void AddService(Depositors depositor)
        {
            access.AddData(depositor);
        }
        #endregion
    }
}
