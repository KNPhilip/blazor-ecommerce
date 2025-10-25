using Domain.Models;

namespace WebUI.Client.Ports;

public interface IPublisherUIService
{
    Task<DbUser> GetPublisherByIdAsync(string id);
    Task<DbUser> CreatePublisherAsync(DbUser publisher);
    Task<DbUser> UpdatePublisherAsync(DbUser publisher);
    Task DeletePublisherByIdAsync(string id);
}
