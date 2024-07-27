using IzmRehber.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Minia.Controllers
{
    public class DashboradController : Controller
    {
        private readonly AppDbContext _context;
        public DashboradController(AppDbContext context)
        {
            _context = context;
        }
        // GET: Dashborad
        public async Task<IActionResult> IndexAsync()
        {
            
            var employees = await _context.users.ToListAsync();
            

            return View(employees);
        }
    }
}