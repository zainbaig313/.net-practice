using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;

public class EmailService : IEmailService
{
    private readonly IConfiguration _config;

    public EmailService(IConfiguration config)
    {
        _config = config;
    }

    public async Task SendEmailAsync(
        string recipient,
        string subject,
        string body)
    {
        var senderEmail = _config["Email:SenderEmail"];
        var smtpHost = _config["Email:SmtpHost"];
        var smtpPort = _config.GetValue<int>("Email:SmtpPort");
        var appPassword = _config["Email:AppPassword"];

        if (string.IsNullOrWhiteSpace(senderEmail) ||
            string.IsNullOrWhiteSpace(smtpHost) ||
            string.IsNullOrWhiteSpace(appPassword))
        {
            throw new InvalidOperationException(
                "Email configuration is incomplete.");
        }

        var message = new MimeMessage();

        message.From.Add(
            new MailboxAddress("Email Demo", senderEmail));

        message.To.Add(
            MailboxAddress.Parse(recipient));

        message.Subject = subject;

        message.Body = new TextPart("plain")
        {
            Text = body
        };

        using var client = new SmtpClient();

        await client.ConnectAsync(
            smtpHost,
            smtpPort,
            SecureSocketOptions.StartTls);

        await client.AuthenticateAsync(
            senderEmail,
            appPassword);

        await client.SendAsync(message);

        await client.DisconnectAsync(true);
    }
}

