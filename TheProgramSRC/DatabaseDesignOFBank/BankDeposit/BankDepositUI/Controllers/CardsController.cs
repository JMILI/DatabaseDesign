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
        public static Cards card = new Cards();
        #endregion

        #region “登录”功能 已实现
        public IActionResult Login(DepositorAndCard card)
        {
            this.Response.Cookies.Append("Uid", card.Duid.ToString());
            this.Response.Cookies.Append("Cid", card.Dcid.ToString());
            this.Response.Cookies.Append("Name", card.Dname.ToString());
            return View("Login", card);
        }
        #endregion

        #region “取款”功能 待实现
        //向记录表中填入数据，Ruid ,Rcid, Rwithdrawals DOUBLE(200,3) 
        //1.返回一个包含各种取款金额的页面（100,200,300,500,1000,2000)，模拟取款操作
        //2.获得前端页面信息，更新数据库
        ////2.1 可以将生成的记录向主页展示，选做
        //3.重新返回主页
        
        #endregion

        #region “活期存款”功能 待实现
        //向记录表中填入数据，Ruid ,Rcid, RflowDeposit DOUBLE(200,3) 
        //1.返回一个填写存款金额的页面，模拟存款操作
        //2.获得前端页面信息，更新数据库
        //3.重新返回主页
        #endregion

        #region “定期存款”功能 待实现
        //向记录表中填入数据，Ruid ,Rcid, RfixDepostit DOUBLE(200,3) 
        //1.返回一个存款金额的页面(包含年限选择-多选框），模拟存款操作
        //2.获得前端页面信息，更新数据库
        //3.重新返回主页
        #endregion

        #region “转账”功能 待实现 选做
        #endregion

        #region 辅助函数 A
        #endregion

        #region 
        #endregion
    }
}
