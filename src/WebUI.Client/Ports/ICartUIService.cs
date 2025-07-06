using Domain.Models;
using Domain.Dtos;

namespace WebUI.Client.Ports;

public interface ICartUIService
{
    event Action OnChange;
    Task<List<CartProductResponseDto>> GetCartProductsAsync();
    Task<int> GetCartItemsCountAsync();
    Task AddToCartAsync(CartItem cartItem);
    Task StoreCartItemsAsync(bool emptyLocalCart);
    Task SetCartItemsCountAsync(int count);
    Task SetCartItemsCountAsync();
    Task UpdateQuantityAsync(CartProductResponseDto product);
    Task RemoveProductFromCartAsync(int productId, int productTypeId);
}
