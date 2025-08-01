﻿using WebUI.Client.Ports;
using UseCases.Ports.Input;
using Domain.Models;
using Domain.Dtos;

namespace WebUI.Server.Adapters;

public sealed class ProductUIService(
    IProductService productService) : IProductUIService
{
    private readonly IProductService productService = productService;

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
            ? await productService.GetFeaturedProductsAsync()
            : await productService.GetProductsByCategoryAsync(categoryUrl);

        if (result is not null)
        {
            Products = result ?? [];
        }

        CurrentPage = 1;
        PageCount = 0;

        if (Products.Count == 0)
            Message = "No products found.";

        OnProductsChanged?.Invoke();
    }

    public async Task GetAdminProductsAsync()
    {
        AdminProducts = await productService.GetAdminProductsAsync();
        CurrentPage = 1;
        PageCount = 0;
        if (AdminProducts!.Count == 0)
        {
            Message = "No products found.";
        }
    }

    public async Task<Product?> GetProductByIdAsync(int productId)
    {
        return await productService.GetProductByIdAsync(productId);
    }

    public async Task<List<string>> GetProductSearchSuggestionsAsync(string searchTerm)
    {
        return await productService.GetProductSearchSuggestionsAsync(searchTerm);
    }

    public async Task SearchProductsAsync(string searchTerm, int page)
    {
        LastSearchTerm = searchTerm;

        ProductSearchResultDto? result = await productService
            .SearchProductsAsync(searchTerm, page);

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
        return await productService.CreateProductAsync(product);
    }

    public async Task<Product?> UpdateProductAsync(Product product)
    {
        return await productService.UpdateProductAsync(product);
    }

    public async Task DeleteProductAsync(Product product)
    {
        await productService.DeleteProductByIdAsync(product.Id);
    }
}
