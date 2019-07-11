using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BankDeposit.Model.SqlBank;
using Microsoft.EntityFrameworkCore;
using BankDeposit.Model.Helper;

namespace BankDeposit.Data
{
    /// <summary>
    /// 访问数据库Managers表，进行各种操作
    /// </summary>
    public class AccessManagers
    {
        #region 查询管理员与行长 （登录的）
        /// <summary>
        /// 查询管理员与行长 （登录的）
        /// </summary>
        /// <param name="user">,Id，Password，Identity（身份）</param>
        /// <returns></returns>
        public Managers QueryManagersData(User user)
        {
            using (var dbContext = new bankContext())
            {
                return dbContext.Managers.FirstOrDefault(a => a.Mid == user.Id);
            }
        }
        #endregion

    }
}
