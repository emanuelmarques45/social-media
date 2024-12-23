using SocialMedia.Classes.Dtos.Account;
using SocialMedia.Classes.Models;

namespace SocialMedia.Classes.Dtos.ChildComment
{
    public class ChildCommentResponseDto
    {
        public int Id { get; set; }

        public required string Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int? CommentId { get; set; }

        public required string UserId { get; set; }

        public CommentModel Comment { get; set; } = default!;

        public RelatedAccountResponseDto User { get; set; } = default!;

        public List<ChildCommentModel> Replies { get; set; } = [];
    }
}
