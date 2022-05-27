using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_CRUD.Models;
using Newtonsoft.Json;

namespace MVC_CRUD.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly Context _context;

        public CheckoutController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(JsonConvert.DeserializeObject<IEnumerable<Item>>(HttpContext.Session.GetString("cart")));
        }
        public async Task<IActionResult> SaveOrder()
        {
            var userID = (int)HttpContext.Session.GetInt32("userID");
            var cart = HttpContext.Session.GetString("cart");
            var li = JsonConvert.DeserializeObject<List<Item>>(cart);
            int total = 0;
            foreach (var item in li)
                total += item.Qty * item.Price;

            Orders order = new()
            {
                CustomerID = userID,
                Total = total
            };
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            foreach (var item in li)
            {
                OrdersInfo info = new()
                {
                    OrderID = _context.Orders.Max(x => x.ID),
                    Title = item.Title,
                    Price = item.Price,
                    Quantity = item.Qty,
                    SubTotal = item.Qty * item.Price
                };
                _context.OrdersInfo.Add(info);
            }

            //substracting stock qty upon ordering
            var dbli = await _context.Items.ToListAsync();
            foreach (var i in dbli)
            {
                foreach (var j in li)
                    if (i.ID == j.ID)
                        i.Qty -= j.Qty;

            }
            await _context.SaveChangesAsync();
            HttpContext.Session.Remove("cart");
            HttpContext.Session.Remove("count");
            return View("Thankyou");
        }
    }
}