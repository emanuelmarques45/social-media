using SocialMedia.Shared.Dtos.Likes;
using SocialMedia.Shared.Models;

namespace SocialMedia.Shared.Mappers
{
    public static class PostLikeMapper
    {
        public static LikeResponseDto ToPostLikeResponseDto(this PostLikeModel like)
        {
            return new LikeResponseDto
            {
                TargetId = like.PostId,
                UserId = like.UserId,
                CreatedAt = like.CreatedAt,
            };
        }

        public static LikeResponseDto ToPostLikeResponseDto(this CommentLikeModel like)
        {
            return new LikeResponseDto
            {
                TargetId = like.CommentId,
                UserId = like.UserId,
                CreatedAt = like.CreatedAt,
            };
        }

        public static LikeResponseDto ToPostLikeResponseDto(this ChildCommentLikeModel like)
        {
            return new LikeResponseDto
            {
                TargetId = like.ChildCommentId,
                UserId = like.UserId,
                CreatedAt = like.CreatedAt,
            };
        }

        public static PostLikeModel ToPostLikeModel(this CreateLikeRequestDto likeDto)
        {
            return new PostLikeModel
            {
                PostId = likeDto.TargetId,
                UserId = likeDto.UserId,
            };
        }
    }
}