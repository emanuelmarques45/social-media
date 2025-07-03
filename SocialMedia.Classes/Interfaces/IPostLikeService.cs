using SocialMedia.Lib.Dtos.Likes;
using SocialMedia.Lib.Helpers.ApiResult;

namespace SocialMedia.Lib.Interfaces
{
    public interface IPostLikeService
    {
        Task<List<LikeResponseDto>> GetAll(LikeableType likeType);

        Task<LikeResponseDto?> GetById(int id, LikeableType likeType);

        Task<ApiResult<LikeResponseDto>> ToggleLike(CreateLikeRequestDto likeToCreate);
    }
}
