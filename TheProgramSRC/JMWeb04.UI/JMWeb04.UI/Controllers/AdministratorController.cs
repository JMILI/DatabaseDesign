using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JMWeb04.UI.Models;
using JMWeb04.Model.JMdataSql;
using JMWeb04.Service;

namespace JMWeb04.UI.Controllers
{
    public class AdministratorController : Controller
    {
        #region  添加管理员
        public IActionResult AddManager()
        {
            return View();
            //此处为了测试方便直接初始化好数据
        }
        public IActionResult AddManagerLogin(Student student)
        {
            //return View("LoginIn", student);
            return null;
        }
        #endregion

        #region  修改自己的密码
        public IActionResult UpdateView(Student student)
        {
            //this.Request.Cookies.TryGetValue("StudentId", out string value);
            //return View("UpdateView", value);
            return null;
        }
        public IActionResult Update(Student student)
        {
            //user = service.UpdateService(student);
            //return View("LoginIn", user);
            return null;
        }
        #endregion

        #region  管理员辅助函数
        public IActionResult LoginIn(Student student)
        {
            //user = service.QueryStudentService(student);
            //if (user == null || user.Password != student.Password)
            //{
            //    return Redirect(Url.Action("PasswordError", "Errors"));
            //}
            //else
            //{
            //    this.Response.Cookies.Append("StudentId", student.StudentId.ToString());
            //    return View("LoginIn", user);
            //}
            return null;
        }
        #endregion


        #region  添加新储户
        public IActionResult AddDepositor()
        {
            return View();
        }
        #endregion

        #region  查询储户信息
        #endregion

        #region  冻结储户账户
        public IActionResult Delete()
        {
            if (this.Request.Cookies.TryGetValue("StudentId", out string value))
            {
                //service.DeleteService(value);
                return View();
            }
            else
            {
                return Redirect(Url.Action("Index", "Home"));
            }
        }
        #endregion

    }
}
