namespace Gateways.Options;

public sealed class CloudinaryOptions
{
    public static string SectionName => "Cloudinary";
    public required string CloudName { get; set; }
    public required string ApiKey { get; set; }
    public required string ApiSecret { get; set; }
}
