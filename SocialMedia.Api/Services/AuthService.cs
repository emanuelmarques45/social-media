using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SocialMedia.Shared.Dtos.User;
using SocialMedia.Shared.Helpers.ApiResult;
using SocialMedia.Shared.Interfaces;
using SocialMedia.Shared.Mappers;
using SocialMedia.Shared.Models;

namespace SocialMedia.Api.Services
{
    [Service(ServiceLifetime.Scoped)]
    public class AuthService : IAuthService
    {
        private readonly SymmetricSecurityKey _key;
        private readonly IConfiguration _config;
        private readonly UserManager<UserModel> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly SignInManager<UserModel> _signInManager;

        public AuthService(IConfiguration config, UserManager<UserModel> userManager, IHttpContextAccessor httpContextAccessor, SignInManager<UserModel> signInManager)
        {
            var signInKey = config["JWT:SignInKey"];

            if (string.IsNullOrEmpty(signInKey))
            {
                throw new ArgumentNullException("JWT:SignInKey", "JWT Sign-In Key is not set in the _configuration.");
            }

            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signInKey));
            _config = config;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _signInManager = signInManager;
        }

        public async Task<IEnumerable<Claim>> GetUserClaims(UserModel user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, user.UserName!),
                new(ClaimTypes.Email, user.Email!),
                new(ClaimTypes.GivenName, user.Name!),
            };

            claims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

            return claims;
        }

        public async Task<string> GenerateAccessToken(UserModel user)
        {
            var claims = await GetUserClaims(user);

            _ = await _userManager.RemoveClaimsAsync(user, claims);

            _ = await _userManager.AddClaimsAsync(user, claims);

            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _config["JWT:Issuer"],
                Audience = _config["JWT:Audience"],
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = credentials,
            };

            var handler = new JwtSecurityTokenHandler();

            var token = handler.CreateToken(tokenDescriptor);

            return handler.WriteToken(token);
        }

        public async Task<ApiResult<RegisterResponseDto>> Register(RegisterRequestDto registerDto)
        {
            var user = registerDto.ToUserModel();

            var createdUser = await _userManager.CreateAsync(user, registerDto.Password);

            if (!createdUser.Succeeded)
            {
                return ApiResultReturn.Fail<RegisterResponseDto>(createdUser.Errors.Select(e => e.Description));
            }

            var createdRole = await _userManager.AddToRoleAsync(user, "user");
            if (!createdRole.Succeeded)
            {
                return ApiResultReturn.Fail<RegisterResponseDto>(createdRole.Errors.Select(e => e.Description));
            }

            var response = user.ToRegisterResponseDto();
            return ApiResultReturn.Ok(response);
        }

        public async Task<LoginResponseDto?> Login(LoginRequestDto loginDto)
        {
            UserModel? userDb = default!;

            if (!string.IsNullOrEmpty(loginDto.Email))
            {
                userDb = await _userManager.FindByEmailAsync(loginDto.Email);
            } else if (!string.IsNullOrEmpty(loginDto.UserName))
            {
                userDb = await _userManager.FindByNameAsync(loginDto.UserName);
            }

            if (userDb is null || !(await _signInManager.CheckPasswordSignInAsync(userDb, loginDto.Password, false)).Succeeded)
            {
                return null;
            }

            var token = await GenerateAccessToken(userDb);
            var response = userDb.ToLoginResponseDto(token);

            return response;
        }

        public async Task Logout() => await _signInManager.SignOutAsync();

        public async Task<UserModel?> GetCurrentUser()
        {
            var claims = _httpContextAccessor.HttpContext!.User.Claims;

            var email = claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var username = claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value;

            var user = await _userManager.FindByNameAsync(username ?? string.Empty) ?? await _userManager.FindByEmailAsync(email ?? string.Empty);

            return user;
        }
    }
}
