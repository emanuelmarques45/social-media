using SocialMedia.Lib.Dtos.User;
using SocialMedia.Lib.Models;

namespace SocialMedia.Lib.Dtos.ChildComment
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
