using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Classes.Dtos.Post
{
    public class CreatePostRequestDto
    {
        [Required]
        [StringLength(280, MinimumLength = 1)]
        public required string Content { get; set; }

        [Required]
        public required string UserId { get; set; }
    }
}
