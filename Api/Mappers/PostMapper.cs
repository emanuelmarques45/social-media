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
