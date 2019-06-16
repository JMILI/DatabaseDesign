using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BankDeposit.Model.SqlBank;
using Microsoft.EntityFrameworkCore;

namespace BankDeposit.Data
{
    /// <summary>
    /// 此类用于ATM系统访问数据
    /// </summary>
    public class AccessCards
    {
        #region 查询银行卡（登录的）
        public Cards QueryCardsData(User user)
        {
            using (var dbContext = new bankContext())
            {
                return dbContext.Cards.FirstOrDefault(a => a.Cid == user.Id);
            }
        }
        #endregion
    }
}
