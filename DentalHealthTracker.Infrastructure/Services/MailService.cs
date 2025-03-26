using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System.Threading.Tasks;

public class MailService
{
    private readonly IConfiguration _configuration;

    public MailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendEmailAsync(string toEmail, string subject, string htmlContent)
    {
        var emailSettings = _configuration.GetSection("EmailSettings");

        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Dental Health", emailSettings["Sender"]));
        message.To.Add(new MailboxAddress("", toEmail));
        message.Subject = subject;

        var bodyBuilder = new BodyBuilder { HtmlBody = htmlContent };
        message.Body = bodyBuilder.ToMessageBody();

        using (var client = new SmtpClient())
        {
            await client.ConnectAsync(emailSettings["SmtpServer"], 587, SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(emailSettings["Username"], emailSettings["Password"]);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
    }
}
