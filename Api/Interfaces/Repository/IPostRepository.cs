using SocialMedia.Api.Models;

namespace SocialMedia.Api.Interfaces.Repository
{
    public interface IPostRepository
    {
        Task<PostModel> Create(PostModel postToCreate);
        Task<List<PostModel>> GetAll();
        Task<PostModel?> GetById(int id);
        Task<PostModel?> Update(PostModel postToUpdate);
        Task<PostModel?> Delete(int postId);
    }
}
