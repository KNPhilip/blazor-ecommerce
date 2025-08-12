using Microsoft.AspNetCore.Http;

namespace UseCases.Ports.Output;

public interface IPaymentGateway
{
    Task<string> CreateCheckoutSessionAsync();
    Task<Result<bool>> FulfillOrderAsync(HttpRequest request);
    Task<string> FakeOrderCompletionAsync();
}
