using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UseCases.Ports.Output;

namespace WebUI.Server.Controllers;

public sealed class PaymentsController(
    IPaymentGateway paymentGateway) : ControllerTemplate
{
    private readonly IPaymentGateway paymentGateway = paymentGateway;

    [HttpPost("checkout"), Authorize]
    public async Task<ActionResult<string>> CreateCheckoutSession()
    {
        try
        {
            string url = await paymentGateway.CreateCheckoutSessionAsync();
            return Ok(url);
        }
        catch
        {
            string url = await paymentGateway.FakeOrderCompletionAsync();
            return Ok(url);
        }
    }

    [HttpPost]
    public async Task<ActionResult<bool>> FulfillOrder() =>
        HandleResult(await paymentGateway.FulfillOrderAsync(Request));
}
