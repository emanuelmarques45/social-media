using SocialMedia.Classes.Dtos.ChildComment;
using SocialMedia.Classes.Models;

namespace SocialMedia.Classes.Mappers
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
