using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_CRUD.Models;
using System.Diagnostics;
using Newtonsoft.Json;

namespace MVC_CRUD.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Context _context;
        private List<Cart> cart;

        public HomeController(ILogger<HomeController> logger, Context context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetInt32("logged") != 1)
                return RedirectToAction("Login","Auth");
            return _context.Items != null ?
                        View(await _context.Items.ToListAsync()) :
                        Problem("Entity set 'Context.Customers'  is null.");
        }
        public async Task<ActionResult> Add(int itemid, int qty)
        {
            if(qty != 0)
            {
                var i = await _context.Items.FirstOrDefaultAsync(i => i.ID == itemid);
                if(qty > i.Qty) return View("Sorry");
                var cart = HttpContext.Session.GetString("cart");
                if (cart == null)
                {
                    List<Item> li = new();
                    var dbitem = await _context.Items.FirstOrDefaultAsync(i => i.ID == itemid);
                    dbitem.Qty = qty;
                    li.Add(dbitem);
                    HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(li));
                    HttpContext.Session.SetInt32("count", 1);
                }
                else
                {
                    var li = JsonConvert.DeserializeObject<List<Item>>(cart);
                    var dbitem = await _context.Items.FirstOrDefaultAsync(i => i.ID == itemid);
                    foreach (var item in li.ToList())
                    {
                        if (item.ID == itemid)
                        {
                            if (item.Qty + qty > dbitem.Qty)
                                return View("Sorry");
                            else item.Qty += qty;
                            
                            HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(li));
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    HttpContext.Session.SetInt32("count", (int)HttpContext.Session.GetInt32("count") + 1);
                    dbitem.Qty = qty;
                    li.Add(dbitem);
                    HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(li));
                }
            }
            return RedirectToAction("Index", "Home");
        }
        public async Task<ActionResult> Remove(int itemid)
        {
            var cart = HttpContext.Session.GetString("cart");
            var li = JsonConvert.DeserializeObject<List<Item>>(cart);
            foreach(var item in li.ToList())
                if(item.ID == itemid)
                    li.RemoveAt(li.IndexOf(item));
            HttpContext.Session.SetInt32("count", (int)HttpContext.Session.GetInt32("count") - 1);
            HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(li));
            return RedirectToAction("Index", "Cart");
        }
        public async Task<ActionResult> Update(int itemid)
        {
            int qty = Int32.Parse(Request.Form["qty"]);
            if (qty == 0)
                Remove(itemid);
            var cart = HttpContext.Session.GetString("cart");
            var li = JsonConvert.DeserializeObject<List<Item>>(cart);
            var dbitem = await _context.Items.FirstOrDefaultAsync(i => i.ID == itemid);
            foreach (var item in li)
                if (item.ID == itemid)
                {
                    if (qty > dbitem.Qty)
                        return View("Sorry");
                    item.Qty = qty;
                }
            HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(li));
            return RedirectToAction("Index", "Cart");
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
        public IActionResult Error(int? statusCode = null)
        {
            if (statusCode.HasValue)
            {
                if (statusCode == 404 || statusCode == 500)
                {
                    var viewName = statusCode.ToString();
                    return View(viewName);
                }
            }

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}