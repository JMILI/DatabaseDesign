using BankDeposit.Data;
using BankDeposit.Model.SqlBank;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankDeposit.Service
{
   public class CardsService
    {
        #region 实例化一些工具对象
        public static AccessCards CardsAccess = new AccessCards();
        public static AccessDepositors DepositorsAccess = new AccessDepositors();
        public static Cards card = new Cards();
        public static Depositors depositor = new Depositors();
        public static DepositorAndCard cards = new DepositorAndCard();
        #endregion

        #region 查询卡登录
        public DepositorAndCard QueryCardsService(User user)
        {
            card = CardsAccess.QueryCardsData(user);
            if (card != null)
            {
                if (card.Cid != user.Id)
                {
                    cards = null;
                }
                else
                {
                    //cards.Dname = user.Uname;
                    cards.Duid = card.Cuid;
                    cards.Dcid = card.Cid;
                    depositor = DepositorsAccess.CheakData(card.Cuid);
                    cards.Dname= depositor.Uname;
                }
            }
            else
            {
                cards = null;
            }
            return cards;
        }
        #endregion
    }
}
