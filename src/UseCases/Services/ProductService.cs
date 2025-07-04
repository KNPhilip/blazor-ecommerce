﻿using UseCases.Ports.Input;
using UseCases.Ports.Output;
using Domain.Models;
using Domain.Dtos;
using UseCases.Ports;

namespace UseCases.Services;

public sealed class ProductService(IProductVariantRepository productVariantRepository,
    IProductRepository productRepository, IAuthService authService) : IProductService
{
    private readonly IProductVariantRepository productVariantRepository = productVariantRepository;
    private readonly IProductRepository productRepository = productRepository;
    private readonly IAuthService authService = authService;

    public async Task<Result<Product>> GetProductByIdAsync(int productId)
    {
        try
        {
            Product product = authService.IsUserAdmin()
                ? await productRepository.GetAdminProductByIdAsync(productId)
                : await productRepository.GetProductByIdAsync(productId);

            if (product.IsSoftDeleted)
            {
                return Result.Fail<Product>($"We're sorry, but \"{product.Title}\" is not available anymore..");
            }
            return product;
        }
        catch (DataAccessException)
        {
            return Result.Fail<Product>("This product does not exist.");
        }
    }

    public async Task<Result<List<Product>>> GetProductsAsync()
    {
        List<Product> products = await productRepository.GetAllProductsAsync();

        return products.Count > 0
            ? products : Result.Fail<List<Product>>("No products found.");
    }

    public async Task<Result<List<Product>>> GetProductsByCategoryAsync(string categoryUrl)
    {
        List<Product> products = await productRepository.GetProductsByCategoryAsync(categoryUrl);

        return products.Count > 0
            ? products : Result.Fail<List<Product>>("No products found.");
    }

    public async Task<Result<List<string>>> GetProductSearchSuggestionsAsync(string searchTerm)
    {
        List<Product> products = await productRepository.GetProductsBySearchTermAsync(searchTerm);
        List<string> result = [];

        foreach (Product product in products)
        {
            if (product.Title.Contains(searchTerm,
                StringComparison.OrdinalIgnoreCase))
            {
                result.Add(product.Title);
            }

            if (product.Description is not null)
            {
                char[] punctuation = product.Description
                    .Where(char.IsPunctuation)
                    .Distinct().ToArray();
                IEnumerable<string> words = product.Description
                    .Split()
                    .Select(s => s.Trim(punctuation));

                foreach (string word in words)
                {
                    if (word.Contains(searchTerm,
                        StringComparison.OrdinalIgnoreCase)
                        && !result.Contains(word))
                    {
                        result.Add(word);
                    }
                }
            }
        }
        return result;
    }

    public async Task<Result<ProductSearchResultDto>> SearchProductsAsync(string searchTerm, int page)
    {
        List<Product> searchResults = await productRepository.GetProductsBySearchTermAsync(searchTerm);

        float pageResults = 2f;
        double pageCount = Math.Ceiling(searchResults.Count / pageResults);

        List<Product> products = searchResults
            .Skip((page - 1) * (int)pageResults)
            .Take((int)pageResults)
            .ToList();

        ProductSearchResultDto response = new()
        {
            Products = products,
            CurrentPage = page,
            Pages = (int)pageCount
        };
        return response;
    }

    public async Task<Result<List<Product>>> GetFeaturedProductsAsync()
    {
        List<Product> response = await productRepository.GetAllFeaturedProductsAsync();

        return response.Count > 0
            ? response : Result.Fail<List<Product>>("No products found.");
    }

    public async Task<Result<List<Product>>> GetAdminProductsAsync()
    {
        List<Product> response = await productRepository.GetAllAdminProductsAsync();

        return response.Count > 0
            ? response : Result.Fail<List<Product>>("No products found.");
    }

    public async Task<Result<Product>> CreateProductAsync(Product product)
    {
        await productRepository.CreateProductAsync(product);
        return product;
    }

    public async Task<Result<Product>> UpdateProductAsync(Product product)
    {
        try
        {
            await productRepository.UpdateProductAsync(product);

            foreach (ProductVariant variant in product.Variants)
            {
                await productVariantRepository.UpdateProductVariantAsync(variant);
            }
            return product;
        }
        catch (DataAccessException)
        {
            return Result.Fail<Product>("Product not found.");
        }
    }

    public async Task<Result<bool>> DeleteProductByIdAsync(int productId)
    {
        try
        {
            await productRepository.DeleteProductByIdAsync(productId);
            return true;
        }
        catch (DataAccessException)
        {
            return Result.Fail<bool>("Product not found");
        }
    }
}
