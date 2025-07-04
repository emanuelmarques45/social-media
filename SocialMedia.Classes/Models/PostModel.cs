namespace SocialMedia.Shared.Models
{
    public class PostModel
    {
        public int Id { get; set; }

        public string Content { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string UserId { get; set; } = string.Empty;

        public UserModel User { get; set; } = default!;

        public List<PostLikeModel> Likes { get; set; } = [];

        public List<CommentModel> Comments { get; set; } = [];
    }
}