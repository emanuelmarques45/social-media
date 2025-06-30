namespace SocialMedia.Classes.Models
{
    public class LikeModel
    {
        public int Id { get; set; }

        public int PostId { get; set; }

        public required string UserId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public PostModel Post { get; set; } = default!;

        public UserModel User { get; set; } = default!;
    }
}
