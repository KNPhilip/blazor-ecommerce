using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using DataAccess.Exceptions;
using DataAccess.Data;
using Domain.Models;
using UseCases.Ports.Output;

namespace DataAccess.Adapters;

public sealed class FavoriteRepository(IServiceProvider serviceProvider) : IFavoriteRepository
{
    private readonly IServiceProvider serviceProvider = serviceProvider;

    public async Task<List<Product>> GetFavoritesAsync(string userId)
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EcommerceContext>();

        DbUser user = await dbContext.Users
            .Where(u => u.Id == userId)
            .Include(u => u.Favorites)
            .AsNoTracking()
            .FirstOrDefaultAsync()
                ?? throw new NotFoundException($"Found no users with id \"{userId}\".");

        return user.Favorites;
    }

    public async Task AddToFavoritesAsync(string userId, Product product)
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EcommerceContext>();

        DbUser user = await dbContext.Users
            .Where(u => u.Id == userId)
            .Include(u => u.Favorites)
            .FirstOrDefaultAsync()
                ?? throw new NotFoundException($"Found no users with id \"{userId}\".");

        user.Favorites.Add(product);
        await dbContext.SaveChangesAsync();
    }

    public async Task RemoveFromFavoritesAsync(string userId, Product product)
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EcommerceContext>();

        DbUser user = await dbContext.Users
            .Where(u => u.Id == userId)
            .Include(u => u.Favorites)
            .FirstOrDefaultAsync()
                ?? throw new NotFoundException($"Found no users with id \"{userId}\".");

        user.Favorites.Remove(product);
        await dbContext.SaveChangesAsync();
    }
}
