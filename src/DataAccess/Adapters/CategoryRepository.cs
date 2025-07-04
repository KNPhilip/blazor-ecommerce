using Microsoft.EntityFrameworkCore;
using DataAccess.Data;
using DataAccess.Exceptions;
using UseCases.Ports.Output;
using Domain.Models;

namespace DataAccess.Adapters;

public sealed class CategoryRepository(EcommerceContext dbContext) : ICategoryRepository
{
    private readonly EcommerceContext dbContext = dbContext;

    public async Task<List<Category>> GetAllCategoriesAsync()
    {
        List<Category> categories = await dbContext.Categories
            .Where(x => x.Visible && !x.IsSoftDeleted)
            .AsNoTracking()
            .ToListAsync();

        return categories;
    }

    public async Task<List<Category>> GetAdminCategoriesAsync()
    {
        List<Category> categories = await dbContext.Categories
            .Where(x => !x.IsSoftDeleted)
            .AsNoTracking()
            .ToListAsync();

        return categories;
    }

    public async Task CreateCategoryAsync(Category category)
    {
        dbContext.Categories.Add(category);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateCategoryAsync(Category category)
    {
        Category? dbCategory = await dbContext.Categories.FindAsync(category.Id)
            ?? throw new NotFoundException("The category with the name " +
            $"\"{category.Name}\" was not found in the database.");

        dbCategory.Name = category.Name;
        dbCategory.Url = category.Url;

        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteCategoryByIdAsync(int id)
    {
        Category dbCategory = await dbContext.Categories.FindAsync(id)
            ?? throw new NotFoundException("The category with id " +
            $"{id} was not found in the database.");

        dbCategory.IsSoftDeleted = true;
        await dbContext.SaveChangesAsync();
    }
}
