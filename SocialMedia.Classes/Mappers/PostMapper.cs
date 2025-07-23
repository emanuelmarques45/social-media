using SocialMedia.Shared.Dtos.Post;
using SocialMedia.Shared.Models;

namespace SocialMedia.Shared.Mappers
{
    public static class PostMapper
    {
        public static PostResponseDto ToGetPostResponseDto(this PostModel post)
        {
            return new PostResponseDto
            {
                Id = post.Id,
                Content = post.Content,
                CreatedAt = post.CreatedAt,
                User = post.User.ToGetRelatedUserResponseDto(),
                Likes = post.Likes.Select(l => l.ToPostLikeResponseDto()).ToList(),
                Comments = post.Comments.Select(c => c.ToGetCommentResponseDto()).ToList(),
                CommentCount = post.Comments.Count,
                LikeCount = post.Likes.Count,
            };
        }

        public static PostModel ToPostModel(this CreatePostRequestDto postDto)
        {
            return new PostModel
            {
                Content = postDto.Content,
                UserId = postDto.UserId,
            };
        }
    }
}
