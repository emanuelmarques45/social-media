using SocialMedia.Classes.Dtos.Post;
using SocialMedia.Classes.Interfaces.Services;
using SocialMedia.Classes.Models;

namespace SocialMedia.Classes.Interfaces
{
    public interface IPostService : IDefaultService<PostModel, CreatePostRequestDto, UpdatePostRequestDto>
    {
    }
}
