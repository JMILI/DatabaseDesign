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
        public static User user = new User();
        #region 查询管理员与行长
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
