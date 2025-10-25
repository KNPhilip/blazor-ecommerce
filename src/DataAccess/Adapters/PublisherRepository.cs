using DataAccess.Data;
using DataAccess.Exceptions;
using Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using UseCases.Ports.Output;

namespace DataAccess.Adapters;

public sealed class PublisherRepository(IServiceProvider serviceProvider) : IPublisherRepository
{
    private readonly IServiceProvider serviceProvider = serviceProvider;

    public async Task<DbUser> GetPublisherByIdAsync(string id)
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EcommerceContext>();

        return await dbContext.Users.FindAsync(id)
            ?? throw new NotFoundException($"Found no publishers with id \"{id}\".");
    }

    public async Task CreatePublisherAsync(DbUser publisher)
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EcommerceContext>();

        await dbContext.Users.AddAsync(publisher);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdatePublisherAsync(DbUser publisher)
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EcommerceContext>();

        DbUser dbPublisher = await dbContext.Users.FindAsync(publisher.Id)
            ?? throw new NotFoundException($"Found no publishers with id \"{publisher.Id}\".");

        dbPublisher.Email = publisher.Email;
        dbPublisher.FirstName = publisher.FirstName;
        dbPublisher.LastName = publisher.LastName;
        dbPublisher.NickName = publisher.NickName;
        dbPublisher.BirthDate = publisher.BirthDate;

        await dbContext.SaveChangesAsync();
    }

    public async Task DeletePublisherByIdAsync(string id)
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EcommerceContext>();

        DbUser dbPublisher = await dbContext.Users.FindAsync(id)
            ?? throw new NotFoundException($"Found no publishers with id \"{id}\".");

        dbContext.Users.Remove(dbPublisher);
        await dbContext.SaveChangesAsync();
    }
}
