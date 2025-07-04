using SocialMedia.Shared.Dtos.Comment;

namespace SocialMedia.Shared.Interfaces
{
    public interface ICommentService : IDefaultService<CommentResponseDto, CreateCommentRequestDto, UpdateCommentRequestDto>
    {
    }
}
