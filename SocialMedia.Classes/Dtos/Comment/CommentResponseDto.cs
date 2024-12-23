using SocialMedia.Classes.Dtos.Account;
using SocialMedia.Classes.Dtos.ChildComment;

namespace SocialMedia.Classes.Dtos.Comment
{
    public class CommentResponseDto
    {
        public int Id { get; set; }

        public required string Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int PostId { get; set; }

        public RelatedAccountResponseDto User { get; set; } = default!;

        public List<ChildCommentResponseDto> Replies { get; set; } = [];
    }
}
