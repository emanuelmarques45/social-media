using Microsoft.AspNetCore.Identity;
using SocialMedia.Api.Repository.Likes;
using SocialMedia.Classes.Dtos.Likes;
using SocialMedia.Classes.Interfaces;
using SocialMedia.Classes.Mappers;
using SocialMedia.Classes.Models;

namespace SocialMedia.Api.Services
{
    [Service(ServiceLifetime.Scoped)]
    public class LikeService(ILikeRepository likeRepo, UserManager<UserModel> userManager) : ILikeService
    {
        public async Task<LikeResponseDto?> LikePost(CreateLikeRequestDto likeToCreate)
        {
            var userDb = await userManager.FindByIdAsync(likeToCreate.UserId);

            if (userDb == null)
            {
                return null;
            }

            var createdLike = await likeRepo.Create(likeToCreate.ToLikeModel());
            var createdLikeDto = createdLike.ToGetLikeResponseDto();

            return createdLikeDto;
        }

        public LikeResponseDto? Create(CreateLikeRequestDto likeToCreate) => new();

        public async Task<List<LikeResponseDto>> GetAll()
        {
            var likesDb = await likeRepo.GetAll();
            var likesDto = likesDb.Select(p => p.ToGetLikeResponseDto()).ToList();

            return likesDto;
        }

        public async Task<LikeResponseDto?> GetById(int id)
        {
            var likeDb = await likeRepo.GetById(id);
            var likeDto = likeDb?.ToGetLikeResponseDto();

            return likeDto;
        }

        public async Task<LikeResponseDto?> Update(UpdateLikeRequestDto likeToUpdate)
        {
            var likeDb = await likeRepo.GetById(likeToUpdate.Id);

            if (likeDb == null)
            {
                return null;
            }

            var updatedLike = await likeRepo.Update(likeDb);
            var updatedLikeDto = updatedLike.ToGetLikeResponseDto();

            return updatedLikeDto;
        }

        public async Task<LikeResponseDto?> Delete(int id)
        {
            var likeDb = await likeRepo.GetById(id);

            if (likeDb == null)
            {
                return null;
            }

            var deletedLike = await likeRepo.Delete(likeDb);
            var deletedLikeDto = deletedLike.ToGetLikeResponseDto();

            return deletedLikeDto;
        }

        Task<LikeResponseDto?> IDefaultService<LikeResponseDto, CreateLikeRequestDto, UpdateLikeRequestDto>.Create(CreateLikeRequestDto postToCreate) => throw new NotImplementedException();
    }
}
