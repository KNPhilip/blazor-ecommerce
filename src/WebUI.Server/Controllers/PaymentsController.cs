using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using UseCases.Ports.Input;

namespace WebUI.Server.Controllers;

public sealed class PaymentsController(
    IPaymentService paymentService) : ControllerTemplate
{
    private readonly IPaymentService paymentService = paymentService;

    [HttpPost("checkout"), Authorize]
    public async Task<ActionResult<string>> CreateCheckoutSession()
    {
        try
        {
            Session session = await paymentService.CreateCheckoutSessionAsync();
            return Ok(session.Url);
        }
        catch
        {
            string url = await paymentService.FakeOrderCompletionAsync();
            return Ok(url);
        }
    }

    [HttpPost]
    public async Task<ActionResult<bool>> FulfillOrder() =>
        HandleResult(await paymentService.FulfillOrderAsync(Request));
}
