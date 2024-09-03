using System.ComponentModel.DataAnnotations;

namespace Api.Dtos.Post
{
    public class CreatePostRequestDto
    {
        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string Content { get; set; } = string.Empty;
        public int UserId { get; set; }
    }
}
