using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankDepositUI.Models;
using BankDeposit.Model.SqlBank;
using BankDeposit.Model.Helper;
using BankDeposit.Service;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;

namespace BankDepositUI.Controllers
{
    public class GovernorsController : Controller
    {
        #region  实例化一些工具对象
        public static GovernorsService governorsService = new GovernorsService();
        public static GovernorsService managersService = new GovernorsService();
        #endregion

        #region  “登录”功能 已实现
        public IActionResult Login(Managers manager)
        {
            cooikeAdd(manager);
            return View("Login", manager);
        }
        #endregion

        #region  “增添管理员”功能 已实现（选做）和注册类似
        //1.返回填写信息页面
        public IActionResult AddInformation()
        {
            return View();
        }
        //2.将返回的信息进行处理，然后登陆系统主页
        /// <summary>
        /// 
        /// </summary>
        /// <param name="managers">Mid,Mname,MPassword</param>
        /// <returns></returns>
        public IActionResult AddLogin(Managers governors)
        {
            governors.Mpassword = MD5Encrypt64(governors.Mpassword);
            governorsService.AddService(governors);
            return RedirectToAction("Success", "Governors", governors);
        }
        public IActionResult Success()
        {
            return View();
        }
        public IActionResult ReLogin()
        {
            return View("Login", RequestCooikeManager());
        }
        #endregion

        #region  “按月统计收支，利润”功能  已完成
        /// <summary>
        ///  “按月统计收支，利润”功能
        /// </summary>
        /// <returns>返回需要展示的数据信息（已被处理）</returns>
        public ActionResult StatisticalByMonth()
        {
            return Content(JsonConvert.SerializeObject(governorsService.StatisticalByMonthService()));
        }
        #endregion

        #region  “统计图表”功能 未完成
        public ActionResult StatisticalBy7()
        {
            return Content(JsonConvert.SerializeObject(governorsService.StatisticalByMonthService()));
        }
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
        public Managers RequestCooikeManager()
        {
            Managers managers = new Managers();
            this.Request.Cookies.TryGetValue("Mid", out string Mid);
            int mid = int.Parse(Mid);
            this.Request.Cookies.TryGetValue("Mname", out string Mname);
            string mname = Mname;
            this.Request.Cookies.TryGetValue("Midentify", out string Midentify);
            string midentify = Midentify;
            managers.Mid = mid;
            managers.Mname = mname;
            managers.Midentify = midentify;
            return managers;
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

        #region "管理员展示“功能 H
        //可以只做管理员信息展示，至于量化评价，可以不实现
        /// <summary>
        /// 主要查询记录表中该用户的交易记录,查询前十项记录，该功能要用Ajax，
        /// 所以不需要建一个新的cshtml页面，只需要在Login的页面中加入数据即可。
        /// </summary>
        /// <returns>返回json数据</returns>
        public ActionResult ShowManagersData()
        {
            List<Managers> governors = new List<Managers>();
            governors = governorsService.QueryManagerService();
            return Content(JsonConvert.SerializeObject(governors));
        }
        #endregion

    }
}
