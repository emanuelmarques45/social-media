using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Api.Dtos.Comment;
using SocialMedia.Api.Interfaces.Repository;
using SocialMedia.Api.Mappers;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentController(ICommentRepository _commentRepo) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCommentRequestDto commentDto)
        {
            var newComment = commentDto.ToCommentModel();
            await _commentRepo.CreateAsync(newComment);

            return CreatedAtAction(nameof(GetById), new { newComment.Id }, newComment.ToGetCommentResponseDto());
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _commentRepo.GetAllAsync();

            var commentsDto = comments.Select(c => c.ToGetCommentResponseDto()).ToList();

            return Ok(commentsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var commentDb = await _commentRepo.GetByIdAsync(id);

            if (commentDb == null)
            {
                return NotFound();
            }

            return Ok(commentDb.ToGetCommentResponseDto());
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentRequestDto commentDto)
        {
            var commentDb = await _commentRepo.UpdateAsync(id, commentDto);

            if (commentDb == null)
            {
                return NotFound();
            }

            return Ok(commentDb.ToGetCommentResponseDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var commentDb = await _commentRepo.DeleteAsync(id);

            if (commentDb == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
