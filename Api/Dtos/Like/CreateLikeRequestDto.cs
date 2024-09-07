using System.ComponentModel.DataAnnotations;

namespace Api.Dtos.Like
{
    public class CreateLikeRequestDto
    {
        [Required]
        public int PostId { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
