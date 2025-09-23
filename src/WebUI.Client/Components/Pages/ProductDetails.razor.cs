using Domain.Models;
using Microsoft.AspNetCore.Components;

namespace WebUI.Client.Components.Pages;

public sealed partial class ProductDetails
{
    private Product? product = null;
    private string message = string.Empty;
    private int currentTypeId = 1;

    [Parameter]
    public int Id { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        Product? result = await ProductUIService.GetProductByIdAsync(Id);
        product = result;
        if (product!.Variants.Count > 0)
        {
            currentTypeId = product.Variants[0].ProductTypeId;
        }
    }

    private ProductVariant? GetSelectedVariant()
    {
        return product!.Variants.FirstOrDefault(v => v.ProductTypeId == currentTypeId);
    }

    private async Task AddToCartAsync()
    {
        ProductVariant? productVariant = GetSelectedVariant();
        CartItem cartItem = new()
        {
            ProductId = productVariant!.ProductId,
            ProductTypeId = productVariant.ProductTypeId,
            Quantity = 1
        };

        await CartUIService.AddToCartAsync(cartItem);
    }

    private string GetPublishers()
    {
        if (product?.Publishers is null || product.Publishers.Count == 0)
            return "";

        List<string> names = product.Publishers.Select(p =>
        {
            if (!string.IsNullOrWhiteSpace(p.NickName))
                return p.NickName;
            else
                return $"{p.FirstName} {p.LastName}";
        }).ToList();

        if (names.Count == 1)
        {
            return names[0];
        }
        else if (names.Count == 2)
        {
            return $"{names[0]} and {names[1]}";
        }
        else
        {
            var allButLast = string.Join(", ", names.Take(names.Count - 1));
            var last = names.Last();
            return $"{allButLast}, and {last}";
        }
    }
}
