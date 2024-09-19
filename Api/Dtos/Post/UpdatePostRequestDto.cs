using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Api.Dtos.Post
{
    public class UpdatePostRequestDto
    {
        [Required]
        public int Id { get; set; }
        [StringLength(280)]
        public string Content { get; set; } = string.Empty;
    }
}
