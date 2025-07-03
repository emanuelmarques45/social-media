using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Lib.Dtos.User
{
    public class UpdateUserRequestDto
    {
        [StringLength(30, MinimumLength = 2)]
        public required string Name { get; set; }

        [StringLength(40, MinimumLength = 4)]
        public required string Email { get; set; }

        [StringLength(16, MinimumLength = 5)]
        public required string UserName { get; set; }

        [StringLength(16, MinimumLength = 8)]
        public required string Password { get; set; }
    }
}
