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
        #region 验证密码取款
        public IActionResult VerifyPasswordError()
        {
            return View();
        }

        #endregion
        #region 管理员登录银行卡报错
        public IActionResult CardsLoginError()
        {
            return View();
        }
        #endregion
        #region 账户已存在页面
        public IActionResult DepositoryExistError()
        {
            return View();
        }
        #endregion

        #region 账户钱不够错误提醒页面
        public IActionResult MoneyError()
        {
            return View();
        }
        #endregion

        #region 绑定错误页面
        /// <summary>
        /// 返回绑定错误页面
        /// </summary>
        /// <returns></returns>
        public IActionResult DepositoryNotExistError()
        {
            return View();
        }
        #endregion
    }
}
