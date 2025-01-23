using System.Net.Http.Json;
using SocialMedia.Classes.Dtos.Post;
using SocialMedia.Classes.Interfaces;

namespace SocialMedia.Front.Client.Services
{
    [Service(ServiceLifetime.Scoped)]
    public class PostService(HttpClient httpClient) : IPostService
    {
        public Task<PostResponseDto?> Create(CreatePostRequestDto postToCreate) => throw new NotImplementedException();
        public async Task<List<PostResponseDto>> GetAll() => (await httpClient.GetFromJsonAsync<List<PostResponseDto>>("posts"))!;
        public async Task<PostResponseDto?> GetById(int id) => await httpClient.GetFromJsonAsync<PostResponseDto?>($"posts/{id}");
        public Task<PostResponseDto?> Update(UpdatePostRequestDto postToUpdate) => throw new NotImplementedException();
        public Task<PostResponseDto?> Delete(int id) => throw new NotImplementedException();
    }
}
