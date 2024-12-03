using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Api.Dtos.ChildComment
{
    public class UpdateChildCommentRequestDto
    {
        [Required]
        public int Id { get; set; }

        [StringLength(200, MinimumLength = 1)]
        public string Content { get; set; } = string.Empty;
    }
}
