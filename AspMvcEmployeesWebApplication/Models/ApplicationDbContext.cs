using Microsoft.EntityFrameworkCore;

namespace AspMvcEmployeesWebApplication.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Company> Companies { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
    }
}
