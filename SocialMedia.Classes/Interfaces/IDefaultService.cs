namespace SocialMedia.Shared.Interfaces
{
    public interface IDefaultService<T, TCreate, TUpdate>
    {
        public Task<T?> Create(TCreate postToCreate);

        public Task<List<T>> GetAll();

        public Task<T?> GetById(int id);

        public Task<T?> Update(int id, TUpdate postToUpdate);

        public Task<T?> Delete(int id);

        public Task<List<T>?> GetByUserId(string userId) => throw new NotImplementedException();
    }
}
