using SocialMedia.Classes.Dtos.Comment;
using SocialMedia.Classes.Models;

namespace SocialMedia.Classes.Mappers
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
                User = comment.User.ToGetRelatedUserResponseDto(),
                ChidComments = comment.ChildComments.Select(c => c.ToGetChildCommentResponseDto()).ToList(),
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
