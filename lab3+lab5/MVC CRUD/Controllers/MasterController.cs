using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MVC_CRUD.Controllers
{
    public class MasterController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.value1 = "initial value";
            ViewBag.value2 = "";
            return View();
        }
        public IActionResult First()
        {
            ViewBag.value1 = "changed value";
            ViewBag.value2 = "changed value";
            return View("first");
        }
        public IActionResult Second()
        {
            ViewBag.value1 = "initial value";
            ViewBag.value2 = "changed value";
            return View("second");
        }
    }
}