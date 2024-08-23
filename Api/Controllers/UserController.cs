using Api.Data;
using Api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(ApplicationDbContext context) : ControllerBase
    {
        private readonly ApplicationDbContext _context = context;

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _context.Users.ToList().Select(u => u.ToUserDto());

            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser([FromRoute] int id)
        {
            var user = _context.Users.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user.ToUserDto());
        }
    }
}
