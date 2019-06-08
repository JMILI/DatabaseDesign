using BankDeposit.Data;
using BankDeposit.Model.SqlBank;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankDeposit.Service
{
   public class DAndCService
    {
        #region 实例化一些工具对象
        public static AccessCards access = new AccessCards();
        public static AccessDAndC aAndC = new AccessDAndC();
        public static Cards card = new Cards();
        #endregion
   
        #region 查询储户
        public DepositorAndCard QueryDAndCService(User user)
        {
            return aAndC.QueryDAndCData(user);
        }
        #endregion
    }
}
