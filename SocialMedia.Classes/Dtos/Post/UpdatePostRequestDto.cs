using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Shared.Dtos.Post
{
    public class UpdatePostRequestDto
    {
        [StringLength(280, MinimumLength = 1)]
        public string Content { get; set; } = string.Empty;
    }
}
