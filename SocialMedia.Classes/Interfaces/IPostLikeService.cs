using SocialMedia.Shared.Dtos.Likes;
using SocialMedia.Shared.Helpers.ApiResult;

namespace SocialMedia.Shared.Interfaces
{
    public interface IPostLikeService
    {
        Task<List<LikeResponseDto>> GetAll(LikeableType likeType);

        Task<LikeResponseDto?> GetById(int id, LikeableType likeType);

        Task<ApiResult<LikeResponseDto>> ToggleLike(CreateLikeRequestDto likeToCreate);
    }
}
