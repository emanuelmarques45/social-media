using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Classes.Dtos.ChildComment
{
    public class UpdateChildCommentRequestDto
    {
        [Required]
        public int Id { get; set; }

        [StringLength(200, MinimumLength = 1)]
        public required string Content { get; set; }
    }
}
