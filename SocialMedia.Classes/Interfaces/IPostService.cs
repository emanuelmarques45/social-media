using SocialMedia.Lib.Dtos.Post;

namespace SocialMedia.Lib.Interfaces
{
    public interface IPostService : IDefaultService<PostResponseDto, CreatePostRequestDto, UpdatePostRequestDto>
    {
    }
}
