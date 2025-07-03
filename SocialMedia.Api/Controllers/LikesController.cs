using Microsoft.AspNetCore.Mvc;
using SocialMedia.Lib.Dtos.Likes;
using SocialMedia.Lib.Interfaces;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    // [Authorize]
    public class LikesController(IPostLikeService postLike) : ControllerBase
    {
        private readonly string _likeNotFoundMsg = "The like was not found!";

        [HttpPost("post")]
        public async Task<IActionResult> LikePost([FromBody] CreateLikeRequestDto likeToCreate)
        {
            var response = await postLike.ToggleLike(likeToCreate);

            if (!response.Success)
            {
                return NotFound(response.Errors);
            }

            return CreatedAtAction(
                nameof(GetById),
                new { response.Data?.Id },
                response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] LikeableType likeType)
        {
            var likes = await postLike.GetAll(likeType);

            return Ok(likes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id, [FromBody] LikeableType likeType)
        {
            var like = await postLike.GetById(id, likeType);

            if (like == null)
            {
                return NotFound(_likeNotFoundMsg);
            }

            return Ok(like);
        }
    }
}
