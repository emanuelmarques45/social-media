using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; }
        public int PostId { get; set; }
        public int UserId { get; set; }

        //Navigation properties
        public Post Post { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}
