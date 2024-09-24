using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Api.Dtos.Comment
{
    public class UpdateCommentRequestDto
    {
        [Required]
        public int Id { get; set; }
        [StringLength(200, MinimumLength = 1)]
        public string Content { get; set; } = string.Empty;
    }
}
