using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Lib.Dtos.Comment
{
    public class CreateCommentRequestDto
    {
        [Required]
        [StringLength(200, MinimumLength = 1)]
        public required string Content { get; set; }

        [Required]
        public int PostId { get; set; }

        [Required]
        public required string UserId { get; set; }
    }
}
