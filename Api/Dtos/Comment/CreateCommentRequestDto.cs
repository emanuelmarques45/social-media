using System.ComponentModel.DataAnnotations;

namespace Api.Dtos.Comment
{
    public class CreateCommentRequestDto
    {
        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string Content { get; set; } = string.Empty;
        [Required]
        public int PostId { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
