using SocialMedia.Classes.Dtos.Comment;
using SocialMedia.Classes.Dtos.Likes;
using SocialMedia.Classes.Dtos.Post;

namespace SocialMedia.Classes.Dtos.User
{
    public class UserResponseDto
    {
        public required string Id { get; set; }

        public required string Name { get; set; }

        public required string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public required string UserName { get; set; }

        public DateTime CreatedAt { get; set; }

        public List<PostResponseDto> Posts { get; set; } = [];

        public List<LikeResponseDto> Likes { get; set; } = [];

        public List<CommentResponseDto> Comments { get; set; } = [];

        public List<RelatedUserResponseDto> Followers { get; set; } = [];

        public List<RelatedUserResponseDto> Followings { get; set; } = [];
    }
}