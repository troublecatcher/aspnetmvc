using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_CRUD.Models;
using MVC_CRUD.Controllers;

namespace MVC_CRUD.Controllers
{
    public class RegisterController : Controller
    {
        private readonly Context _context;

        public RegisterController(Context context)
        {
            _context = context;
        }

        // GET: Register
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetInt32("logged") != 1 || HttpContext.Session.GetInt32("isadmin") != 1)
                return RedirectToAction("Login", "Auth");
            return _context.Registers != null ? 
                          View(await _context.Registers.ToListAsync()) :
                          Problem("Entity set 'Context.Registers'  is null.");
        }

        // GET: Register/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (HttpContext.Session.GetInt32("logged") != 1 || HttpContext.Session.GetInt32("isadmin") != 1)
                return RedirectToAction("Login", "Auth");
            if (id == null || _context.Registers == null)
            {
                return NotFound();
            }

            var register = await _context.Registers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (register == null)
            {
                return NotFound();
            }

            return View(register);
        }

        // GET: Register/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetInt32("logged") != 1 || HttpContext.Session.GetInt32("isadmin") != 1)
                return RedirectToAction("Login", "Auth");
            return View();
        }

        // POST: Register/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Surname,Name,Patro,Phone,Email,Password,ConfirmPassword,IsAdmin")] Register register)
        {
            if (HttpContext.Session.GetInt32("logged") != 1 || HttpContext.Session.GetInt32("isadmin") != 1)
                return RedirectToAction("Login", "Auth");
            if (ModelState.IsValid)
            {
                _context.Add(register);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(register);
        }

        // GET: Register/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetInt32("logged") != 1 || HttpContext.Session.GetInt32("isadmin") != 1)
                return RedirectToAction("Login", "Auth");
            if (id == null || _context.Registers == null)
            {
                return NotFound();
            }

            var register = await _context.Registers.FindAsync(id);
            if (register == null)
            {
                return NotFound();
            }
            return View(register);
        }

        // POST: Register/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Surname,Name,Patro,Phone,Email,Password,ConfirmPassword,IsAdmin")] Register register)
        {
            if (HttpContext.Session.GetInt32("logged") != 1 || HttpContext.Session.GetInt32("isadmin") != 1)
                return RedirectToAction("Login", "Auth");
            if (id != register.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(register);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegisterExists(register.ID))
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
            return View(register);
        }

        // GET: Register/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetInt32("logged") != 1 || HttpContext.Session.GetInt32("isadmin") != 1)
                return RedirectToAction("Login", "Auth");
            if (id == null || _context.Registers == null)
            {
                return NotFound();
            }

            var register = await _context.Registers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (register == null)
            {
                return NotFound();
            }

            return View(register);
        }

        // POST: Register/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (HttpContext.Session.GetInt32("logged") != 1 || HttpContext.Session.GetInt32("isadmin") != 1)
                return RedirectToAction("Login", "Auth");
            if (_context.Registers == null)
            {
                return Problem("Entity set 'Context.Registers'  is null.");
            }
            var register = await _context.Registers.FindAsync(id);
            if (register != null)
            {
                _context.Registers.Remove(register);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegisterExists(int id)
        {
          return (_context.Registers?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
