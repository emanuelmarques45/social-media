using SocialMedia.Classes.Dtos.Likes;
using SocialMedia.Classes.Models;

namespace SocialMedia.Classes.Mappers
{
    public static class LikeMapper
    {
        public static LikeResponseDto ToGetLikeResponseDto(this LikeModel like)
        {
            return new LikeResponseDto
            {
                PostId = like.PostId,
                UserId = like.UserId,
                CreatedAt = like.CreatedAt,
            };
        }

        public static LikeModel ToLikeModel(this CreateLikeRequestDto likeDto)
        {
            return new LikeModel
            {
                PostId = likeDto.PostId,
                UserId = likeDto.UserId,
            };
        }
    }
}