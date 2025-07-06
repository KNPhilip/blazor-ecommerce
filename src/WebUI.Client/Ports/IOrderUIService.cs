using Domain.Dtos;

namespace WebUI.Client.Ports;

public interface IOrderUIService
{
    Task<List<OrderOverviewDto>> GetOrdersAsync();
    Task<OrderDetailsDto> GetOrderDetailsByIdAsync(int orderId);
    Task<string> PlaceOrderAsync();
}
