using EmailSender.Helpers;
using EmailSender.ResourceModels;
using EmailSender.Services.Interfaces;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Threading.Tasks;

namespace EmailSender.Services.Logic
{
    /// <summary>
    /// Сервис отправки писем на электронную почту.
    /// </summary>
    public class MailSender : IMailSender
    {
        /// <summary>
        /// Конфигурация для подключения к SMTP серверу.
        /// </summary>
        private readonly SmtpSettings _smtpSettings;

        /// <summary>
        /// Конструктор.
        /// </summary>
        public MailSender(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value ?? throw new ArgumentNullException(nameof(SmtpSettings));
        }

        /// <summary>
        /// Выполнит рассылку указанным адресатам.
        /// </summary>
        /// <param name="mailFrom">Адрес отправителя.</param>
        /// <param name="recipients">Адреса получателей.</param>
        /// <param name="body">Текст сообщения.</param>
        /// <param name="subject">Тема сообщения.</param>
        public async Task SendAsync(string mailFrom, string[] recipients, string body, string subject)
        {
            if (string.IsNullOrEmpty(mailFrom))
            {
                throw new ArgumentNullException(nameof(mailFrom), $"Необходимо указать адрес отправителя.");
            }

            if (!MailValidator.IsValid(mailFrom))
            {
                throw new ArgumentNullException(nameof(mailFrom), $"Адрес отправителя {mailFrom} указан не верно.");
            }

            if (recipients == null || recipients.Length == 0)
            {
                throw new ArgumentNullException(nameof(recipients), $"Необходимо указать как минимум одного получателя.");
            }

            foreach(var recipient in recipients)
            {
                if (!MailValidator.IsValid(recipient))
                {
                    throw new ArgumentNullException(nameof(recipient), $"Адрес получателя {recipient} указан не верно.");
                }
            }

            if (string.IsNullOrEmpty(body))
            {
                throw new ArgumentNullException(nameof(body), $"Необходимо указать сообщение.");
            }

            if (string.IsNullOrEmpty(subject))
            {
                throw new ArgumentNullException(nameof(subject), $"Необходимо указать тему сообщения.");
            }

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
