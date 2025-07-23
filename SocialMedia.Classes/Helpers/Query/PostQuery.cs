namespace SocialMedia.Shared.Helpers.Query
{
    public class PostQuery : Query
    {
        public string? Content { get; set; }

        public DateTime? CreatedAtStart { get; set; }

        public DateTime? CreatedAtEnd { get; set; }
    }
}
