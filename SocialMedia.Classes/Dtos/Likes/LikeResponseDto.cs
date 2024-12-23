namespace SocialMedia.Classes.Dtos.Likes
{
    public class LikeResponseDto
    {
        public int Id { get; set; }

        public int PostId { get; set; }

        public required string UserId { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
