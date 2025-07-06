using WebUI.Client.Ports;
using UseCases.Ports.Input;
using Domain.Models;

namespace WebUI.Server.Adapters;

public sealed class CategoryUIService(
    ICategoryService categoryService) : ICategoryUIService
{
    private readonly ICategoryService categoryService = categoryService;

    public List<Category> Categories { get; set; } = [];
    public List<Category> AdminCategories { get; set; } = [];

    public event Action? OnChange;

    public async Task GetCategoriesAsync()
    {
        Categories = await categoryService.GetCategoriesAsync();
    }

    public async Task GetAdminCategoriesAsync()
    {
        List<Category>? result =
            await categoryService.GetAdminCategoriesAsync();

        if (result is not null)
        {
            AdminCategories = result ?? [];
        }
    }

    public Category CreateNewCategory()
    {
        Category newCategory = new()
        {
            IsNew = true,
            Editing = true
        };
        AdminCategories.Add(newCategory);
        OnChange?.Invoke();
        return newCategory;
    }

    public async Task CreateCategoryAsync(Category category)
    {
        AdminCategories = await categoryService.CreateCategoryAsync(category);
        await GetCategoriesAsync();
        OnChange?.Invoke();
    }

    public async Task UpdateCategoryAsync(Category category)
    {
        AdminCategories = await categoryService.UpdateCategoryAsync(category);
        await GetCategoriesAsync();
        OnChange?.Invoke();
    }

    public async Task DeleteCategoryByIdAsync(int categoryId)
    {
        AdminCategories = await categoryService.DeleteCategoryAsync(categoryId);
        await GetCategoriesAsync();
        OnChange?.Invoke();
    }
}
