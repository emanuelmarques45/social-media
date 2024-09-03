using Api.Dtos.User;
using Api.Interfaces.Repository;
using Api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserRepository _userRepo) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = (await _userRepo.GetAllAsync()).Select(u => u.ToGetUserResponseDto());

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var userDb = await _userRepo.GetByIdAsync(id);

            if (userDb == null)
            {
                return NotFound();
            }

            return Ok(userDb.ToGetUserResponseDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserRequestDto userRequestDto)
        {
            var newUser = userRequestDto.ToUserDto();
            await _userRepo.CreateAsync(newUser);

            return CreatedAtAction(nameof(GetById), new { newUser.Id }, newUser.ToGetUserResponseDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUserRequestDto userDto)
        {
            var userDb = await _userRepo.UpdateAsync(id, userDto);

            if (userDb == null)
            {
                return NotFound();
            }

            return Ok(userDb.ToGetUserResponseDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var userDb = await _userRepo.DeleteAsync(id);

            if (userDb == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
