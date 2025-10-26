using Domain.Models;
using UseCases.Ports;
using UseCases.Ports.Input;
using UseCases.Ports.Output;

namespace UseCases.Services;

public sealed class FavoriteService(IAuthService authService,
    IFavoriteRepository favoriteRepository, IProductRepository productRepository) : IFavoriteService
{
    public async Task<Result<List<Product>>> GetFavoritesAsync()
    {
        try
        {
            string userId = await authService.GetUserIdAsync();
            List<Product> result = await favoriteRepository.GetFavoritesAsync(userId);
            return result;
        }
        catch (DataAccessException ex)
        {
            return Result.Fail<List<Product>>(ex.Message);
        }
    }

    public async Task<Result<bool>> AddToFavoritesAsync(Product product)
    {
        try
        {
            string userId = await authService.GetUserIdAsync();
            await favoriteRepository.AddToFavoritesAsync(userId, product);
            return true;
        }
        catch (DataAccessException ex)
        {
            return Result.Fail<bool>(ex.Message);
        }
    }

    public async Task<Result<bool>> RemoveFromFavoritesAsync(int productId)
    {
        try
        {
            string userId = await authService.GetUserIdAsync();
            Product product = await productRepository.GetProductByIdAsync(productId);

            await favoriteRepository.RemoveFromFavoritesAsync(userId, product);
            return true;
        }
        catch (DataAccessException ex)
        {
            return Result.Fail<bool>(ex.Message);
        }
    }
}
