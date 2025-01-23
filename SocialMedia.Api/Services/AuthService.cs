using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SocialMedia.Classes.Dtos.User;
using SocialMedia.Classes.Interfaces;
using SocialMedia.Classes.Mappers;
using SocialMedia.Classes.Models;

namespace SocialMedia.Api.Services
{
    [Service(ServiceLifetime.Scoped)]
    public class AuthService(IConfiguration config, UserManager<UserModel> userManager, IHttpContextAccessor httpContext, SignInManager<UserModel> signInManager) : IAuthService
    {
        private readonly SymmetricSecurityKey _key = new(Encoding.UTF8.GetBytes(config["JWT:SignInKey"]!));

        public async Task<IEnumerable<Claim>> GetUserClaims(UserModel user)
        {
            var userRoles = await userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, user.Name!),
                new(ClaimTypes.Email, user.Email!),
                new(ClaimTypes.GivenName, user.UserName!),
            };

            claims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

            return claims;
        }

        public async Task<string> GenerateAccessToken(UserModel user)
        {
            var claims = await GetUserClaims(user);

            _ = await userManager.RemoveClaimsAsync(user, claims);

            _ = await userManager.AddClaimsAsync(user, claims);

            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = config["JWT:Issuer"],
                Audience = config["JWT:Audience"],
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = credentials,
            };

            var handler = new JwtSecurityTokenHandler();

            var token = handler.CreateToken(tokenDescriptor);

            return handler.WriteToken(token);
        }

        public async Task<AuthResponseDto?> Login(LoginRequestDto loginDto)
        {
            UserModel? userDb = default!;

            if (!string.IsNullOrEmpty(loginDto.Email))
            {
                userDb = await userManager.FindByEmailAsync(loginDto.Email);
            } else if (!string.IsNullOrEmpty(loginDto.UserName))
            {
                userDb = await userManager.FindByNameAsync(loginDto.UserName);
            }

            if (userDb is null || !(await signInManager.CheckPasswordSignInAsync(userDb, loginDto.Password, false)).Succeeded)
            {
                return null;
            }

            var token = await GenerateAccessToken(userDb);
            var response = userDb.ToAuthResponseDto(token);

            return response;
        }

        public async Task<UserModel?> GetCurrentUser()
        {
            if (httpContext.HttpContext!.User.Identity?.IsAuthenticated == true)
            {
                var claims = httpContext.HttpContext!.User.Claims;

                var email = claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
                var username = claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value;

                var user = await userManager.FindByNameAsync(username ?? string.Empty) ?? await userManager.FindByEmailAsync(email ?? string.Empty);

                return user;
            }

            return null;
        }
    }
}
