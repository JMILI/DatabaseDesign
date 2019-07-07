using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankDepositUI.Models;
using BankDeposit.Model.SqlBank;
using BankDeposit.Service;
using Newtonsoft.Json;

namespace BankDepositUI.Controllers
{
    public class ManagersController : Controller
    {
        #region 实例化一些工具对象
        public static Managers manager = new Managers();
        public static ManagersService managerServive = new ManagersService();
        public static CardsController cardsController = new CardsController();
        #endregion

        #region “登录”功能 已实现
        public IActionResult Login(Managers manager)
        {
            this.Response.Cookies.Append("Mid", manager.Mid.ToString());
            this.Response.Cookies.Append("Mname", manager.Mname.ToString());
            this.Response.Cookies.Append("Midentify", manager.Midentify.ToString());
            return View("Login", manager);
        }
        #endregion

        #region “注册银行卡”功能 已实现 
        //模拟柜台管理员给储户开户，即要填写用户基本信息储户账号Cuid，密码Cpassword
        //1.返回填写信息页面
        //2.获得前端页面信息，向数据库Cards表中填写数据。
        //3.返回一个成功页面，展示新增的这项Cards记录
        public IActionResult AddInformation()
        {
            return View();
        }
        public IActionResult AddLogin(Cards card)
        {
            managerServive.AddCardService(card);
            return RedirectToAction("Success", "Managers");
        }
        public IActionResult Success()
        {
            return View();
        }

        public IActionResult ReLogin()
        {
            return RedirectToAction("Login", "Managers", ManagerRequestCookie());
        }
        public Managers ManagerRequestCookie()
        {
            this.Request.Cookies.TryGetValue("Mid", out string Mid);
            int mid = int.Parse(Mid);
            this.Request.Cookies.TryGetValue("Mname", out string Mname);
            string name = Mname;
            this.Request.Cookies.TryGetValue("Midentify", out string Midentify);
            string midentify = Midentify;
            manager.Mid = mid;
            manager.Mname = name;
            manager.Midentify = midentify;
            return manager;
        }
        #endregion

        #region 查询管理员一段时间的办理业务记录 已完成
        public ActionResult BusinessInformation(string limit)
        {
            List<Information> Information = new List<Information>();
            Information = managerServive.BusinessRecordsService(ManagerRequestCookie().Mid, limit);
            return Content(JsonConvert.SerializeObject(Information));
        }
        #endregion

        #region 办理储户的各种业务（复用ATM系统，扩展）待实现

        #region 识别银行卡（银行卡登录）已实现

        public IActionResult VerifyLoginInformation()
        {
            return View();
        }

        public IActionResult BusinessLogin(User card)
        {
            DepositorAndCard dAndC = new DepositorAndCard();
            dAndC = managerServive.LoginCardsService(card);
            if (dAndC != null)
            {
               AddCooikeOfDAndC(dAndC);
                return View();
            }
            else
                return RedirectToAction("CardsLoginError", "Errors");
        }
        #endregion

        #region 定期存款（柜台模拟）已实现
        public IActionResult AddFixInformation()
        {
            return View();
        }
        public IActionResult AddFixBalance(Fixbalances fix)
        {
            managerServive.AddFixBalanceService(DAndC(),fix, ManagerRequestCookie().Mid);
            return RedirectToAction("Success", "Managers");
        }
        #endregion

        #region cooike加入cid,uid,name,以及请求
        public void AddCooikeOfDAndC(DepositorAndCard card1)
        {
            DepositorAndCard dAndC = new DepositorAndCard();
            dAndC = card1;
            this.Response.Cookies.Append("Uid", dAndC.Duid.ToString());
            this.Response.Cookies.Append("Cid", dAndC.Dcid.ToString());
            this.Response.Cookies.Append("Name", dAndC.Dname.ToString());
        }
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
        #endregion
        #endregion

    }
}
