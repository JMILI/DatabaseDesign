using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankDepositUI.Models;
using BankDeposit.Model.SqlBank;
using BankDeposit.Service;

namespace BankDepositUI.Controllers
{
    public class ErrorsController : Controller
    {
        #region 账户或密码错误页面
        public IActionResult PasswordError()
        {
            return View();
        }
        #endregion
    }
}
