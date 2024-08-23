using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; }
        public int UserId { get; set; }

        //Navigation properties
        public User User { get; set; } = null!;
        public List<Like> Likes { get; set; } = [];
        public List<Comment> Comments { get; set; } = [];
    }
}