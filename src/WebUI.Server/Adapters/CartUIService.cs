﻿using Blazored.LocalStorage;
using Domain.Dtos;
using Domain.Models;
using UseCases;
using UseCases.Ports.Input;
using WebUI.Client.Ports;

namespace WebUI.Server.Adapters;

public sealed class CartUIService(
    ILocalStorageService localStorage,
    IAuthUIService authService,
    ICartService cartService) : ICartUIService
{
    public event Action? OnChange;

    public async Task GetCartItemsCount()
    {
        if (await authService.IsUserAuthenticated())
        {
            int count = await cartService.GetCartItemsCountAsync();
            await localStorage.SetItemAsync("cartItemsCount", count);
        }
        else
        {
            List<CartItem>? cart = await localStorage
                .GetItemAsync<List<CartItem>>("cart");

            await localStorage.SetItemAsync
                ("cartItemsCount", cart is not null ? cart.Count : 0);
        }
    }

    public async Task AddToCart(CartItem cartItem)
    {
        if (await authService.IsUserAuthenticated())
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
        await GetCartItemsCount();
    }

    public async Task<List<CartProductResponseDto>> GetCartProducts()
    {
        if (await authService.IsUserAuthenticated())
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

    public async Task RemoveProductFromCart(int productId, int productTypeId)
    {
        if (await authService.IsUserAuthenticated())
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
        await GetCartItemsCount();
    }

    public async Task StoreCartItems(bool emptyLocalCart)
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

    public async Task UpdateQuantity(CartProductResponseDto product)
    {
        if (await authService.IsUserAuthenticated())
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
}
