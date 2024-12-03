using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Api.Dtos.Comment;
using SocialMedia.Api.Interfaces.Services;
using SocialMedia.Api.Mappers;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
                createdComment.ToGetCommentResponseDto());
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await commentService.GetAll();

            var commentsDto = comments.Select(c => c.ToGetCommentResponseDto()).ToList();

            return Ok(commentsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var commentDb = await commentService.GetById(id);

            if (commentDb == null)
            {
                return NotFound(_commentNotFoundMsg);
            }

            return Ok(commentDb.ToGetCommentResponseDto());
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCommentRequestDto commentToUpdate)
        {
            var updatedComment = await commentService.Update(commentToUpdate);

            if (updatedComment == null)
            {
                return NotFound(_commentNotFoundMsg);
            }

            return Ok(updatedComment.ToGetCommentResponseDto());
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
