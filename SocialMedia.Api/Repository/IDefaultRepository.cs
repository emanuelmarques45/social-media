namespace SocialMedia.Api.Repository
{
    public interface IDefaultRepository<T>
    {
        Task<T> Create(T registerToCreate);

        Task<List<T>> GetAll();

        Task<T?> GetById(int id);

        Task<T> Update(T registerToUpdate);

        Task<T> Delete(T registerToDelete);
    }
}
