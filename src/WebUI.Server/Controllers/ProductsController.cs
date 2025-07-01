using Domain.Dtos;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UseCases.Ports.Input;

namespace WebUI.Server.Controllers;

public sealed class ProductsController(
    IProductService productService) : ControllerTemplate
{
    private readonly IProductService productService = productService;

    [HttpGet("admin"), Authorize(Roles = "Admin")]
    public async Task<ActionResult<List<Product>>> GetAdminProducts() =>
        HandleResult(await productService.GetAdminProductsAsync());

    [HttpPost, Authorize(Roles = "Admin")]
    public async Task<ActionResult<Product>> CreateProduct(Product product) =>
        HandleResult(await productService.CreateProductAsync(product));

    [HttpPut, Authorize(Roles = "Admin")]
    public async Task<ActionResult<List<Product>>> UpdateProduct(Product product) =>
        HandleResult(await productService.UpdateProductAsync(product));

    [HttpDelete("{productId}"), Authorize(Roles = "Admin")]
    public async Task<ActionResult<bool>> DeleteProduct(int productId) =>
        HandleResult(await productService.DeleteProductByIdAsync(productId));

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetAllProducts() =>
        HandleResult(await productService.GetProductsAsync());

    [HttpGet("{productId}")]
    public async Task<ActionResult<Product>> GetProduct(int productId) =>
        HandleResult(await productService.GetProductByIdAsync(productId));

    [HttpGet("category/{categoryUrl}")]
    public async Task<ActionResult<List<Product>>> GetProductsByCategory(string categoryUrl) =>
        HandleResult(await productService.GetProductsByCategoryAsync(categoryUrl));

    [HttpGet("search/{searchTerm}/{page}")]
    public async Task<ActionResult<ProductSearchResultDto>> SearchProducts(string searchTerm, int page = 1) =>
        HandleResult(await productService.SearchProductsAsync(searchTerm, page));

    [HttpGet("search-suggestions/{searchTerm}")]
    public async Task<ActionResult<List<Product>>> GetProductSearchSuggestions(string searchTerm) =>
        HandleResult(await productService.GetProductSearchSuggestionsAsync(searchTerm));

    [HttpGet("featured")]
    public async Task<ActionResult<List<Product>>> GetFeaturedProducts() =>
        HandleResult(await productService.GetFeaturedProductsAsync());
}
