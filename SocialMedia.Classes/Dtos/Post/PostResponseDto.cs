using SocialMedia.Classes.Dtos.Comment;
using SocialMedia.Classes.Dtos.Likes;
using SocialMedia.Classes.Dtos.User;

namespace SocialMedia.Classes.Dtos.Post
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
