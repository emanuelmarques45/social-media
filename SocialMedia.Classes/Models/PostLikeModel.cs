namespace SocialMedia.Lib.Models
{
    public class PostLikeModel
    {
        public int Id { get; set; }

        public int PostId { get; set; }

        public string UserId { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public PostModel Post { get; set; } = default!;

        public UserModel User { get; set; } = default!;
    }
}
