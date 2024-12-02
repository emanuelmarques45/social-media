namespace SocialMedia.Api.Models
{
    public class LikeModel
    {
        public int Id { get; set; }

        public int PostId { get; set; }

        public string UserId { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public PostModel Post { get; set; } = null!;

        public UserModel User { get; set; } = null!;
    }
}
