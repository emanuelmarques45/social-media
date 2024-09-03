using Api.Models;
using System.ComponentModel.DataAnnotations;

namespace Api.Dtos.Post
{
    public class UpdatePostRequestDto
    {

        public int Id { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }

        //Navigation properties
        public List<LikeModel> Likes { get; set; } = [];
        public List<CommentModel> Comments { get; set; } = [];
    }
}
