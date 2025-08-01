﻿using Blazored.LocalStorage;
using Domain.Dtos;
using Domain.Models;
using UseCases.Ports.Input;
using WebUI.Client.Ports;

namespace WebUI.Server.Adapters;

public sealed class CartUIService(ILocalStorageService localStorage,
    IAuthUIService authService, ICartService cartService) : ICartUIService
{
    private readonly ILocalStorageService localStorage = localStorage;
    private readonly IAuthUIService authService = authService;
    private readonly ICartService cartService = cartService;
    
    public event Action? OnChange;

    public async Task<List<CartProductResponseDto>> GetCartProductsAsync()
    {
        if (await authService.IsUserAuthenticatedAsync())
        {
            return await cartService.GetCartItemsAsync();
        }
        else
        {
            List<CartItem>? cartItems = await localStorage
                .GetItemAsync<List<CartItem>>("cart");
            if (cartItems is null)
            {
                return [];
            }
            return await cartService.GetCartProductsAsync(cartItems);
        }
    }

    public async Task<int> GetCartItemsCountAsync()
    {
        return await cartService.GetCartItemsCountAsync();
    }

    public async Task AddToCartAsync(CartItem cartItem)
    {
        if (await authService.IsUserAuthenticatedAsync())
        {
            await cartService.AddToCartAsync(cartItem);
        }
        else
        {
            List<CartItem> cart = await localStorage
                .GetItemAsync<List<CartItem>>("cart") ?? [];

            CartItem? sameItem = cart.Find(x => x.ProductId == cartItem.ProductId
            && x.ProductTypeId == cartItem.ProductTypeId);
            if (sameItem is null)
            {
                cart.Add(cartItem);
            }
            else
            {
                sameItem.Quantity += cartItem.Quantity;
            }

            await localStorage.SetItemAsync("cart", cart);
        }
        await SetCartItemsCountAsync();
        OnChange?.Invoke();
    }

    public async Task StoreCartItemsAsync(bool emptyLocalCart)
    {
        List<CartItem>? localCart = await localStorage
            .GetItemAsync<List<CartItem>>("cart");
        if (localCart is null)
        {
            return;
        }

        await cartService.StoreCartItemsAsync(localCart);

        if (emptyLocalCart)
        {
            await localStorage.RemoveItemAsync("cart");
        }
    }

    public async Task SetCartItemsCountAsync(int count)
    {
        await localStorage.SetItemAsync("cartItemsCount", count);
    }

    public async Task SetCartItemsCountAsync()
    {
        if (await authService.IsUserAuthenticatedAsync())
        {
            int count = await GetCartItemsCountAsync();
            await SetCartItemsCountAsync(count);
        }
        else
        {
            List<CartItem>? cart = await localStorage
                .GetItemAsync<List<CartItem>>("cart");

            await SetCartItemsCountAsync(cart is null ? 0 : cart.Count);
        }
    }

    public async Task UpdateQuantityAsync(CartProductResponseDto product)
    {
        if (await authService.IsUserAuthenticatedAsync())
        {
            CartItem request = new()
            {
                ProductId = product.ProductId,
                Quantity = product.Quantity,
                ProductTypeId = product.ProductTypeId
            };
            await cartService.UpdateQuantityAsync(request);
        }
        else
        {
            List<CartItem>? cart = await localStorage
                .GetItemAsync<List<CartItem>>("cart");
            if (cart is null)
            {
                return;
            }

            CartItem? cartItem = cart
                .Find(x => x.ProductId == product.ProductId
                    && x.ProductTypeId == product.ProductTypeId);

            if (cartItem is not null)
            {
                cartItem.Quantity = product.Quantity;
                await localStorage
                    .SetItemAsync("cart", cart);
            }
        }
    }

    public async Task RemoveProductFromCartAsync(int productId, int productTypeId)
    {
        if (await authService.IsUserAuthenticatedAsync())
        {
            await cartService.RemoveItemFromCartAsync(productId, productTypeId);
        }
        else
        {
            List<CartItem>? cart = await localStorage
                .GetItemAsync<List<CartItem>>("cart");
            if (cart is null)
            {
                return;
            }

            CartItem? cartItem = cart.Find(x => x.ProductId == productId
                && x.ProductTypeId == productTypeId);

            if (cartItem is not null)
            {
                cart.Remove(cartItem);
                await localStorage.SetItemAsync("cart", cart);
            }
        }
        await SetCartItemsCountAsync();
        OnChange?.Invoke();
    }
}
