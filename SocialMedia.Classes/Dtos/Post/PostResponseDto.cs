using SocialMedia.Shared.Dtos.Comment;
using SocialMedia.Shared.Dtos.Likes;
using SocialMedia.Shared.Dtos.User;

namespace SocialMedia.Shared.Dtos.Post
{
    public class PostResponseDto
    {
        public int Id { get; set; }

        public string Content { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public int LikeCount { get; set; }

        public int CommentCount { get; set; }

        public RelatedUserResponseDto User { get; set; } = default!;

        public List<LikeResponseDto> Likes { get; set; } = [];

        public List<CommentResponseDto> Comments { get; set; } = [];
    }
}
