using System.Net.Http.Json;
using SocialMedia.Classes.Dtos.Likes;
using SocialMedia.Classes.Interfaces;

namespace SocialMedia.Front.Client.Services
{
    [Service(ServiceLifetime.Scoped)]
    public class LikeService(IHttpClientFactory httpClientFactory) : ILikeService
    {
        public async Task<LikeResponseDto?> LikePost(CreateLikeRequestDto likeToCreate)
        {
            var httpClient = httpClientFactory.CreateClient("Auth");

            return await httpClient.GetFromJsonAsync<LikeResponseDto>("likes") ?? new();
        }
        public Task<LikeResponseDto?> Create(CreateLikeRequestDto postToCreate) => throw new NotImplementedException();
        public Task<LikeResponseDto?> Delete(int id) => throw new NotImplementedException();
        public Task<List<LikeResponseDto>> GetAll() => throw new NotImplementedException();
        public Task<LikeResponseDto?> GetById(int id) => throw new NotImplementedException();

        public Task<LikeResponseDto?> Update(UpdateLikeRequestDto postToUpdate) => throw new NotImplementedException();
    }
}
