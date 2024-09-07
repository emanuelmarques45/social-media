using Api.Dtos.User;
using Api.Helpers.Query;
using Api.Interfaces.Repository;
using Api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserRepository _userRepo) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserRequestDto userDto)
        {
            var newUser = userDto.ToUserDto();
            await _userRepo.CreateAsync(newUser);

            return CreatedAtAction(nameof(GetById), new { newUser.Id }, newUser.ToGetUserResponseDto());
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] UserQuery query)
        {
            var users = await _userRepo.GetAllAsync(query);

            var usersDto = users.Select(u => u.ToGetUserResponseDto()).ToList();

            return Ok(usersDto);
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
