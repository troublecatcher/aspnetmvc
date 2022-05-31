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
    public class ItemController : Controller
    {
        private readonly Context _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ItemController(Context context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Item
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetInt32("logged") != 1 || HttpContext.Session.GetInt32("isadmin") != 1)
                return RedirectToAction("Login", "Auth");
            return _context.Items != null ?
                        View(await _context.Items.ToListAsync()) :
                        Problem("Entity set 'Context.Items'  is null.");
        }

        // GET: Item/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (HttpContext.Session.GetInt32("logged") != 1 || HttpContext.Session.GetInt32("isadmin") != 1)
                return RedirectToAction("Login", "Auth");
            if (id == null || _context.Items == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .FirstOrDefaultAsync(m => m.ID == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: Item/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetInt32("logged") != 1 || HttpContext.Session.GetInt32("isadmin") != 1)
                return RedirectToAction("Login", "Auth");
            return View();
        }

        // POST: Item/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Desc,Price,Qty,ImageFile")] Item item)
        {
            if (HttpContext.Session.GetInt32("logged") != 1 || HttpContext.Session.GetInt32("isadmin") != 1)
                return RedirectToAction("Login", "Auth");
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(item.ImageFile.FileName);
                string extension = Path.GetExtension(item.ImageFile.FileName);
                item.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/img/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await item.ImageFile.CopyToAsync(fileStream);
                }
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        // GET: Item/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetInt32("logged") != 1 || HttpContext.Session.GetInt32("isadmin") != 1)
                return RedirectToAction("Login", "Auth");
            if (id == null || _context.Items == null)
            {
                return NotFound();
            }

            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // POST: Item/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Desc,Price,Qty,ImageName,ImageFile")] Item item)
        {
            if (HttpContext.Session.GetInt32("logged") != 1 || HttpContext.Session.GetInt32("isadmin") != 1)
                return RedirectToAction("Login", "Auth");
            if (id != item.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (item.ImageFile != null)
                    {
                        string name = item.ImageFile.FileName;
                        string wwwRootPath = _hostEnvironment.WebRootPath;
                        string fileName = Path.GetFileNameWithoutExtension(name);
                        string extension = Path.GetExtension(name);
                        item.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                        string path = Path.Combine(wwwRootPath + "/img/", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await item.ImageFile.CopyToAsync(fileStream);
                        }
                        
                    }
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.ID))
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
            return View(item);
        }

        // GET: Item/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetInt32("logged") != 1 || HttpContext.Session.GetInt32("isadmin") != 1)
                return RedirectToAction("Login", "Auth");
            if (id == null || _context.Items == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .FirstOrDefaultAsync(m => m.ID == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (HttpContext.Session.GetInt32("logged") != 1 || HttpContext.Session.GetInt32("isadmin") != 1)
                return RedirectToAction("Login", "Auth");
            if (_context.Items == null)
            {
                return Problem("Entity set 'Context.Items'  is null.");
            }
            var item = await _context.Items.FindAsync(id);
            if (item != null)
            {
                _context.Items.Remove(item);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(int id)
        {
            return (_context.Items?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}