using SocialMedia.Classes.Models;

namespace SocialMedia.Api.Services.Auth
{
    public interface IAuthService
    {
        public Task<string> GenerateAccessToken(UserModel user);
    }
}
