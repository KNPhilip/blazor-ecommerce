using Domain.Models;

namespace WebUI.Client.Ports;

public interface IProductUIService
{
    event Action OnProductsChanged;
    List<Product> Products { get; set; }
    List<Product> AdminProducts { get; set; }
    string Message { get; set; }
    int CurrentPage { get; set; }
    int PageCount { get; set; }
    string LastSearchTerm { get; set; }
    Task GetProductsAsync(string? categoryUrl = null);
    Task GetAdminProductsAsync();
    Task<Product?> GetProductByIdAsync(int productId);
    Task<List<string>> GetProductSearchSuggestionsAsync(string searchTerm);
    Task SearchProductsAsync(string searchTerm, int page);
    Task<Product> CreateProductAsync(Product product);
    Task<Product?> UpdateProductAsync(Product product);
    Task DeleteProductAsync(Product product);
}
