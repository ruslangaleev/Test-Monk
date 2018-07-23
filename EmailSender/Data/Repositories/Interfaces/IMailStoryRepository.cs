using EmailSender.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmailSender.Data.Repositories.Interfaces
{
    /// <summary>
    /// Репозиторий для работы с историей сообщений.
    /// </summary>
    public interface IMailStoryRepository
    {
        /// <summary>
        /// Вернет список всех сообщений.
        /// </summary>
        Task<IEnumerable<MailStory>> GetAsync();

        /// <summary>
        /// Добавит новую историю сообщения.
        /// </summary>
        Task AddAsync(MailStory mailStory);
    }
}
