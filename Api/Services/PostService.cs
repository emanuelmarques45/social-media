using SocialMedia.Api.Dtos.Post;
using SocialMedia.Api.Interfaces.Repository;
using SocialMedia.Api.Interfaces.Services;
using SocialMedia.Api.Mappers;
using SocialMedia.Api.Models;

namespace SocialMedia.Api.Services
{
    public class PostService(IPostRepository _postRepo) : IPostService
    {
        public async Task<PostModel> Create(CreatePostRequestDto postToCreate)
        {
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

            if (!string.IsNullOrWhiteSpace(postToUpdate.Content))
            {
                postDb.Content = postToUpdate.Content;
            }

            var updatedPost = await _postRepo.Update(postDb);

            return updatedPost;
        }

        public Task<PostModel> Delete(CreatePostRequestDto postToDelete)
        {
            throw new NotImplementedException();
        }
    }
}
