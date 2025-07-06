using Microsoft.EntityFrameworkCore;
using DataAccess.Data;
using DataAccess.Exceptions;
using UseCases.Ports.Output;
using Domain.Models;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Adapters;

public sealed class AddressRepository(IServiceProvider serviceProvider) : IAddressRepository
{
    private readonly IServiceProvider serviceProvider = serviceProvider;

    public async Task<Address> GetAddressByUserIdAsync(string userId)
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EcommerceContext>();

        Address address = await GetDbAddressByUserIdAsync(userId);
        return address;
    }

    public async Task CreateAddressAsync(Address address)
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EcommerceContext>();

        dbContext.Addresses.Add(address);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateAddressAsync(Address address)
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EcommerceContext>();

        if (address.UserId is null)
        {
            throw new ArgumentException("User Id of the address was null.");
        }
        Address dbAddress = await GetDbAddressByUserIdAsync(address.UserId);

        dbAddress.FirstName = address.FirstName;
        dbAddress.LastName = address.LastName;
        dbAddress.Street = address.Street;
        dbAddress.City = address.City;
        dbAddress.State = address.State;
        dbAddress.Zip = address.Zip;
        dbAddress.Country = address.Country;

        await dbContext.SaveChangesAsync();
    }

    private async Task<Address> GetDbAddressByUserIdAsync(string userId)
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EcommerceContext>();

        Address dbAddress = await dbContext.Addresses
            .Where(x => x.UserId == userId).FirstOrDefaultAsync()
                ?? throw new NotFoundException("The user with the id " +
                $"\"{userId}\" does not have a registered address.");
        return dbAddress;
    }
}
