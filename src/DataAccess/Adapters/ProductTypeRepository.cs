using DataAccess.Data;
using DataAccess.Exceptions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UseCases.Ports.Output;

namespace DataAccess.Adapters;

public sealed class ProductTypeRepository(IServiceProvider serviceProvider) : IProductTypeRepository
{
    private readonly IServiceProvider serviceProvider = serviceProvider;

    public async Task<List<ProductType>> GetAllProductTypesAsync()
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EcommerceContext>();

        List<ProductType> productTypes = await dbContext.ProductTypes
            .Where(x => !x.IsSoftDeleted)
            .AsNoTracking()
            .ToListAsync();

        return productTypes;
    }

    public async Task CreateProductTypeAsync(ProductType productType)
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EcommerceContext>();

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
        using IServiceScope scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EcommerceContext>();

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
        using IServiceScope scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EcommerceContext>();

        ProductType productType = await dbContext.ProductTypes.FindAsync(id)
            ?? throw new NotFoundException("The product type with the id"
            + $" \"{id}\" could not be found in the database.");

        productType.IsSoftDeleted = true;
        await dbContext.SaveChangesAsync();
    }
}
