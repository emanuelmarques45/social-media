using Microsoft.EntityFrameworkCore;
using SocialMedia.Shared.Data;
using SocialMedia.Shared.Dtos.Likes;
using SocialMedia.Shared.Mappers;
using SocialMedia.Shared.Models;

namespace SocialMedia.Api.Repository.Likes
{
    [Service(ServiceLifetime.Scoped)]
    public class LikeRepository(ApplicationDbContext context) : ILikeRepository
    {
        public async Task<LikeResponseDto> Create(CreateLikeRequestDto likeToCreate)
        {
            _ = new LikeResponseDto();

            LikeResponseDto? createdLike;
            switch (likeToCreate.Type)
            {
                case LikeableType.Post:
                    var postLike = new PostLikeModel { UserId = likeToCreate.UserId, PostId = likeToCreate.TargetId, CreatedAt = DateTime.UtcNow };
                    _ = context.PostLike.Add(postLike);
                    createdLike = postLike.ToPostLikeResponseDto();
                    break;

                case LikeableType.Comment:
                    var commentLike = new CommentLikeModel { UserId = likeToCreate.UserId, CommentId = likeToCreate.TargetId, CreatedAt = DateTime.UtcNow };
                    _ = context.CommentLike.Add(commentLike);
                    createdLike = commentLike.ToPostLikeResponseDto();
                    break;

                case LikeableType.ChildComment:
                    var childCommentLike = new ChildCommentLikeModel { UserId = likeToCreate.UserId, ChildCommentId = likeToCreate.TargetId, CreatedAt = DateTime.UtcNow };
                    _ = context.ChildCommentLike.Add(childCommentLike);
                    createdLike = childCommentLike.ToPostLikeResponseDto();
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(likeToCreate.Type), "Unsupported likeable type");
            }

            _ = await context.SaveChangesAsync();

            return createdLike;
        }

        public async Task<List<LikeResponseDto>> GetAll(LikeableType likeType)
        {
            return likeType switch
            {
                LikeableType.Post => await context.PostLike
                    .AsNoTracking()
                    .Include(l => l.User)
                    .Include(l => l.Post)
                    .Select(l => l.ToPostLikeResponseDto())
                    .ToListAsync(),

                LikeableType.Comment => await context.CommentLike
                    .AsNoTracking()
                    .Include(l => l.User)
                    .Include(l => l.Comment)
                    .Select(l => l.ToPostLikeResponseDto())
                    .ToListAsync(),

                LikeableType.ChildComment => await context.ChildCommentLike
                    .AsNoTracking()
                    .Include(l => l.User)
                    .Include(l => l.ChildComment)
                    .Select(l => l.ToPostLikeResponseDto())
                    .ToListAsync(),

                _ => throw new ArgumentOutOfRangeException(nameof(likeType), "Unsupported likeable type")
            };
        }

        public async Task<LikeResponseDto?> GetById(int id, LikeableType likeType)
        {
            return likeType switch
            {
                LikeableType.Post => (await context.PostLike
                    .Include(l => l.User)
                    .Include(l => l.Post)
                    .FirstOrDefaultAsync(p => p.Id == id))?.ToPostLikeResponseDto(),

                LikeableType.Comment => (await context.CommentLike
                    .Include(l => l.User)
                    .Include(l => l.Comment)
                    .FirstOrDefaultAsync(p => p.Id == id))?.ToPostLikeResponseDto(),

                LikeableType.ChildComment => (await context.ChildCommentLike
                    .Include(l => l.User)
                    .Include(l => l.ChildComment)
                    .FirstOrDefaultAsync(p => p.Id == id))?.ToPostLikeResponseDto(),

                _ => throw new ArgumentOutOfRangeException(nameof(likeType), "Unsupported likeable type")
            };
        }

        public Task<PostLikeModel> Update(PostLikeModel registerToUpdate) => throw new NotImplementedException();

        public async Task<PostLikeModel> Delete(PostLikeModel likeToDelete)
        {
            _ = context.PostLike.Remove(likeToDelete);
            _ = await context.SaveChangesAsync();

            return likeToDelete;
        }

        public async Task<bool> Exists(CreateLikeRequestDto like)
        {
            return like.Type switch
            {
                LikeableType.Post =>
                    await context.PostLike.AnyAsync(l => l.UserId == like.UserId && l.PostId == like.TargetId),

                LikeableType.Comment =>
                    await context.CommentLike.AnyAsync(l => l.UserId == like.UserId && l.CommentId == like.TargetId),

                LikeableType.ChildComment =>
                    await context.ChildCommentLike.AnyAsync(l => l.UserId == like.UserId && l.ChildCommentId == like.TargetId),

                _ => throw new ArgumentOutOfRangeException(nameof(like.Type), "Unsupported likeable type")
            };
        }

        public async Task<bool> Delete(CreateLikeRequestDto likeToDelete)
        {
            switch (likeToDelete.Type)
            {
                case LikeableType.Post:
                    var postLike = await context.PostLike.FirstOrDefaultAsync(l => l.UserId == likeToDelete.UserId && l.PostId == likeToDelete.TargetId);
                    if (postLike == null)
                    {
                        return false;
                    }

                    _ = context.PostLike.Remove(postLike);
                    break;

                case LikeableType.Comment:
                    var commentLike = await context.CommentLike.FirstOrDefaultAsync(l => l.UserId == likeToDelete.UserId && l.CommentId == likeToDelete.TargetId);
                    if (commentLike == null)
                    {
                        return false;
                    }

                    _ = context.CommentLike.Remove(commentLike);
                    break;

                case LikeableType.ChildComment:
                    var childCommentLike = await context.ChildCommentLike.FirstOrDefaultAsync(l => l.UserId == likeToDelete.UserId && l.ChildCommentId == likeToDelete.TargetId);
                    if (childCommentLike == null)
                    {
                        return false;
                    }

                    _ = context.ChildCommentLike.Remove(childCommentLike);
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(likeToDelete.Type), "Unsupported likeable type");
            }

            _ = await context.SaveChangesAsync();
            return true;
        }
    }
}
