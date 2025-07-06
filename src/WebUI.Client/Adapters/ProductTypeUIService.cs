using System.Net.Http.Json;
using WebUI.Client.Ports;
using Domain.Models;

namespace WebUI.Client.Adapters;

public sealed class ProductTypeUIService(HttpClient http) : IProductTypeUIService
{
    private readonly HttpClient http = http;

    public List<ProductType> ProductTypes { get; set; } = [];

    public event Action? OnChange;

    public async Task GetProductTypesAsync()
    {
        List<ProductType> result = await http
            .GetFromJsonAsync<List<ProductType>>("api/v1/producttypes") ?? [];
        ProductTypes = result;
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
        HttpResponseMessage response = await http.PostAsJsonAsync("api/v1/producttypes", productType);
        ProductTypes = (await response.Content
            .ReadFromJsonAsync<List<ProductType>>())!;
        OnChange?.Invoke();
    }

    public async Task UpdateProductTypeAsync(ProductType productType)
    {
        HttpResponseMessage response = await http
            .PutAsJsonAsync("api/v1/producttypes", productType);
        ProductTypes = await response.Content
            .ReadFromJsonAsync<List<ProductType>>() ?? [];
        OnChange?.Invoke();
    }

    public async Task DeleteProductTypeByIdAsync(int productTypeId)
    {
        HttpResponseMessage response = await http
            .DeleteAsync($"api/v1/producttypes/{productTypeId}");
        ProductTypes = await response.Content
            .ReadFromJsonAsync<List<ProductType>>() ?? [];
        OnChange?.Invoke();
    }
}
