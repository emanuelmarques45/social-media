using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Api.Dtos.ChildComment;
using SocialMedia.Api.Interfaces.Services;
using SocialMedia.Api.Mappers;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ChildCommentsController(IChildCommentService childCommentService) : ControllerBase
    {
        private readonly string _childCommentNotFoundMsg = "The comment was not found!";

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateChildCommentRequestDto childCommentToCreate)
        {
            var createdChildComment = await childCommentService.Create(childCommentToCreate);

            if (createdChildComment == null)
            {
                return NotFound("User or Post not found!");
            }

            return CreatedAtAction(
                nameof(GetById),
                new { createdChildComment.Id },
                createdChildComment.ToGetChildCommentResponseDto());
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var childComments = await childCommentService.GetAll();

            var childCommentsDto = childComments.Select(c => c.ToGetChildCommentResponseDto()).ToList();

            return Ok(childCommentsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var childCommentDb = await childCommentService.GetById(id);

            if (childCommentDb == null)
            {
                return NotFound(_childCommentNotFoundMsg);
            }

            return Ok(childCommentDb.ToGetChildCommentResponseDto());
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateChildCommentRequestDto childCommentToUpdate)
        {
            var updatedChildComment = await childCommentService.Update(childCommentToUpdate);

            if (updatedChildComment == null)
            {
                return NotFound(_childCommentNotFoundMsg);
            }

            return Ok(updatedChildComment.ToGetChildCommentResponseDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deletedChildComment = await childCommentService.Delete(id);

            if (deletedChildComment == null)
            {
                return NotFound(_childCommentNotFoundMsg);
            }

            return NoContent();
        }
    }
}
