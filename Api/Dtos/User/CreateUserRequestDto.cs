using System.ComponentModel.DataAnnotations;

namespace Api.Dtos.User
{
    public class CreateUserRequestDto
    {
        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(40, MinimumLength = 4)]
        public string Email { get; set; } = string.Empty;
        [Required]
        [StringLength(16, MinimumLength = 5)]
        public string Username { get; set; } = string.Empty;
        [Required]
        [StringLength(16, MinimumLength = 8)]
        public string Password { get; set; } = string.Empty;
    }
}