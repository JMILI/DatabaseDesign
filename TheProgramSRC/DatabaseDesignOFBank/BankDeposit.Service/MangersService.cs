using BankDeposit.Data;
using BankDeposit.Model.SqlBank;
using System;
using System.Collections.Generic;
using System.Text;
using BankDeposit.Model.Helper;

namespace BankDeposit.Service
{
    /// <summary>
    /// Managers表的业务逻辑层类，处理对Managers表的数据处理
    /// </summary>
    public class ManagersService
    {
        #region 实例化一些工具对象
        public static AccessManagers access = new AccessManagers();
        public static CardsService cardServive = new CardsService();
        public static AccessInformation accessInformation = new AccessInformation();
        public static FixbalanceService fixbalanceService = new FixbalanceService();
        public static RecordsService recordsService = new RecordsService();
        #endregion

        #region 查询管理员（含行长）
        /// <summary>
        /// 查询管理员（含行长）
        /// </summary>
        /// <param name="user">,Id，Password，Identity（身份）</param>
        /// <returns></returns>
        public Managers QueryManagersService(User user)
        {
            return access.QueryManagersData(user);
        }
        #endregion

        #region 增加银行卡
        /// <summary>
        /// 增加银行卡,ManagerService对象调用CardService对象，将任务直接交给他，它是对银行卡操作的直接对象，ManagerService只能向其提出需求。
        /// </summary>
        /// <param name="card">前端页面填写的信息：CflowBalanceRate，Cpassword，Cuid</param>
        public void AddCardService(Cards card)
        {
            cardServive.AddCardService(card);
        }
        #endregion

        #region 查询管理员业务办理记录
        /// <summary>
        /// 查询管理员业务办理记录，由于Information是一个视图，只可以查询，其没有其他操作，所以没有其对应的业务逻辑处理层类
        /// </summary>
        /// <param name="mid">传入管理员的账号</param>
        /// <param name="limit">传入范围，今天，本周，本月</param>
        /// <returns>返回业务记录</returns>
        public List<Information> BusinessRecordsService(int mid, string limit)
        {
            return accessInformation.BusinessData(mid, limit);
        }
        #endregion

        #region ATM系统登录查询银行卡信息。
        /// <summary>
        /// ATM系统登录查询银行卡信息,ManagerService对象调用CardService对象，将任务直接交给它，
        /// 它是对银行卡操作的直接对象，ManagerService只能向其提出需求。
        /// </summary>
        /// <param name="card">User型对象：Id，Password</param>
        /// <returns></returns>
        public DepositorAndCard LoginCardsService(User card)
        {
            return cardServive.QueryCardsService(card);
        }
        #endregion

        #region 增加定期存款
        /// <summary>
        /// 增加定期存款记录，并向FixBalance表添加存款数据，分别向fixbalanceService，recordsService提出需求。
        /// </summary>
        /// <param name="depositorAndCard">传入从cooike中获取的储户和储户银行卡信息。其对象为DepositorAndCard</param>
        /// <param name="fix">Fyear，FfixBalanceRate，FfixBalance，FfixBalance</param>
        /// <param name="mid">传入业务办理员账号Mid</param>
        public void AddFixBalanceService(DepositorAndCard depositorAndCard, Fixbalances fix, int mid)
        {
            fix.Fcid = (int)depositorAndCard.Dcid;
            fix.Fmid = mid;
            fixbalanceService.AddFixBalanceService(fix);
            recordsService.AddRecordsService(depositorAndCard, 3, (double)fix.FfixBalance, mid);
        }
        #endregion

        #region 查询活期存款余额情况
        /// <summary>
        ///  是ManagerService的方法，将查询余额利息的职责交给CardsService类来处理,ManagerService对象调用CardService对象，
        ///  任务直接交给他，它是对银行卡操作的直接对象，ManagerService只能向其提出需求
        /// </summary>
        /// <param name="cid">传入银行卡账号</param>
        /// <returns></returns>
        public List<double> FlowBalanceService(int cid)
        {
            return cardServive.FlowBalanceService(cid);
        }
        #endregion

        #region 查询定期余额情况
        /// <summary>
        ///  是ManagerService的方法，将查询余额利息的职责交给FixBalanceService类来处理,ManagerService对象调用FixBalanceService对象，
        ///  任务直接交给他，它是对定期存款表FixBalance表操作的直接对象，ManagerService只能向其提出需求
        /// </summary>
        /// <param name="cid">传入银行卡账号</param>
        /// <returns></returns>
        public List<Fixbalances> FixBalanceService(int cid)
        {
            return fixbalanceService.FixBalancesService(cid);
        }

        #endregion

        #region 增加活期存款
        /// <summary>
        /// 增加活期存款记录Records,并向修改cards表中的数据，分别向cardServive，recordsService提出需求。
        /// </summary>
        /// <param name="dAndC">传入从cooike中获取的储户和储户银行卡信息。其对象为DepositorAndCard</param>
        /// <param name="card">CflowBalance</param>
        /// <param name="mid">传入业务办理员账号Mid</param>
        public void AddFlowBalanceService(DepositorAndCard dAndC, Cards card, int mid)
        {
            Cards cardss = new Cards();
            cardss = cardServive.CheakCards((int)dAndC.Dcid);//查询原来的银行卡信息
            cardss.CflowBalance = cardss.CflowBalance + card.CflowBalance;//修改活期余额
            cardServive.UpdataFlowBalanceService(cardss);//更新
            recordsService.AddRecordsService(dAndC, 2, (double)card.CflowBalance, mid);//Records生成记录
        } 
        #endregion
    }
}
