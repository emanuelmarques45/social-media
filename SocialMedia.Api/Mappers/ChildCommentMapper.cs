using SocialMedia.Api.Dtos.ChildComment;
using SocialMedia.Api.Models;

namespace SocialMedia.Api.Mappers
{
    public static class ChildCommentMapper
    {
        public static ChildCommentResponseDto ToGetChildCommentResponseDto(this ChildCommentModel childComment)
        {
            return new ChildCommentResponseDto
            {
                Id = childComment.Id,
                Content = childComment.Content,
                CreatedAt = childComment.CreatedAt,
                CommentId = childComment.CommentId,
                UserId = childComment.UserId,
                User = childComment.User.ToGetRelatedAccountResponseDto(),
            };
        }

        public static ChildCommentModel ToChildCommentModel(this CreateChildCommentRequestDto childCommentDto)
        {
            return new ChildCommentModel
            {
                Content = childCommentDto.Content,
                CommentId = childCommentDto.CommentId,
                UserId = childCommentDto.UserId,
            };
        }
    }
}
