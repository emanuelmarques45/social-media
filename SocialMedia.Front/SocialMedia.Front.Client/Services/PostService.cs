using System.Net.Http.Json;
using SocialMedia.Classes.Dtos.Post;
using SocialMedia.Classes.Interfaces;
using SocialMedia.Classes.Models;

namespace SocialMedia.Front.Client.Services
{
    public class PostService(HttpClient http) : IPostService
    {
        public Task<PostModel?> Create(CreatePostRequestDto postToCreate) => throw new NotImplementedException();
        public Task<PostModel?> Delete(int id) => throw new NotImplementedException();
        public async Task<List<PostModel>> GetAll() => (await http.GetFromJsonAsync<List<PostModel>>("posts"))!;
        public Task<PostModel?> GetById(int id) => throw new NotImplementedException();
        public Task<PostModel?> Update(UpdatePostRequestDto postToUpdate) => throw new NotImplementedException();
    }
}
