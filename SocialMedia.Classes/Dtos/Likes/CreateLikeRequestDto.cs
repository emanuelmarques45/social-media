using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Classes.Dtos.Likes
{
    public class CreateLikeRequestDto
    {
        [Required]
        public int PostId { get; set; }

        [Required]
        public required string UserId { get; set; }
    }
}
