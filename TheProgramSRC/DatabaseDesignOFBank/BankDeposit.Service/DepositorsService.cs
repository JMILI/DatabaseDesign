using BankDeposit.Data;
using BankDeposit.Model.SqlBank;
//using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankDeposit.Service
{
   public class DepositorsService
    {
        #region 实例化一些工具对象
        public static AccessDepositors access = new AccessDepositors();
        public static Depositors depositor = new Depositors();
        public static DepositorAndCard depositors = new DepositorAndCard();
        #endregion

        #region 查询储户
        /// <summary>
        /// 根据封装登录信息的对象User（卡或储户）
        /// </summary>
        /// <param name="user">Id，Password，Identify</param>
        /// <returns>Depositors</returns>
        public Depositors QueryDepositorsService(User user)
        {
            return access.QueryDepositorsData(user);
        }
        #endregion

        #region 增加储户
        /// <summary>
        /// 判断是否增加储户成功
        /// </summary>
        /// <param name="depositor">表单填写的储户信息Duid,Dcid,Dname</param>
        /// <returns>DepositorAndCard</returns>
        public DepositorAndCard AddService(Depositors depositor)
        {
            if (access.CheakData(depositor)!=null)
            {
                return null;
            }
            else
            {
                access.AddData(depositor);
                depositors.Dcid = 0;
                depositors.Dname = depositor.Uname;
                depositors.Duid = depositor.Uid;
                return depositors;
            }
        }
        #endregion
    }
}
