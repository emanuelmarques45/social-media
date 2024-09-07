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
                CreatedAt = user.CreatedAt,
                Posts = user.Posts.Select(p => p.ToGetPostResponseDto()).ToList(),
                Likes = user.Likes.Select(l => l.ToGetLikeResponseDto()).ToList(),
                Comments = user.Comments.Select(c => c.ToGetCommentResponseDto()).ToList()
            };
        }

        public static UserModel ToUserDto(this CreateUserRequestDto userDto)
        {
            return new UserModel
            {
                Name = userDto.Name,
                Email = userDto.Email,
                Username = userDto.Username,
                Password = userDto.Password
            };
        }
    }
}
