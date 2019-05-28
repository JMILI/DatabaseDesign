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
    public class StudentController : Controller
    {
        public static StudentService service = new StudentService();
        public static Student user = new Student();

        #region registe
        public IActionResult Add()
        {
            return View();
        }

        public IActionResult AddLogin(Student student)
        {
            service.AddService(student);
            return View("LoginIn", student);
        }
        #endregion

        #region LoginIn
        public IActionResult LoginIn(Student student)
        {
            user = service.QueryStudentService(student);
            if (user == null || user.Password != student.Password)
            {
                return Redirect(Url.Action("PasswordError", "Errors"));
            }
            else
            {
                this.Response.Cookies.Append("StudentId", student.StudentId.ToString());
                return View("LoginIn", user);
            }
        }
        #endregion

        #region Update
        public IActionResult UpdateView(Student student)
        {
            this.Request.Cookies.TryGetValue("StudentId", out string value);
            return View("UpdateView",value);
        }
        public IActionResult Update(Student student)
        {
           user= service.UpdateService(student);
            return View("LoginIn", user);
        }
        #endregion

        #region Delete
        public IActionResult Delete()
        {
            if (this.Request.Cookies.TryGetValue("StudentId", out string value))
            {
                service.DeleteService(value);
                return View();
            }
            else {
                return Redirect(Url.Action("Index", "Home"));
            }  
        }
        #endregion

        //#region Error
        //public IActionResult PasswordError()
        //{
        //    ViewData["Message"] = "Your contact page.";
        //    return View();
        //}
        //#endregion

    }
}
