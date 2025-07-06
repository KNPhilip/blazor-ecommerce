using DataAccess.Data;
using DataAccess.Exceptions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UseCases.Ports.Output;

namespace DataAccess.Adapters;

public sealed class CartRepository(IServiceProvider serviceProvider) : ICartRepository
{
    private readonly IServiceProvider serviceProvider = serviceProvider;

    public async Task<List<CartItem>> GetCartItemsForUserAsync(string userId)
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EcommerceContext>();

        List<CartItem> cartItems = await dbContext.CartItems
            .Where(ci => ci.UserId == userId)
            .AsNoTracking()
            .ToListAsync() ?? [];

        return cartItems;
    }

    public async Task<bool> CartItemExistAsync(CartItem cartItem)
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EcommerceContext>();

        CartItem? dbCartItem = await dbContext.CartItems
            .FirstOrDefaultAsync(ci => ci.ProductId == cartItem.ProductId &&
            ci.ProductTypeId == cartItem.ProductTypeId &&
            ci.UserId == cartItem.UserId);

        return dbCartItem is not null;
    }

    public async Task CreateCartItemAsync(CartItem cartItem)
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EcommerceContext>();

        dbContext.CartItems.Add(cartItem);
        await dbContext.SaveChangesAsync();
    }

    public async Task CreateCartItemsAsync(List<CartItem> cartItems)
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EcommerceContext>();

        dbContext.CartItems.AddRange(cartItems);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateQuantityAsync(CartItem cartItem)
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EcommerceContext>();

        CartItem dbCartItem = await dbContext.CartItems
            .FirstOrDefaultAsync(ci => ci.ProductId == cartItem.ProductId &&
            ci.ProductTypeId == cartItem.ProductTypeId &&
            ci.UserId == cartItem.UserId)
                ?? throw new NotFoundException("Cart item does not exist.");

        dbCartItem.Quantity = cartItem.Quantity;
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteCartItemAsync(string userId, int productId, int productTypeId)
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EcommerceContext>();

        CartItem cartItem = await dbContext.CartItems
            .FirstOrDefaultAsync(ci => ci.ProductId == productId &&
            ci.ProductTypeId == productTypeId &&
            ci.UserId == userId)
                ?? throw new NotFoundException("Cart item does not exist.");

        dbContext.CartItems.Remove(cartItem);
        await dbContext.SaveChangesAsync();
    }
}
