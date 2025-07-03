using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Lib.Dtos.User
{
    public class RegisterRequestDto
    {
        [Required]
        [StringLength(30, MinimumLength = 2)]
        public required string Name { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(40, MinimumLength = 4)]
        public required string Email { get; set; }

        [Required]
        [StringLength(16, MinimumLength = 5)]
        public required string UserName { get; set; }

        [Required]
        [StringLength(16, MinimumLength = 8)]
        public required string Password { get; set; }
    }
}