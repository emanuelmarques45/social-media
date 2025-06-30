using System.Net.Http.Json;
using SocialMedia.Classes.Dtos.Post;
using SocialMedia.Classes.Interfaces;

namespace SocialMedia.Front.Client.Services
{
    [Service(ServiceLifetime.Scoped)]
    public class PostService(IHttpClientFactory httpClientFactory) : IPostService
    {
        public Task<PostResponseDto?> Create(CreatePostRequestDto postToCreate) => throw new NotImplementedException();
        public Task<PostResponseDto?> Delete(int id) => throw new NotImplementedException();
        public async Task<List<PostResponseDto>> GetAll()
        {
            var httpClient = httpClientFactory.CreateClient("Auth");

            return await httpClient.GetFromJsonAsync<List<PostResponseDto>>("posts") ?? [];
        }
        public Task<PostResponseDto?> GetById(int id) => throw new NotImplementedException();
        public Task<PostResponseDto?> Update(UpdatePostRequestDto postToUpdate) => throw new NotImplementedException();
    }
}
