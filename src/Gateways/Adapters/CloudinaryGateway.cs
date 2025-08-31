using Microsoft.Extensions.Options;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Domain.Dtos;
using Gateways.Options;
using UseCases.Ports.Output;
using UseCases.Ports;

namespace Gateways.Adapters;

public sealed class CloudinaryGateway(IOptions<CloudinaryOptions> options) : IPhotoGateway
{
    private readonly CloudinaryOptions options = options.Value;

    public async Task<PhotoUploadDto> AddPhotoAsync(string base64String)
    {
        ArgumentNullException.ThrowIfNull(base64String);
        Cloudinary cloudinary = GetCloudinaryConnection();

        var stream = CreateStreamFromBase64(base64String);
        var uploadParams = CreateUploadParams(stream);

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

    private static MemoryStream CreateStreamFromBase64(string base64String)
    {
        var base64Data = base64String.Substring(base64String.IndexOf(",") + 1);
        byte[] imageBytes = Convert.FromBase64String(base64Data);
        return new MemoryStream(imageBytes);
    }

    private static ImageUploadParams CreateUploadParams(Stream stream)
    {
        return new ImageUploadParams
        {
            File = new FileDescription("upload.bin", stream),
            Transformation = new Transformation().Height(500).Width(500).Crop("fill")
        };
    }

    public async Task<string> DeletePhotoAsync(string publicId)
    {
        ArgumentNullException.ThrowIfNull(publicId);
        Cloudinary cloudinary = GetCloudinaryConnection();

        DeletionParams deleteParams = new(publicId);
        DeletionResult result = await cloudinary.DestroyAsync(deleteParams);

        if (result.Result != "ok")
        {
            throw new GatewayException($"Failed to delete photo with public ID: {publicId}. Error: {result.Error?.Message}");
        }

        return result.Result;
    }

    private Cloudinary GetCloudinaryConnection()
    {
        Account account = new
        (
            options.CloudName,
            options.ApiKey,
            options.ApiSecret
        );
        Cloudinary cloudinary = new(account);

        return cloudinary;
    }
}
