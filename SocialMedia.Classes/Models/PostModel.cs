namespace SocialMedia.Classes.Models
{
    public class PostModel
    {
        public int Id { get; set; }

        public required string Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public required string UserId { get; set; }

        public UserModel User { get; set; } = default!;

        public List<LikeModel> Likes { get; set; } = [];

        public List<CommentModel> Comments { get; set; } = [];
    }
}