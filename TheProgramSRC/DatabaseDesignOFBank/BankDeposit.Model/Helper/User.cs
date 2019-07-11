using System;
using System.Collections.Generic;
using System.Text;

namespace BankDeposit.Model.Helper
{
    /// <summary>
    /// 该类用来封装登录界面填写的信息，并用来传输数据,Id，Password，Identity（身份）
    /// </summary>
    public class User
    {
        /// <summary>
        /// Id登录账号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        ///Password登录密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        ///Identity（登录身份）
        /// </summary>
        public string Identify { get; set; }
    }
}
