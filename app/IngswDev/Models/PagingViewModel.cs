namespace IngswDev.Models
{
    public class PagingViewModel
    {
        public PagingViewModel(int page = 0, int size = 20)
        {
            Page = page;
            PageSize = size;
        }

        public int? Page { get; set; }
        public int? PageSize { get; set; }
    }
}
