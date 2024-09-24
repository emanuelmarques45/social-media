using SocialMedia.Api.Dtos.Like;
using SocialMedia.Api.Models;

namespace SocialMedia.Api.Mappers
{
    public static class LikeMapper
    {
        public static LikeResponseDto ToGetLikeResponseDto(this LikeModel like)
        {
            return new LikeResponseDto
            {
                Id = like.Id,
                PostId = like.PostId,
                UserId = like.UserId,
                CreatedAt = like.CreatedAt
            };
        }

        public static LikeModel ToLikeModelDto(this CreateLikeRequestDto likeDto)
        {
            return new LikeModel
            {
                PostId = likeDto.PostId,
                UserId = likeDto.UserId
            };
        }
    }
}