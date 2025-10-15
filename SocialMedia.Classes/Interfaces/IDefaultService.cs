using SocialMedia.Shared.Dtos.Post;

namespace SocialMedia.Shared.Interfaces
{
    public interface IDefaultService<T, TCreate, TUpdate>
    {
        public Task<T?> Create(TCreate postToCreate);

        public Task<List<T>> GetAll();

        public Task<T?> GetById(int id);

        public Task<T?> Update(TUpdate postToUpdate);

        public Task<T?> Delete(int id);
        Task<List<T>> GetByUserId(string userId);
    }
}
