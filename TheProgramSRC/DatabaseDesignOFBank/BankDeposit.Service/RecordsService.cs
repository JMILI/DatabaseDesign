using BankDeposit.Data;
using BankDeposit.Model.SqlBank;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankDeposit.Service
{
    public class RecordsService
    {
        #region 实例化一些工具对象
        public static AccessCards access = new AccessCards();
        public static AccessRecords accessRecords = new AccessRecords();
        public static AccessDAndC aAndC = new AccessDAndC();
        public static Records record = new Records();

        public void AddRecords(DepositorAndCard dAndC, int v, double money, int mid)
        {
            accessRecords.Add(dAndC, v, money, mid);
        }


        #endregion


    }
}
