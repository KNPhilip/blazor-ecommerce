using WebUI.Client.Ports;
using UseCases.Ports.Input;
using UseCases;
using Domain.Models;

namespace WebUI.Server.Adapters;

public sealed class AddressUIService(
    IAddressService addressService) : IAddressUIService
{
    private readonly IAddressService addressService = addressService;

    public async Task<Address> GetAddressAsync()
    {
        Result<Address> result = await addressService.GetAddressAsync();
        return result;
    }

    public async Task<Address> CreateOrUpdateAddressAsync(Address address)
    {
        await addressService.UpdateOrCreateAddressAsync(address);
        return await addressService.GetAddressAsync();
    }
}
