using Domain.Models;

namespace UseCases.Ports.Output;

public interface IProductTypeRepository
{
    Task<List<ProductType>> GetAllProductTypesAsync();
    Task CreateProductTypeAsync(ProductType productType);
    Task UpdateProductTypeAsync(ProductType productType);
    Task DeleteProductTypeByIdAsync(int id);
}
