using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Api.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class UserModel : IdentityUser<int>
    {
        public string Name { get; set; } = string.Empty;
        public override string Email { get; set; } = string.Empty;
        public override string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        //Navigation properties
        public List<PostModel> Posts { get; set; } = [];
        public List<LikeModel> Likes { get; set; } = [];
        public List<CommentModel> Comments { get; set; } = [];
    }
}