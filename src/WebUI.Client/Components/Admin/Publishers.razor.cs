using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Domain.Models;
using MudBlazor;

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
                Editing = false,
                BirthDate = DateTime.Now
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
        if (publisher.HasNoName() && publisher.HasNoNickname())
        {
            Snackbar.Add("Please provide either a real name or a nickname " +
                "(e.g. company name, artist name, etc.) for the publisher.", Severity.Error);
            return;
        }

        if (publisher.IsNew)
        {
            string id = Guid.NewGuid().ToString();
            string placeholderHash = "$5x$20$wA0Z8JH6g9mXQ8e2c4c0HuXHkOa2wX";

            publisher.Id = id;
            publisher.ConcurrencyStamp = id;
            publisher.SecurityStamp = id;
            publisher.PasswordHash = placeholderHash;
            publisher.UserName = publisher.Email;
            publisher.NormalizedUserName = publisher.Email!.ToUpper();
            publisher.NormalizedEmail = publisher.Email.ToUpper();
            publisher.EmailConfirmed = true;
            publisher.DateCreated = DateTime.Now;

            DbUser result = await PublisherUIService.CreatePublisherAsync(publisher);
            Snackbar.Add("You created a new publisher!", Severity.Success);
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
