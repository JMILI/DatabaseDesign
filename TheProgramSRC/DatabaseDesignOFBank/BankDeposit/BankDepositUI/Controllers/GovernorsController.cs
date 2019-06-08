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
    public class GovernorsController : Controller
    {
        #region  实例化一些工具对象
        public static Managers manager = new Managers();
        #endregion

        #region  “登录”功能 已实现
        public IActionResult Login(Managers manager)
        {
            this.Response.Cookies.Append("Mid", manager.Mid.ToString());
            this.Response.Cookies.Append("Mname", manager.Mname.ToString());
            this.Response.Cookies.Append("Midentify", manager.Midentify.ToString());
            return View("Login", manager);
        }
        #endregion

        #region 统计银行资金流量情况（三选一，试着如何用图标统计,并展示）

        #region  “统计银行每月的资金流动”功能 待实现
        //具体如何统计，看自己如何设计
        #endregion

        #region  “统计银行季度的资金流动”功能 待实现
        //具体如何统计，看自己如何设计
        #endregion

        #region  “统计银行每年的资金流动”功能 待实现
        //具体如何统计，看自己如何设计
        #endregion

        #endregion

        #region "管理员展示“功能 待实现
        //可以只做管理员信息展示，至于量化评价，可以不实现
        #endregion

        #region  “增添管理员”功能 待实现（选做）和注册类似

        #endregion
    }
}
