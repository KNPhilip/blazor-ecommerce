using UseCases.Ports.Input;
using UseCases.Ports.Output;
using UseCases.Ports;
using Domain.Models;
using Domain.Dtos;

namespace UseCases.Services;

public sealed class CartService(IAuthService authService, ICartRepository cartRepository, 
    IProductRepository productRepository, IProductVariantRepository productVariantRepository
    ) : ICartService
{
    private readonly IAuthService authService = authService;
    private readonly ICartRepository cartRepository = cartRepository;
    private readonly IProductRepository productRepository = productRepository;
    private readonly IProductVariantRepository productVariantRepository = productVariantRepository;

    public async Task<Result<int>> GetCartItemsCountAsync()
    {
        string userId = await authService.GetUserIdAsync();
        List<CartItem> cartItems = await cartRepository.GetCartItemsForUserAsync(userId);
        return cartItems.Count;
    }

    public async Task<Result<List<CartProductResponseDto>>> GetCartItemsAsync(string? userId = null)
    {
        userId ??= await authService.GetUserIdAsync();
        List<CartItem> cartItems = await cartRepository.GetCartItemsForUserAsync(userId);
        return await GetCartProductsAsync(cartItems);
    }

    public async Task<Result<List<CartProductResponseDto>>> GetCartProductsAsync(List<CartItem> cartItems)
    {
        List<CartProductResponseDto> response = [];

        foreach (CartItem item in cartItems)
        {
            try
            {
                Product? product = await productRepository.GetProductByIdAsync(item.ProductId);
                ProductVariant productVariant = await productVariantRepository
                    .GetProductVariantAsync(item.ProductId, item.ProductTypeId);

                CartProductResponseDto cartProduct = new()
                {
                    ProductId = product.Id,
                    Title = product.Title,
                    ImageUrl = product.ImageUrl,
                    Price = productVariant.Price,
                    ProductType = productVariant.ProductType.Name,
                    ProductTypeId = productVariant.ProductTypeId,
                    Quantity = item.Quantity
                };
                response.Add(cartProduct);
            }
            catch (DataAccessException) 
            {
                
            }
        }
        return response.Count > 0 ? response : 
            Result.Fail<List<CartProductResponseDto>>("No products found.");
    }

    public async Task<Result<List<CartProductResponseDto>>> StoreCartItemsAsync(List<CartItem> cartItems)
    {
        string userId = await authService.GetUserIdAsync();
        cartItems.ForEach(cartItem => cartItem.UserId = userId);

        await cartRepository.CreateCartItemsAsync(cartItems);

        return await GetCartItemsAsync();
    }

    public async Task<Result<bool>> AddToCartAsync(CartItem cartItem)
    {
        try
        {
            cartItem.UserId = await authService.GetUserIdAsync();

            if (await cartRepository.CartItemExistAsync(cartItem))
            {
                await UpdateQuantityAsync(cartItem);
            }
            else
            {
                await cartRepository.CreateCartItemAsync(cartItem);
            }
            return true;
        }
        catch (DataAccessException e)
        {
            return Result.Fail<bool>(e.Message);
        }
    }

    public async Task<Result<bool>> UpdateQuantityAsync(CartItem cartItem)
    {
        try
        {
            string userId = await authService.GetUserIdAsync();
            cartItem.UserId = userId;

            await cartRepository.UpdateQuantityAsync(cartItem);
            return true;
        }
        catch (DataAccessException e)
        {
            return Result.Fail<bool>(e.Message);
        }
    }

    public async Task<Result<bool>> RemoveItemFromCartAsync(int productId, int productTypeId)
    {
        try
        {
            string userId = await authService.GetUserIdAsync();
            await cartRepository.DeleteCartItemAsync(userId, productId, productTypeId);
            return true;
        }
        catch (DataAccessException e)
        {
            return Result.Fail<bool>(e.Message);
        }
    }
}
