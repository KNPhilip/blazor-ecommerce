using Domain.Models;
using Domain.Dtos;

namespace UseCases.Ports.Input;

public interface ICartService
{
    Task<Result<List<CartProductResponseDto>>> GetCartProductsAsync(List<CartItem> cartItems);
    Task<Result<List<CartProductResponseDto>>> StoreCartItemsAsync(List<CartItem> cartItems);
    Task<Result<int>> GetCartItemsCountAsync();
    Task<Result<List<CartProductResponseDto>>> GetCartItemsAsync(string? userId = null);
    Task<Result<bool>> AddToCartAsync(CartItem cartItem);
    Task<Result<bool>> UpdateQuantityAsync(CartItem cartItem);
    Task<Result<bool>> RemoveItemFromCartAsync(int productId, int productTypeId);
}
