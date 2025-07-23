using SocialMedia.Shared.Dtos.Comment;

namespace SocialMedia.Shared.Interfaces
{
    public interface ICommentService : IDefaultService<CommentResponseDto, CreateCommentRequestDto, UpdateCommentRequestDto>
    {
        Task<List<CommentResponseDto>> GetByPostId(int id);
    }
}
