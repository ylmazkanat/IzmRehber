using IzmRehber.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace IzmRehber.Controllers
{
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Dashboard
        public async Task<IActionResult> Index()
        {
            // Oturum kontrolü
            var userId = HttpContext.Session.GetInt32("UserId");

            // Varsayılan değerleri ayarlama
            var userRole = 0;
            var userName = "Giriş Yap";

            // Kullanıcı oturum açmışsa
            if (userId != null)
            {
                var user = await _context.users.FirstOrDefaultAsync(u => u.Id == userId);
                if (user != null)
                {
                    userRole = user.Role;
                    userName = user.AdSoyad;
                }
            }

            // Kullanıcı rolünü ViewBag ile geçirme
            ViewBag.UserRole = userRole;
            ViewBag.UserName = userName;

            var employees = await _context.users.ToListAsync();
            return View(employees);
        }

        public IActionResult Maintenance()
        {
            return View();
        }

        public IActionResult Error404()
        {
            return View();
        }
    }
}
