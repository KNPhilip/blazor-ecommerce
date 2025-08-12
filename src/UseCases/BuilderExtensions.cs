using Microsoft.Extensions.DependencyInjection;
using UseCases.Ports.Input;
using UseCases.Services;

namespace UseCases;

public static class BuilderExtensions
{
    public static void AddUseCases(this IServiceCollection services)
    {
        services.AddScoped<IAddressService, AddressService>();
        services.AddScoped<ICartService, CartService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IProductTypeService, ProductTypeService>();
    }
}
