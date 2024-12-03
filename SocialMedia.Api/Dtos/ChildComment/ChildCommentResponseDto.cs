using SocialMedia.Api.Dtos.Account;
using SocialMedia.Api.Models;

namespace SocialMedia.Api.Dtos.ChildComment
{
    public class ChildCommentResponseDto
    {
        public int Id { get; set; }

        public string Content { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int? CommentId { get; set; }

        public string UserId { get; set; } = string.Empty;

        public CommentModel Comment { get; set; } = null!;

        public RelatedAccountResponseDto User { get; set; } = null!;

        public List<ChildCommentModel> Replies { get; set; } = [];
    }
}
