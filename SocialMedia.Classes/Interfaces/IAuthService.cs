using SocialMedia.Classes.Dtos.User;
using SocialMedia.Classes.Models;

namespace SocialMedia.Classes.Interfaces
{
    public interface IAuthService
    {
        public Task<string> GenerateAccessToken(UserModel user);

        public Task<AuthResponseDto?> Login(LoginRequestDto loginDto);

        public Task<UserModel?> GetCurrentUser();
    }
}
