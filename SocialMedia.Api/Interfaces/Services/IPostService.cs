using SocialMedia.Api.Dtos.Post;
using SocialMedia.Api.Models;

namespace SocialMedia.Api.Interfaces.Services
{
    public interface IPostService : IDefaultService<PostModel, CreatePostRequestDto, UpdatePostRequestDto>
    {
    }
}
