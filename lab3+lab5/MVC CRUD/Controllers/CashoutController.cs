using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_CRUD.Models;
using Newtonsoft.Json;

namespace MVC_CRUD.Controllers
{
    public class CashoutController : Controller
    {
        public IActionResult Index()
        {
            return View(JsonConvert.DeserializeObject<IEnumerable<Item>>(HttpContext.Session.GetString("cart")));
        }
    }
}