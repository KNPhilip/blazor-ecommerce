using Domain.Models;
using UseCases.Ports;
using UseCases.Ports.Input;
using UseCases.Ports.Output;

namespace UseCases.Services;

public sealed class PublisherService(IPublisherRepository publisherRepository) : IPublisherService
{
    public async Task<Result<DbUser>> GetPublisherByIdAsync(string id)
    {
        try
        {
            DbUser result = await publisherRepository.GetPublisherByIdAsync(id);
            return result;
        }
        catch (DataAccessException ex)
        {
            return Result.Fail<DbUser>(ex.Message);
        }
    }

    public async Task<Result<DbUser>> CreatePublisherAsync(DbUser publisher)
    {
        try
        {
            await publisherRepository.CreatePublisherAsync(publisher);
            return await GetPublisherByIdAsync(publisher.Id);
        }
        catch (DataAccessException ex)
        {
            return Result.Fail<DbUser>(ex.Message);
        }
    }

    public async Task<Result<DbUser>> UpdatePublisherAsync(DbUser publisher)
    {
        try
        {
            await publisherRepository.UpdatePublisherAsync(publisher);
            return await GetPublisherByIdAsync(publisher.Id);
        }
        catch (DataAccessException ex)
        {
            return Result.Fail<DbUser>(ex.Message);
        }
    }

    public async Task<Result<bool>> DeletePublisherByIdAsync(string id)
    {
        try
        {
            await publisherRepository.DeletePublisherByIdAsync(id);
            return true;
        }
        catch (DataAccessException ex)
        {
            return Result.Fail<bool>(ex.Message);
        }
    }
}
