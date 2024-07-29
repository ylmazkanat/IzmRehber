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
            if (userId == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            var user = await _context.users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                return NotFound();
            }

            // Kullanıcı rolünü ViewBag ile geçirme
            ViewBag.UserRole = user.Role;
            ViewBag.UserName = user.AdSoyad;
            var employees = await _context.users.ToListAsync();
            return View(employees);
        }

        public IActionResult maintenance()
        {

            return View();
        }

        public IActionResult Error404()
        {

            return View();
        }
    }
}
