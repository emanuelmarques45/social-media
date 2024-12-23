using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Api.Services.Auth;
using SocialMedia.Classes.Dtos.Account;
using SocialMedia.Classes.Helpers.Query;
using SocialMedia.Classes.Mappers;
using SocialMedia.Classes.Models;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountsController(
        UserManager<UserModel> userManager,
        SignInManager<UserModel> signInManager,
        IAuthService authService,
        RoleManager<IdentityRole> roleManager) : ControllerBase
    {
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerDto)
        {
            var user = registerDto.ToUserModel();

            var createdUser = await userManager.CreateAsync(user, registerDto.Password);

            if (!createdUser.Succeeded)
            {
                return StatusCode(500, createdUser.Errors);
            }

            var createdRole = await userManager.AddToRoleAsync(user, "user");

            if (!createdRole.Succeeded)
            {
                return StatusCode(500, createdRole.Errors);
            }

            var addToRole = await AssignRole(user.Id, "User");
            var token = await authService.GenerateAccessToken(user);
            var response = user.ToAuthResponseDto(token);

            return CreatedAtAction(nameof(GetUserById), new { user.Id }, user.ToGetAccountResponseDto());
        }

        [HttpPost("assign-role")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AssignRole(string id, string roleName)
        {
            var userDb = await userManager.FindByIdAsync(id);

            if (userDb == null)
            {
                return NotFound();
            }

            var createdRole = await userManager.AddToRoleAsync(userDb, roleName);

            if (!createdRole.Succeeded)
            {
                return StatusCode(500, createdRole.Errors);
            }

            return Ok("Role added successfully!");
        }

        [HttpPost("create-role")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            if (await roleManager.RoleExistsAsync(roleName))
            {
                return StatusCode(409, "This role already exists!");
            }

            _ = await roleManager.CreateAsync(new IdentityRole(roleName));

            return Created();
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
                userDb = await userManager.FindByEmailAsync(loginDto.Email);
            } else if (!string.IsNullOrEmpty(loginDto.UserName))
            {
                userDb = await userManager.FindByNameAsync(loginDto.UserName);
            }

            if (userDb == null || !(await signInManager.CheckPasswordSignInAsync(userDb, loginDto.Password, false)).Succeeded)
            {
                return Unauthorized("Username or password incorrects!");
            }

            var token = await authService.GenerateAccessToken(userDb);
            var response = userDb.ToAuthResponseDto(token);

            return Ok(response);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUsers([FromQuery] UserQuery query)
        {
            var users = userManager.Users
                    .AsQueryable();

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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] string id)
        {
            var user = await userManager.Users
                        .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            var userDto = user.ToGetAccountResponseDto();

            return Ok(userDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] UpdateAccountRequestDto userDto)
        {
            var userDb = await userManager.FindByIdAsync(id);

            if (userDb == null)
            {
                return NotFound();
            }

            userDb.Name = userDto.Name;
            userDb.Email = userDto.Email;
            userDb.UserName = userDto.UserName;
            userDb.PasswordHash = userDto.Password;

            var updatedUser = await userManager.UpdateAsync(userDb);

            if (!updatedUser.Succeeded)
            {
                return StatusCode(500, updatedUser.Errors);
            }

            return Ok(userDb.ToGetAccountResponseDto());
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var userDb = await userManager.FindByIdAsync(id);

            if (userDb == null)
            {
                return NotFound();
            }

            var deletedUser = await userManager.DeleteAsync(userDb);

            if (!deletedUser.Succeeded)
            {
                return StatusCode(500, deletedUser.Errors);
            }

            return NoContent();
        }
    }
}