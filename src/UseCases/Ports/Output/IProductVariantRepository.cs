using Domain.Models;

namespace UseCases.Ports.Output;

public interface IProductVariantRepository
{
    Task<ProductVariant> GetProductVariantAsync(int productId, int productTypeId);
    Task UpdateProductVariantAsync(ProductVariant productVariant);
}
