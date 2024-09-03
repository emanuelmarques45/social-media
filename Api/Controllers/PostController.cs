using Api.Dtos.Post;
using Api.Interfaces.Repository;
using Api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController(IPostRepository _postRepo) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var posts = (await _postRepo.GetAllAsync()).Select(p => p.ToGetPostResponseDto());

            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var postDb = await _postRepo.GetByIdAsync(id);

            if (postDb == null)
            {
                return NotFound();
            }

            return Ok(postDb.ToGetPostResponseDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePostRequestDto postRequestDto)
        {
            var newPost = postRequestDto.ToPostDto();
            await _postRepo.CreateAsync(newPost);

            return CreatedAtAction(nameof(GetById), new { newPost.Id }, newPost.ToGetPostResponseDto());
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update(int id, [FromBody] string value)
        //{
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //}
    }
}
