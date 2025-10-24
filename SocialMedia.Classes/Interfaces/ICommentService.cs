using SocialMedia.Shared.Dtos.Comment;
using SocialMedia.Shared.Helpers.ApiResult;

namespace SocialMedia.Shared.Interfaces
{
    public interface ICommentService : IDefaultService<CommentResponseDto, CreateCommentRequestDto, UpdateCommentRequestDto>
    {
        new Task<ApiResult<List<UserCommentResponseDto>>> GetByUserId(string userId);

        Task<ApiResult<List<CommentResponseDto>>> GetByPostId(int postId);
    }
}
