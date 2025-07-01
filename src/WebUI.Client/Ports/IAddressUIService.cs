using Domain.Models;

namespace WebUI.Client.Ports;

public interface IAddressUIService
{
    Task<Address> GetAddress();
    Task<Address> AddOrUpdateAddress(Address address);
}
