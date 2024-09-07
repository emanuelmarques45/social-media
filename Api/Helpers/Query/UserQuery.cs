namespace Api.Helpers.Query
{
    public class UserQuery
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? SortBy { get; set; }
        public bool IsDescending { get; set; }
    }
}
