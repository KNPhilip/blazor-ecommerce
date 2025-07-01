using WebUI.Client.Ports;
using UseCases.Ports.Input;
using Domain.Models;

namespace WebUI.Server.Adapters;

public sealed class CategoryUIService(
    ICategoryService categoryService)
    : ICategoryUIService
{
    public List<Category> Categories { get; set; } = [];
    public List<Category> AdminCategories { get; set; } = [];

    public event Action? OnChange;

    public async Task GetCategories()
    {
        Categories = await categoryService.GetCategoriesAsync();
    }

    public async Task AddCategory(Category category)
    {
        AdminCategories = await categoryService.CreateCategoryAsync(category);
        await GetCategories();
        OnChange!.Invoke();
    }

    public Category CreateNewCategory()
    {
        Category newCategory = new()
        {
            IsNew = true,
            Editing = true
        };
        AdminCategories.Add(newCategory);
        OnChange!.Invoke();
        return newCategory;
    }

    public async Task DeleteCategory(int categoryId)
    {
        AdminCategories = await categoryService.DeleteCategoryAsync(categoryId);
        await GetCategories();
        OnChange!.Invoke();
    }

    public async Task GetAdminCategories()
    {
        List<Category>? result =
            await categoryService.GetAdminCategoriesAsync();

        if (result is not null)
        {
            AdminCategories = result ?? [];
        }
    }

    public async Task UpdateCategory(Category category)
    {
        AdminCategories = await categoryService.UpdateCategoryAsync(category);
        await GetCategories();
        OnChange!.Invoke();
    }
}
