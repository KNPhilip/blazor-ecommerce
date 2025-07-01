using Microsoft.AspNetCore.Components.Authorization;
using WebUI.Client.Ports;

namespace WebUI.Client.Adapters;

public sealed class AuthUIService(
    AuthenticationStateProvider authStateProvider) : IAuthUIService
{
    public async Task<bool> IsUserAuthenticated()
    {
        return (await authStateProvider
            .GetAuthenticationStateAsync()).User.Identity!.IsAuthenticated;
    }
}
