using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Classes.Dtos.Post
{
    public class CreatePostRequestDto
    {
        [Required]
        [StringLength(280, MinimumLength = 1)]
        public string Content { get; set; } = string.Empty;

        [Required]
        public string UserId { get; set; } = string.Empty;
    }
}
