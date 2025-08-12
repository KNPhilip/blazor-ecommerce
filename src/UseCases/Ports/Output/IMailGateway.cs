namespace UseCases.Ports.Output;

public interface IMailGateway
{
    Task<Result<bool>> SendEmailAsync(string toEmail, string subject, string htmlBody);
}
