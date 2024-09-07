using Api.Data;
using Api.Dtos.Comment;
using Api.Interfaces.Repository;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository
{
    public class CommentRepository(ApplicationDbContext _context) : ICommentRepository
    {
        public async Task<CommentModel> CreateAsync(CommentModel comment)
        {
            await _context.Comment.AddAsync(comment);
            await _context.SaveChangesAsync();

            return comment;
        }

        public async Task<List<CommentModel>> GetAllAsync()
        {
            return await _context.Comment.ToListAsync();
        }

        public async Task<CommentModel?> GetByIdAsync([FromRoute] int id)
        {
            return await _context.Comment.FindAsync(id);
        }

        public async Task<CommentModel?> UpdateAsync([FromRoute] int id, UpdateCommentRequestDto commentDto)
        {
            var commentDb = await GetByIdAsync(id);

            if (commentDb == null)
            {
                return null;
            }

            commentDb.Content = commentDto.Content;

            await _context.SaveChangesAsync();

            return commentDb;
        }

        public async Task<CommentModel?> DeleteAsync([FromRoute] int id)
        {
            var commentDb = await GetByIdAsync(id);

            if (commentDb == null)
            {
                return null;
            }

            _context.Comment.Remove(commentDb);

            await _context.SaveChangesAsync();

            return commentDb;
        }
    }
}
