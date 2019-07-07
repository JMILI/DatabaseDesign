using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BankDeposit.Model.SqlBank;
using Microsoft.EntityFrameworkCore;
namespace BankDeposit.Data
{
    public class AccessDAndC
    {
        #region 实例一些容器
        //public static User user = new User();
        public static Cards card = new Cards();
        public static Depositors depositors = new Depositors();
        public static DepositorAndCard dAndC = new DepositorAndCard();
        #endregion

        #region 查询储户和储户默认的银行卡所构成的视图对象 （登录的）
        public DepositorAndCard QueryDAndCData(User user)
        {
            using (var dbContext = new bankContext())
            {
                if (user.Identify == "depository") return QueryDepositorData(user);
                else return QueryCardsData(user);
            }
        }

        #region 查询是否为储户
        public DepositorAndCard QueryDepositorData(User user)
        {
            using (var dbContext = new bankContext())
            {
                depositors = dbContext.Depositors.FirstOrDefault(a => a.Uid == user.Id);
                //判断是否为正确
                if (depositors != null && depositors.Upassword == user.Password)
                {
                    using (var viewContext = new ViewContext())
                    {
                        dAndC = viewContext.DepositorAndCard.FirstOrDefault(a => a.Dcid == depositors.Ucid);//返回储户和该用户默认的卡号组成的视图
                    }
                }
                else dAndC = null;
            }
            return dAndC;
        }
        #endregion 

        #region 查询是否为银行卡登录
        public DepositorAndCard QueryCardsData(User user)
        {
            using (var dbContext = new bankContext())
            {
                card = dbContext.Cards.FirstOrDefault(a => a.Cid == user.Id);
                if (card != null && card.Cpassword == user.Password)
                {
                    using (var viewContext = new ViewContext())
                    {
                        dAndC = viewContext.DepositorAndCard.FirstOrDefault(a => a.Dcid == card.Cid);//返回储户和该用户默认的卡号组成的视图
                    }
                }
                else dAndC = null;
            }
            return dAndC;
        }
        #endregion 
    }
    #endregion
}

