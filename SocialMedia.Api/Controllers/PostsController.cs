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
        private string PostNotFoundMsg => $"{GetType().Name.Replace("Controller", string.Empty)[..^1]} not found.";

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
                createdPost);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PostQuery query)
        {
            var posts = (await postService.GetAll()).AsQueryable();

            if (!string.IsNullOrEmpty(query.Content))
            {
                posts = posts.Where(p => p.Content.Contains(query.Content));
            }

            if (query.CreatedAtStart != null)
            {
                posts = posts.Where(p => p.CreatedAt >= query.CreatedAtStart);
            }

            if (query.CreatedAtEnd != null)
            {
                posts = posts.Where(p => p.CreatedAt <= query.CreatedAtEnd);
            }

            posts = posts.ApplySorting(query.SortBy, query.IsDescending).ApplyPagination(query);

            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var post = await postService.GetById(id);

            if (post == null)
            {
                return NotFound(ApiResultReturn.Fail([PostNotFoundMsg], "Failed to get post."));
            }

            return Ok(post);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdatePostRequestDto postToUpdate)
        {
            var updatedPost = await postService.Update(id, postToUpdate);

            if (updatedPost == null)
            {
                return NotFound(ApiResultReturn.Fail([PostNotFoundMsg], "Failed to update post."));
            }

            return Ok(updatedPost);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deletedPost = await postService.Delete(id);

            if (deletedPost == null)
            {
                return NotFound(ApiResultReturn.Fail([PostNotFoundMsg], "Failed to delete post."));
            }

            return NoContent();
        }

        [HttpGet("{id}/comments")]
        public async Task<IActionResult> GetComments([FromRoute] int id)
        {
            var commentsDb = await commentService.GetByPostId(id);

            if (commentsDb == null)
            {
                return NotFound(ApiResultReturn.Fail([PostNotFoundMsg], "Failed to get comments"));
            }

            return Ok(ApiResultReturn.Ok(commentsDb));
        }
    }
}
