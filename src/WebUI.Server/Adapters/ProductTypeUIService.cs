using WebUI.Client.Ports;
using UseCases.Ports.Input;
using Domain.Models;

namespace WebUI.Server.Adapters;

public sealed class ProductTypeUIService(
    IProductTypeService productTypeService)
    : IProductTypeUIService
{
    public List<ProductType> ProductTypes { get; set; } = [];

    public event Action? OnChange;

    public async Task AddProductType(ProductType productType)
    {
        productType.Editing = productType.IsNew = false;
        ProductTypes = await productTypeService.CreateProductTypeAsync(productType);
        OnChange!.Invoke();
    }

    public ProductType CreateNewProductType()
    {
        ProductType newProductType = new()
        {
            IsNew = true,
            Editing = true,
        };

        ProductTypes.Add(newProductType);
        OnChange!.Invoke();
        return newProductType;
    }

    public async Task DeleteProductType(int productTypeId)
    {
        ProductTypes = await productTypeService.DeleteProductTypeByIdAsync(productTypeId);
        OnChange!.Invoke();
    }

    public async Task GetProductTypes()
    {
        ProductTypes = await productTypeService.GetProductTypesAsync();
    }

    public async Task UpdateProductType(ProductType productType)
    {
        ProductTypes = await productTypeService.UpdateProductTypeAsync(productType);
        OnChange!.Invoke();
    }
}
