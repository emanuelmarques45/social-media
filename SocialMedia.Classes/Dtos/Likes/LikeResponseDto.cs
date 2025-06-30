namespace SocialMedia.Classes.Dtos.Likes
{
    public class LikeResponseDto
    {
        public int Id { get; set; }

        public int PostId { get; set; }

        public string UserId { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
    }
}
