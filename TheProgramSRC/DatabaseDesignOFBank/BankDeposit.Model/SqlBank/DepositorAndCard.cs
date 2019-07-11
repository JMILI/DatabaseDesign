using System;
using System.Collections.Generic;

namespace BankDeposit.Model.SqlBank
{
    //此类用来封装储户和储户默认银行卡的一个数据库视图
    /// <summary>
    /// 此类用来封装储户和储户默认银行卡的一个数据库视图，Duid,Dcid,Dname
    /// </summary>
    public partial class DepositorAndCard
    {
        /// <summary>
        /// 储户账号（相当于电话号码)
        /// </summary>
        public int Duid { get; set; }
        /// <summary>
        /// 储户的银行卡号，在没有自注册储户账号时，该字段可为空，表示尚未绑定银行卡
        /// </summary>
        public int? Dcid { get; set; }
        /// <summary>
        /// 储户姓名
        /// </summary>
        public string Dname { get; set; }
    }
}

