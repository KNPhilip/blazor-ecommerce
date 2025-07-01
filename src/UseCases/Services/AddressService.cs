using UseCases.Ports.Input;
using UseCases.Ports.Output;
using UseCases.Ports;
using Domain.Models;

namespace UseCases.Services;

public sealed class AddressService(IAuthService authService,
    IAddressRepository repository) : IAddressService
{
    private readonly IAuthService authService = authService;
    private readonly IAddressRepository repository = repository;

    public async Task<Result<Address>> GetAddressAsync()
    {
        try
        {
            string userId = await authService.GetUserIdAsync();
            return await repository.GetAddressByUserIdAsync(userId);
        }
        catch (DataAccessException ex)
        {
            return Result.Fail<Address>(ex.Message);
        }
    }

    public async Task<Result> UpdateOrCreateAddressAsync(Address address)
    {
        try
        {
            await repository.UpdateAddressAsync(address);
            return Result.Ok("The address was updated.");
        }
        catch (DataAccessException)
        {
            return await CreateAddressAsync(address);
        }
    }

    private async Task<Result> CreateAddressAsync(Address address)
    {
        try
        {
            address.UserId = await authService.GetUserIdAsync();
            await repository.CreateAddressAsync(address);
            return Result.Ok("The address was created.");
        }
        catch (Exception ex)
        {
            return Result.Fail(ex.Message);
        }
    }
}
