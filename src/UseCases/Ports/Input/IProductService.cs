using Domain.Models;
using Domain.Dtos;

namespace UseCases.Ports.Input;

public interface IProductService
{
    Task<Result<List<Product>>> GetProductsAsync();
    Task<Result<Product>> GetProductByIdAsync(int productId);
    Task<Result<List<Product>>> GetProductsByCategoryAsync(string categoryUrl);
    Task<Result<ProductSearchResultDto>> SearchProductsAsync(string searchText, int page);
    Task<Result<List<string>>> GetProductSearchSuggestionsAsync(string searchText);
    Task<Result<List<Product>>> GetFeaturedProductsAsync();
    Task<Result<List<Product>>> GetAdminProductsAsync();
    Task<Result<Product>> CreateProductAsync(Product product);
    Task<Result<Product>> UpdateProductAsync(Product product);
    Task<Result<bool>> DeleteProductByIdAsync(int productId);
}
