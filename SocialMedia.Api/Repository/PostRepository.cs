using Microsoft.EntityFrameworkCore;
using SocialMedia.Api.Data;
using SocialMedia.Api.Interfaces.Repository;
using SocialMedia.Api.Models;

namespace SocialMedia.Api.Repository
{
    public class PostRepository(ApplicationDbContext _context) : IPostRepository
    {
        public async Task<PostModel> Create(PostModel postToCreate)
        {
            await _context.Post.AddAsync(postToCreate);
            await _context.SaveChangesAsync();

            return postToCreate;
        }

        public async Task<List<PostModel>> GetAll()
        {
            return await _context.Post
                .Include(p => p.User)
                .Include(p => p.Likes)
                .Include(p => p.Comments.Where(c => c.ParentId == null))
                .ToListAsync();
        }

        public async Task<PostModel?> GetById(int id)
        {
            return await _context.Post
                .Include(p => p.User)
                .Include(p => p.Likes)
                .Include(p => p.Comments.Where(c => c.ParentId == null))
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<PostModel> Update(PostModel postToUpdate)
        {
            _context.Post.Update(postToUpdate);
            await _context.SaveChangesAsync();

            return postToUpdate;
        }

        public async Task<PostModel> Delete(PostModel postToDelete)
        {
            _context.Post.Remove(postToDelete);
            await _context.SaveChangesAsync();

            return postToDelete;
        }
    }
}
