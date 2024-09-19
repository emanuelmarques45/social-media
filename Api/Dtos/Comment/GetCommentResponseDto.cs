namespace SocialMedia.Api.Dtos.Comment
{
    public class GetCommentResponseDto
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int PostId { get; set; }
        public string UserId { get; set; } = string.Empty;
    }
}
