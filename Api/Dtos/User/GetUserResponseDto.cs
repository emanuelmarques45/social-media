using Api.Models;

namespace Api.Dtos.User
{
    public class GetUserResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        public List<PostModel> Posts { get; set; } = [];
        public List<LikeModel> Likes { get; set; } = [];
        public List<CommentModel> Comments { get; set; } = [];
    }
}