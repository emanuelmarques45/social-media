namespace SocialMedia.Lib.Dtos.Likes
{
    public class LikeResponseDto
    {
        public int Id { get; set; }

        public int TargetId { get; set; }

        public string UserId { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
    }
}
