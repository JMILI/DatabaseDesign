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
using BankDeposit.Model.Helper;
using System.Security.Cryptography;
using System.Text;

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
        /// <summary>
        /// 跳转到柜台管理员主页
        /// </summary>
        /// <param name="manager">传入登录页面输入的信息</param>
        /// <returns></returns>
        public IActionResult Login(Managers manager)
        {
            cooikeAdd(manager);
            return View("Login", manager);
        }
        #endregion

        #region “注册银行卡”功能 已实现 
        /// <summary>
        /// 返回填写注册银行卡信息页面
        /// </summary>
        /// <returns></returns>
        public IActionResult AddInformation()
        {
            return View();
        }
        /// <summary>
        /// 数据库增加信息，并返回一个成功页面
        /// </summary>
        /// <param name="card">前端页面填写的信息：CflowBalanceRate，Cpassword，Cuid</param>
        /// <returns></returns>
        public IActionResult AddLogin(Cards card)
        {
            card.Cpassword=MD5Encrypt64(card.Cpassword);//Md5加密
            managerServive.AddCardService(card);
            return RedirectToAction("Success", "Managers");
        }
        /// <summary>
        /// 返回成功页面
        /// </summary>
        /// <returns></returns>
        public IActionResult Success()
        {
            return View();
        }
        /// <summary>
        /// 重新登录管理员主页，
        /// </summary>
        /// <returns></returns>
        public IActionResult ReLogin()
        {
            return RedirectToAction("Login", "Managers", ManagerRequestCookie());
        }
        #endregion

        #region 查询管理员一段时间的办理业务记录 已完成
        /// <summary>
        /// 查询管理员一段时间的办理业务记录
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        public ActionResult BusinessInformation(string limit)
        {
            List<Information> Information = new List<Information>();
            Information = managerServive.BusinessRecordsService(ManagerRequestCookie().Mid, limit);
            return Content(JsonConvert.SerializeObject(Information));
        }
        #endregion

        #region 办理储户的各种业务（复用ATM系统，扩展）待实现

        #region 识别银行卡（银行卡登录）已实现
        /// <summary>
        /// 返回验证信息页面，主要填写密码
        /// </summary>
        /// <returns></returns>
        public IActionResult VerifyLoginInformation()
        {
            return View();
        }
        /// <summary>
        /// 接受前端页面的User信息
        /// </summary>
        /// <param name="card">User型对象：Id，Password</param>
        /// <returns></returns>
        public IActionResult BusinessLogin(User card)
        {
            card.Password = MD5Encrypt64(card.Password);//Md5加密
            DepositorAndCard dAndC = new DepositorAndCard();
            dAndC = managerServive.LoginCardsService(card);
            if (dAndC != null)//不空，证明验证成功
            {
                AddCooikeOfDAndC(dAndC);
                return View();//返回业务办理页面
            }
            else
                return RedirectToAction("CardsLoginError", "Errors");
        }
        #endregion

        #region 定期存款（柜台模拟）已实现
        /// <summary>
        /// 定期存款（柜台模拟）返回填写信息页面
        /// </summary>
        /// <returns>返回填写信息页面</returns>
        public IActionResult AddFixInformation()
        {
            return View();
        }
        /// <summary>
        /// 定期存款表增加记录。
        /// </summary>
        /// <param name="fix">Fyear，FfixBalanceRate，FfixBalance，FfixBalance</param>
        /// <returns></returns>
        public IActionResult AddFixBalance(Fixbalances fix)
        {
            managerServive.AddFixBalanceService(DAndC(), fix, ManagerRequestCookie().Mid);
            return RedirectToAction("Success", "Managers");
        }
        #endregion

        #region 活期存款（柜台模拟）已实现
       /// <summary>
       /// 返回存款填写信息页面。由于没有读款器，用填写信息代替读款器数钱的过程
       /// </summary>
       /// <returns></returns>
        public IActionResult AddFlowInformation()
        {
            return View();
        }
        /// <summary>
        /// 接受参数，然后修改数据库Cards表中的CflowBalance
        /// </summary>
        /// <param name="card">CflowBalance</param>
        /// <returns></returns>
        public IActionResult AddFlowBalance(Cards card)
        {
            managerServive.AddFlowBalanceService(DAndC(), card, ManagerRequestCookie().Mid);
            return RedirectToAction("Success", "Managers");
        }
        #endregion

        #region “查询活期余额”功能 已实现
        /// <summary>
        /// 查询活期余额,页面返回一个余额，一个利息
        /// </summary>
        /// <returns></returns>
        public ActionResult FlowBalance()
        {
            List<Double> record = new List<Double>();
            record = managerServive.FlowBalanceService((int)DAndC().Dcid);//这里需要service返回一个余额，一个利息
            return Content(JsonConvert.SerializeObject(record));//以json方式
        }
        #endregion

        #region “查询定期余额”功能 已实现
        /// <summary>
        /// 查询定期余额,传入银行卡账号，并查询其定期存款记录，以列表展示
        /// </summary>
        /// <returns></returns>
        public ActionResult FixBalance()
        {
            List<Fixbalances> record = new List<Fixbalances>();
            record = managerServive.FixBalanceService((int)DAndC().Dcid);
            return Content(JsonConvert.SerializeObject(record));//以json方式
        }
        #endregion

        #region cooike加入cid,uid,name,以及请求
        /// <summary>
        /// 向浏览器cooike中加入值DepositorAndCard
        /// </summary>
        /// <param name="card1">传入DepositorAndCard对象</param>
        public void AddCooikeOfDAndC(DepositorAndCard card1)
        {
            this.Response.Cookies.Append("Uid", card1.Duid.ToString());
            this.Response.Cookies.Append("Cid", card1.Dcid.ToString());
            this.Response.Cookies.Append("Name", card1.Dname.ToString());
        }
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
        #endregion

        #endregion

        #region 辅助函数：登录，注册功能模块中，加入cooike,获取cooike
        /// <summary>
        /// 向浏览器cooike中加入值DepositorAndCard
        /// </summary>
        /// <param name="card1">传入DepositorAndCard对象</param>
        public void cooikeAdd(Managers manager)
        {
            this.Response.Cookies.Append("Mid", manager.Mid.ToString());
            this.Response.Cookies.Append("Mname", manager.Mname.ToString());
            this.Response.Cookies.Append("Midentify", manager.Midentify.ToString());
        }
        /// <summary>
        /// 从浏览器获取Managers对象的值：Dcid，Dname，Duid
        /// </summary>
        /// <returns>返回Managers对象</returns>
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

        #region 辅助函数MD5加密用户密码
        /// <summary>
        /// MD5加密用户密码
        /// </summary>
        /// <param name="password"> 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　</param>
        /// <returns></returns>
        public static string MD5Encrypt64(string password)
        {
            string cl = password;
            MD5 md5 = MD5.Create(); //实例化一个md5对像
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
            return Convert.ToBase64String(s);
        }
        #endregion

    }
}
