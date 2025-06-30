using System.Net.Http.Json;
using SocialMedia.Classes.Dtos.User;
using SocialMedia.Classes.Interfaces;
using SocialMedia.Classes.Models;

namespace SocialMedia.Front.Client.Services
{
    [Service(ServiceLifetime.Scoped)]
    public class AuthService(IHttpClientFactory httpClientFactory) : IAuthService
    {
        public Task<string> GenerateAccessToken(UserModel user) => throw new NotImplementedException();
        public async Task<UserModel?> GetCurrentUser()
        {
            var httpClient = httpClientFactory.CreateClient("Auth");

            return await httpClient.GetFromJsonAsync<UserModel>("auth/current-user") ?? new();
        }
        public async Task<AuthResponseDto?> Login(LoginRequestDto loginDto)
        {
            var httpClient = httpClientFactory.CreateClient("Auth");

            var response = await httpClient.PostAsJsonAsync("auth/login", loginDto);

            if (response.IsSuccessStatusCode)
            {
                var authResponse = await response.Content.ReadFromJsonAsync<AuthResponseDto>();
                return authResponse;
            }

            return null;
        }

        public Task Logout() => throw new NotImplementedException();
    }
}
