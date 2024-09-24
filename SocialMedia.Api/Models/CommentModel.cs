using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Api.Models
{
    public class CommentModel
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int PostId { get; set; }
        public string UserId { get; set; } = string.Empty;

        //Navigation properties
        public PostModel Post { get; set; } = null!;
        public UserModel User { get; set; } = null!;
    }
}
