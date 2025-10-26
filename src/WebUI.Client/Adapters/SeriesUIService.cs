using System.Net.Http.Json;
using WebUI.Client.Ports;
using Domain.Models;

namespace WebUI.Client.Adapters;

public sealed class SeriesUIService(HttpClient http) : ISeriesUIService
{
    public List<Series> Series { get; set; } = null!;
    public event Action? OnSeriesChanged;

    public async Task GetSeriesAsync()
    {
        Series = await http.GetFromJsonAsync<List<Series>>($"api/v1/series") ?? [];
        OnSeriesChanged?.Invoke();
    }

    public async Task<Series> GetSeriesByIdAsync(int id)
    {
        Series? response = await http.GetFromJsonAsync<Series>($"api/v1/series/{id}");
        return response!;
    }

    public async Task<Series> CreateSeriesAsync(Series series)
    {
        HttpResponseMessage response = await http
            .PostAsJsonAsync("api/v1/series", series);

        return response.Content.ReadFromJsonAsync<Series>().Result!;
    }

    public async Task<Series> UpdateSeriesAsync(Series series)
    {
        HttpResponseMessage response = await http
            .PutAsJsonAsync("api/v1/series", series);

        return response.Content.ReadFromJsonAsync<Series>().Result!;
    }

    public async Task DeleteSeriesByIdAsync(int id)
    {
        await http.DeleteAsync($"api/v1/series/{id}");
    }
}
