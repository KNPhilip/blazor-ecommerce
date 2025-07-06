using WebUI.Client.Ports;
using UseCases.Ports.Input;
using Domain.Models;

namespace WebUI.Server.Adapters;

public sealed class ProductTypeUIService(
    IProductTypeService productTypeService): IProductTypeUIService
{
    private readonly IProductTypeService productTypeService = productTypeService;

    public List<ProductType> ProductTypes { get; set; } = [];

    public event Action? OnChange;

    public async Task GetProductTypesAsync()
    {
        ProductTypes = await productTypeService.GetProductTypesAsync();
    }

    public ProductType CreateNewProductType()
    {
        ProductType newProductType = new()
        {
            IsNew = true,
            Editing = true,
        };

        ProductTypes.Add(newProductType);
        OnChange?.Invoke();
        return newProductType;
    }

    public async Task CreateProductTypeAsync(ProductType productType)
    {
        productType.Editing = productType.IsNew = false;
        ProductTypes = await productTypeService.CreateProductTypeAsync(productType);
        OnChange?.Invoke();
    }

    public async Task UpdateProductTypeAsync(ProductType productType)
    {
        ProductTypes = await productTypeService.UpdateProductTypeAsync(productType);
        OnChange?.Invoke();
    }

    public async Task DeleteProductTypeByIdAsync(int productTypeId)
    {
        ProductTypes = await productTypeService.DeleteProductTypeByIdAsync(productTypeId);
        OnChange?.Invoke();
    }
}
