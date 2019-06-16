using System;
using System.Collections.Generic;
using System.Text;

namespace BankDeposit.Model.SqlBank
{
    /// <summary>
    /// 该类用来封装登录界面填写的信息，并用来传输数据
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string Identify { get; set; }
    }
}
