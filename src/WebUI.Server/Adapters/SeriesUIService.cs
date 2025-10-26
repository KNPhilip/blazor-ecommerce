using Domain.Models;
using UseCases.Ports.Input;
using UseCases;
using WebUI.Client.Ports;

namespace WebUI.Server.Adapters;

public sealed class SeriesUIService(ISeriesService seriesService) : ISeriesUIService
{
    public List<Series> Series { get; set; } = null!;
    public event Action? OnSeriesChanged;

    public async Task GetSeriesAsync()
    {
        Result<List<Series>> result = await seriesService.GetSeriesAsync();
        Series = result.Value ?? [];
        OnSeriesChanged?.Invoke();
    }

    public async Task<Series> GetSeriesByIdAsync(int id)
    {
        Result<Series> result = await seriesService.GetSeriesByIdAsync(id);
        return result;
    }

    public async Task<Series> CreateSeriesAsync(Series series)
    {
        Result<Series> result = await seriesService.CreateSeriesAsync(series);
        return result;
    }

    public async Task<Series> UpdateSeriesAsync(Series series)
    {
        Result<Series> result = await seriesService.UpdateSeriesAsync(series);
        return result;
    }

    public async Task DeleteSeriesByIdAsync(int id)
    {
        await seriesService.DeleteSeriesByIdAsync(id);
    }
}
