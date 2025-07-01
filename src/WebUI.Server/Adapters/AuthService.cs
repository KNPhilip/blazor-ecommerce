using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using UseCases.Ports.Output;
using Domain.Models;

namespace WebUI.Server.Adapters;

public sealed class AuthService(IHttpContextAccessor httpContextAccessor, 
    UserManager<DbUser> userManager) : IAuthService
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly UserManager<DbUser> userManager = userManager;

    public async Task<string> GetUserIdAsync()
    {
        DbUser user = await userManager.GetUserAsync(_httpContextAccessor.HttpContext!.User)
            ?? throw new Exception("User not found.");

        return user.Id;
    }

    public string GetUserEmail()
    {
        return _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name)
            ?? throw new ArgumentNullException("Couldn't get the users email..");
    }

    public async Task<DbUser> GetUserByEmailAsync(string email)
    {
        DbUser? user = await userManager.FindByEmailAsync(email);

        ArgumentNullException.ThrowIfNull(user, nameof(user));

        return user;
    }

    public bool IsUserAdmin()
    {
        try
        {
            return httpContextAccessor.HttpContext!.User.IsInRole("Admin");
        }
        catch (Exception)
        {
            return false;
        }
    }
}
