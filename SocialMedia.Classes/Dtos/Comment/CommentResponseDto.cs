using SocialMedia.Classes.Dtos.ChildComment;
using SocialMedia.Classes.Dtos.User;

namespace SocialMedia.Classes.Dtos.Comment
{
    public class CommentResponseDto
    {
        public int Id { get; set; }

        public required string Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int PostId { get; set; }

        public RelatedUserResponseDto User { get; set; } = default!;

        public List<ChildCommentResponseDto> Replies { get; set; } = [];
    }
}
