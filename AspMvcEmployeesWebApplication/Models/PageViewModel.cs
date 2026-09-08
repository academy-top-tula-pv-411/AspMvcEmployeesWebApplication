namespace AspMvcEmployeesWebApplication.Models
{
    public class PageViewModel
    {
        public int PageNumber { get; }
        public int TotalPages { get; }
        public bool PreviousPage => PageNumber > 1;
        public bool NextPage => PageNumber < TotalPages;


        public PageViewModel(int employeesCount, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(employeesCount / (double)pageSize);
        }
    }
}
