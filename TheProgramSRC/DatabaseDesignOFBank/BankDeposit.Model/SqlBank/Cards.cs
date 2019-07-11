using System;
using System.Collections.Generic;

namespace BankDeposit.Model.SqlBank
{
    /// <summary>
    /// 数据库实体表，银行卡表Cards，主键：Cid，无外键，字段有`Cid`, `Cuid`, `Cpassword`, `CflowBalance`, `CflowBalanceRate`
    /// </summary>
    public partial class Cards
    {
        /// <summary>
        /// 主键，自动增加
        /// </summary>
        public int Cid { get; set; }
        /// <summary>
        /// 储户账号(和电话号码性质一样）
        /// </summary>
        public int Cuid { get; set; }
        /// <summary>
        /// 银行卡密码
        /// </summary>
        public string Cpassword { get; set; }
        /// <summary>
        /// 活期存款余额
        /// </summary>
        public double? CflowBalance { get; set; }
        /// <summary>
        /// 活期存款利率
        /// </summary>
        public double? CflowBalanceRate { get; set; }
    }
}
