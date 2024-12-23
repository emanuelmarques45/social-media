using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SocialMedia.Classes.Models;

namespace SocialMedia.Api.Services.Auth
{
    [Service(ServiceLifetime.Scoped)]
    public class AuthService(IConfiguration config, UserManager<UserModel> userManager) : IAuthService
    {
        private readonly SymmetricSecurityKey _key = new(Encoding.UTF8.GetBytes(config["JWT:SignInKey"]));

        public async Task<string> GenerateAccessToken(UserModel user)
        {
            var userRoles = await userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, user.Name),
                new(ClaimTypes.Email, user.Email),
                new(ClaimTypes.GivenName, user.UserName),
            };

            claims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

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
    }
}
