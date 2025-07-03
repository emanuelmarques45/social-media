using SocialMedia.Lib.Dtos.User;
using SocialMedia.Lib.Helpers.ApiResult;
using SocialMedia.Lib.Models;

namespace SocialMedia.Lib.Interfaces
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
