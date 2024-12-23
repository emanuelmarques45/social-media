using SocialMedia.Classes.Dtos.Account;
using SocialMedia.Classes.Dtos.Comment;
using SocialMedia.Classes.Dtos.Likes;

namespace SocialMedia.Classes.Dtos.Post
{
    public class PostResponseDto
    {
        public int Id { get; set; }

        public required string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        public RelatedAccountResponseDto User { get; set; } = default!;

        public List<LikeResponseDto> Likes { get; set; } = [];

        public List<CommentResponseDto> Comments { get; set; } = [];
    }
}
