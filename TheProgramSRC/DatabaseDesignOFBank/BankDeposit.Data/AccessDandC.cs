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
        public static Cards card = new Cards();
        public static User user = new User();
        public static Depositors depositors = new Depositors();
        public static DepositorAndCard dAndC = new DepositorAndCard();
        #endregion
        #region 查询储户和储户默认的银行卡所构成的视图对象
        public DepositorAndCard QueryDAndCData(User user)
        {
            using (var dbContext = new bankContext())
            {
                if (user.Identify == "depository")
                {
                    depositors = dbContext.Depositors.FirstOrDefault(a => a.Uid == user.Id);
                    if (depositors == null)
                    {
                        return dAndC = null;
                    }
                    //判断是否为正确
                    else if (depositors.Upassword == user.Password)
                    {
                        using (var viewContext = new ViewContext())
                        {
                            dAndC = viewContext.DepositorAndCard.FirstOrDefault(a => a.Dcid == depositors.Ucid);//返回储户和该用户默认的卡号组成的视图
                        }
                    }
                    else dAndC = null;
                }
                else
                {
                    card = dbContext.Cards.FirstOrDefault(a => a.Cid == user.Id);
                    if (card == null)
                    {
                        return dAndC = null;
                    }
                    if (card.Cpassword == user.Password)
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
        }
    }
    #endregion
}

