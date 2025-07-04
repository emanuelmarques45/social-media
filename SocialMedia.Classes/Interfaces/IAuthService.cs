using SocialMedia.Shared.Dtos.User;
using SocialMedia.Shared.Helpers.ApiResult;
using SocialMedia.Shared.Models;

namespace SocialMedia.Shared.Interfaces
{
    public interface IAuthService
    {
        public Task<string> GenerateAccessToken(UserModel user);

        public Task<ApiResult<RegisterResponseDto>> Register(RegisterRequestDto registerDto);

        public Task<LoginResponseDto?> Login(LoginRequestDto loginDto);

        public Task Logout();

        public Task<UserModel?> GetCurrentUser();
    }
}
