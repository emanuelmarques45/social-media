using Microsoft.AspNetCore.Identity;
using SocialMedia.Api.Repository.Comment;
using SocialMedia.Api.Repository.Post;
using SocialMedia.Shared.Dtos.Comment;
using SocialMedia.Shared.Dtos.Post;
using SocialMedia.Shared.Interfaces;
using SocialMedia.Shared.Mappers;
using SocialMedia.Shared.Models;

namespace SocialMedia.Api.Services
{
    [Service(ServiceLifetime.Scoped)]
    public class CommentService(ICommentRepository commentRepo, UserManager<UserModel> userManager, IPostRepository postRepo) : ICommentService
    {
        public async Task<CommentResponseDto?> Create(CreateCommentRequestDto commentToCreate)
        {
            var postDb = await postRepo.GetById(commentToCreate.PostId);
            var userDb = await userManager.FindByIdAsync(commentToCreate.UserId);

            if (postDb == null || userDb == null)
            {
                return null;
            }

            var createdComment = await commentRepo.Create(commentToCreate.ToCommentModel());
            var createdCommentDto = createdComment.ToGetCommentResponseDto();

            return createdCommentDto;
        }

        public async Task<List<CommentResponseDto>> GetAll()
        {
            var commentsDb = await commentRepo.GetAll();
            var commentsDto = commentsDb.Select(p => p.ToGetCommentResponseDto()).ToList();

            return commentsDto;
        }

        public async Task<CommentResponseDto?> GetById(int id)
        {
            var commentDb = await commentRepo.GetById(id);
            var commentDto = commentDb?.ToGetCommentResponseDto();

            return commentDto;
        }

        public async Task<CommentResponseDto?> Update(UpdateCommentRequestDto commentToUpdate)
        {
            var commentDb = await commentRepo.GetById(commentToUpdate.Id);

            if (commentDb == null)
            {
                return null;
            }

            commentDb.Content = commentToUpdate.Content;

            var updatedComment = await commentRepo.Update(commentDb);
            var updatedCommentDto = updatedComment.ToGetCommentResponseDto();

            return updatedCommentDto;
        }

        public async Task<CommentResponseDto?> Delete(int id)
        {
            var commentDb = await commentRepo.GetById(id);

            if (commentDb == null)
            {
                return null;
            }

            var deletedComment = await commentRepo.Delete(commentDb);
            var deletedCommentDto = deletedComment.ToGetCommentResponseDto();

            return deletedCommentDto;
        }

        public Task<List<PostResponseDto>> GetByUserId(string userId) => throw new NotImplementedException();
    }
}
