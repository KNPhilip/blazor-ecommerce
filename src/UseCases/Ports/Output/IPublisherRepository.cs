using Domain.Models;

namespace UseCases.Ports.Output;

public interface IPublisherRepository
{
    Task<DbUser> GetPublisherByIdAsync(string id);
    Task CreatePublisherAsync(DbUser publisher);
    Task UpdatePublisherAsync(DbUser publisher);
    Task DeletePublisherByIdAsync(string id);
}
