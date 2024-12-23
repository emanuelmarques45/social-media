using Microsoft.AspNetCore.Identity;
using SocialMedia.Api.Repository.Post;
using SocialMedia.Classes.Dtos.Post;
using SocialMedia.Classes.Interfaces;
using SocialMedia.Classes.Mappers;
using SocialMedia.Classes.Models;

namespace SocialMedia.Api.Services.Post
{
    [Service(ServiceLifetime.Scoped)]
    public class PostService(IPostRepository postRepo, UserManager<UserModel> userManager) : IPostService
    {
        public async Task<PostModel?> Create(CreatePostRequestDto postToCreate)
        {
            var userDb = await userManager.FindByIdAsync(postToCreate.UserId);

            if (userDb == null)
            {
                return null;
            }

            var createdPost = await postRepo.Create(postToCreate.ToPostModel());

            return createdPost;
        }

        public async Task<List<PostModel>> GetAll() => await postRepo.GetAll();

        public async Task<PostModel?> GetById(int id) => await postRepo.GetById(id);

        public async Task<PostModel?> Update(UpdatePostRequestDto postToUpdate)
        {
            var postDb = await GetById(postToUpdate.Id);

            if (postDb == null)
            {
                return null;
            }

            postDb.Content = postToUpdate.Content;

            var updatedPost = await postRepo.Update(postDb);

            return updatedPost;
        }

        public async Task<PostModel?> Delete(int id)
        {
            var postDb = await GetById(id);

            if (postDb == null)
            {
                return null;
            }

            var deletedPost = await postRepo.Delete(postDb);

            return deletedPost;
        }
    }
}
