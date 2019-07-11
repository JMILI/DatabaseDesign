using System;
using System.Collections.Generic;

namespace BankDeposit.Model.SqlBank
{
    /// <summary>
    ///数据库实体表 管理员表（包含行长）Managers，主键：Mid 自增，字段有Mid，Mname，Mpassword，Midentify
    /// </summary>
    public partial class Managers
    {
        /// <summary>
        /// 主键：Mid 自增
        /// </summary>
        public int Mid { get; set; }
        /// <summary>
        /// 管理员姓名
        /// </summary>
        public string Mname { get; set; }
        /// <summary>
        /// 账号密码
        /// </summary>
        public string Mpassword { get; set; }
        /// <summary>
        /// 管理员身份
        /// </summary>
        public string Midentify { get; set; }
    }
}
