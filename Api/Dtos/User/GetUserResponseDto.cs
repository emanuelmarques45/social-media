using Api.Models;

namespace Api.Dtos.User
{
    public class GetUserResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public DateTime CreatedAt { get; }

        public List<Post> Posts { get; set; } = [];
        public List<Like> Likes { get; set; } = [];
        public List<Comment> Comments { get; set; } = [];
    }
}