using SocialMedia.Api.Dtos.Account;

namespace SocialMedia.Api.Dtos.Comment
{
    public class CommentResponseDto
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int PostId { get; set; }
        public RelatedAccountResponseDto User { get; set; } = null!;
        public List<CommentResponseDto> Replies { get; set; } = [];
    }
}
