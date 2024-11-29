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
    public class PostsController(IPostService _postService) : ControllerBase
    {
        private readonly string postNotFoundMsg = "The post was not found!";

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePostRequestDto postToCreate)
        {
            var createdPost = await _postService.Create(postToCreate);

            if (createdPost == null)
            {
                return NotFound("User not found!");
            }

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
                return NotFound(postNotFoundMsg);
            }

            return Ok(post.ToGetPostResponseDto());
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePostRequestDto postToUpdate)
        {
            var updatedPost = await _postService.Update(postToUpdate);

            if (updatedPost == null)
            {
                return NotFound(postNotFoundMsg);
            }

            return Ok(updatedPost.ToGetPostResponseDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deletedPost = await _postService.Delete(id);

            if (deletedPost == null)
            {
                return NotFound(postNotFoundMsg);
            }

            return NoContent();
        }
    }
}
