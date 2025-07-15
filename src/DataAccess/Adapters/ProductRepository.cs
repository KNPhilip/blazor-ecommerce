using DataAccess.Data;
using DataAccess.Exceptions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UseCases.Ports.Output;

namespace DataAccess.Adapters;

public sealed class ProductRepository(IServiceProvider serviceProvider) : IProductRepository
{
    private readonly IServiceProvider serviceProvider = serviceProvider;

    public async Task<List<Product>> GetAllProductsAsync()
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EcommerceContext>();

        List<Product> products = await dbContext.Products
            .Where(x => x.Visible && !x.IsSoftDeleted)
            .Include(x => x.Images)
            .Include(x => x.Category)
            .Include(x => x.Variants.Where(x => x.Visible && !x.IsSoftDeleted))
            .AsNoTracking()
            .ToListAsync();

        return products;
    }

    public async Task<List<Product>> GetAllAdminProductsAsync()
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EcommerceContext>();

        List<Product> products = await dbContext.Products
            .Where(x => !x.IsSoftDeleted)
            .Include(x => x.Variants.Where(x => !x.IsSoftDeleted))
                .ThenInclude(x => x.ProductType)
            .Include(x => x.Images)
            .Include(x => x.Category)
            .AsNoTracking()
            .ToListAsync();

        return products;
    }

    public async Task<List<Product>> GetAllFeaturedProductsAsync()
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EcommerceContext>();

        List<Product> products = await dbContext.Products
            .Where(x => x.Featured && x.Visible && !x.IsSoftDeleted)
            .Include(x => x.Variants.Where(x => x.Visible && !x.IsSoftDeleted))
            .Include(x => x.Images)
            .AsNoTracking()
            .ToListAsync();

        return products;
    }

    public async Task<List<Product>> GetProductsByCategoryAsync(string categoryUrl)
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EcommerceContext>();

        List<Product> products = await dbContext.Products
            .Where(x => x.Visible && !x.IsSoftDeleted && x.Category!.Url!
                .ToLower().Equals(categoryUrl.ToLower()))
            .Include(x => x.Variants)
            .Include(x => x.Images)
            .Include(x => x.Category)
            .AsNoTracking()
            .ToListAsync();

        return products;
    }

    public async Task<List<Product>> GetProductsBySearchTermAsync(string searchTerm)
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EcommerceContext>();

        List<Product> products = await dbContext.Products
            .Where(p => p.Title.ToLower().Contains(searchTerm.ToLower()) ||
                                    p.Description.ToLower().Contains(searchTerm.ToLower()) &&
                                    p.Visible && !p.IsSoftDeleted)
            .Include(x => x.Variants)
            .AsNoTracking()
            .ToListAsync();

        return products;
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EcommerceContext>();

        Product? product = await dbContext.Products
            .Include(x => x.Variants.Where(x => x.Visible && !x.IsSoftDeleted))
                .ThenInclude(x => x.ProductType)
            .Include(x => x.Images)
            .Include(x => x.Category)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new NotFoundException("The product with the id"
                + $" \"{id}\" could not be found in the database.");

        return product;
    }

    public async Task<Product> GetAdminProductByIdAsync(int id)
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EcommerceContext>();

        Product? product = await dbContext.Products
            .Include(x => x.Variants.Where(x => !x.IsSoftDeleted))
                .ThenInclude(x => x.ProductType)
            .Include(x => x.Images)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new NotFoundException("The product with the id"
                + $" \"{id}\" could not be found in the database.");

        return product;
    }

    public async Task CreateProductAsync(Product product)
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EcommerceContext>();

        foreach (ProductVariant variant in product.Variants)
        {
            variant.ProductType = null;
        }
        dbContext.Products.Add(product);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateProductAsync(Product product)
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EcommerceContext>();

        Product dbProduct = await dbContext.Products
            .Include(x => x.Images)
            .FirstOrDefaultAsync(x => x.Id == product.Id)
                ?? throw new NotFoundException("The product with the id"
                    + $" \"{product.Id}\" could not be found in the database.");

        dbContext.Images.RemoveRange(dbProduct.Images);

        dbProduct.Title = product.Title;
        dbProduct.Description = product.Description;
        dbProduct.CategoryId = product.CategoryId;
        dbProduct.Visible = product.Visible;
        dbProduct.Featured = product.Featured;
        dbProduct.Images = product.Images;

        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteProductByIdAsync(int id)
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EcommerceContext>();

        Product dbProduct = await dbContext.Products.FindAsync(id)
            ?? throw new NotFoundException("The product with the id"
                + $" \"{id}\" could not be found in the database.");

        dbProduct.IsSoftDeleted = true;
        await dbContext.SaveChangesAsync();
    }
}
