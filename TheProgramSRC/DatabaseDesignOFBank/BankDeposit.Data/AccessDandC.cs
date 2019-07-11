using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BankDeposit.Model.SqlBank;
using BankDeposit.Model.Helper;
using Microsoft.EntityFrameworkCore;
namespace BankDeposit.Data
{
    /// <summary>
    /// 储户和银行卡联合的视图访问类
    /// </summary>
    public class AccessDAndC
    {
        #region 查询储户和储户默认的银行卡所构成的视图对象
        /// <summary>
        /// 查询储户和储户默认的银行卡所构成的视图对象
        /// </summary>
        /// <param name="user">传入登录信息，账号Id,Password,Identify</param>
        /// <returns></returns>
        public DepositorAndCard QueryDAndCData(User user)
        {
            using (var dbContext = new bankContext())
            {
                if (user.Identify == "depository") return QueryDepositorData(user);//判断登录着身份
                else return QueryCardsData(user);
            }
        }

        #region 查询储户
        /// <summary>
        /// 查询银行卡登录
        /// </summary>
        /// <param name="user">传入登录信息，账号Id,Password,Identify</param>
        /// <returns></returns>
        public DepositorAndCard QueryDepositorData(User user)
        {
            Depositors depositors = new Depositors();//接受查询到的数据
            DepositorAndCard dAndC = new DepositorAndCard();//函数将返回DepositorAndCard对象
            using (var dbContext = new bankContext())
            {
                depositors = dbContext.Depositors.FirstOrDefault(a => a.Uid == user.Id);
                //判断是否为正确
                if (depositors != null && depositors.Upassword == user.Password)
                {
                    using (var viewContext = new ViewContext())//视图查询环境
                    {
                        dAndC = viewContext.DepositorAndCard.FirstOrDefault(a => a.Dcid == depositors.Ucid);//返回储户和该用户默认的卡号组成的视图
                    }
                }
                else dAndC = null;
            }
            return dAndC;
        }
        #endregion 

        #region 查询银行卡登录
        /// <summary>
        /// 查询银行卡登录
        /// </summary>
        /// <param name="user">传入登录信息，账号Id,Password,Identify</param>
        /// <returns></returns>
        public DepositorAndCard QueryCardsData(User user)
        {
            Cards card = new Cards();//接受查询到的数据
            DepositorAndCard dAndC = new DepositorAndCard();//函数将返回DepositorAndCard对象
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
        #endregion
    }
}

