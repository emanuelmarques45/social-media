using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class LikeModel
    {
        [Key]
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        //Navigation properties
        public PostModel Post { get; set; } = null!;
        public UserModel User { get; set; } = null!;
    }
}
