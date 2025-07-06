using Microsoft.EntityFrameworkCore;
using DataAccess.Data;
using DataAccess.Exceptions;
using UseCases.Ports.Output;
using Domain.Models;

namespace DataAccess.Adapters;

public sealed class ProductRepository(EcommerceContext dbContext) : IProductRepository
{
    private readonly EcommerceContext dbContext = dbContext;

    public async Task<List<Product>> GetAllProductsAsync()
    {
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
        foreach (ProductVariant variant in product.Variants)
        {
            variant.ProductType = null;
        }
        dbContext.Products.Add(product);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateProductAsync(Product product)
    {
        Product dbProduct = await dbContext.Products.FindAsync(product.Id)
            ?? throw new NotFoundException("The product with the id"
                + $" \"{product.Id}\" could not be found in the database.");

        dbContext.Images.RemoveRange(dbProduct.Images);

        dbProduct.Title = product.Title;
        dbProduct.Description = product.Description;
        dbProduct.ImageUrl = product.ImageUrl;
        dbProduct.CategoryId = product.CategoryId;
        dbProduct.Visible = product.Visible;
        dbProduct.Featured = product.Featured;
        dbProduct.Images = product.Images;

        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteProductByIdAsync(int id)
    {
        Product dbProduct = await dbContext.Products.FindAsync(id)
            ?? throw new NotFoundException("The product with the id"
                + $" \"{id}\" could not be found in the database.");

        dbProduct.IsSoftDeleted = true;
        await dbContext.SaveChangesAsync();
    }
}
