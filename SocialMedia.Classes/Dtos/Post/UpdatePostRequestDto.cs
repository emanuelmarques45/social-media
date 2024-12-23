using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Classes.Dtos.Post
{
    public class UpdatePostRequestDto
    {
        [Required]
        public int Id { get; set; }

        [StringLength(280, MinimumLength = 1)]
        public required string Content { get; set; }
    }
}
