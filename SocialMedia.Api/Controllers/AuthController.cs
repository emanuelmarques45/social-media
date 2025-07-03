using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Lib.Dtos.User;
using SocialMedia.Lib.Interfaces;
using SocialMedia.Lib.Models;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(UserManager<UserModel> userManager, IAuthService authService) : ControllerBase
    {
        [Authorize]
        [HttpGet("user-claims")]
        public IActionResult GetUserClaims()
        {
            var userClaims = User.Claims.Select(c => new { c.Type, c.Value }).ToList();

            return Ok(userClaims);
        }

        [HttpGet("current-user")]
        [Authorize]
        public async Task<IActionResult> GetCurrentUser()
        {
            var user = await authService.GetCurrentUser();

            if (user is null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerDto)
        {
            var result = await authService.Register(registerDto);

            if (!result.Success)
            {
                return StatusCode(500, new { result.Errors });
            }

            return CreatedAtAction(nameof(Register), new { id = result.Data?.UserName }, result.Data);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginDto)
        {
            if (string.IsNullOrEmpty(loginDto.Email) && string.IsNullOrEmpty(loginDto.UserName))
            {
                return BadRequest("Please provide an email or username!");
            }

            var response = await authService.Login(loginDto);

            if (response is null)
            {
                return Unauthorized("Username or password incorrects!");
            }

            return Ok(response);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await authService.Logout();
            return NoContent();
        }
    }
}
