namespace Domain.Dtos;

public sealed class SendMailDto
{
    public required string ToEmail { get; set; }
    public required string Subject { get; set; }
    public required string HtmlBody { get; set; }
}
