using AspMvcEmployeesWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspMvcEmployeesWebApplication.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext dataContext;

        public int PageSize { get; set; } = 2;

        public HomeController(ApplicationDbContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public async Task<IActionResult> Index(
            string name, 
            int companyId = 0,
            int page = 1,
            SortState sortOrder = SortState.NameAsc)
        {
            IQueryable<Employee> employees = dataContext.Employees
                                         .Include(e => e.Company);
            if(companyId != 0)
                employees = employees.Where(e => e.CompanyId == companyId);

            if(!String.IsNullOrEmpty(name))
                employees = employees.Where(e => e.Name.Contains(name));

            employees = sortOrder switch
            {
                SortState.NameDesc => employees.OrderByDescending(e => e.Name),
                SortState.AgeAsc => employees.OrderBy(e => e.Age),
                SortState.AgeDesc => employees.OrderByDescending(e => e.Age),
                SortState.CompanyAsc => employees.OrderBy(e => e.Company!.Title),
                SortState.CompanyDesc => employees.OrderByDescending(e => e.Company!.Title),
                _ => employees.OrderBy(e => e.Name)
            };

            int employeesCount = await employees.CountAsync();
            employees = employees.Skip((page - 1) * PageSize).Take(PageSize);

            IndexViewModel indexViewModel = new(
                employees,
                new SortViewModel(sortOrder),
                new SelectViewModel(dataContext.Companies.ToList(), companyId, name),
                new PageViewModel(employeesCount, page, PageSize));
           

            return View(indexViewModel);

        }
    }
}
