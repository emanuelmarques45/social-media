using SocialMedia.Lib.Dtos.Post;
using SocialMedia.Lib.Models;

namespace SocialMedia.Lib.Mappers
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
