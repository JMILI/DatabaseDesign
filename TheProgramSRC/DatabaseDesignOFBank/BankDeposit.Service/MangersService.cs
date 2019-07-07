﻿using BankDeposit.Data;
using BankDeposit.Model.SqlBank;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankDeposit.Service
{
    public class ManagersService
    {
        #region 实例化一些工具对象
        public static AccessManagers access = new AccessManagers();
        public static Depositors depositor = new Depositors();
        public static CardsService cardServive = new CardsService();
        public static AccessInformation accessInformation = new AccessInformation();
        public static FixbalanceService fixbalanceService = new FixbalanceService();
        public static RecordsService recordsService = new RecordsService();
        #endregion

        #region 查询管理员（含行长）
        public Managers QueryManagersService(User user)
        {
            return access.QueryManagersData(user);
        }

        public void AddCardService(Cards card)
        {
            cardServive.AddCardService(card);
        }

        public List<Information> BusinessRecordsService(int mid, string limit)
        {
            return accessInformation.BusinessData(mid, limit);
        }

        public DepositorAndCard LoginCardsService(User card)
        {
            return cardServive.QueryCardsService(card);
        }

        public void AddFixBalanceService(DepositorAndCard depositorAndCard, Fixbalances fix,int mid)
        {
            fix.Fcid =(int) depositorAndCard.Dcid;
            fixbalanceService.AddFixBalanceService(fix);
            recordsService.AddRecords(depositorAndCard,3,(double)fix.FfixBalance,mid);
        }
        #endregion
    }
}
