using Domain.Dtos;

namespace WebUI.Client.Ports;

public interface IOrderUIService
{
    Task<string> PlaceOrder();
    Task<List<OrderOverviewDto>> GetOrders();
    Task<OrderDetailsDto> GetOrderDetails(int orderId);
}
