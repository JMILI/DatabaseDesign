using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BankDeposit.Model.SqlBank;
using Microsoft.EntityFrameworkCore;

namespace BankDeposit.Data
{
    public class AccessUser
    {
        #region 实例一些容器
        public static User user = new User();
        public static Depositors depositor = new Depositors();
        #endregion
    }
}
