using SocialMedia.Api.Dtos.Comment;
using SocialMedia.Api.Dtos.Likes;
using SocialMedia.Api.Dtos.Post;

namespace SocialMedia.Api.Dtos.Account
{
    public class AccountResponseDto
    {
        public string Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public bool EmailConfirmed { get; set; }

        public string UserName { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public List<PostResponseDto> Posts { get; set; } = [];

        public List<LikeResponseDto> Likes { get; set; } = [];

        public List<CommentResponseDto> Comments { get; set; } = [];
    }
}