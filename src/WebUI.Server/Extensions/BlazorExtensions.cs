using Blazored.LocalStorage;
using MudBlazor.Services;

namespace WebUI.Server.Extensions;

public static class BlazorExtensions
{
    public static void AddBlazor(this IServiceCollection services)
    {
        services.AddCascadingAuthenticationState();
        services.AddRazorComponents()
            .AddInteractiveServerComponents()
            .AddInteractiveWebAssemblyComponents();

        services.AddRazorPages();
        services.AddMudServices();
        services.AddBlazoredLocalStorage();
    }
}
