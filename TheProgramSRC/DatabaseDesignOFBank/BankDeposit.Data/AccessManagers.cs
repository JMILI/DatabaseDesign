using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BankDeposit.Model.SqlBank;
using Microsoft.EntityFrameworkCore;

namespace BankDeposit.Data
{
    public class AccessManagers
    {
        #region 实例一些容器
        #endregion

        #region 查询管理员与行长 （登录的）
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
