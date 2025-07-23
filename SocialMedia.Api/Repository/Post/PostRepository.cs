using Microsoft.EntityFrameworkCore;
using SocialMedia.Shared.Data;
using SocialMedia.Shared.Models;

namespace SocialMedia.Api.Repository.Post
{
    [Service(ServiceLifetime.Scoped)]
    public class PostRepository(ApplicationDbContext context, IDbContextFactory<ApplicationDbContext> contextFactory) : IPostRepository
    {
        public async Task<PostModel> Create(PostModel postToCreate)
        {
            _ = await context.Post.AddAsync(postToCreate);
            _ = await context.SaveChangesAsync();

            return postToCreate;
        }

        public async Task<List<PostModel>> GetAll()
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            return await context.Post.AsNoTracking()
                .Include(p => p.User)
                .Include(p => p.Likes)
                .ToListAsync();
        }

        public async Task<PostModel?> GetById(int id)
        {
            return await context.Post
                .Include(p => p.User)
                .Include(p => p.Comments)
                .Include(p => p.Likes)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<PostModel> Update(PostModel postToUpdate)
        {
            _ = context.Post.Update(postToUpdate);
            _ = await context.SaveChangesAsync();

            return postToUpdate;
        }

        public async Task<PostModel> Delete(PostModel postToDelete)
        {
            _ = context.Post.Remove(postToDelete);
            _ = await context.SaveChangesAsync();

            return postToDelete;
        }

        public async Task<List<PostModel>> GetByUserId(string userId) => await context.Post.Where(p => p.UserId == userId).ToListAsync();
    }
}
