using Microsoft.EntityFrameworkCore;
using SocialMedia.Api.Data;
using SocialMedia.Api.Interfaces.Repository;
using SocialMedia.Api.Models;

namespace SocialMedia.Api.Repository
{
    public class CommentRepository(ApplicationDbContext context) : ICommentRepository
    {
        public async Task<CommentModel> Create(CommentModel commentToCreate)
        {
            await context.Comment.AddAsync(commentToCreate);
            await context.SaveChangesAsync();

            return commentToCreate;
        }

        public async Task<List<CommentModel>> GetAll()
        {
            return await context.Comment
                .ToListAsync();
        }

        public async Task<CommentModel?> GetById(int id)
        {
            return await context.Comment
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<CommentModel> Update(CommentModel commentToUpdate)
        {
            context.Comment.Update(commentToUpdate);
            await context.SaveChangesAsync();

            return commentToUpdate;
        }

        public async Task<CommentModel> Delete(CommentModel commentToDelete)
        {
            context.Comment.Remove(commentToDelete);
            await context.SaveChangesAsync();

            return commentToDelete;
        }
    }
}
