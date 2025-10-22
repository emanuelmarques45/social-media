using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Shared.Dtos.Comment
{
    public class UpdateCommentRequestDto
    {
        [StringLength(200, MinimumLength = 1)]
        public string Content { get; set; } = string.Empty;
    }
}
