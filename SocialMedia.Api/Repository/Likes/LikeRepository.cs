using Microsoft.EntityFrameworkCore;
using SocialMedia.Classes.Data;
using SocialMedia.Classes.Models;

namespace SocialMedia.Api.Repository.Likes
{
    [Service(ServiceLifetime.Scoped)]
    public class LikeRepository(ApplicationDbContext context) : ILikeRepository
    {
        public async Task<LikeModel> LikePost(LikeModel likeToCreate)
        {
            _ = await context.AppLike.AddAsync(likeToCreate);
            _ = await context.SaveChangesAsync();

            return likeToCreate;
        }

        public async Task<LikeModel> Create(LikeModel likeToCreate)
        {
            _ = await context.AppLike.AddAsync(likeToCreate);
            _ = await context.SaveChangesAsync();

            return likeToCreate;
        }

        public async Task<List<LikeModel>> GetAll()
        {
            return await context.AppLike.AsNoTracking()
                .Include(l => l.User)
                .Include(l => l.Post)
                .ToListAsync();
        }

        public async Task<LikeModel?> GetById(int id)
        {
            return await context.AppLike
                .Include(l => l.User)
                .Include(l => l.Post)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<LikeModel> Update(LikeModel likeToUpdate)
        {
            _ = context.AppLike.Update(likeToUpdate);
            _ = await context.SaveChangesAsync();

            return likeToUpdate;
        }

        public async Task<LikeModel> Delete(LikeModel likeToDelete)
        {
            _ = context.AppLike.Remove(likeToDelete);
            _ = await context.SaveChangesAsync();

            return likeToDelete;
        }
    }
}
