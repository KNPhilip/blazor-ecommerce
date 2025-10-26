using Domain.Models;
using UseCases.Ports.Input;
using WebUI.Client.Ports;

namespace WebUI.Server.Adapters;

public sealed class FavoriteUIService(IFavoriteService favoriteService
    ) : IFavoriteUIService
{
    public List<Product> Favorites { get; set; } = [];
    public event Action? OnFavoritesChanged;

    public async Task GetFavoritesAsync()
    {
        var result = await favoriteService.GetFavoritesAsync();
        Favorites = result.Value ?? [];
        OnFavoritesChanged?.Invoke();
    }

    public async Task AddToFavoritesAsync(Product favorite)
    {
        await favoriteService.AddToFavoritesAsync(favorite);
    }

    public async Task RemoveFromFavoritesAsync(Product favorite)
    {
        await favoriteService.RemoveFromFavoritesAsync(favorite.Id);
    }
}
