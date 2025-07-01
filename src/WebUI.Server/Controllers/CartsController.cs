using Domain.Dtos;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using UseCases.Ports.Input;

namespace WebUI.Server.Controllers;

public sealed class CartsController(
    ICartService cartService) : ControllerTemplate
{
    private readonly ICartService cartService = cartService;

    [HttpPost("products")]
    public async Task<ActionResult<List<CartProductResponseDto>>> GetCartProducts(List<CartItem> cartItems) =>
        HandleResult(await cartService.GetCartProductsAsync(cartItems));

    [HttpPost]
    public async Task<ActionResult<List<CartProductResponseDto>>> StoreCartItems(List<CartItem> cartItems) =>
        HandleResult(await cartService.StoreCartItemsAsync(cartItems));

    [HttpPost("add")]
    public async Task<ActionResult<bool>> AddToCart(CartItem cartItem) =>
        HandleResult(await cartService.AddToCartAsync(cartItem));

    [HttpPut("update-quantity")]
    public async Task<ActionResult<bool>> UpdateQuantity(CartItem cartItem) =>
        HandleResult(await cartService.UpdateQuantityAsync(cartItem));

    [HttpDelete("{productId}/{productTypeId}")]
    public async Task<ActionResult<bool>> RemoveItemFromCart(int productId, int productTypeId) =>
        HandleResult(await cartService.RemoveItemFromCartAsync(productId, productTypeId));

    [HttpGet("count")]
    public async Task<ActionResult<int>> GetCartItemsCount() =>
        HandleResult(await cartService.GetCartItemsCountAsync());

    [HttpGet]
    public async Task<ActionResult<List<CartProductResponseDto>>> GetDbCartItems() =>
        HandleResult(await cartService.GetCartItemsAsync());
}
