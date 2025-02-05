﻿using IzmRehber.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace IzmRehber.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Dashboard
        public async Task<IActionResult> IndexAsync()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return Redirect("/auth/login");
            }

            var user = _context.users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                return NotFound();
            }
            // Kullanıcı rolünü ViewBag ile geçirme
            ViewBag.UserRole = user.Role;
            ViewBag.UserName = user.AdSoyad;
            // Eğer kullanıcı rolü admin değilse, uyarı ver ve giriş sayfasına yönlendir
            if (user.Role != 1) // admin rolü 1 olarak kabul ediliyor
            {
                TempData["ErrorMessage"] = "Bu sayfaya Yetkiniz Yoktur. Lütfen Yetkili bir hesaptan giriş Yapınız.";
                return Redirect("/auth/login");
            }

            // Admin kullanıcılar için tüm çalışanları listele
            var employees = await _context.users.ToListAsync();
            return View(employees);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(int id, string kullaniciAdi, string sifre, string adSoyad, string departman, string email, string tel)
        {
            var employee = await _context.users.FirstOrDefaultAsync(e => e.Id == id);
            if (employee == null)
            {
                return Json(new { success = false, message = "Güncelleme Başarısız. Tekrar Deneyin." });
            }

            employee.KullaniciAdi = kullaniciAdi;
            employee.Sifre = sifre;
            employee.AdSoyad = adSoyad;
            employee.Departman = departman;
            employee.Email = email;
            employee.Tel = tel;

            try
            {
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Çalışan Güncellendi." });
            }
            catch (DbUpdateException ex)
            {
                return Json(new { success = false, message = "Veritabanı güncellemesi sırasında bir hata oluştu: " + ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(string kullaniciAdi, string sifre, string adSoyad, string departman, string email, string tel)
        {
            var employee = new Rehber
            {
                KullaniciAdi = kullaniciAdi,
                Sifre = sifre,
                AdSoyad = adSoyad,
                Departman = departman,
                Email = email,
                Tel = tel
            };

            _context.users.Add(employee);

            try
            {
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Yeni Çalışan Eklendi." });
            }
            catch (DbUpdateException ex)
            {
                return Json(new { success = false, message = "Veritabanına ekleme sırasında bir hata oluştu: " + ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.users.FindAsync(id);
            if (employee == null)
            {
                return Json(new { success = false, message = "Çalışan bulunamadı." });
            }

            try
            {
                _context.users.Remove(employee);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Çalışan başarıyla silindi." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Çalışan silinirken bir hata oluştu: " + ex.Message });
            }
        }
    }
}
