using Api.Dtos.Account;
using Api.Mappers;
using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(UserManager<UserModel> _userManager, TokenService _tokenService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerDto)
        {
            try
            {
                var user = registerDto.ToUserModel();

                var newUser = await _userManager.CreateAsync(user, user.Password);

                if (!newUser.Succeeded)
                {
                    return StatusCode(500, newUser.Errors);
                }

                var createdRole = await _userManager.AddToRoleAsync(user, "user");

                if (!createdRole.Succeeded)
                {
                    return StatusCode(500, createdRole.Errors);
                }

                _tokenService.GenerateAccessToken(user);

                return Ok(new RegisterResponseDto
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    Token = _tokenService.GenerateAccessToken(user)
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
                throw;
            }
        }
    }
}
