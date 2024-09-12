using Api.Dtos.Account;
using Api.Models;

namespace Api.Mappers
{
    public static class AccountMapper
    {
        public static AccountResponseDto ToAccountResponseDto(this UserModel user)
        {
            return new AccountResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed,
                UserName = user.UserName,
                CreatedAt = user.CreatedAt,
                Posts = user.Posts.Select(p => p.ToGetPostResponseDto()).ToList(),
                Likes = user.Likes.Select(l => l.ToGetLikeResponseDto()).ToList(),
                Comments = user.Comments.Select(c => c.ToGetCommentResponseDto()).ToList()
            };
        }

        public static UserModel ToUserModel(this RegisterRequestDto registerDto)
        {
            return new UserModel
            {
                Name = registerDto.Name,
                Email = registerDto.Email,
                UserName = registerDto.UserName,
                Password = registerDto.Password
            };
        }
    }
}
