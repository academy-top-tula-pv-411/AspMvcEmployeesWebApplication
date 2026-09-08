using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspMvcEmployeesWebApplication.Models
{
    public class SelectViewModel
    {
        public SelectList Companies { get; }
        public int SelectedCompanyId { get; }
        public string SelectedName { get; }

        public SelectViewModel(List<Company> companies, int selectedCompanyId, string selectedName)
        {
            companies.Insert(0, new() { Title = "All", Id = 0 });
            Companies = new SelectList(companies, nameof(Company.Id), nameof(Company.Title));
            SelectedCompanyId = selectedCompanyId;
            SelectedName = selectedName;
        }
    }
}
