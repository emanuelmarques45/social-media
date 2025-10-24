using Microsoft.AspNetCore.Identity;
using SocialMedia.Api.Repository.Comment;
using SocialMedia.Api.Repository.Post;
using SocialMedia.Shared.Dtos.Comment;
using SocialMedia.Shared.Helpers.ApiResult;
using SocialMedia.Shared.Interfaces;
using SocialMedia.Shared.Mappers;
using SocialMedia.Shared.Models;

namespace SocialMedia.Api.Services
{
    [Service(ServiceLifetime.Scoped)]
    public class CommentService(ICommentRepository commentRepo, UserManager<UserModel> userManager, IPostRepository postRepo) : ICommentService
    {
        private string CommentNotFoundMsg => $"{GetType().Name.Replace("Service", string.Empty)[..]} not found.";

        public async Task<ApiResult<CommentResponseDto>> Create(CreateCommentRequestDto commentToCreate)
        {
            var postDb = await postRepo.GetById(commentToCreate.PostId);
            var userDb = await userManager.FindByIdAsync(commentToCreate.UserId);

            if (postDb == null)
            {
                return ApiResultReturn.Fail<CommentResponseDto>(["Post not found.", "Failed to create comment."]);
            }

            if (userDb == null)
            {
                return ApiResultReturn.Fail<CommentResponseDto>(["User not found.", "Failed to create comment."]);
            }

            var createdComment = await commentRepo.Create(commentToCreate.ToCommentModel());
            var createdCommentDto = createdComment.ToCommentResponseDto();

            return ApiResultReturn.Ok(createdCommentDto, "Comment created.");
        }

        public async Task<ApiResult<List<CommentResponseDto>>> GetAll()
        {
            var commentsDb = await commentRepo.GetAll();
            var commentsDto = commentsDb.Select(p => p.ToCommentResponseDto()).ToList();

            return ApiResultReturn.Ok(commentsDto);
        }

        public async Task<ApiResult<CommentResponseDto>> GetById(int id)
        {
            var commentDb = await commentRepo.GetById(id);

            if (commentDb == null)
            {
                return ApiResultReturn.Fail<CommentResponseDto>([CommentNotFoundMsg], "Failed to get comment.");
            }

            var commentDto = commentDb.ToCommentResponseDto();

            return ApiResultReturn.Ok(commentDto);
        }

        public async Task<ApiResult<CommentResponseDto>> Update(int id, UpdateCommentRequestDto commentToUpdate)
        {
            var commentDb = await commentRepo.GetById(id);

            if (commentDb == null)
            {
                return ApiResultReturn.Fail<CommentResponseDto>([CommentNotFoundMsg], "Failed to update comment.");
            }

            commentDb.Content = commentToUpdate.Content;

            var updatedComment = await commentRepo.Update(commentDb);
            var updatedCommentDto = updatedComment.ToCommentResponseDto();

            return ApiResultReturn.Ok(updatedCommentDto, "Comment updated.");
        }

        public async Task<ApiResult<CommentResponseDto>> Delete(int id)
        {
            var commentDb = await commentRepo.GetById(id);

            if (commentDb == null)
            {
                return ApiResultReturn.Fail<CommentResponseDto>([CommentNotFoundMsg], "Failed to delete comment.");
            }

            var deletedComment = await commentRepo.Delete(commentDb);
            var deletedCommentDto = deletedComment.ToCommentResponseDto();

            return ApiResultReturn.Ok(deletedCommentDto, "Comment deleted.");
        }

        public async Task<ApiResult<List<UserCommentResponseDto>>> GetByUserId(string userId)
        {
            var userDb = await userManager.FindByIdAsync(userId);

            if (userDb == null)
            {
                return ApiResultReturn.Fail<List<UserCommentResponseDto>>(["User not found."], "Failed to get comments.");
            }

            var commentsDb = await commentRepo.GetByUserId(userId);
            var commentsDto = commentsDb.Select(c => c.ToUserCommentResponseDto()).ToList();

            return ApiResultReturn.Ok(commentsDto);
        }

        public async Task<ApiResult<List<CommentResponseDto>>> GetByPostId(int postId)
        {
            var postDb = await postRepo.GetById(postId);

            if (postDb == null)
            {
                return ApiResultReturn.Fail<List<CommentResponseDto>>(["Post not found.", "Failed to get comments."]);
            }

            var commentsDb = await commentRepo.GetByPostId(postId);
            var commentsDto = commentsDb.Select(c => c.ToCommentResponseDto()).ToList();

            return ApiResultReturn.Ok(commentsDto);
        }
    }
}
