using Gateways.Options;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using UseCases;
using UseCases.Ports.Output;

namespace Gateways.Adapters;

public sealed class MailGateway(IOptions<MailSettingsOptions> mailOptions) : IMailGateway
{
    private readonly MailSettingsOptions _mailOptions = mailOptions.Value;

    public async Task<Result<bool>> SendEmailAsync(string toEmail, string subject, string htmlBody)
    {
        MailMessage message = new()
        {
            From = new(_mailOptions.FromEmail),
            Subject = subject,
            IsBodyHtml = true,
            Body = htmlBody
        };
        message.To.Add(new(toEmail));

        SmtpClient smtp = new()
        {
            Port = _mailOptions.Port,
            Host = _mailOptions.Host,
            EnableSsl = true,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(_mailOptions.Username, _mailOptions.Password),
            DeliveryMethod = SmtpDeliveryMethod.Network
        };

        try
        {
            await smtp.SendMailAsync(message);
            return true;
        }
        catch (Exception e)
        {
            return Result.Fail<bool>(e.Message.ToString());
        }
    }
}
