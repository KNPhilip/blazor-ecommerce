using Domain.Models;

namespace UseCases.Ports.Output;

public interface IFavoriteRepository
{
    Task<List<Product>> GetFavoritesAsync(string userId);
    Task AddToFavoritesAsync(string userId, Product product);
    Task RemoveFromFavoritesAsync(string userId, Product product);
}
