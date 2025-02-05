﻿using Microsoft.AspNetCore.Mvc;
using IzmRehber.Models;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Principal;

namespace IzmRehber.Controllers
{
    public class AuthController : Controller
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Username, string Password)
        {
            var user = _context.users.FirstOrDefault(u => (u.KullaniciAdi == Username || u.Email == Username) && u.Sifre == Password);
            if (user != null)
            {
                HttpContext.Session.SetInt32("UserId", user.Id);
                HttpContext.Session.SetInt32("UserRole", user.Role);
                return RedirectToAction("Profile");
            }

            TempData["ErrorMessage"] = "Giriş Bilgileriniz Hatalı. Tekrar Deneyiniz.";
            return RedirectToAction("Login");
        }

        [HttpPost]
        public IActionResult WindowsLogin()
        {
            var windowsUsername = WindowsIdentity.GetCurrent().Name;
            var extractedUsername = windowsUsername.Split('\\').Last();
            var user = _context.users.FirstOrDefault(u => u.KullaniciAdi == extractedUsername);

            if (user != null)
            {
                HttpContext.Session.SetInt32("UserId", user.Id);
                HttpContext.Session.SetInt32("UserRole", user.Role);
                TempData["SuccessMessage"] = $"Başarıyla giriş yaptınız. Windows Kullanıcı Adınız: {extractedUsername}";
                return RedirectToAction("Profile");
            }

            TempData["ErrorMessage"] = $"Windows ile giriş yaparken bir hata oluştu. Kullanıcı bulunamadı. Kullanıcı Adınız: {extractedUsername}";
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Profile()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("Login");
            }

            var user = _context.users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                return NotFound();
            }
            ViewBag.UserRole = user.Role;
            ViewBag.UserName = user.AdSoyad;
            return View(user);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserId");
            return RedirectToAction("Login");
        }
    }
}
