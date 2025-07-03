namespace SocialMedia.Lib.Interfaces
{
    public interface IDefaultService<T, TCreate, TUpdate>
    {
        public Task<T?> Create(TCreate postToCreate);

        public Task<List<T>> GetAll();

        public Task<T?> GetById(int id);

        public Task<T?> Update(TUpdate postToUpdate);

        public Task<T?> Delete(int id);
    }
}
