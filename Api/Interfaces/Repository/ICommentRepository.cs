using Api.Dtos.Comment;
using Api.Models;

namespace Api.Interfaces.Repository
{
    public interface ICommentRepository
    {
        Task<CommentModel> CreateAsync(CommentModel comment);
        Task<List<CommentModel>> GetAllAsync();
        Task<CommentModel?> GetByIdAsync(int id);
        Task<CommentModel?> UpdateAsync(int id, UpdateCommentRequestDto commentDto);
        Task<CommentModel?> DeleteAsync(int id);
    }
}
