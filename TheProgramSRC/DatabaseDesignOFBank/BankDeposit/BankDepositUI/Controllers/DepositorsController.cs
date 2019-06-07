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
    public class DepositorsController : Controller
    {
        public static DepositorsService depositorServive = new DepositorsService();
        public static Depositors depositor = new Depositors();
        public static DepositorAndCard depositors = new DepositorAndCard();

        #region 登录
        public IActionResult Login(DepositorAndCard depositor)
        {
            cooikeAdd(depositor);
            return View("Login", depositor);
        }
        #endregion
        #region 登录，注册，加入cooike
        public void cooikeAdd(DepositorAndCard depositor)
        {
            this.Response.Cookies.Append("Uid", depositor.Dcid.ToString());
            this.Response.Cookies.Append("Cid", depositor.Duid.ToString());
            this.Response.Cookies.Append("Uname", depositor.Duid.ToString());
        }
        #endregion
        #region  注册储户
        public IActionResult AddInformation()
        {
            return View();
        }
        public IActionResult AddLogin(Depositors depositor)
        {
            depositorServive.AddService(depositor);
            depositors.Dcid = 0;
            depositors.Dname = depositor.Uname;
            depositors.Duid = depositor.Uid;
            cooikeAdd(depositors);
            return RedirectToAction("Login", "Depositors", depositors);
        }
        #endregion
        #region 
        #endregion
        #region 
        #endregion
        #region 
        #endregion
        #region 
        #endregion

    }
}
