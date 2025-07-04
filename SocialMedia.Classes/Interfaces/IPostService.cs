using SocialMedia.Shared.Dtos.Post;

namespace SocialMedia.Shared.Interfaces
{
    public interface IPostService : IDefaultService<PostResponseDto, CreatePostRequestDto, UpdatePostRequestDto>
    {
    }
}
