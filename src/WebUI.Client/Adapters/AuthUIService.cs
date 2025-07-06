using Microsoft.AspNetCore.Components.Authorization;
using WebUI.Client.Ports;

namespace WebUI.Client.Adapters;

public sealed class AuthUIService(
    AuthenticationStateProvider authStateProvider) : IAuthUIService
{
    private readonly AuthenticationStateProvider authStateProvider = authStateProvider;

    public async Task<bool> IsUserAuthenticatedAsync()
    {
        return (await authStateProvider
            .GetAuthenticationStateAsync()).User.Identity!.IsAuthenticated;
    }
}
