using UseCases.Ports.Input;
using UseCases.Ports.Output;
using Domain.Models;

namespace UseCases.Services;

public sealed class ProductTypeService(IProductTypeRepository repository) : IProductTypeService
{
    private readonly IProductTypeRepository repository = repository;

    public async Task<Result<List<ProductType>>> GetProductTypesAsync()
    {
        return await repository.GetAllProductTypesAsync();
    }

    public async Task<Result<List<ProductType>>> CreateProductTypeAsync(ProductType productType)
    {
        await repository.CreateProductTypeAsync(productType);
        return await GetProductTypesAsync();
    }

    public async Task<Result<List<ProductType>>> UpdateProductTypeAsync(ProductType productType)
    {
        await repository.UpdateProductTypeAsync(productType);
        return await GetProductTypesAsync();
    }

    public async Task<Result<List<ProductType>>> DeleteProductTypeByIdAsync(int productTypeId)
    {
        await repository.DeleteProductTypeByIdAsync(productTypeId);
        return await GetProductTypesAsync();
    }
}
