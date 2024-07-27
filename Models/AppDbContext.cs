using Microsoft.EntityFrameworkCore;

namespace IzmRehber.Models
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Rehber> users { get; set; }
       
    }
}
