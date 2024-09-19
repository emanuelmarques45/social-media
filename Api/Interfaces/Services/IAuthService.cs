using SocialMedia.Api.Models;

namespace SocialMedia.Api.Interfaces.Services
{
    public interface IAuthService
    {
        public string GenerateAccessToken(UserModel user);
    }
}
