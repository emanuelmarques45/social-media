using SocialMedia.Classes.Dtos.Comment;

namespace SocialMedia.Classes.Interfaces
{
    public interface ICommentService : IDefaultService<CommentResponseDto, CreateCommentRequestDto, UpdateCommentRequestDto>
    {
    }
}
