using UseCases.Ports.Output;
using UseCases.Ports.Input;
using UseCases.Ports;
using Domain.Models;

namespace UseCases.Services;

public sealed class SeriesService(ISeriesRepository seriesRepository) : ISeriesService
{
    private readonly ISeriesRepository seriesRepository = seriesRepository;

    public async Task<Result<List<Series>>> GetSeriesAsync()
    {
        try
        {
            List<Series> result = await seriesRepository.GetSeriesAsync();
            return result;
        }
        catch (DataAccessException ex)
        {
            return Result.Fail<List<Series>>(ex.Message);
        }
    }

    public async Task<Result<Series>> GetSeriesByIdAsync(int id)
    {
        try
        {
            Series result = await seriesRepository.GetSeriesByIdAsync(id);
            return result;
        }
        catch (DataAccessException ex)
        {
            return Result.Fail<Series>(ex.Message);
        }
    }

    public async Task<Result<Series>> CreateSeriesAsync(Series series)
    {
        try
        {
            await seriesRepository.CreateSeriesAsync(series);
            return await seriesRepository.GetSeriesByIdAsync(series.Id);
        }
        catch (DataAccessException ex)
        {
            return Result.Fail<Series>(ex.Message);
        }
    }

    public async Task<Result<Series>> UpdateSeriesAsync(Series series)
    {
        try
        {
            await seriesRepository.UpdateSeriesAsync(series);
            return await seriesRepository.GetSeriesByIdAsync(series.Id);
        }
        catch (DataAccessException ex)
        {
            return Result.Fail<Series>(ex.Message);
        }
    }

    public async Task<Result<bool>> DeleteSeriesByIdAsync(int id)
    {
        try
        {
            await seriesRepository.DeleteSeriesByIdAsync(id);
            return true;
        }
        catch (DataAccessException ex)
        {
            return Result.Fail<bool>(ex.Message);
        }
    }
}
