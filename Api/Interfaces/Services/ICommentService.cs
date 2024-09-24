using SocialMedia.Api.Dtos.Comment;
using SocialMedia.Api.Models;

namespace SocialMedia.Api.Interfaces.Services
{
    public interface ICommentService
    {
        public Task<CommentModel?> Create(CreateCommentRequestDto commentToCreate);
        public Task<List<CommentModel>> GetAll();
        public Task<CommentModel?> GetById(int id);
        public Task<CommentModel?> Update(UpdateCommentRequestDto commentToUpdate);
        public Task<CommentModel?> Delete(int id);
    }
}
