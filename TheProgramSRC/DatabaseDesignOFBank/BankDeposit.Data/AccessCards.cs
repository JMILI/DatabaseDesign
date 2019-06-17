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
        public static Cards card = new Cards();

        #region 查询银行卡（登录的）
        public Cards QueryCardsData(User user)
        {
            using (var dbContext = new bankContext())
            {
                card = dbContext.Cards.FromSql("select * from Cards where  Cid= {0} and Cpassword={1} ",
                    user.Id, user.Password).AsNoTracking().ToList().FirstOrDefault();
                return card;
            }
            //return access.QueryCardsData(user);
        }
        #endregion
    }
}
