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
    public class CardsController : Controller
    {
        public static Cards card  = new Cards();
        #region 登录
        public IActionResult Login(DepositorAndCard card)
        {
            this.Response.Cookies.Append("Uid", card.Dcid.ToString());
            this.Response.Cookies.Append("Cid", card.Duid.ToString());
            this.Response.Cookies.Append("Uname", card.Duid.ToString());
            return View("Login", card);
        }
        #endregion
        #region  退出登录
        //public IActionResult LogOut(DepositorAndCard card)
        //{

        //}
        #endregion
        #region 
        #endregion
        #region 
        #endregion
    }
}
