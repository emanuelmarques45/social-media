using Api.Dtos.Comment;
using Api.Models;

namespace Api.Mappers
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

        public static CommentModel ToCommentDto(this CreateCommentRequestDto commentDto)
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
