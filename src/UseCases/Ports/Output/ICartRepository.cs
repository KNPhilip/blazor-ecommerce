using Domain.Models;

namespace UseCases.Ports.Output;

public interface ICartRepository
{
    Task<List<CartItem>> GetCartItemsForUserAsync(string userId);
    Task<bool> CartItemExistAsync(CartItem cartItem);
    Task CreateCartItemAsync(CartItem cartItem);
    Task CreateCartItemsAsync(List<CartItem> cartItems);
    Task UpdateQuantityAsync(CartItem cartItem);
    Task DeleteCartItemAsync(string userId, int productId, int productTypeId);
}
