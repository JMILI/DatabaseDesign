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
        #region 实例化一些工具对象
        public static CardsService cardServive = new CardsService();
        public static RecordsService recordsService = new RecordsService();
        #endregion

        #region “登录”功能 已实现
        public IActionResult Login(DepositorAndCard card)
        {
            AddCooikeOfDAndC(card);
            return View("Login", card);
        }
        #endregion

        #region “活期取款”功能 已实现
        //向记录表中填入数据，Ruid ,Rcid, Rwithdrawals DOUBLE(200,3) 
        //1.返回一个包含各种取款金额的页面（100,200,800,500,1000,2000)，模拟取款操作
        //2.获得前端页面信息，更新数据库
        ////2.1 可以将生成的记录向主页展示，选做
        //3.重新返回主页

        public IActionResult VerifyPassword()
        {
            return View();
        }
        public IActionResult Verify(User card)
        {
            DepositorAndCard dAndC = new DepositorAndCard();
            dAndC = DAndC();
            card.Id = (int)dAndC.Dcid;
            if (cardServive.QueryCardsService(card) != null)
            {
                return Redirect(Url.Action("WithDrawal", "Cards"));
            }
            else
                return Redirect(Url.Action("VerifyPasswordError", "Errors"));
        }

        public IActionResult WithDrawal()
        {
            return View();
        }

        public IActionResult WithDrawalInformation(double money)
        {
            DepositorAndCard dAndC = new DepositorAndCard();
            dAndC = DAndC();
            bool istrue = cardServive.Drawal(dAndC, 1, money);
            if (istrue == true)//修改存款余额
            {
                //cardServive.AddRecords(dAndC,1,money);//增加记录表,1代表的是要修改的是取款项
                return Redirect(Url.Action("Success", "Cards"));
            }
            else
            {
                return Redirect(Url.Action("MoneyError", "Errors"));
            }
        }

        public IActionResult Success()
        {
            return View();
        }

        public IActionResult ReLogin()
        {
            DepositorAndCard dAndC = new DepositorAndCard();
            dAndC = DAndC();
            return RedirectToAction("Login", "Cards", dAndC);
        }
        #endregion

        #region “活期存款”功能 待实现

        #endregion

        #region “转账”功能 待实现 选做
        #endregion

        #region 辅助函数获得cooike对象，以及cooike加值
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
        public void AddCooikeOfDAndC(DepositorAndCard card1)
        {
            DepositorAndCard dAndC = new DepositorAndCard();
            dAndC = card1;
            this.Response.Cookies.Append("Uid", dAndC.Duid.ToString());
            this.Response.Cookies.Append("Cid", dAndC.Dcid.ToString());
            this.Response.Cookies.Append("Name", dAndC.Dname.ToString());
        }
        #endregion

    }
}
