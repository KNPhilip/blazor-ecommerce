using WebUI.Client.Ports;

namespace WebUI.Server.Adapters;

public sealed class AuthUIService(
    IHttpContextAccessor httpContextAccessor) : IAuthUIService
{
    private readonly IHttpContextAccessor httpContextAccessor = httpContextAccessor;

    public async Task<bool> IsUserAuthenticatedAsync()
    {
        await Task.Run(() => { });

        bool? isAuthenticated = httpContextAccessor
            .HttpContext!.User.Identity!.IsAuthenticated;

        return isAuthenticated is not null && isAuthenticated.Value;
    }
}
