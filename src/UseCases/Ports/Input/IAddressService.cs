using Domain.Models;

namespace UseCases.Ports.Input;

public interface IAddressService
{
    Task<Result<Address>> GetAddressAsync();
    Task<Result> UpdateOrCreateAddressAsync(Address address);
}
