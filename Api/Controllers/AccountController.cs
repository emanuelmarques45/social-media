using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Api.Dtos.Account;
using SocialMedia.Api.Helpers.Query;
using SocialMedia.Api.Mappers;
using SocialMedia.Api.Models;
using SocialMedia.Api.Services;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AccountController(UserManager<UserModel> _userManager, SignInManager<UserModel> _signInManager, AuthService _tokenService) : ControllerBase
    {
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerDto)
        {
            var user = registerDto.ToUserModel();

            var createdUser = await _userManager.CreateAsync(user, registerDto.Password);

            if (!createdUser.Succeeded)
            {
                return StatusCode(500, createdUser.Errors);
            }

            var createdRole = await _userManager.AddToRoleAsync(user, "user");

            if (!createdRole.Succeeded)
            {
                return StatusCode(500, createdRole.Errors);
            }

            var addToRole = AddToRole(user.Id, "User");
            var token = _tokenService.GenerateAccessToken(user);
            var response = user.ToAuthResponseDto(token);

            return CreatedAtAction(nameof(GetUserById), new { user.Id }, user.ToGetAccountResponseDto());
        }

        [HttpPost("addRole")]
        public async Task<IActionResult> AddToRole(string userId, string roleName)
        {
            var userDb = await _userManager.FindByIdAsync(userId);

            if (userDb == null)
            {
                return NotFound();
            }

            var createdRole = await _userManager.AddToRoleAsync(userDb, roleName);

            if (!createdRole.Succeeded)
            {
                return StatusCode(500, createdRole.Errors);
            }

            return Ok("Role added successfully!");
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginDto)
        {
            if (string.IsNullOrEmpty(loginDto.Email) && string.IsNullOrEmpty(loginDto.UserName))
            {
                return BadRequest("Please provide an email or username!");
            }

            UserModel? userDb = null;

            if (!string.IsNullOrEmpty(loginDto.Email))
            {
                userDb = await _userManager.FindByEmailAsync(loginDto.Email);
            } else if (!string.IsNullOrEmpty(loginDto.UserName))
            {
                userDb = await _userManager.FindByNameAsync(loginDto.UserName);
            }

            if (userDb == null || !(await _signInManager.CheckPasswordSignInAsync(userDb, loginDto.Password, false)).Succeeded)
            {
                return Unauthorized("Username or password incorrects!");
            }

            var token = _tokenService.GenerateAccessToken(userDb);
            var response = userDb.ToAuthResponseDto(token);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers([FromQuery] UserQuery query)
        {
            var users = _userManager.Users.Include(u => u.Posts).AsQueryable();

            if (!string.IsNullOrEmpty(query.Name))
            {
                users = users.Where(u => u.Name.Contains(query.Name));
            }

            if (!string.IsNullOrEmpty(query.Email))
            {
                users = users.Where(u => u.Email.Contains(query.Email));
            }

            if (!string.IsNullOrEmpty(query.UserName))
            {
                users = users.Where(u => u.UserName.Contains(query.UserName));
            }

            if (!string.IsNullOrEmpty(query.SortBy))
            {
                if (query.SortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    users = query.IsDescending ? users.OrderByDescending(u => u.Name) : users.OrderBy(u => u.Name);
                }
                if (query.SortBy.Equals("UserName", StringComparison.OrdinalIgnoreCase))
                {
                    users = query.IsDescending ? users.OrderByDescending(u => u.UserName) : users.OrderBy(u => u.UserName);
                }
            }

            users = users.Skip(query.SkipNumber).Take(query.PageSize).AsSingleQuery();

            var usersDto = await users.Select(u => u.ToGetAccountResponseDto()).ToListAsync();

            return Ok(usersDto);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById([FromRoute] string userId)
        {
            var user = await _userManager.Users.Include(u => u.Posts).FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                return NotFound();
            }

            var userDto = user.ToGetAccountResponseDto();

            return Ok(userDto);
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> Update([FromRoute] string userId, [FromBody] UpdateAccountRequestDto userDto)
        {
            var userDb = await _userManager.FindByIdAsync(userId);

            if (userDb == null)
            {
                return NotFound();
            }

            userDb.Name = userDto.Name;
            userDb.Email = userDto.Email;
            userDb.UserName = userDto.UserName;
            userDb.PasswordHash = userDto.Password;

            var updatedUser = await _userManager.UpdateAsync(userDb);

            if (!updatedUser.Succeeded)
            {
                return StatusCode(500, updatedUser.Errors);
            }

            return Ok(userDb.ToGetAccountResponseDto());
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete([FromRoute] string userId)
        {
            var userDb = await _userManager.FindByIdAsync(userId);

            if (userDb == null)
            {
                return NotFound();
            }

            var deletedUser = await _userManager.DeleteAsync(userDb);

            if (!deletedUser.Succeeded)
            {
                return StatusCode(500, deletedUser.Errors);
            }

            return NoContent();
        }
    }
}