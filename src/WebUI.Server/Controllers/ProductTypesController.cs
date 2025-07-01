using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UseCases.Ports.Input;

namespace WebUI.Server.Controllers;

[Authorize(Roles = "Admin")]
public sealed class ProductTypesController(
    IProductTypeService productTypeService) : ControllerTemplate
{
    private readonly IProductTypeService productTypeService = productTypeService;

    [HttpGet]
    public async Task<ActionResult<List<ProductType>>> GetProductTypes() =>
        HandleResult(await productTypeService.GetProductTypesAsync());

    [HttpPost]
    public async Task<ActionResult<List<ProductType>>> AddProductType(ProductType productType) =>
        HandleResult(await productTypeService.CreateProductTypeAsync(productType));

    [HttpPut]
    public async Task<ActionResult<List<ProductType>>> UpdateProductType(ProductType productType) =>
        HandleResult(await productTypeService.UpdateProductTypeAsync(productType));

    [HttpDelete("{productTypeId}")]
    public async Task<ActionResult<List<ProductType>>> DeleteProductType(int productTypeId) =>
        HandleResult(await productTypeService.DeleteProductTypeByIdAsync(productTypeId));
}
