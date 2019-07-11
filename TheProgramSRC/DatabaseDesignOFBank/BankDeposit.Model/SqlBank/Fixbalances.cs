using System;
using System.Collections.Generic;

namespace BankDeposit.Model.SqlBank
{
    /// <summary>
    ///数据库实体表：定期存款表Fixbalances，主键：Fid，字段有：`Fid`, `Fcid`, `Fyear`, `FfixBalanceRate`, `FfixBalance`, `FbusinessTime`, `Fmid`
    /// </summary>
    public partial class Fixbalances
    {
        /// <summary>
        /// Fid，自增，主键
        /// </summary>
        public int Fid { get; set; }
        /// <summary>
        /// Fcid，定期存款表的关联外键，表示是哪个银行卡的存款，非空
        /// </summary>
        public int Fcid { get; set; }
        /// <summary>
        /// Fyear 存款年限
        /// </summary>
        public int? Fyear { get; set; }
        /// <summary>
        /// FfixBalanceRate，存款年利率
        /// </summary>
        public double? FfixBalanceRate { get; set; }
        /// <summary>
        /// FfixBalance ，存款余额
        /// </summary>
        public double? FfixBalance { get; set; }
        /// <summary>
        /// FbusinessTime，存入时间
        /// </summary>
        public DateTime? FbusinessTime { get; set; }
        /// <summary>
        /// 业务办理员
        /// </summary>
        public int? Fmid { get; set; }
    }
}
