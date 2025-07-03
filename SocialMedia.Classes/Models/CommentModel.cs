using SocialMedia.Lib.Dtos.Likes;

namespace SocialMedia.Lib.Models
{
    public class CommentModel
    {
        public int Id { get; set; }

        public required string Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int PostId { get; set; }

        public required string UserId { get; set; }

        public PostModel Post { get; set; } = default!;

        public UserModel User { get; set; } = default!;

        public List<ChildCommentModel> ChildComments { get; set; } = [];

        public List<CommentLikeModel> Likes { get; set; } = [];
    }
}
