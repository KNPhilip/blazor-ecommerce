using Domain.Models;

namespace WebUI.Client.Components.Admin;

public sealed partial class Categories
{
    Category? editingCategory = null;

    protected override async Task OnInitializedAsync()
    {
        await CategoryUIService.GetAdminCategoriesAsync();
        CategoryUIService.OnChange += StateHasChanged;
    }

    public void Dispose()
    {
        CategoryUIService.OnChange -= StateHasChanged;
    }

    private void CreateNewCategory()
    {
        editingCategory = CategoryUIService.CreateNewCategory();
    }

    private void EditCategory(Category category)
    {
        category.Editing = true;
        editingCategory = category;
    }

    private async Task CreateOrUpdateCategoryAsync()
    {
        if (editingCategory!.IsNew)
        {
            await CategoryUIService.CreateCategoryAsync(editingCategory);
        }
        else
        {
            await CategoryUIService.UpdateCategoryAsync(editingCategory);
        }

        editingCategory = null;
    }

    private async Task CancelEditingAsync()
    {
        await CategoryUIService.GetAdminCategoriesAsync();
        editingCategory = null;
    }

    private async Task DeleteCategoryByIdAsync(int id)
    {
        await CategoryUIService.DeleteCategoryByIdAsync(id);
    }
}
