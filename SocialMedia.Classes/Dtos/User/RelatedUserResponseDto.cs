namespace SocialMedia.Shared.Dtos.User
{
    public class RelatedUserResponseDto
    {
        public string Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Username { get; set; } = string.Empty;

        public required string Email { get; set; }
    }
}
