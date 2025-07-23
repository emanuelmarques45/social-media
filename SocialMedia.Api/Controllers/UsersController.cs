using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Shared.Dtos.User;
using SocialMedia.Shared.Helpers.Query;
using SocialMedia.Shared.Interfaces;
using SocialMedia.Shared.Mappers;
using SocialMedia.Shared.Models;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController(
        UserManager<UserModel> userManager,
        RoleManager<IdentityRole> roleManager,
        IAuthService authService
        ) : ControllerBase
    {
        [HttpPost("assign-role")]

        // [Authorize(Roles = "Admin")]
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

        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            if (await roleManager.RoleExistsAsync(roleName))
            {
                return StatusCode(409, "This role already exists!");
            }

            _ = await roleManager.CreateAsync(new IdentityRole(roleName));

            return Created();
        }

        [HttpGet]

        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll([FromQuery] UserQuery query)
        {
            var users = userManager.Users;

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

            users = users
                .Include(u => u.Posts)
                .Include(u => u.Likes)
                .Include(u => u.Comments)
                .Include(u => u.Followers)
                .Include(u => u.Followings)
                .Skip(query.SkipNumber)
                .Take(query.PageSize)
                .AsSingleQuery();

            var usersDto = await users.Select(u => u.ToGetUserResponseDto()).ToListAsync();

            return Ok(usersDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var currentUser = await authService.GetCurrentUser();

            if (currentUser?.Id != id)
            {
                return Unauthorized();
            }

            var user = await userManager.Users
                        .Include(u => u.Posts)
                        .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            var userDto = user.ToGetUserResponseDto();

            return Ok(userDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] UpdateUserRequestDto userDto)
        {
            var userDb = await userManager.FindByIdAsync(id);

            if (userDb == null)
            {
                return NotFound();
            }

            userDb.Name = userDto.Name;
            userDb.Email = userDto.Email;
            userDb.UserName = userDto.UserName;

            var updatedUser = await userManager.UpdateAsync(userDb);

            if (!updatedUser.Succeeded)
            {
                return StatusCode(500, updatedUser.Errors);
            }

            return Ok(userDb.ToGetUserResponseDto());
        }

        [HttpDelete("{id}")]

        // [Authorize(Roles = "Admin")]
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

        [HttpGet("{id}/posts")]
        public async Task<IActionResult> GetPosts([FromRoute] string id)
        {
            var user = await userManager.Users.Include(u => u.Posts)
                        .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user.Posts);
        }

        [HttpPost("upload-profile-picture")]
        public async Task<IActionResult> UploadProfilePicture(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            var currentUser = await authService.GetCurrentUser();

            if (currentUser == null || string.IsNullOrEmpty(currentUser.Id))
            {
                return Unauthorized();
            }

            var user = await userManager.FindByIdAsync(currentUser.Id);
            if (user == null)
            {
                return NotFound();
            }

            using var ms = new MemoryStream();
            await file.CopyToAsync(ms);
            user.ProfilePicture = ms.ToArray();
            user.ProfilePictureContentType = file.ContentType;

            _ = await userManager.UpdateAsync(user);

            return Ok();
        }

        [HttpGet("{id}/profile-picture")]
        public async Task<IActionResult> GetProfilePicture(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user == null || user.ProfilePicture == null)
            {
                return NotFound();
            }

            return File(user.ProfilePicture, user.ProfilePictureContentType ?? "application/octet-stream");
        }
    }
}