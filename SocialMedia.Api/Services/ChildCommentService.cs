using Microsoft.AspNetCore.Identity;
using SocialMedia.Api.Repository.ChildComment;
using SocialMedia.Api.Repository.Post;
using SocialMedia.Shared.Dtos.ChildComment;
using SocialMedia.Shared.Dtos.Post;
using SocialMedia.Shared.Interfaces;
using SocialMedia.Shared.Mappers;
using SocialMedia.Shared.Models;

namespace SocialMedia.Api.Services
{
    [Service(ServiceLifetime.Scoped)]
    public class ChildCommentService(IChildCommentRepository childCommentRepo, UserManager<UserModel> userManager, IPostRepository postRepo) : IChildCommentService
    {
        public async Task<ChildCommentResponseDto?> Create(CreateChildCommentRequestDto childCommentToCreate)
        {
            var commentDb = await postRepo.GetById(childCommentToCreate.CommentId);
            var userDb = await userManager.FindByIdAsync(childCommentToCreate.UserId);

            if (commentDb == null || userDb == null)
            {
                return null;
            }

            var createdChildComment = await childCommentRepo.Create(childCommentToCreate.ToChildCommentModel());
            var createdChildCommentDto = createdChildComment.ToChildCommentResponseDto();

            return createdChildCommentDto;
        }

        public async Task<List<ChildCommentResponseDto>> GetAll()
        {
            var childCommentsDb = await childCommentRepo.GetAll();
            var childCommentsDto = childCommentsDb.Select(c => c.ToChildCommentResponseDto()).ToList();

            return childCommentsDto;
        }

        public async Task<ChildCommentResponseDto?> GetById(int id)
        {
            var childCommentDb = await childCommentRepo.GetById(id);
            var childCommentDto = childCommentDb?.ToChildCommentResponseDto();

            return childCommentDto;
        }

        public async Task<ChildCommentResponseDto?> Update(int id, UpdateChildCommentRequestDto childCommentToUpdate)
        {
            var childCommentDb = await childCommentRepo.GetById(id);

            if (childCommentDb == null)
            {
                return null;
            }

            childCommentDb.Content = childCommentToUpdate.Content;

            var updatedChildComment = await childCommentRepo.Update(childCommentDb);
            var updatedChildCommentDto = updatedChildComment.ToChildCommentResponseDto();

            return updatedChildCommentDto;
        }

        public async Task<ChildCommentResponseDto?> Delete(int id)
        {
            var childCommentDb = await childCommentRepo.GetById(id);

            if (childCommentDb == null)
            {
                return null;
            }

            var deletedChildComment = await childCommentRepo.Delete(childCommentDb);
            var deletedChildCommentDto = deletedChildComment.ToChildCommentResponseDto();

            return deletedChildCommentDto;
        }

        public Task<List<ChildCommentResponseDto>> GetByUserId(string userId) => throw new NotImplementedException();
    }
}
