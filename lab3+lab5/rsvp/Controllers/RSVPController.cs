using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rsvp.Models;

namespace rsvp.Controllers
{
    public class RSVPController : Controller
    {
        private readonly Context _context;
        public RSVPController(Context context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> NewGuest([Bind("Name,Email,Phone,WillAttend")] Guest guest)
        {
            if (ModelState.IsValid)
            {
                var g = await _context.guest
                .FirstOrDefaultAsync(m => m.Phone == guest.Phone);
                if(g != default)
                {
                    g.Name = guest.Name;
                    g.Email = guest.Email;
                    g.WillAttend = guest.WillAttend;
                }else
                _context.Add(guest);
                await _context.SaveChangesAsync();
                return RedirectToAction("thanks");
            }
            return View("form", guest);
        }
        [HttpGet]
        public IActionResult Form()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Guests()
        {
            return View("guests", _context.guest);
        }
        [HttpGet]
        public IActionResult Thanks()
        {
            return View("thanks");
        }
        
    }
    
}