using Domain.Models;

namespace UseCases.Ports.Input;

public interface IProductTypeService
{
    Task<Result<List<ProductType>>> GetProductTypesAsync();
    Task<Result<List<ProductType>>> CreateProductTypeAsync(ProductType productType);
    Task<Result<List<ProductType>>> UpdateProductTypeAsync(ProductType productType);
    Task<Result<List<ProductType>>> DeleteProductTypeByIdAsync(int productTypeId);
}
