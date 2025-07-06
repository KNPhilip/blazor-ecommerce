using System.Net.Http.Json;
using WebUI.Client.Ports;
using Domain.Models;

namespace WebUI.Client.Adapters;

public sealed class CategoryUIService(HttpClient http)
    : ICategoryUIService
{
    private readonly HttpClient http = http;

    public List<Category> Categories { get; set; } = [];
    public List<Category> AdminCategories { get; set; } = [];

    public event Action? OnChange;

    public async Task GetCategoriesAsync()
    {
        Categories = await http
            .GetFromJsonAsync<List<Category>>
                ("api/v1/categories") ?? [];
    }

    public async Task GetAdminCategoriesAsync()
    {
        List<Category>? response = await http
            .GetFromJsonAsync<List<Category>>
                ("api/v1/categories/admin");

        if (response is not null)
        {
            AdminCategories = response;
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
        HttpResponseMessage response = await http
            .PostAsJsonAsync("api/v1/categories", category);
        AdminCategories = (await response.Content
            .ReadFromJsonAsync<List<Category>>())!;
        await GetCategoriesAsync();
        OnChange?.Invoke();
    }

    public async Task UpdateCategoryAsync(Category category)
    {
        HttpResponseMessage response = await http
            .PutAsJsonAsync("api/v1/categories", category);
        AdminCategories = (await response.Content
            .ReadFromJsonAsync<List<Category>>())!;
        await GetCategoriesAsync();
        OnChange?.Invoke();
    }

    public async Task DeleteCategoryByIdAsync(int categoryId)
    {
        HttpResponseMessage response = await http
            .DeleteAsync($"api/v1/categories/{categoryId}");
        AdminCategories = (await response.Content
            .ReadFromJsonAsync<List<Category>>())!;
        await GetCategoriesAsync();
        OnChange?.Invoke();
    }
}
