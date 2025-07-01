using WebUI.Client.Ports;
using UseCases.Ports.Input;
using UseCases;
using Domain.Models;

namespace WebUI.Server.Adapters;

public sealed class AddressUIService(
    IAddressService addressService) : IAddressUIService
{
    public async Task<Address> AddOrUpdateAddress(Address address)
    {
        await addressService.UpdateOrCreateAddressAsync(address);
        return await addressService.GetAddressAsync();
    }

    public async Task<Address> GetAddress()
    {
        Result<Address> result = await addressService.GetAddressAsync();
        return result;
    }
}
