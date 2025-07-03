using Microsoft.AspNetCore.Mvc;
using SocialMedia.Lib.Dtos.Comment;
using SocialMedia.Lib.Interfaces;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    // [Authorize]
    public class CommentsController(ICommentService commentService) : ControllerBase
    {
        private readonly string _commentNotFoundMsg = "The comment was not found!";

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
                return NotFound(_commentNotFoundMsg);
            }

            return Ok(comment);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCommentRequestDto commentToUpdate)
        {
            var updatedComment = await commentService.Update(commentToUpdate);

            if (updatedComment == null)
            {
                return NotFound(_commentNotFoundMsg);
            }

            return Ok(updatedComment);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deletedComment = await commentService.Delete(id);

            if (deletedComment == null)
            {
                return NotFound(_commentNotFoundMsg);
            }

            return NoContent();
        }
    }
}
