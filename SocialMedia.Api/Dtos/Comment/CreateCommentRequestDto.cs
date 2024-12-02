using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Api.Dtos.Comment
{
    public class CreateCommentRequestDto
    {
        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string Content { get; set; } = string.Empty;

        [Required]
        public int PostId { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;
    }
}
