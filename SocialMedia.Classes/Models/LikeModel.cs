using Microsoft.EntityFrameworkCore;

namespace SocialMedia.Classes.Models
{
    [PrimaryKey(nameof(PostId), nameof(UserId))]
    public class LikeModel
    {
        public int PostId { get; set; }

        public required string UserId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public PostModel Post { get; set; } = default!;

        public UserModel User { get; set; } = default!;
    }
}
