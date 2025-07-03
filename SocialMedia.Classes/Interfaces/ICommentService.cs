using SocialMedia.Lib.Dtos.Comment;

namespace SocialMedia.Lib.Interfaces
{
    public interface ICommentService : IDefaultService<CommentResponseDto, CreateCommentRequestDto, UpdateCommentRequestDto>
    {
    }
}
