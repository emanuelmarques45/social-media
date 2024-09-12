//using Api.Data;
//using Api.Dtos.Account;
//using Api.Helpers.Query;
//using Api.Interfaces.Repository;
//using Api.Models;
//using Microsoft.EntityFrameworkCore;

//namespace Api.Repository
//{
//    public class UserRepository(ApplicationDbContext _context) : IUserRepository
//    {
//        public async Task<UserModel> CreateAsync(UserModel user)
//        {
//            await _context.Users.AddAsync(user);
//            await _context.SaveChangesAsync();

//            return user;
//        }

//        public async Task<List<UserModel>> GetAllAsync(UserQuery query)
//        {
//            var users = _context.Users.Include(u => u.Posts).Include(u => u.Likes).Include(u => u.Comments).AsQueryable();

//            if (!string.IsNullOrEmpty(query.Name))
//            {
//                users = users.Where(u => u.Name.Contains(query.Name));
//            }

//            if (!string.IsNullOrEmpty(query.Email))
//            {
//                users = users.Where(u => u.Email.Contains(query.Email));
//            }

//            if (!string.IsNullOrEmpty(query.UserName))
//            {
//                users = users.Where(u => u.UserName.Contains(query.UserName));
//            }

//            if (!string.IsNullOrEmpty(query.SortBy))
//            {
//                if (query.SortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
//                {
//                    users = query.IsDescending ? users.OrderByDescending(u => u.Name) : users.OrderBy(u => u.Name);
//                }
//            }

//            users = query.IsDescending ? users.OrderByDescending(u => u.Id) : users.OrderBy(u => u.Id);

//            users = users.Skip(query.SkipNumber).Take(query.PageSize);

//            return await users.ToListAsync();
//        }

//        public async Task<UserModel?> GetByIdAsync(int id)
//        {
//            return await _context.Users.Include(u => u.Posts).Include(u => u.Likes).Include(u => u.Comments).FirstOrDefaultAsync(u => u.Id == id);
//        }

//        public async Task<UserModel?> UpdateAsync(int id, UpdateUserRequestDto userDto)
//        {
//            var userDb = await GetByIdAsync(id);

//            if (userDb == null)
//            {
//                return null;
//            }

//            userDb.Name = userDto.Name;
//            userDb.Email = userDto.Email;
//            userDb.UserName = userDto.UserName;

//            await _context.SaveChangesAsync();

//            return userDb;
//        }

//        public async Task<UserModel?> DeleteAsync(int id)
//        {
//            var userDb = await GetByIdAsync(id);

//            if (userDb == null)
//            {
//                return null;
//            }

//            var associatedPosts = await _context.Post.Where(p => p.UserId == userDb.Id).ToListAsync();
//            var associatedLikes = await _context.Likes.Where(l => l.UserId == userDb.Id).ToListAsync();
//            var associatedComments = await _context.Comment.Where(c => c.UserId == userDb.Id).ToListAsync();

//            _context.Post.RemoveRange(associatedPosts);
//            _context.Likes.RemoveRange(associatedLikes);
//            _context.Comment.RemoveRange(associatedComments);

//            _context.Users.Remove(userDb);

//            await _context.SaveChangesAsync();

//            return userDb;
//        }
//    }
//}
