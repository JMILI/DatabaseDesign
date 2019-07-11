using BankDeposit.Data;
using BankDeposit.Model.SqlBank;
using System;
using System.Collections.Generic;
using System.Text;
using BankDeposit.Model.Helper;

namespace BankDeposit.Service
{
    public class DAndCService
    {
        #region 实例化一些工具对象
        public static AccessDAndC aAndC = new AccessDAndC();
        #endregion

        #region 查询储户
        /// <summary>
        /// 查询储户
        /// </summary>
        /// <param name="user">传入登录信息，账号Id,Password,Identify</param>
        /// <returns></returns>
        public DepositorAndCard QueryDAndCService(User user)
        {
            return aAndC.QueryDAndCData(user);
        }
        #endregion
    }
}
