using SocialMedia.Shared.Dtos.User;
using SocialMedia.Shared.Models;

namespace SocialMedia.Shared.Dtos.ChildComment
{
    public class ChildCommentResponseDto
    {
        public int Id { get; set; }

        public string Content { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int CommentId { get; set; }

        public CommentModel Comment { get; set; } = default!;

        public RelatedUserResponseDto User { get; set; } = default!;
    }
}
