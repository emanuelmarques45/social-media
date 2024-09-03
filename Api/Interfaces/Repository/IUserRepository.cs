using Api.Dtos.User;
using Api.Models;

namespace Api.Interfaces.Repository
{
    public interface IUserRepository
    {
        Task<UserModel> CreateAsync(UserModel user);
        Task<List<UserModel>> GetAllAsync();
        Task<UserModel?> GetByIdAsync(int id);
        Task<UserModel?> UpdateAsync(int id, UpdateUserRequestDto userDto);
        Task<UserModel?> DeleteAsync(int id);
    }
}
