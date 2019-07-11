using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankDepositUI.Models;
using BankDeposit.Model.SqlBank;
using BankDeposit.Service;
using BankDeposit.Model.Helper;

namespace BankDepositUI.Controllers
{
    public class CardsController : Controller
    {
        #region 实例化一些工具对象
        public static CardsService cardServive = new CardsService();
        public static RecordsService recordsService = new RecordsService();
        #endregion

        #region “登录”功能 已实现
        /// <summary>
        /// “登录”功能,向cooike中加入信息
        /// </summary>
        /// <param name="card">传入DepositorAndCard类型的参数</param>
        /// <returns>返回主页，带参数</returns>
        public IActionResult Login(DepositorAndCard card)
        {

            AddCooikeOfDAndC(card);
            return View("Login", card);
        }
        #endregion

        #region “活期取款”功能 已实现
        /// <summary>
        /// 返回密码验证页面
        /// </summary>
        /// <returns></returns>
        public IActionResult VerifyPassword()
        {
            return View();
        }
        /// <summary>
        /// 接受密码并验证信息
        /// </summary>
        /// <param name="card">接受密码，接受User对象</param>
        /// <returns>返回操作页面</returns>
        public IActionResult Verify(User card)
        {
            card.Id = (int)DAndC().Dcid;
            if (cardServive.QueryCardsService(card) != null)
            {//返回一个取钱页面
                return Redirect(Url.Action("WithDrawal", "Cards"));
            }
            else
                //返回一个验证错误页面
                return Redirect(Url.Action("VerifyPasswordError", "Errors"));
        }

        /// <summary>
        /// 返回取钱页面
        /// </summary>
        /// <returns>返回取钱页面</returns>
        public IActionResult WithDrawal()
        {
            return View();
        }
        /// <summary>
        /// 接受取钱信息
        /// </summary>
        /// <param name="money">传入取钱金额</param>
        /// <returns></returns>
        public IActionResult WithDrawalInformation(double money)
        {
            bool istrue = cardServive.Drawal(DAndC(), 1, money);
            if (istrue == true)//修改存款余额成功
            {//返回成功页面
                return Redirect(Url.Action("Success", "Cards"));
            }
            else
            {//错误页面
                return Redirect(Url.Action("MoneyError", "Errors"));
            }
        }
        /// <summary>
        ///返回成功页面
        /// </summary>
        /// <returns></returns>
        public IActionResult Success()
        {
            return View();
        }
        /// <summary>
        /// 返回操作完之后重新登录主页
        /// </summary>
        /// <returns></returns>
        public IActionResult ReLogin()
        {
            return RedirectToAction("Login", "Cards", DAndC());
        }
        #endregion

        #region 辅助函数获得cooike对象，以及cooike加值
        /// <summary>
        /// 从浏览器获取DepositorAndCard对象的值：Dcid，Dname，Duid
        /// </summary>
        /// <returns>返回DepositorAndCard对象</returns>
        public DepositorAndCard DAndC()
        {
            DepositorAndCard dAndC = new DepositorAndCard();
            this.Request.Cookies.TryGetValue("Cid", out string Cid);
            int cid = int.Parse(Cid);
            this.Request.Cookies.TryGetValue("Uid", out string Uid);
            int uid = int.Parse(Uid);
            this.Request.Cookies.TryGetValue("Name", out string Name);
            string name = Name;
            dAndC.Dcid = cid;
            dAndC.Dname = name;
            dAndC.Duid = uid;
            return dAndC;
        }
        /// <summary>
        /// 向浏览器cooike中加入值DepositorAndCard
        /// </summary>
        /// <param name="card1">传入DepositorAndCard对象</param>
        public void AddCooikeOfDAndC(DepositorAndCard dAndC)
        {
            this.Response.Cookies.Append("Uid", dAndC.Duid.ToString());
            this.Response.Cookies.Append("Cid", dAndC.Dcid.ToString());
            this.Response.Cookies.Append("Name", dAndC.Dname.ToString());
        }
        #endregion

    }
}
