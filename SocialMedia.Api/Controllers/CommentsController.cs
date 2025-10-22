using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Shared.Dtos.Comment;
using SocialMedia.Shared.Helpers.ApiResult;
using SocialMedia.Shared.Interfaces;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentsController(ICommentService commentService) : ControllerBase
    {
        private string CommentNotFoundMsg => $"{GetType().Name.Replace("Controller", string.Empty)[..^1]} not found.";

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCommentRequestDto commentToCreate)
        {
            var createdComment = await commentService.Create(commentToCreate);

            if (createdComment == null)
            {
                return NotFound("User or Post not found!");
            }

            return CreatedAtAction(
                nameof(GetById),
                new { createdComment.Id },
                createdComment);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await commentService.GetAll();

            return Ok(comments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var comment = await commentService.GetById(id);

            if (comment == null)
            {
                return NotFound(ApiResultReturn.Fail([CommentNotFoundMsg], "Failed to get comment."));
            }

            return Ok(comment);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentRequestDto commentToUpdate)
        {
            var updatedComment = await commentService.Update(id, commentToUpdate);

            if (updatedComment == null)
            {
                return NotFound(ApiResultReturn.Fail([CommentNotFoundMsg], "Failed to update comment."));
            }

            return Ok(updatedComment);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deletedComment = await commentService.Delete(id);

            if (deletedComment == null)
            {
                return NotFound(ApiResultReturn.Fail([CommentNotFoundMsg], "Failed to delete comment"));
            }

            return NoContent();
        }
    }
}
