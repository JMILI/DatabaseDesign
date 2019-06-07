using BankDeposit.Data;
using BankDeposit.Model.SqlBank;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankDeposit.Service
{
   public class CardsService
    {
        public static AccessCards access = new AccessCards();
        public static Cards card  = new Cards();
        #region 查询储户
        public Cards QueryCardsService(User user)
        {
            return access.QueryCardsData(user);
        }
        #endregion
    }
}
