using Domain.Models;

namespace WebUI.Client.Components.Admin;

public sealed partial class ProductTypes
{
    ProductType? editingProductType = null;

    protected override async Task OnInitializedAsync()
    {
        await ProductTypeUIService.GetProductTypesAsync();
        ProductTypeUIService.OnChange += StateHasChanged;
    }

    public void Dispose()
    {
        ProductTypeUIService.OnChange -= StateHasChanged;
    }

    private void EditProductType(ProductType productType)
    {
        productType.Editing = true;
        editingProductType = productType;
    }

    private void CreateNewProductType()
    {
        editingProductType = ProductTypeUIService.CreateNewProductType();
    }

    private async Task CancelEditingAsync()
    {
        await ProductTypeUIService.GetProductTypesAsync();
        editingProductType = null;
    }

    private async Task CreateOrUpdateProductTypeAsync()
    {
        if (editingProductType!.IsNew)
        {
            await ProductTypeUIService.CreateProductTypeAsync(editingProductType);
        }
        else
        {
            await ProductTypeUIService.UpdateProductTypeAsync(editingProductType);
        }
        editingProductType = null;
    }

    private async Task DeleteProductTypeByIdAsync(int productTypeId)
    {
        await ProductTypeUIService.DeleteProductTypeByIdAsync(productTypeId);
    }
}
