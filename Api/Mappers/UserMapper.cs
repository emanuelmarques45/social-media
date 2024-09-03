using Api.Dtos.User;
using Api.Models;

namespace Api.Mappers
{
    public static class UserMapper
    {
        public static GetUserResponseDto ToGetUserResponseDto(this UserModel user)
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

        public static UserModel ToUserDto(this CreateUserRequestDto userRequestDto)
        {
            return new UserModel
            {
                Name = userRequestDto.Name,
                Email = userRequestDto.Email,
                Username = userRequestDto.Username,
                Password = userRequestDto.Password
            };
        }
    }
}
