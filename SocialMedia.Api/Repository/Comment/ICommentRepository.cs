using SocialMedia.Shared.Models;

namespace SocialMedia.Api.Repository.Comment
{
    public interface ICommentRepository : IDefaultRepository<CommentModel>
    {
        Task<List<CommentModel>> GetByPostId(int id);
    }
}
