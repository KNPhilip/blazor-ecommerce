using WebUI.Client.Ports;

namespace WebUI.Server.Adapters;

public sealed class AuthUIService(
    IHttpContextAccessor httpContextAccessor) : IAuthUIService
{
    public async Task<bool> IsUserAuthenticated()
    {
        await Task.Run(() => { });
        bool? isAuthenticated = httpContextAccessor
            .HttpContext!.User.Identity!.IsAuthenticated;
        if (isAuthenticated is null)
        {
            return false;
        }
        return isAuthenticated.Value;
    }
}
