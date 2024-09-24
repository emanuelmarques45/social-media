using SocialMedia.Api.Dtos.Post;
using SocialMedia.Api.Models;

namespace SocialMedia.Api.Interfaces.Services
{
    public interface IPostService
    {
        public Task<PostModel?> Create(CreatePostRequestDto postToCreate);
        public Task<List<PostModel>> GetAll();
        public Task<PostModel?> GetById(int id);
        public Task<PostModel?> Update(UpdatePostRequestDto postToUpdate);
        public Task<PostModel?> Delete(int id);
    }
}
