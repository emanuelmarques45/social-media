namespace SocialMedia.Classes.Dtos.User
{
    public class AuthResponseDto
    {
        public required string Name { get; set; }

        public required string UserName { get; set; }

        public required string Email { get; set; }

        public required string Token { get; set; }
    }
}
