using SocialMedia.Classes.Dtos.Likes;

namespace SocialMedia.Classes.Interfaces
{
    public interface ILikeService : IDefaultService<LikeResponseDto, CreateLikeRequestDto, UpdateLikeRequestDto>
    {
        Task<LikeResponseDto?> LikePost(CreateLikeRequestDto likeToCreate);
    }
}
