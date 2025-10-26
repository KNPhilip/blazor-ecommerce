using System.Net.Http.Json;
using Domain.Models;
using WebUI.Client.Ports;

namespace WebUI.Client.Adapters;

public sealed class FavoriteUIService(HttpClient http) : IFavoriteUIService
{
    public List<Product> Favorites { get; set; } = [];
    public event Action? OnFavoritesChanged;

    public async Task GetFavoritesAsync()
    {
        Favorites = await http.GetFromJsonAsync<List<Product>>($"api/v1/favorite") ?? [];
        OnFavoritesChanged?.Invoke();
    }

    public async Task AddToFavoritesAsync(Product favorite)
    {
        await http.PostAsJsonAsync($"api/v1/favorite", favorite);
    }

    public async Task RemoveFromFavoritesAsync(Product favorite)
    {
        await http.DeleteAsync($"api/v1/favorite/{favorite.Id}");
    }
}
