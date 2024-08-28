using Api.Data;
using Api.Dtos.User;
using Api.Interfaces.Repository;
using Api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(ApplicationDbContext _context, IUserRepository _userRepo) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userRepo.GetAllAsync();
            var usersDto = users.Select(u => u.ToGetUserResponseDto());

            return Ok(usersDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] int id)
        {
            var user = await _userRepo.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user.ToGetUserResponseDto());
        }

        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] CreateUserRequestDto userDto)
        {
            var newUser = userDto.ToCreateUserRequestDto();
            await _userRepo.CreateAsync(newUser);

            return CreatedAtAction(nameof(GetUser), new { newUser.Id }, newUser.ToGetUserResponseDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int id, [FromBody] UpdateUserRequestDto userDto)
        {
            var user = await _userRepo.UpdateAsync(id, userDto);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user.ToGetUserResponseDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            var user = await _userRepo.DeleteAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
