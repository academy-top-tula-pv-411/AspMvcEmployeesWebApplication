using Microsoft.EntityFrameworkCore;

namespace AspMvcEmployeesWebApplication.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
            //Database.EnsureCreated();
        }
    }
}
