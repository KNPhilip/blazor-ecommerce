using WebUI.Client.Ports;
using WebUI.Server.Adapters;

namespace WebUI.Server.Extensions;

public static class UIServiceExtensions
{
    public static void AddUIServices(this IServiceCollection services)
    {
        services.AddScoped<IAddressUIService, AddressUIService>();
        services.AddScoped<IAuthUIService, AuthUIService>();
        services.AddScoped<ICartUIService, CartUIService>();
        services.AddScoped<ICategoryUIService, CategoryUIService>();
        services.AddScoped<IOrderUIService, OrderUIService>();
        services.AddScoped<IProductUIService, ProductUIService>();
        services.AddScoped<IProductTypeUIService, ProductTypeUIService>();
    }
}
