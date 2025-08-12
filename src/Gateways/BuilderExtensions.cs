using Gateways.Adapters;
using Microsoft.Extensions.DependencyInjection;
using UseCases.Ports.Output;

namespace Gateways;

public static class BuilderExtensions
{
    public static void AddGateways(this IServiceCollection services)
    {
        services.AddScoped<IMailGateway, MailGateway>();
        services.AddScoped<IPaymentGateway, PaymentGateway>();
    }
}
