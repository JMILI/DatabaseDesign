using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JMWeb04.UI.Models;

namespace JMWeb04.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SignIn()
        {
            //此处分类，让储户和管理员分别登录到自己的界面

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
            return View();
        }
    }
}
