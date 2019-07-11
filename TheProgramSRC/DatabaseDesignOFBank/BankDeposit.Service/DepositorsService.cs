using BankDeposit.Data;
using BankDeposit.Model.SqlBank;
//using Microsoft.AspNetCore.Mvc;
using System.Web.Extensions;
using BankDeposit.Model.Helper;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System;

namespace BankDeposit.Service
{
    public class DepositorsService
    {
        #region 实例化一些工具对象
        public static AccessDepositors access = new AccessDepositors();
        public static CardsService cardsService = new CardsService();
        public static FixbalanceService fixbalanceService = new FixbalanceService();
        #endregion

        #region 查询储户
        /// <summary>
        /// 根据封装登录信息的对象User（卡或储户）
        /// </summary>
        /// <param name="user">Id，Password，Identify</param>
        /// <returns>Depositors</returns>
        public DepositorAndCard QueryDepositorsService(User user)
        {
            Depositors depositor = new Depositors();//接受返回值
            DepositorAndCard depositors = new DepositorAndCard();//函数将要返回的对象
            depositor = access.QueryDepositorsData(user);
            if (depositor != null)
            {
                if (depositor.Uid != user.Id)
                {
                    depositors = null;
                }
                else
                {
                    depositors.Dname = depositor.Uname;
                    depositors.Duid = depositor.Uid;
                    depositors.Dcid = depositor.Ucid;
                }
            }
            else
            {
                depositors = null;
            }
            return depositors;
        }
        #endregion

        #region 增加储户
        /// <summary>
        /// 判断是否增加储户成功
        /// </summary>
        /// <param name="depositor">表单填写的储户信息Uid,Uname,UPassword</param>
        /// <returns>DepositorAndCard</returns>
        public DepositorAndCard AddService(Depositors depositor)
        {
            DepositorAndCard depositors = new DepositorAndCard();
            Depositors depositor1 = new Depositors();
            depositor1 = access.CheakData(depositor.Uid);//查询有没有该储户
            if (depositor1 != null)
            {
                depositors = null;
            }
            else
            {
                access.AddData(depositor);
                depositors.Dname = depositor.Uname;
                depositors.Duid = depositor.Uid;
                depositors.Dcid = null;
            }
            return depositors;
        }


        #endregion

        #region 查询十项交易记录
        /// <summary>
        /// DepositorsService层用来查询前十项交易记录的函数,向CardsService对象发送请求。
        /// </summary>
        /// <param name="cid">传入从cooike中查询的cid</param>
        /// <returns>返回一个根据储户当前默认银行卡的交易记录，取前十项</returns>
        public List<Records> TenRecordsService(int cid)
        {
            return cardsService.TenRecordsService(cid);
        }
        #endregion

        #region 储户绑定卡号
        /// <summary>
        /// 储户绑定卡号,先找到该储户，然后找到该储户要绑定的银行卡，最后绑定
        /// </summary>
        /// <param name="depositor">前端传入DepositorAndCard对象，属性：Duid,Dname,Dcid</param>
        /// <returns></returns>
        public bool UpdataBandService(DepositorAndCard depositor)
        {
            Cards card = new Cards();//接受返回数据
            bool s = false;//绑定银行卡成功的标志。true为成功
            Depositors depositor1 = new Depositors();//接受查询到的数据
            depositor1 = access.CheakData(depositor.Duid);//查询有没有该储户
            if (depositor1 != null)//有数据
            {
                if (depositor1.Uid == depositor.Duid)//判断查找到的储户是不是我们要找的
                {
                    card = cardsService.CheakCards((int)depositor.Dcid);
                    if (card != null && card.Cuid == depositor.Duid)//判断查找到的银行卡是不是我们要找的
                    {
                        access.UpdataBandData(depositor);//更新绑定卡号
                        s = true;
                    }
                }
            }
            return s;
        }

        #endregion

        #region 查询活期存款余额情况
        /// <summary>
        ///  查询活期存款余额情况,是DepositoryService的方法，将查询余额利息的职责交给CardsService类来处理
        /// </summary>
        /// <param name="cid">传入查询的cid</param>
        /// <returns></returns>
        public List<double> FlowBalanceService(int cid)
        {
            return cardsService.FlowBalanceService(cid);
        }
        #endregion

        #region 查询定期余额情况
        /// <summary>
        /// 查询定期余额情况,是DepositoryService的方法，将查询余额利息的职责交给FixbalanceService类来处理
        /// </summary>
        /// <param name="cid">传入查询的cid</param>
        /// <returns></returns>
        public List<Fixbalances> FixBalanceService(int cid)
        {
            return fixbalanceService.FixBalancesService(cid);
        }
        #endregion
    }
}
