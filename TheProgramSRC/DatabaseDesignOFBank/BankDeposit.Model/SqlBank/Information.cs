using System;
using System.Collections.Generic;
using System.Text;

namespace BankDeposit.Model.SqlBank
{
    /// <summary>
    /// 视图表，数据库没有其实体，提取记录表表项和用户名，以记录表Records的主键Rid为主键Irid。
    /// 字段有Irid,Iname,Iuid，Icid，IflowDeposit，IfixDepostit，Iwithdrawals，Ioldtime
    /// </summary>
    public class Information
    {
        /// <summary>
        /// Irid 主键
        /// </summary>
        public int Irid { get; set; }
        /// <summary>
        /// Iname 储户姓名
        /// </summary>
        public string Iname { get; set; }
        /// <summary>
        /// Iuid 储户账号
        /// </summary>
        public int Iuid { get; set; }
        /// <summary>
        /// Icid 储户默认银行卡账号
        /// </summary>
        public int Icid { get; set; }
        /// <summary>
        /// IflowDeposit 活期存款额
        /// </summary>
        public double IflowDeposit { get; set; }
        /// <summary>
        /// IfixDepostit 定期存款额
        /// </summary>
        public double IfixDeposit { get; set; }
        /// <summary>
        /// Iwithdrawals 取款额
        /// </summary>
        public double Iwithdrawals { get; set; }
        /// <summary>
        /// Ioldtime 交易时间
        /// </summary>
        public DateTime? Ioldtime { get; set; }
        /// <summary>
        /// Imid，业务办理员
        /// </summary>
        public int Imid { get; set; }
    }
}
