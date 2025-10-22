using SocialMedia.Shared.Dtos.Comment;

namespace SocialMedia.Shared.Interfaces
{
    public interface ICommentService : IDefaultService<CommentResponseDto, CreateCommentRequestDto, UpdateCommentRequestDto>
    {
        new Task<List<UserCommentResponseDto>?> GetByUserId(string userId);

        Task<List<CommentResponseDto>?> GetByPostId(int postId);
    }
}
