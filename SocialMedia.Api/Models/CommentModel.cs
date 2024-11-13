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
        public int? ParentId { get; set; }

        //Navigation properties
        public PostModel Post { get; set; } = null!;
        public UserModel User { get; set; } = null!;
        public CommentModel Comment { get; set; } = null!;
        public List<CommentModel> Replies { get; set; } = [];
    }
}
