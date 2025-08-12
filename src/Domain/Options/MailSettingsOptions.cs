namespace Domain.Options;

public sealed class MailSettingsOptions
{
    public static string SectionName => "MailSettings";
    public required string Username { get; init; }
    public required string Password { get; init; }
    public required int Port { get; init; }
    public required string FromEmail { get; init; }
    public required string Host { get; init; }
}
