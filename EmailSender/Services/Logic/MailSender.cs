using EmailSender.ResourceModels;
using EmailSender.Services.Interfaces;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Threading.Tasks;

namespace EmailSender.Services.Logic
{
    public class MailSender : IMailSender
    {
        private readonly SmtpSettings _smtpSettings;

        public MailSender(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value ?? throw new ArgumentNullException(nameof(SmtpSettings));
        }

        public async Task SendAsync(string mailFrom, string[] recipients, string body, string subject)
        {
            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress(mailFrom));
            foreach (var recipient in recipients)
            {
                mimeMessage.To.Add(new MailboxAddress(recipient));
            }
            mimeMessage.Subject = subject;

            var builder = new BodyBuilder
            {
                HtmlBody = body
            };
            mimeMessage.Body = builder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_smtpSettings.Host, _smtpSettings.Port, _smtpSettings.UseSsl);
                await client.AuthenticateAsync(_smtpSettings.UserName, _smtpSettings.Password);
                await client.SendAsync(mimeMessage);
                await client.DisconnectAsync(true);
            }
        }
    }
}
