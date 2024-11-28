namespace SocialMedia.Api.Models
{
    public class ChildCommentModel
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string UserId { get; set; } = string.Empty;
        public int? ParentId { get; set; }

        //Navigation properties
        public UserModel User { get; set; } = null!;
        public CommentModel Comment { get; set; } = null!;
    }
}
