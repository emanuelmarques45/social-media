using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Shared.Dtos.User
{
    public class LoginRequestDto
    {
        public string? Email { get; set; }

        public string? UserName { get; set; }

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
