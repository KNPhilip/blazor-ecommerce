using Microsoft.EntityFrameworkCore;
using DataAccess.Data;
using DataAccess.Exceptions;
using UseCases.Ports.Output;
using Domain.Models;

namespace DataAccess.Adapters;

public sealed class OrderRepository(EcommerceContext dbContext) : IOrderRepository
{
    private readonly EcommerceContext dbContext = dbContext;

    public async Task<List<Order>> GetOrdersByUserIdAsync(string userId)
    {
        List<Order> orders = await GetFullDbOrdersByUserIdAsync(userId);
        return orders ?? [];
    }

    public async Task<Order> GetOrderByIdAsync(string userId, int id)
    {
        Order order = await GetFullDbOrderByIdAsync(userId, id);
        return order;
    }

    public async Task CreateOrderForUserAsync(string userId, Order order)
    {
        dbContext.Orders.Add(order);
        dbContext.CartItems.RemoveRange(dbContext.CartItems
            .Where(ci => ci.UserId == userId));

        await dbContext.SaveChangesAsync();
    }

    private async Task<List<Order>> GetFullDbOrdersByUserIdAsync(string userId)
    {
        return await dbContext.Orders
            .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .ThenInclude(p => p!.Images)
            .Where(x => x.UserId == userId)
            .OrderByDescending(x => x.OrderDate)
            .AsNoTracking()
            .ToListAsync() ?? [];
    }

    private async Task<Order> GetFullDbOrderByIdAsync(string userId, int id)
    {
        return await dbContext.Orders
            .Where(o => o.Id == id)
            .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .ThenInclude(p => p.Images)
            .Include(o => o.OrderItems)
                .ThenInclude(pv => pv.ProductType)
            .Where(x => x.UserId == userId && x.Id == id)
            .OrderByDescending(o => o.OrderDate)
            .AsNoTracking()
            .FirstOrDefaultAsync()
                ?? throw new NotFoundException("The order with the id"
                + $" \"{id}\" could not be found in the database.");
    }
}
