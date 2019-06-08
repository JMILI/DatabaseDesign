using BankDeposit.Data;
using BankDeposit.Model.SqlBank;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankDeposit.Service
{
   public class ManagersService
    {
        #region 实例化一些工具对象
        public static AccessManagers access = new AccessManagers();
        public static Depositors depositor = new Depositors();
        #endregion

        #region 查询管理员（含行长）
        public Managers QueryManagersService(User user)
        {
            return access.QueryManagersData(user);
        }
        #endregion
    }
}
