using System.Threading.Tasks;

namespace EmailSender.Services.Interfaces
{
    /// <summary>
    /// Сервис отправки писем на электронную почту.
    /// </summary>
    public interface IMailSender
    {
        /// <summary>
        /// Выполнит рассылку указанным адресатам.
        /// </summary>
        /// <param name="mailFrom">Адрес отправителя.</param>
        /// <param name="recipients">Адреса получателей.</param>
        /// <param name="body">Текст сообщения.</param>
        /// <param name="subject">Тема сообщения.</param>
        Task SendAsync(string mailFrom, string[] recipients, string body, string subject);
    }
}
