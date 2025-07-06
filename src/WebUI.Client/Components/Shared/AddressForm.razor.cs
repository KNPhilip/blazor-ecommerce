using Domain.Models;

namespace WebUI.Client.Components.Shared;

public sealed partial class AddressForm
{
    private Address? address = null;
    private bool editAddress = false;

    protected override async Task OnInitializedAsync()
    {
        address = await AddressUIService.GetAddressAsync();
    }

    private async Task SubmitAddresssAsync()
    {
        editAddress = false;
        address = await AddressUIService.CreateOrUpdateAddressAsync(address!);
    }

    private void InitAddress()
    {
        address = new();
        editAddress = true;
    }

    private void EditAddress()
    {
        editAddress = true;
    }
}
