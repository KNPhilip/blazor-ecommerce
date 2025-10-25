using Domain.Models;
using UseCases;
using UseCases.Ports.Input;
using WebUI.Client.Ports;

namespace WebUI.Server.Adapters;

public sealed class PublisherUIService(IPublisherService publisherService
    ) : IPublisherUIService
{
    public async Task<DbUser> GetPublisherByIdAsync(string id)
    {
        Result<DbUser> result = await publisherService.GetPublisherByIdAsync(id);
        return result;
    }

    public async Task<DbUser> CreatePublisherAsync(DbUser publisher)
    {
        Result<DbUser> result = await publisherService.CreatePublisherAsync(publisher);
        return result;
    }

    public async Task<DbUser> UpdatePublisherAsync(DbUser publisher)
    {
        Result<DbUser> result = await publisherService.UpdatePublisherAsync(publisher);
        return result;
    }

    public async Task DeletePublisherByIdAsync(string id)
    {
        await publisherService.DeletePublisherByIdAsync(id);
    }
}
