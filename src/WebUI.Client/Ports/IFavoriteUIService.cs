using Domain.Models;

namespace WebUI.Client.Ports;

public interface IFavoriteUIService
{
    List<Product> Favorites { get; set; }
    event Action? OnFavoritesChanged;
    Task GetFavoritesAsync();
    Task AddToFavoritesAsync(Product favorite);
    Task RemoveFromFavoritesAsync(Product favorite);
}
