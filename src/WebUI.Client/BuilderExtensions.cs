using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using MudBlazor.Services;
using WebUI.Client.Ports;
using WebUI.Client.Adapters;

namespace WebUI.Client;

public static class BuilderExtensions
{
    public static void AddServicesFromExtensionsClass
        (this IServiceCollection services, Uri baseAddress)
    {
        services.AddMudServices();
        services.AddBlazoredLocalStorage();
        services.AddCascadingAuthenticationState();

        services.AddScoped(sp => new HttpClient { BaseAddress = baseAddress });
        services.AddScoped<AuthenticationStateProvider, ClientAuthStateProvider>();
        services.AddScoped<IAddressUIService, AddressUIService>();
        services.AddScoped<IAuthUIService, AuthUIService>();
        services.AddScoped<ICartUIService, CartUIService>();
        services.AddScoped<ICategoryUIService, CategoryUIService>();
        services.AddScoped<IOrderUIService, OrderUIService>();
        services.AddScoped<IProductUIService, ProductUIService>();
        services.AddScoped<IProductTypeUIService, ProductTypeUIService>();

        services.AddOptions();
        services.AddAuthorizationCore();
    }
}
