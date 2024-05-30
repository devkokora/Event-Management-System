namespace EventManagementSystem.Utilities
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalNumberOfPages { get; private set; }
        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalNumberOfPages;
        public string? SearchQuery { get; set; }
        public int AllItemsCount { get; set; }

        public PaginatedList(List<T> items, int allItemsCount, int pageIndex, int pageSize)
        {
            AllItemsCount = allItemsCount;
            PageIndex = pageIndex;
            TotalNumberOfPages = (int)Math.Ceiling((double)allItemsCount / pageSize);
            AddRange(items);
        }
    }
}
