using SocialMedia.Api.Dtos.Comment;
using SocialMedia.Api.Models;

namespace SocialMedia.Api.Mappers
{
    public static class CommentMapper
    {
        public static GetCommentResponseDto ToGetCommentResponseDto(this CommentModel comment)
        {
            return new GetCommentResponseDto
            {
                Id = comment.Id,
                Content = comment.Content,
                CreatedAt = comment.CreatedAt,
                PostId = comment.PostId,
                UserId = comment.UserId
            };
        }

        public static CommentModel ToCommentModel(this CreateCommentRequestDto commentDto)
        {
            return new CommentModel
            {
                Content = commentDto.Content,
                PostId = commentDto.PostId,
                UserId = commentDto.UserId
            };
        }
    }
}
