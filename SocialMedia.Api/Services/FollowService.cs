using Microsoft.AspNetCore.Identity;
using SocialMedia.Shared.Helpers.ApiResult;
using SocialMedia.Shared.Interfaces;
using SocialMedia.Shared.Models;

namespace SocialMedia.Api.Services
{
    [Service(ServiceLifetime.Scoped)]
    public class FollowService : IFollowService
    {
        public async Task<ApiResult<bool>> Follow(string userId, string followId)
        {
            return ApiResultReturn.Ok(true);
        }
    }
}