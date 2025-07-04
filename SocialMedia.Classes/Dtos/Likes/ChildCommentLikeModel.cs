using SocialMedia.Shared.Models;

namespace SocialMedia.Shared.Dtos.Likes
{
    public class ChildCommentLikeModel
    {
        public int Id { get; set; }

        public int ChildCommentId { get; set; }

        public string UserId { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public UserModel User { get; set; } = default!;

        public ChildCommentModel ChildComment { get; set; } = default!;
    }
}
