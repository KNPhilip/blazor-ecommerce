using Domain.Models;

namespace UseCases.Ports.Input;

public interface ICategoryService
{
    Task<Result<List<Category>>> GetCategoriesAsync();
    Task<Result<List<Category>>> GetAdminCategoriesAsync();
    Task<Result<List<Category>>> CreateCategoryAsync(Category category);
    Task<Result<List<Category>>> UpdateCategoryAsync(Category category);
    Task<Result<List<Category>>> DeleteCategoryAsync(int categoryId);
}
