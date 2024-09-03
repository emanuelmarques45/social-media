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
                CreatedAt = post.CreatedAt,
                UserId = post.UserId,
                Likes = post.Likes.Select(l => l.ToGetLikeResponseDto()).ToList(),
                //Comments = post.Comments,
            };
        }

        public static PostModel ToPostDto(this CreatePostRequestDto postRequestDto)
        {
            return new PostModel
            {
                Content = postRequestDto.Content,
                UserId = postRequestDto.UserId
            };
        }
    }
}
