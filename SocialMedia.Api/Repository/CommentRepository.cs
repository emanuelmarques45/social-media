using Microsoft.EntityFrameworkCore;
using SocialMedia.Api.Data;
using SocialMedia.Api.Interfaces.Repository;
using SocialMedia.Api.Models;

namespace SocialMedia.Api.Repository
{
    public class CommentRepository(ApplicationDbContext _context) : ICommentRepository
    {
        public async Task<CommentModel> Create(CommentModel commentToCreate)
        {
            await _context.Comment.AddAsync(commentToCreate);
            await _context.SaveChangesAsync();

            return commentToCreate;
        }

        public async Task<List<CommentModel>> GetAll()
        {
            return await _context.Comment
                .Include(c => c.User)
                .ToListAsync();
        }

        public async Task<CommentModel?> GetById(int id)
        {
            return await _context.Comment
                .Include(c => c.User)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<CommentModel> Update(CommentModel commentToUpdate)
        {
            _context.Comment.Update(commentToUpdate);
            await _context.SaveChangesAsync();

            return commentToUpdate;
        }

        public async Task<CommentModel> Delete(CommentModel commentToDelete)
        {
            _context.Comment.Remove(commentToDelete);
            await _context.SaveChangesAsync();

            return commentToDelete;
        }
    }
}
