using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using lab5.Models;

namespace lab5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Calculator cal)
        {
            double a, b;
            a = cal.v1;
            b = cal.v2;
            switch (cal.action)
            {
                case "+":
                    cal.result = a + b + "";
                    break;
                case "-":
                    cal.result = a - b + "";
                    break;
                case "*":
                    cal.result = a * b + "";
                    break;
                case "/":
                    if(b == 0)
                    {
                        cal.result = "Делить на 0 нельзя";
                        break;
                    }
                    cal.result = a / b + "";
                    break;
            }
            ViewData["result"] = cal.result;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
