using SocialMedia.Shared.Dtos.ChildComment;

namespace SocialMedia.Shared.Dtos.Comment
{
    public class UserCommentResponseDto
    {
        public int Id { get; set; }

        public string Content { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int PostId { get; set; }

        public List<ChildCommentResponseDto> ChidComments { get; set; } = [];
    }
}
