using SocialMedia.Shared.Dtos.ChildComment;
using SocialMedia.Shared.Dtos.User;

namespace SocialMedia.Shared.Dtos.Comment
{
    public class CommentResponseDto
    {
        public int Id { get; set; }

        public string Content { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int PostId { get; set; }

        public RelatedUserResponseDto User { get; set; } = default!;

        public List<ChildCommentResponseDto> ChidComments { get; set; } = [];
    }
}
