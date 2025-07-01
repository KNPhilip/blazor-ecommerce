using UseCases.Ports.Input;
using UseCases.Ports.Output;
using UseCases.Ports;
using Domain.Models;

namespace UseCases.Services;

public sealed class CategoryService(ICategoryRepository repository) : ICategoryService
{
    private readonly ICategoryRepository repository = repository;

    public async Task<Result<List<Category>>> GetCategoriesAsync()
    {
        List<Category> categories = await repository.GetAllCategoriesAsync();
        return categories;
    }

    public async Task<Result<List<Category>>> GetAdminCategoriesAsync()
    {
        List<Category> categories = await repository.GetAdminCategoriesAsync();
        return categories;
    }

    public async Task<Result<List<Category>>> CreateCategoryAsync(Category category)
    {
        await repository.CreateCategoryAsync(category);
        return await GetAdminCategoriesAsync();
    }

    public async Task<Result<List<Category>>> UpdateCategoryAsync(Category category)
    {
        try
        {
            await repository.UpdateCategoryAsync(category);
            return await GetAdminCategoriesAsync();
        }
        catch (DataAccessException ex)
        {
            return Result.Fail<List<Category>>(ex.Message);
        }
    }

    public async Task<Result<List<Category>>> DeleteCategoryAsync(int id)
    {
        try
        {
            await repository.DeleteCategoryByIdAsync(id);
            return await GetAdminCategoriesAsync();
        }
        catch (DataAccessException ex)
        {
            return Result.Fail<List<Category>>(ex.Message);
        }
    }
}
