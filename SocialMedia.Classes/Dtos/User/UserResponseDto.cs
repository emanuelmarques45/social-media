using SocialMedia.Shared.Dtos.Comment;
using SocialMedia.Shared.Dtos.Likes;
using SocialMedia.Shared.Dtos.Post;

namespace SocialMedia.Shared.Dtos.User
{
    public class UserResponseDto
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

        public List<RelatedUserResponseDto> Followers { get; set; } = [];

        public List<RelatedUserResponseDto> Followings { get; set; } = [];
    }
}