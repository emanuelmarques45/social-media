using SocialMedia.Classes.Dtos.Post;
using SocialMedia.Classes.Models;

namespace SocialMedia.Classes.Mappers
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
                Likes = post.Likes.Select(l => l.ToGetLikeResponseDto()).ToList(),
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
