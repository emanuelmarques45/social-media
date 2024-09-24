using SocialMedia.Api.Dtos.Account;
using SocialMedia.Api.Models;

namespace SocialMedia.Api.Mappers
{
    public static class AccountMapper
    {
        public static AccountResponseDto ToGetAccountResponseDto(this UserModel user)
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

        public static RelatedAccountResponseDto ToGetRelatedAccountResponseDto(this UserModel user)
        {
            return new RelatedAccountResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                UserName = user.UserName,
            };
        }

        public static AuthResponseDto ToAuthResponseDto(this UserModel user, string token)
        {
            return new AuthResponseDto
            {
                Name = user.Name,
                Email = user.Email,
                UserName = user.UserName,
                Token = token
            };
        }

        public static UserModel ToUserModel(this RegisterRequestDto registerDto)
        {
            return new UserModel
            {
                Name = registerDto.Name,
                Email = registerDto.Email,
                UserName = registerDto.UserName,
            };
        }
    }
}
