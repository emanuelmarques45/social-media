using Api.Dtos.Like;
using Api.Dtos.Post;

namespace Api.Dtos.User
{
    public class GetUserResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        public List<GetPostResponseDto> Posts { get; set; } = [];
        public List<GetLikeResponseDto> Likes { get; set; } = [];
        //public List<CommentModel> Comments { get; set; } = [];
    }
}