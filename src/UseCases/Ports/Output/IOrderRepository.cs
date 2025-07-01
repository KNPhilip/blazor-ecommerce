using Domain.Models;

namespace UseCases.Ports.Output;

public interface IOrderRepository
{
    Task<Order> GetOrderByIdAsync(string userId, int id);
    Task<List<Order>> GetOrdersByUserIdAsync(string userId);
    Task CreateOrderForUserAsync(string userId, Order order);
}
