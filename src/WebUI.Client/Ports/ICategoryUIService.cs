using Domain.Models;

namespace WebUI.Client.Ports;

public interface ICategoryUIService
{
    event Action OnChange;
    List<Category> Categories { get; set; }
    List<Category> AdminCategories { get; set; }
    Task GetCategoriesAsync();
    Task GetAdminCategoriesAsync();
    Category CreateNewCategory();
    Task CreateCategoryAsync(Category category);
    Task UpdateCategoryAsync(Category category);
    Task DeleteCategoryByIdAsync(int categoryId);
}
