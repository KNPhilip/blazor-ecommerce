using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using UseCases.Ports.Input;
using UseCases.Ports.Output;
using Domain.Models;
using Domain.Dtos;
using Stripe.Checkout;
using Stripe;
using Domain.Enums;

namespace UseCases.Services;

public sealed class PaymentService(IConfiguration config, IAuthService authService,
    ICartService cartService, IOrderService orderService) : IPaymentService
{
    private readonly IConfiguration config = config;
    private readonly IAuthService authService = authService;
    private readonly ICartService cartService = cartService;
    private readonly IOrderService orderService = orderService;

    public async Task<Session> CreateCheckoutSessionAsync()
    {
        List<CartProductResponseDto> products = await cartService.GetCartItemsAsync();
        List<SessionLineItemOptions> lineItems = [];
        products?.ForEach(product => lineItems.Add(new()
        {
            PriceData = new()
            {
                UnitAmountDecimal = product.Price * 100,
                Currency = "usd",
                ProductData = new()
                {
                    Name = product.Title,
                    Images = product.Images
                        .Where(x => x.Type == ImageType.Url
                            || x.Type == ImageType.Base64)
                        .Select(x => x.Data)
                        .Take(8)
                        .ToList()
                }
            },
            Quantity = product.Quantity
        }));

        SessionCreateOptions options = new()
        {
            CustomerEmail = authService.GetUserEmail(),
            ShippingAddressCollection = new()
            {
                AllowedCountries = ["DK"]
            },
            PaymentMethodTypes =
            [
                "card"
            ],
            LineItems = lineItems,
            Mode = "payment",
            SuccessUrl = "https://localhost:7240/order-success",
            CancelUrl = "https://localhost:7240/cart"
        };

        SessionService service = new();
        return service.Create(options);
    }

    public async Task<Result<bool>> FulfillOrderAsync(HttpRequest request)
    {
        string json = await new StreamReader(request.Body).ReadToEndAsync();
        try
        {
            Event stripeEvent = EventUtility.ConstructEvent(
                json,
                request.Headers["Stripe-Signature"],
                config["StripeWebhookSecret"]
            );

            if (stripeEvent.Type == Events.CheckoutSessionCompleted)
            {
                Session session = stripeEvent.Data.Object as Session
                    ?? throw new StripeException("The data object for the Stripe event was null.");
                DbUser user = await authService.GetUserByEmailAsync(session.CustomerEmail);
                await orderService.PlaceOrderForEmailAsync(user.Email);
            }
            return true;
        }
        catch (StripeException e)
        {
            return Result.Fail<bool>(e.Message);
        }
    }

    public async Task<string> FakeOrderCompletionAsync()
    {
        string userId = await authService.GetUserIdAsync();
        await orderService.PlaceOrderForEmailAsync(userId);
        return "https://localhost:7240/order-success/fake";
    }
}
