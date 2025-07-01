using Microsoft.EntityFrameworkCore;
using DataAccess.Data;
using DataAccess.Exceptions;
using UseCases.Ports.Output;
using Domain.Models;

namespace DataAccess.Adapters;

public sealed class ProductTypeRepository(EcommerceContext dbContext) : IProductTypeRepository
{
    private readonly EcommerceContext dbContext = dbContext;

    public async Task<List<ProductType>> GetAllProductTypesAsync()
    {
        List<ProductType> productTypes = await dbContext.ProductTypes
            .Where(x => !x.IsSoftDeleted)
            .AsNoTracking()
            .ToListAsync();

        return productTypes;
    }

    public async Task CreateProductTypeAsync(ProductType productType)
    {
        ProductType? dbProductType = await dbContext.ProductTypes
            .Where(x => x.Name == productType.Name)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (dbProductType is not null)
        {
            throw new EntityAlreadyExistsException("The product type with the name"
                + $"{productType.Name} already exists in the database.");
        }

        dbProductType = productType;
        dbContext.ProductTypes.Add(dbProductType);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateProductTypeAsync(ProductType productType)
    {
        ProductType dbProductType = await dbContext.ProductTypes
            .Where(x => x.Id == productType.Id)
            .FirstOrDefaultAsync()
                ?? throw new NotFoundException("The product type with"
                + $"the name \"{productType.Name}\" could not be found in the database.");

        dbProductType.Name = productType.Name;

        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteProductTypeByIdAsync(int id)
    {
        ProductType productType = await dbContext.ProductTypes
            .Where(x => x.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync()
                ?? throw new NotFoundException("The product type with the id"
                + $" \"{id}\" could not be found in the database.");

        productType.IsSoftDeleted = true;
        await dbContext.SaveChangesAsync();
    }
}
