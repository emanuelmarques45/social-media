using Api.Dtos.Like;
using Api.Models;

namespace Api.Mappers
{
    public static class LikeMapper
    {
        public static GetLikeResponseDto ToGetLikeResponseDto(this LikeModel like)
        {
            return new GetLikeResponseDto
            {
                Id = like.Id,
                PostId = like.PostId,
                UserId = like.UserId,
                CreatedAt = like.CreatedAt
            };
        }

        public static LikeModel ToLikeDto(this CreateLikeRequestDto likeDto)
        {
            return new LikeModel
            {
                PostId = likeDto.PostId,
                UserId = likeDto.UserId
            };
        }
    }
}