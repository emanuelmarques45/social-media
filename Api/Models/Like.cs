using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Like
    {
        [Key]
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; }

        //Navigation properties
        public Post Post { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}
