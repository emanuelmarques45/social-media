using Microsoft.AspNetCore.Identity;
using SocialMedia.Classes.Data;
using SocialMedia.Classes.Models;

namespace SocialMedia.Front.Components.Account
{
    internal sealed class IdentityUserAccessor(IdentityRedirectManager redirectManager, IServiceScopeFactory scopeFactory)
    {
        public async Task<UserModel> GetRequiredUserAsync(HttpContext context)
        {
            using var scope = scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<UserModel>>();

            var user = await userManager.GetUserAsync(context.User);

            if (user is null)
            {
                redirectManager.RedirectToWithStatus("Account/InvalidUser", $"Error: Unable to load user with ID '{userManager.GetUserId(context.User)}'.", context);
            }

            return user;
        }
    }
}
