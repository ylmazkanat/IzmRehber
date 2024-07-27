using IzmRehber.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IzmRehber.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;
        public AdminController(AppDbContext context)
        {
            _context = context;
        }
        // GET: Dashborad
        public async Task<IActionResult> IndexAsync()
        {

            var employees = await _context.users.ToListAsync();


            return View(employees);
        }

        [HttpPost]
        public IActionResult UpdateEmployee(int id, string adSoyad, string departman, string email, string tel)
        {
            var employee = _context.users.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return Json(new { success = false, message = "Employee not found" });
            }

            employee.AdSoyad = adSoyad;
            employee.Departman = departman;
            employee.Email = email;
            employee.Tel = tel;

            _context.SaveChanges();
            return Json(new { success = true, message = "Employee updated successfully" });
        }
    }
}
