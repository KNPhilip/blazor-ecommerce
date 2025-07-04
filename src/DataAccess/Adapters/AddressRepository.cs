using Microsoft.EntityFrameworkCore;
using DataAccess.Data;
using DataAccess.Exceptions;
using UseCases.Ports.Output;
using Domain.Models;

namespace DataAccess.Adapters;

public sealed class AddressRepository(EcommerceContext dbContext) : IAddressRepository
{
    private readonly EcommerceContext dbContext = dbContext;

    public async Task<Address> GetAddressByUserIdAsync(string userId)
    {
        Address address = await GetDbAddressByUserIdAsync(userId);
        return address;
    }

    public async Task CreateAddressAsync(Address address)
    {
        dbContext.Addresses.Add(address);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateAddressAsync(Address address)
    {
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
        Address dbAddress = await dbContext.Addresses
            .Where(x => x.UserId == userId).FirstOrDefaultAsync()
                ?? throw new NotFoundException("The user with the id " +
                $"\"{userId}\" does not have a registered address.");
        return dbAddress;
    }
}
