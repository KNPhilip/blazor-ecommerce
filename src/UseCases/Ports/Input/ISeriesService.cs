using Domain.Models;

namespace UseCases.Ports.Input;

public interface ISeriesService
{
    Task<Result<List<Series>>> GetSeriesAsync();
    Task<Result<Series>> GetSeriesByIdAsync(int id);
    Task<Result<Series>> CreateSeriesAsync(Series series);
    Task<Result<Series>> UpdateSeriesAsync(Series series);
    Task<Result<bool>> DeleteSeriesByIdAsync(int id);
}
