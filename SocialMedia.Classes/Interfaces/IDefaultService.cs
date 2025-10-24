using SocialMedia.Shared.Helpers.ApiResult;

namespace SocialMedia.Shared.Interfaces
{
    public interface IDefaultService<T, TCreate, TUpdate>
    {
        public Task<ApiResult<T>> Create(TCreate postToCreate);

        public Task<ApiResult<List<T>>> GetAll();

        public Task<ApiResult<T>> GetById(int id);

        public Task<ApiResult<T>> Update(int id, TUpdate postToUpdate);

        public Task<ApiResult<T>> Delete(int id);

        public Task<ApiResult<List<T>>> GetByUserId(string userId) => throw new NotImplementedException();
    }
}
