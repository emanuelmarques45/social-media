using Microsoft.AspNetCore.Identity;
using SocialMedia.Api.Repository.ChildComment;
using SocialMedia.Shared.Dtos.ChildComment;
using SocialMedia.Shared.Helpers.ApiResult;
using SocialMedia.Shared.Interfaces;
using SocialMedia.Shared.Mappers;
using SocialMedia.Shared.Models;

namespace SocialMedia.Api.Services
{
    [Service(ServiceLifetime.Scoped)]
    public class ChildCommentService(IChildCommentRepository childCommentRepo, UserManager<UserModel> userManager, ICommentService commentService) : IChildCommentService
    {
        private string ChildCommentNotFoundMsg => $"{GetType().Name.Replace("Service", string.Empty)[..]} not found.";

        public async Task<ApiResult<ChildCommentResponseDto>> Create(CreateChildCommentRequestDto childCommentToCreate)
        {
            var commentDb = await commentService.GetById(childCommentToCreate.CommentId);
            var userDb = await userManager.FindByIdAsync(childCommentToCreate.UserId);

            if (commentDb == null)
            {
                return ApiResultReturn.Fail<ChildCommentResponseDto>(["Comment not found.", "Failed to create comment."]);
            }

            if (userDb == null)
            {
                return ApiResultReturn.Fail<ChildCommentResponseDto>(["User not found.", "Failed to create comment."]);
            }

            var createdChildComment = await childCommentRepo.Create(childCommentToCreate.ToChildCommentModel());
            var createdChildCommentDto = createdChildComment.ToChildCommentResponseDto();

            return ApiResultReturn.Ok(createdChildCommentDto, "Comment created.");
        }

        public async Task<ApiResult<List<ChildCommentResponseDto>>> GetAll()
        {
            var childCommentsDb = await childCommentRepo.GetAll();
            var childCommentsDto = childCommentsDb.Select(c => c.ToChildCommentResponseDto()).ToList();

            return ApiResultReturn.Ok(childCommentsDto);
        }

        public async Task<ApiResult<ChildCommentResponseDto>> GetById(int id)
        {
            var childCommentDb = await childCommentRepo.GetById(id);

            if (childCommentDb == null)
            {
                return ApiResultReturn.Fail<ChildCommentResponseDto>([ChildCommentNotFoundMsg], "Failed to get comment.");
            }

            var childCommentDto = childCommentDb.ToChildCommentResponseDto();

            return ApiResultReturn.Ok(childCommentDto);
        }

        public async Task<ApiResult<ChildCommentResponseDto>> Update(int id, UpdateChildCommentRequestDto childCommentToUpdate)
        {
            var childCommentDb = await childCommentRepo.GetById(id);

            if (childCommentDb == null)
            {
                return ApiResultReturn.Fail<ChildCommentResponseDto>([ChildCommentNotFoundMsg], "Failed to update comment.");
            }

            childCommentDb.Content = childCommentToUpdate.Content;

            var updatedChildComment = await childCommentRepo.Update(childCommentDb);
            var updatedChildCommentDto = updatedChildComment.ToChildCommentResponseDto();

            return ApiResultReturn.Ok(updatedChildCommentDto, "Comment updated.");
        }

        public async Task<ApiResult<ChildCommentResponseDto>> Delete(int id)
        {
            var childCommentDb = await childCommentRepo.GetById(id);

            if (childCommentDb == null)
            {
                return ApiResultReturn.Fail<ChildCommentResponseDto>([ChildCommentNotFoundMsg], "Failed to delete comment.");
            }

            var deletedChildComment = await childCommentRepo.Delete(childCommentDb);
            var deletedChildCommentDto = deletedChildComment.ToChildCommentResponseDto();

            return ApiResultReturn.Ok(deletedChildCommentDto, "Comment deleted.");
        }

        public Task<ApiResult<List<ChildCommentResponseDto>>> GetByUserId(string userId) => throw new NotImplementedException();

        public async Task<ApiResult<List<ChildCommentResponseDto>>> GetByCommentId(int commentId)
        {
            var commentDb = await commentService.GetById(commentId);

            if (commentDb == null)
            {
                return ApiResultReturn.Fail<List<ChildCommentResponseDto>>([ChildCommentNotFoundMsg], "Failed to get comments.");
            }

            var commentsDb = await childCommentRepo.GetByCommentId(commentId);
            var commentsDto = commentsDb.Select(c => c.ToChildCommentResponseDto()).ToList();

            return ApiResultReturn.Ok(commentsDto);
        }
    }
}
