using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Classes.Dtos.Post;
using SocialMedia.Classes.Interfaces;
using SocialMedia.Classes.Mappers;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PostsController(IPostService postService) : ControllerBase
    {
        private readonly string _postNotFoundMsg = "The post was not found!";

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePostRequestDto postToCreate)
        {
            var createdPost = await postService.Create(postToCreate);

            if (createdPost == null)
            {
                return NotFound("User not found!");
            }

            return CreatedAtAction(
                nameof(GetById),
                new { createdPost.Id },
                createdPost.ToGetPostResponseDto());
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var posts = await postService.GetAll();

            var postsDto = posts.Select(p => p.ToGetPostResponseDto()).ToList();

            return Ok(postsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var post = await postService.GetById(id);

            if (post == null)
            {
                return NotFound(_postNotFoundMsg);
            }

            return Ok(post.ToGetPostResponseDto());
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePostRequestDto postToUpdate)
        {
            var updatedPost = await postService.Update(postToUpdate);

            if (updatedPost == null)
            {
                return NotFound(_postNotFoundMsg);
            }

            return Ok(updatedPost.ToGetPostResponseDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deletedPost = await postService.Delete(id);

            if (deletedPost == null)
            {
                return NotFound(_postNotFoundMsg);
            }

            return NoContent();
        }
    }
}
