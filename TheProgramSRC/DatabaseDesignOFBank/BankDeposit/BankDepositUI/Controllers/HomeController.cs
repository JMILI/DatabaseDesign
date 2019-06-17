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
    /// <summary>
    /// 最开始登录时，系统选择控制器
    /// </summary>
    public class HomeController : Controller
    {
        #region 实例一些工具对象
        public static DepositorsService depositorServive = new DepositorsService();
        public static CardsService cardServive = new CardsService();
        public static ManagersService managerServive = new ManagersService();
        public static DAndCService dAndCServive = new DAndCService();

        public static Depositors depositor = new Depositors();
        public static Cards card = new Cards();
        public static Managers manager = new Managers();
        public static DepositorAndCard dAndC = new DepositorAndCard();
        public static User users = new User();
        #endregion

        #region 返回登录初始页面
        public IActionResult Index()
        {
            //返回登录页面
            return View();
        }
        #endregion

        #region 分情况，分别登录各个系统
        /// <summary>
        /// 接受页面参数，准备判断应该登录那个系统
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public IActionResult SignIn(User user)
        {
            //此处分类，让储户,管理员分别登录到自己的界面，
            //还有ATM系统登录（利用卡号登录）
            #region 储户新版本
            if (user.Identify == "depository")
            {
                dAndC = depositorServive.QueryDepositorsService(user);
                if (dAndC != null)
                {
                    return RedirectToAction("Login", "Depositors", dAndC);
                }
                else
                    return Redirect(Url.Action("PasswordError", "Errors"));
            }
            #endregion
            #region ATM-银行卡
            else if (user.Identify == "cards")
            {
                dAndC = cardServive.QueryCardsService(user);
                if (dAndC != null)
                {
                    return RedirectToAction("Login", "Cards", dAndC);
                }
                else
                    return Redirect(Url.Action("PasswordError", "Errors"));
            }
            #endregion
            #region 管理员或行长
            else
            {
                manager = managerServive.QueryManagersService(user);
                if (manager == null || manager.Mpassword != user.Password)
                {
                    return Redirect(Url.Action("PasswordError", "Errors"));
                }
                else if (user.Identify == "manager")
                {
                    manager.Mpassword = "***";
                    return RedirectToAction("Login", "Managers", manager);
                }
                else
                {
                    depositor.Upassword = "***";
                    return RedirectToAction("Login", "Governors", manager);
                }
            }
            #endregion
        }
        #endregion
    }
}
