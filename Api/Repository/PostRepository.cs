using Api.Data;
using Api.Dtos.Post;
using Api.Interfaces.Repository;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository
{
    public class PostRepository(ApplicationDbContext _context) : IPostRepository
    {
        public async Task<PostModel> CreateAsync(PostModel post)
        {
            await _context.Post.AddAsync(post);
            await _context.SaveChangesAsync();

            return post;
        }

        public async Task<List<PostModel>> GetAllAsync()
        {
            return await _context.Post.Include(p => p.Likes).Include(p => p.Comments).ToListAsync();
        }

        public async Task<PostModel?> GetByIdAsync(int id)
        {
            return await _context.Post.Include(p => p.Likes).Include(p => p.Comments).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<PostModel?> UpdateAsync(int id, UpdatePostRequestDto postDto)
        {
            var postDb = await GetByIdAsync(id);

            if (postDb == null)
            {
                return null;
            }

            postDb.Content = postDto.Content;

            await _context.SaveChangesAsync();

            return postDb;
        }

        public async Task<PostModel?> DeleteAsync(int id)
        {
            var post = await GetByIdAsync(id);

            if (post == null)
            {
                return null;
            }

            _context.Post.Remove(post);

            await _context.SaveChangesAsync();

            return post;
        }
    }
}
