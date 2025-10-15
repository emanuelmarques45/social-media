using SocialMedia.Shared.Dtos.Likes;

namespace SocialMedia.Api.Repository.Likes
{
    public interface ILikeRepository
    {
        Task<bool> Exists(CreateLikeRequestDto like);

        Task<LikeResponseDto> Create(CreateLikeRequestDto likeToCreate);

        Task<bool> Delete(CreateLikeRequestDto likeToDelete);

        Task<List<LikeResponseDto>> GetAll(LikeableType likeType);

        Task<LikeResponseDto?> GetById(int id, LikeableType likeType);
    }
}
