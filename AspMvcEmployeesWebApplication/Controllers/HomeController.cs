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
        public async Task<IActionResult> Index()
        {
            return View(await dataContext.Employees.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            dataContext.Employees.Add(employee);
            await dataContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if(id is not null)
            {
                Employee employee = new() { Id = id.Value };
                dataContext.Entry(employee).State = EntityState.Deleted;
                await dataContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return NotFound();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            Employee? employee = await dataContext.Employees.FirstOrDefaultAsync(e => e.Id == id);
            if(employee is not null)
                return View(employee);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Employee employee)
        {
            dataContext.Employees.Update(employee);
            await dataContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
