using AspMvcEmployeesWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspMvcEmployeesWebApplication.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext dataContext;

        public HomeController(ApplicationDbContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public async Task<IActionResult> Index(SortState sortOrder = SortState.NameAsc)
        {
            ViewData["NameSort"] = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            ViewData["AgeSort"] = sortOrder == SortState.AgeAsc ? SortState.AgeDesc : SortState.AgeAsc;
            ViewData["CompanySort"] = sortOrder == SortState.CompanyAsc ? SortState.CompanyDesc : SortState.CompanyAsc;

            IQueryable<Employee> employees = dataContext.Employees
                                         .Include(e => e.Company);

            employees = sortOrder switch
            {
                SortState.NameDesc => employees.OrderByDescending(e => e.Name),
                SortState.AgeAsc => employees.OrderBy(e => e.Age),
                SortState.AgeDesc => employees.OrderByDescending(e => e.Age),
                SortState.CompanyAsc => employees.OrderBy(e => e.Company!.Title),
                SortState.CompanyDesc => employees.OrderByDescending(e => e.Company!.Title),
                _ => employees.OrderBy(e => e.Name)
            };


            return View(await employees.ToListAsync());

        }
    }
}
