using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Domain.Enums;
using Domain.Models;

namespace WebUI.Client.Components.Admin;

public sealed partial class EditProduct
{
    [Parameter]
    public int Id { get; set; }

    private Product product = new();
    private string btnText = "";
    private bool isLoaded = false;
    private bool cloudinaryUpload = false;
    private string message = string.Empty;

    private static string DefaultDragClass = "relative rounded-lg border-2 border-dashed pa-4 mt-4 mud-width-full mud-height-full z-10";
    private string DragClass = DefaultDragClass;
    private List<string> fileNames = [];
    private string imageUrl = string.Empty;

    protected sealed override async Task OnInitializedAsync()
    {
        await ProductTypeUIService.GetProductTypesAsync();
        await CategoryUIService.GetAdminCategoriesAsync();
    }

    protected sealed override async Task OnParametersSetAsync()
    {
        if (Id == 0)
        {
            product = new()
            {
                IsNew = true
            };
            btnText = "Create Product";
        }
        else
        {
            Product? dbProduct = await ProductUIService.GetProductByIdAsync(Id);
            if (dbProduct is null)
            {
                message = $"Product with Id '{Id}' does not exist.";
                return;
            }

            product = dbProduct;
            product.Editing = true;
            btnText = "Update Product";
        }
        isLoaded = true;
    }

    private void RemoveVariant(int productTypeId)
    {
        ProductVariant? variant = product.Variants.Find(v => v.ProductTypeId == productTypeId);

        if (variant is null)
        {
            return;
        }
        if (variant.IsNew)
        {
            product.Variants.Remove(variant);
        }
        else
        {
            variant.IsSoftDeleted = true;
        }
    }

    private void AddVariant()
    {
        product.Variants.Add(new()
        {
            IsNew = true,
            ProductId = product.Id
        });
    }

    private async Task CreateOrUpdateProductAsync()
    {
        if (product.IsNew)
        {
            Product result = await ProductUIService.CreateProductAsync(product);
            NavigationManager.NavigateTo($"admin/product/{result.Id}");
        }
        else
        {
            product.IsNew = false;
            product = await ProductUIService.UpdateProductAsync(product) ?? new();
            NavigationManager.NavigateTo($"admin/product/{product!.Id}", true);
        }
    }

    private async Task DeleteProductAsync()
    {
        bool confirmed = await JSRuntime.InvokeAsync<bool>("confirm",
            $"Are you sure you want to delete '{product.Title}'?");

        if (confirmed)
        {
            await ProductUIService.DeleteProductAsync(product);
            NavigationManager.NavigateTo("admin/products");
        }
    }

    private void AddImageByUrl()
    {
        product.Images.Add(
            new Image
            {
                Type = ImageType.Url,
                Data = imageUrl,
                IsNew = true
            }
        );

        imageUrl = string.Empty;
    }

    private async Task OnFileChangeAsync(InputFileChangeEventArgs e)
    {
        ClearDragClass();
        IReadOnlyList<IBrowserFile> files = e.GetMultipleFiles();
        foreach (IBrowserFile file in files)
        {
            fileNames.Add(file.Name);
        }

        string format = "image/png";
        foreach (IBrowserFile image in e.GetMultipleFiles(int.MaxValue))
        {
            IBrowserFile resizedImage = await image.RequestImageFileAsync(format, 200, 200);
            byte[] buffer = new byte[resizedImage.Size];
            await resizedImage.OpenReadStream().ReadAsync(buffer);
            string imageData = $"data:{format};base64,{Convert.ToBase64String(buffer)}";

            product.Images.Add(
                new Image
                {
                    Type = cloudinaryUpload ? ImageType.Cloudinary : ImageType.Base64,
                    Data = imageData,
                    IsNew = true
                }
            );
        }
    }

    private async Task ClearImagesAsync()
    {
        fileNames.Clear();
        ClearDragClass();
        await Task.Delay(100);
        product.Images.Clear();
    }

    private void SetDragClass()
    {
        DragClass = $"{DefaultDragClass} mud-border-primary";
    }

    private void ClearDragClass()
    {
        DragClass = DefaultDragClass;
    }
}
