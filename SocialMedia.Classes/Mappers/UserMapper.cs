using SocialMedia.Classes.Dtos.User;
using SocialMedia.Classes.Models;

namespace SocialMedia.Classes.Mappers
{
    public static class UserMapper
    {
        public static UserResponseDto ToGetUserResponseDto(this UserModel user)
        {
            return new UserResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed,
                UserName = user.UserName,
                CreatedAt = user.CreatedAt,
                Posts = user.Posts.Select(p => p.ToGetPostResponseDto()).ToList(),
                Likes = user.Likes.Select(l => l.ToGetLikeResponseDto()).ToList(),
                Comments = user.Comments.Select(c => c.ToGetCommentResponseDto()).ToList(),
                Followers = user.Followers.Select(f => f.ToGetRelatedUserResponseDto()).ToList(),
                Followings = user.Followings.Select(f => f.ToGetRelatedUserResponseDto()).ToList(),
            };
        }

        public static RelatedUserResponseDto ToGetRelatedUserResponseDto(this UserModel user)
        {
            return new RelatedUserResponseDto
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
                Token = token,
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
