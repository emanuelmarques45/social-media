using Api.Data;
using Api.Dtos.User;
using Api.Interfaces.Repository;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository
{
    public class UserRepository(ApplicationDbContext _context) : IUserRepository
    {
        public async Task<UserModel> CreateAsync(UserModel user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<List<UserModel>> GetAllAsync()
        {
            return await _context.Users.Include(u => u.Posts).ThenInclude(p => p.Likes).ToListAsync();
        }

        public async Task<UserModel?> GetByIdAsync(int id)
        {
            return await _context.Users.Include(u => u.Posts).FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<UserModel?> UpdateAsync(int id, UpdateUserRequestDto userRequestDto)
        {
            var userDb = await GetByIdAsync(id);

            if (userDb == null)
            {
                return null;
            }

            userDb.Name = userRequestDto.Name;
            userDb.Email = userRequestDto.Email;
            userDb.Username = userRequestDto.Username;

            await _context.SaveChangesAsync();

            return userDb;
        }

        public async Task<UserModel?> DeleteAsync(int id)
        {
            var userDb = await GetByIdAsync(id);

            if (userDb == null)
            {
                return null;
            }

            var associatedPosts = await _context.Post.Where(p => p.UserId == userDb.Id).ToListAsync();
            var associatedLikes = await _context.Likes.Where(l => l.UserId == userDb.Id).ToListAsync();
            var associatedComments = await _context.Comment.Where(c => c.UserId == userDb.Id).ToListAsync();

            _context.Post.RemoveRange(associatedPosts);
            _context.Likes.RemoveRange(associatedLikes);
            _context.Comment.RemoveRange(associatedComments);

            _context.Users.Remove(userDb);

            await _context.SaveChangesAsync();

            return userDb;
        }
    }
}
