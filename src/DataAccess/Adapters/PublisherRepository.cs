using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using UseCases.Ports.Output;
using DataAccess.Exceptions;
using DataAccess.Data;
using Domain.Models;

namespace DataAccess.Adapters;

public sealed class PublisherRepository(IServiceProvider serviceProvider) : IPublisherRepository
{
    private readonly IServiceProvider serviceProvider = serviceProvider;

    public async Task<DbUser> GetPublisherByIdAsync(string id)
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<DbUser>>();

        return await userManager.FindByIdAsync(id)
            ?? throw new NotFoundException($"Found no publishers with id \"{id}\".");
    }

    public async Task CreatePublisherAsync(DbUser publisher)
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<DbUser>>();
        
        IdentityResult result = await userManager.CreateAsync(publisher);

        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(publisher, "Publisher");
        }
        else throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));
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
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<DbUser>>();

        DbUser publisher = await userManager.FindByIdAsync(id)
            ?? throw new NotFoundException($"Found no publishers with id \"{id}\".");

        await userManager.DeleteAsync(publisher);
    }
}
