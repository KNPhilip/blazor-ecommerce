using Microsoft.EntityFrameworkCore;
using DataAccess.Data;
using DataAccess.Exceptions;
using UseCases.Ports.Output;
using Domain.Models;

namespace DataAccess.Adapters;

public sealed class CartRepository(EcommerceContext dbContext) : ICartRepository
{
    private readonly EcommerceContext dbContext = dbContext;

    public async Task<List<CartItem>> GetCartItemsForUserAsync(string userId)
    {
        List<CartItem> cartItems = await dbContext.CartItems
            .Where(ci => ci.UserId == userId)
            .AsNoTracking()
            .ToListAsync() ?? [];

        return cartItems;
    }

    public async Task<bool> CartItemExistAsync(CartItem cartItem)
    {
        CartItem? dbCartItem = await dbContext.CartItems
            .FirstOrDefaultAsync(ci => ci.ProductId == cartItem.ProductId &&
            ci.ProductTypeId == cartItem.ProductTypeId &&
            ci.UserId == cartItem.UserId);

        return dbCartItem is not null;
    }

    public async Task CreateCartItemAsync(CartItem cartItem)
    {
        dbContext.CartItems.Add(cartItem);
        await dbContext.SaveChangesAsync();
    }

    public async Task CreateCartItemsAsync(List<CartItem> cartItems)
    {
        dbContext.CartItems.AddRange(cartItems);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateQuantityAsync(CartItem cartItem)
    {
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
        CartItem cartItem = await dbContext.CartItems
            .FirstOrDefaultAsync(ci => ci.ProductId == productId &&
            ci.ProductTypeId == productTypeId &&
            ci.UserId == userId)
                ?? throw new NotFoundException("Cart item does not exist.");

        dbContext.CartItems.Remove(cartItem);
        await dbContext.SaveChangesAsync();
    }
}
