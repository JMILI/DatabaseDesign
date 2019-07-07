using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankDepositUI.Models;
using BankDeposit.Model.SqlBank;
using BankDeposit.Service;
using System.Web.Script.Serialization;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace BankDepositUI.Controllers
{
    public class DepositorsController : Controller
    {
        #region 实例化一些工具对象
        public static DepositorsService depositorServive = new DepositorsService();
        public static Depositors depositor = new Depositors();
        public static DepositorAndCard depositors = new DepositorAndCard();
        #endregion

        #region “登录”功能 已实现
        /// <summary>
        /// “登录”功能
        /// </summary>
        /// <param name="depositor">传入的是DepositorAndCard类型的数据</param>
        /// <returns></returns>
        public IActionResult Login(DepositorAndCard depositor)
        {
            cooikeAdd(depositor);
            return View("Login", depositor);
        }
        #endregion

        #region  “注册储户”功能 已实现
        //1.返回填写信息页面
        public IActionResult AddInformation()
        {
            return View();
        }
        //2.将返回的信息进行处理，然后登陆系统主页
        /// <summary>
        /// 
        /// </summary>
        /// <param name="depositor">Uid,Uname,UPassword</param>
        /// <returns></returns>
        public IActionResult AddLogin(Depositors depositor)
        {
            depositors = depositorServive.AddService(depositor);
            if (depositors != null)
            {
                cooikeAdd(depositors);
                return RedirectToAction("Login", "Depositors", depositors);
            }
            else
                return Redirect(Url.Action("DepositoryExistError", "Errors"));
        }
        #endregion

        #region “查询近十笔交易记录”功能 已实现
        /// <summary>
        /// 主要查询记录表中该用户的交易记录,查询前十项记录，该功能要用Ajax，
        /// 所以不需要建一个新的cshtml页面，只需要在Login的页面中加入数据即可。
        /// </summary>
        /// <returns>返回json数据</returns>
        public ActionResult QueryTenRecords()
        {
            List<Records> record = new List<Records>();
            this.Request.Cookies.TryGetValue("Cid", out string Cid);
            int cid = int.Parse(Cid);
            record = depositorServive.TenRecordsService(cid);
            return Content(JsonConvert.SerializeObject(record));
        }
        #endregion

        #region “绑定银行卡”功能 已实现
        //1.向绑定band表中添加数据
        //2.绑定成功返回主页
        public IActionResult UpdataBandInformation()
        {
            return View();
        }
        //2.将返回的信息进行处理，然后登陆系统主页
        /// <summary>
        /// 
        /// </summary>
        /// <param name="depositor">Duid,Dname,Dcid</param>
        /// <returns></returns>
        public IActionResult UpdataBand(DepositorAndCard depositor)
        {
            this.Request.Cookies.TryGetValue("Uid", out string Uid);
            this.Request.Cookies.TryGetValue("Name", out string Name);
            depositor.Duid = int.Parse(Uid);
            depositor.Dname = Name;
            int uid = int.Parse(Uid);
            bool s = depositorServive.UpdataBandService(depositor);
            if (s == true)
            {
                //cooikeAdd(depositors);
                return RedirectToAction("Login", "Depositors", depositor);
            }
            else
                return Redirect(Url.Action("DepositoryNotExistError", "Errors"));
        }

        #endregion

        #region “查询活期余额”功能 已实现
        public ActionResult FlowBalance()
        {
            List<Double> record = new List<Double>();
            this.Request.Cookies.TryGetValue("Cid", out string Cid);//从cookie中请求当前用户卡号
            int cid = int.Parse(Cid);
            record = depositorServive.FlowBalanceService(cid);//这里需要service返回一个余额，一个利息
            return Content(JsonConvert.SerializeObject(record));//以json方式
        }
        #endregion

        #region “查询定期余额”功能 已实现
        public ActionResult FixBalance()
        {
            List<Fixbalances> record = new List<Fixbalances>();
            //this.Request.Cookies.TryGetValue("Cid", out string Cid);//从cookie中请求当前用户卡号
            //int cid = int.Parse(Cid);
            record = depositorServive.FixBalanceService((int)DAndC().Dcid);//这里需要service返回一个余额，一个利息
            return Content(JsonConvert.SerializeObject(record));//以json方式
        }
        #endregion

        #region “转账”功能 待实现 选做
        #endregion

        #region “修改个人信息”功能，待实现，选做，由于设置的用户信息较少，可不做
        //包含：密码和默认银行卡号
        //1.返回一个页面用来填写信息。
        //2.将得到的数据更新到数据库中
        //3.重新返回用户主页
        #endregion

        #region 辅助函数：登录，注册功能模块中，加入cooike
        public void cooikeAdd(DepositorAndCard depositor)
        {
            this.Response.Cookies.Append("Uid", depositor.Duid.ToString());
            this.Response.Cookies.Append("Cid", depositor.Dcid.ToString());
            this.Response.Cookies.Append("Name", depositor.Dname.ToString());
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

    }
}
