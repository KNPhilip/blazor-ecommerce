using Domain.Models;

namespace WebUI.Client.Ports;

public interface ISeriesUIService
{
    List<Series> Series { get; set; }
    event Action? OnSeriesChanged;
    Task GetSeriesAsync();
    Task<Series> GetSeriesByIdAsync(int id);
    Task<Series> CreateSeriesAsync(Series series);
    Task<Series> UpdateSeriesAsync(Series series);
    Task DeleteSeriesByIdAsync(int id);
}
