using Microsoft.EntityFrameworkCore;
using AspMvcEmployeesWebApplication.Models;

var builder = WebApplication.CreateBuilder(args);

string? connectionString = builder.Configuration
                                  .GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(
                    option => option.UseSqlServer(connectionString));

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
