using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Shared.Dtos.ChildComment
{
    public class CreateChildCommentRequestDto
    {
        [Required]
        [StringLength(200, MinimumLength = 1)]
        public required string Content { get; set; }

        [Required]
        public int CommentId { get; set; }

        [Required]
        public required string UserId { get; set; }
    }
}
