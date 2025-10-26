using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UseCases.Ports.Input;
using Domain.Models;

namespace WebUI.Server.Controllers;

[Authorize]
public sealed class FavoriteController(
    IFavoriteService favoriteService) : ControllerTemplate
{
    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetFavoritesAsync() =>
        HandleGenericResult(await favoriteService.GetFavoritesAsync());

    [HttpPost]
    public async Task<ActionResult> AddToFavoritesAsync(Product favorite) =>
        HandleResult(await favoriteService.AddToFavoritesAsync(favorite));

    [HttpDelete("{productId:int}")]
    public async Task<ActionResult> RemoveFromFavoritesAsync(int productId) =>
        HandleResult(await favoriteService.RemoveFromFavoritesAsync(productId));
}
