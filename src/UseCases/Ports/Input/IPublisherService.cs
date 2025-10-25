using Domain.Models;

namespace UseCases.Ports.Input;

public interface IPublisherService
{
    Task<Result<DbUser>> GetPublisherByIdAsync(string id);
    Task<Result<DbUser>> CreatePublisherAsync(DbUser publisher);
    Task<Result<DbUser>> UpdatePublisherAsync(DbUser publisher);
    Task<Result<bool>> DeletePublisherByIdAsync(string id);
}
