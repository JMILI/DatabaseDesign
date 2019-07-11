using System;
using System.Collections.Generic;

namespace BankDeposit.Model.SqlBank
{
    /// <summary>
    /// 数据可实体表 交易记录表Records ，Rid 主键自增，字段有`Rid`, `Ruid`, `Rcid`, `RflowDeposit`, `RfixDepostit`, `Rwithdrawals`, `RnowDateTime`, `Rmid`
    /// </summary>
    public partial class Records
    {
        /// <summary>
        /// Rid 主键自增
        /// </summary>
        public int Rid { get; set; }
        /// <summary>
        /// Ruid 储户账号
        /// </summary>
        public int Ruid { get; set; }
        /// <summary>
        /// Rcid 储户默认银行卡账号
        /// </summary>
        public int Rcid { get; set; }
        /// <summary>
        ///RflowDeposit  活期存款额
        /// </summary>
        public double? RflowDeposit { get; set; }
        /// <summary>
        /// RfixDepostit 定期存款额
        /// </summary>
        public double? RfixDepostit { get; set; }
        /// <summary>
        /// Rwithdrawals 取款额
        /// </summary>
        public double? Rwithdrawals { get; set; }
        /// <summary>
        /// RnowDateTime 交易时间
        /// </summary>
        public DateTime? RnowDateTime { get; set; }
        /// <summary>
        /// Rmid 业务办理员
        /// </summary>
        public int? Rmid { get; set; }
    }
}
