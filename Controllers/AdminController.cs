using IzmRehber.Models;
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
            var employees = await _context.users.ToListAsync();
            return View(employees);
        }

        

        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(int id, string adSoyad, string departman, string email, string tel)
        {
            var employee = await _context.users.FirstOrDefaultAsync(e => e.Id == id);
            if (employee == null)
            {
                return Json(new { success = false, message = "Güncelleme Başarısız. Tekrar Deneyin." });
            }

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
    }
}
