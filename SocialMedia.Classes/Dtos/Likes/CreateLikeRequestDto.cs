using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Lib.Dtos.Likes
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
