using Microsoft.AspNetCore.Http;
using Stripe.Checkout;

namespace UseCases.Ports.Input;

public interface IPaymentService
{
    Task<Session> CreateCheckoutSessionAsync();
    Task<Result<bool>> FulfillOrderAsync(HttpRequest request);
    Task<string> FakeOrderCompletionAsync();
}
