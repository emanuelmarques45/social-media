using SocialMedia.Api.Dtos.Comment;
using SocialMedia.Api.Models;

namespace SocialMedia.Api.Mappers
{
    public static class CommentMapper
    {
        public static CommentResponseDto ToGetCommentResponseDto(this CommentModel comment)
        {
            return new CommentResponseDto
            {
                Id = comment.Id,
                Content = comment.Content,
                CreatedAt = comment.CreatedAt,
                PostId = comment.PostId,
                User = comment.User.ToGetRelatedAccountResponseDto(),
            };
        }

        public static CommentModel ToCommentModel(this CreateCommentRequestDto commentDto)
        {
            return new CommentModel
            {
                Content = commentDto.Content,
                PostId = commentDto.PostId,
                UserId = commentDto.UserId,
            };
        }
    }
}
