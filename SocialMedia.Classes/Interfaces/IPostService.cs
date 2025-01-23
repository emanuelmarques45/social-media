using SocialMedia.Classes.Dtos.Post;

namespace SocialMedia.Classes.Interfaces
{
    public interface IPostService : IDefaultService<PostResponseDto, CreatePostRequestDto, UpdatePostRequestDto>
    {
    }
}
