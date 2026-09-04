namespace AspMvcEmployeesWebApplication.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public List<Employee> Employees { get; set; } = new();
    }
}
