using SocialMedia.Shared.Data;

namespace SocialMedia.Api.Repository.Follow
{
    public class FollowRepository(ApplicationDbContext context)
    {
        public async Task Follow(string userId, string followId)
        {
            context.Post
        }
    }
}