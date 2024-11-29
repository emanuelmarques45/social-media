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
    public class CommentsController(ICommentService _commentService) : ControllerBase
    {
        private readonly string commentNotFoundMsg = "The comment was not found!";

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCommentRequestDto commentToCreate)
        {
            var createdComment = await _commentService.Create(commentToCreate);

            if (createdComment == null)
            {
                return NotFound("User or Post not found!");
            }

            return CreatedAtAction(
                nameof(GetById),
                new { createdComment.Id },
                createdComment.ToGetCommentResponseDto()
            );
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _commentService.GetAll();

            var commentsDto = comments.Select(c => c.ToGetCommentResponseDto()).ToList();

            return Ok(commentsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var commentDb = await _commentService.GetById(id);

            if (commentDb == null)
            {
                return NotFound(commentNotFoundMsg);
            }

            return Ok(commentDb.ToGetCommentResponseDto());
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCommentRequestDto commentToUpdate)
        {
            var updatedPost = await _commentService.Update(commentToUpdate);

            if (updatedPost == null)
            {
                return NotFound(commentNotFoundMsg);
            }

            return Ok(updatedPost.ToGetCommentResponseDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deletedComment = await _commentService.Delete(id);

            if (deletedComment == null)
            {
                return NotFound(commentNotFoundMsg);
            }

            return NoContent();
        }
    }
}
