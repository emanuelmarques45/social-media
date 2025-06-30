using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Classes.Dtos.Likes
{
    public class UpdateLikeRequestDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int PostId { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;
    }
}
