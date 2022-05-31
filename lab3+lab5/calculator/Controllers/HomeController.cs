using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using calculator.Models;

namespace calculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public static double convert(String input)
        {
            input = input.Replace(',', '.');
            int decimalSeperator = input.LastIndexOf('.');

            if (decimalSeperator > -1)
            {
                input = input.Substring(0, decimalSeperator).Replace(".", "") + input.Substring(decimalSeperator);
            }

            return Convert.ToDouble(input);
        }
        [HttpPost]
        public IActionResult Index(Calculator cal)
        {
            double a, b;
            a = convert(cal.v1);
            b = convert(cal.v2);
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
                    if (b == 0)
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
        public IActionResult Index()
        {
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

