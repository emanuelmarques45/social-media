using SocialMedia.Api.Models;

namespace SocialMedia.Api.Interfaces.Services
{
    public interface IAuthService
    {
        public Task<string> GenerateAccessToken(UserModel user);
    }
}
