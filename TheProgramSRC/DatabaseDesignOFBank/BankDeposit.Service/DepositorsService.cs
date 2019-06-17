using BankDeposit.Data;
using BankDeposit.Model.SqlBank;
//using Microsoft.AspNetCore.Mvc;
using System.Web.Extensions;

using System.Collections.Generic;
using System.Web.Script.Serialization;
using System;

namespace BankDeposit.Service
{
    public class DepositorsService
    {
        #region 实例化一些工具对象
        public static AccessDepositors access = new AccessDepositors();
        public static Depositors depositor = new Depositors();
        public static DepositorAndCard depositors = new DepositorAndCard();
        public static User userNow = new User();
        public static List<Records> records = new List<Records>();
        #endregion

        #region 查询储户
        /// <summary>
        /// 根据封装登录信息的对象User（卡或储户）
        /// </summary>
        /// <param name="user">Id，Password，Identify</param>
        /// <returns>Depositors</returns>
        public DepositorAndCard QueryDepositorsService(User user)
        {
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
        /// Service层用来查询前十项交易记录的函数
        /// </summary>
        /// <param name="cid">传入从cooike中查询的cid</param>
        /// <returns>  /// <summary>
        /// Service层用来查询前十项交易记录的函数
        /// </summary>
        /// <returns>返回一个根据储户当前默认银行卡的交易记录，取前十项</returns></returns>
        public List<Records> TenRecordsService(int cid)
        {
            return access.TenRecordsData(cid);
        }
        #endregion
    }
}
