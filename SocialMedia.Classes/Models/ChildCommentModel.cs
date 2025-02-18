namespace SocialMedia.Classes.Models
{
    public class ChildCommentModel
    {
        public int Id { get; set; }

        public required string Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int CommentId { get; set; }

        public required string UserId { get; set; }

        public CommentModel Comment { get; set; } = default!;

        public UserModel User { get; set; } = default!;
    }
}
