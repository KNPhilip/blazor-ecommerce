using Microsoft.EntityFrameworkCore;
using DataAccess.Exceptions;
using DataAccess.Data;
using UseCases.Ports.Output;
using Domain.Models;

namespace DataAccess.Adapters;

public sealed class ProductVariantRepository(EcommerceContext dbContext) : IProductVariantRepository
{
    private readonly EcommerceContext dbContext = dbContext;

    public async Task<ProductVariant> GetProductVariantAsync(int productId, int productTypeId)
    {
        ProductVariant productVariant = await dbContext.ProductVariants
            .Where(v => v.ProductId == productId && v.ProductTypeId == productTypeId)
            .Include(v => v.ProductType)
            .AsNoTracking()
            .FirstOrDefaultAsync()
                ?? throw new NotFoundException("The product variant with the product id " +
                    $"\"{productId}\" and the product type id \"{productTypeId}\" " +
                    "was not found in the database.");

        return productVariant;
    }

    public async Task UpdateProductVariantAsync(ProductVariant productVariant)
    {
        ProductVariant? dbProductVariant = await dbContext.ProductVariants
            .SingleOrDefaultAsync(x => x.ProductId == productVariant.ProductId
            && x.ProductTypeId == productVariant.ProductTypeId);

        if (dbProductVariant is null)
        {
            productVariant.ProductType = null;
            dbContext.ProductVariants.Add(productVariant);
        }
        else
        {
            dbProductVariant.ProductTypeId = productVariant.ProductTypeId;
            dbProductVariant.Price = productVariant.Price;
            dbProductVariant.OriginalPrice = productVariant.OriginalPrice;
            dbProductVariant.Visible = productVariant.Visible;
            dbProductVariant.IsSoftDeleted = productVariant.IsSoftDeleted;
        }
        await dbContext.SaveChangesAsync();
    }
}
