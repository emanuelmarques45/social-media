using SocialMedia.Shared.Dtos.ChildComment;
using SocialMedia.Shared.Models;

namespace SocialMedia.Shared.Mappers
{
    public static class ChildCommentMapper
    {
        public static ChildCommentResponseDto ToChildCommentResponseDto(this ChildCommentModel childComment)
        {
            return new ChildCommentResponseDto
            {
                Id = childComment.Id,
                Content = childComment.Content,
                CreatedAt = childComment.CreatedAt,
                CommentId = childComment.CommentId,
                User = childComment.User.ToGetRelatedUserResponseDto(),
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
