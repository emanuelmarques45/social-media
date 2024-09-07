using Api.Dtos.Comment;
using Api.Dtos.Like;

namespace Api.Dtos.Post
{
    public class GetPostResponseDto
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }

        //Navigation properties
        public List<GetLikeResponseDto> Likes { get; set; } = [];
        public List<GetCommentResponseDto> Comments { get; set; } = [];
    }
}
