using DataAccess.Data;
using DataAccess.Exceptions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UseCases.Ports.Output;

namespace DataAccess.Adapters;

public sealed class ProductVariantRepository(IServiceProvider serviceProvider) : IProductVariantRepository
{
    private readonly IServiceProvider serviceProvider = serviceProvider;

    public async Task<ProductVariant> GetProductVariantAsync(int productId, int productTypeId)
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EcommerceContext>();

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
        using IServiceScope scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EcommerceContext>();

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
