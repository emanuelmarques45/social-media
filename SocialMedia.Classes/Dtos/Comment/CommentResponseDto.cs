using SocialMedia.Lib.Dtos.ChildComment;
using SocialMedia.Lib.Dtos.User;

namespace SocialMedia.Lib.Dtos.Comment
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
