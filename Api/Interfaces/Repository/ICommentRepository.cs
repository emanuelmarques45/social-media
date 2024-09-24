using SocialMedia.Api.Models;

namespace SocialMedia.Api.Interfaces.Repository
{
    public interface ICommentRepository
    {
        Task<CommentModel> Create(CommentModel commentToCreate);
        Task<List<CommentModel>> GetAll();
        Task<CommentModel?> GetById(int id);
        Task<CommentModel> Update(CommentModel commentToUpdate);
        Task<CommentModel> Delete(CommentModel commentToDelete);
    }
}
