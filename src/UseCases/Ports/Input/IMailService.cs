namespace UseCases.Ports.Input;

public interface IMailService
{
    Task<Result<bool>> SendEmailAsync(string toEmail, string subject, string htmlBody);
}
