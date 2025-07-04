using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Shared.Dtos.Likes
{
    public class CreateLikeRequestDto
    {
        [Required]
        public int TargetId { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        public LikeableType Type { get; set; }
    }
}
