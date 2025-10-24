using Microsoft.AspNetCore.Mvc;
using SocialMedia.Shared.Dtos.ChildComment;
using SocialMedia.Shared.Interfaces;

namespace SocialMedia.Api.Controllers
{
    [Route("api/child-comments")]
    [ApiController]

    // [Authorize]
    public class ChildCommentsController(IChildCommentService childCommentService) : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateChildCommentRequestDto childCommentToCreate)
        {
            var createdChildComment = await childCommentService.Create(childCommentToCreate);

            if (!createdChildComment.Success)
            {
                return NotFound(createdChildComment);
            }

            return CreatedAtAction(
                nameof(GetById),
                new { createdChildComment.Data?.Id },
                createdChildComment);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var childComments = await childCommentService.GetAll();

            return Ok(childComments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var childComment = await childCommentService.GetById(id);

            if (!childComment.Success)
            {
                return NotFound(childComment);
            }

            return Ok(childComment);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateChildCommentRequestDto childCommentToUpdate)
        {
            var updatedChildComment = await childCommentService.Update(id, childCommentToUpdate);

            if (!updatedChildComment.Success)
            {
                return NotFound(updatedChildComment);
            }

            return Ok(updatedChildComment);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deletedChildComment = await childCommentService.Delete(id);

            if (!deletedChildComment.Success)
            {
                return NotFound(deletedChildComment);
            }

            return NoContent();
        }
    }
}
