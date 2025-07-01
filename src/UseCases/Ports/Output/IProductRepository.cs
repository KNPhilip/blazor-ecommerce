using Domain.Models;

namespace UseCases.Ports.Output;

public interface IProductRepository
{
    Task<List<Product>> GetAllProductsAsync();
    Task<List<Product>> GetAllAdminProductsAsync();
    Task<List<Product>> GetAllFeaturedProductsAsync();
    Task<List<Product>> GetProductsByCategoryAsync(string categoryUrl);
    Task<List<Product>> GetProductsBySearchTermAsync(string searchTerm);
    Task<Product> GetProductByIdAsync(int id);
    Task<Product> GetAdminProductByIdAsync(int id);
    Task CreateProductAsync(Product product);
    Task UpdateProductAsync(Product product);
    Task DeleteProductByIdAsync(int id);
}
