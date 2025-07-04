using SocialMedia.Shared.Models;

namespace SocialMedia.Shared.Dtos.Likes
{
    public class CommentLikeModel
    {
        public int Id { get; set; }

        public int CommentId { get; set; }

        public string UserId { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public CommentModel Comment { get; set; } = default!;

        public UserModel User { get; set; } = default!;
    }
}
