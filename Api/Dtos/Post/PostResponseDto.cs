using SocialMedia.Api.Dtos.Account;
using SocialMedia.Api.Dtos.Comment;
using SocialMedia.Api.Dtos.Like;

namespace SocialMedia.Api.Dtos.Post
{
    public class PostResponseDto
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        //Navigation properties
        public RelatedAccountResponseDto User { get; set; } = null!;
        public List<LikeResponseDto> Likes { get; set; } = [];
        public List<CommentResponseDto> Comments { get; set; } = [];
    }
}
