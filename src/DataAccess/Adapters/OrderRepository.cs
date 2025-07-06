using DataAccess.Data;
using DataAccess.Exceptions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UseCases.Ports.Output;

namespace DataAccess.Adapters;

public sealed class OrderRepository(IServiceProvider serviceProvider) : IOrderRepository
{
    private readonly IServiceProvider serviceProvider = serviceProvider;

    public async Task<List<Order>> GetOrdersByUserIdAsync(string userId)
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EcommerceContext>();

        List<Order> orders = await GetFullDbOrdersByUserIdAsync(userId);
        return orders ?? [];
    }

    public async Task<Order> GetOrderByIdAsync(string userId, int id)
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EcommerceContext>();

        Order order = await GetFullDbOrderByIdAsync(userId, id);
        return order;
    }

    public async Task CreateOrderForUserAsync(string userId, Order order)
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EcommerceContext>();

        dbContext.Orders.Add(order);
        dbContext.CartItems.RemoveRange(dbContext.CartItems
            .Where(ci => ci.UserId == userId));

        await dbContext.SaveChangesAsync();
    }

    private async Task<List<Order>> GetFullDbOrdersByUserIdAsync(string userId)
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EcommerceContext>();

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
        using IServiceScope scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EcommerceContext>();

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
