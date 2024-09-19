using Microsoft.IdentityModel.Tokens;
using SocialMedia.Api.Interfaces.Services;
using SocialMedia.Api.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SocialMedia.Api.Services
{
    public class AuthService(IConfiguration _config) : IAuthService
    {
        private SymmetricSecurityKey _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SignInKey"]));

        public string GenerateAccessToken(UserModel user)
        {

            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, user.Name),
                new(ClaimTypes.Email, user.Email),
                new(ClaimTypes.GivenName, user.UserName),
            };


            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _config["JWT:Issuer"],
                Audience = _config["JWT:Audience"],
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = credentials
            };

            var handler = new JwtSecurityTokenHandler();

            var token = handler.CreateToken(tokenDescriptor);

            return handler.WriteToken(token);
        }
    }
}
