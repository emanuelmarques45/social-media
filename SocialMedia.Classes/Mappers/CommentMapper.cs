using SocialMedia.Shared.Dtos.Comment;
using SocialMedia.Shared.Models;

namespace SocialMedia.Shared.Mappers
{
    public static class CommentMapper
    {
        public static CommentResponseDto ToCommentResponseDto(this CommentModel comment)
        {
            return new CommentResponseDto
            {
                Id = comment.Id,
                Content = comment.Content,
                CreatedAt = comment.CreatedAt,
                PostId = comment.PostId,
                User = comment.User.ToGetRelatedUserResponseDto(),
                ChidComments = comment.ChildComments.Select(c => c.ToChildCommentResponseDto()).ToList(),
            };
        }

        public static UserCommentResponseDto ToUserCommentResponseDto(this CommentModel comment)
        {
            return new UserCommentResponseDto
            {
                Id = comment.Id,
                Content = comment.Content,
                CreatedAt = comment.CreatedAt,
                PostId = comment.PostId,
                ChidComments = comment.ChildComments.Select(c => c.ToChildCommentResponseDto()).ToList(),
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
