using Microsoft.AspNetCore.Identity;
using SocialMedia.Api.Dtos.Comment;
using SocialMedia.Api.Interfaces.Repository;
using SocialMedia.Api.Interfaces.Services;
using SocialMedia.Api.Mappers;
using SocialMedia.Api.Models;

namespace SocialMedia.Api.Services
{
    public class CommentService(ICommentRepository _commentRepo, UserManager<UserModel> _userManager, IPostRepository _postRepo) : ICommentService
    {
        public async Task<CommentModel?> Create(CreateCommentRequestDto commentToCreate)
        {
            var postDb = await _postRepo.GetById(commentToCreate.PostId);
            var userDb = await _userManager.FindByIdAsync(commentToCreate.UserId);

            if (postDb == null || userDb == null)
            {
                return null;
            }

            var createdComment = await _commentRepo.Create(commentToCreate.ToCommentModel());

            return createdComment;
        }

        public async Task<List<CommentModel>> GetAll()
        {
            return await _commentRepo.GetAll();
        }

        public async Task<CommentModel?> GetById(int id)
        {
            return await _commentRepo.GetById(id);
        }

        public async Task<CommentModel?> Update(UpdateCommentRequestDto commentToUpdate)
        {
            var commentDb = await GetById(commentToUpdate.Id);

            if (commentDb == null)
            {
                return null;
            }

            commentDb.Content = commentToUpdate.Content;

            var updatedComment = await _commentRepo.Update(commentDb);

            return updatedComment;
        }

        public async Task<CommentModel?> Delete(int id)
        {
            var commentDb = await GetById(id);

            if (commentDb == null)
            {
                return null;
            }

            var deletedComment = await _commentRepo.Delete(commentDb);

            return deletedComment;
        }
    }
}
