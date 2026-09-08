namespace AspMvcEmployeesWebApplication.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Employee> Employees { get; }
        public SortViewModel SortViewModel { get; }
        public SelectViewModel SelectViewModel { get; }
        public PageViewModel PageViewModel { get; }

        public IndexViewModel(IEnumerable<Employee> employees,
                              SortViewModel sortViewModel,
                              SelectViewModel selectViewModel,
                              PageViewModel pageViewModel)
        {
            Employees = employees;
            SortViewModel = sortViewModel;
            SelectViewModel = selectViewModel;
            PageViewModel = pageViewModel;
        }
    }
}
