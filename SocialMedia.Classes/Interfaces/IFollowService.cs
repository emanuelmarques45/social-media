using SocialMedia.Shared.Helpers.ApiResult;

namespace SocialMedia.Shared.Interfaces
{
    public interface IFollowService
    {
        public Task<ApiResult<bool>> Follow(string userId, string followId);
    }
}