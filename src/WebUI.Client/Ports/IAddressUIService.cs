using Domain.Models;

namespace WebUI.Client.Ports;

public interface IAddressUIService
{
    Task<Address> GetAddressAsync();
    Task<Address> CreateOrUpdateAddressAsync(Address address);
}
