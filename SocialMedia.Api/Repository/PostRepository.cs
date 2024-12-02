using Microsoft.EntityFrameworkCore;
using SocialMedia.Api.Data;
using SocialMedia.Api.Interfaces.Repository;
using SocialMedia.Api.Models;

namespace SocialMedia.Api.Repository
{
    public class PostRepository(ApplicationDbContext context) : IPostRepository
    {
        public async Task<PostModel> Create(PostModel postToCreate)
        {
            _ = await context.Post.AddAsync(postToCreate);
            _ = await context.SaveChangesAsync();

            return postToCreate;
        }

        public async Task<List<PostModel>> GetAll()
        {
            return await context.Post
                .Include(p => p.User)
                .Include(p => p.Comments)
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
    }
}
