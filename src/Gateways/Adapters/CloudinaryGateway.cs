using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Domain.Dtos;
using Gateways.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using UseCases.Ports;
using UseCases.Ports.Output;

namespace Gateways.Adapters;

public sealed class CloudinaryGateway(IOptions<CloudinaryOptions> options) : IPhotoGateway
{
    private readonly CloudinaryOptions options = options.Value;

    public async Task<PhotoUploadDto> AddPhotoAsync(IFormFile file)
    {
        Account account = new
        (
            options.CloudName,
            options.ApiKey,
            options.ApiSecret
        );
        Cloudinary cloudinary = new(account);

        if (file.Length <= 0)
        {
            throw new GatewayException("File is empty.");
        }

        await using var stream = file.OpenReadStream();
        ImageUploadParams uploadParams = new()
        {
            File = new FileDescription(file.FileName, stream),
            Transformation = new Transformation().Height(500).Width(500).Crop("fill")
        };

        ImageUploadResult uploadResult = await cloudinary.UploadAsync(uploadParams);

        if (uploadResult.Error is not null)
        {
            throw new GatewayException(uploadResult.Error.Message);
        }

        return new PhotoUploadDto
        {
            PublicId = uploadResult.PublicId,
            Url = uploadResult.SecureUrl.ToString()
        };
    }

    public async Task<string> DeletePhotoAsync(string publicId)
    {
        Account account = new
        (
            options.CloudName,
            options.ApiKey,
            options.ApiSecret
        );
        Cloudinary cloudinary = new(account);

        DeletionParams deleteParams = new(publicId);
        DeletionResult result = await cloudinary.DestroyAsync(deleteParams);

        if (result.Result != "ok")
        {
            throw new GatewayException($"Failed to delete photo with public ID: {publicId}. Error: {result.Error?.Message}");
        }

        return result.Result;
    }
}
