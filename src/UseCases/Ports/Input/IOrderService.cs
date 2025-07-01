using Domain.Dtos;

namespace UseCases.Ports.Input;

public interface IOrderService
{
    Task<Result<List<OrderOverviewDto>>> GetOrdersAsync();
    Task<Result<OrderDetailsDto>> GetOrderDetailsAsync(int orderId);
    Task<Result<bool>> PlaceOrderForEmailAsync(string userId);
}
