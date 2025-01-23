using System.Net.Http.Json;
using SocialMedia.Classes.Dtos.User;
using SocialMedia.Classes.Interfaces;
using SocialMedia.Classes.Models;

namespace SocialMedia.Front.Client.Services
{
    [Service(ServiceLifetime.Scoped)]
    public class AuthService(HttpClient httpClient) : IAuthService
    {
        public Task<string> GenerateAccessToken(UserModel user) => throw new NotImplementedException();
        public Task<UserModel?> GetCurrentUser()
        {
            var user = httpClient.GetFromJsonAsync<UserModel?>("users/current");

            return user;
        }

        public async Task<AuthResponseDto?> Login(LoginRequestDto loginDto)
        {
            var response = await httpClient.PostAsJsonAsync("auth/login", loginDto);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<AuthResponseDto>();
            }

            return null;
        }
    }
}