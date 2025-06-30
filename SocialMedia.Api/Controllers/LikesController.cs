using Microsoft.AspNetCore.Mvc;
using SocialMedia.Classes.Dtos.Likes;
using SocialMedia.Classes.Interfaces;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    // [Authorize]
    public class LikesController(ILikeService likeService) : ControllerBase
    {
        private readonly string _likeNotFoundMsg = "The like was not found!";

        [HttpPost("like-post")]
        public async Task<IActionResult> LikePostAsync([FromBody] CreateLikeRequestDto likeToCreate)
        {
            var createdLike = await likeService.Create(likeToCreate);

            if (createdLike == null)
            {
                return NotFound("User not found!");
            }

            return CreatedAtAction(
                nameof(GetById),
                new { createdLike.Id },
                createdLike);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateLikeRequestDto likeToCreate) => Ok();

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var likes = await likeService.GetAll();

            return Ok(likes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var like = await likeService.GetById(id);

            if (like == null)
            {
                return NotFound(_likeNotFoundMsg);
            }

            return Ok(like);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateLikeRequestDto likeToUpdate)
        {
            var updatedLike = await likeService.Update(likeToUpdate);

            if (updatedLike == null)
            {
                return NotFound(_likeNotFoundMsg);
            }

            return Ok(updatedLike);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deletedLike = await likeService.Delete(id);

            if (deletedLike == null)
            {
                return NotFound(_likeNotFoundMsg);
            }

            return NoContent();
        }
    }
}
