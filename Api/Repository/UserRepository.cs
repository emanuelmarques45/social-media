using Api.Data;
using Api.Dtos.User;
using Api.Interfaces.Repository;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository
{
    public class UserRepository(ApplicationDbContext _context) : IUserRepository
    {
        public async Task<User> CreateAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User?> DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return null;
            }

            var associatedPosts = await _context.Post.Where(p => p.UserId == user.Id).ToListAsync();
            var associatedLikes = await _context.Likes.Where(l => l.UserId == user.Id).ToListAsync();
            var associatedComments = await _context.Comment.Where(c => c.UserId == user.Id).ToListAsync();

            _context.Post.RemoveRange(associatedPosts);
            _context.Likes.RemoveRange(associatedLikes);
            _context.Comment.RemoveRange(associatedComments);

            _context.Users.Remove(user);

            await _context.SaveChangesAsync();

            return user;
        }

        public Task<List<User>> GetAllAsync()
        {
            return _context.Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User?> UpdateAsync(int id, UpdateUserRequestDto userDto)
        {
            var user = await GetByIdAsync(id);

            if (user == null)
            {
                return null;
            }

            user.Name = userDto.Name;
            user.Email = userDto.Email;
            user.Username = userDto.Username;

            await _context.SaveChangesAsync();

            return user;
        }
    }
}
