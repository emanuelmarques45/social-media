using Microsoft.AspNetCore.Identity;
using SocialMedia.Api.Repository.Post;
using SocialMedia.Shared.Dtos.Post;
using SocialMedia.Shared.Helpers.ApiResult;
using SocialMedia.Shared.Interfaces;
using SocialMedia.Shared.Mappers;
using SocialMedia.Shared.Models;

namespace SocialMedia.Api.Services
{
    [Service(ServiceLifetime.Scoped)]
    public class PostService(IPostRepository postRepo, UserManager<UserModel> userManager) : IPostService
    {
        private string PostNotFoundMsg => $"{GetType().Name.Replace("Service", string.Empty)[..]} not found.";

        public async Task<ApiResult<PostResponseDto>> Create(CreatePostRequestDto postToCreate)
        {
            var userDb = await userManager.FindByIdAsync(postToCreate.UserId);

            if (userDb == null)
            {
                return ApiResultReturn.Fail<PostResponseDto>(["User not found."], "Failed to create post.");
            }

            var createdPost = await postRepo.Create(postToCreate.ToPostModel());
            var createdPostDto = createdPost.ToPostResponseDto();

            return ApiResultReturn.Ok(createdPostDto, "Post created.");
        }

        public async Task<ApiResult<List<PostResponseDto>>> GetAll()
        {
            var postsDb = await postRepo.GetAll();
            var postsDto = postsDb.Select(p => p.ToPostResponseDto()).ToList();

            return ApiResultReturn.Ok(postsDto);
        }

        public async Task<ApiResult<PostResponseDto>> GetById(int id)
        {
            var postDb = await postRepo.GetById(id);

            if (postDb == null)
            {
                return ApiResultReturn.Fail<PostResponseDto>([PostNotFoundMsg], "Failed to get post.");
            }

            var postDto = postDb.ToPostResponseDto();

            return ApiResultReturn.Ok(postDto);
        }

        public async Task<ApiResult<PostResponseDto>> Update(int id, UpdatePostRequestDto postToUpdate)
        {
            var postDb = await postRepo.GetById(id);

            if (postDb == null)
            {
                return ApiResultReturn.Fail<PostResponseDto>([PostNotFoundMsg], "Failed to create post.");
            }

            if (!string.IsNullOrWhiteSpace(postToUpdate.Content))
            {
                postDb.Content = postToUpdate.Content;
            }

            var updatedPost = await postRepo.Update(postDb);
            var updatedPostDto = updatedPost.ToPostResponseDto();

            return ApiResultReturn.Ok(updatedPostDto, "Post updated.");
        }

        public async Task<ApiResult<PostResponseDto>> Delete(int id)
        {
            var postDb = await postRepo.GetById(id);

            if (postDb == null)
            {
                return ApiResultReturn.Fail<PostResponseDto>([PostNotFoundMsg], "Failed to delete post.");
            }

            var deletedPost = await postRepo.Delete(postDb);
            var deletedPostDto = deletedPost.ToPostResponseDto();

            return ApiResultReturn.Ok(deletedPostDto, "Post deleted.");
        }

        public async Task<ApiResult<List<PostResponseDto>>> GetByUserId(string userId)
        {
            var userDb = await userManager.FindByIdAsync(userId);

            if (userDb == null)
            {
                return ApiResultReturn.Fail<List<PostResponseDto>>(["User not found."], "Failed to get posts.");
            }

            var postsDb = await postRepo.GetByUserId(userId);
            var postsDto = postsDb.Select(p => p.ToPostResponseDto()).ToList();

            return ApiResultReturn.Ok(postsDto);
        }
    }
}
