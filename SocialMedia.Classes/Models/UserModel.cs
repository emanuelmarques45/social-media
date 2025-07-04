using Microsoft.AspNetCore.Identity;

namespace SocialMedia.Shared.Models
{
    public class UserModel : IdentityUser
    {
        public string Name { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public List<PostModel> Posts { get; set; } = [];

        public List<PostLikeModel> Likes { get; set; } = [];

        public List<CommentModel> Comments { get; set; } = [];

        public List<UserModel> Followers { get; set; } = [];

        public List<UserModel> Followings { get; set; } = [];
    }
}