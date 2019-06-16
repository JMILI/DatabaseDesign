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
    public class ManagersController : Controller
    {
        #region 实例化一些工具对象
        public static Managers manager = new Managers();
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

        #region “注册银行卡”功能 待实现 
        //模拟柜台管理员给储户开户，即要填写用户基本信息储户账号Cuid，密码Cpassword
        //1.返回填写信息页面
        //2.获得前端页面信息，向数据库Cards表中填写数据。
        //3.返回一个成功页面，展示新增的这项Cards记录
        #endregion

        #region “统计查询所有储户卡信息”功能 待实现 
        //模拟柜台管理员统计信息，信息自己定
        #endregion

        #region “冻结账户”功能 待实现 
        //模拟柜台管理员统计信息，信息自己定，
        //如果做了此功能，储户系统，和ATM系统会作出相应改变，需要最后加入相应的改变
        #endregion

    }
}
