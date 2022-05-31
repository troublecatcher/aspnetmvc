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

        // GET: OrdersInfo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (HttpContext.Session.GetInt32("logged") != 1 || HttpContext.Session.GetInt32("isadmin") != 1)
                return RedirectToAction("Login", "Auth");
            if (id == null || _context.OrdersInfo == null)
            {
                return NotFound();
            }

            var ordersInfo = await _context.OrdersInfo
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ordersInfo == null)
            {
                return NotFound();
            }

            return View(ordersInfo);
        }

        // GET: OrdersInfo/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetInt32("logged") != 1 || HttpContext.Session.GetInt32("isadmin") != 1)
                return RedirectToAction("Login", "Auth");
            return View();
        }

        // POST: OrdersInfo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,OrderID,Title,Price,Quantity,SubTotal")] OrdersInfo ordersInfo)
        {
            if (HttpContext.Session.GetInt32("logged") != 1 || HttpContext.Session.GetInt32("isadmin") != 1)
                return RedirectToAction("Login", "Auth");
            if (ModelState.IsValid)
            {
                _context.Add(ordersInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ordersInfo);
        }

        // GET: OrdersInfo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetInt32("logged") != 1 || HttpContext.Session.GetInt32("isadmin") != 1)
                return RedirectToAction("Login", "Auth");
            if (id == null || _context.OrdersInfo == null)
            {
                return NotFound();
            }

            var ordersInfo = await _context.OrdersInfo.FindAsync(id);
            if (ordersInfo == null)
            {
                return NotFound();
            }
            return View(ordersInfo);
        }

        // POST: OrdersInfo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,OrderID,Title,Price,Quantity,SubTotal")] OrdersInfo ordersInfo)
        {
            if (HttpContext.Session.GetInt32("logged") != 1 || HttpContext.Session.GetInt32("isadmin") != 1)
                return RedirectToAction("Login", "Auth");
            if (id != ordersInfo.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordersInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdersInfoExists(ordersInfo.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ordersInfo);
        }

        // GET: OrdersInfo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetInt32("logged") != 1 || HttpContext.Session.GetInt32("isadmin") != 1)
                return RedirectToAction("Login", "Auth");
            if (id == null || _context.OrdersInfo == null)
            {
                return NotFound();
            }

            var ordersInfo = await _context.OrdersInfo
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ordersInfo == null)
            {
                return NotFound();
            }

            return View(ordersInfo);
        }

        // POST: OrdersInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (HttpContext.Session.GetInt32("logged") != 1 || HttpContext.Session.GetInt32("isadmin") != 1)
                return RedirectToAction("Login", "Auth");
            if (_context.OrdersInfo == null)
            {
                return Problem("Entity set 'Context.OrdersInfo'  is null.");
            }
            var ordersInfo = await _context.OrdersInfo.FindAsync(id);
            if (ordersInfo != null)
            {
                _context.OrdersInfo.Remove(ordersInfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdersInfoExists(int id)
        {
          return (_context.OrdersInfo?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
