using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Classes.Dtos.Comment
{
    public class UpdateCommentRequestDto
    {
        [Required]
        public int Id { get; set; }

        [StringLength(200, MinimumLength = 1)]
        public required string Content { get; set; }
    }
}
