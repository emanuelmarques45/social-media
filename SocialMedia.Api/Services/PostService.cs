using Microsoft.AspNetCore.Identity;
using SocialMedia.Api.Dtos.Post;
using SocialMedia.Api.Interfaces.Repository;
using SocialMedia.Api.Interfaces.Services;
using SocialMedia.Api.Mappers;
using SocialMedia.Api.Models;

namespace SocialMedia.Api.Services
{
    public class PostService(IPostRepository _postRepo, UserManager<UserModel> _userManager) : IPostService
    {
        public async Task<PostModel?> Create(CreatePostRequestDto postToCreate)
        {
            //var userDb = await _userManager.FindByIdAsync(postToCreate.UserId);

            //if (userDb == null)
            //{
            //    return null;
            //}

            var createdPost = await _postRepo.Create(postToCreate.ToPostModel());

            return createdPost;
        }

        public async Task<List<PostModel>> GetAll()
        {
            return await _postRepo.GetAll();
        }

        public async Task<PostModel?> GetById(int id)
        {
            return await _postRepo.GetById(id);
        }

        public async Task<PostModel?> Update(UpdatePostRequestDto postToUpdate)
        {
            var postDb = await GetById(postToUpdate.Id);

            if (postDb == null)
            {
                return null;
            }

            postDb.Content = postToUpdate.Content;

            var updatedPost = await _postRepo.Update(postDb);

            return updatedPost;
        }

        public async Task<PostModel?> Delete(int id)
        {
            var postDb = await GetById(id);

            if (postDb == null)
            {
                return null;
            }

            var deletedPost = await _postRepo.Delete(postDb);

            return deletedPost;
        }
    }
}
