namespace AspMvcEmployeesWebApplication.Models
{
    public class SortViewModel
    {
        public SortState NameSort { get; set; } = SortState.NameAsc;
        public SortState AgeSort { get; set; } = SortState.AgeAsc;
        public SortState CompanySort { get; set; } = SortState.CompanyAsc;
        public SortState CurrentSort { get; set; }
        public bool Asc { get; set; } = true;

        public SortViewModel(SortState sortState = SortState.NameAsc)
        {
            if (sortState == SortState.NameDesc
                || sortState == SortState.AgeDesc
                || sortState == SortState.CompanyDesc)
                Asc = false;

            switch (sortState)
            {
                case SortState.NameAsc:
                    CurrentSort = NameSort = SortState.NameDesc;
                    break;
                case SortState.NameDesc:
                    CurrentSort = NameSort = SortState.NameAsc;
                    break;
                case SortState.AgeAsc:
                    CurrentSort = AgeSort = SortState.AgeDesc;
                    break;
                case SortState.AgeDesc:
                    CurrentSort = AgeSort = SortState.AgeAsc;
                    break;
                case SortState.CompanyAsc:
                    CurrentSort = CompanySort = SortState.CompanyDesc;
                    break;
                case SortState.CompanyDesc:
                    CurrentSort = CompanySort = SortState.CompanyAsc;
                    break;
                default:
                    break;
            }
        }
    }
}
