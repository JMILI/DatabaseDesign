using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JMWeb04.UI.Controllers
{
    public class ErrorsController : Controller
    {
        public IActionResult PasswordError()
        {
            return View();
        }
    }
}
