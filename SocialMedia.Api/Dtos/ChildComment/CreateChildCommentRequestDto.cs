using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Api.Dtos.ChildComment
{
    public class CreateChildCommentRequestDto
    {
        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string Content { get; set; } = string.Empty;

        [Required]
        public int CommentId { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;
    }
}
