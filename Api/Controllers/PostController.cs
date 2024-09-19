using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Api.Dtos.Post;
using SocialMedia.Api.Interfaces.Services;
using SocialMedia.Api.Mappers;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PostController(IPostService _postService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePostRequestDto postToCreate)
        {
            var createdPost = await _postService.Create(postToCreate);

            return CreatedAtAction(
                nameof(GetById),
                new { createdPost.Id },
                createdPost.ToGetPostResponseDto()
            );
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var posts = await _postService.GetAll();

            var postsDto = posts.Select(p => p.ToGetPostResponseDto()).ToList();

            return Ok(postsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var post = await _postService.GetById(id);

            if (post == null)
            {
                return NotFound();
            }

            return Ok(post.ToGetPostResponseDto());
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePostRequestDto postDto)
        {
            var updatedPost = await _postService.Update(postDto);

            if (updatedPost == null)
            {
                return NotFound();
            }

            return Ok(updatedPost.ToGetPostResponseDto());
        }

        /*[HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var postDb = await _postService.Delete(id);

            if (postDb == null)
            {
                return NotFound();
            }

            return NoContent();
        }*/
    }
}
