using System;
using System.Collections.Generic;

namespace BankDeposit.Model.SqlBank
{
    /// <summary>
    /// 数据库实体表，储户表Depositors，主键：Uid，无外键，字段有`Uid`, `Ucid`, `Uname`, `Upassword`, `Uidentify`, `Ustatus`
    /// </summary>
    public partial class Depositors
    {
        /// <summary>
        /// 储户账号，非自增，自己填写，一般为电话号码
        /// </summary>
        public int Uid { get; set; }
        /// <summary>
        /// 储户默认绑定的银行卡，（储户可以有多个卡，但是有一个默认可以支付的卡），非外键，可为空
        /// </summary>
        public int? Ucid { get; set; }
        /// <summary>
        /// 储户姓名
        /// </summary>
        public string Uname { get; set; }
        /// <summary>
        /// 储户密码
        /// </summary>
        public string Upassword { get; set; }
        /// <summary>
        /// 储户的身份
        /// </summary>
        public string Uidentify { get; set; }
        /// <summary>
        /// 储户的状态
        /// </summary>
        public string Ustatus { get; set; }
    }
}
