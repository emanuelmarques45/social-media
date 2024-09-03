//using Api.Dtos.Post;
using Api.Dtos.Post;
using Api.Models;

namespace Api.Interfaces.Repository
{
    public interface IPostRepository
    {
        Task<PostModel> CreateAsync(PostModel Post);
        Task<List<PostModel>> GetAllAsync();
        Task<PostModel?> GetByIdAsync(int id);
        Task<PostModel?> UpdateAsync(int id, UpdatePostRequestDto userDto);
        Task<PostModel?> DeleteAsync(int id);
    }
}
