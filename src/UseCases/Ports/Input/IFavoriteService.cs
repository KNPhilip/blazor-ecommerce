using Domain.Models;

namespace UseCases.Ports.Input;

public interface IFavoriteService
{
    Task<Result<List<Product>>> GetFavoritesAsync();
    Task<Result<bool>> AddToFavoritesAsync(Product product);
    Task<Result<bool>> RemoveFromFavoritesAsync(int productId);
}
