using Microsoft.AspNetCore.Identity;
using SocialMedia.Api.Repository.ChildComment;
using SocialMedia.Api.Repository.Comment;
using SocialMedia.Api.Repository.Likes;
using SocialMedia.Api.Repository.Post;
using SocialMedia.Lib.Dtos.Likes;
using SocialMedia.Lib.Helpers.ApiResult;
using SocialMedia.Lib.Interfaces;
using SocialMedia.Lib.Models;

namespace SocialMedia.Api.Services
{
    [Service(ServiceLifetime.Scoped)]
    public class LikeService(
        ILikeRepository likeRepository,
        IPostRepository postRepository,
        ICommentRepository commentRepository,
        IChildCommentRepository childCommentRepository,
        UserManager<UserModel> userManager) : IPostLikeService
    {
        public async Task<List<LikeResponseDto>> GetAll(LikeableType likeType) => await likeRepository.GetAll(likeType);

        public async Task<LikeResponseDto?> GetById(int id, LikeableType likeType) => await likeRepository.GetById(id, likeType);

        public async Task<ApiResult<LikeResponseDto>> ToggleLike(CreateLikeRequestDto likeToCreate)
        {
            var userDb = await userManager.FindByIdAsync(likeToCreate.UserId);
            if (userDb == null)
            {
                return ApiResultReturn.Fail<LikeResponseDto>(["User not found!"]);
            }

            switch (likeToCreate.Type)
            {
                case LikeableType.Post:
                    var postDb = await postRepository.GetById(likeToCreate.TargetId);
                    if (postDb == null)
                    {
                        return ApiResultReturn.Fail<LikeResponseDto>(["Post not found!"]);
                    }

                    break;

                case LikeableType.Comment:
                    var commentDb = await commentRepository.GetById(likeToCreate.TargetId);
                    if (commentDb == null)
                    {
                        return ApiResultReturn.Fail<LikeResponseDto>(["Comment not found!"]);
                    }

                    break;

                case LikeableType.ChildComment:
                    var childCommentDb = await childCommentRepository.GetById(likeToCreate.TargetId);
                    if (childCommentDb == null)
                    {
                        return ApiResultReturn.Fail<LikeResponseDto>(["Child comment not found!"]);
                    }

                    break;

                default:
                    return ApiResultReturn.Fail<LikeResponseDto>(["Invalid like type"]);
            }

            var alreadyExists = await likeRepository.Exists(likeToCreate);
            if (alreadyExists)
            {
                var deleted = await likeRepository.Delete(likeToCreate);
                if (!deleted)
                {
                    return ApiResultReturn.Fail<LikeResponseDto>(["Could not remove like!"]);
                }

                return ApiResultReturn.Ok<LikeResponseDto>(new(), "Like removed");
            }

            var createdLike = await likeRepository.Create(likeToCreate);
            return ApiResultReturn.Ok(createdLike, "Like added");
        }
    }
}
