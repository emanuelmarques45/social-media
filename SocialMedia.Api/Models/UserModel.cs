using Microsoft.AspNetCore.Identity;

namespace SocialMedia.Api.Models
{
    public class UserModel : IdentityUser
    {
        public string Name { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public List<PostModel> Posts { get; set; } = [];

        public List<LikeModel> Likes { get; set; } = [];

        public List<CommentModel> Comments { get; set; } = [];
    }
}