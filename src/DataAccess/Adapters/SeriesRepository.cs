using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using UseCases.Ports.Output;
using DataAccess.Exceptions;
using DataAccess.Data;
using Domain.Models;

namespace DataAccess.Adapters;

public sealed class SeriesRepository(IServiceProvider serviceProvider) : ISeriesRepository
{
    private readonly IServiceProvider serviceProvider = serviceProvider;

    public async Task<List<Series>> GetSeriesAsync()
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EcommerceContext>();

        return await dbContext.Series
            .Include(s => s.Products.Where(p => p.Visible && !p.IsSoftDeleted))
            .ThenInclude(p => p.Images)
            .Include(s => s.Products.Where(p => p.Visible && !p.IsSoftDeleted))
            .ThenInclude(p => p.Variants.Where(v => v.Visible && !v.IsSoftDeleted))
            .AsNoTracking()
            .ToListAsync() ?? [];
    }

    public async Task<Series> GetSeriesByIdAsync(int id)
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EcommerceContext>();

        return await dbContext.Series
            .Where(s => s.Id == id)
            .Include(s => s.Products.Where(p => p.Visible && !p.IsSoftDeleted))
            .ThenInclude(p => p.Images)
            .Include(s => s.Products.Where(p => p.Visible && !p.IsSoftDeleted))
            .ThenInclude(p => p.Variants.Where(v => v.Visible && !v.IsSoftDeleted))
            .AsNoTracking()
            .FirstOrDefaultAsync()
                ?? throw new NotFoundException($"Found no series with id \"{id}\".");
    }

    public async Task CreateSeriesAsync(Series series)
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EcommerceContext>();

        dbContext.Series.Add(series);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateSeriesAsync(Series series)
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EcommerceContext>();

        Series existingSeries = await dbContext.Series.FindAsync(series.Id)
            ?? throw new NotFoundException($"Found no series with id \"{series.Id}\".");

        existingSeries.Name = series.Name;
        existingSeries.Description = series.Description;
        existingSeries.Products = series.Products;

        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteSeriesByIdAsync(int id)
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EcommerceContext>();

        Series series = await dbContext.Series.FindAsync(id)
            ?? throw new NotFoundException($"Found no series with id \"{id}\".");

        dbContext.Series.Remove(series);
        await dbContext.SaveChangesAsync();
    }
}
