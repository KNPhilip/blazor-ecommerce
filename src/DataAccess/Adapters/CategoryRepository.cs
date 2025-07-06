using DataAccess.Data;
using DataAccess.Exceptions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UseCases.Ports.Output;

namespace DataAccess.Adapters;

public sealed class CategoryRepository(IServiceProvider serviceProvider) : ICategoryRepository
{
    private readonly IServiceProvider serviceProvider = serviceProvider;

    public async Task<List<Category>> GetAllCategoriesAsync()
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EcommerceContext>();

        List<Category> categories = await dbContext.Categories
            .Where(x => x.Visible && !x.IsSoftDeleted)
            .AsNoTracking()
            .ToListAsync();

        return categories;
    }

    public async Task<List<Category>> GetAdminCategoriesAsync()
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EcommerceContext>();

        List<Category> categories = await dbContext.Categories
            .Where(x => !x.IsSoftDeleted)
            .AsNoTracking()
            .ToListAsync();

        return categories;
    }

    public async Task CreateCategoryAsync(Category category)
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EcommerceContext>();

        dbContext.Categories.Add(category);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateCategoryAsync(Category category)
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EcommerceContext>();

        Category? dbCategory = await dbContext.Categories.FindAsync(category.Id)
            ?? throw new NotFoundException("The category with the name " +
            $"\"{category.Name}\" was not found in the database.");

        dbCategory.Name = category.Name;
        dbCategory.Url = category.Url;

        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteCategoryByIdAsync(int id)
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EcommerceContext>();

        Category dbCategory = await dbContext.Categories.FindAsync(id)
            ?? throw new NotFoundException("The category with id " +
            $"{id} was not found in the database.");

        dbCategory.IsSoftDeleted = true;
        await dbContext.SaveChangesAsync();
    }
}
