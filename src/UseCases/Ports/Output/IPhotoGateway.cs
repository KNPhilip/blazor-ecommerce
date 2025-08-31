using Domain.Dtos;

namespace UseCases.Ports.Output;

public interface IPhotoGateway
{
    Task<PhotoUploadDto> AddPhotoAsync(string base64String);
    Task<string> DeletePhotoAsync(string publicId);
}
