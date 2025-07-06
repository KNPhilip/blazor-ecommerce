using WebUI.Client.Ports;
using UseCases.Ports.Input;
using UseCases.Ports.Output;
using Domain.Dtos;

namespace WebUI.Server.Adapters;

public sealed class OrderUIService(IHttpContextAccessor httpContextAccessor, 
    IOrderService orderService, IAuthService authService) : IOrderUIService
{
    private readonly IHttpContextAccessor httpContextAccessor = httpContextAccessor;
    private readonly IOrderService orderService = orderService;
    private readonly IAuthService authService = authService;

    public async Task<List<OrderOverviewDto>> GetOrdersAsync()
    {
        return await orderService.GetOrdersAsync();
    }

    public async Task<OrderDetailsDto> GetOrderDetailsByIdAsync(int orderId)
    {
        return await orderService.GetOrderDetailsAsync(orderId);
    }

    public async Task<string> PlaceOrderAsync()
    {
        if (IsUserAuthenticated())
        {
            string userId = await authService.GetUserIdAsync();
            await orderService.PlaceOrderForEmailAsync(userId);
            return "https://localhost:7240/order-success/fake";
        }
        else
        {
            return "account/login";
        }
    }

    private bool IsUserAuthenticated()
    {
        return httpContextAccessor.HttpContext!.User.Identity!.IsAuthenticated;
    }
}
