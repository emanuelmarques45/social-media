using SocialMedia.Classes.Dtos.User;
using SocialMedia.Classes.Models;

namespace SocialMedia.Classes.Dtos.ChildComment
{
    public class ChildCommentResponseDto
    {
        public int Id { get; set; }

        public required string Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int CommentId { get; set; }

        public CommentModel Comment { get; set; } = default!;

        public RelatedUserResponseDto User { get; set; } = default!;
    }
}
