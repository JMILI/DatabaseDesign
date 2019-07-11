using Microsoft.AspNetCore.Mvc;
using BankDeposit.Model.SqlBank;
using BankDeposit.Service;
using BankDeposit.Model.Helper;
using System.Security.Cryptography;
using System.Text;
using System;

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

        public static Managers manager = new Managers();
        public static DepositorAndCard dAndC = new DepositorAndCard();
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

        #region 返回登录初始页面
        /// <summary>
        /// 登录账户页面
        /// </summary>
        /// <returns></returns>
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
        /// <param name="user">传入登录信息，账号Id,Password,Identify</param>
        /// <returns></returns>
        public IActionResult SignIn(User user)
        {
            user.Password = MD5Encrypt64(user.Password);//接到登录信息，给密码加密
            //此处分类，让储户,管理员分别登录到自己的界面，
            //还有ATM系统登录（利用卡号登录）
            #region 储户新版本
            if (user.Identify == "depository")
            {
                dAndC = depositorServive.QueryDepositorsService(user);//验证信息
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
                dAndC = cardServive.QueryCardsService(user);//验证信息
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
                manager = managerServive.QueryManagersService(user);//验证信息
                if (manager == null || manager.Mpassword != user.Password)
                {
                    return Redirect(Url.Action("PasswordError", "Errors"));
                }
                else if (user.Identify == "manager")
                {
                    return RedirectToAction("Login", "Managers", manager);
                }
                else
                {
                    return RedirectToAction("Login", "Governors", manager);
                }
            }
            #endregion
        }
        #endregion
    }
}
