using Microsoft.AspNetCore.Identity;
using SocialMedia.Api.Repository.Post;
using SocialMedia.Lib.Dtos.Post;
using SocialMedia.Lib.Interfaces;
using SocialMedia.Lib.Mappers;
using SocialMedia.Lib.Models;

namespace SocialMedia.Api.Services
{
    [Service(ServiceLifetime.Scoped)]
    public class PostService(IPostRepository postRepo, UserManager<UserModel> userManager) : IPostService
    {
        public async Task<PostResponseDto?> Create(CreatePostRequestDto postToCreate)
        {
            var userDb = await userManager.FindByIdAsync(postToCreate.UserId);

            if (userDb == null)
            {
                return null;
            }

            var createdPost = await postRepo.Create(postToCreate.ToPostModel());
            var createdPostDto = createdPost.ToGetPostResponseDto();

            return createdPostDto;
        }

        public async Task<List<PostResponseDto>> GetAll()
        {
            var postsDb = await postRepo.GetAll();
            var postsDto = postsDb.Select(p => p.ToGetPostResponseDto()).ToList();

            return postsDto;
        }

        public async Task<PostResponseDto?> GetById(int id)
        {
            var postDb = await postRepo.GetById(id);
            var postDto = postDb?.ToGetPostResponseDto();

            return postDto;
        }

        public async Task<PostResponseDto?> Update(UpdatePostRequestDto postToUpdate)
        {
            var postDb = await postRepo.GetById(postToUpdate.Id);

            if (postDb == null)
            {
                return null;
            }

            postDb.Content = postToUpdate.Content;

            var updatedPost = await postRepo.Update(postDb);
            var updatedPostDto = updatedPost.ToGetPostResponseDto();

            return updatedPostDto;
        }

        public async Task<PostResponseDto?> Delete(int id)
        {
            var postDb = await postRepo.GetById(id);

            if (postDb == null)
            {
                return null;
            }

            var deletedPost = await postRepo.Delete(postDb);
            var deletedPostDto = deletedPost.ToGetPostResponseDto();

            return deletedPostDto;
        }
    }
}
