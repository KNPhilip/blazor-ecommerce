using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UseCases.Ports.Input;

namespace WebUI.Server.Controllers;

public sealed class CategoriesController(
    ICategoryService categoryService) : ControllerTemplate
{
    private readonly ICategoryService categoryService = categoryService;

    [HttpGet]
    public async Task<ActionResult<List<Category>>> GetCategories() =>
        HandleResult(await categoryService.GetCategoriesAsync());

    [HttpGet("admin"), Authorize(Roles = "Admin")]
    public async Task<ActionResult<List<Category>>> GetAdminCategories() =>
        HandleResult(await categoryService.GetAdminCategoriesAsync());

    [HttpPost, Authorize(Roles = "Admin")]
    public async Task<ActionResult<List<Category>>> AddCategory(Category category) =>
        HandleResult(await categoryService.CreateCategoryAsync(category));

    [HttpPut, Authorize(Roles = "Admin")]
    public async Task<ActionResult<List<Category>>> UpdateCategory(Category category) =>
        HandleResult(await categoryService.UpdateCategoryAsync(category));

    [HttpDelete, Authorize(Roles = "Admin")]
    public async Task<ActionResult<List<Category>>> DeleteCategory(int categoryId) =>
        HandleResult(await categoryService.DeleteCategoryAsync(categoryId));
}
