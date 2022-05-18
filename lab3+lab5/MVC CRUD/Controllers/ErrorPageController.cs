using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MVC_CRUD.Controllers
{
    [Route("ErrorPage/{statuscode}")]
    public class ErrorPageController : Controller
    {
        public IActionResult HttpStatusCodeHandler(int statuscode)
        {
            switch (statuscode)
            {
                case 404:
                    ViewData["Error"] = "The page you're looking for is lost in space";
                    break;
                default:
                    ViewData["Error"] = "Something happened. Our fault. Sry";
                    break;
            }
            return View("ErrorPage");
        }
    }
}