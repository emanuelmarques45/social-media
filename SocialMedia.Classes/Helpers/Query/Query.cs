namespace SocialMedia.Classes.Helpers.Query
{
    public abstract class Query
    {
        // Default values for PageSize and PageNumber
        private int _pageSize = 10;
        private int _pageNumber = 1;

        public string? SortBy { get; set; }

        public bool IsDescending { get; set; }

        public int PageSize { get => _pageSize; set => _pageSize = value <= 0 ? 1 : value; }

        public int PageNumber { get => _pageNumber; set => _pageNumber = value <= 0 ? 1 : value; }

        public int SkipNumber => (PageNumber - 1) * PageSize;
    }
}
