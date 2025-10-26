using Domain.Models;

namespace UseCases.Ports.Output;

public interface ISeriesRepository
{
    Task<List<Series>> GetSeriesAsync();
    Task<Series> GetSeriesByIdAsync(int id);
    Task CreateSeriesAsync(Series series);
    Task UpdateSeriesAsync(Series series);
    Task DeleteSeriesByIdAsync(int id);
}
