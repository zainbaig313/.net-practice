using MailKit;
using MailKit.Net.Imap;
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



        // if (client.Capabilities.HasFlag(SmtpCapabilities.Dsn))
        // {
        //     Console.WriteLine("DSN is supported!");
        // }
        // else
        // {
        //     Console.WriteLine("DSN is NOT supported!");
        // }
       await CheckBounceEmails();
        var response = await client.SendAsync(message);
        Console.WriteLine(response);
        await client.DisconnectAsync(true);
    }
    public async Task CheckBounceEmails()
    {

        var senderEmail = _config["Email:SenderEmail"];
        var imapHost = _config["Email:ImapHost"];
        var imapPort = _config.GetValue<int>("Email:ImapPort");
        var appPassword = _config["Email:AppPassword"];


        using var client = new ImapClient();

        await client.ConnectAsync(
            imapHost,
            imapPort,
            SecureSocketOptions.SslOnConnect
        );

        await client.AuthenticateAsync(
            senderEmail,
            appPassword
        );

        var inbox = client.Inbox;

        await inbox.OpenAsync(FolderAccess.ReadOnly);

        Console.WriteLine($"Total Emails: {inbox.Count}");

        await client.DisconnectAsync(true);
    }
}

