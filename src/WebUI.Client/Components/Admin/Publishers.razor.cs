using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Domain.Models;

namespace WebUI.Client.Components.Admin;

public sealed partial class Publishers
{
    [Parameter]
    public string? Id { get; set; }

    private DbUser? publisher;
    private string btnText = "";
    private bool isLoaded = false;
    private string message = string.Empty;

    protected sealed override async Task OnParametersSetAsync()
    {
        if (Id is null)
        {
            publisher = new()
            {
                IsNew = true,
                Editing = false
            };
            btnText = "Create Publisher";
        }
        else
        {
            DbUser? dbUser = await PublisherUIService.GetPublisherByIdAsync(Id);
            if (dbUser is null)
            {
                message = $"Publisher with Id '{Id}' does not exist.";
                return;
            }

            publisher = dbUser;
            publisher.Editing = true;
            btnText = "Update Publisher";
        }
        isLoaded = true;
    }

    private async Task CreateOrUpdatePublisherAsync()
    {
        if (publisher.IsNew)
        {
            DbUser result = await PublisherUIService.CreatePublisherAsync(publisher);
            NavigationManager.NavigateTo($"admin/publisher/{result.Id}");
        }
        else
        {
            publisher.IsNew = false;
            publisher = await PublisherUIService.UpdatePublisherAsync(publisher) ?? new();
            NavigationManager.NavigateTo($"admin/publisher/{publisher!.Id}", true);
        }
    }

    private async Task DeletePublisherAsync()
    {
        bool confirmed = await JSRuntime.InvokeAsync<bool>("confirm",
            $"Are you sure you want to delete '{publisher.FullName}'?");

        if (confirmed)
        {
            await PublisherUIService.DeletePublisherByIdAsync(publisher.Id);
            NavigationManager.NavigateTo("admin/products");
        }
    }
}
