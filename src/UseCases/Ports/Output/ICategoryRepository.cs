using Domain.Models;

namespace UseCases.Ports.Output;

public interface ICategoryRepository
{
    Task<List<Category>> GetAllCategoriesAsync();
    Task<List<Category>> GetAdminCategoriesAsync();
    Task CreateCategoryAsync(Category category);
    Task UpdateCategoryAsync(Category category);
    Task DeleteCategoryByIdAsync(int id);
}
