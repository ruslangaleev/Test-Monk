using System.Threading.Tasks;

namespace EmailSender.Services.Interfaces
{
    /// <summary>
    /// Сервис отправки писем на электронную почту.
    /// </summary>
    public interface IMailSender
    {
        /// <summary>
        /// Отправляет письмо на электронные почты.
        /// </summary>
        /// <param name="mailFrom"></param>
        /// <param name="recipients"></param>
        /// <param name="body"></param>
        /// <param name="subject"></param>
        /// <returns></returns>
        Task SendAsync(string mailFrom, string[] recipients, string body, string subject);
    }
}
