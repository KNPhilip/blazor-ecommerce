using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using UseCases.Ports.Output;
using Domain.Models;

namespace WebUI.Server.Adapters;

public sealed class AuthService(IHttpContextAccessor httpContextAccessor, 
    IServiceProvider serviceProvider) : IAuthService
{
    private readonly IHttpContextAccessor httpContextAccessor = httpContextAccessor;
    private readonly IServiceProvider serviceProvider = serviceProvider;

    public async Task<string> GetUserIdAsync()
    {
        IServiceScope scope = serviceProvider.CreateScope();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<DbUser>>();

        DbUser user = await userManager.GetUserAsync(httpContextAccessor.HttpContext!.User)
            ?? throw new Exception("User not found.");

        return user.Id;
    }

    public string GetUserEmail()
    {
        return httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.Name)
            ?? throw new ArgumentNullException("Couldn't get the users email..");
    }

    public async Task<DbUser> GetUserByEmailAsync(string email)
    {
        IServiceScope scope = serviceProvider.CreateScope();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<DbUser>>();

        DbUser user = await userManager.FindByEmailAsync(email)
            ?? throw new Exception($"User with email \"{email}\" not found.");

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
