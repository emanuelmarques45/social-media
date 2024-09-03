using Api.Dtos.Post;
using Api.Models;

namespace Api.Mappers
{
    public static class PostMapper
    {
        public static GetPostResponseDto ToGetPostResponseDto(this PostModel post)
        {
            return new GetPostResponseDto
            {
                Id = post.Id,
                Content = post.Content,
                Likes = post.Likes,
                Comments = post.Comments,
                CreatedAt = post.CreatedAt,
                UserId = post.UserId
            };
        }

        public static PostModel ToPostDto(this CreatePostRequestDto postRequestDto)
        {
            return new PostModel
            {
                Content = postRequestDto.Content,
            };
        }
    }
}
