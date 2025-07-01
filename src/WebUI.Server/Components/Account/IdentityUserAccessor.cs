using Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace WebUI.Server.Components.Account;

internal sealed class IdentityUserAccessor(UserManager<DbUser> userManager, IdentityRedirectManager redirectManager)
{
    public async Task<DbUser> GetRequiredUserAsync(HttpContext context)
    {
        DbUser? user = await userManager.GetUserAsync(context.User);

        if (user is null)
        {
            redirectManager.RedirectToWithStatus("account/invaliduser", $"Error: Unable to load user with ID '{userManager.GetUserId(context.User)}'.", context);
        }

        return user;
    }
}
