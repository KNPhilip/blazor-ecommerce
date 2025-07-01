using Domain.Models;

namespace UseCases.Ports.Output;

public interface IAddressRepository
{
    Task<Address> GetAddressByUserIdAsync(string userId);
    Task CreateAddressAsync(Address address);
    Task UpdateAddressAsync(Address address);
}
