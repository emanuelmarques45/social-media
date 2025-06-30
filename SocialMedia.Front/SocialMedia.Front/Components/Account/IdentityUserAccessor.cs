using Microsoft.AspNetCore.Identity;


namespace SocialMedia.Front.Components.Account;

internal sealed class IdentityUserAccessor(UserManager<UserModel> userManager, IdentityRedirectManager redirectManager)
{
    public async Task<UserModel> GetRequiredUserAsync(HttpContext context)
    {
        var user = await userManager.GetUserAsync(context.User);

        if (user is null)
        {
            redirectManager.RedirectToWithStatus("Account/InvalidUser", $"Error: Unable to load user with ID '{userManager.GetUserId(context.User)}'.", context);
        }

        return user;
    }
}
