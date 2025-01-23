using Microsoft.EntityFrameworkCore;
using SocialMedia.Classes.Data;
using SocialMedia.Classes.Models;

namespace SocialMedia.Api.Repository.ChildComment
{
    [Service(ServiceLifetime.Scoped)]
    public class ChildCommentRepository(ApplicationDbContext context) : IChildCommentRepository
    {
        public async Task<ChildCommentModel> Create(ChildCommentModel commentToCreate)
        {
            _ = await context.ChildComment.AddAsync(commentToCreate);
            _ = await context.SaveChangesAsync();

            return commentToCreate;
        }

        public async Task<List<ChildCommentModel>> GetAll()
        {
            return await context.ChildComment
                .Include(c => c.User)
                .ToListAsync();
        }

        public async Task<ChildCommentModel?> GetById(int id)
        {
            return await context.ChildComment
                .Include(c => c.User)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<ChildCommentModel> Update(ChildCommentModel commentToUpdate)
        {
            _ = context.ChildComment.Update(commentToUpdate);
            _ = await context.SaveChangesAsync();

            return commentToUpdate;
        }

        public async Task<ChildCommentModel> Delete(ChildCommentModel childCommentToDelete)
        {
            _ = context.ChildComment.Remove(childCommentToDelete);
            _ = await context.SaveChangesAsync();

            return childCommentToDelete;
        }
    }
}
