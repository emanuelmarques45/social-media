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
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePostRequestDto postDto)
        {
            var newPost = postDto.ToPostDto();
            await _postRepo.CreateAsync(newPost);

            return CreatedAtAction(nameof(GetById), new { newPost.Id }, newPost.ToGetPostResponseDto());
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var posts = await _postRepo.GetAllAsync();

            var postsDto = posts.Select(p => p.ToGetPostResponseDto()).ToList();

            return Ok(postsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var postDb = await _postRepo.GetByIdAsync(id);

            if (postDb == null)
            {
                return NotFound();
            }

            return Ok(postDb.ToGetPostResponseDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdatePostRequestDto postDto)
        {
            var postDb = await _postRepo.UpdateAsync(id, postDto);

            if (postDb == null)
            {
                return NotFound();
            }

            return Ok(postDb.ToGetPostResponseDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var postDb = await _postRepo.DeleteAsync(id);

            if (postDb == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
