using Domain.Dtos;
using Domain.Enums;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Stripe;
using Stripe.Checkout;
using UseCases;
using UseCases.Ports.Input;
using UseCases.Ports.Output;

namespace Gateways.Adapters;

public sealed class StripeGateway(IConfiguration config, IAuthService authService,
    ICartService cartService, IOrderService orderService) : IPaymentGateway
{
    private readonly IConfiguration config = config;
    private readonly IAuthService authService = authService;
    private readonly ICartService cartService = cartService;
    private readonly IOrderService orderService = orderService;

    public async Task<string> CreateCheckoutSessionAsync()
    {
        List<CartProductResponseDto>? products = await cartService.GetCartItemsAsync();
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
        Session session = service.Create(options);
        return session.Url;
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

                if (user.Email is null)
                {
                    return false;
                }
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
