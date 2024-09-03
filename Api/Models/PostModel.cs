using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class PostModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }

        //Navigation properties
        public UserModel User { get; set; } = null!;
        public List<LikeModel> Likes { get; set; } = [];
        public List<CommentModel> Comments { get; set; } = [];
    }
}