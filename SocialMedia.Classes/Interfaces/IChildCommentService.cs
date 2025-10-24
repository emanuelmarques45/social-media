using SocialMedia.Shared.Dtos.ChildComment;
using SocialMedia.Shared.Helpers.ApiResult;

namespace SocialMedia.Shared.Interfaces
{
    public interface IChildCommentService : IDefaultService<ChildCommentResponseDto, CreateChildCommentRequestDto, UpdateChildCommentRequestDto>
    {
        public Task<ApiResult<List<ChildCommentResponseDto>>> GetByCommentId(int commentId);
    }
}
