using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Shared.Dtos.Comment;
using SocialMedia.Shared.Interfaces;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]
    public class CommentsController(ICommentService commentService, IChildCommentService childCommentService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCommentRequestDto commentToCreate)
        {
            var createdComment = await commentService.Create(commentToCreate);

            if (!createdComment.Success)
            {
                return NotFound(createdComment);
            }

            return CreatedAtAction(
                nameof(GetById),
                new { createdComment.Data?.Id },
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

            if (!comment.Success)
            {
                return NotFound(comment);
            }

            return Ok(comment);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentRequestDto commentToUpdate)
        {
            var updatedComment = await commentService.Update(id, commentToUpdate);

            if (!updatedComment.Success)
            {
                return NotFound(updatedComment);
            }

            return Ok(updatedComment);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deletedComment = await commentService.Delete(id);

            if (!deletedComment.Success)
            {
                return NotFound(deletedComment);
            }

            return NoContent();
        }

        [HttpGet("{id}/child-comments")]
        public async Task<IActionResult> GetChildComments([FromRoute] int id)
        {
            var childComments = await childCommentService.GetByCommentId(id);

            if (!childComments.Success)
            {
                return NotFound(childComments);
            }

            return Ok(childComments);
        }
    }
}
