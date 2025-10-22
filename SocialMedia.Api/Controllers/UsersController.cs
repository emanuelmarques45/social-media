using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Shared.Dtos.User;
using SocialMedia.Shared.Helpers.ApiResult;
using SocialMedia.Shared.Helpers.Query;
using SocialMedia.Shared.Interfaces;
using SocialMedia.Shared.Mappers;
using SocialMedia.Shared.Models;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]
    public class UsersController(
        UserManager<UserModel> userManager,
        RoleManager<IdentityRole> roleManager,
        IAuthService authService,
        IPostService postService,
        ICommentService commentService
        ) : ControllerBase
    {
        private string UserNotFoundMsg => $"{GetType().Name.Replace("Controller", string.Empty)[..^1]} not found.";

        [HttpPost("assign-role")]

        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AssignRole(string id, string roleName)
        {
            var userDb = await userManager.FindByIdAsync(id);

            if (userDb == null)
            {
                return NotFound(ApiResultReturn.Fail([UserNotFoundMsg], "Failed to assign role"));
            }

            var createdRole = await userManager.AddToRoleAsync(userDb, roleName);

            if (!createdRole.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ApiResultReturn.Fail(createdRole.Errors.Select(e => e.Description), "Failed to assign role"));
            }

            return Ok(ApiResultReturn.Ok("Role added successfully!"));
        }

        [HttpPost("create-role")]

        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            if (await roleManager.RoleExistsAsync(roleName))
            {
                return StatusCode(StatusCodes.Status409Conflict, ApiResultReturn.Fail(["Role already exists"], "Failed to create role"));
            }

            _ = await roleManager.CreateAsync(new IdentityRole(roleName));

            // return CreatedAtAction(nameof(GetRoleByName), new { roleName = roleName }, ApiResultReturn.Ok($"Role '{roleName}' created successfully."));
            return Created();
        }

        [HttpGet]

        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll([FromQuery] UserQuery query)
        {
            var users = userManager.Users;

            if (!string.IsNullOrWhiteSpace(query.Name))
            {
                users = users.Where(u => u.Name.Contains(query.Name));
            }

            if (!string.IsNullOrWhiteSpace(query.Email))
            {
                users = users.Where(u => u.Email != null && u.Email.Contains(query.Email));
            }

            if (!string.IsNullOrWhiteSpace(query.UserName))
            {
                users = users.Where(u => u.UserName != null && u.UserName.Contains(query.UserName));
            }

            users = users.ApplySorting(query.SortBy, query.IsDescending).ApplyPagination(query);

            users = users
                .Include(u => u.Posts)
                .Include(u => u.Likes)
                .Include(u => u.Comments)
                .Include(u => u.Followers)
                .Include(u => u.Followings)
                .AsSingleQuery();

            var usersDto = await users.Select(u => u.ToGetUserResponseDto()).ToListAsync();

            return Ok(ApiResultReturn.Ok(usersDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var currentUser = await authService.GetCurrentUser();

            if (currentUser?.Id != id)
            {
                return Unauthorized();
            }

            var userDb = await userManager.FindByIdAsync(id);

            if (userDb == null)
            {
                return NotFound(ApiResultReturn.Fail([UserNotFoundMsg], "Failed to get user"));
            }

            var userDto = userDb.ToGetUserResponseDto();

            return Ok(ApiResultReturn.Ok(userDto));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] UpdateUserRequestDto userToUpdate)
        {
            var userDb = await userManager.FindByIdAsync(id);

            if (userDb == null)
            {
                return NotFound(ApiResultReturn.Fail([UserNotFoundMsg], "Failed to update user"));
            }

            if (!string.IsNullOrWhiteSpace(userToUpdate.Name))
            {
                userDb.Name = userToUpdate.Name;
            }

            if (!string.IsNullOrWhiteSpace(userToUpdate.Email))
            {
                userDb.Email = userToUpdate.Email;
            }

            if (!string.IsNullOrWhiteSpace(userToUpdate.UserName))
            {
                userDb.UserName = userToUpdate.UserName;
            }

            var updatedUser = await userManager.UpdateAsync(userDb);

            if (!updatedUser.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ApiResultReturn.Fail(updatedUser.Errors.Select(e => e.Description), "Failed to update user"));
            }

            var userDto = userDb.ToGetUserResponseDto();

            return Ok(ApiResultReturn.Ok(userDto, "User updated successfully."));
        }

        [HttpDelete("{id}")]

        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var userDb = await userManager.FindByIdAsync(id);

            if (userDb == null)
            {
                return NotFound(ApiResultReturn.Fail([UserNotFoundMsg], "Failed to delete user"));
            }

            var deletedUser = await userManager.DeleteAsync(userDb);

            if (!deletedUser.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ApiResultReturn.Fail(deletedUser.Errors.Select(e => e.Description), "Failed to delete user"));
            }

            return NoContent();
        }

        [HttpGet("{id}/posts")]
        public async Task<IActionResult> GetPosts([FromRoute] string id)
        {
            var posts = await postService.GetByUserId(id);

            if (posts == null)
            {
                return NotFound(ApiResultReturn.Fail([UserNotFoundMsg], "Failed to get posts"));
            }

            return Ok(ApiResultReturn.Ok(posts));
        }

        [HttpGet("{id}/comments")]
        public async Task<IActionResult> GetComments([FromRoute] string id)
        {
            var commentsDb = await commentService.GetByUserId(id);

            if (commentsDb == null)
            {
                return NotFound(ApiResultReturn.Fail([UserNotFoundMsg], "Failed to get comments"));
            }

            return Ok(ApiResultReturn.Ok(commentsDb));
        }

        [HttpPost("upload-profile-picture")]
        public async Task<IActionResult> UploadProfilePicture(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest(ApiResultReturn.Fail(["No file uploaded"], "Failed to upload profile picture"));
            }

            var currentUser = await authService.GetCurrentUser();

            if (currentUser == null || string.IsNullOrWhiteSpace(currentUser.Id))
            {
                return Unauthorized();
            }

            var userDb = await userManager.FindByIdAsync(currentUser.Id);
            if (userDb == null)
            {
                return NotFound(ApiResultReturn.Fail([UserNotFoundMsg], "Failed to upload profile picture"));
            }

            using var ms = new MemoryStream();
            await file.CopyToAsync(ms);
            userDb.ProfilePicture = ms.ToArray();
            userDb.ProfilePictureContentType = file.ContentType;

            _ = await userManager.UpdateAsync(userDb);

            return Ok();
        }

        [HttpGet("{id}/profile-picture")]
        public async Task<IActionResult> GetProfilePicture(string id)
        {
            var userDb = await userManager.FindByIdAsync(id);

            if (userDb == null || userDb.ProfilePicture == null)
            {
                return NotFound(ApiResultReturn.Fail([UserNotFoundMsg], "Failed to get profile picture"));
            }

            return File(userDb.ProfilePicture, userDb.ProfilePictureContentType ?? "application/octet-stream");
        }

        [HttpGet("{id}/followers")]
        public async Task<IActionResult> GetFollowers([FromRoute] string id)
        {
            var userDb = await userManager.FindByIdAsync(id);

            if (userDb == null)
            {
                return NotFound(ApiResultReturn.Fail([UserNotFoundMsg], "Failed to get followers"));
            }

            var followers = await userManager.Users.Where(u => u.Followings.Any(f => f.Id == id))
                .Select(u => u.ToGetUserResponseDto())
                .ToListAsync();

            return Ok(ApiResultReturn.Ok(followers));
        }

        [HttpGet("{id}/followings")]
        public async Task<IActionResult> GetFollowings([FromRoute] string id)
        {
            var userDb = await userManager.FindByIdAsync(id);

            if (userDb == null)
            {
                return NotFound(ApiResultReturn.Fail([UserNotFoundMsg], "Failed to get followings"));
            }

            var followings = await userManager.Users.Where(u => u.Followers.Any(f => f.Id == id))
                .Select(u => u.ToGetUserResponseDto())
                .ToListAsync();

            return Ok(ApiResultReturn.Ok(followings));
        }
    }
}