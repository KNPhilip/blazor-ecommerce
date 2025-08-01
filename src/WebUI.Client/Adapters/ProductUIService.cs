﻿using System.Net.Http.Json;
using WebUI.Client.Ports;
using Domain.Models;
using Domain.Dtos;

namespace WebUI.Client.Adapters;

public sealed class ProductUIService(HttpClient http) : IProductUIService
{
    private readonly HttpClient http = http;

    public List<Product> Products { get; set; } = [];
    public List<Product> AdminProducts { get; set; } = [];
    public string Message { get; set; } = string.Empty;
    public int CurrentPage { get; set; } = 1;
    public int PageCount { get; set; } = 0;
    public string LastSearchTerm { get; set; } = string.Empty;

    public event Action? OnProductsChanged;

    public async Task GetProductsAsync(string? categoryUrl = null)
    {
        List<Product>? result = categoryUrl is null
            ? await http.GetFromJsonAsync<List<Product>>
                ("api/v1/products/featured")
            : await http.GetFromJsonAsync<List<Product>>
                ($"api/v1/products/category/{categoryUrl}");

        if (result is not null)
        {
            Products = result;
        }

        CurrentPage = 1;
        PageCount = 0;

        if (Products.Count == 0)
        {
            Message = "No products found.";
        }

        OnProductsChanged?.Invoke();
    }

    public async Task GetAdminProductsAsync()
    {
        List<Product> result = await http
            .GetFromJsonAsync<List<Product>>("api/v1/products/admin")
                ?? [];
        AdminProducts = result!;
        CurrentPage = 1;
        PageCount = 0;
        if (AdminProducts!.Count == 0)
        {
            Message = "No products found.";
        }
    }

    public async Task<Product?> GetProductByIdAsync(int productId)
    {
        return await http
            .GetFromJsonAsync<Product?>($"api/v1/products/{productId}");
    }

    public async Task<List<string>> GetProductSearchSuggestionsAsync(string searchTerm)
    {
        List<string> result = await http.GetFromJsonAsync<List<string>>
            ($"api/v1/products/search-suggestions/{searchTerm}") ?? [];

        return result;
    }

    public async Task SearchProductsAsync(string searchTerm, int page)
    {
        LastSearchTerm = searchTerm;

        ProductSearchResultDto? result = await http
            .GetFromJsonAsync<ProductSearchResultDto>
                ($"api/v1/products/search/{searchTerm}/{page}");

        if (result is not null)
        {
            Products = result.Products;
            CurrentPage = result.CurrentPage;
            PageCount = result.Pages;
        }
        if (Products.Count == 0)
        {
            Message = "No products found.";
        }
        OnProductsChanged?.Invoke();
    }

    public async Task<Product> CreateProductAsync(Product product)
    {
        HttpResponseMessage result = await http
            .PostAsJsonAsync("api/v1/products", product);
        Product? newProduct = await result.Content
            .ReadFromJsonAsync<Product>();

        return newProduct!;
    }

    public async Task<Product?> UpdateProductAsync(Product product)
    {
        HttpResponseMessage result = await http
            .PutAsJsonAsync($"api/v1/products", product);
        return await result.Content
            .ReadFromJsonAsync<Product>();
    }

    public async Task DeleteProductAsync(Product product)
    {
        await http
            .DeleteAsync($"api/v1/products/{product.Id}");
    }
}
