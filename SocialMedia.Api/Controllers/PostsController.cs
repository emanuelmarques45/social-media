using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Shared.Dtos.Post;
using SocialMedia.Shared.Helpers.ApiResult;
using SocialMedia.Shared.Helpers.Query;
using SocialMedia.Shared.Interfaces;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]
    public class PostsController(IPostService postService, ICommentService commentService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePostRequestDto postToCreate)
        {
            var createdPost = await postService.Create(postToCreate);

            if (!createdPost.Success)
            {
                return NotFound(createdPost);
            }

            return CreatedAtAction(
                nameof(GetById),
                new { createdPost.Data?.Id },
                createdPost);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PostQuery query)
        {
            var posts = (await postService.GetAll()).Data?.AsQueryable();

            if (!string.IsNullOrEmpty(query.Content))
            {
                posts = posts?.Where(p => p.Content.Contains(query.Content));
            }

            if (query.CreatedAtStart != null)
            {
                posts = posts?.Where(p => p.CreatedAt >= query.CreatedAtStart);
            }

            if (query.CreatedAtEnd != null)
            {
                posts = posts?.Where(p => p.CreatedAt <= query.CreatedAtEnd);
            }

            posts = posts?.ApplySorting(query.SortBy, query.IsDescending).ApplyPagination(query);

            return Ok(ApiResultReturn.Ok(posts));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var post = await postService.GetById(id);

            if (!post.Success)
            {
                return NotFound(post);
            }

            return Ok(post);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdatePostRequestDto postToUpdate)
        {
            var updatedPost = await postService.Update(id, postToUpdate);

            if (!updatedPost.Success)
            {
                return NotFound(updatedPost);
            }

            return Ok(updatedPost);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deletedPost = await postService.Delete(id);

            if (!deletedPost.Success)
            {
                return NotFound(deletedPost);
            }

            return NoContent();
        }

        [HttpGet("{id}/comments")]
        public async Task<IActionResult> GetComments([FromRoute] int id)
        {
            var commentsDb = await commentService.GetByPostId(id);

            if (!commentsDb.Success)
            {
                return NotFound(commentsDb);
            }

            return Ok(commentsDb);
        }
    }
}
