namespace Pagination.Models
{
    //The “T” is a placeholder for a specific data type that will be determined when an instance of the class is created.
    public class PaginatedList<T>
    {
        public List<T> Items { get; }
        public int PageSize { get; private set; }
        public int CurrentPage { get; private set;  }
        public int TotalItemCount { get; private set; }
        public int TotalPageCount { get; private set; }
        public bool HasPreviousPage => (CurrentPage > 1);
        public bool HasNextPage => (CurrentPage < TotalPageCount);
        public PaginatedList(List<T> items, int currentPage, int totalPages) 
        {
            Items = items;
            CurrentPage= currentPage;
            TotalPageCount = totalPages;
        }
    }
}
