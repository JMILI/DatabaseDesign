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
    public class DepositorsController : Controller
    {
        #region 实例化一些工具对象
        public static DepositorsService depositorServive = new DepositorsService();
        public static Depositors depositor = new Depositors();
        public static DepositorAndCard depositors = new DepositorAndCard();

        #endregion

        #region “登录”功能 已实现
        public IActionResult Login(DepositorAndCard depositor)
        {
            cooikeAdd(depositor);
            return View("Login", depositor);
        }
        #endregion

        #region  “注册储户”功能
        //1.返回填写信息页面
        public IActionResult AddInformation()
        {
            return View();
        }
        //2.将返回的信息进行处理，然后登陆系统主页
        public IActionResult AddLogin(Depositors depositor)
        {
            if (depositorServive.AddService(depositor)!=null)
            {
                cooikeAdd(depositors);
                return RedirectToAction("Login", "Depositors", depositors);
            }else
                return Redirect(Url.Action("DepositoryExistError", "Errors"));
        }
        #endregion

        #region “修改个人信息”功能，待实现，选做，由于设置的用户信息较少，可不做
        //包含：密码和默认银行卡号
        //1.返回一个页面用来填写信息。
        //2.将得到的数据更新到数据库中
        //3.重新返回用户主页
        #endregion

        #region “查询当前银行卡的余额明细”功能 待实现
        //包含定期余额，定期利息，定期利率，定期年限，活期余额，活期利息，活期率
        //此处应采用视图查询方便，以银行卡号为导向

        //1.用户是否冻结（选做）
        //2.注意要判断是否绑定银行卡
        //3.查询并返回信息列表
        #endregion

        #region “查询近十笔交易记录”功能 待实现
        //主要查询记录表中该用户的交易记录
        //1.查询前十项记录，注意事项不够的情况
        #endregion

        #region “绑定银行卡”功能 待实现
        //1.向绑定band表中添加数据
        //2.绑定成功返回主页
        #endregion

        #region “转账”功能 待实现 选做
        #endregion

        #region 辅助函数：登录，注册功能模块中，加入cooike
        public void cooikeAdd(DepositorAndCard depositor)
        {
            this.Response.Cookies.Append("Uid", depositor.Duid.ToString());
            this.Response.Cookies.Append("Cid", depositor.Dcid.ToString());
            this.Response.Cookies.Append("Name", depositor.Dname.ToString());
        }
        #endregion

    }
}
