using Domain.Models;

namespace WebUI.Client.Ports;

public interface IProductTypeUIService
{
    event Action OnChange;
    public List<ProductType> ProductTypes { get; set; }
    Task GetProductTypesAsync();
    ProductType CreateNewProductType();
    Task CreateProductTypeAsync(ProductType productType);
    Task UpdateProductTypeAsync(ProductType productType);
    Task DeleteProductTypeByIdAsync(int productTypeId);
}
