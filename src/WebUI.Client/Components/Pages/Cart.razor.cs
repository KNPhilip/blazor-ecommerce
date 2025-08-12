using Domain.Dtos;
using Microsoft.AspNetCore.Components;

namespace WebUI.Client.Components.Pages;

public sealed partial class Cart
{
    List<CartProductResponseDto>? cartProducts = null;
    string message = "Loading cart...";
    bool isAuthenticated = false;

    protected override async Task OnInitializedAsync()
    {
        isAuthenticated = await AuthUIService.IsUserAuthenticatedAsync();
        await LoadCartAsync();
    }

    private async Task RemoveProductFromCartAsync(int productId, int productTypeId)
    {
        await CartUIService.RemoveProductFromCartAsync(productId, productTypeId);
        await LoadCartAsync();
    }

    private async Task LoadCartAsync()
    {
        await CartUIService.SetCartItemsCountAsync();
        cartProducts = await CartUIService.GetCartProductsAsync();
        if (cartProducts is null || cartProducts.Count == 0)
        {
            message = "Your cart is empty.";
        }
    }

    private async Task UpdateQuantityAsync(ChangeEventArgs e, CartProductResponseDto product)
    {
        product.Quantity = int.Parse(e.Value!.ToString()!);
        if (product.Quantity < 1)
        {
            product.Quantity = 1;
        }
        await CartUIService.UpdateQuantityAsync(product);
    }

    private async Task PlaceOrderAsync()
    {
        string url = await OrderUIService.PlaceOrderAsync();
        if (url is not null)
        {
            
            NavigationManager.NavigateTo(url);
        }
    }
}
