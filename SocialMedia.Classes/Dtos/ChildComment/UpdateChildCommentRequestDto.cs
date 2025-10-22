using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Shared.Dtos.ChildComment
{
    public class UpdateChildCommentRequestDto
    {
        [StringLength(200, MinimumLength = 1)]
        public string Content { get; set; } = string.Empty;
    }
}
