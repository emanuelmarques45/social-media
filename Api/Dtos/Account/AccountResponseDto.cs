using Api.Dtos.Comment;
using Api.Dtos.Like;
using Api.Dtos.Post;

namespace Api.Dtos.Account
{
    public class AccountResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool EmailConfirmed { get; set; }
        public string UserName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        public List<GetPostResponseDto> Posts { get; set; } = [];
        public List<GetLikeResponseDto> Likes { get; set; } = [];
        public List<GetCommentResponseDto> Comments { get; set; } = [];
    }
}