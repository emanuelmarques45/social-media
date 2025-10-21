using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Shared.Dtos.User;
using SocialMedia.Shared.Helpers.ApiResult;
using SocialMedia.Shared.Interfaces;
using SocialMedia.Shared.Models;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        [HttpGet("user-claims")]
        [Authorize]
        public IActionResult GetUserClaims()
        {
            var userClaims = User.Claims.Select(c => new { c.Type, c.Value }).ToList();

            return Ok(userClaims);
        }

        [HttpGet("me")]
        [Authorize]
        public async Task<IActionResult> GetCurrentUser()
        {
            var user = await authService.GetCurrentUser();

            if (user == null)
            {
                return NotFound(ApiResultReturn.Fail<UserModel>(["User not found"], "Failed to retrieve current user"));
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
                return StatusCode(StatusCodes.Status500InternalServerError, new { result.Errors });
            }

            return CreatedAtAction(nameof(Register), new { id = result.Data?.UserName }, result.Data);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginDto)
        {
            if (string.IsNullOrWhiteSpace(loginDto.Email) && string.IsNullOrWhiteSpace(loginDto.UserName))
            {
                return BadRequest("Please provide an email or username!");
            }

            var response = await authService.Login(loginDto);

            if (!response.Success)
            {
                return Unauthorized(response);
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
