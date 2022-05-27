using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_CRUD.Models;

namespace MVC_CRUD.Controllers
{
    public class AuthController : Controller
    {
        private readonly Context _context;

        public AuthController(Context context)
        {
            _context = context;
        }
        public IActionResult Login()
        {
            return View();
        }
        public async Task<IActionResult> Enter([Bind("Email,Password")] Login log)
        {
            HttpContext.Session.Remove("invalid");
            if (ModelState.IsValid)
            {
                var li = await _context.Registers.ToListAsync();
                foreach (var item in li)
                    if (item.Email == log.Email && item.Password == log.Password)
                    {
                        if (item.IsAdmin == true)
                            HttpContext.Session.SetInt32("isadmin", 1);
                        HttpContext.Session.SetInt32("logged", 1);
                        HttpContext.Session.SetString("user", item.Name);
                        HttpContext.Session.SetInt32("userID", item.ID);
                        return RedirectToAction("Index", "Home");
                    }
                    HttpContext.Session.SetString("invalid", "Логин или пароль неверный =(");
            }
            return View("Login", log);
        }
        public IActionResult Leave()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> NewUser([Bind("Surname,Name,Patro,Phone,Email,Password,ConfirmPassword")] Register reg)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("user", reg.Name);
                _context.Registers.Add(reg);
                await _context.SaveChangesAsync();
                HttpContext.Session.SetInt32("logged", 1);
                return RedirectToAction("Index","Home");
            }
            return View("Register", reg);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
    }
}