using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_CRUD.Models;

namespace MVC_CRUD.Controllers
{
    public class OrdersInfoController : Controller
    {
        private readonly Context _context;

        public OrdersInfoController(Context context)
        {
            _context = context;
        }

        // GET: OrdersInfo
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetInt32("logged") != 1 || HttpContext.Session.GetInt32("isadmin") != 1)
                return RedirectToAction("Login", "Auth");
            if (_context.OrdersInfo == null)
                return Problem("Entity set 'Context.OrdersInfo'  is null.");
            else
            {
                var l1 = await _context.Orders.ToListAsync();
                var l2 = await _context.OrdersInfo.ToListAsync();
                var l3 = await _context.Registers.ToListAsync();
                var tuple = new Tuple<List<Orders>,List<OrdersInfo>,List<Register>>(l1,l2,l3);
                return View(tuple);
            }
        }
    }
}
