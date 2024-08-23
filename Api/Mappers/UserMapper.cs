using Api.Dtos.User;
using Api.Models;

namespace Api.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToUserDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Username = user.Username,
                Posts = user.Posts,
                Likes = user.Likes,
                Comments = user.Comments
            };
        }
    }
}
