using Api.Dtos.User;
using Api.Models;

namespace Api.Mappers
{
    public static class UserMapper
    {
        public static GetUserResponseDto ToGetUserResponseDto(this User user)
        {
            return new GetUserResponseDto
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

        public static User ToCreateUserRequestDto(this CreateUserRequestDto userRequestDto)
        {
            return new User
            {
                Name = userRequestDto.Name,
                Email = userRequestDto.Email,
                Username = userRequestDto.Username,
                Password = userRequestDto.Password
            };
        }
    }
}
