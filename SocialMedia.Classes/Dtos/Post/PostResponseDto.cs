using SocialMedia.Lib.Dtos.Comment;
using SocialMedia.Lib.Dtos.Likes;
using SocialMedia.Lib.Dtos.User;

namespace SocialMedia.Lib.Dtos.Post
{
    public class PostResponseDto
    {
        public int Id { get; set; }

        public string Content { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public RelatedUserResponseDto User { get; set; } = default!;

        public List<LikeResponseDto> Likes { get; set; } = [];

        public List<CommentResponseDto> Comments { get; set; } = [];
    }
}
