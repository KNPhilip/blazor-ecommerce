using Domain.Dtos;
using Microsoft.AspNetCore.Http;

namespace UseCases.Ports.Output;

public interface IPhotoGateway
{
    Task<PhotoUploadDto> AddPhotoAsync(IFormFile file);
    Task<string> DeletePhotoAsync(string publicId);
}
