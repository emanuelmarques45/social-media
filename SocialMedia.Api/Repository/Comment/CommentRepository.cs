﻿using Microsoft.EntityFrameworkCore;
using SocialMedia.Classes.Data;
using SocialMedia.Classes.Models;

namespace SocialMedia.Api.Repository.Comment
{
    [Service(ServiceLifetime.Scoped)]
    public class CommentRepository(ApplicationDbContext context) : ICommentRepository
    {
        public async Task<CommentModel> Create(CommentModel commentToCreate)
        {
            _ = await context.Comment.AddAsync(commentToCreate);
            _ = await context.SaveChangesAsync();

            return commentToCreate;
        }

        public async Task<List<CommentModel>> GetAll()
        {
            return await context.Comment
                .Include(c => c.User)
                .Include(c => c.ChildComments)
                .ToListAsync();
        }

        public async Task<CommentModel?> GetById(int id)
        {
            return await context.Comment
                .Include(c => c.User)
                .Include(c => c.ChildComments)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<CommentModel> Update(CommentModel commentToUpdate)
        {
            _ = context.Comment.Update(commentToUpdate);
            _ = await context.SaveChangesAsync();

            return commentToUpdate;
        }

        public async Task<CommentModel> Delete(CommentModel commentToDelete)
        {
            context.ChildComment.RemoveRange(commentToDelete.ChildComments);
            _ = context.Comment.Remove(commentToDelete);
            _ = await context.SaveChangesAsync();

            return commentToDelete;
        }
    }
}
